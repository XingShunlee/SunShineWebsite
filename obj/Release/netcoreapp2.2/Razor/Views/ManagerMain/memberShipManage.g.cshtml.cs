#pragma checksum "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\ManagerMain\memberShipManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerMain_memberShipManage), @"mvc.1.0.view", @"/Views/ManagerMain/memberShipManage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManagerMain/memberShipManage.cshtml", typeof(AspNetCore.Views_ManagerMain_memberShipManage))]
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
#line 1 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa", @"/Views/ManagerMain/memberShipManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_ManagerMain_memberShipManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner1.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("First slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner2.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Second slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner3.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Third slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 2 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\ManagerMain\memberShipManage.cshtml"
  
    ViewData["Title"] = "会员管理";
Layout = "_ManagerTop";

#line default
#line hidden
            BeginContext(67, 858, true);
            WriteLiteral(@"
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
            BeginContext(925, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa6763", async() => {
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
            BeginContext(975, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1069, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa8115", async() => {
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
            BeginContext(1120, 94, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"item\">\r\n                        ");
            EndContext();
            BeginContext(1214, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa9468", async() => {
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
            BeginContext(1264, 3815, true);
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
            <table class=""table table-hover table-success list-group col-md-12 col-xs-12 col-sm-12"">
                <tbody>
      ");
            WriteLiteral(@"              <tr class=""data-row"" style=""border:1px dotted red;"">
                        <td style=""width:8%;"" class=""data-col"">账单ID</td>
                        <td style=""width:18%;"" class=""data-col"">用户名</td>
                        <td style=""width:8%;"" class=""data-col"">创建时间</td>
                        <td style=""width:8%;"" class=""data-col"">登录IP</td>
                        <td style=""width:8%;"" class=""data-col"">VIP等级</td>
                        <td style=""width:24%;"" class=""data-col"">提交时间</td>
                        <td style=""width:8%;"" class=""data-col"">状态</td>
                        <td style=""width:16%;"" class=""data-col"">  </td>
                        <td style=""width:8%;"" class=""data-col"">  </td>
                    </tr>
                    <tr v-for=""(item,index) in facilities"">
                        <td>
                            <span class=""grade-tag"">{{item.UserName}}</span>
                        </td>
                        <td>
                            <span cl");
            WriteLiteral(@"ass=""grade-tag"">{{item.UserName}}</span>
                        </td>
                        <td>
                            <span class=""grade-tag"">{{item.CreateTime}}</span>
                        </td>
                        <td>
                            <span class=""grade-tag"">{{item.LoginIP}}</span>
                        </td>
                        <td>
                            <span class=""grade-tag"">{{item.CreateTime}}</span>
                        </td>
                        <td>
                            <span class=""grade-tag"">{{item.CreateTime}}</span>
                        </td>
                        <td>
                            <span class=""grade-tag"" v-if=""item.nStatus<1"">冻  结</span>
                            <span class=""grade-tag"" v-else>正常</span>
                        </td>
                        <td>
                            <span class=""grade-tag""><input type=""button"" v-on:click=""PageDisabled(item.UserId)"" value=""冻  结"" /></span>  || <sp");
            WriteLiteral(@"an class=""grade-tag""><input type=""button"" v-on:click=""PageResetPassword(item.UserId)"" value=""重置密码"" /></span>
                        </td>
                        <td>
                            <span class=""grade-tag""><input type=""button"" v-on:click=""PageDelete(item.UserId)"" value=""删  除"" /></span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <ul class=""pagination"">

                <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                    <select v-bind:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""height:34px;margin-top:0;display:inline;"">
                        ");
            EndContext();
            BeginContext(5079, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa14773", async() => {
                BeginContext(5087, 2, true);
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
            BeginContext(5098, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5124, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa15970", async() => {
                BeginContext(5132, 2, true);
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
            BeginContext(5143, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5169, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa17167", async() => {
                BeginContext(5177, 2, true);
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
            BeginContext(5188, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5214, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa18364", async() => {
                BeginContext(5222, 3, true);
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
            BeginContext(5234, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(5260, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3e8e968d6b933c876ea4d18d4c3ca9a7e482fa19562", async() => {
                BeginContext(5268, 3, true);
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
            BeginContext(5280, 7107, true);
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
                name: '',
                selectPageSize: 10,
                isprevDisable: { disabled: true },
                isNextDisable: { disabled: false },
                posts: {
                  ");
            WriteLiteral(@"  containerId: '456',
                    tabid: '7777',

                    tabitems: [
                        {
                            id: 'jhh789jk2',
                            targetid: '#ALL',
                            text: '所有游戏',
                            isActive: true,
                        },



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
                            url: ""../GameCenter/GetMemberships"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: thi");
            WriteLiteral(@"s.pageindex, rows: this.selectPageSize },
                            success: (arrdata) => {
                                if (arrdata != null) {
                                    this.facilities = arrdata.data;
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
                            url: ""../ManagerMain/GetMemberships"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: this.pageindex, rows: this.selectPageSize },
                            success: (arrdata) => {
                                if (arrdata != null) {
                                    this.facilities = arrdat");
            WriteLiteral(@"a.data;
                                    this.pageCount = arrdata.Total;

                                }

                            }
                        });
                    }
                    else {
                        this.isprevDisable.disabled = false;
                        this.NextPage.disabled = true;
                    }
                },
                PageChanged: function (page) {
                    this.pageindex = page;
                    $.ajax({
                        url: ""../ManagerMain/GetMemberships"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                                this.pageCount = arrdata.Total;

                            }

                  ");
            WriteLiteral(@"      }
                    });
                },
                selectChanged: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/GetGameList"",
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
                },
                PageDisabled: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/DisableMember"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { status: false, uid: e },
                        success: (arrdata) => {
  ");
            WriteLiteral(@"                          if (arrdata != null) {
                                alert(""用户ID:"" + e + ""已经成功冻结"");

                            }

                        }
                    });
                },
                PageResetPassword: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/PageResetPassword"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { status: false, uid: e },
                        success: (arrdata) => {
                            if (arrdata != null && arrdata.Total > 0) {

                                alert(""密码已经成功修改"");

                            }

                        }
                    });
                },
                PageDelete: function (e) {
                    $.ajax({
                        url: ""../ManagerMain/DeleteMember"",
                        type: ""post"",
                        dataType: ""json"",
                ");
            WriteLiteral(@"        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.facilities = arrdata.data;
                                this.pageCount = arrdata.Total;

                            }

                        }
                    });
                }
            },
            mounted: function () {
                $.ajax({
                    url: ""../ManagerMain/GetMemberships"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { name: '' },
                    success: (arrdata) => {
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
