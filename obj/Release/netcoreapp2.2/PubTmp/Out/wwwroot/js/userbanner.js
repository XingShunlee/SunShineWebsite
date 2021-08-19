$(function () {
    //---检测用户是否已经登录
    //判断是否为顶层窗口
    if (self != top) {
        top.location.href = "../Ehaiker";
        return
    }
    var usrname = $("#header-login-info").text();
    if ("游客" != usrname) {
        $("#loginform").css("display", "none");
        $(".login-ready").show();
        $("#header-login-info").text(usrname);
        $("#header-login-info").attr("href", "#");
       // $("#user_logop").attr("href", "/Ehaiker/Logout");
       // $("#user_logop").text("退出");
        $("#logname").text(usrname);

    }
    else {
        $(".login-ready").css("display", "none");
        $("#header-login-info").attr("href", "#");
        $("#header-login-info").text("游客,请登录");
        //$("#user_logop").attr("href", "/Ehaiker/Login");
       // $("#user_logop").text("登录");
    }
    //-------------end
});

