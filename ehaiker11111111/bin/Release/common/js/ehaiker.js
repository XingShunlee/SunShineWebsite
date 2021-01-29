﻿function goTop() {
    $('html,body').animate({ 'scrollTop': 0 }, 300);
}
  //判断是否为顶层窗口
if (self != top) {
    top.location.href = "../Ehaiker";
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
            url: "/EHaiker/SiginClick",
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
            $("." + o).attr("src", "/EHaiker/GetValidateCode?t=" + n);
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
                { url: "/EHaiker/memshiplogin",
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
            location.href = "/EHaiker/Logout";
        });
    }

    function SetQiandaoState() {
        var pbtn = $("span.qiandao-btn");
        if (pbtn == null)
            return;

        //查询用户状态
        $.ajax({
            url: "/EHaiker/GetSignStatus",
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
    //---------------------查询Gamelist
    $.ajax({
        url: "../EHaiker/GameTopMost",
        type: "post",
        dataType: "json",
        success: function (arrdata) {
            if (arrdata != null) {
                $.each(arrdata, function (i, item) {
                    var listr = '<li><div class="top-img"><img src="' + item.ImgDescUri +
                    '" /><div class="cover"><div class="opacity"></div><a href="' + item.hrefUri +
                    '" style="display:block;width:100%;height:100%;position:absolute;top:0;left:0;cursor:pointer;" target="_blank" ><div class="info"><a href="' + item.hrefUri +
                    '" class="sw-btn J_click_key" target="_blank" >前去玩耍</a></div></a></div></div><div class="bottom-content"><span class="fanli-tag">' + item.fanli +
                    '</span><p>' + item.ItemName +
                    '</p><p>运营商:<span class="sw-jl">' + item.ImgHoverUri + '</span></p></div></li>';
                    $("#GameTopMost").append(listr);  //动态取数据
                });
            }

        }
    });
    //HotList
    $.ajax({
        url: "../EHaiker/GameHotItems",
        type: "post",
        dataType: "json",
        success: function (arrdata) {
            if (arrdata != null) {
                $.each(arrdata, function (i, item) {
                    var listr = '<li><a href="' + item.ImgHoverUri + '" class="ad-href" target="_blank" ><img src="' + item.ImgDescUri +
                    '" alt=" " width="270px" height="180px"></a></li>';
                    $("#HotList").append(listr);  //动态取数据
                });
            }

        }
    });

    //----游戏攻略分享
    $.ajax({
        url: "../EHaiker/GameWenzhuangItems",
        type: "post",
        dataType: "json",
        data: { id: $("#search_content").val() },
        success: function (arrdata) {
            if (arrdata != null) {
                $("#content li").remove();
                $.each(arrdata, function (i, item) {
                    var listr = '<li><a href="../GameStrategiesShow?wenzhangID=' + item.Id + '" class="news-href" target="_blank" ><strong>' + item.Title +
                    '</strong></a></li>';
                    $("#content").append(listr);  //动态取数据
                });
            }

        }
    });
    //---------------------------类型按钮

    $(".share-game-types a").on("click", function (o) {
        o.stopPropagation();
        var preItem = $(".share-game-types.type-btnselect");
        $(preItem).removeClass("share-game-types type-btnselect");
        $(preItem).addClass("share-game-types type-btn");
        $(this).removeClass("share-game-types type-btn");
        $(this).addClass("share-game-types type-btnselect");
        $.ajax({
            url: "../EHaiker/GameWenzhuangItems",
            type: "post",
            dataType: "json",
            data: { type: $(this).data("type") },
            success: function (arrdata) {
                if (arrdata != null) {
                    $("#content li").remove();
                    $.each(arrdata, function (i, item) {
                        var listr = '<li><a href="../GameStrategiesShow?wenzhangID=' + item.Id + '" class="news-href" target="_blank" ><strong>' + item.Title +
                    '</strong></a></li>';
                        $("#content").append(listr);  //动态取数据
                    });
                }

            }
        });
    });
    //游戏推荐事件
    $(".l-game-types a").on("click", function (o) {
        o.stopPropagation();
        var preItem = $(".l-game-types.type-btnselect");
        $(preItem).removeClass("l-game-types type-btnselect");
        $(preItem).addClass("l-game-types type-btn");
        $(this).removeClass("l-game-types type-btn");
        $(this).addClass("l-game-types type-btnselect");
        $.ajax({
            url: "../EHaiker/GameTopMost",
            type: "post",
            dataType: "json",
            data: { type: $(this).data("type") },
            success: function (arrdata) {
                if (arrdata != null) {
                    $("#GameTopMost li").remove();
                    $.each(arrdata, function (i, item) {
                        var listr = '<li><div class="top-img"><img src="' + item.ImgDescUri +
                    '" /><div class="cover"><div class="opacity"></div><a href="' + item.hrefUri +
                    '" style="display:block;width:100%;height:100%;position:absolute;top:0;left:0;cursor:pointer;" target="_blank" ><div class="info"><a href="' + item.hrefUri +
                    '" class="sw-btn J_click_key" target="_blank" >前去玩耍</a></div></a></div></div><div class="bottom-content"><span class="fanli-tag">' + item.fanli +
                    '</span><p>' + item.ItemName +
                    '</p><p>运营商:<span class="sw-jl">' + item.ImgHoverUri + '</span></p></div></li>';
                        $("#GameTopMost").append(listr);  //动态取数据
                    });
                }

            }
        });
    });
    //游戏供应商
    $.ajax({
        url: "../EHaiker/getSupplierInfo",
        type: "post",
        dataType: "json",
        success: function (arrdata) {
            if (arrdata != null) {
                $.each(arrdata, function (i, item) {
                    var listr = '<li><span><img src="' + item.ImgDescUri +
                    '" alt=" " /></span></li>';
                    $(".hzsj-list").append(listr);  //动态取数据
                });
            }

        }
    });
    //-------新闻中心
    //HotList
    $.ajax({
        url: "../NewsCenter/NewsHotItems",
        type: "post",
        dataType: "json",
        success: function (arrdata) {
            if (arrdata != null) {
                $.each(arrdata, function (i, item) {
                    var listr = '<li><a href="../NewsCenter/showDetail?newsID=' + item.Id + '" class="news-href" target="_blank" >' + item.Title + '</a></li>';
                    $("#newsContent").append(listr);  //动态取数据
                });
            }

        }
    });
    //-------------end
    $(".OnlineKefu ul li").hover(function () {
        $(this).find(".sidebox").stop().animate({ "width": "124px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "#ae1c1c" })
    }, function () {
        $(this).find(".sidebox").stop().animate({ "width": "54px" }, 200).css({ "opacity": "0.8", "filter": "Alpha(opacity=80)", "background": "#000" })
    });

});

