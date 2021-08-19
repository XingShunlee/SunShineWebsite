$(function () {
    //---获取Uri
    $(".datagrid-pager-select").change(function () {
        var usrUri = $("#idpagerUri").val();
        var p1 = $(this).children('option:selected').val(); //这就是selected的值  
        window.location.href = usrUri + "?pageindex=1&pagesize=" + p1;
    });
    //-------------end
});

