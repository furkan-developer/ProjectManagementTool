let createStageButton = document.getElementById("create-stage-button");
let createStageForm = document.getElementById("create-stage-form");
let createStageFormPiece = document.getElementById("create-stage-form-piece");
let createStageFormCloseButton = document.getElementById(
  "create-stage-form-close-btn"
);

createStageButton.addEventListener("click", function (event) {
  if (!(event.target == createStageFormCloseButton)) {
    if (createStageForm.classList.contains("d-none"))
      createStageForm.classList.remove("d-none");
      createStageFormPiece.classList.remove("d-none");
  }
});

createStageFormCloseButton.addEventListener("click", function () {
  let createStageForm = document.getElementById("create-stage-form");
  console.log(!createStageForm.classList.contains("d-none"));
  if (!createStageForm.classList.contains("d-none")) {
    createStageForm.classList.add("d-none");
    createStageFormPiece.classList.add("d-none");
  }
});

function createStage(element) {
  let boardId = element.getAttribute("data-board-id");
  let stageName = document.getElementById("create-stage-input").value.trim();

  fetch(`${LOCALHOST}board/createonestage`, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
    },
    body: JSON.stringify({
      boardId: `${boardId}`,
      stageName: `${stageName}`,
    }),
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.isSuccess) {
        Toastify({
          text: `${result.data.stageName} has been created`,
          duration: 3000,
          close: true,
          gravity: "top", 
          position: "center", 
          stopOnFocus: true, 
          style: {
            background: "linear-gradient(to right, #a8e063, #56ab2f)",
          }
        }).showToast();

        let stages = document.getElementById("stages");
        console.log(stages);
        stages.insertAdjacentHTML(
          "beforeend",
          `
            <div class="stage" data-stage-id="${result.data.stageId}">
              <div class="stage-header">
                  <p>${result.data.stageName}</p>
                  <a
                      href="/Board/CreateOneTask?boardId=${result.data.boardId}&stageId=${result.data.stageId}&returnUrl=/Board/GetDetailsOneBoard?boardId=${result.data.boardId}">
                      <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" height="1em"
                          width="1em" xmlns="http://www.w3.org/2000/svg">
                          <path
                              d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z">
                          </path>
                      </svg>
                  </a>
              </div>
              <div id="stage-body" class="stage-body">
                  <a href="/Board/CreateOneTask?boardId=${result.data.boardId}&stageId=${result.data.stageId}&returnUrl=/Board/GetDetailsOneBoard?boardId=${result.data.boardId}"
                      class="add-task-button">
                      <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" height="1em"
                          width="1em" xmlns="http://www.w3.org/2000/svg">
                          <path
                              d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z">
                          </path>
                      </svg>
                      <span>Add Task</span>
                  </a>
              </div>
            </div>
      `
        );
      } else {
        Toastify({
          text: `${result.errorMessages.toString()}`,
          duration: 3000,
          close: true,
          gravity: "top", 
          position: "center", 
          stopOnFocus: true,
          style: {
            background: "linear-gradient(to right, #f6d365, #fda085)",
          }
        }).showToast();
      }
    })
    .catch((err) => console.log(err));
}
