 
$(function () {
//---
            $('#Usertb').textbox({
                buttonText: '搜索',
                iconCls: 'icon-search',
                iconAlign: 'left',
                onClickButton: function () {
                    $('#PerGrid').datagrid({
                        queryParams: {
                            Account: $("#Usertb").val(),
                        }
                    });
                }
            });
            //保存权限
            $("#btnAdminSave").linkbutton({
                onClick: function () {
                    var rows = $("#PerGrid").datagrid("getChecked");
                    var ids = "";
                    if (rows.length == 0) {
                        $.messager.alert('警告', '没有选择任何项，该用户将受限');
                    }
                    else {
                        
                        
                        for (var i = 0; i < rows.length; i++) {
                            if (i < rows.length - 1) {
                                ids += rows[i].Id + ",";
                            }
                            else {
                                ids += rows[i].Id;
                            }
                            
                        }
                        $.messager.confirm('确认', '您确定修改吗？', function (r) {
                            if (r) {
                            var GroupId = $("#roleList").children('option:selected').val();
                            var selectedId =$('#adminList').children('option:selected').val();
                                $.ajax({
                                    url: '../AdminHome/SaveSitePermissions',
                                    type: 'post',
                                    data: {
                                        ids:ids,
                                        UserId:selectedId,
                                        groupid:GroupId
                                    },
                                    success: function (res) {
                                        if (res.changecnt > 0) {
                                        
                                            $.messager.alert('提示', '修改成功！');
                                           
                                        }
                                        else {
                                            $.messager.alert('提示', '修改失败！');
                                        }
                                    }

                                });
                            }
                        });  
                      

                    }
                }
            });
            ///////----权限分配

            //保存权限
            $("#btnAdminDisp").linkbutton({
                onClick: function () {
                    var rows = $("#PerGrid").datagrid("getChecked");
                    var ids = "";
                    if (rows.length == 0) {
                        $.messager.alert('警告', '没有选择任何项，该用户将受限');
                    }
                    else {
                        for (var i = 0; i < rows.length; i++) {
                            if (i < rows.length - 1) {
                                ids += rows[i].Id + ",";
                            }
                            else {
                                ids += rows[i].Id;
                            }
                            
                        }
                       }
                        $.messager.confirm('确认', '您确定分配吗？', function (r) {
                            if (r) {
                            var GroupId = $("#roleList").children('option:selected').val();;
                                $.ajax({
                                    url: '../AdminHome/SaveGroupPermissions',
                                    type: 'post',
                                    data: {
                                        ids:ids,
                                        groupid:GroupId
                                    },
                                    success: function (res) {
                                        if (res.changecnt > 0) {
                                        
                                            $.messager.alert('提示', '修改成功！');
                                           
                                        }
                                        else {
                                            $.messager.alert('提示', '修改失败！');
                                        }
                                    }

                                });
                            }
                        });  
                      

                }
            });
         /////////////////
           // 添加
            $("#btnAdminAdd").linkbutton({
                onClick: function () {
                    $("#ddGroupAdd").dialog({
                        width: 500,
                        height: 200,
                        title: "添加管理组",
                    });
                    $("#btnGronpSave").linkbutton({
                        onClick: function () {
                         var group =$("#groupname").val();
                            $.ajax({
                                url: '../AdminHome/AddNewAdminGroup',
                                type: 'post',
                                data: { newgroup: group ,
                                groupdesc:$("#groupdesc").val()
                                },
                                dataType: "json",
                                success: function (res) {
                                    $("#ddGroupAdd").dialog('close');
                                    
                                    if (res.Id>0) {
                                         var vpagesize = $("#PerGrid").datagrid('getPager').data("pagination").options.pageSize;
                                    //
                                     $.ajax({
                                                url: "../AdminHome/GetPermissions",
                                                type: "post",
                                                data:{"groupid":111111,page:0,rows:vpagesize},
                                                success: function (data) {
                                                    $("#PerGrid").datagrid("loadData", data);  //动态取数据
                                                    //增加一个
                                                    $("#roleList").append("<option value='"+res.Id+"'>"+group+" </option>");
                                                    $("#roleList").find("option[value='"+res.Id+"']").attr("selected",true);
                                                     $.messager.alert("提示", "添加成功！");
                                                }
                                            });
                                       
                                        
                                    }
                                    else {
                                        $.messager.alert("提示", "添加失败！");
                                    }
                                }
                            });
                            
                        }
                    });
                }
            });



             $("#btnAdminLoad").linkbutton({
                onClick: function () {
                      var vpagesize = $("#PerGrid").datagrid('getPager').data("pagination").options.pageSize;
                      $.ajax({
                            url: "../AdminHome/GetPermissions",
                            type: "post",
                            data:{"groupid":0,page:0,rows:vpagesize},
                            success: function (data) {
                                $("#PerGrid").datagrid("loadData", data);  //动态取数据
                                //取消打勾
                                 $("#PerGrid").datagrid("unselectAll");
                                //根据当前管理组打勾
                                 var p1 = $("#roleList").children('option:selected').val(); 
                                 $.ajax({
                                url: "../AdminHome/GetGroupPermissions",
                                type: "post",
                                data:{"groupid":p1},
                                success: function (data) {
                                    //动态标注数据
                                     var rows = $("#PerGrid").datagrid("getRows");
                                    if (rows.length == 0) {
                                        return;
                                    }
                                    else {
                            
                                    for (var i = 0; i < rows.length; i++) {
                                            if (data.Ids.indexOf(rows[i].Id)>-1) {
                                                $("#PerGrid").datagrid('checkRow', i);
                                            }
                                    }
                                    }
                                }
                                });
                                ////-----------------
                            }
                        });
                }
                });
           
//++++++++++++++++++++++++++++++++++++
    //-----------------------------------------------
  
    $('#PerGrid').datagrid({
        url: '/AdminHome/GetPermissions',
        pagination: true,        //设置显示分页
         pageSize: 10,     //每页显示条数
         pageList: [10, 20, 50, 100, 150, 200],   //每页显示条数供选项
        columns: [[
        { field:'check', title:"state", checkbox: true,width: 100},
        { field: 'Id', title: 'ID', width: 100 },
        { field: 'ControllerNo', title: '部门ID', width: 100},
        { field: 'ControllerName', title: '部门', width: 100},
        { field: 'Controller', title: '控制器', width: 100 },
        { field: 'ActionNo', title: '接口ID', width: 100 },
        { field: 'Action', title: 'Action', width: 100 },
        { field: 'ActionName', title: '接口', width: 100 },
        { field: 'isGet',title:'Get方法',width: 100 },
        { field: 'ShowInManagerBar', title: '显示到管理菜单', width: 150 }
        ]],
    toolbar: "#Usertool",
    onLoadSuccess:function(data){  
        //进行权限标注  
        //$("#PerGrid").datagrid("loadData", data);  //动态取数据
        }
    });
    //------------------------------------
    $("#roleList").on('change',function () {
        var p1 = $(this).children('option:selected').val(); 
         $.ajax({
        url: "../AdminHome/GetGroupPermissions",
        type: "post",
        data:{"groupid":p1},
        success: function (data) {
            //动态标注数据
             //取消打勾
             $("#PerGrid").datagrid("unselectAll");
             var rows = $("#PerGrid").datagrid("getRows");
            if (rows.length == 0) {
                return;
            }
            else {
                            
            for (var i = 0; i < rows.length; i++) {
                    if (data.Ids.indexOf(rows[i].Id)>-1) {
                        $("#PerGrid").datagrid('checkRow', i);
                    }
            }
            }
        }
        });
       //查询他的ps,进行check
       
    });
    //--------ID 改变
    $('#adminList').on('change',function(){
     var p1 = $(this).children('option:selected').val();
     //查询个人权限，并标注
             $.ajax({
                        url: "../AdminHome/GetSitePermissions",
                        type: "post",
                        data:{"userId":p1},
                        success: function (data) {
                         //取消打勾
                          $("#PerGrid").datagrid("unselectAll");
                            //动态标注数据
                             var rows = $("#PerGrid").datagrid("getRows");
                            if (rows.length == 0) {
                                $.messager.alert('警告', '请选择删除的数据！');
                            }
                            else {
                            
                                    for (var i = 0; i < rows.length; i++) {
                                           if (data.Ids.indexOf(rows[i].Id)>-1) {
                                                $("#PerGrid").datagrid('checkRow', i);
                                            }
                                            }
                                }
                            //-----
                        }
                    });
    });
    
   
    //---------------------------------------------

});