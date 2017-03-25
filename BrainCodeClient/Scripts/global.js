$(document).ready(function () {

    $.ajaxSetup({
        beforeSend: function () {
            $("#cover").fadeIn(100);
        },
        complete: function () {
            $("#cover").fadeOut(500);
        }
    });

     $('#cover').fadeOut(100);
});