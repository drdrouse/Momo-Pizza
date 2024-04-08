$(document).ready(function () {

    $(".card__add").click(function () {
        var Id = $(this).attr('id');

        $.ajax({
            type: "POST",
            url: "/Menu/Add_Order",
            data: {
                "pizzaID": Id,
                "orderID": 1
            },
            success: function (r) {
                if (r) {
                    
                } else {
                    alert("Пицца уже в корзине");
                }
            }
        });
    });
});