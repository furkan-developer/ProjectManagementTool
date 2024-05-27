const allStageBody = document.querySelectorAll("#stage-body");
const allTask = document.querySelectorAll("#stage-body .task__wrapper");

allTask.forEach((element) => {
  element.setAttribute("draggable", "true");
  element.addEventListener("dragstart", taskDragStart);
  element.addEventListener("dragend", taskDragEnd);

  element.addEventListener("contextmenu", function (event) {
    event.preventDefault(); // prevent browser's contextmenu
    document.body.insertAdjacentHTML(
      "beforeend",
      `     
      <div id="taskContextMenu" class="taskContextMenu">
        <ul>
          <li>More details</li>
          <li>Delete</li>
        </ul>
      </div>`
    );
    let taskContextMenu = document.getElementById("taskContextMenu");
    taskContextMenu.addEventListener("mouseleave", function () {
      taskContextMenu.remove();
    });

    taskContextMenu.style.display = "block";
    taskContextMenu.style.left = event.pageX - 10 + "px";
    taskContextMenu.style.top = event.pageY - 10 + "px";

    let taskId = this.getAttribute("data-task-id");
    let options = taskContextMenu.querySelectorAll("ul li");
    options[0].addEventListener("click", function (ev) {
      // get more details operation
      fetch(`${LOCALHOST}Board/HasAssignmentAgainstTask`, {
        method: "POST",
        body: JSON.stringify({
          jobId: taskId,
        }),
        headers: {
          Accept: "application/json",
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.isSuccess) {
            window.location.href = `${LOCALHOST}board/getdetailsonetask/${taskId}`;
          } else {
            alert("You don't have assignment related task");
          }
        })
        .catch((err) => console.log(err));
    });
    options[1].addEventListener("click", function (e) {
      // Delete Operation
      fetch("https://localhost:7184/Board/DeleteOneTask", {
        method: "POST",
        body: JSON.stringify({
          jobId: taskId,
        }),
        headers: {
          Accept: "application/json",
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.isSuccess) {
            event.target.closest(".task__wrapper").remove();
          } else {
            alert(data.errorMessage);
          }
        })
        .catch((error) => console.error("Unable to add item.", error));
    });
  });
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

// create new task node
function createNewTask({ title, id, dueDate, priority, assignments }) {
  // Ana wrapper div
  const taskWrapper = document.createElement("div");
  taskWrapper.className = "task__wrapper";
  taskWrapper.setAttribute("data-task-id", `${id}`);
  taskWrapper.setAttribute("draggable", "true");

  // add events
  taskWrapper.addEventListener("dragstart",taskDragStart);
  taskWrapper.addEventListener("dragend",taskDragEnd);

  // Priority div
  const priorityDiv = document.createElement("div");
  let priortyClassName = "";
  switch (priority) {
    case 0:
      priortyClassName = "task-priority-low";
      break;
    case 1:
      priortyClassName = "task-priority-medium";
      break;
    case 2:
      priortyClassName = "task-priority-high";
      break;
  }
  priorityDiv.className = `${priortyClassName}`;
  taskWrapper.appendChild(priorityDiv);

  // Task div
  const taskDiv = document.createElement("div");
  taskDiv.className = "task";
  taskWrapper.appendChild(taskDiv);

  // Task top div
  const taskTopDiv = document.createElement("div");
  taskTopDiv.className = "task-top";
  taskDiv.appendChild(taskTopDiv);

  // Due date div
  const dueDateDiv = document.createElement("div");
  dueDateDiv.className = "due-date";
  taskTopDiv.appendChild(dueDateDiv);

  // SVG for due date
  const dueDateSvg = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "svg"
  );
  dueDateSvg.setAttribute("stroke", "currentColor");
  dueDateSvg.setAttribute("fill", "currentColor");
  dueDateSvg.setAttribute("stroke-width", "0");
  dueDateSvg.setAttribute("viewBox", "0 0 24 24");
  dueDateSvg.setAttribute("height", "1em");
  dueDateSvg.setAttribute("width", "1em");

  // Paths for SVG
  const dueDatePath1 = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "path"
  );
  dueDatePath1.setAttribute("fill", "none");
  dueDatePath1.setAttribute("d", "M0 0h24v24H0V0z");
  dueDateSvg.appendChild(dueDatePath1);

  const dueDatePath2 = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "path"
  );
  dueDatePath2.setAttribute(
    "d",
    "M7 11h2v2H7v-2zm14-5v14c0 1.1-.9 2-2 2H5a2 2 0 0 1-2-2l.01-14c0-1.1.88-2 1.99-2h1V2h2v2h8V2h2v2h1c1.1 0 2 .9 2 2zM5 8h14V6H5v2zm14 12V10H5v10h14zm-4-7h2v-2h-2v2zm-4 0h2v-2h-2v2z"
  );
  dueDateSvg.appendChild(dueDatePath2);

  dueDateDiv.appendChild(dueDateSvg);

  // Due date text
  const dueDateText = document.createElement("span");
  const d = new Date(dueDate);
  dueDateText.textContent = `${d.getDate()}/${
    d.getMonth() + 1
  }/${d.getFullYear()}`;
  dueDateDiv.appendChild(dueDateText);

  // Task body div
  const taskBodyDiv = document.createElement("div");
  taskBodyDiv.className = "task-body";
  taskDiv.appendChild(taskBodyDiv);

  // Task description
  const taskDescription = document.createElement("p");
  taskDescription.textContent = `${title}`;
  taskBodyDiv.appendChild(taskDescription);

  // Task footer wrapper div
  const taskFooterWrapperDiv = document.createElement("div");
  taskFooterWrapperDiv.className = "task-footer__wrapper";
  taskDiv.appendChild(taskFooterWrapperDiv);

  // Inner footer div
  const innerFooterDiv = document.createElement("div");
  taskFooterWrapperDiv.appendChild(innerFooterDiv);

  // Task footer div
  const taskFooterDiv = document.createElement("div");
  taskFooterDiv.className = "task-footer";
  innerFooterDiv.appendChild(taskFooterDiv);

  // Priority badge
  const priorityBadge = document.createElement("div");
  let badgeText = "";
  switch (priority) {
    case 0:
      badgeText = "low";
      break;
    case 1:
      badgeText = "Medium";
      break;
    case 2:
      badgeText = "high";
      break;
  }

  priorityBadge.className = `task-priority-bagde ${priortyClassName}`;
  priorityBadge.textContent = `${badgeText}`;
  taskFooterDiv.appendChild(priorityBadge);

  // Assignment div
  const assignmentDiv = document.createElement("div");
  assignmentDiv.className = "assignment";
  taskFooterDiv.appendChild(assignmentDiv);

  // Assignment list
  const assignmentList = document.createElement("ul");
  assignmentDiv.appendChild(assignmentList);

  // Assignment items
  for (const user of assignments) {
    const assignmentItem1 = document.createElement("li");
    assignmentItem1.innerHTML = `${user[0].toUpperCase()}<a href="#">${user}</a>`;
    assignmentList.appendChild(assignmentItem1);
  }

  // Plus icon SVG
  const plusIconSvg = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "svg"
  );
  plusIconSvg.setAttribute("stroke", "currentColor");
  plusIconSvg.setAttribute("fill", "currentColor");
  plusIconSvg.setAttribute("stroke-width", "0");
  plusIconSvg.setAttribute("viewBox", "0 0 512 512");
  plusIconSvg.setAttribute("height", "1em");
  plusIconSvg.setAttribute("width", "1em");

  // Paths for plus icon SVG
  const plusIconPath1 = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "path"
  );
  plusIconPath1.setAttribute(
    "d",
    "M346.5 240H272v-74.5c0-8.8-7.2-16-16-16s-16 7.2-16 16V240h-74.5c-8.8 0-16 6-16 16s7.5 16 16 16H240v74.5c0 9.5 7 16 16 16s16-7.2 16-16V272h74.5c8.8 0 16-7.2 16-16s-7.2-16-16-16z"
  );
  plusIconSvg.appendChild(plusIconPath1);

  const plusIconPath2 = document.createElementNS(
    "http://www.w3.org/2000/svg",
    "path"
  );
  plusIconPath2.setAttribute(
    "d",
    "M256 76c48.1 0 93.3 18.7 127.3 52.7S436 207.9 436 256s-18.7 93.3-52.7 127.3S304.1 436 256 436c-48.1 0-93.3-18.7-127.3-52.7S76 304.1 76 256s18.7-93.3 52.7-127.3S207.9 76 256 76m0-28C141.1 48 48 141.1 48 256s93.1 208 208 208 208-93.1 208-208S370.9 48 256 48z"
  );
  plusIconSvg.appendChild(plusIconPath2);

  taskFooterWrapperDiv.appendChild(plusIconSvg);

  return taskWrapper;
}

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
