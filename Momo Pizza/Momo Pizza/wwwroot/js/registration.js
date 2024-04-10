
!(function () {
    const form = document.getElementById("form");
    const username = document.getElementById("username");
    const email = document.getElementById("email");
    const telephone = document.getElementById("telephone");
    const password = document.getElementById("password");
    const password2 = document.getElementById("password2");


    function showError(input, message) {
        const formControl = input.parentElement;
        formControl.className = "form-control error";
        const small = formControl.querySelector("small");
        small.innerText = message;
    }

    function showSuccess(input) {
        const formControl = input.parentElement;
        formControl.className = "form-control success";
    }

    function checkEmail(input) {
        const re = /^(([^<>()#№&?%\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "E-mail имеет неверный формат");
            return (false);
        }
    }

    function checkTelephone(input) {
        const re = /\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}/;           
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Телефон имеет неверный формат");
            return (false);
        }
    }
    
    function checkPassword(input) {
        const re = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!_-])(?=.{8,})^.+$/;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Пароль имеет неверный формат");
            return (false);
        }
    }
    
       
    function checkPasswordsMatch(input1, input2) {
        if (input1.value !== input2.value) {
            showError(input2, "Пароли не совпадают");
            return (false);
        } else {
            if (input1.value !== null){
                showSuccess(input2);
            }
            return (true);
        }
    }

    
    function getFieldName(input) {
        return input.id.charAt(0).toUpperCase() + input.id.slice(1);
    }

    
    // Устанавливаем слушатели событий на форму
    form.addEventListener("submit", function (e) {
        e.preventDefault();
        if (checkEmail(email)
            & checkPassword(password)
            & checkTelephone(telephone)
            & checkPasswordsMatch(password, password2)) {
            $.ajax({
                type: "POST",
                url: "/Registration/Add_User",
                data: {
                    "phone": telephone.value,
                    "email": email.value,
                    "password": password.value,
                    "username": username.value,
                },
                success: function (r) {
                    if (r) {
                        window.history.go(-1);
                    } else {
                        alert("Пользователь с таким e-mail уже есть");
                    }
                }
            });
            
        }         
    });

})();