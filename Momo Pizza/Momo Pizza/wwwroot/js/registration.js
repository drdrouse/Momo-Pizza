
!(function () {
    const form = document.getElementById("form");
    const username = document.getElementById("username");
    const email = document.getElementById("email");
    const telephone = document.getElementById("telephone");
    const password = document.getElementById("password");
    const password2 = document.getElementById("password2");
    const path = 'Loggin/error.txt';
    var now = new Date().toLocaleString();

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
    function checkUsername(input) {
        const re = /^[а-яА-Яa-zA-Z_]+$/;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Никнейм имеет неверный формат");
            $.ajax({
                type: "POST",
                url: "/Registration/Create_Log",
                data: {
                    "path": path,
                    "text": "Ошибка ввода: Введёный никнейм не соответствует формату: " + '"' + input.value + '"' + ". Дата: " + now,
                }
            });
            return (false);
        }
    }

    function checkEmail(input) {
        const re = /^(([^<>()#№&?%\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "E-mail имеет неверный формат");
            $.ajax({
                type: "POST",
                url: "/Registration/Create_Log",
                data: {
                    "path": path,
                    "text": "Ошибка ввода: Введёный email не соответствует формату: " + '"' + input.value + '"' + ". Дата: " + now,
                }
            });
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
            $.ajax({
                type: "POST",
                url: "/Registration/Create_Log",
                data: {
                    "path": path,
                    "text": "Ошибка ввода: Введёный телефон не соответствует формату: " + '"' + input.value + '"' + ". Дата: " + now,
                }
            });
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
            $.ajax({
                type: "POST",
                url: "/Registration/Create_Log",
                data: {
                    "path": path,
                    "text": "Ошибка ввода: Введёный пароль не соответствует формату: " + '"' + input.value + '"' + ". Дата: " + now,
                }
            });
            return (false);
        }
    }
    
       
    function checkPasswordsMatch(input1, input2) {
        if (input1.value !== input2.value) {
            showError(input2, "Пароли не совпадают");
            $.ajax({
                type: "POST",
                url: "/Registration/Create_Log",
                data: {
                    "path": path,
                    "text": "Ошибка ввода: Пароли не совпадают. Дата: " + now,
                }
            });
            return (false);
        } else {
            if (input1.value !== null){
                showSuccess(input2);                
            }
            return (true);
        }
    }

    
       
    // Устанавливаем слушатели событий на форму
    form.addEventListener("submit", function (e) {
        e.preventDefault();
        if (checkEmail(email)
            & checkPassword(password)
            & checkTelephone(telephone)
            & checkPasswordsMatch(password, password2)
            & checkUsername(username)) {
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
                        window.location.href = '/Autorization/Index/';
                    } else {
                        alert("Пользователь с таким e-mail уже есть");
                    }
                }
            });
            
        }         
    });

})();