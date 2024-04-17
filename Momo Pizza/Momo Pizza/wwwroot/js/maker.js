
const canvas = document.getElementById('pizza-canvas');
const ctx = canvas.getContext('2d');

// Изображения пиццы
const doughImages = {
    4: '/js/Начинки/Тонкое.png',
    6: '/js/Начинки/Толстое.png'
};

const sauceImages = {
    8: '/js/Начинки/Томатный.png',
    3: '/js/Начинки/Сырный.png',
    4: '/js/Начинки/Песто.png'
};

const ingredientImages = {
    1: '/js/Начинки/Пепперони.png',
    2: '/js/Начинки/Пармезан.png',
    3: '/js/Начинки/Чеддер.png',
    5: '/js/Начинки/Мортаделла.png',
    6: '/js/Начинки/Брынза.png',
    16: '/js/Начинки/Моцарелла.png',
    7: '/js/Начинки/Цыплёнок.png',
    9: '/js/Начинки/Ананас.png',
    10: '/js/Начинки/Бекон.png',
    19: '/js/Начинки/Шампиньоны.png',
    12: '/js/Начинки/Красный лук.png',
    13: '/js/Начинки/Боварские сосиски.png',
    15: '/js/Начинки/Чоризо.png'
};
// Текущие настройки
let dough;
let sauce;
let ingredients = [];

// Функция отрисовки пиццы
function drawPizza() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Тесто
    const doughImage = new Image(50, 50);
    doughImage.src = doughImages[dough];
    console.log(doughImages[dough])
    doughImage.onload = () => {
        ctx.drawImage(doughImage, 0, 0, canvas.width, canvas.height)
    }
    // Соус
    const sauceImage = new Image();
    sauceImage.src = sauceImages[sauce];
    sauceImage.onload = () => {
        ctx.drawImage(sauceImage, 0, 0, canvas.width, canvas.height);
    };
    // Ингредиенты
    ingredients.forEach(ingredient => {
        const ingredientImage = new Image();
        ingredientImage.src = ingredientImages[ingredient];
        ingredientImage.onload = () => {
            // Позиционирование ингредиента
            ctx.drawImage(ingredientImage, 0, 0, canvas.width, canvas.height);
        };
    });
}

// Обработчики событий
document.getElementById('dough').addEventListener('change', () => {
    dough = document.getElementById('dough').value;
    drawPizza();
});

document.getElementById('sauce').addEventListener('change', () => {
    sauce = document.getElementById('sauce').value;
    drawPizza();
});

const ingredientCheckboxes = document.querySelectorAll('.ingredient input[type="checkbox"]');
console.log(ingredientCheckboxes);

const nodesArray = Array.from(ingredientCheckboxes);

for (let node of ingredientCheckboxes) {
    node.addEventListener('change', event => {
        console.log(node.checked);
        console.log(node.id);
        const ingredient = node.id;
        if (node.checked) {
            ingredients.push(ingredient);
        } else {
            ingredients = ingredients.filter(i => i !== ingredient);
        }
        drawPizza();
        updatePrice();
    })
}
$(".qt-plus").click(function () {
    child = $(this).parent().children(".qt");
    if (parseInt(child.html()) < 9) {
        child.html(parseInt(child.html()) + 1);
    }
});
$(".qt-minus").click(function () {

    child = $(this).parent().children(".qt");

    if (parseInt(child.html()) > 1) {
        child.html(parseInt(child.html()) - 1);
    }
});

// Отрисовка пиццы при загрузке страницы
drawPizza();
updatePrice();
