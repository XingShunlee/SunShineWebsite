#pragma checksum "E:\CodeStore\ehaikerv202010\Views\NewsCenter\bsIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c047bb68b320fe5a6d485e449ef0214c2d911d8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewsCenter_bsIndex), @"mvc.1.0.view", @"/Views/NewsCenter/bsIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewsCenter/bsIndex.cshtml", typeof(AspNetCore.Views_NewsCenter_bsIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c047bb68b320fe5a6d485e449ef0214c2d911d8c", @"/Views/NewsCenter/bsIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_bsIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\bsIndex.cshtml"
  
    ViewBag.Title = "公告";

#line default
#line hidden
            BeginContext(34, 1649, true);
            WriteLiteral(@"
  <!--homepage-->
  <link rel=""stylesheet"" href=""/css/GameStrategiesCenter/home-page.min.css"" />
  <div class=""container mainPage"" id=""app"">
      <!--过渡图片-->
      <div class=""row col-sm-12 col-md-12 col-lg-12"">
          <!--轮播内容-->
          <div class=""bd"">
              <ul>
                  <li class=""slide-bd-list"">
                      <a class=""slide-bd-a"" style=""background: url(/public/hotbg.jpg) repeat top center;"" href=""#"" target=""_blank""></a>
                  </li>

              </ul>
          </div>
      </div>
      <div class=""row"" id=""webapp"">
          <div id=""myTabContent"" class=""panel panel-info col-md-9 col-xs-9 col-sm-12"" style=""min-height:300px;overflow:hidden; border:1px solid #e8e8e8;margin-top:30px;"">
              <div class=""panel-heading panel-title""><span>公告板系统</span></div>
              <div class=""panel-body col-md-12"">
                  <ul class=""list-group col-md-12 col-xs-12 col-sm-12"">
                      <li v-for=""(item,index) in facilities");
            WriteLiteral(@"1"" class=""list-group-item"" style=""float:left;border:none;display:block;width:100%;"">
                          <a :href=""'../NewsCenter/showDetail?newsID='+item.Id"" class=""sw-btn"" target=""_blank"">{{item.Title}}</a>
                      </li>
                  </ul>
                  <ul class=""pagination"">
                      <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                          <select v-bind:change=""selectChanged(this)"" v-model=""selectPageSize"" class=""selectpicker"" style=""height:34px;margin-top:0;display:inline;"">
                              ");
            EndContext();
            BeginContext(1683, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c047bb68b320fe5a6d485e449ef0214c2d911d8c5110", async() => {
                BeginContext(1691, 2, true);
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
            BeginContext(1702, 32, true);
            WriteLiteral("\r\n                              ");
            EndContext();
            BeginContext(1734, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c047bb68b320fe5a6d485e449ef0214c2d911d8c6312", async() => {
                BeginContext(1742, 2, true);
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
            BeginContext(1753, 32, true);
            WriteLiteral("\r\n                              ");
            EndContext();
            BeginContext(1785, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c047bb68b320fe5a6d485e449ef0214c2d911d8c7514", async() => {
                BeginContext(1793, 2, true);
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
            BeginContext(1804, 32, true);
            WriteLiteral("\r\n                              ");
            EndContext();
            BeginContext(1836, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c047bb68b320fe5a6d485e449ef0214c2d911d8c8716", async() => {
                BeginContext(1844, 3, true);
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
            BeginContext(1856, 32, true);
            WriteLiteral("\r\n                              ");
            EndContext();
            BeginContext(1888, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c047bb68b320fe5a6d485e449ef0214c2d911d8c9919", async() => {
                BeginContext(1896, 3, true);
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
            BeginContext(1908, 4481, true);
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
      <script>

    //vue
    var app = new Vue({
        el:'#webapp',
        data: {
            facilities1: [],
            pageCount: 0,
            pageindex: 1,
            selectPageSize:10,
            isprevDisable: {disabled:true},
            isNextDisable: { disabled: false },

        },
        methods:
        {
            PrevPage: function () {
                if (this.pageindex <= 1) {
                    this.isprevDisable.disabled = true;
");
            WriteLiteral(@"                    this.isNextDisable.disabled = false;
                }
                else {
                    this.pageindex--;
                    this.isNextDisable.disabled = false;
                    $.ajax({
                        url: ""../NewsCenter/GetPageInfo"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize},
                        success: (arrdata)=> {
                            if (arrdata != null) {
                                this.facilities1 = arrdata.data;
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
                        url: ""../NewsCenter/GetPageInfo"",");
            WriteLiteral(@"
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize },
                        success: (arrdata)=> {
                            if (arrdata != null) {
                                this.facilities1 = arrdata.data;
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
                    url: ""../NewsCenter/GetPageInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize },
                    success: (a");
            WriteLiteral(@"rrdata)=> {
                        if (arrdata != null) {
                            this.facilities1 = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
            selectChanged: function (e) {
                $.ajax({
                    url: ""../NewsCenter/GetPageInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize },
                    success: (arrdata)=> {
                        if (arrdata != null) {
                            this.facilities1 = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
        },
        mounted: function () {
            $.ajax({
                url: ""../NewsCenter/GetPageInfo"",
                type: ""post"",
                d");
            WriteLiteral(@"ataType: ""json"",
                data: { page: 0, rows: this.selectPageSize },
                success:  (arrdata)=> {
                    if (arrdata != null) {
                        this.facilities1 = arrdata.data;
                        this.pageCount = arrdata.Total;

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
