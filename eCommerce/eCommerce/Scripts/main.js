$(document).ready(function () {
    $(".thumbnail img").on("mouseover", function () {
        $(".main-image img").attr("src", $(this).attr("src"));
    });
});