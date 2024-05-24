let subTaskCheckBox = document.getElementById("sub-task-checkbox");
subTaskCheckBox.addEventListener("change", function (ev) {
  if (ev.currentTarget.checked) console.log("Checked");
  else console.log("Not checked");
});

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
  // add comment
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

        let hasNotCommentInfoText = document.getElementById("has-not-comment-info");
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
