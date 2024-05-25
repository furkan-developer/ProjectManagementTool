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

          if (!hasNotSubTaskInfoText.classList.contains("d-none"))
            hasNotSubTaskInfoText.classList.add("d-none");
        } else {
          console.log(result.errorMessages.toString());
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

connection
  .start()
  .then(function () {
    document.getElementById("add-comment-button").disabled = false;
    document
      .getElementById("add-comment-button")
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
  fetch(`${LOCALHOST}board/deleteonesubtask`, {
    method: "DELETE",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
      "SubTaskId": `${subTaskId}`,
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
