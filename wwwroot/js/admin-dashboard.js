//  start make li active
let links = document.querySelectorAll(".dashboard.sidebar ul li");

links.forEach(function(item){

    item.addEventListener("click", function(){
        
        links.forEach(i => {
            i.classList.remove("active");
        })
        this.classList.add("active");
    })
    

})
// end make li active
// toggle
let toggleIcon = document.getElementById("toggle-icon");
let sideMenu = document.querySelector(".dashboard.sidebar");
toggleIcon.addEventListener("click", function(){
    sideMenu.classList.toggle("resize");
})


let searchBtn = document.getElementById("dash-search-btn");
let search = document.getElementById("dash-search-form");

if(window.innerWidth < 715){
    searchBtn.addEventListener("click", function (){
        search.classList.toggle("show");
        if(search.classList.contains("show")){
            searchBtn.innerHTML = "<i class= 'fa-solid fa-x'></i>";
        }else{
            searchBtn.innerHTML = "<i class= 'fa-solid fa-search'></i>";
        }
    })
}

window.addEventListener("resize", function (){
    if(this.innerWidth < 768) {
        sideMenu.classList.add("resize");
        searchBtn.innerHTML = "<i class= 'fa-solid fa-search'></i>";
        search.classList.remove("show");
    }
})
/// file
document.querySelector("#product-image").onchange = function() {
    let fileName = this.files[0].name;

    let label = document.getElementById("file-name");
    
    label.innerText = fileName ?? "Browse Files";
    label.style.display = "inline";
};