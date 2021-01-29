$(function(){             
    addDataWin = $('#addData-window').window({                    
        href:'${basePath}/page/marketPlat2/addData/addData.jsp?workId=${workId}year=${year}&month=${month}   &quarter=${quarter}&businessType=${businessType}&type=${type}',  
    title:'添加数据',  
    left:'100px',  
    top:'70px',  
    closed: true,  
    modal: false,  
    cache: false,  
    minimizable:false,  
    maximizable:false,  
    collapsible:false,  
    shadow: false  
    });  
//添加数据弹出窗口  
    function addData(){  
        addDataWin.window('open');                       
    }  
}  
//这里只插入了一个datagrid的部分代码，就是点击这个按钮，就会新调用addData()方法；  
{  
    id:'add',  
    text:'新增',  
    iconCls:'icon-add',  
  handler:addData  
}  
 //关闭弹出窗口  
function closeWin(myWin) {  
    myWin.window('close');  }



    });
