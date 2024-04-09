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

        if (input.dataset.required == "Pass") {
            if (/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})^.+$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'Пароль неверный!')

                result = false
            }
        }

        if (input.dataset.required == "Email") {
            if (/^(([^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(input.value) == false) {
                removeError(input)
                createError(input, 'E-mail неверный!')
                result = false
            }
        }

    }

    return result
}

document.getElementById("AutoForm").addEventListener("submit", function (event) {
    event.preventDefault()
    if (validation(this) == true) {
        alert('Форма проверена успешна!')
    }
})