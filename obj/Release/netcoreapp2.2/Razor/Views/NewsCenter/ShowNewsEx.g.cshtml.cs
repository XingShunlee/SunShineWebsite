#pragma checksum "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNewsEx.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3172a2b6ee77e1a3fc05cd35e325b374d040039b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewsCenter_ShowNewsEx), @"mvc.1.0.view", @"/Views/NewsCenter/ShowNewsEx.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewsCenter/ShowNewsEx.cshtml", typeof(AspNetCore.Views_NewsCenter_ShowNewsEx))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3172a2b6ee77e1a3fc05cd35e325b374d040039b", @"/Views/NewsCenter/ShowNewsEx.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_ShowNewsEx : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNewsEx.cshtml"
  
    Layout = "_ManagerTop";
    ViewData["Title"] = "新闻中心";

#line default
#line hidden
            BeginContext(69, 2064, true);
            WriteLiteral(@"
<!-- 顶部导航区域 -->
<div class=""container mainPage"" id=""app"" style=""margin-top:30px;"">
    <div class=""block-main"">
        <div class=""datagrid-container-fliud"">
            <div id=""app3"" class=""row"">

                <div id=""NewsTabctl"" class=""tab-content col-md-12 col-xs-12 col-sm-12"" style=""min-height:300px; border:1px solid #e8e8e8;"">
                    <table class=""table table-hover table-success list-group col-md-12 col-xs-12 col-sm-12"">
                        <tbody>
                            <tr class=""data-row"" style=""border:1px dotted red;"">
                                <td style=""width:36%;"" class=""data-col"">标题</td>
                                <td style=""width:18%;"" class=""data-col"">状态</td>
                                <td style=""width:16%;"" class=""data-col"">  </td>
                                <td style=""width:8%;"" class=""data-col"">  </td>
                            </tr>
                            <tr v-for=""(item,index) in facilities"">
                       ");
            WriteLiteral(@"         <td>
                                    <span class=""grade-tag"">{{item.Title}}</span>
                                </td>
                               
                                <td>
                                    <span class=""grade-tag""> <a :href=""'../NewsCenter/ShowDetailEx?newsID='+item.Id"" target='_self'>查看|修改</a></span>
                                </td>
                                <td>
                                    <span class=""grade-tag""><input type=""button"" value=""删除"" /></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <ul class=""pagination"">

                        <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                            <select v-bind:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""height:34px;margin-top:0;display:inline;"">
                ");
            WriteLiteral("                ");
            EndContext();
            BeginContext(2133, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3172a2b6ee77e1a3fc05cd35e325b374d040039b5629", async() => {
                BeginContext(2141, 2, true);
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
            BeginContext(2152, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2186, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3172a2b6ee77e1a3fc05cd35e325b374d040039b6833", async() => {
                BeginContext(2194, 2, true);
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
            BeginContext(2205, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2239, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3172a2b6ee77e1a3fc05cd35e325b374d040039b8037", async() => {
                BeginContext(2247, 2, true);
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
            BeginContext(2258, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2292, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3172a2b6ee77e1a3fc05cd35e325b374d040039b9241", async() => {
                BeginContext(2300, 3, true);
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
            BeginContext(2312, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2346, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3172a2b6ee77e1a3fc05cd35e325b374d040039b10446", async() => {
                BeginContext(2354, 3, true);
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
            BeginContext(2366, 5309, true);
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
   ");
            WriteLiteral(@"             isNextDisable: { disabled: false },
                posts: {
                    containerId: '456',
                    tabid: '7777',

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
                            url: ""../NewsCenter/GetShowNews"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: this.pageindex, rows: this.selectPageSize },
                            success: (arrdata) => {
                                if (arrdata != null) {
            WriteLiteral(@"
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
                            url: ""../NewsCenter/GetShowNews"",
                            type: ""post"",
                            dataType: ""json"",
                            data: { page: this.pageindex, rows: this.selectPageSize },
                            success: (arrdata) => {
                                if (arrdata != null) {
                                    this.facilities = arrdata.data;
                                    this.pageCount = arrdata.Total;

                                }

                            }
       ");
            WriteLiteral(@"                 });
                    }
                    else {
                        this.isprevDisable.disabled = false;
                        this.NextPage.disabled = true;
                    }
                },
                PageChanged: function (page) {
                    this.pageindex = page;
                    $.ajax({
                        url: ""../NewsCenter/GetShowNews"",
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

                selectChanged: function (e) {
                    $.ajax({
                        ur");
            WriteLiteral(@"l: ""../NewsCenter/GetShowNews"",
                        
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
                
            },
            mounted: function () {
                $.ajax({
                    url: ""../NewsCenter/GetShowNews"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize },
                    success: (arrdata) => {
                        if (arrdata != null) {
                            this.facilities = arrdata.data;
  ");
            WriteLiteral("                          this.pageCount = arrdata.Total;\r\n                        }\r\n\r\n                    }\r\n                });\r\n\r\n            }\r\n\r\n\r\n        });\r\n\r\n    })()\r\n</script>\r\n");
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