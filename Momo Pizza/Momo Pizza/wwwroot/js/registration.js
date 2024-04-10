
!(function () {
    const form = document.getElementById("form");
    const username = document.getElementById("username");
    const email = document.getElementById("email");
    const telephone = document.getElementById("telephone");
    const password = document.getElementById("password");
    const password2 = document.getElementById("password2");

    // Показываем ошибку под полем
    function showError(input, message) {
        const formControl = input.parentElement;
        formControl.className = "form-control error";
        const small = formControl.querySelector("small");
        small.innerText = message;
    }

    // Показываем, что поле заполнено верно
    function showSuccess(input) {
        const formControl = input.parentElement;
        formControl.className = "form-control success";
    }

    // Проверяем адрес электронной почты на правильность
    function checkEmail(input) {
        const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "E-mail имеет неверный формат");
            return (false);
        }
    }

    function checkTelephone(input) {
        const re =            
        if (re.test(input.value.trim())) {
            showSuccess(input);
            return (true);
        } else {
            showError(input, "Телефон имеет неверный формат");
            return (false);
        }
    }
    // Проверка обязательных полей
    /**
     *
     * @param {HTMLElement[]} inputElements
     * @returns {boolean}
     */
    function checkRequired(inputElements) {
        let isRequired = false;
        inputElements.forEach(function (input) {
            if (input.value.trim() === "") {
                showError(input, `Требуется задать значение для поля ${getFieldName(input)}`);
                isRequired = false;
            } else {
                isRequired = true;
            }
        });

        return isRequired;
    }

    // Проверяем значение поля на соответствие минимальной и максимальной длине
    function checkLength(input, min) {
        if (input.value.length < min) {
            showError(
                input,
                `Поле ${getFieldName(input)} должно быть длиной не менее ${min} символов`
            );
        } else {
            showSuccess(input);
        }
    }

    // Проверка соответствия паролей
    function checkPasswordsMatch(input1, input2) {
        if (input1.value !== input2.value) {
            showError(input2, "Пароли не совпадают");
        }
    }

    // Получаем имя поля
    function getFieldName(input) {
        return input.id.charAt(0).toUpperCase() + input.id.slice(1);
    }

    // Устанавливаем слушатели событий на форму
    form.addEventListener("submit", function (e) {
        e.preventDefault();

        if (checkRequired([email]) && checkEmail(email)) {
            alert("OK")
            //checkLength(password, 8);
            //checkEmail(email);
            //checkPasswordsMatch(password, password2);
        } else {
            alert("Not Ok")
        }
    });

})();