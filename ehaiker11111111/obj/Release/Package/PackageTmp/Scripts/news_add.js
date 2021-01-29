$(function () {

    //---------------------------------------------
    $(".box-wrap input").on("focus", function () {
        $(".box-wrap input").removeClass("input-focus");
        $(this).addClass("input-focus");
    });
    //

    //发表文章
    $("#personal-shiwan-add-btn").on("click", function (o) {
        o.stopPropagation();
        var title = $("#idTitle").val();
        var article_content = tinyMCE.activeEditor.getContent({ format: 'raw' });
        var content = article_content;
        var gameid = $("#Types").val();
        //验证处理
        if (typeof title == "undefined" || title == null || title == "") {
            new $Msg({
                content: "请输入标题\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return
        }

        //ajax提交发送请求
        $.ajax(
                { url: "../NewsCenter/Add",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "Add",
                                Title: title,
                                Content: escape(content.replace(/(?!<(img|p|span).*?>)<.*?>/g, "")),
                                GameId: gameid
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.iSuccessCode > 0) {
                            new $Msg({
                                content: "公告发布成功\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })

                        }
                        else {
                            new $Msg({
                                content: o.msg,
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })
                        }
                    }
                     ,
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        new $Msg({
                            content: "公告发布失败\r\n",
                            title: "提示",
                            type: "success",
                            footer: true,
                            header: true,
                            btnName: ["确定"]
                        })
                    }

                }); //ajax
    });

});