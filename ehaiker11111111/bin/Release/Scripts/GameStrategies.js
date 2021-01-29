
$(function () {
//格式化试图
    var cardview =$.extend({},$.fn.datagrid.defaults.view,{
    renderRow:function(target,fileds,frozen,rowIndex,rowData){
    var cc=[];
    if( typeof(rowData.Id) != 'undefined'){
    cc.push('<li><a href="../GameStrategiesShow?wenzhangID=' + rowData.Id + '" name="opera" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\')">'+
    rowData.Title+'</a></li>');
    }
    return cc.join('');
    }
    });
 $('#gametb').textbox({
                buttonText: '搜索',
                iconCls: 'icon-search',
                iconAlign: 'left',
                onClickButton: function () {
                    $('#contentGrid').datagrid({
                        queryParams: {
                            name: $("#gametb").val(),
                            type:-1
                        }
                    });
                }
            });
            function changeDateFormat(cellval) {
        if (cellval != null) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    };
    
     //分页功能    
            function pagerFilter(data) {
                if (typeof data.length == 'number' && typeof data.splice == 'function') {
                    data = {
                        total: data.length,
                        rows: data
                    }
                }
                var dg = $(this);
                var opts = dg.datagrid('options');
                var pager = dg.datagrid('getPager');
                pager.pagination({
                    onSelectPage: function (pageNum, pageSize) {
                        opts.pageNumber = pageNum;
                        opts.pageSize = pageSize;
                        pager.pagination('refresh', {
                            pageNumber: pageNum,
                            pageSize: pageSize
                        });
                        dg.datagrid('loadData', data);
                    }
                });
                if (!data.originalRows) {
                    if(data.rows)
                        data.originalRows = (data.rows);
                    else if(data.data && data.data.rows)
                        data.originalRows = (data.data.rows);
                    else
                        data.originalRows = [];
                }
                var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
                var end = start + parseInt(opts.pageSize);
                data.rows = (data.originalRows.slice(start, end));
                return data;
            }  
$('#contentGrid').datagrid({
        url: '../GameStrategies/GetGameStrategies',
        pagination: true,        //设置显示分页
        loadMsg:'数据加载中....',
     view:cardview,
    toolbar: "#Usetool",
    loadFilter: pagerFilter,
    });


     //---按钮事件
     $("#btnWebGeme,#btnAppGame,#btnotherGame").on("click", function () {
          $('#contentGrid').datagrid({
                        queryParams: {
                            name: $(this).val(),
                            type:$(this).data("type")
                        }
                    });
     });
//------------------------------
});