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
      console.log(`clicked : ${ev.currentTarget}`);
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
        .then(data => {
          if(data.isSuccess){
            window.location.href = `${LOCALHOST}board/getdetailsonetask/${taskId}`;
          }
          else{
            alert("You don't have assignment against the task")  
          }
        })
        .catch(err => console.log(err))
    });
    options[1].addEventListener("click", function (e) {
      // Delete Operation
      console.log(taskId);

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
  });

  // element.addEventListener("dragenter", function () {
  //   this.style.opacity = "0.5";
  // });

  // element.addEventListener("dragleave", function () {
  //   this.style.opacity = "1";
  // });
});
