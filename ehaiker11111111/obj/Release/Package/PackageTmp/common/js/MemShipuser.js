 function ResetPassword(id, accounts) {
           $.messager.confirm('确认对话框', "确定重置" + accounts + "的密码", function (result) {
               if (result) {
                   $.ajax({
                       url: "../AdminHome/ResetMemshipPassword",
                       type: "post",
                       data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "ResetPassword",
                                Account: accounts,
                                UserId: id
                            })
                       },
                       dataType: "json",
                       success: function (res) {

                           if (res > 0) {
                               $.messager.alert('提示', '重置成功！');
                               $("#UserGrid").datagrid("reload");
                           }
                           else {
                               $.messager.alert('提示', '重置失败！');
                           }
                       }
                   });
               }
           });
       };  
$(function () {
//---
            $('#Usertb').textbox({
                buttonText: '搜索',
                iconCls: 'icon-search',
                iconAlign: 'left',
                onClickButton: function () {
                    $('#UserGrid').datagrid({
                        queryParams: {
                            Account: $("#Usertb").val(),
                        }
                    });
                }
            });
            //删除
            $("#btnUserDelete").linkbutton({
                onClick: function () {
                    var rows = $("#UserGrid").datagrid("getChecked");
                    if (rows.length == 0) {
                        $.messager.alert('警告', '请选择删除的数据！');
                    }
                    else {
                        
                        var ids = "";
                        for (var i = 0; i < rows.length; i++) {
                            if (i < rows.length - 1) {
                                ids += rows[i].UserId + ",";
                            }
                            else {
                                ids += rows[i].UserId;
                            }
                            
                        }
                        $.messager.confirm('确认', '您确认想要删除记录吗？', function (r) {
                            if (r) {
                                $.ajax({
                                    url: '../AdminHome/DelMemShip',
                                    type: 'post',
                                    data: {
                                        ids: ids
                                    },
                                    success: function (res) {
                                        $("#UserGrid").datagrid("reload");
                                        if (res > 0) {
                                        
                                            $.messager.alert('提示', '删除成功！');
                                           
                                        }
                                        else {
                                            $.messager.alert('提示', '删除失败！');
                                        }
                                    }

                                });
                            }
                        });  
                      

                    }
                }
            });
            //编辑
            $("#btnUserEdit").linkbutton({
                onClick: function () {

                    var rows = $("#UserGrid").datagrid("getSelections");
                    if (rows.length == 0 || rows.length > 1) {
                        $.messager.alert("提示", "请选择一行数据");
                    }
                    else {
                        $('#ddUserAdd').dialog({
                            title: '修改信息',
                            width: 400,
                            height: 200,
                            closed: false,
                            cache: false,
                            modal: true,
                        });
                        $("#username").textbox({
                            value: rows[0].Account
                        });
                        $("#btnUserSave").linkbutton({
                            onClick: function () {
                                $.ajax({
                                    url: '../AdminHome/MemshipEdit',
                                    type: 'post',
                                    data: {ehaiker_parameter: JSON.stringify({
                                        name: $("#username").val(),
                                        UserId: rows[0].UserId
                                        })
                                    },
                                    success: function (res) {
                                    $("#UserGrid").datagrid("reload");
                                        if (res == 1) {
                                            $.messager.alert("提示", "修改成功！");
                                            
                                        }
                                        else {
                                            $.messager.alert("提示", "修改失败！");
                                        }
                                    }
                                });
                            }
                        })

                    }
                }
            });
           
//++++++++++++++++++++++++++++++++++++
    //转换日期格式  
function changeDateFormat(cellval) {
        if (cellval != null) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    };
   
    
    //-----------------------------------------------
    $.ajax({
        url: "../AdminHome/GetMemberInfo",
        type: "post",
        dataType: "json",
        success: function (data) {
            $("#UserGrid").datagrid("loadData", data);  //动态取数据
        }
    });
    $('#UserGrid').datagrid({
        url: '/AdminHome/GetMemberInfo',
        pagination: true,        //设置显示分页
        columns: [[
        { field:'check', title:"state", checkbox: true,width: 100 },
        { field: 'Account', title: 'Name', width: 100 },
        { field: 'LoginTime', title: 'LoginTime', width: 100, formatter: function (value, row, index) {
            return changeDateFormat(value)
        }
        },
        { field: 'CreateTime', title: 'CreateTime', width: 100, formatter: function (value, row, index) {
            return changeDateFormat(value)
        }
        },
        { field: 'LoginIP', title: 'LoginIP', width: 100 },
        { title: "操作", field: 'UserId', width: 100, formatter: function (value, row, index) {
            return '<a href="#" name="opera" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="ResetPassword('+value+',\''+ row.Account +'\')">重置密码</a>';
        }
        }
    ]],
    toolbar: "#Usertool",
    onLoadSuccess:function(data){  
        $("a[name='opera']").linkbutton({text:'重置密码',plain:true,iconCls:'icon-remove'});  
        },
    });
    //------------------------------------
    
    
   
   
    //---------------------------------------------

});