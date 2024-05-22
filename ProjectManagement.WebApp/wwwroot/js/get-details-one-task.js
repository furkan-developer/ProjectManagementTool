let subTaskCheckBox = document.getElementById("sub-task-checkbox");
subTaskCheckBox.addEventListener("change", function (ev) {
  if (ev.currentTarget.checked) console.log("Checked");
  else console.log("Not checked");
});

let addCommentButton = document.getElementById("add-comment-button");
let comments = document.getElementById("comments");
let commentInput = document.getElementById("comment-input");
addCommentButton.addEventListener("click", function (ev) {
  // add comment
  let comment = commentInput.value;
  console.log(comment);
  let toJob = commentInput.getAttribute("data-job-id");
  console.log(toJob);

  fetch(`${LOCALHOST}board/postcomment`, {
    method: "POST",
    body: JSON.stringify({
      content: comment,
      toJob: toJob,
    }),
    headers: {
      Accept: "application/json",
      "Content-type": "application/json; charset=UTF-8",
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
