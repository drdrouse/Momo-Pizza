
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
        const re = /^\+?[0-9]{10,15}$/;           
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Телефон имеет неверный формат");
            return (false);
        }
    }
    function checkName(input) {
        const re = /^(?!-#)(?!.*-$)[a-zA-Z-]+$/;;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Никнейм имеет неверный формат");
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
    // Проверка обязательных полей
    /**
     *
     * @param {HTMLElement[]} inputElements
     * @returns {boolean}
     */
    
    function checkLength(input, min) {
        if (input.value.length < min) {
            showError(
                input,
                `Поле ${getFieldName(input)} должно быть длиной не менее ${min} символов`
            );
            return (false);
        } else {
            return (true);
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
        if (checkLength(password, 8)
            & checkEmail(email)
            & checkPassword(password)
            & checkTelephone(telephone)
            & checkPasswordsMatch(password, password2)
            & checkName(username)) {
            alert("OK")
        } else {
            alert("Not OK")
        }

    });

})();