

$(function () {
    refreshCode("J_validate_code");
    //form内input控件行为
    $(".unlogin-box input").on("focus", function () {
        $(".unlogin-box input").removeClass("input-focus");
        $(this).addClass("input-focus");
    });

    //mobileCode
    $("#mobileCode,#emailCode").on("click", function (o) {
        o.stopPropagation();
        refreshCode("J_validate_code");
    });
    $("#emailCode").on("click", function (o) {
        o.stopPropagation();
        refreshCode("J_validate_code");
    });

    $(".register-btn,.register-btnselect").on("click", function (o) {
        o.stopPropagation();
        var txt = $(this).text();
        var preItem = $(".register-typebtn .register-btnselect");
        $(preItem).removeClass("register-btnselect");
        $(preItem).addClass("register-btn");
        $(this).removeClass("register-btn");
        $(this).addClass("register-btnselect");
        $("span.error-text").hide();
        if ('MobileRegister' == txt) {
            $("#user-register_email").css("display", "none");
            $("#user-register_mobile").show();
        }
        else {
            $("#user-register_mobile").css("display", "none");
            $("#user-register_email").show();
        }

    });
    function i(o) {
        var n = new RegExp("(^|&)" + o + "=([^&]*)(&|$)"), t = window.location.search.substr(1).match(n);
        return null != t ? unescape(t[2]) : null
    }
    function refreshCode(o) {
        var n = Date.parse(new Date);
        $("." + o).attr("src", "../Account/GetValidateCode?t=" + n);
        $(".yzm-pic").show();
    }
    function SendSMS(o) {
        o.stopPropagation();
        o.preventDefault();
        var moblie = $("#mobile").val();
        //验证处理
        var mobilereg = /^[1][3,4,5,7,8][0-9]{9}$/;
        if (!mobilereg.test(moblie)) {
            new $Msg({
                content: "请输入正确的手机号码\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            });
            return
        }

        //ajax提交发送请求
        $.ajax(
                { url: "/Register/SmsSend",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "register",
                                Account: moblie
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o == "0") {
                            $("span.error-text").text("短信已经发送到你的手机，请注意查收，5分钟内有效").show();

                        }
                        else {
                            $("span.error-text").text("短信发送失败|或者手机注册未开启").show();
                        }
                    }
                     ,
                    error: function (o) {
                        $("span.error-text").text(o.result).show();
                    }

                }); //ajax
        $("#code-btn").unbind();
        var that = $("#code-btn");
        $(that).removeClass("code-btn");
        $(that).addClass("code-btn-disabled");
        var sendnewSMS = new DaojishiPlugEx2("code-btn", function () {
            $("#code-btn").removeClass("code-btn-disabled");
            $("#code-btn").addClass("code-btn");
            $('#code-btn').text("获取验证码");
            $("#code-btn").on("click", SendSMS);
        });
        var stampend = parseInt($(that).attr('data-time')); //灵活读取表里的结束时间戳
        sendnewSMS.timer(stampend);
    }
    function SendmailSMS(o) {
        o.stopPropagation();
        o.preventDefault();
        var mail = $("#email").val();
        //----------验证
        var mailreg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
        if (!mailreg.test(mail)) {
            new $Msg({
                content: "请输入正确的邮箱\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            });
            return
        }

        //ajax提交发送请求
        $.ajax(
            {
                url: "/Register/SmsSendEmail",
                type: "post",
                data: {
                    ehaiker_parameter: JSON.stringify(
                        {
                            c: "Index",
                            fun: "register",
                            Account: mail
                        })
                },
                dataType: "json",
                success: function (o) {
                    if (o == "0") {
                        $("span.error-text").text("验证码已经发送到你的邮箱，请注意查收，5分钟内有效").show();

                    }
                    else {
                        $("span.error-text").text("验证码发送失败|或者邮箱注册未开启").show();
                    }
                }
                ,
                error: function (o) {
                    $("span.error-text").text(o.result).show();
                }

            }); //ajax
        $("#email-btn").unbind();
        var that = $("#email-btn");
        $(that).removeClass("code-btn");
        $(that).addClass("code-btn-disabled");
        var sendnewSMS = new DaojishiPlugEx2("email-btn", function () {
            $("#email-btn").removeClass("code-btn-disabled");
            $("#email-btn").addClass("code-btn");
            $('#email-btn').text("获取验证码");
            $("#email-btn").on("click", SendmailSMS);
        });
        var stampend = parseInt($(that).attr('data-time')); //灵活读取表里的结束时间戳
        sendnewSMS.timer(stampend);
    }
    //发送验证码
    $("#code-btn").on("click", SendSMS);
    $("#email-btn").on("click", SendmailSMS);

    //绑定手机注册事件
    $("#J_mobileRegister-btn").on("click",
        function (o) {
            o.stopPropagation();
            var n = $("#mobile").val(),
            t = $("#mobilePassword").val(),
            r = $("#mobileCode").val(),
            v = $("#mobileSms").val(),
            c = n;
            //验证处理
            var mobilereg = /^[1][3,4,5,7,8][0-9]{9}$/;
            if (!mobilereg.test(n)) {
                new $Msg({
                    content: "请输入正确的手机号码\r\n",
                    title: "提示",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                });
                return
            }
            if (t != $("#mobileRePassword").val()) {
                new $Msg({
                    content: "两次输入密码不正确\r\n",
                    title: "提示",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                });
                return
            }
            //ajax提交
            $.ajax(
                { url: "/Register/SmsRegister",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "register",
                                Account: n,
                                password: t,
                                verificat_code: r,
                                verificat_smscode: v,
                                MobilePhone: c
                            })
                    },
                    dataType: "json",
                    success: function (o) {

                        if (o.SuccessCode == "0") {
                            //$("#logID").text(o.Account);
                            window.location.href = "/";
                            return;
                        }
                        else if (o.SuccessCode == "10000") {
                            //  $("#header-login-info").attr("href", o.UserInfoUrl);
                            $("span.error-text").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10001") {

                            $("span.error-text").text(o.msg).show();

                        }
                        else if (o.SuccessCode == "10002") {
                            $("span.error-text").text(o.ErrorString).show();
                        }
                        else if (o.SuccessCode == "10003") {
                            $("span.error-text").text(o.msg).show();
                        }


                    }
                     ,
                    error: function (o) {
                        //e("J_validate_code");
                        $("span.error-text").text(o.msg).show();
                    }

                }); //ajax
        });
    //绑定邮箱注册事件
    $("#J_emailRegister-btn").on("click",
        function (o) {
            o.stopPropagation();
            var n = $("#email").val(),
            t = $("#emailPassword").val(),
                r = $("#emailCode").val();
            v = $("#emailSms").val(),
            c = n;
            //----------验证
            var mailreg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
            if (!mailreg.test(n)) {
                new $Msg({
                    content: "请输入正确的邮箱\r\n",
                    title: "提示",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                });
                return
            }
            if (t != $("#emailRePassword").val()) {
                new $Msg({
                    content: "两次输入密码不一致\r\n",
                    title: "提示",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                });
                return
            }
            //ajax提交
            $.ajax(
                { url: "/Register/EmailRegister",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "register",
                                Account: n,
                                password: t,
                            verificat_code: r,
                            verificat_smscode: v,
                                MobilePhone: c
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.SuccessCode == "0") {
                            window.location.href = "/";
                        }
                        else if (o.SuccessCode == "10000") {
                            //  $("#header-login-info").attr("href", o.UserInfoUrl);
                            $("span.error-text").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10001") {
                            $("span.error-text").text(o.msgg).show();
                        }
                        else if (o.SuccessCode == "10002") {
                            $("span.error-text").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10003") {
                            $("span.error-text").text(o.msg).show();
                        }


                    }
                     ,
                    error: function (o) {
                        $("span.error-text").text(o.msg).show();
                    }

                }); //ajax
        });
    //---------------------

});