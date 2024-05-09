
const canvas = document.getElementById('pizza-canvas');
const ctx = canvas.getContext('2d');
const Price = document.getElementById('full-price');
const Sauce = document.getElementById('sauce');

// Изображения пиццы
const doughImages = {
    "Итальянское тесто": '/js/Начинки/Тонкое.png',
    "Нью-йорское тесто": '/js/Начинки/Толстое.png'
};
const doughCost = {
    "Итальянское тесто": 250,
    "Нью-йорское тесто": 300
}
const sauceImages = {
    "Томатный соус": '/js/Начинки/Томатный.png',
    "Сырный соус": '/js/Начинки/Сырный.png',
    "Соус Песто": '/js/Начинки/Песто.png'
};
const sauceCost = {
    "Без соуса": 0,
    "Томатный соус": 50,
    "Сырный соус": 45,
    "Соус Песто": 60
}
const ingredientImages = {
    "Пепперони": '/js/Начинки/Пепперони.png',
    "Пармезан": '/js/Начинки/Пармезан.png',
    "Чеддер": '/js/Начинки/Чеддер.png',
    "Мортаделла": '/js/Начинки/Мортаделла.png',
    "Брынза": '/js/Начинки/Брынза.png',
    "Моцарелла": '/js/Начинки/Моцарелла.png',
    "Цыплёнок": '/js/Начинки/Цыплёнок.png',
    "Ананас": '/js/Начинки/Ананас.png',
    "Бекон": '/js/Начинки/Бекон.png',
    "Шампиньоны": '/js/Начинки/Шампиньоны.png',
    "Красный лук": '/js/Начинки/Красный лук.png',
    "Баварские сосиски": '/js/Начинки/Боварские сосиски.png',
    "Острая колбаса чоризо": '/js/Начинки/Чоризо.png'
};
const ingredientCost = {
    "Пепперони": 40,
    "Пармезан": 50,
    "Чеддер": 45,
    "Мортаделла": 55,
    "Брынза": 89,    
    "Цыплёнок": 75,
    "Ананас": 96,
    "Бекон": 50,    
    "Красный лук": 45,
    "Баварские сосиски": 120,
    "Острая колбаса чоризо": 109,
    "Моцарелла": 70,
    "Шампиньоны": 55
};

const ingridientNumber = {
    "Пепперони": 0,
    "Пармезан": 1,
    "Чеддер": 2,
    "Мортаделла": 3,
    "Брынза": 4,
    "Цыплёнок": 5,
    "Ананас": 6,
    "Бекон": 7,
    "Красный лук": 8,
    "Баварские сосиски": 9,
    "Острая колбаса чоризо": 10,
    "Моцарелла": 11,
    "Шампиньоны": 12
}
// Текущие настройки
let dough = "Итальянское тесто";
let sauce = "Без соуса";
let ingredients = [];
let priceDough = 0;
let priceIngridient = 0;
let priceSauce = 0;
let fullPrice = 0;

// Функция отрисовки пиццы
function drawPizza() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    // Тесто
    const doughImage = new Image(50, 50);
    doughImage.src = doughImages[dough];

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
//Функция обновления стоимости
function updatePriceDough() {
    var cost = doughCost[dough];
    priceDough = cost;
    Price.innerHTML = cost + "₽";
 }

function updatePriceSauce() {
    var cost = sauceCost[sauce];
    priceSauce = cost;
    Price.innerHTML = priceSauce + priceDough + "₽";
}
function updatePriceIngridient() {
    if (ingredients.length > 0) {
        priceIngridient = 0
        ingredients.forEach(ingredient => {
            var priceConcrete = parseInt($('span.qt').eq(ingridientNumber[ingredient]).text(), 10) * ingredientCost[ingredient];
            priceIngridient = priceIngridient + priceConcrete;
            Price.innerHTML = priceSauce + priceDough + priceIngridient + "₽";
        });
        priceIngridient = 0
    } else {
        Price.innerHTML = priceSauce + priceDough + "₽";
    }
}

const ingredientCheckboxes = document.querySelectorAll('.ingredient input[type="checkbox"]');
console.log(ingredientCheckboxes);

const nodesArray = Array.from(ingredientCheckboxes);
// Обработчики событий
document.getElementById('dough').addEventListener('change', () => {
    dough = document.getElementById('dough').value;
    var el = $(this);
    for (let node of ingredientCheckboxes) {
        console.log(node.checked);
        console.log(node.id);
        const ingredient = node.id;
        if (node.checked == true) {
            
            ingredients = ingredients.filter(i => i !== ingredient);
            node.checked = !node.checked;
            $('span.qt').eq(ingridientNumber[ingredient]).html("0");
        } else {

        }
    }
    Sauce.value = "Без соуса";
    sauce = "Без соуса";
    drawPizza();
    updatePriceDough();
});

document.getElementById('sauce').addEventListener('change', () => {
    sauce = document.getElementById('sauce').value;
    
    for (let node of ingredientCheckboxes) {
        console.log(node.checked);
        console.log(node.id);
        const ingredient = node.id;
        if (node.checked == true) {

            ingredients = ingredients.filter(i => i !== ingredient);
            node.checked = !node.checked;
            $('span.qt').eq(ingridientNumber[ingredient]).html("0");
        } else {

        }
    }
    drawPizza();
    updatePriceSauce();
});



for (let node of ingredientCheckboxes) {
    node.addEventListener('change', event => {
        console.log(node.checked);
        console.log(node.id);
        const ingredient = node.id;
        if (node.checked) {
            ingredients.push(ingredient);
            $('span.qt').eq(ingridientNumber[ingredient]).html("1");
        } else {
            ingredients = ingredients.filter(i => i !== ingredient);
            $('span.qt').eq(ingridientNumber[ingredient]).html("0");
        }
        drawPizza();
        updatePriceIngridient();
    })
}
$(".qt-plus").click(function () {
    for (let node of ingredientCheckboxes) {
        if (node.checked) {
            child = $(this).parent().children(".qt");
            if (parseInt(child.html()) < 9) {
                child.html(parseInt(child.html()) + 1);
                updatePriceIngridient();
            }
        }
    }
});
$(".qt-minus").click(function () {
    for (let noe of ingredientCheckboxes) {
        if (node.checked) {
            child = $(this).parent().children(".qt");

            if (parseInt(child.html()) > 1) {
                child.html(parseInt(child.html()) - 1);
                updatePriceIngridient();
            }
        }
    }
});

// Отрисовка пиццы при загрузке страницы
drawPizza();
updatePriceDough();

var check = false;
function changeVal(el) {
    var qt = parseFloat(el.parent().children(".qt").html());
    
    var eq = Math.round(price * qt * 100) / 100;

    el.parent().children(".full-price").html(eq + "₽");

    changeTotal();
}

$(".add-to-cart-btn").click(function () {
    fullPrice = parseInt(Price.innerHTML);
    $.ajax({
        type: "POST",
        url: "/Maker/AddPizza",
        data: {
            "Price": fullPrice,
            "NameDough": dough,
            "NameSauce": sauce,
            "NameIngredient": ingredients
        },
        success: function (r) {
            if (r) {
                window.location.href = '/Basket/Index/';
            } else {

            }
        }
    });
});
