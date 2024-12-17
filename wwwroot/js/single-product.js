// start dynamic product image
let mainImg = document.querySelector(".product-main-img");

let smallImg = document.querySelectorAll(".small-img");


smallImg.forEach(element => {
    element.addEventListener("click", function(e){
        mainImg.src = e.currentTarget.src
    })
});
// end dynamic product image

// start product swiper
var swiper = new Swiper(".slide-content", {
    slidesPerView: 3,
    spaceBetween: 25,
    loop: true,
    centerSlide: 'true',
    fade: 'true',
    grabCursor: 'true',
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
        dynamicBullets: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },

    breakpoints: {
        0: {
    slidesPerView: 1,
        },
        600:{
    slidesPerView: 2,
        },
        950:{
    slidesPerView: 3,
        },
        1140:{
    slidesPerView: 4,
        },
    },
});
// end product swiper