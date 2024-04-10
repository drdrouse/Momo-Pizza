var email = false;
var name = false;
var telephone = false;
var confirmPassword = false;
!(function () {
    const form = document.getElementById("form");
    const username = document.getElementById("name");
    const email = document.getElementById("email");
    const password = document.getElementById("password");
    const password2 = document.getElementById("confirmPassword");
    const password2 = document.getElementById("confirmPassword");

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

//function validation(form) {
//    function removeError(input) {
//        const parent = input.parentNode;
//        if (parent.classList.contains('error')) {
//            parent.querySelector('.error-label').remove()
//            parent.classList.remove('error')
//        }
//    }
//    function createError(input, text) {
//        const parent = input.parentNode;
//        const errorLabel = document.createElement('label')
//        errorLabel.classList.add('error-label')
//        errorLabel.textContent = text
//        parent.classList.add('error');
//        parent.append(errorLabel)
//    }
//    let result = true;
//    const allInputs = form.querySelectorAll('input');
//    for (const input of allInputs) {
//        removeError(input)

//        if (input.dataset.required == "Tele") {
//            if (/^\+?[0-9]{10,15}$/.test(input.value) == false) {
//                removeError(input)
//                createError(input, 'Неверно введён телефон')
//                result = false
//            }
//        }
//        if (input.dataset.required == "Pass") {
//            if (/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})^.+$/.test(input.value) == false) {
//                removeError(input)
//                createError(input, 'Пароль должен содержать: буквы (a-z, A-Z), цифры [0-9], к-во символов более 8')

//                result = false
//            }
//        }
//        if (input.dataset.required == "RPass") {
//            if (document.getElementById('p1').value != document.getElementById('p2').value) {
//                removeError(input)
//                createError(input, 'Несовпадение паролей')
//                result = false
//            }
//            else {
//                removeError(input)
//            }
//        }

//        if (input.dataset.required == "Email") {
//            if (/^(([^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(input.value) == false) {
//                removeError(input)
//                createError(input, 'Неверно введён email')
//                result = false
//            }
//        }

//    }

//    return result
//}

//document.getElementById("RegForm").addEventListener("submit", function (event) {
//    event.preventDefault()
//    if (validation(this) == true) {
//        alert('Вы зарегестрировались')
//        window.history.go(-1)
//    }
//})