$(function () {
    $("select").kendoDropDownList();
    $(".colorbox").colorbox({ scrolling: false });

    socialLinkHover();
    shareHover();
    tooltipsy();
    packageLoad();
});

function socialLinkHover() {
    $(".navSocial a").live("mouseover", function () {
        $(this).stop().animate({
            'background-position-y': '-27px'
        }, 200);
    });

    $(".navSocial a").live("mouseout", function () {
        $(this).stop().animate({
            'background-position-y': '0px'
        }, 200);
    });
}

function shareHover() {
    $(".share > a.fb").live("mouseover", function () {
        $(".share > .top").addClass("fbHover");
    });
    $(".share > a.fb").live("mouseout", function () {
        $(".share > .top").removeClass("fbHover");
    });
    $(".share > a.tw").live("mouseover", function () {
        $(".share > .top").addClass("twHover");
    });
    $(".share > a.tw").live("mouseout", function () {
        $(".share > .top").removeClass("twHover");
    });
}

function tooltipsy() {
    $('.ttT').tipsy({ gravity: 's', fade: true, html: true });
    $('.ttB').tipsy({ gravity: 'n', fade: true, html: true });
    $('.ttL').tipsy({ gravity: 'e', fade: true, html: true });
    $('.ttR').tipsy({ gravity: 'w', fade: true, html: true });
}

function rateGenerate(Id, Full, FullText) {
    $("#" + Id).addClass("rateBar");
    var barClass = "";
    var percent = "%";
    Full = Full.replace(percent, "");
    barClass = "rateBarYellow";

    $("#" + Id).html("<div class=\"" + barClass + "\" style=\"width:0%;\"></div>");

    if (Full > 100) { Full = 100; }

    setTimeout(function () {

        var mainBarWidth = 0;
        if (Full < 30) {
            mainBarWidth = Full;
        }
        else {
            mainBarWidth = Full - 29;
            mainBarWidth = Full - mainBarWidth;
        }
        $("#" + Id + ">." + barClass + "").animate({
            width: mainBarWidth + percent
        }, 500, function () {


            if (Full > 29) {
                var barWidth = 0;
                if (Full < 90) {
                    barWidth = Full;
                }
                else {
                    barWidth = Full - 29;
                }

                $("#" + Id).append("<div class=\"rateBarYellow\" id=\"yellow_" + Id + "\" style=\"-moz-opacity:0;opacity:0;width:" + mainBarWidth + percent + "; position: absolute; \"></div>");

                $("#" + Id + ">." + barClass + "").animate({
                    width: barWidth + percent,
                    opacity: 0
                }, 500);

                $("#" + Id + ">#yellow_" + Id + "").animate({
                    width: barWidth + percent,
                    opacity: 1
                }, 400, function () {

                    if (Full > 89) {
                        var barPinkWidth = 0;
                        if (Full < 100) {
                            barPinkWidth = Full;
                        }
                        else {
                            barPinkWidth = Full;
                        }
                        $("#" + Id).append("<div class=\"rateBarPink\" id=\"pink_" + Id + "\" style=\"-moz-opacity:0; opacity:0; width:" + barWidth + percent + ";position: absolute;\"></div>");
                        $("#" + Id + ">#yellow_" + Id + "").animate({
                            width: barPinkWidth + percent,
                            opacity: 0
                        }, 500);

                        $("#" + Id + ">#pink_" + Id + "").animate(
                        {
                            width: barPinkWidth + percent,
                            opacity: 1
                        }, 300);
                    }

                });
            }

        });

        if (FullText != undefined) {
            FullText = FullText.replace("%", "");
            if (parseInt(FullText) < 0)
                FullText = 0;

            $("#" + Id).append("<div class=\"fIta\" style=\"position: absolute; z-index: 5; line-height: 21px; text-indent: 7px; display:none;\" id=\"barText_" + Id + "\">" + FullText + "%</div>");
            $("#barText_" + Id).fadeIn('slow');
        }
    }, 700);
}

function packageLoad() {
    $(".packageLoad").live("click", function () {
        var className = $(this).attr("class");
        if (className.indexOf("open") != -1) {
            $(this).removeClass("open");
            $("#packageLoad").animate({
                marginTop: "-206px"
            }, 500, function () {
                $("#packageOverlay").hide();
            });
        }
        else {
            $(this).addClass("open");
            $("#packageLoad").animate({
                marginTop: "0px"
            }, 500, function () {
                $("#packageOverlay").show();
            });
        }
    });

    $("#packageOverlay").live("click", function () {
        $(".packageLoad").removeClass("open");
        $("#packageLoad").animate({
            marginTop: "-206px"
        }, 500, function () {
            $("#packageOverlay").hide();
        });
    });
}

function partialLoad(area, path) {
    $(area).html(partialLoading());
    setTimeout(function () {
        $(area).load(path, function (responseText, textStatus, req) {
            $(this).hide().fadeIn();
            if (textStatus == "error") {
                partialError(area);
                return false;
            }
            else { return true; }
        });
    }, 1500);
}

function partialLoading() {
    return "<img src=\"http://localhost:18309/images/global/loading.gif\" width=\"20px\" />";
}

function partialError(area) {
    $(area).fadeOut('fast');

    setTimeout(function () {
        $(area).load("/Global/PartialError", function (responseText, textStatus, req) {
            $(this).fadeIn('slow');
        });
    }, 500);
}