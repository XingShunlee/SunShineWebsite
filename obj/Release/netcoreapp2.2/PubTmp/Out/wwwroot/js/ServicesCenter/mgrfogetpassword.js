$(function () {
    refreshCode("yzm-pic");
    //form内input控件行为
    $(".input-block input").on("focus", function () {
        $(".input-block input").removeClass("input-focus");
        $(this).addClass("input-focus");
    });

    //mobileCode
    $("#mobileCode,#emailCode").on("click", function (o) {
        o.stopPropagation();
        refreshCode("yzm-pic");
    });
    $(".yanzhengma-block").on("click", function (o) {
        o.stopPropagation();
        refreshCode("yzm-pic");
    });

    function refreshCode(o) {
        var n = Date.parse(new Date);
        $("." + o).attr("src", "/AdminLogin/GetValidateCode?t=" + n);
        $(".yanzhengma-block .yzm-pic").show();
    }
    //发送验证码
    $(".sms-btn").on("click", function (o) {
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
        //
        var chk = $("#sms-tbtn").hasClass("sms-btn-disabled");
        if (chk === true)
            return;
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
                            //disable sms button
                            var redirect = new DaojishiPlugEx2("sms-tbtn", function () {
                                $("#sms-tbtn").removeClass("sms-btn-disabled");
                                $("#sms-tbtn").addClass("sms-btn");
                                $("#sms-tbtn").text("发送验证码");
                            });
                            var stampend = parseInt($("#sms-tbtn").attr('data-time')); //灵活读取表里的结束时间戳
                            redirect.timer(stampend);
                            $("#sms-tbtn").removeClass("sms-btn");
                            $("#sms-tbtn").addClass("sms-btn-disabled");
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
                            window.location.href = "/";
                            return;
                        }
                        else if (o.SuccessCode == "10000") {
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
                        $("span.error-text").text(o.msg).show();
                    }

                }); //ajax
        });
    
    //---------------------

});