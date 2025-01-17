let subTaskCheckBox = document.getElementById("sub-task-checkbox");
let subTaskAddButton = document.getElementById("sub-task-add-button");
let subTaskInputText = document.getElementById("sub-task-input-text");
let subTaskInputCheck = document.getElementById("sub-task-input-check");

subTaskAddButton.addEventListener("click", function (ev) {
  let subTaskTitle = subTaskInputText.value.trim();
  if (subTaskTitle === "") {
    alert("Sub task title is not empty");
  } else {
    let taskId = this.getAttribute("data-task-id");
    let isSubTaskInputCheck = subTaskInputCheck.checked;
    let connectionId = document
      .getElementById("sub-task-add-button")
      .getAttribute("data-connection-id");

    fetch(`${LOCALHOST}board/createonesubtask`, {
      method: "POST",
      body: JSON.stringify({
        title: `${subTaskTitle}`,
        taskId: `${taskId}`,
        isComplete: isSubTaskInputCheck,
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
          subTaskInputText.value = "";
          let subTaskListArea = document.getElementById("sub-task-list-area");
          let hasNotSubTaskInfoText = document.getElementById(
            "has-not-sub-task-info"
          );
          subTaskListArea.insertAdjacentHTML(
            `${subTaskInputCheck.checked ? "afterbegin" : "beforeend"}`,
            `
              <div data-sub-task-id="${
                result.subTaskId
              }" class="d-flex align-items-center justify-content-between sub-task">
                <div class="d-flex align-items-center gap-2">
                    <input type="checkbox" class="form-check-input" ${
                      isSubTaskInputCheck ? "checked" : ""
                    } onchange="updateSubtaskStatus(this)">
                    <p class="lead mb-0">${subTaskTitle}</p>
                </div>
                <svg id="sub-task-delete-icon" onclick="deleteSubTask(this)" stroke="currentColor" fill="currentColor" stroke-width="0"
                    viewBox="0 0 448 512" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg">
                    <path
                        d="M268 416h24a12 12 0 0 0 12-12V188a12 12 0 0 0-12-12h-24a12 12 0 0 0-12 12v216a12 12 0 0 0 12 12zM432 80h-82.41l-34-56.7A48 48 0 0 0 274.41 0H173.59a48 48 0 0 0-41.16 23.3L98.41 80H16A16 16 0 0 0 0 96v16a16 16 0 0 0 16 16h16v336a48 48 0 0 0 48 48h288a48 48 0 0 0 48-48V128h16a16 16 0 0 0 16-16V96a16 16 0 0 0-16-16zM171.84 50.91A6 6 0 0 1 177 48h94a6 6 0 0 1 5.15 2.91L293.61 80H154.39zM368 464H80V128h288zm-212-48h24a12 12 0 0 0 12-12V188a12 12 0 0 0-12-12h-24a12 12 0 0 0-12 12v216a12 12 0 0 0 12 12z">
                    </path>
                </svg>
              </div>
            `
          );

          if (subTaskInputCheck.checked) subTaskInputCheck.checked = false;

          if (hasNotSubTaskInfoText) {
            if (!hasNotSubTaskInfoText.classList.contains("d-none"))
              hasNotSubTaskInfoText.classList.add("d-none");
          }
        } else {
          Toastify({
            text: `${result.errorMessages.toString()}`,
            duration: 2000,
            gravity: "top",
            position: "center",
            stopOnFocus: true,
            style: {
              background: "linear-gradient(to right, #f6d365, #fda085)",
            },
            onClick: function () {},
          }).showToast();
        }
      })
      .catch((err) => console.log(err));
  }
});

// add comment
// websocket connection
document.getElementById("add-comment-button").disabled = true;

var connection = new signalR.HubConnectionBuilder()
  .withUrl("/commentHub")
  .build();

connection.on("RecieveComment", function ({ content, fullName }) {
  let comments = document.getElementById("comments");
  comments.insertAdjacentHTML(
    "beforeend",
    `
    <div class="comment incoming">
        <div class="sender">${fullName}</div>
        <div class="text">${content}</div>
    </div>
    `
  );
});

connection.on("DeleteOneSubTask", function ({ subtaskId }) {
  let allSubTasks = document.querySelectorAll(".sub-task");

  for (let index = 0; index < allSubTasks.length; index++) {
    let avalibaleSubTaskId = allSubTasks[index].getAttribute("data-sub-task-id");
    if (avalibaleSubTaskId == subtaskId){
      allSubTasks[index].remove();
      break;
    }
  }
});

connection.on("CreateOneSubTask", function ({ id, title, isComplete, jobId }) {
  console.log("Create one Sub task connection");

  let currentJobId = document
    .getElementById("job-information-container")
    .getAttribute("data-job-id");

  if (currentJobId == jobId) {
    let subTaskListArea = document.getElementById("sub-task-list-area");
    let hasNotSubtaskInfo = subTaskListArea.querySelector(
      "#has-not-sub-task-info"
    );

    if (hasNotSubtaskInfo) {
      hasNotSubtaskInfo.classList.add("d-none");
    }

    let checkedText = "checked";
    let emptyText = "";
    let beforeendText = "beforeend";
    let afterbeginText = "afterbegin";

    console.log("Sub task list area");
    console.log(subTaskListArea);

    subTaskListArea.insertAdjacentHTML(
      `${isComplete ? afterbeginText : beforeendText}`,
      `
        <div data-sub-task-id="${id}" onchange="updateSubtaskStatus(this)"
        class="d-flex align-items-center justify-content-between sub-task">
        <div class="d-flex align-items-center gap-2">
            <input type="checkbox" class="form-check-input" ${
              isComplete ? checkedText : emptyText
            }>
            <p class="lead mb-0">${title}</p>
        </div>
        <svg id="sub-task-delete-icon" onclick="deleteSubTask(this)" stroke="currentColor" fill="currentColor"
            stroke-width="0" viewBox="0 0 448 512" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg">
            <path
                d="M268 416h24a12 12 0 0 0 12-12V188a12 12 0 0 0-12-12h-24a12 12 0 0 0-12 12v216a12 12 0 0 0 12 12zM432 80h-82.41l-34-56.7A48 48 0 0 0 274.41 0H173.59a48 48 0 0 0-41.16 23.3L98.41 80H16A16 16 0 0 0 0 96v16a16 16 0 0 0 16 16h16v336a48 48 0 0 0 48 48h288a48 48 0 0 0 48-48V128h16a16 16 0 0 0 16-16V96a16 16 0 0 0-16-16zM171.84 50.91A6 6 0 0 1 177 48h94a6 6 0 0 1 5.15 2.91L293.61 80H154.39zM368 464H80V128h288zm-212-48h24a12 12 0 0 0 12-12V188a12 12 0 0 0-12-12h-24a12 12 0 0 0-12 12v216a12 12 0 0 0 12 12z">
            </path>
        </svg>
      </div>
    `
    );
  }
});

connection
  .start()
  .then(function () {
    document.getElementById("add-comment-button").disabled = false;
    document
      .getElementById("add-comment-button")
      .setAttribute("data-connection-id", connection.connectionId);
    document
      .getElementById("sub-task-add-button")
      .setAttribute("data-connection-id", connection.connectionId);
  })
  .catch(function (err) {
    return console.error(err.toString());
  });

let addCommentButton = document.getElementById("add-comment-button");
let comments = document.getElementById("comments");
let commentInput = document.getElementById("comment-input");
addCommentButton.addEventListener("click", function (ev) {
  let comment = commentInput.value;
  let toJob = commentInput.getAttribute("data-job-id");
  let connectionId = this.getAttribute("data-connection-id");

  fetch(`${LOCALHOST}board/postcomment`, {
    method: "POST",
    body: JSON.stringify({
      content: comment,
      toJob: toJob,
    }),
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      "Hub-connection-id": `${connectionId}`,
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        comments.insertAdjacentHTML(
          "beforeend",
          `
          <div class="comment outgoing">
              <div class="sender">Ben</div>
              <div class="text">${comment}</div>
          </div>
          `
        );
        commentInput.value = "";

        let hasNotCommentInfoText = document.getElementById(
          "has-not-comment-info"
        );
        if (!hasNotCommentInfoText.classList.contains("d-none"))
          hasNotCommentInfoText.classList.add("d-none");
      } else {
        Toastify({
          text: `${result.errorMessages.toString()}`,
          duration: 2000,
          newWindow: true,
          close: true,
          gravity: "top",
          position: "center",
          stopOnFocus: true,
          style: {
            background: "linear-gradient(to right, #f6d365, #fda085)",
          },
          onClick: function () {},
        }).showToast();
      }
    })
    .catch((err) => console.log(err));
});

function updateSubtaskStatus(element) {
  let subTaskId = element.closest(".sub-task").getAttribute("data-sub-task-id");
  fetch(`${LOCALHOST}board/updateonesubtaskstatus`, {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      SubTaskId: `${subTaskId}`,
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        alert("Update process has completed successfully");
      } else {
        console.log(result.errorMessages);
      }
    })
    .catch((err) => console.log(err));
}

function deleteSubTask(element) {
  let subTaskId = element.closest(".sub-task").getAttribute("data-sub-task-id");
  let connectionId = document
    .getElementById("sub-task-add-button")
    .getAttribute("data-connection-id");

  fetch(`${LOCALHOST}board/deleteonesubtask`, {
    method: "DELETE",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      SubTaskId: `${subTaskId}`,
      "Hub-Connection-Id": `${connectionId}`,
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        alert("Delete process has completed successfully");
        element.closest(".sub-task").remove();
      } else {
        console.log(result.errorMessages);
      }
    })
    .catch((err) => console.log(err));
}

// UPDATE TASK STATUS
let updateTaskStatus = document.getElementById("update-task-status");
updateTaskStatus.addEventListener("click", function (ev) {
  let taskId = this.getAttribute("data-task-id");

  fetch(`${LOCALHOST}board/updatetaskstatus`, {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      TaskId: `${taskId}`,
    },
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        alert("update process has completed successfully");

        while (this.firstChild) {
          this.removeChild(this.firstChild);
          // element.firstChild.remove();
        }

        if (result.data.isComplete) {
          console.log("İsComplete = true");
          this.insertAdjacentHTML(
            "beforeend",
            `
            <svg stroke="currentColor" fill="currentColor" stroke-width="0" version="1.1" viewBox="0 0 16 16" height="1em"
                width="1em" xmlns="http://www.w3.org/2000/svg">
                <path
                    d="M15.854 12.854c-0-0-0-0-0-0l-4.854-4.854 4.854-4.854c0-0 0-0 0-0 0.052-0.052 0.090-0.113 0.114-0.178 0.066-0.178 0.028-0.386-0.114-0.529l-2.293-2.293c-0.143-0.143-0.351-0.181-0.529-0.114-0.065 0.024-0.126 0.062-0.178 0.114 0 0-0 0-0 0l-4.854 4.854-4.854-4.854c-0-0-0-0-0-0-0.052-0.052-0.113-0.090-0.178-0.114-0.178-0.066-0.386-0.029-0.529 0.114l-2.293 2.293c-0.143 0.143-0.181 0.351-0.114 0.529 0.024 0.065 0.062 0.126 0.114 0.178 0 0 0 0 0 0l4.854 4.854-4.854 4.854c-0 0-0 0-0 0-0.052 0.052-0.090 0.113-0.114 0.178-0.066 0.178-0.029 0.386 0.114 0.529l2.293 2.293c0.143 0.143 0.351 0.181 0.529 0.114 0.065-0.024 0.126-0.062 0.178-0.114 0-0 0-0 0-0l4.854-4.854 4.854 4.854c0 0 0 0 0 0 0.052 0.052 0.113 0.090 0.178 0.114 0.178 0.066 0.386 0.029 0.529-0.114l2.293-2.293c0.143-0.143 0.181-0.351 0.114-0.529-0.024-0.065-0.062-0.126-0.114-0.178z">
                </path>
            </svg>
            <span class="ps-2">Again raise</span>
          `
          );
        } else {
          console.log("İsComplete = false");
          this.insertAdjacentHTML(
            "beforeend",
            `
            <svg stroke="currentColor" fill="currentColor" stroke-width="0" version="1.1" viewBox="0 0 16 16" height="1em"
            width="1em" xmlns="http://www.w3.org/2000/svg">
            <path
                d="M6.21 14.339l-6.217-6.119 3.084-3.035 3.133 3.083 6.713-6.607 3.084 3.035-9.797 9.643zM1.686 8.22l4.524 4.453 8.104-7.976-1.391-1.369-6.713 6.607-3.133-3.083-1.391 1.369z">
            </path>
            </svg>
            <span class="ps-2">Mark Complete</span>
          `
          );
        }
      } else {
        console.log(result.errorMessages);
      }
    })
    .catch((err) => console.log(err));
});
