//dynamic add product to product-list div
///////products-list
let products = [
    {
        id : 0,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 1,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 2,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 3,
        image : "img/shirt.png",
        category : "Sportswear",
        title : "Product",
        price : 200
    },
    {
        id : 4,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 5,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 0,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 1,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 2,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 3,
        image : "img/shirt.png",
        category : "Sportswear",
        title : "Product",
        price : 200
    },
    {
        id : 4,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 5,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 0,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 1,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 2,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 3,
        image : "img/shirt.png",
        category : "Sportswear",
        title : "Product",
        price : 200
    },
    {
        id : 4,
        image : "img/accessor-2.png",
        category : "Accessor",
        title : "Product",
        price : 150
    },
    {
        id : 5,
        image : "img/shoes.png",
        category : "Shoes",
        title : "Product",
        price : 100
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
    {
        id : 6,
        image : "img/bag-3.png",
        category : "Bags",
        title : "Product",
        price : 120
    },
]

const items = [...new Set(products.map((item)=> {
    return item;
}))]

document.querySelector(".shop .product-list").innerHTML = items.map((item)=> {
    let {id , image, title, price} = item;

    return (
        `<div class="item position-relative">
        <div class="image">
            <img src=${image} alt="" class="img-fluid">
            <button href="" class="wishlist-btn text-light position-absolute p-2"><i class="pe-lg-4 pe-2 fa-solid fa-heart d-block fs-5"></i></button>
        </div>
        <div class="item-body">
            <div class="title text-center">
                <h5>${title}</h5>
            </div>
            <div class="price text-center">
                <span>$</span>
                <span class="price">${price}</span>
            </div>
            <div class="button d-flex align-items-center justify-content-center mt-3">
                <div class="overlay"></div>
                <button>Add To Cart</button> 
                </div>
            </div>
        </div>`
    )
}).join('')


//start shop page side-filter dynamic value
let slider = document.getElementById("to-slider");
let sliderOutput = document.getElementById("filter-value");
sliderOutput.innerHTML = `Price: <span class="dollar">$</span>0 - <span class="dollar">$</span>${slider.value}`;

slider.addEventListener("input", function (){
    sliderOutput.innerHTML = `Price: <span class="dollar">$</span>0 - <span class="dollar">$</span>${this.value}`
})
//end shop page side-filter dynamic value