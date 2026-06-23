const reveals = document.querySelectorAll(".reveal");

window.addEventListener("scroll", () => {

reveals.forEach(section => {

const top = section.getBoundingClientRect().top;

if(top < window.innerHeight - 100){
section.classList.add("active");
}

});

});

const cursor = document.querySelector(".cursor");

document.addEventListener("mousemove",(e)=>{

cursor.style.left = e.clientX + "px";
cursor.style.top = e.clientY + "px";

});

function showMessage(){
alert("Thank you for visiting my portfolio!");
}