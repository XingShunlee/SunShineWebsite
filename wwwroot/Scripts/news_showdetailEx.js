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
        var contentid = $("#newsID").val();
        var article_content = tinyMCE.activeEditor.getContent();
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
            });
            return
        }

        //ajax提交发送请求
        $.ajax(
                { url: "../NewsCenter/Edit",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "Edit",
                                Title: title,
                                Content: escape(content.replace(/<(?!img).*?>/g, "")),
                                GameId: gameid,
                                Id: contentid
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.iSuccessCode > 0) {
                            new $Msg({
                                content: "广告修改成功\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })

                        }
                        else {
                            new $Msg({
                                content: o.msg+"\r\n",
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
                            content: "修改提交失败\r\n",
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