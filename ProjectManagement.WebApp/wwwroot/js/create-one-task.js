const searchInput = document.getElementById("user-search");
const userList = document.getElementById("user-list");
const notFoundliItem = document.getElementById("not-found-li-item");
console.log(notFoundliItem);
console.log(notFoundliItem.classList);
const usersListItems = document.querySelectorAll("#user-list li");

searchInput.addEventListener("input", function (ev) {
  let searchText = this.value.toLowerCase().trim();
  let hasMoreOneUserFound = false;
    if(!notFoundliItem.classList.contains("d-none")){
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
