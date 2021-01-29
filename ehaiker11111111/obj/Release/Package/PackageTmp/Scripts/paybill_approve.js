
function approve_ac(index,state) {
    
    //保存到数据库
    $.ajax(
                { url: "../PayCenter/SetPayBillState",
                    type: "post",
                    data: {
                        KeyValue: index,
                        PayForState: state
                    },
                    dataType: "json",
                    success: function (o) {

                        new $Msg({
                            content: o,
                            title: "提示",
                            type: "success",
                            footer: true,
                            header: true,
                            btnName: ["确定"]
                        })
                        window.location.href = "../PayCenter/Index";
                    }
                     ,
                    error: function (o) {
                        new $Msg({
                            content: "操作失败\r\n",
                            title: "提示",
                            type: "success",
                            footer: true,
                            header: true,
                            btnName: ["确定"]
                        })
                    }

                });   //ajax
}
$(function () {
    function escape2Html(str) {
        var arrEntities = { 'lt': '<', 'gt': '>', 'nbsp': ' ', 'amp': '&', 'quot': '"' };
        return str.replace(/&(lt|gt|nbsp|amp|quot);/ig, function (all, t) { return arrEntities[t]; });
    }
    //---------------------------------------------
    $("#PayForState").change(function (o) {
        var state = $(this).children('option:selected').val();
        o.stopPropagation();
        var data = $("#griddata").val();
        $(".datagrid-container-fliud").empty();
        $(".datagrid-container-fliud").append(
    '<div class="data-row">' +
     '<div style="width:8%;" class="data-col">会员信息</div>' +
     '<div style="width:12%;" class="data-col">支付内容</div>' +
     '<div style="width:8%;" class="data-col">支付类型</div>' +
     '<div style="width:8%;" class="data-col">支付数值</div>' +
     '<div style="width:30%;" class="data-col">支付凭证</div>' +
     '<div style="width:14%;" class="data-col">提交时间</div>' +
     '<div style="width:10%;" class="data-col">状态</div>' +
     '<div style="width:10%;" class="data-col">操作</div>' +
     '</div>');
        if (data != null) {
            var listr = '';
            var jsondata = $.parseJSON(data);
            for (var i = 0; i < jsondata.length; i++) {
                var item = jsondata[i];

                if (Number(item.PayState) == Number(state) || Number(state) == 10000) {
                    var str = '<div class="data-row">' +
                        '<div style="width:8%;" class="data-col">' + item.UserId + '</div>' +
                         '<div style="width:12%;" class="data-col">' + item.PayForWhat + '</div>' +
                         ' <div style="width:8%;" class="data-col">' + (item.PayType == 2 ? "支付宝" : item.PayType > 1 ? "在线支付" : "微信支付") + '</div>' +
                         '<div style="width:8%;" class="data-col">' + item.PayValue + '</div>' +
                         '<div style="width:30%;" class="data-col">' + item.PayIdentity + '</div>' +
                         '<div style="width:14%;" class="data-col">' + item.PayForDateTime + '</div>' +
                          '<div style="width:10%;" class="data-col">' + item.PayState + '</div>' +
                          '<div style="width:10%;" class="data-col">' +
                          '<a href="javascript:void(0)" onclick="approve_ac(' + item.PayBillID +
                   ',1)">通过</a>' +
                   ' <a href="javascript:void(0)" onclick="approve_ac( ' + item.PayBillID + ',0)">撤销</a>' +
                    '        </div>' +
                    '   </div>';
                    listr = listr + str;
                }
            }
            $(".datagrid-container-fliud").append(listr);  //动态取数据
        }
    });
    //

});