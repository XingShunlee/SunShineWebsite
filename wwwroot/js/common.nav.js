
$(function () {
    
	 $('.guanzhumenu:last').mouseover(function () {
        $('.guanzhumenu:last .guanzhuBox').css("display", "block");
    });
    $('.guanzhumenu:last').mouseout(function () {
        $('.guanzhumenu:last .guanzhuBox').css("display", "none");
    });
    $('.softlife-navbar-toggle').click(function (event) {
        event.stopPropagation();
        var r = $('.softlife-navbar-content').css("display");
        if (r !== "block") {
            $('.softlife-navbar-content').css("display","block");
        }
        else {
            $('.softlife-navbar-content').attr("style", ";");
        }
    });
});