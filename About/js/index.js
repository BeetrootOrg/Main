
document.querySelector("h1").onmousemove = h1_action;
function h1_action() 
{
    this.style.color = this.style.color === "green" ? "black" : "green";
}
