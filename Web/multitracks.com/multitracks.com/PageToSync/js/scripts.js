$(document).ready(function () {
    $("li.tab-filter--item a").click(function (event) {

        $("li.tab-filter--item").removeClass("is-active");

        $(this).parent().addClass("is-active");
    });
});
