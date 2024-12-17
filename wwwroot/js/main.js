// start scroll button
let scrollBtn = document.getElementsByClassName("scroll")[0];
window.addEventListener("scroll", function () {
    if(window.scrollY >= 600){
        scrollBtn.style.display = "block";
    }else{
        scrollBtn.style.display = "none";
    }
})
scrollBtn.addEventListener("click", function () {
    window.scrollTo({
        left: 0,
        top: 0,
        behavior: "smooth"
    })
}) 
// end scroll button


