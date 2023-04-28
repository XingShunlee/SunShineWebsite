#pragma checksum "D:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowNewsEx.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0570e79d5dc3b962f2b6764755ffa03f725479f"
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
#line 1 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0570e79d5dc3b962f2b6764755ffa03f725479f", @"/Views/NewsCenter/ShowNewsEx.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_ShowNewsEx : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowNewsEx.cshtml"
  
    Layout = "_ManagerTop";
    ViewData["Title"] = "新闻中心";

#line default
#line hidden
            BeginContext(69, 2384, true);
            WriteLiteral(@"
<!-- 顶部导航区域 -->
<div class=""container mainPage"" id=""app"">
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
                                <td>
          ");
            WriteLiteral(@"                          <span class=""grade-tag"">{{item.Title}}</span>
                                </td>
                               
                                <td>
                                    <span class=""grade-tag""> <a :href=""'../NewsCenter/ShowDetailEx?newsID='+item.Id"" target='_self'>查看|修改</a></span>
                                </td>
                                <td>
                                    <span class=""grade-tag""><input type=""button"" v-on:click=""OnDeleteItem(item.Id)"" value=""删除"" /></span>
                                    <span class=""grade-tag"" v-if=""item.IsUnVisible>0""><input type=""button"" v-on:click=""OnRecoverItem(item.Id)"" value=""恢复"" /></span>
                                    <span class=""grade-tag"" v-else><input type=""button"" v-on:click=""OnHiddenItem(item.Id)"" value=""隐藏"" /></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <ul clas");
            WriteLiteral(@"s=""pagination"">

                        <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                            <select v-bind:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""height:34px;margin-top:0;display:inline;"">
                                ");
            EndContext();
            BeginContext(2453, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0570e79d5dc3b962f2b6764755ffa03f725479f5960", async() => {
                BeginContext(2461, 2, true);
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
            BeginContext(2472, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2506, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0570e79d5dc3b962f2b6764755ffa03f725479f7164", async() => {
                BeginContext(2514, 2, true);
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
            BeginContext(2525, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2559, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0570e79d5dc3b962f2b6764755ffa03f725479f8368", async() => {
                BeginContext(2567, 2, true);
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
            BeginContext(2578, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2612, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0570e79d5dc3b962f2b6764755ffa03f725479f9572", async() => {
                BeginContext(2620, 3, true);
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
            BeginContext(2632, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(2666, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0570e79d5dc3b962f2b6764755ffa03f725479f10777", async() => {
                BeginContext(2674, 3, true);
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
            BeginContext(2686, 6883, true);
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
                OnDeleteItem: function (e) {
                    $.ajax({
                        url: ""../NewsCenter/NewsDel"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                alert(""公告ID:"" + e + ""已经成功删除"");

                            }

     ");
            WriteLiteral(@"                   }
                    });
                },
                OnHiddenItem: function (e) {
                    $.ajax({
                        url: ""../NewsCenter/NewsHidden"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                alert(""公告ID:"" + e + ""已经成功隐藏"");

                            }

                        }
                    });
                },
                OnRecoverItem: function (e) {
                    $.ajax({
                        url: ""../NewsCenter/NewsRecover"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { uid: e },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                alert(""公告ID:"" + e + ""已经成功恢复"");
");
            WriteLiteral(@"
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