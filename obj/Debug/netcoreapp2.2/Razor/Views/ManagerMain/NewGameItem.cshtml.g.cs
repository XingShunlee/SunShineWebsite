#pragma checksum "D:\CodeStore\ehaikerv202010\Views\ManagerMain\NewGameItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "250a41462203fa37becde68a683481458745f4aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerMain_NewGameItem), @"mvc.1.0.view", @"/Views/ManagerMain/NewGameItem.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManagerMain/NewGameItem.cshtml", typeof(AspNetCore.Views_ManagerMain_NewGameItem))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"250a41462203fa37becde68a683481458745f4aa", @"/Views/ManagerMain/NewGameItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagerMain_NewGameItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaiker.Models.GameModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner1.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("First slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner2.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Second slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner3.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Third slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\CodeStore\ehaikerv202010\Views\ManagerMain\NewGameItem.cshtml"
  
    ViewData["Title"] = "上线游戏";
    Layout = "_ManagerTop";

#line default
#line hidden
            BeginContext(102, 948, true);
            WriteLiteral(@"
<link rel=""stylesheet"" type=""text/css"" href=""../css/gameitemlist/GamelistItemMgr.css"" />
<div class=""container mainPage"" id=""app"">
    <!--轮播行-->
    <div id=""flashads"" class=""row"">
        <div class=""col-md-12 col-lg-12"" style=""padding:0;"">
            <div id=""myCarousel"" class=""carousel slide col-md-12 col-lg-12"" style=""height:200px; padding:0;overflow:hidden;"" data-ride=""carousel"" data-wrap=""true"" data-interval=""2000"">
                <!-- 轮播（Carousel）指标 -->
                <ol class=""carousel-indicators"">
                    <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
                    <li data-target=""#myCarousel"" data-slide-to=""1""></li>
                    <li data-target=""#myCarousel"" data-slide-to=""2""></li>
                </ol>
                <!-- 轮播（Carousel）项目 -->
                <div class=""carousel-inner"">
                    <div class=""item active"">
                        ");
            EndContext();
            BeginContext(1050, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "250a41462203fa37becde68a683481458745f4aa6601", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1100, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1194, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "250a41462203fa37becde68a683481458745f4aa7954", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1245, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1339, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "250a41462203fa37becde68a683481458745f4aa9307", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1389, 5243, true);
            WriteLiteral(@"
                    </div>
                </div>
                <!-- 轮播（Carousel）导航 -->
                <a class=""left carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
                    <span class=""glyphicon glyphicon-chevron-left"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""right carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""next"">
                    <span class=""glyphicon glyphicon-chevron-right"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
    </div>
    <!--左边个人信息展示-->

    <div id=""app3"" class=""row"">

        <div id=""myTabContent1"" class=""tab-content col-md-12 col-xs-12 col-sm-12"" style=""min-height:300px; border:1px solid #e8e8e8;"">
            <div id=""imgDlg"" class=""popImgDialog"" style=""display: none; position: absolute; z-index: 50000;"">
                <a hre");
            WriteLiteral(@"f=""javascript:void(0);"" class=""close-a""></a>
                <ul class=""popImgWrap""></ul>
                <input type=""button"" name=""imgprev"" id=""imgprev"" v-on:click=""PrevPage();"" :class=""isprevDisable"" value=""上一页"" />
                <input type=""button"" name=""imgnext"" id=""imgnext"" v-on:click=""NextPage();"" :class=""isNextDisable"" value=""下一页"" />
            </div>
            <table class=""table table-hover table-success list-group col-md-12 col-xs-12 col-sm-12"">
                <tbody>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td style=""border:2px dotted green;"" class=""data-col"">游戏名称:</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" id=""gamename""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">运营商:</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" id=""game");
            WriteLiteral(@"supporter""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">著作所有者:</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" id=""gameproducer""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">游戏评分(0-10):</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""gamegrade""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">游戏推荐系数(1-100):</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""gameTopLevel"" style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
           ");
            WriteLiteral(@"             <td class=""data-col"">文章引用地址:</td>
                        <td class=""data-col"" colspan=""3""> <input type=""text"" v-model=""gameresourcefrom""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">游戏关键字:</td>
                        <td class=""data-col"" colspan=""2""> <input type=""text"" id=""gamekeywords""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">封面图片地址:</td>
                        <td class=""data-col"" colspan=""2""> <input type=""text"" name=""imgDesc"" id=""imgDesc""   style=""width:100%;"" /></td>
                        <td class=""data-col""><input type=""button"" v-on:click=""GetGameImages('imgDesc')"" value=""浏 览"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""d");
            WriteLiteral(@"ata-col"">封面图片地址(鼠标移入):</td>
                        <td class=""data-col"" colspan=""2""> <input type=""text"" name=""imgHover"" id=""imgHover""  style=""width:100%;"" /></td>
                        <td class=""data-col""><input type=""button"" v-on:click=""GetGameImages('imgHover')"" value=""浏 览"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"">游戏入口地址(互联网):</td>
                        <td class=""data-col"" colspan=""2""> <input type=""text"" id=""gametargetUri""  style=""width:100%;"" /></td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td class=""data-col"" colspan=""2"">简单介绍:</td>
                    </tr>
                    <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td style=""width:100%;"" class=""data-col"" colspan=""4""> <textarea name=""DIVCSS5"" cols=""3"" rows=""4"" style=""width:100%;"" id=""gameDescription""></textar");
            WriteLiteral("ea></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td><span class=\"Title\">游戏类型：</span>");
            EndContext();
            BeginContext(6633, 109, false);
#line 105 "D:\CodeStore\ehaikerv202010\Views\ManagerMain\NewGameItem.cshtml"
                                                       Write(Html.DropDownList("GameTypes", ViewData["GameTypes"] as SelectList, "--请选择--", new { @class = "SelectList" }));

#line default
#line hidden
            EndContext();
            BeginContext(6742, 116, true);
            WriteLiteral("</td>\r\n                        <td><span class=\"login-btn\"><a id=\"personal-shiwan-add-btn\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 6858, "\"", 6866, 0);
            EndWriteAttribute();
            BeginContext(6867, 11417, true);
            WriteLiteral(@" v-on:click=""DoNewGameItem();"">新    增</a></span></td>
                        
                    </tr>
                </tbody>
            </table>
        </div>

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
                    gamegrade: '',
                    gameTopLevel: '',
                    gameresourcefrom: '',
                    posts: {
                    },

                },
                methods: {
                  ");
            WriteLiteral(@"  PrevPage: function () {
                        if (this.animating === true)
                            return false;

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
        ");
            WriteLiteral(@"                        var listr = '<li><a class=""img-a"" href=""javascript:void(0);""><img class=""img"" src=""' + item +
                                    '"" alt="" "" width=200px height=200px  /></a></li>';
                                $("".popImgWrap"").append(listr);  //动态取数据
                            }
                            else if (that.current_index + 4 <= i) {


                                return false;
                            }
                        });
                        //选择图片时
                        $("".img-a"").on(""click"", function (o) {
                            o.stopPropagation();
                            if (that.imgctrl === ""#imgDesc"") {
                                that.gameDescUri = $(this).children('.img').attr('src');
                                $(that.imgctrl).val(that.gameDescUri);
                            }
                            else {
                               
                                that.gameHoverUri = $(this)");
            WriteLiteral(@".children('.img').attr('src');
                                $(that.imgctrl).val(that.gameHoverUri);
                            }
                            // $(that.imgctrl).val($(this).children('.img').attr('src'));
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

                        if (this.animating === true)
                            return false;

                        this.animating = true;
                        var that = this;
                        $("".popImgWrap li"").remove();
                        //取得下一页的开始索引
  ");
            WriteLiteral(@"                      this.current_index = this.current_index + 4;
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
                            }
                        });
                        //选择图片时
                        $("".img-a"").on(""click"", function (o) {
                            o.stop");
            WriteLiteral(@"Propagation();
                            if (that.imgctrl === ""#imgDesc"") {
                                that.gameDescUri = $(this).children('.img').attr('src');
                                $(that.imgctrl).val(that.gameDescUri);
                            }
                            else {
                                that.gameHoverUri = $(this).children('.img').attr('src');
                                $(that.imgctrl).val(that.gameHoverUri);
                            }
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
      ");
            WriteLiteral(@"                  $("".popImgWrap li"").remove();
                        var that = this;
                        this.imgctrl = '#' + e;
                        $.ajax({
                            url: ""../ManagerMain/GetDescImgs"",
                            type: ""post"",
                            dataType: ""json"",
                            success: function (arrdata) {
                                if (arrdata != null) {
                                    that.totalitems = arrdata.total;
                                    that.imgdata = arrdata.data;
                                    that.current_index = 0;
                                    that.animating = false;
                                    $.each(that.imgdata, function (i, item) {
                                        if (i > that.current_index + 3)
                                            return false;
                                        var listr = '<li><a class=""img-a"" href=""javascript:void(0);""><img class=");
            WriteLiteral(@"""img"" src=""' + item +
                                            '"" alt="" "" width=200px height=200px  /></a></li>';
                                        $("".popImgWrap"").append(listr);  //动态取数据
                                    });
                                    //修改弹出位置
                                    $("".popImgDialog"").css('display', ""block"");
                                    //选择图片时
                                    $("".img-a"").on(""click"", function (o) {
                                        o.stopPropagation();

                                        if (that.imgctrl === ""#imgDesc"") {
                                            that.gameDescUri = $(this).children('.img').attr('src');
                                            $(that.imgctrl).val(that.gameDescUri);
                                        }
                                        else {
                                            that.gameHoverUri = $(this).children('.img').attr('src');
              ");
            WriteLiteral(@"                              $(that.imgctrl).val(that.gameHoverUri);
                                        }
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
                    DoNewGameItem: function () {
                        var content = $(""#gameDescription"").val();
                        $.ajax(
                            {
                                url: ""/ManagerMain/AddNewGameItem"",
                                type: ""post"",
                   ");
            WriteLiteral(@"             data: {
                                    Item_parameter: JSON.stringify(
                                        {
                                            ItemName: $(""#gamename"").val(),
                                            supporter: $(""#gamesupporter"").val(),
                                            producer: $(""#gameproducer"").val(),
                                            grade: this.gamegrade,
                                            TopLevel: this.gameTopLevel,
                                            resourcefrom: this.gameresourcefrom,
                                            Keywords: $(""#gamekeywords"").val(),
                                            ImgDescUri: $(""#imgDesc"").val(),
                                            ImgHoverUri: $(""#imgHover"").val(),
                                            targetUri: $(""#gametargetUri"").val(),
                                            gameDescription: content.replace(/(?!<(img|p|span).*?>)<.*?");
            WriteLiteral(@">/g, """"),
                                            Gametype: $(""#GameTypes"").val(),

                                        })
                                },
                                dataType: ""json"",
                                success: function (o) {
                                    if (o.code == ""0"") {
                                        alert(""添加成功"");

                                    }
                                    else {
                                        alert(""添加失败"");
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
  ");
            WriteLiteral("                      $(\"#imgDlg\").css(\'display\', \"none\");\r\n                    });\r\n\r\n\r\n                }\r\n            })\r\n\r\n        })()\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaiker.Models.GameModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
