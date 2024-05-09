!(function () {
    const form = document.getElementById("form");
    const email = document.getElementById("email");
    const password = document.getElementById("password");


    function showError(input, message) {
        const formControl_password = input.parentElement;
        formControl_password.className = "form-control error";
        const formControl_email = email.parentElement;
        formControl_email.className = "form-control error";
        const small = formControl_password.querySelector("small");
        small.innerText = message;
    }
    function showSuccess() {
        const formControl_password = password.parentElement;
        formControl_password.className = "form-control success";
        const formControl_email = email.parentElement;
        formControl_email.className = "form-control success";
    }
    
    // Устанавливаем слушатели событий на форму
    form.addEventListener("submit", function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "/Autorization/Login",
            data: {
                "email": email.value,
                "password": password.value,
            },
            success: function (r) {
                if (r != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Autorization/Add_Authoruze",
                        data: {
                            "email": email.value,
                            "password": password.value,
                            "id": r,
                        },
                        success: function (r) {
                            showSuccess();
                            window.location.href = '/Home/Index/';
                        }
                    })
                    
                } else {
                    showError(password, "Неверно введён логин или пароль");
                }
            }
        })
    });          
})();