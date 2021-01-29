
$(function () {
//格式化试图
    var cardview =$.extend({},$.fn.datagrid.defaults.view,{
    renderRow:function(target,fileds,frozen,rowIndex,rowData){
    var listr='';
    if( typeof(rowData.ItemID) != 'undefined'){
     listr = '<div class="top-img"><img src="' + rowData.ImgDescUri +
                    '" /><div class="cover"><div class="opacity"></div><div class="info"><a href="' + rowData.targetUri +
                    '" class="sw-btn" target="_blank" >前去玩耍</a></div></div><div class="bottom-content"><span class="fanli-tag">' + rowData.grade +
                    '</span><p>' + rowData.ItemName +
         '</p><p>运营商:<span class="sw-jl">' + rowData.supporter + '</span></p></div>';
     }
    return listr;
    }
    });
         $('#gametb').textbox({
                buttonText: '查询',
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
        url: '../GameCenter/GetGameListInfo',
        pagination: true,        //设置显示分页
        loadMsg:'数据加载中....',
     view:cardview,
     fitColumns:true,
    toolbar: "#Usetool",
    loadFilter: pagerFilter,

    });
    //---按钮事件
     $("#btnWebGeme,#btnAppGame,#btnotherGame").on("click", function (o) {
           o.stopPropagation();
          $('#contentGrid').datagrid({
                        queryParams: {
                            name: $(this).val(),
                            type:$(this).data("type")
                        }
                    });
     });
     
//------------------------------
});