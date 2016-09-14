$(function () {
    //$("select").kendoDropDownList();
    loginButton();
    //tcellLoginButton();
    $(".ajax").colorbox();
});

function loginButton() {
    $(".loginBtn a").on("mouseover", function () {
        $(this).children("span").stop().animate({
            width: '270px'
        });
    });
    $(".loginBtn a").on("mouseout", function () {
        $(this).children("span").stop().animate({
            width: '141px'
        });
    });
}

//function tcellLoginButton() {
//    $(".tcellLogin a").on("mouseover", function () {
//        setTimeout(function () {
//            $(".tcellLogin a span").animate({
//                width: '270px'
//            });
//        }, 100);
//    });
//    $(".tcellLogin a").on("mouseout", function () {
//        setTimeout(function () {
//            $(".tcellLogin a span").animate({
//                width: '141px'
//            });
//        }, 100);
//    });
//}