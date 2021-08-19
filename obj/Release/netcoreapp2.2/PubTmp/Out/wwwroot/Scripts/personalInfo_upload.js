
$(function () {

    //文件大小
    //获取input图片宽高和大小
    function getImageWidthAndHeight(id, callback) {
        var _URL = window.URL || window.webkitURL;

        var file, img;
        file = document.getElementById(id).files[0];
        if (file != null) {
            img = new Image();
            img.onload = function () {
                callback && callback({ "width": this.width, "height": this.height, "filesize": file.size });
            };
            img.src = _URL.createObjectURL(file);
        }
    }

    //
    $(".action-btn").on("click", function (e) {
        e.stopPropagation();
        //验证文件大小：
        var upfile = document.getElementById('fileToUpload').files[0];
        if (typeof (upfile) == "undefined" || typeof (upfile.size) == "undefined") {
            new $Msg({
                content: "请选择文件\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return;
        }
        if (upfile.size > 20 * 1024 * 1024) {
            new $Msg({
                content: "文件大小超过20M\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return;
        }
        var filename = upfile.name;
        var ipos = filename.lastIndexOf('.');
        if (ipos == -1) {
            new $Msg({
                content: "请选择文件\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return;
        }
        var fext = filename.substring(ipos + 1, filename.length).toLowerCase();
        if (fext != "jpg" &&
            fext != "png" &&
            fext != "gif"
            ) {
            new $Msg({
                content: "只能上传JPG|PNG|GIF格式文件\r\n",
                title: "提示",
                type: "success",
                footer: true,
                header: true,
                btnName: ["确定"]
            })
            return;
        }
        /*文件大小*/
        getImageWidthAndHeight('fileToUpload', function (obj) {
            if (obj.width != 200 || obj.height != 200) {
                new $Msg({
                    content: "图片格式必须是54*54px\r\n",
                    title: "提示",
                    type: "success",
                    footer: true,
                    header: true,
                    btnName: ["确定"]
                })
            }
            else {
                var formData = new FormData();
                formData.append("files", upfile);
                $.ajax(
                { url: "../personal/UploadFile",
                    type: "post",
                    data: formData,
                    contentType: false, //必须false才会自动加上正确的Content-Type
                    processData: false, //必须false才会避开JQUERY对formdata的默认处理
                    success: function (o) {
                        if (o.SuccessCode == "0") {
                            $('#imgshow').attr('src', o.msg);
                        }
                        else {
                            new $Msg({
                                content: o.msg,
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
        });

        //




    });


});