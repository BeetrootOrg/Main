
document.querySelector("h4").onmousemove = h4_action;
function h4_action() 
{
    this.style.color = this.style.color === "black" ? "green" : "black";
}