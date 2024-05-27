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
    let connectionId = document.getElementById("websocket-connection-container").getAttribute("data-connection-id");

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
        "Hub-Connection-Id": `${connectionId}`
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

// create new task node
function createNewTask({ title, id, dueDate, priority, assignments }) {
  // Ana wrapper div
  const taskWrapper = document.createElement("div");
  taskWrapper.className = "task__wrapper";
  taskWrapper.setAttribute("data-task-id", `${id}`);
  taskWrapper.setAttribute("draggable", "true");

  // add events
  taskWrapper.addEventListener("dragstart", taskDragStart);
  taskWrapper.addEventListener("dragend", taskDragEnd);

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
