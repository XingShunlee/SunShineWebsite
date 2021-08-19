
$(function () {
    
	 $('.guanzhumenu:last').mouseover(function () {
        $('.guanzhumenu:last .guanzhuBox').css("display", "inline-block");
    });
    $('.guanzhumenu:last').mouseout(function () {
        $('.guanzhumenu:last .guanzhuBox').css("display", "none");
    });
});