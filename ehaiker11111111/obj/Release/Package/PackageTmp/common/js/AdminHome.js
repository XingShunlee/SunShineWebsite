


//判断是否为顶层窗口
(function () {
    if (self != top) {
        top.location.href = "../AdminLogin/Index";
    }
})();
$(function () {
    //---
    $('#mainTab').tabs({
        onBeforeClose: function (title) {
            return confirm('您确认想要关闭 ' + title);
        }

    });
  
    //--增加tab
    function addTabw(title, table_id, target_url) {
        if ($('#mainTab').tabs('exists', title)) {
            var currentTab = $('#mainTab').tabs('getSelected');
            var url = $(currentTab.panel('options')).attr('href');
            $('#mainTab').tabs('update', {
                tab: currentTab,
                options: {
                    href: url
                }
            });
            currentTab.panel('refresh');
            $("#mainTab").tabs("select", title);
            return;
        }
        var content = '<div style="width:100%;height:100%;overflow:hidden;"><iframe src=' + target_url + ' name=' + table_id + ' id=' + table_id + ' style="width:100%;height:100%;overflow:hidden;scrolling=auto"></iframe></div>';

        $('#mainTab').tabs('add', {//不存在，则添加一个
            title: title,
            closable: true,
            content: content,
            iconCls: 'icon-reload'
        });
       
    }
    $('#ManagerInfo').bind('click', function (event) {
        addTabw($('#ManagerInfo').linkbutton().text(), 'fggff', '../AdminHome/ManagerInfo');
    });
    ///MemberInfo
    $('#MemberInfo').bind('click', function (event) {
        addTabw($('#MemberInfo').linkbutton().text(), 'fggff', '../AdminHome/MemberInfo');
    });
    // GameListOnLine
    $('#GameListOnLine').bind('click', function (event) {
        addTabw($('#GameListOnLine').linkbutton().text(), 'fggff', '../AdminHome/GameItemManage');
    });
    //------------------------------------
    $('#ReleaseNews').bind('click', function (event) {
        addTabw($('#ReleaseNews').linkbutton().text(), 'fggff', '../NewsCenter/Add');
    });
    $('#newsManager').bind('click', function (event) {
        addTabw($('#newsManager').linkbutton().text(), 'MainContent', '../NewsCenter/ShowNews');
    });
    //---------------------------------------------

    $('#PayBillInfo').bind('click', function (event) {
        addTabw($('#PayBillInfo').linkbutton().text(), 'MainContent', '../PayCenter');
    });

});