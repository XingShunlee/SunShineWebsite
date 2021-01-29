
//判断是否为顶层窗口
(function () {
    if (self != top) {
        top.location.href = "../AdminLogin/Index";
    }
})();


$(function () {
    //++++++++++++++++++++++++++++++++++++

    //------------------------------------
    function e(o) {
        if ("" != $("." + o).attr("src")) {
            var n = Date.parse(new Date);
            $("." + o).attr("src", "/AdminLogin/GetValidateCode?t=" + n);
            $(".yzm-pic").show();
        }
    }
    //用户登录
    $(".ulogin-form input").on("focus", function () {
        $(".ulogin-form input").removeClass("input-focus");
        $(this).addClass("input-focus");
    });

    $("#code,#J_validate_code").on("click", function (o) {
        o.stopPropagation();
        e("J_validate_code");
    });
    //自动登录 $("#isAuto")
    $(".auto-login-box").on("click", function (o) {
        o.stopPropagation();
        var state = $("#isAuto").prop('checked');
        $("#isAuto").prop('checked', !state);
        if (state == true) {
            $("#isAuto").removeClass("auto-login-btn unselect");
            $("#isAuto").addClass("auto-login-btn select");
        }
        else {
            $("#isAuto").removeClass("auto-login-btn select");
            $("#isAuto").addClass("auto-login-btn unselect");
        }
    });

    //用户快速登录
    $("#QQuicklogin").on("click", function () {
        qqLoginHandle();
    });
    //<!------QQ ----------------------------->
    function qqLoginHandle() {
        QC.Login({
            btnId: "qqLoginBtn",   //插入按钮的节点id
            scope: "get_user_info"
        }, function (reqData, opts) {
            //登录成功
            //根据返回数据，更换按钮显示状态方法
            var dom = document.getElementById(opts['btnId']),
             _logoutTemplate = [
            //头像
                  '<span><img src="{figureurl}" class="{size_key}"/></span>'
            //昵称
             , '<span>{nickname}</span>'
            //退出
             , '<span><a href="javascript:QC.Login.signOut();">退出</a></span>'
             ].join("");
            dom && (dom.innerHTML = QC.String.format(_logoutTemplate, {
                nickname: QC.String.escHTML(reqData.nickname), //做xss过滤
                figureurl: reqData.figureurl
            }));
        }, function (opts) {
            //注销成功
            location.href = "/AdminLogin/Logout";
        });
    }

    //绑定事件
    $(".login-btn").on("click",
        function (o) {
            o.stopPropagation();
            var n = $("#account").val(),
            t = $("#password").val(),
            r = $("#code").val(),
            c = $("#isAuto").prop("checked");
            //ajax提交
            $.ajax(
                { url: "/AdminLogin/Login",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "login",
                                account: n,
                                password: t,
                                verificat_code: r,
                                is_auto: c
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.SuccessCode == "0") {
                            window.location.href = "../ManagerMain/Index";
                            return;
                        }
                        else {
                            $(".login-error").text(o.msg).show();
                        }

                    }
                     ,
                    error: function (o) {
                        e("J_validate_code");
                        $(".login-error").text(o.msg).show();
                    }

                }); //ajax
        });
    //---------------------------------------------
    

});