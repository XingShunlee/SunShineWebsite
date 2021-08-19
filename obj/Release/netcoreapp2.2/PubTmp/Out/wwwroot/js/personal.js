$(function () {
    //---

    //加载对应的JS文件
    //$.getScript("../xx.js");
    //---------------------------------------------
    $("#liUbit").on("click", function (o) {
        o.stopPropagation();
        $(".block-Right").load("../personal/UserInfo");
    });
    //
    $("#liTbit").on("click", function (o) {
        o.stopPropagation();
        $(".block-Right").load("../personal/UserInfo");
    });
    //listrategies
    $("#listrategies").on("click", function (o) {
        o.stopPropagation();
        window.location.href = "../personal/show?pageindex=1&pagesize=11";
    });
    //linewstrategies
    $("#linewstrategies").on("click", function (o) {
        o.stopPropagation();
        $(".block-Right").load("../personal/Add");
        /* $("head").append("<link>");
        css = $("head").children(":last");
        css.attr({
        rel: "stylesheet",
        type: "text/css",
        href: "../common/css/personal/home-page.min.css"
        });*/

    });
    //lipayvip
    $("#lipayvip").on("click", function (o) {
        o.stopPropagation();
        $(".block-Right").load("../personal/PayBill");
    });
    $("#lipaybill").on("click", function (o) {
        o.stopPropagation();
       window.location.href = "../personal/MyBill?pageindex=1&pagesize=10";
      //  $(".block-Right").load("../personal/MyBill?pageindex=1&pagesize=10");
    });
    //修改密码liModify
    $("#liModify").on("click", function (o) {
        o.stopPropagation();
        $(".block-Right").load("../personal/NewPassword");
    });
    //liuserInfo
    $("liuserInfo").on("click", function (e) {
        e.stopPropagation();
        $(".block-Right").load("../personal/UserInfo");
    });
    //左侧菜单 
    $('dt').click(function (e) {
        e.stopPropagation();
        var obj = $(this).next();
        if ($(this).next().css('display') == 'block') {
            obj.hide('fast');
            $(this).removeClass('on');
        }
        else {
            obj.show('fast');
            $(this).addClass('on');
        }
    });
});