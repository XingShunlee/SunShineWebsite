$(function () {

    //---------------------------------------------
    $(".black_overlay a.paybtn").on("click", function (o) {
        o.stopPropagation();
        var typeval = $(this).data("type");
        if (typeval == 1) {
            $("img#payimg").attr("src", "../Common/public/paybill/wx.png");
        }
        else {
            $("img#payimg").attr("src", "../Common/public/paybill/zhifubao.png");
        }
        $("img#payimg").data("type", typeval);
    });
    //

    //
    $(".pay-complete").on("click", function (o) {
        o.stopPropagation();
        var money = $("#uc_01").val();
        var RMB = $("#uc_01").text();
        var paytype = $("img#payimg").data("type");
        //ajax提交发送请求
        $.ajax(
                { url: "../personal/BookVIP",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(
                            { c: "PayBill",
                                fun: "BookVIP",
                                PayValue: money,
                                PayType: paytype
                            })
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o.SuccessCode =="10000") {
                            new $Msg({
                                content: "订单提交成功\r\n",
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
                            content: "订单提交失败\r\n",
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