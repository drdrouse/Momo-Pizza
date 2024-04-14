$('#exite').on('click', function () {

    $.ajax({
        type: "POST",
        url: "/Home/Exite",
        success: function (r) {
            if (r) {
                window.location.href = '/Home/Index/';
            } else {
               
            }
        }
    });
});

