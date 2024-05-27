// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const LOCALHOST = "https://localhost:7184/";

function taskDragStart(ev){
    ev.currentTarget.classList.add("dragging");
}

function taskDragEnd(ev){
    ev.currentTarget.classList.remove("dragging");
}

function allowDrogOver(e) {
  e.preventDefault();
}

function setStageToDrop(ev) {
  let dropingArea = ev.currentTarget;

  let draggingTask = document.querySelector(".dragging");
  let currentStageOfDraggingTask = draggingTask.closest(".stage-body");
  let currentStageIdOfDraggingTask = draggingTask
    .closest(".stage")
    .getAttribute("data-stage-id");
  let targetStageIdOfDraggingTask = ev.target
    .closest(".stage")
    .getAttribute("data-stage-id");

  if (ev.currentTarget === currentStageOfDraggingTask) {
  } else {
    draggingTaskId = draggingTask.getAttribute("data-task-id");

    fetch("https://localhost:7184/Board/UpdateStageOfOneTask", {
      method: "POST",
      body: JSON.stringify({
        fromStage: currentStageIdOfDraggingTask,
        toStage: targetStageIdOfDraggingTask,
        taskId: draggingTaskId,
      }),
      headers: {
        Accept: "application/json",
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          dropingArea.insertBefore(
            draggingTask,
            dropingArea.lastElementChild
          );
        } else {
          Toastify({
            text: `${data.errorMessage}`,
            duration: 2000,
            newWindow: true,
            close: true,
            gravity: "top", // `top` or `bottom`
            position: "center", // `left`, `center` or `right`
            stopOnFocus: true, // Prevents dismissing of toast on hover
            style: {
              background: "linear-gradient(to right, #f6d365, #fda085)",
            },
            onClick: function () {}, // Callback after click
          }).showToast();
        }
      })
      .catch((error) => console.error("Unable to add item.", error));
  }
}
