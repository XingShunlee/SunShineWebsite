#pragma checksum "E:\CodeStore\ehaikerv202010\Views\VIPBill\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65513ff6bf83a73ea5c1d6f10240fc0905a5f996"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VIPBill_Index), @"mvc.1.0.view", @"/Views/VIPBill/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/VIPBill/Index.cshtml", typeof(AspNetCore.Views_VIPBill_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65513ff6bf83a73ea5c1d6f10240fc0905a5f996", @"/Views/VIPBill/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_VIPBill_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10000", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\CodeStore\ehaikerv202010\Views\VIPBill\Index.cshtml"
  
    ViewBag.Title = "我的账单";
    Layout = "_MemberShipLayout";
    //var datta = Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model));

#line default
#line hidden
            BeginContext(206, 2573, true);
            WriteLiteral(@"
<link rel=""stylesheet"" href=""../css/websitebase.css"" /><!--基本样式应用-->
<link rel=""stylesheet"" href=""../css/common.min.css"" /><!--菜单与悬浮样式应用-->
<link rel=""stylesheet"" href=""../css/icon.min.css"" />
<link rel=""stylesheet"" href=""../css/personal/home-page.min.css"" />

<script src=""../Scripts/personalbill_approve.js""></script>
<script src=""../js/personal.js""></script>
<link rel=""stylesheet"" href=""../css/CommonDialog.css"" />
<script type=""text/javascript"" src=""../js/CommonDialog.js""></script>


<style>
   
    .datagrid-container-fliud {
        float: left;
    }

    .da.data-row {
        float: left;
        width: 100%;
        height: 25px;
        border: 2px solid green;
    }

    .data-row.data-col {
        float: left;
        border: 2px solid green;
    }
</style>
<div id=""left-right-layout"" style=""width:100%;height:200px"">
    <Table class=""datagrid-container-fliud"">
            <tr class=""data-row"" style=""border:1px dotted red;"">
                <td style=""width:8%;"" cl");
            WriteLiteral(@"ass=""data-col"">账单ID</td>
                <td style=""width:18%;"" class=""data-col"">支付内容</td>
                <td style=""width:4%;"" class=""data-col"">支付类型</td>
                <td style=""width:8%;"" class=""data-col"">支付数值</td>
                <td style=""width:30%;"" class=""data-col"">支付凭证</td>
                <td style=""width:24%;"" class=""data-col"">提交时间</td>
                <td style=""width:8%;"" class=""data-col"">状态</td>
            </tr>
            <tr v-for=""item in paybills"" class=""data-row"" style=""clear:both;"">
                <td  class=""data-col"">{{item.PayBillID}}</td>
                <td  class=""data-col"">{{item.ApproveForWhat}}</td>
                <td v-if=""item.PayType===0""  class=""data-col"">支付宝支付</td>
                <td v-else-if=""item.PayType===1""  class=""data-col"">微信支付</td>
                <td v-else class=""data-col"">在线支付</td>
                <td  class=""data-col"">{{item.PayValue}}</td>
                <td  class=""data-col"">{{item.PayForDateTime}}</td>
                <td  class=""data-c");
            WriteLiteral(@"ol"">{{item.CreateTime}}</td>
                <td v-if=""item.PayState===1"" class=""data-col"">审核通过</td>
                <td v-else  class=""data-col"">审核未通过</td>
            </tr>
            <tr class=""data-row"">
                <td v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                    <select v-if=""pageCount >1"" v-on:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""height:34px;margin-top:0;display:inline;"">
                        ");
            EndContext();
            BeginContext(2779, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f9967364", async() => {
                BeginContext(2787, 2, true);
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
            BeginContext(2798, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2824, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f9968560", async() => {
                BeginContext(2832, 2, true);
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
            BeginContext(2843, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2869, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f9969756", async() => {
                BeginContext(2877, 2, true);
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
            BeginContext(2888, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2914, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99610952", async() => {
                BeginContext(2922, 3, true);
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
            BeginContext(2934, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2960, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99612150", async() => {
                BeginContext(2968, 3, true);
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
            BeginContext(2980, 729, true);
            WriteLiteral(@"
                    </select>
                </td>
                <td><a v-if=""pageCount >1"" v-on:click=""PrevPage"" :class=""isprevDisable"">&laquo;</a></td>
                <td v-for=""index of pageCount ""><a v-if=""index >= pageindex && pageCount>1"" v-on:click=""PageChanged(index)"">{{index}}</a></td>
                <td><a v-if=""pageCount >1"" v-on:click=""NextPage"" :class=""isNextDisable"">&raquo;</a></td>
            </tr>
            <tr id=""BillStateSeach"" class=""data-row"">
                <td colspan=""7"">
                    <span>数据状态：</span>
                    <select class=""att-txt"" id=""PayForState"" name=""PayForState"" v-on:change=""StateselectChanged(this)"" v-model=""Stateselected"">
                        ");
            EndContext();
            BeginContext(3709, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99614085", async() => {
                BeginContext(3731, 6, true);
                WriteLiteral("==所有==");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3746, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(3772, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99615487", async() => {
                BeginContext(3790, 3, true);
                WriteLiteral("待审核");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3802, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(3828, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99616886", async() => {
                BeginContext(3846, 3, true);
                WriteLiteral("已通过");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3858, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(3884, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65513ff6bf83a73ea5c1d6f10240fc0905a5f99618285", async() => {
                BeginContext(3903, 2, true);
                WriteLiteral("退回");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3914, 4921, true);
            WriteLiteral(@"
                    </select>
                </td>
            </tr>
        </Table>


</div>
<script>
    var app = new Vue({
        el: '#left-right-layout',
        data: {
            paybills: [],
            pageCount: 0,
            pageindex: 1,
            selectPageSize: 10,
            Stateselected: 10000,
            isprevDisable: { disabled: true },
            isNextDisable: { disabled: false }

        },
        created() {
            //如果没有这句代码，select中初始化会是空白的，默认选中就无法实现
            this.Stateselected = 10000;
        },
        methods:
        {
            PrevPage: function () {
                if (this.pageindex <= 1) {
                    this.isprevDisable.disabled = true;
                    this.isNextDisable.disabled = false;
                }
                else {
                    this.pageindex--;
                    this.isNextDisable.disabled = false;
                    $.ajax({
                        url: ""../VIPBill/MyBill"",
   ");
            WriteLiteral(@"                     type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, pagesize: this.selectPageSize, type: this.Stateselected },
                        success: (arrdata) => {
                            if (arrdata != null) {
                                this.paybills = arrdata.data;
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
                        url: ""../VIPBill/MyBill"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, pagesize: this.selectPageSize, type: this.Stateselected },
                        success: (arrdata) => {
                      ");
            WriteLiteral(@"      if (arrdata != null) {
                                this.paybills = arrdata.data;
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
                    url: ""../VIPBill/MyBill"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, pagesize: this.selectPageSize, type: this.Stateselected },
                    success: (arrdata) => {
                        if (arrdata != null) {
                            this.paybills = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

      ");
            WriteLiteral(@"              }
                });
            },
            selectChanged: function (e) {
                $.ajax({
                    url: ""../VIPBill/MyBill"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, pagesize: this.selectPageSize, type: this.Stateselected },
                    success: (arrdata) => {
                        if (arrdata != null) {
                            this.paybills = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
            StateselectChanged: function (e) {
                $.ajax({
                    url: ""../VIPBill/MyBill"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, pagesize: this.selectPageSize, type: this.Stateselected },
                    success: (arrdata) => {
                ");
            WriteLiteral(@"        if (arrdata != null) {
                            this.paybills = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
        },
        mounted: function () {
            $.ajax({
                url: ""../VIPBill/MyBill"",
                type: ""post"",
                dataType: ""json"",
                data: { pagesize: this.selectPageSize, type: 10000 },
                success: (arrdata) => {
                    if (arrdata != null) {
                        this.paybills = arrdata.data;
                        this.pageCount = arrdata.Total;
                        this.ntype = 0;
                    }

                }
            });
        }


    });

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
