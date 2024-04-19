
const canvas = document.getElementById('pizza-canvas');
const ctx = canvas.getContext('2d');
const Price = document.getElementById('full-price');
const Sauce = document.getElementById('sauce');

// Изображения пиццы
const doughImages = {
    4: '/js/Начинки/Тонкое.png',
    6: '/js/Начинки/Толстое.png'
};
const doughCost = {
    4: 250,
    6: 300
}
const sauceImages = {
    8: '/js/Начинки/Томатный.png',
    3: '/js/Начинки/Сырный.png',
    4: '/js/Начинки/Песто.png'
};
const sauceCost = {
    0: 0,
    8: 50,
    3: 45,
    4: 60
}
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
const ingredientCost = {
    1: 40,
    2: 50,
    3: 45,
    5: 55,
    6: 89,    
    7: 75,
    9: 96,
    10: 50,    
    12: 45,
    13: 120,
    15: 109,
    16: 70,
    19: 55
};

const ingridientNumber = {
    1: 0,
    2: 1,
    3: 2,
    5: 3,
    6: 4,
    7: 5,
    9: 6,
    10: 7,
    12: 8,
    13: 9,
    15: 10,
    16: 11,
    19: 12
}
// Текущие настройки
let dough = 4;
let sauce;
let ingredients = [];
let priceDough = 0;
let priceIngridient = 0;
let priceSauce = 0;

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
    Sauce.value = 0;
    sauce = 0;
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
    child = $(this).parent().children(".qt");
    if (parseInt(child.html()) < 9) {
        child.html(parseInt(child.html()) + 1);
        updatePriceIngridient();
    }
});
$(".qt-minus").click(function () {

    child = $(this).parent().children(".qt");

    if (parseInt(child.html()) > 1) {
        child.html(parseInt(child.html()) - 1);
        updatePriceIngridient();
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
    alert("Ok")
    //$.ajax({
    //    type: "POST",
    //    url: "/Basket/Confirm",
    //    success: function (r) {
    //        if (r) {
    //            window.location.href = '/Confirm/Index/';
    //        } else {

    //        }
    //    }
    //});
});
