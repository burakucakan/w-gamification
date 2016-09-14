$(function () {
    $("select").kendoDropDownList({});
    
    $(".check").live("mouseover", function () {
        var t = $(this).children(".tooltip");
        if (t != undefined) {
            $(this).children(".tooltip").show();
        }
    });
    $(".check").live("mouseout", function () {
        var t = $(this).children(".tooltip");
        if (t != undefined) {
            $(this).children(".tooltip").hide();
        }
    });
});