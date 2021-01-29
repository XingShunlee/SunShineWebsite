//公共函数：可以转变为通用函数
var g_imgdes_col_index = 0;
var current_index, totalitems, previous_index; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches
var imgdata;
		function editrow(index){
			$('#UserGrid').datagrid('beginEdit', index);
          $("a[name='opera']").linkbutton({plain:true,iconCls:'icon-remove'}); 
        $("a[name='opdel']").linkbutton({plain:true,iconCls:'icon-remove'});  
		}
		function deleterow(index){
			$.messager.confirm('确认','是否删除，删除后不能恢复?',function(r){
			    if (r) {
			        //
			        var row = $('#UserGrid').datagrid('getData').rows[index];
			        $.ajax(
                        { url: "../AdminHome/DelGameItem",
                          type: "post",
                          data: { ehaiker_parameter: JSON.stringify(row)
                            },
                          dataType: "json",
                            success: function (o) {
                                if (o > 0) {
                                    $('#UserGrid').datagrid('deleteRow', index);
                                }
                                else {
                                    new $Msg({
                                        content: "条目更新失败\r\n",
                                        title: "提示",
                                        type: "success",
                                        footer: true,
                                        header: true,
                                        btnName: ["确定"]
                                    })
                                }
                            },
                        error: function (o) {
                            new $Msg({
                                content: "条目更新失败\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })
                        }

                       }); //ajax
					
				}
        $("a[name='opera']").linkbutton({plain:true,iconCls:'icon-remove'}); 
        $("a[name='opdel']").linkbutton({plain:true,iconCls:'icon-remove'});  
			});
		}
		function saverow(index){
			$('#UserGrid').datagrid('endEdit', index);
            $("a[name='opera']").linkbutton({plain:true,iconCls:'icon-remove'}); 
             $("a[name='opdel']").linkbutton({plain:true,iconCls:'icon-remove'});  
           var row =$('#UserGrid').datagrid('getData').rows[index];
            //保存到数据库
             $.ajax(
                { url: "../AdminHome/GameItemEdit",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(row)
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o > 0) {
                            new $Msg({
                                content: "条目更新成功\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })

                        }
                        else {
                            new $Msg({
                                content: "条目更新失败\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })
                        }
                    }
                     ,
                    error: function (o) {
                        new $Msg({
                            content: "条目更新失败\r\n",
                            title: "提示",
                            type: "success",
                            footer: true,
                            header: true,
                            btnName: ["确定"]
                        })
                    }

                }); //ajax
		}
		function cancelrow(index){
			$('#UserGrid').datagrid('cancelEdit', index);
            $("a[name='opera']").linkbutton({plain:true,iconCls:'icon-remove'}); 
        $("a[name='opdel']").linkbutton({plain:true,iconCls:'icon-remove'});
    }
    //--增加一个条目
    function insert() {
        var row = $('#UserGrid').datagrid('getSelected');
        if (row) {
            var index = $('#UserGrid').datagrid('getRowIndex', row);
        } else {
            index = 0;
        }
        //后台增加一项
        //ajax提交发送请求
        var newItemName = "new_" + Date.parse(new Date);
        var newRow ={
            ItemName: newItemName,
        Gametype:1
        };
        $.ajax(
                { url: "../AdminHome/AddGameItem",
                    type: "post",
                    data: { ehaiker_parameter: JSON.stringify(newRow)
                    },
                    dataType: "json",
                    success: function (o) {
                        if (o > 0) {
                            new $Msg({
                                content: "增加上线条目成功\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            })
                            newRow.ItemID = o;
                        }
                        else {
                            new $Msg({
                                content: "增加上线条目失败\r\n",
                                title: "提示",
                                type: "success",
                                footer: true,
                                header: true,
                                btnName: ["确定"]
                            });
                            return;
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        new $Msg({
                            content: "增加上线条目失败\r\n",
                            title: "提示",
                            type: "success",
                            footer: true,
                            header: true,
                            btnName: ["确定"]
                        });
                        return;
                    }
                });    //ajax
        $('#UserGrid').datagrid('insertRow', {
            index: index,
            row: newRow
        });
        //重新加载数据
        $('#UserGrid').datagrid('selectRow', index);
        //进入编辑模式
        editrow(index);
    }


    $(function () {
        //---
        $('#Usertb').textbox({
            buttonText: '搜索',
            iconCls: 'icon-search',
            iconAlign: 'left',
            onClickButton: function () {
                $('#UserGrid').datagrid({
                    queryParams: {
                        name: $("#Usertb").val(),
                        type: -1
                    }
                });
            }
        });
        //删除

        //编辑


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

        //----------------------------------------------
        $('#UserGrid').datagrid({
            url: '/AdminHome/GetGameListInfo',
            pagination: true,        //设置显示分页
            singleSelect: true,
            idField: 'ItemId',
            fitColumns: false,
            columns: [[
        { field: 'ItemName', title: '项目名称', width: 200,
            editor: 'text'
        },
        { field: 'ImgDescUri', title: '封面图像', width: 200,
            editor: 'text'
        },
        { field: 'supporter', title: '(服务商)', width: 200,
            editor: 'text'
        },
        { field: 'producer', title: '(制造商)', width: 200,
            editor: 'text'
         },
         {
                    field: 'resourcefrom', title: '来源', width: 200,
                    editor: 'text'
                },
                {
                    field: 'MineTime', title: '采集时间', width: 200,
                    formatter: function (value, row, index) {
                        if (value != null) {
                            return changeDateFormat(value);
                        } else {
                            return value;
                        }
                    },
                    editor: 'datetimebox'
                },
        { field: 'targetUri', title: '目标URL', width: 200,
            editor: 'text'
        },
        { field: 'StartTime', title: '上线时间', width: 100,
            formatter: function (value, row, index) {
                if (value != null) {
                    return changeDateFormat(value);
                } else {
                    return value;
                }
            },
            editor: 'datetimebox'
        },
        { field: 'EndTime', title: '下线时间', width: 100,
            formatter: function (value, row, index) {
                if (value != null) {
                    return changeDateFormat(value);
                } else {
                    return value;
                }
            },
            editor: 'datetimebox'
        },
        { field: 'TopLevel', title: '推荐等级', width: 100,
            editor: 'text'
        },
        { field: 'grade', title: '评分', width: 100,
            editor: {
                type: 'combobox',
                options: {
                    valueField: 'text',
                    textField: 'text'
                }
            }
        },
        
        { field: 'Gametype', title: '游戏类型', width: 100,
            editor: {
                type: 'combobox',
                options: {
                    valueField: 'GameId',
                    textField: 'Name'
                }
            }
        },
        { title: "操作", field: 'ItemID', width: 150, formatter:
            function (value, row, index) {
                var jsonstr = JSON.stringify(row).replace(/\"/g, "'");
                if (row.editing) {
                    var s = '<a href="javascript:void(0)" name="opera" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="saverow(' +
                    index + ',' + jsonstr + ')">保存</a> ';
                    var c = '<a href="javascript:void(0)" name="opdel" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="cancelrow(' +
                    index + ',' + jsonstr + ')">取消</a>';
                    return s + c;
                } else {
                    var e = '<a href="javascript:void(0)" name="opera" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="editrow(' +
                    index + ',' + jsonstr + ')">编辑</a> ';
                    var d = '<a href="javascript:void(0)" name="opdel" class="easyui-linkbutton" data-options="plain:true,iconCls:\'icon-add\'" onclick="deleterow(' +
                    index + ',' + jsonstr + ')">删除</a>';
                    return e + d;
                }
            }
        }
    ]],
            toolbar: "#Usertool",
            onLoadSuccess: function (data) {
                $("a[name='opera']").linkbutton({ plain: true, iconCls: 'icon-remove' });
                $("a[name='opdel']").linkbutton({ plain: true, iconCls: 'icon-remove' });
            },
            onEndEdit: function (index, row) {
                var ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'Gametype'
                });
                row.Gametype = $(ed.target).combobox('getValue');
            },
            onBeforeEdit: function (index, row) {
                row.editing = true;

                $(this).datagrid('refreshRow', index);
            },
            onAfterEdit: function (index, row) {
                row.editing = false;
                $(this).datagrid('refreshRow', index);
            },
            onCancelEdit: function (index, row) {
                row.editing = false;
                $(".popImgDialog").css('display', "none");
                $(this).datagrid('refreshRow', index);
            },
            onBeginEdit: function (index, row) {
                var ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'Gametype'
                });
                //先从后端获取数据
                $.ajax({
                    url: "../AdminHome/GetGameType",
                    type: "post",
                    dataType: "json",
                    success: function (arrdata) {
                        $(ed.target).combobox("loadData", arrdata);
                    }
                });
                //添加评分
                var grade_ed = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'grade'
                });
               
                var gradeData = new Array();//创建空数组
                gradeData.push({'Id':1,'text':'1.0'});
                gradeData.push({ 'Id':2, 'text':'2.0'});
                gradeData.push({ 'Id':3, 'text':'3.0'});
                gradeData.push({ 'Id':4, 'text':'4.0'});
                gradeData.push({ 'Id':5, 'text':'5.0'});
                $(grade_ed.target).combobox("loadData", gradeData);
                //-----------------------添加点击事件
                var imgtx = $(this).datagrid('getEditor', {
                    index: index,
                    field: 'ImgDescUri'
                });
                $(imgtx.target).val(' ');
                //绑定事件
                $(imgtx.target).bind("click", function () {
                    g_imgdes_col_index = index;
                    $(".popImgWrap li").remove();
                    //
                    //ajax获取图片GetDescImgs()
                    $.ajax({
                        url: "../AdminHome/GetDescImgs",
                        type: "post",
                        dataType: "json",
                        success: function (arrdata) {
                            if (arrdata != null) {
                                totalitems = arrdata.total;
                                imgdata = arrdata.data;
                                current_index = 0;
                                $.each(imgdata, function (i, item) {
                                    if (i >= current_index + 2)
                                        return false;
                                    var listr = '<li><a class="img-a" href="javascript:void(0);"><img class="img" src="' + item +
                    '" alt=" " width=200px height=200px  /></a></li>';
                                    $(".popImgWrap").append(listr);  //动态取数据
                                });
                                current_index = 2;
                                //修改弹出位置
                                $(".popImgDialog").css('display', "block");
                                //选择图片时
                                $(".img-a").on("click", function (o) {
                                    o.stopPropagation();
                                    var imgtx = $('#UserGrid').datagrid('getEditor', {
                                        index: g_imgdes_col_index,
                                        field: 'ImgDescUri'
                                    });
                                    $(imgtx.target).val($(this).children('.img').attr('src'));
                                    $("#imgDlg").css('display', "none");
                                });
                            }

                        }
                    });

                })
            }
        });
        //------------------------------------添加新项目
        $("#btnItemAdd").on("click", function (o) {
            o.stopPropagation();
            insert();
        });

        $("#imgnext").click(function () {
            if (animating)
                return false;
            if (current_index+2 >= totalitems) {
                return;
            }
            animating = true;
            $(".popImgWrap li").remove();
            $.each(imgdata, function (i, item) {
                var listr = '<li><a class="img-a" href="javascript:void(0);"><img class="img" src="' + item +
                    '" alt=" " width=200px height=200px  /></a></li>';
                if (current_index < i && current_index + 2 > i) {
                    $(".popImgWrap").append(listr);  //动态取数据
                }
                else if (current_index + 2 < i) {
                    return false;
                }
            });
            //选择图片时
            $(".img-a").on("click", function (o) {
                o.stopPropagation();
                var imgtx = $('#UserGrid').datagrid('getEditor', {
                    index: g_imgdes_col_index,
                    field: 'ImgDescUri'
                });
                $(imgtx.target).val($(this).children('.img').attr('src'));
                $("#imgDlg").css('display', "none");
            });
            current_index = current_index + 2;
            animating = false;

        });

        $("#imgprev").click(function () {
            if (animating) return false;
            if (current_index-2 <= 0)
                return;
            animating = true;
            $(".popImgWrap li").remove();
            //

            $.each(imgdata, function (i, item) {
                var listr = '<li><a class="img-a" href="javascript:void(0);"><img class="img" src="' + item +
                    '" alt=" " width=200px height=200px /></a></li>';
                if (current_index < i && current_index + 2 > i) {
                    $(".popImgWrap").append(listr);  //动态取数据
                }
                else if (current_index + 2 < i) {
                    return false;
                }
            });
            //选择图片时
            $(".img-a").on("click", function (o) {
                o.stopPropagation();
                var imgtx = $('#UserGrid').datagrid('getEditor', {
                    index: g_imgdes_col_index,
                    field: 'ImgDescUri'
                });
                $(imgtx.target).val($(this).children('.img').attr('src'));
                $("#imgDlg").css('display', "none");
            });
            current_index = current_index - 2;
            animating = false;


        });
        //---------------------------------------------

    });