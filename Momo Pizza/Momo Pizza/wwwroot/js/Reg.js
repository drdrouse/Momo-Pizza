function validation(form) {
    function removeError(input) {
        const parent = input.parentNode;
        if (parent.classList.contains('error')) {
            parent.querySelector('.error-label').remove()
            parent.classList.remove('error')
        }
    }
    function createError(input, text) {
        const parent = input.parentNode;
        const errorLabel = document.createElement('label')
        errorLabel.classList.add('error-label')
        errorLabel.textContent = text
        parent.classList.add('error');
        parent.append(errorLabel)
    }
    let result = true;
    const allInputs = form.querySelectorAll('input');
    for (const input of allInputs) {
        removeError(input)

        if (input.dataset.required == "Namee") {
            if (/^[А-ЯЁа-яё]+(-[А-ЯЁа-яё]+)?$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'Нужен следующий вид: Влад, У-иглы. Буквы русского алфавита, возможно использовать знак - в имени!')
                result = false
            }
        }
        if (input.dataset.required == "Tele") {
            if (/^\+?[0-9]{10,15}$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'Нужен следующий вид: +79123456789, знак + не обязателен. Последовательность цифр без лишних символов!')
                result = false
            }
        }
        if (input.dataset.required == "Pass") {
            if (/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})^.+$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'Особенности пароля: мин. 1 строчная (a-z) и прописная(A-Z), мин. 1 спец. символ [!@#$ %^&*], мин. 1 цифра, к-во символов 8 и более!')

                result = false
            }
        }
        if (input.dataset.required == "RPass") {
            if (document.getElementById('p1').value != document.getElementById('p2').value) {
                removeError(input)
                createError(input, 'Несовпадение паролей')
                result = false
            }
            else {
                removeError(input)
            }
        }

        if (input.dataset.required == "Email") {
            if (/^(([^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'Неверно введён email')
                result = false
            }
        }

    }

    return result
}

document.getElementById("RegForm").addEventListener("submit", function (event) {
    event.preventDefault()
    if (validation(this) == true) {
        alert('Вы зарегестрировались')
    }
})