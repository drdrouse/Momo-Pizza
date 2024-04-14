$(document).ready(function () {

    $(".card__add").click(function () {
        var Id_pizza = $(this).attr('id');
        
        if (Id_pizza == 0) {
            window.location.href = '/Autorization/Index/';
        } else {
            const button_ = document.getElementById(Id_pizza);
            $.ajax({
                type: "POST",
                url: "/Menu/Add_Order",
                data: {
                    "pizzaID": Id_pizza,
                    "Aut_Id": button_.value
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