//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches
$(function () {
    $(".next").click(function () {
        if (animating)
            return false;
        var n = $("#email").val(),
            t = $("#pass").val(),
            r = $("#cpass").val();
        var mailreg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
        if (!mailreg.test(n)) {
            new $Msg({
                content: "请输入正确的邮箱\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        if (t != r) {
            new $Msg({
                content: "两次密码不一致\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        
        animating = true;

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //改变不骤颜色
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        //显示第二步页面
        next_fs.show();
        //隐藏之前的页面
        current_fs.animate({ opacity: 0 }, {
            step: function (now, mx) {
                //as the opacity of current_fs reduces to 0 - stored in "now"
                //1. scale current_fs down to 80%
                scale = 1 - (1 - now) * 0.2;
                //2. bring next_fs from the right(50%)
                left = (now * 50) + "%";
                //3. increase opacity of next_fs to 1 as it moves in
                opacity = 1 - now;
                current_fs.css({ 'transform': 'scale(' + scale + ')' });
                next_fs.css({ 'left': left, 'opacity': opacity });
            },
            duration: 800,
            complete: function () {
                current_fs.hide();
                animating = false;
            }
        });
    });

    $(".previous").click(function () {
        if (animating) return false;
        animating = true;

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        //de-activate current step on progressbar
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        //show the previous fieldset
        previous_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now, mx) {
                //as the opacity of current_fs reduces to 0 - stored in "now"
                //1. scale previous_fs from 80% to 100%
                scale = 0.8 + (1 - now) * 0.2;
                //2. take current_fs to the right(50%) - from 0%
                left = ((1 - now) * 50) + "%";
                //3. increase opacity of previous_fs to 1 as it moves in
                opacity = 1 - now;
                current_fs.css({ 'left': left });
                previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
            },
            duration: 800,
            complete: function () {
                current_fs.hide();
                animating = false;
            }
        });
    });
    //sendemail
    $("#sendemail").click(function () {
        var n = $("#email").val(),
            t = $("#pass").val(),
            r = $("#cpass").val();
        var mailreg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
        if (!mailreg.test(n)) {
            new $Msg({
                content: "请输入正确的邮箱\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        if (t != r) {
            new $Msg({
                content: "两次输入密码不一致\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        $('.next').attr('disabled', "true"); //添加disabled属性
        //----发送邮件到用户那里，并增加一个修改变量到Session，以便后续验证，本次登录有效
        //ajax提交
        $.ajax(
                { url: "/Personal/PassValidMail",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Personal",
                                fun: "NewPassword",
                                Account: n,
                                password: t
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.SuccessCode == "0") {
                            $('.next').removeAttr("disabled"); //移除disabled属性
                            $(".fs-subtitle").text(o.msg).show();
                        }
                        else {
                            $(".fs-subtitle").text(o.msg).show();
                            return;
                        }
                    }
                     ,
                    error: function (o) {
                        $(".fs-subtitle").text("后台交互出错").show();
                        return;
                    }

                }); //ajax
    });
    $(".submit").click(function () {
        var n = $("#email").val(),
            t = $("#pass").val(),
            r = $("#cpass").val(),
            v = $("#SHAMSG").val(),
            c = n;
        var mailreg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
        if (!mailreg.test(n)) {
            new $Msg({
                content: "请输入正确的邮箱\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        if (t != r) {
            new $Msg({
                content: "两次输入密码不一致\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }
        //ajax提交
        $.ajax(
                { url: "/Personal/NewPassWordEx",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Personal",
                                fun: "NewPassword",
                                Account: n,
                                password: t,
                                verificat_code: v
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.SuccessCode == "0") {
                            window.location.href = "../personal";
                        }
                        else if (o.SuccessCode == "10000") {
                            $("#notice").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10001") {
                            $("#notice").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10002") {
                            $("#notice").text(o.msg).show();
                        }
                        else if (o.SuccessCode == "10003") {
                            $("#notice").text(o.msg).show();
                        }
                    }
                     ,
                    error: function (o) {
                        $("#notice").text(o.msg).show();
                    }

                }); //ajax
    })

});