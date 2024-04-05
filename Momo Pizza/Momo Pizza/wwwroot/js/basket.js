var check = false;
function changeVal(el) {
    var qt = parseFloat(el.parent().children(".qt").html());
    var price = parseFloat(el.parent().children(".price").html());
    var eq = Math.round(price * qt * 100) / 100;

    el.parent().children(".full-price").html(eq + "€");

    changeTotal();
}

$(document).ready(function () {

    $(".remove").click(function () {
        var el = $(this);
        el.parent().parent().addClass("removed");
        window.setTimeout(
            function () {
                el.parent().parent().slideUp('fast', function () {
                    el.parent().parent().remove();
                   
                    changeTotal();
                });
            }, 200);
        var Id = $(this).attr('id');
        $.ajax({
            type: "POST",
            url: "/Basket/Delete_Order",
            data: { "orderID": Id }
        });   
    });

    $(".qt-plus").click(function () {
        $(this).parent().children(".qt").html(parseInt($(this).parent().children(".qt").html()) + 1);

        $(this).parent().children(".full-price").addClass("added");

        var el = $(this);
        window.setTimeout(function () { el.parent().children(".full-price").removeClass("added"); changeVal(el); }, 150);
        var Id = $(this).attr('id');
        $.ajax({
            type: "POST",
            url: "/Basket/UpdateCountPizza_Plus",
            data: { "orderID": Id }
        });
    });

    $(".qt-minus").click(function () {

        child = $(this).parent().children(".qt");

        if (parseInt(child.html()) > 1) {
            child.html(parseInt(child.html()) - 1);
        }

        $(this).parent().children(".full-price").addClass("minused");

        var el = $(this);
        window.setTimeout(function () { el.parent().children(".full-price").removeClass("minused"); changeVal(el); }, 150);
        var Id = $(this).attr('id');
        $.ajax({
            type: "POST",
            url: "/Basket/UpdateCountPizza_Minus",
            data: { "orderID": Id }
        });
    });

    window.setTimeout(function () { $(".is-open").removeClass("is-open") }, 1200);

    $(".btn").click(function () {
        check = true;
        $(".remove").click();
    });
});

