const addStageButton = document.getElementById("add-stage-button");
const stageName = document.getElementById("stage-name");
const stageDescription = document.getElementById("stage-description");
const stageListTableBody = document.getElementById("stage-list-table-body");
const emptyStageListText = document.getElementById("empty-stage-list-text");
const formElement = document.querySelector("form");
const stageDatasField = document.getElementById("stage-datas-field");

addStageButton.addEventListener("click", function (ev) {
  let stageNameValue = stageName.value.trim();
  if (!stageNameValue) alert("Stage name must be not empty");
  else {
    let count = stageListTableBody.children.length;

    stageListTableBody.insertAdjacentHTML(
      "beforeend",
      `
        <tr>
            <td>${stageNameValue}</td>
            <td><svg data-order="${count}" stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M32 464a48 48 0 0 0 48 48h288a48 48 0 0 0 48-48V128H32zm272-256a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zm-96 0a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zm-96 0a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zM432 32H312l-9.4-18.7A24 24 0 0 0 281.1 0H166.8a23.72 23.72 0 0 0-21.4 13.3L136 32H16A16 16 0 0 0 0 48v32a16 16 0 0 0 16 16h416a16 16 0 0 0 16-16V48a16 16 0 0 0-16-16z"></path></svg></td>
        </tr>
        `
    );

    if (!emptyStageListText.classList.contains("d-none"))
      emptyStageListText.classList.add("d-none");

    stageListTableBody.lastElementChild
      .querySelector("svg")
      .addEventListener("click", function () {
        // Performing delete stage created in form operation using trash icon
        let parentTr = this.closest("tr");
        let dataOrder = this.getAttribute("data-order");
        let stageDatasLength = stageDatasField.children.length - 1;

        if (dataOrder < stageDatasLength) {
          stageDatasField.children.item(dataOrder).remove();
          stageListTableBody.children.item(dataOrder).remove();
          let iterateStageData = stageDatasField.children;
          let iterateStageListTable =
            stageListTableBody.querySelectorAll("svg");
          for (
            let index = dataOrder;
            index < iterateStageData.length;
            index++
          ) {
            let stageDatachildren = iterateStageData[index].children;
            iterateStageListTable[index].setAttribute("data-order", `${index}`);
            for (const element of stageDatachildren) {
              if (element.getAttribute("data-identifier") == "stage-name") {
                element.setAttribute("id", `Stages_${index}__StageName`);
                element.setAttribute("name", `Stages[${index}].StageName`);
              } else {
                element.setAttribute("id", `Stages_${index}__Description`);
                element.setAttribute("name", `Stages[${index}].Description`);
              }
            }
          }
        } else {
          parentTr.remove();
          stageDatasField.children[stageDatasLength].remove();
        }

        if (stageListTableBody.children.length < 1)
          emptyStageListText.classList.remove("d-none");
      });

    stageDatasField.insertAdjacentHTML(
      "beforeend",
      `
        <div data-order="${count}">
          <input data-identifier="stage-name" type="hidden" id="Stages_${count}__StageName" name="Stages[${count}].StageName" value="${stageNameValue}"/>
          <input data-identifier="stage-description" type="hidden" id="Stages_${count}__Description" name="Stages[${count}].Description" value="${stageDescription.value}"/>
        </div>
        `
    );

    stageName.value = "";
    stageDescription.value = "";
  }
});

// Search users in check list
const searchInput = document.getElementById("user-search");
const userList = document.getElementById("user-list");
const notFoundliItem = document.getElementById("not-found-li-item");
const usersListItems = document.querySelectorAll("#user-list li");
searchInput.addEventListener("input", function (ev) {
  let searchText = this.value.toLowerCase().trim();
  let hasMoreOneUserFound = false;
  if (!notFoundliItem.classList.contains("d-none")) {
    notFoundliItem.classList.add("d-none");
  }

  usersListItems.forEach(function (item) {
    if (!item.getAttribute("Id")) {
      let itemText = item.textContent.toLowerCase().trim();

      if (itemText.startsWith(searchText)) {
        item.style.display = "";
        hasMoreOneUserFound = true;
      } else {
        item.style.display = "none";
      }
    }
  });

  if (!hasMoreOneUserFound) {
    notFoundliItem.classList.remove("d-none");
  }
});
