#pragma checksum "E:\CodeStore\ehaikerv202010\Views\ManagerMain\ItBlogManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17106e51c9697038986b78f7543b29e85d183c47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerMain_ItBlogManage), @"mvc.1.0.view", @"/Views/ManagerMain/ItBlogManage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManagerMain/ItBlogManage.cshtml", typeof(AspNetCore.Views_ManagerMain_ItBlogManage))]
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
#line 1 "E:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "E:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17106e51c9697038986b78f7543b29e85d183c47", @"/Views/ManagerMain/ItBlogManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagerMain_ItBlogManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\CodeStore\ehaikerv202010\Views\ManagerMain\ItBlogManage.cshtml"
  
    ViewData["Title"] = "文章管理";
    Layout = "_ManagerTop";

#line default
#line hidden
            BeginContext(71, 869, true);
            WriteLiteral(@"
<div class=""container mainPage"" id=""app"">
    <!--轮播行-->
    <div id=""flashads"" class=""row"">
        <div class=""col-md-12 col-xs-12 col-sm-12"" style=""padding:0; "">
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
            BeginContext(940, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "17106e51c9697038986b78f7543b29e85d183c476738", async() => {
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
            BeginContext(990, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1084, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "17106e51c9697038986b78f7543b29e85d183c478090", async() => {
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
            BeginContext(1135, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1229, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "17106e51c9697038986b78f7543b29e85d183c479443", async() => {
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
            BeginContext(1279, 4162, true);
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

        <div id=""myTabContent1"" class=""col-md-12 col-xs-12 col-sm-12"" style=""min-height:300px; border:1px solid #e8e8e8; padding:0px;"">
            <table class=""table table-hover table-success list-group col-md-12 col-xs-12 col-sm-12"" style=""padding:0px;"">
         ");
            WriteLiteral(@"       <tbody class=""col-md-12 col-xs-12 col-sm-12"" style=""padding:0px;"">
                    <tr class=""data-row col-md-12 col-xs-12 col-sm-12"" >
                        <td style=""width:10%;"" class=""data-col"">标题</td>
                        <td style=""width:8%;"" class=""data-col"">文章ID</td>
                        <td style=""width:8%;"" class=""data-col"">创建时间</td>
                        <td style=""width:8%;"" class=""data-col"">最后更新时间</td>
                        <td style=""width:20%;"" class=""smallcol-bigcontent"">大概内容...</td>
                        <td style=""width:10%;"" class=""data-col"">作者</td>
                        <td style=""width:4%;"" class=""data-col"">状态</td>
                        <td style=""width:16%;"" class=""data-col"">  </td>
                        <td style=""width:8%;"" class=""data-col""> <a href=""../ManagerMain/NewItBlog"" class=""addnew-a"">发表文章</a></td>
                    </tr>
                    <tr v-for=""(item,index) in facilities"" class=""data-row col-md-12 col-xs-12 col-sm-12"">
     ");
            WriteLiteral(@"                   <td style=""width:10%;"" >
                            <span class=""grade-tag"">{{item.Title}}</span>
                        </td>
                        <td style=""width:8%;"" >
                            <span class=""grade-tag"">{{item.Id}}</span>
                        </td>
                        <td style=""width:8%;"">
                            <span class=""grade-tag"">{{item.CreateTime}}</span>
                        </td>
                        <td style=""width:8%;"">
                            <span class=""grade-tag"">{{item.LastEditTime}}</span>
                        </td>
                        <td style=""width:20%;"" class=""smallcol-bigcontent"">
                            <span >{{item.Content}}</span>
                        </td>
                        <td style=""width:10%;"">
                            <span class=""grade-tag"">{{item.Author}}</span>
                        </td>
                        <td style=""width:4%;"">
                            <");
            WriteLiteral(@"span class=""grade-tag"" v-if=""item.IsIdentified<1"">未审核</span>
                            <span class=""grade-tag"" v-else>已审核</span>
                        </td>
                        <td style=""width:16%;"">
                            <span class=""grade-tag""><input type=""button"" v-on:click=""ValidPass(item.Id)"" value=""通过审核"" /></span>  || <span class=""grade-tag""><input type=""button"" v-on:click=""Forbidden(item.Id)"" value=""退回修改"" /></span>
                        </td>
                        <td style=""width:8%;"">
                            <span class=""grade-tag""><input type=""button"" v-on:click=""ValidBack(item.Id)"" value=""删除"" /></span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <ul class=""pagination"">

                <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                    <select v-bind:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""he");
            WriteLiteral("ight:34px;margin-top:0;display:inline;\">\r\n                        ");
            EndContext();
            BeginContext(5441, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17106e51c9697038986b78f7543b29e85d183c4715156", async() => {
                BeginContext(5449, 2, true);
                WriteLiteral("10");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5460, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5486, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17106e51c9697038986b78f7543b29e85d183c4716353", async() => {
                BeginContext(5494, 2, true);
                WriteLiteral("20");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5505, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5531, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17106e51c9697038986b78f7543b29e85d183c4717550", async() => {
                BeginContext(5539, 2, true);
                WriteLiteral("50");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5550, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5576, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17106e51c9697038986b78f7543b29e85d183c4718747", async() => {
                BeginContext(5584, 3, true);
                WriteLiteral("100");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5596, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5622, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17106e51c9697038986b78f7543b29e85d183c4719945", async() => {
                BeginContext(5630, 3, true);
                WriteLiteral("200");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5642, 6933, true);
            WriteLiteral(@"
                    </select>
                </li>
                <li><a v-if=""pageCount >1"" v-on:click=""PrevPage"" :class=""isprevDisable"">&laquo;</a></li>
                <li v-for=""index of pageCount ""><a v-if=""index >= pageindex && pageCount>1"" v-on:click=""PageChanged(index)"">{{index}}</a></li>
                <li><a v-if=""pageCount >1"" v-on:click=""NextPage"" :class=""isNextDisable"">&raquo;</a></li>
            </ul>

        </div>

    </div>

</div>
<script>
    (function () {
       
       //----------------------------
        var datas = [];
        var app = new Vue({

            el: '#app',
            data: {
                checkAll: false,
                checkedRows: [],
                facilities: datas,
                pageCount: 0,
                pageindex: 1,
                ntype: 0,
                selectPageSize: 10,
                isprevDisable: { disabled: true },
                isNextDisable: { disabled: false },
                posts: {
          ");
            WriteLiteral(@"          containerId: '456',
                    tabid:'7777',

                    tabitems: [
                    ]
                },
                
            },
            methods: {
                PrevPage: function () {
                    if (this.pageindex <= 1) {
                        this.isprevDisable.disabled = true;
                        this.isNextDisable.disabled = false;
                    }
                    else {
                        this.pageindex--;
                        this.isNextDisable.disabled = false;
                        $.ajax({
                            url: ""../ManagerMain/GetItBlogInfo"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: this.pageindex, rows: this.selectPageSize},
                            success: (arrdata) => {
                                if (arrdata != null) {
                                    this.facilities = arrdata.data;");
            WriteLiteral(@"
                                    this.pageCount = arrdata.Total;

                                }

                            }
                        });
                    }
                },
                NextPage: function () {
                    if (this.pageindex < this.pageCount) {
                        this.pageindex++;
                        $.ajax({
                            url: ""../ManagerMain/GetItBlogInfo"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: this.pageindex, rows: this.selectPageSize },
                            success: (arrdata) => {
                                if (arrdata != null) {
                                    this.facilities = arrdata.data;
                                    this.pageCount = arrdata.Total;

                                }

                            }
                        });
                    }
                    e");
            WriteLiteral(@"lse {
                        this.isprevDisable.disabled = false;
                        this.NextPage.disabled = true;
                    }
                },
                PageChanged: function (page) {
                    this.pageindex = page;
                    $.ajax({
                        url: ""../ManagerMain/GetItBlogInfo"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize},
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                                this.pageCount = arrdata.Total;

                            }

                        }
                    });
                },
                selectChanged: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/GetItBlogInfo"",
                        type: ");
            WriteLiteral(@"""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                                this.pageCount = arrdata.Total;

                            }

                        }
                    });
                },
                ValidPass: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/ItBlogPass"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                alert(""文章ID:"" + e + ""已经成功批付"");

                            }

                        }
                    });
                },
                Valid");
            WriteLiteral(@"Forbidden: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/ItBlogForbidden"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                                this.pageCount = arrdata.Total;

                            }

                        }
                    });
                },
                ValidBack: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/ItBlogDel"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                  ");
            WriteLiteral(@"              this.pageCount = arrdata.Total;

                            }

                        }
                    });
                },
            },
            mounted:function() {
                $.ajax({
                    url: ""../ManagerMain/GetItBlogInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize  },
                    success: (arrdata)=> {
                        if (arrdata != null) {
                            this.facilities = arrdata.data;
                            this.pageCount = arrdata.Total;
                        }

                    }
                });

            }


        });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
