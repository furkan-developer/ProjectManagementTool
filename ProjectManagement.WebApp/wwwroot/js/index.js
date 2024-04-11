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
    let currentAreaOfDraggingTask = draggingTask.closest(".stage-body");

    if (this === currentAreaOfDraggingTask) {
    } else {
      this.insertBefore(draggingTask, this.lastElementChild);

      alert("Update stage information of task in server. Nonetheless create update http request for this one");
    }
  });

  // element.addEventListener("dragenter", function () {
  //   this.style.opacity = "0.5";
  // });

  // element.addEventListener("dragleave", function () {
  //   this.style.opacity = "1";
  // });
});
