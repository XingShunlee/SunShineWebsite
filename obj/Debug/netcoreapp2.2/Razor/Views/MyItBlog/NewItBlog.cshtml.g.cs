#pragma checksum "D:\CodeStore\ehaikerv202010\Views\MyItBlog\NewItBlog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3a87963ab80acdfedf3cc374157ef4fd6fdc55a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyItBlog_NewItBlog), @"mvc.1.0.view", @"/Views/MyItBlog/NewItBlog.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MyItBlog/NewItBlog.cshtml", typeof(AspNetCore.Views_MyItBlog_NewItBlog))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3a87963ab80acdfedf3cc374157ef4fd6fdc55a", @"/Views/MyItBlog/NewItBlog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_MyItBlog_NewItBlog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaikerv202010.Models.ItBlogModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\CodeStore\ehaikerv202010\Views\MyItBlog\NewItBlog.cshtml"
  
    ViewData["Title"] = "发布新博客";
    var types = ViewBag.Types as IEnumerable<SelectListItem>;
    Layout = "_MemberShipLayout";

#line default
#line hidden
            BeginContext(183, 3889, true);
            WriteLiteral(@"<header>
   
    <link rel=""stylesheet"" href=""../css/personal/home-page.min.css"" /> <!--主体样式应用-->
    <script src=""../../plugins/tinymce/tinymce.min.js""></script>
    <link rel=""stylesheet"" href=""../css/CommonDialog.css"" />
    <script type=""text/javascript"" src=""../js/CommonDialog.js""></script>
    <script>
        tinymce.init({
            selector: '#idContent',
            language: 'zh_CN',
            directionality: 'ltr',
            browser_spellcheck: true,
            contextmenu: false,
            plugins: [
                ""advlist autolink lists link image charmap print preview anchor"",
                ""searchreplace visualblocks code fullscreen"",
                ""insertdatetime media table contextmenu paste imagetools wordcount"",
                ""code""
            ],
            toolbar: ""insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | code"",

        });
    </script>
</hea");
            WriteLiteral(@"der>
<div style=""margin-top:10px;margin-bottom:10px;"" id=""app"">
    <div class=""box-wrap"">
        <div id=""imgDlg"" class=""popImgDialog"" style=""display: none; position: absolute; z-index: 50000;"">
            <a href=""javascript:void(0);"" class=""close-a""></a>
            <ul class=""popImgWrap""></ul>
            <input type=""button"" name=""imgprev"" id=""imgprev"" v-on:click=""PrevPage();"" :class=""isprevDisable"" value=""上一页"" />
            <input type=""button"" name=""imgnext"" id=""imgnext"" v-on:click=""NextPage();"" :class=""isNextDisable"" value=""下一页"" />
        </div>
        <table class=""table table-hover table-success list-group col-md-12 col-xs-12 col-sm-12"">
            <tbody>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td style=""border:2px dotted green;"" class=""data-col"">文章名称:</td>
                    <td class=""data-col"" colspan=""3""> <input type=""text"" id=""stragetitle"" style=""width:100%;"" /></td>
                </tr>
                <tr class=""data-ro");
            WriteLiteral(@"w"" style=""border:1px dotted red;"">
                    <td class=""data-col"">著作原作者:</td>
                    <td class=""data-col"" colspan=""3""> <input type=""text"" id=""stragereferauthor"" style=""width:100%;"" /></td>
                </tr>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td class=""data-col"">等级(0-10):</td>
                    <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""stragerank"" style=""width:100%;"" /></td>
                </tr>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td class=""data-col"">推荐系数(1-100):</td>
                    <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""stragetoplevel"" style=""width:100%;"" /></td>
                </tr>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td class=""data-col"">文章引用地址:</td>
                    <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""ReferUri"" style=""width:100");
            WriteLiteral(@"%;"" /></td>
                </tr>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td class=""data-col"">关键字:</td>
                    <td class=""data-col"" colspan=""2""> <input type=""text"" id=""gamekeywords"" style=""width:100%;"" /></td>
                </tr>
               
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td class=""data-col"" colspan=""2"">详细介绍:</td>
                </tr>
                <tr class=""data-row"" style=""border:1px dotted red;"">
                    <td style=""width:100%;"" class=""data-col"" colspan=""4""> <textarea name=""DIVCSS5"" cols=""3"" rows=""4"" style=""width:100%;"" id=""idContent""></textarea></td>
                </tr>
                <tr>
                    <td><span class=""Title"">文章类型：</span>");
            EndContext();
            BeginContext(4073, 100, false);
#line 74 "D:\CodeStore\ehaikerv202010\Views\MyItBlog\NewItBlog.cshtml"
                                                   Write(Html.DropDownList("Types", ViewData["ypes"] as SelectList, "--请选择--", new { @class = "SelectList" }));

#line default
#line hidden
            EndContext();
            BeginContext(4173, 112, true);
            WriteLiteral("</td>\r\n                    <td><span class=\"login-btn\"><a id=\"personal-shiwan-add-btn\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 4285, "\"", 4293, 0);
            EndWriteAttribute();
            BeginContext(4294, 8803, true);
            WriteLiteral(@" v-on:click=""DoNewGameStrage();"">新    增</a></span></td>

                </tr>
            </tbody>
        </table>
        
        <hr />
    </div>
</div>
<script charset=""utf-8"">
    (function () {
        //----------------------------
        var datas = [];
        var app = new Vue({

            el: '#app',
            data: {
                animating: false,
                selectPageSize: 10,
                current_index: 0,
                totalitems: 0,
                previous_index: 0,
                imgdata: [],
                isprevDisable: { disabled: true },
                isNextDisable: { disabled: false },
                imgctrl: '',
                stragerank: '10',
                stragetoplevel: '100',
                ReferUri: '',
                stragekeywords: '',

                posts: {
                },

            },
            methods: {
                PrevPage: function () {
                    if (this.animating === true)
    ");
            WriteLiteral(@"                    return false;

                    if (this.current_index - 4 <= 0) {
                        this.isprevDisable.disabled = true;
                        this.isNextDisable.disabled = false;
                    }
                    else {
                        this.isNextDisable.disabled = false;

                    }
                    this.animating = true;
                    var that = this;
                    //取得下一页的开始索引
                    this.current_index = this.current_index - 4;
                    if (this.current_index < 0) {
                        this.current_index = 0;
                    }
                    $("".popImgWrap li"").remove();
                    $.each(that.imgdata, function (i, item) {
                        if (that.current_index <= i && i < that.current_index + 4) {
                            var listr = '<li><a class=""img-a"" href=""javascript:void(0);""><img class=""img"" src=""' + item +
                                '"" alt="" """);
            WriteLiteral(@" width=200px height=200px  /></a></li>';
                            $("".popImgWrap"").append(listr);  //动态取数据
                        }
                        else if (that.current_index + 4 <= i) {


                            return false;
                        }
                    });
                    //选择图片时
                    $("".img-a"").on(""click"", function (o) {
                        o.stopPropagation();

                         $(that.imgctrl).val($(this).children('.img').attr('src'));
                        //
                        $(""#imgDlg"").css('display', ""none"");
                    });
                    if (this.current_index < 0) {
                        this.current_index = 0;
                        this.isprevDisable.disabled = true;
                        this.isNextDisable.disabled = false;
                    }
                    this.animating = false;
                },
                NextPage: function () {

                    if (this.a");
            WriteLiteral(@"nimating === true)
                        return false;

                    this.animating = true;
                    var that = this;
                    $("".popImgWrap li"").remove();
                    //取得下一页的开始索引
                    this.current_index = this.current_index + 4;
                    if (this.current_index > this.totalitems) {
                        this.current_index = this.current_index - 4;
                    }
                    $.each(that.imgdata, function (i, item) {
                        if (that.current_index <= i && i < that.current_index + 4) {
                            var listr = '<li><a class=""img-a"" href=""javascript:void(0);""><img class=""img"" src=""' + item +
                                '"" alt="" "" width=200px height=200px  /></a></li>';
                            $("".popImgWrap"").append(listr);  //动态取数据
                        }
                        else if (i >= that.current_index + 4) {

                            return false;
         ");
            WriteLiteral(@"               }
                    });
                    //选择图片时
                    $("".img-a"").on(""click"", function (o) {
                        o.stopPropagation();
                        $(that.imgctrl).val($(this).children('.img').attr('src'));
                        //
                        $(""#imgDlg"").css('display', ""none"");
                    });
                    this.animating = false;
                    this.isprevDisable.disabled = false;
                    if (this.current_index >= this.totalitems) {

                        this.isNextDisable.disabled = true;
                        return;
                    }
                },
                GetGameImages: function (e) {
                    $("".popImgWrap li"").remove();
                    var that = this;
                    this.imgctrl = '#' + e;
                    $.ajax({
                        url: ""../MyItBlog/GetDescImgs"",
                        type: ""post"",
                        dataType");
            WriteLiteral(@": ""json"",
                        success: function (arrdata) {
                            if (arrdata != null) {
                                that.totalitems = arrdata.total;
                                that.imgdata = arrdata.data;
                                that.current_index = 0;
                                that.animating = false;
                                $.each(that.imgdata, function (i, item) {
                                    if (i > that.current_index + 3)
                                        return false;
                                    var listr = '<li><a class=""img-a"" href=""javascript:void(0);""><img class=""img"" src=""' + item +
                                        '"" alt="" "" width=200px height=200px  /></a></li>';
                                    $("".popImgWrap"").append(listr);  //动态取数据
                                });
                                //修改弹出位置
                                $("".popImgDialog"").css('display', ""block"");
        ");
            WriteLiteral(@"                        //选择图片时
                                $("".img-a"").on(""click"", function (o) {
                                    o.stopPropagation();

                                    $(that.imgctrl).val($(this).children('.img').attr('src'));
                                    $(""#imgDlg"").css('display', ""none"");
                                });
                                that.isprevDisable.disabled = true;
                                that.isNextDisable.disabled = false;

                                if (that.current_index + 4 <= that.totalitems) {
                                    that.isNextDisable.disabled = true;

                                }
                            }

                        }
                    });
                },
                DoNewGameStrage: function () {
                    $.ajax(
                        {
                            url: ""/MyItBlog/AddNewItBlog"",
                            type: ""post"",
       ");
            WriteLiteral(@"                     data: {
                                Item_parameter: JSON.stringify(
                                    {
                                        Title: $(""#stragetitle"").val(),
                                        ReferAthor: $(""#stragereferauthor"").val(),
                                        ReferUri: this.ReferUri,
                                        Rank: this.stragerank,
                                        toplevel: this.stragetoplevel,
                                        Content: tinyMCE.activeEditor.getContent(),
                                        blogtype: $(""#Types"").val(),

                                    })
                            },
                            dataType: ""json"",
                            success: function (o) {
                                if (o.ErrorCode == ""0"") {
                                    alert(o.msg);

                                }
                                else {
               ");
            WriteLiteral(@"                     alert(o.msg);
                                }
                            }
                            ,
                            error: function (o) {
                                alert(""添加失败1"");
                            }

                        }); //ajax
                },
            },
            mounted: function () {

                $("".close-a"").on(""click"", function (o) {
                    o.stopPropagation();
                    $(""#imgDlg"").css('display', ""none"");
                });


            }
        })

    })()
</script>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaikerv202010.Models.ItBlogModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
