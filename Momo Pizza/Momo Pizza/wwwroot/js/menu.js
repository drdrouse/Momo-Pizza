$(document).ready(function () {

    $(".card__add").click(function () {
        var Id = $(this).attr('id');
        if (Id == 0) {
            window.location.href = '/Autorization/Index/';
        } else {
            $.ajax({
                type: "POST",
                url: "/Menu/Add_Order",
                data: {
                    "pizzaID": Id,
                    "orderID": 1
                },
                success: function (r) {
                    if (r) {
                        alert("Пицца успешно добавлена")
                    } else {
                        alert("Пицца уже в корзине");
                    }
                }
            });
        };
        
    });
});