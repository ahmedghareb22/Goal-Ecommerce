let registerForm = document.querySelector(".register");
let registerImg = document.querySelector(".register-image");
let loginBox = document.querySelector(".login-box");

window.onload = () => {
    let page = localStorage.getItem("page") || "login";
    if (page === "register") {
        loginBox.classList.remove("active");
        registerForm.classList.remove("active");
        registerImg.classList.remove("active");
    }
};
function toggleLogin() {
    registerForm.classList.toggle("active");
    registerImg.classList.toggle("active");
    loginBox.classList.toggle("active");
    if (registerForm.classList.contains("active") && registerImg.classList.contains("active")) {
        localStorage.setItem("page", "login");
    } else {
        localStorage.setItem("page", "register");
    }
}