function goTop() {
    $('html,body').animate({ 'scrollTop': 0 }, 300);
}
  //判断是否为顶层窗口
if (self != top) {
    top.location.href = "../Account";
    return
}
$(function () {
    //---检测用户是否已经登录
  
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
    $("#QQuicklogin").on("click", function (o) {
        o.stopPropagation();
        qqLoginHandle();
    });
    //签到功能
    $("span.qiandao-btn").on("click", function (o) {
        o.stopPropagation();
        var thisobj = $("span.qiandao-btn");
        $.ajax({
            url: "/Account/SiginClick",
            type: "post",
            dataType: "json",
            success: function (o) {
                if (o.SuccessCode != "-1000") {
                    $(thisobj).removeClass("qiandao-btn");
                    $(thisobj).addClass("qiandao-btn-ready");
                    $(thisobj).unbind();
                }
                else {
                    ; //alert("hjk");
                }

            }
                     ,
            error: function (o) {
                new $Msg({
                    content: "签到出错\r\n",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                });
            }

        }); //ajax

    });
    
    function e(o) {
        if ("" != $("." + o).attr("src")) {
            var n = Date.parse(new Date);
            $("." + o).attr("src", "/Account/GetValidateCode?t=" + n);
            $(".yzm-pic").show();
        }
    }
    //绑定事件
    $(".J_userlogin").on("click",
        function (o) {
            o.stopPropagation();
            var n = $("#account").val(),
            t = $("#password").val(),
            r = $("#code").val(),
            c = $("#isAuto").prop("checked");
            //ajax提交
            $.ajax(
                { url: "/Account/memshiplogin",
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
                            $("#loginform").css("display", "none");
                            $(".login-ready").show();
                            $("#header-login-info").text(o.Account);
                            $("#header-login-info").attr("href", o.UserInfoUrl);
                            $("#user_logop").attr("href", o.UserLogUrl); //设置验证图片地址
                            $("#logname").text(o.Account);
                            $("#logID").text("ID:" + o.UserId);
                            $("#user-onwer-UMoney").text(o.UMoney);
                            $("#user-onwer-TMoney").text(o.TMoney);
                            SetQiandaoState();
                        }
                        else {
                            $("#header-login-info").attr("href", o.UserInfoUrl);
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
            location.href = "/Account/Logout";
        });
    }

    function SetQiandaoState() {
        var pbtn = $("span.qiandao-btn");
        if (pbtn == null)
            return;

        //查询用户状态
        $.ajax({
            url: "/Account/GetSignStatus",
            type: "post",
            dataType: "json",
            success: function (o) {
                if (o.SuccessCode != "-10000") {
                    var pbtn = $("span.qiandao-btn");
                    $(pbtn).removeClass("qiandao-btn");
                    $(pbtn).addClass("qiandao-btn-ready");
                    $(pbtn).unbind();
                }

            }
                     ,
            error: function (o) {
                ;
            }

        }); //ajax
    }
    //-----------查询用户签到状态
    SetQiandaoState();
    //-------------end
    $(".OnlineKefu ul li").hover(function () {
        $(this).find(".sidebox").stop().animate({ "width": "124px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "#ae1c1c" })
    }, function () {
        $(this).find(".sidebox").stop().animate({ "width": "54px" }, 200).css({ "opacity": "0.8", "filter": "Alpha(opacity=80)", "background": "#000" })
    });

});

