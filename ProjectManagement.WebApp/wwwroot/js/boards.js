const workspaceColors = ["d183b9","0880bd","2aab9c","ffcc66","4a4a4a"];
const workspaces = document.getElementsByClassName("board");
let colorOrder = 0;


for (let index = 0; index < workspaces.length; index++) {
    if(colorOrder >= workspaceColors.length)
        colorOrder = 0;

    workspaces[index].style.backgroundColor = `#${workspaceColors[colorOrder]}`;
    ++colorOrder;
}