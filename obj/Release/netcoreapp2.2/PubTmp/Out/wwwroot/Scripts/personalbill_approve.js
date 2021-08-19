
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
});