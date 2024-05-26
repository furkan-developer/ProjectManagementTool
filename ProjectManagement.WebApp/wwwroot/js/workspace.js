let mainContent = document.querySelector("main")
const workspaceColors = ["d183b9","0880bd","2aab9c","ffcc66"];
const workspaces = document.getElementsByClassName("workspace");

mainContent.classList.add("workspace-grid--main-content");


let colorOrder = 0;

for (let index = 0; index < workspaces.length; index++) {
    if(colorOrder >= workspaceColors.length)
        colorOrder = 0;

    workspaces[index].style.border = `4px solid #${workspaceColors[colorOrder]}`;
    workspaces[index].style.color = `#${workspaceColors[colorOrder]}`;
    
    let button = workspaces[index].querySelector("a");
    button.style.border = `2px solid #${workspaceColors[colorOrder]}`;

    ++colorOrder;
}