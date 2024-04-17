
const canvas = document.getElementById('pizza-canvas');
const ctx = canvas.getContext('2d');

// Изображения пиццы
const doughImages = {
    Тонкое: '/js/Начинки/Тонкое.png',
    Толстое: '/js/Начинки/Толстое.png'
};

const sauceImages = {
    Томатный: '/js/Начинки/Томатный.png',
    Сырный: '/js/Начинки/Сырный.png',
    Песто: '/js/Начинки/Песто.png'
};

const ingredientImages = {
    Пепперони: '/js/Начинки/Пепперони.png',
    Пармезан: '/js/Начинки/Пармезан.png',
    Чеддер: '/js/Начинки/Чеддер.png',
    Мортаделла: '/js/Начинки/Мортаделла.png',
    Брынза: '/js/Начинки/Брынза.png',
    Моцарелла: '/js/Начинки/Моцарелла.png',
    Цыплёнок: '/js/Начинки/Цыплёнок.png',
    Ананас: '/js/Начинки/Ананас.png',
    Бекон: '/js/Начинки/Бекон.png',
    Шампиньоны: '/js/Начинки/Шампиньоны.png'
};
// Текущие настройки
let dough = 'Тонкое';
let sauce = 'Томатный';
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

const ingredientCheckboxes = document.querySelectorAll('.ingredient-info input[type="checkbox"]');
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
