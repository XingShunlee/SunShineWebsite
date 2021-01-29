function ResetPassword(id, accounts) {
           $.messager.confirm('确认对话框', "确定重置" + accounts + "的密码", function (result) {
               if (result) {
                   $.ajax({
                       url: "../AdminHome/ResetPassword",
                       type: "post",
                       data: { ehaiker_parameter: JSON.stringify(
                            { c: "Index",
                                fun: "ResetPassword",
                                Account: accounts,
                                AdministratorID:id
                            })
                       },
                       dataType: "json",
                       success: function (res) {
                           
                           if (res >0) {
                               $.messager.alert('提示', '重置成功！');
                               $("#AdminGrid").datagrid("reload");
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
            $('#tb').textbox({
                buttonText: '搜索',
                iconCls: 'icon-search',
                iconAlign: 'left',
                onClickButton: function () {
                    $('#AdminGrid').datagrid({
                        queryParams: {
                            name: $("#tb").val(),
                        }
                    });
                }
            });
            //删除
            $("#btnDelete").linkbutton({
                onClick: function () {
                    var rows = $("#AdminGrid").datagrid("getChecked");
                    if (rows.length == 0) {
                        $.messager.alert('警告', '请选择删除的数据！');
                    }
                    else {
                        
                        var ids = "";
                        for (var i = 0; i < rows.length; i++) {
                            if (i < rows.length - 1) {
                                ids += rows[i].AdministratorID + ",";
                            }
                            else {
                                ids += rows[i].AdministratorID;
                            }
                            
                        }
                        $.messager.confirm('确认', '您确认想要删除记录吗？', function (r) {
                            if (r) {
                                $.ajax({
                                    url: '../AdminHome/DelAdmin',
                                    type: 'post',
                                    data: {
                                        ids: ids,
                                    },
                                    success: function (res) {
                                        $("#AdminGrid").datagrid("reload");
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
            $("#btnEditGroup").linkbutton({
                onClick: function () {

                    var rows = $("#AdminGrid").datagrid("getSelections");
                    if (rows.length == 0 || rows.length > 1) {
                        $.messager.alert("提示", "请选择一行数据");
                    }
                    else {
                        
                        $("#edusername").textbox({
                            value: rows[0].Account
                        });
                        //----------------get the group
                        $("#roleList").combobox({    
                            url:'../AdminHome/GetGroupRoles',    
                            valueField:'Id',    
                            textField:'Name'   
                        });  


                        //增加组数据
                            $('#ddEdit').dialog({ 
                                            title: '修改信息',
                                            width: 400,
                                            height: 200,
                                            closed: false,
                                            cache: false,
                                            modal: true
                                        });
                        //--------------------------------
                        $("#btnEditSave").linkbutton({
                            onClick: function () {
                                $.ajax({
                                    url: '../AdminHome/EditGroup',
                                    type: 'post',
                                    data: {ehaiker_parameter: JSON.stringify({
                                        Account: $("#edusername").val(),
                                        AdministratorID: rows[0].AdministratorID,
                                       GroupId:$("#roleList").combobox("getValue")
                                        })
                                    },
                                    success: function (res) {
                                    $("#ddEdit").dialog('close');
                                    $("#AdminGrid").datagrid("reload");
                                        if (res.ErrorCode==0) {
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
             //编辑
            $("#btnEditPwd").linkbutton({
                onClick: function () {

                    var rows = $("#AdminGrid").datagrid("getSelections");
                    if (rows.length == 0 || rows.length > 1) {
                        $.messager.alert("提示", "请选择一行数据");
                    }
                    else {
                        
                        $("#username").textbox({
                            value: rows[0].Account
                        });
                        //增加组数据
                        $('#ddAdd').dialog({ 
                                        title: '修改密码',
                                        width: 400,
                                        height: 200,
                                        closed: false,
                                        cache: false,
                                        modal: true
                                    });
                      $("#btnEditSave").linkbutton({
                            onClick: function () {
                                $.ajax({
                                    url: '../AdminHome/EditPassword',
                                    type: 'post',
                                    data: {ehaiker_parameter: JSON.stringify({
                                        Account: $("#username").val(),
                                        AdministratorID: rows[0].AdministratorID,
                                       Password:$("#userpwd").Val()
                                        })
                                    },
                                    success: function (res) {
                                    $("#ddAdd").dialog('close');
                                    $("#AdminGrid").datagrid("reload");
                                        if (res.ErrorCode==0) {
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





            // 添加
            $("#btnAdd").linkbutton({
                onClick: function () {
                    $("#ddAdd").dialog({
                        width: 500,
                        height: 200,
                        title: "添加管理员",
                    });
                    $("#btnAdduser").linkbutton({
                        onClick: function () {
                            $.ajax({
                                url: '../AdminHome/AddNew',
                                type: 'post',
                                data: { ehaiker_parameter: JSON.stringify(
                                { c: "Index",
                                    fun: "AddNew",
                                    Account: $("#username").val(),
                                    Password:$("#userpwd").val()
                                    })
                                 },
                                 dataType: "json",
                                success: function (res) {
                                    $("#ddAdd").dialog('close');
                                    $("#AdminGrid").datagrid("reload");
                                    if (res == 1) {
                                    
                                        $.messager.alert("提示", "添加成功！");
                                        
                                    }
                                    else {
                                        $.messager.alert("提示", "添加失败！");
                                    }
                                }
                            });
                            
                        }
                    });
                }
            })

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
        url: "../AdminHome/Index",
        type: "post",
        dataType: "json",
        success: function (data) {
            $("#AdminGrid").datagrid("loadData", data);  //动态取数据
        }
    });
    $('#AdminGrid').datagrid({
        url: '/AdminHome/Index',
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
        { title: "操作", field: 'AdministratorID', width: 100, formatter: function (value, row, index) {
            return '<a href="#" name="opera" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="ResetPassword('+value+',\''+ row.Account +'\')">重置密码</a>';
        }
        }
    ]],
    toolbar: "#tool",
    onLoadSuccess:function(data){  
        $("a[name='opera']").linkbutton({text:'重置密码',plain:true,iconCls:'icon-remove'});  
        },
    });
    //------------------------------------
    
    
   
   
    //---------------------------------------------

});