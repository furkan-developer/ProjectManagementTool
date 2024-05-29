const allStageBody = document.querySelectorAll("#stage-body");
const allTask = document.querySelectorAll("#stage-body .task__wrapper");

allTask.forEach((element) => {
  element.setAttribute("draggable", "true");
  element.addEventListener("dragstart", taskDragStart);
  element.addEventListener("dragend", taskDragEnd);

  element.addEventListener("contextmenu", contextMenuHandler);
});

allStageBody.forEach((element) => {
  element.addEventListener("dragover", function (e) {
    e.preventDefault();
  });

  element.addEventListener("drop", setStageToDrop);

  // element.addEventListener("dragenter", function () {
  //   this.style.opacity = "0.5";
  // });

  // element.addEventListener("dragleave", function () {
  //   this.style.opacity = "1";
  // });
});

// CREATE ONE TASK DIALOG
let taskForm = document.getElementById("taskForm");
let createTaskDialog = document.getElementById("create-one-task-dialog");
let closeDialogBtn = document.getElementById("create-task-dialog-close-btn");
let assignToInput = document.getElementById("assignTo");
let assignToList = document.getElementById("assignToList");
let dropdownIcon = document.getElementById("dropdownIcon");
let dialogCreateTaskButton = document.getElementById(
  "dialog-create-task-button"
);

taskForm.addEventListener("submit", function (event) {
  event.preventDefault();
  let stageId = dialogCreateTaskButton.getAttribute("data-target-stage-id");
  const form = event.target;
  const formData = new FormData(form);
  const formObject = Object.fromEntries(formData.entries());

  const assignments = [];
  formData.getAll("assignments").forEach((value) => {
    assignments.push(value);
  });
  formObject.assignments = assignments;

  // Priority değerini sayısal olarak ayarla
  if (formObject["priority"]) {
    switch (formObject["priority"].toLowerCase()) {
      case "low":
        formObject["priority"] = 0;
        break;
      case "medium":
        formObject["priority"] = 1;
        break;
      case "high":
        formObject["priority"] = 2;
        break;
    }
  }

  let connectionId = document
    .getElementById("websocket-connection-container")
    .getAttribute("data-connection-id");

  fetch(`${LOCALHOST}board/createonetask`, {
    method: "POST",
    body: JSON.stringify({
      title: formObject.title,
      description: formObject.description,
      priority: formObject.priority,
      dueDate: formObject.dueDate,
      assignments: formObject.assignments,
      stageId: `${stageId}`,
    }),
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      "Hub-Connection-Id": `${connectionId}`,
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        const currentStages = document.querySelectorAll("[data-stage-id]");

        let associatedStage;
        for (let index = 0; index < currentStages.length; index++) {
          const element = currentStages[index];
          if (element.getAttribute("data-stage-id") == stageId) {
            associatedStage = element;
            break;
          }
        }

        if (associatedStage) {
          const stageBody = associatedStage.querySelector("#stage-body");
          const lastChildAtStageBody =
            stageBody.querySelector(".add-task-button");
          stageBody.insertBefore(
            createNewTask(result.data),
            lastChildAtStageBody
          );
        }
      } else {
        Toastify({
          text: `${result.errorMessages}`,
          duration: 2000,
          close: true,
          gravity: "top",
          position: "center",
          stopOnFocus: true,
          style: {
            background: "linear-gradient(to right, #f6d365, #fda085)",
          },
        }).showToast();
      }
    })
    .catch((err) => console.log(err));
});

function showDialog(element) {
  let stageId = element.closest(".stage").getAttribute("data-stage-id");
  let boardId = element.getAttribute("data-board-id");

  dialogCreateTaskButton.setAttribute("data-target-stage-id", stageId);

  fetch(`${LOCALHOST}board/getusersat/${boardId}`, {
    method: "GET",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        let userCheckboxGroup = document.getElementById("user-checkbox-group");
        for (const user of result.users) {
          userCheckboxGroup.insertAdjacentHTML(
            "beforeend",
            `
            <div class="checkbox-item">
              <input name="assignments" value="${user.id}" type="checkbox"><span>${user.fullName}</span>
            </div>
            `
          );
        }
        // open dialog
        createTaskDialog.showModal();
      } else {
        alert(result.errorMessages.toString());
      }
    })
    .catch((err) => console.log(err));
}

closeDialogBtn.addEventListener("click", () => {
  createTaskDialog.close();
});

assignToInput.addEventListener("focus", () => {
  assignToList.style.display = "block";
  dropdownIcon.classList.toggle("rotate-180");
});

assignToInput.addEventListener("blur", (event) => {
  setTimeout(() => {
    if (!assignToList.contains(document.activeElement)) {
      assignToList.style.display = "none";
      dropdownIcon.classList.toggle("rotate-180");
    }
  }, 100);
});

dropdownIcon.addEventListener("click", function () {
  this.classList.toggle("rotate-180");
  let assignToList = document.getElementById("assignToList");
  if (assignToList.style.display === "block") {
    assignToList.style.display = "none";
  } else {
    assignToList.style.display = "block";
  }
});

assignToInput.addEventListener("input", () => {
  const filter = assignToInput.value.toLowerCase().trim();
  let users = document
    .getElementById("user-checkbox-group")
    .querySelectorAll("span");

  users.forEach((user) => {
    const name = user.textContent.toLowerCase();
    if (name.startsWith(filter)) {
      user.closest(".checkbox-item").style.display = "";
    } else {
      user.closest(".checkbox-item").style.display = "none";
    }
  });
});

createTaskDialog.addEventListener("close", function () {
  let userCheckboxGroup = document.getElementById("user-checkbox-group");
  while (userCheckboxGroup.hasChildNodes())
    userCheckboxGroup.removeChild(userCheckboxGroup.firstChild);

  dropdownIcon.classList.toggle("rotate-180");
  if (assignToList.style.display === "block") {
    assignToList.style.display = "none";
  } else {
    assignToList.style.display = "block";
  }
});

// WEBSOCKET CONNECTION
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/getdetailsoneboardhub")
  .build();

connection.on("UpdateStageOfTask", function ({ fromStage, toStage, taskId }) {
  let allStageBodies = document.querySelectorAll("#stage-body");
  let allTasks = document.querySelectorAll(".task__wrapper");

  let draggedTaskElement;
  for (let index = 0; index < allTasks.length; index++) {
    let draggedTaskId = allTasks[index].getAttribute("data-task-id");
    if (draggedTaskId == taskId) {
      draggedTaskElement = allTasks[index];
      break;
    }
  }

  for (let index = 0; index < allStageBodies.length; index++) {
    let stageBody = allStageBodies[index];
    let stageBodyId = stageBody.closest(".stage").getAttribute("data-stage-id");

    if (stageBodyId == toStage) {
      let lastChildOfStageBody = stageBody.querySelector(".add-task-button");
      stageBody.insertBefore(draggedTaskElement, lastChildOfStageBody);
      break;
    }
  }
});

connection.on("AddNewTaskToStage", function (data) {
  const newTask = createNewTask(data);

  let allStageBodies = document.querySelectorAll("#stage-body");
  for (let index = 0; index < allStageBodies.length; index++) {
    let stageBody = allStageBodies[index];
    let stageBodyId = stageBody.closest(".stage").getAttribute("data-stage-id");

    if (stageBodyId == data.stageId) {
      let lastChildOfStageBody = stageBody.querySelector(".add-task-button");
      stageBody.insertBefore(newTask, lastChildOfStageBody);
      break;
    }
  }
});

connection.on("DeleteOneTask", function (data) {
  let allTasks = document.querySelectorAll(".task__wrapper");

  for (let index = 0; index < allTasks.length; index++) {
    let avalibaleTaskId = allTasks[index].getAttribute("data-task-id");
    if (avalibaleTaskId == data.taskId) {
      allTasks[index].remove();
      break;
    }
  }
});

connection.on("CreateOneStage", function ({ boardId, stageId, stageName }) {
  console.log(boardId);
  console.log(stageName);
  console.log(stageId);

  let stagesArea = document.getElementById("stages");
  if (stagesArea.getAttribute("data-board-id") == boardId) {
    console.log("Bu board doğru board");

    let userRoleContainer = document.getElementById("user-role-container");
    if (userRoleContainer) {
      let createTaskButton = `
          <a onclick="showDialog(this)" data-board-id="${boardId}" class="add-task-button">
          <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" height="1em"
              width="1em" xmlns="http://www.w3.org/2000/svg">
              <path
                  d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z">
              </path>
          </svg>
          <span>Add Task</span>
      </a>`;

      let topCreateTaskButton = `
          <a onclick="showDialog(this)" data-board-id="${boardId}">
            <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" height="1em"
                width="1em" xmlns="http://www.w3.org/2000/svg">
                <path
                    d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z">
                </path>
            </svg>
        </a>`;

      stagesArea.insertAdjacentHTML(
        "beforeend",
        `
          <div class="stage" data-stage-id="${stageId}">
            <div class="stage-header">
                <p>${stageName}</p>
                ${topCreateTaskButton}
            </div>
            <div id="stage-body" class="stage-body" ondrop="setStageToDrop(event)" ondragover="allowDrogOver(event)">
                ${createTaskButton}
            </div>
          </div>
        `
      );
    } else {
      stagesArea.insertAdjacentHTML(
        "beforeend",
        `
          <div class="stage" data-stage-id="${stageId}">
            <div class="stage-header">
                <p>${stageName}</p>
            </div>
            <div id="stage-body" class="stage-body" ondrop="setStageToDrop(event)" ondragover="allowDrogOver(event)">
            </div>
          </div>
        `
      );
    }
  } else {
    console.log("Bu board yanlış board. stage buraya eklenmeyecek");
  }
});

connection
  .start()
  .then(function () {
    document
      .getElementById("websocket-connection-container")
      .setAttribute("data-connection-id", connection.connectionId);
  })
  .catch(function (err) {
    return console.error(err.toString());
  });

connection.on("UpdateIsCompleteTaskIcon", function (data) {
  let allTasks = document.querySelectorAll(".task__wrapper");

  for (let index = 0; index < allTasks.length; index++) {
    let avalibaleTaskId = allTasks[index].getAttribute("data-task-id");

    if (avalibaleTaskId == data.taskId) {

      let isCompleteIcon = allTasks[index].querySelector("#is-complete-icon");
      if (isCompleteIcon) {
        isCompleteIcon.remove();
      } else {
        let taskFooter = allTasks[index].querySelector(".task-footer__wrapper");
        taskFooter.insertAdjacentHTML(
          "beforeend",
          `
        <svg id="is-complete-icon" stroke="currentColor" fill="currentColor" stroke-width="0" version="1.2" baseProfile="tiny" viewBox="0 0 24 24" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M16.972 6.251c-.967-.538-2.185-.188-2.72.777l-3.713 6.682-2.125-2.125c-.781-.781-2.047-.781-2.828 0-.781.781-.781 2.047 0 2.828l4 4c.378.379.888.587 1.414.587l.277-.02c.621-.087 1.166-.46 1.471-1.009l5-9c.537-.966.189-2.183-.776-2.72z"></path></svg>
        `
        );
      }
      break;
    }
  }
});
