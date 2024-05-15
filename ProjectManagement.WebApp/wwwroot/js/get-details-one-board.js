const allStageBody = document.querySelectorAll("#stage-body");
const allTask = document.querySelectorAll("#stage-body .task__wrapper");

allTask.forEach((element) => {
  element.setAttribute("draggable", "true");
  element.addEventListener("dragstart", function () {
    this.classList.add("dragging");
  });
  element.addEventListener("dragend", function () {
    this.classList.remove("dragging");
  });
});

allStageBody.forEach((element) => {
  element.addEventListener("dragover", function (e) {
    e.preventDefault();
  });

  element.addEventListener("drop", function () {
    let draggingTask = document.querySelector(".dragging");
    let currentStageOfDraggingTask = draggingTask.closest(".stage-body");
    let currentStageIdOfDraggingTask = draggingTask
      .closest(".stage")
      .getAttribute("data-stage-id");
    let targetStageIdOfDraggingTask =
      this.closest(".stage").getAttribute("data-stage-id");

    if (this === currentStageOfDraggingTask) {
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
            this.insertBefore(draggingTask, this.lastElementChild);
          } else {
            alert(data.errorMessage);
          }
        })
        .catch((error) => console.error("Unable to add item.", error));
    }
  });

  // element.addEventListener("dragenter", function () {
  //   this.style.opacity = "0.5";
  // });

  // element.addEventListener("dragleave", function () {
  //   this.style.opacity = "1";
  // });
});
