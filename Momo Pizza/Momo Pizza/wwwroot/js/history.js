$(document).ready(function () {
    $(".confirm").click(function () {
        var Id_history = $(this).attr('id');
        $.ajax({
            type: "POST",
            url: "/History/Confirm",
            data: {
                "id_history": Id_history
            },
            success: function (r) {
                if (r) {
                    window.location.href = '/Basket/Index/';
                } else {

                }
            }
        });
    });
});