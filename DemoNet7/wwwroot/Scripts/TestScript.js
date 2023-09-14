$(document).ready(function () {
    $("#change_header").click(function () {
        $("h1").html("This header has changed.");
    });

    $("button").click(function () {
        $("h1").hide("slow");
        $("p").fadeIn(1000);
    });
    $("p").click(function () {
        $(this).fadeOut(1400);
    });
});