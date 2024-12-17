//start header
let list = document.querySelectorAll("nav ul li");


list.forEach(function (li) {
    li.addEventListener("click", function (e) {
        //remove active from all
        list.forEach(function (li) {
            li.classList.remove("active")
        })
        //add active to clicked li
        e.currentTarget.classList.add("active");
    })
})


// user nav icon  
let header = document.querySelectorAll(".navbar .container div");
console.log(header)

header.forEach(function (item) {
    if (item.classList.contains("user-nav-icon")) {
        let userNavImg = document.getElementById("user-nav-icon");
        let userNavImgPopUp = document.getElementById("sub-menu-wrap");

        userNavImg.addEventListener("click", function () {
            userNavImgPopUp.classList.toggle("active");
        })
    }
})
//end header

// start cart
let body = document.querySelector("body");
let cartCloseBtn = document.querySelector(".cart .cart-header button");
let cartIcon = document.getElementById("close-cart");
let cartIconSpan = document.getElementById("close-cart").children[1];
// open and close cart
cartCloseBtn.addEventListener("click", function () {
    body.classList.toggle("active-cart");
});
cartIcon.addEventListener("click", function () {
    body.classList.toggle("active-cart");
});



// end cart

