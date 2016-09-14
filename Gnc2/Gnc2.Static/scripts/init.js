$(function () {

    MenuOverSet();
    SpecialFormStyles();
    BadgeCarouselAnimate();
    Tab();
    validateEmail();
});

function Tab() {
    $(".tabNav a").live("click", function () {
        var activeSection = $(this).attr("data-active");
        $(".tabDetails").hide();
        $(".tabNav a").removeClass("active");
        $(this).addClass("active");
        $(".tabDetails[id=" + activeSection + "]").show();
    });
}

function MenuOverSet() {
    $('.subMenu').mouseover(function myfunction() {
        $(this).parent().children("a").addClass("active");
    });

    $('.subMenu').mouseout(function myfunction() {
        $(this).parent().children("a").removeClass("active");
    });
}

function BadgeCarouselAnimate() {
    $("#badgeCarousel>li>a").mouseover(function () {
        $($(this).parent().find(".badge")).animate({
            width: '90px',
            height: '89px',
            'margin': '-10px 0px 10px 0px'
        }, 200).stop();

        $(this).parent().find(".tooltip").fadeIn('500');
    });
    $("#badgeCarousel>li>a").mouseout(function () {
        $($(this).parent().find(".badge")).stop().animate({
            width: '80px',
            height: '79px',
            'margin': '0px 0px 0px 0px'
        }, 250);

        $(this).parent().find(".tooltip").stop().fadeOut('500');
    });
}

function SpecialFormStyles() {

    $("input[type='radio']").live("click", function (e) {
        $(this).parents('.rdGroup').find("label").removeClass("check-active");
        $(this).parents('.rdGroup').find("input[type='radio']").removeAttr("checked");
        $(this).next().toggleClass("check-active");
        $(this).attr("checked", "checked");
    });

    $("input[type='radio']").next("label").toggleClass("check");
    $("input[type='radio']:checked").next("label").toggleClass("check-active");


    $("input[type='checkbox']").next("label").toggleClass("check");
    $("input[type='checkbox']:checked").next("label").toggleClass("check-active");
    $("input[type='checkbox']").click(function (e) {
      
        if ($(this).attr("checked") == "checked")
            $(this).attr('checked', 'checked');
        else
            $(this).removeAttr('checked');

        $(this.nextElementSibling).toggleClass("check-active");

    });

    radioChecked();
}

function radioChecked() {
    $("input[type=radio]:checked").next("label").attr("class", "rd-active");
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}