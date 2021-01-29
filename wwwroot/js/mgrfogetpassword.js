$(function () {

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
    $(".J_validate_code validate-code").on("click", function (o) {
        o.stopPropagation();
        refreshCode("J_validate_code");
    });

    function refreshCode(o) {
        var n = Date.parse(new Date);
        $("." + o).attr("src", "/EHaiker/GetValidateCode?t=" + n);
        $(".yzm-pic").show();
    }
    //发送验证码
    $(".code-btn").on("click", function (o) {
        o.stopPropagation();
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
                { url: "/ServicesCenter/SmsSend",
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
                            $("span.error-text").text("短信发送失败|或者手机号码找回未开启").show();
                        }
                    }
                     ,
                    error: function (o) {
                        $("span.error-text").text(o.result).show();
                    }

                }); //ajax
    });
    //绑定手机注册事件
    $("#J_mobileForget-btn").on("click",
        function (o) {
            o.stopPropagation();
            var n = $("#mobile").val(),
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
            //ajax提交
            $.ajax(
                { url: "/ServicesCenter/SmsForgetPasswordEx",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "register",
                                Account: n,
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
                            $("span.error-text").text(o.msg).show();
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
    
    //---------------------

});