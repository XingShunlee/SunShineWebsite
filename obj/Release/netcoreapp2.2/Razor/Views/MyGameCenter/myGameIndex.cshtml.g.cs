#pragma checksum "E:\CodeStore\ehaikerv202010\Views\MyGameCenter\myGameIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d840967d7acae316bc9609cbbe26f245ac266fc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyGameCenter_myGameIndex), @"mvc.1.0.view", @"/Views/MyGameCenter/myGameIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MyGameCenter/myGameIndex.cshtml", typeof(AspNetCore.Views_MyGameCenter_myGameIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d840967d7acae316bc9609cbbe26f245ac266fc1", @"/Views/MyGameCenter/myGameIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_MyGameCenter_myGameIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\CodeStore\ehaikerv202010\Views\MyGameCenter\myGameIndex.cshtml"
  
    ViewBag.Title = "我收藏的游戏";
    Layout = "_MemberShipLayout";

#line default
#line hidden
            BeginContext(73, 2152, true);
            WriteLiteral(@"
  <!--homepage-->
 
<!--过渡图片-->
<div class=""row col-sm-12 col-md-12 col-lg-12"">
    <!--轮播内容-->
	<div class=""bd"">
		<ul>
			<li  class=""slide-bd-list"" >
				<a class=""slide-bd-a"" style=""background: url(/public/hotbg.jpg) repeat top center;"" href=""#"" target=""_blank""></a>
			</li>
						
		</ul>
	</div>
</div>
<div class=""row"" id=""webapp"">
    <div id=""myTabContent"" class=""tab-content col-md-9 col-xs-9 col-sm-12"" style=""border:1px solid #e8e8e8;margin-top:30px;"">
        <product-show-comp v-bind:post=""posts"">

        </product-show-comp>
        <div class=""col-md-12"">
            <ul class=""list-group col-md-12 col-xs-12 col-sm-12"" style=""min-height:300px;"">
                <li v-for=""(item,index) in facilities1"" class=""list-group-item"" style=""float:left;"">
                    <div class=""Item-img"">
                        <img :src=""item.ImgDescUri"" alt="" "" />
                        <div class=""cover"">
                            <div class=""opacity"">
                           ");
            WriteLiteral(@"     <div class=""info"">
                                    <a :href=""item.targetUri"" class=""sw-btn"" target=""_blank"">前去玩耍</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""Item-content"">
                        <span class=""grade-tag"">星级:{{item.grade}}</span>
                        <p> {{item.ItemName}}</p>
                        <p>运营商:<span class=""yunying-tag"">{{item.supporter}}</span></p>
                        <P class=""shoucang-tag"">
                            <a href=""javascript:void(0);"" v-on:click=""CancelMygame(item.ItemID)"">取消</a>
                        </P>
                    </div>
                </li>
            </ul>
            <ul class=""pagination"">
               
                <li v-if=""pageCount >1"" class=""list-group-item"" style=""margin:-1px 1px 0 -1px;padding:0;"">
                    <select  v-bind:change=""selectChanged(this)"" v-model=""selectPa");
            WriteLiteral("geSize\" class=\"selectpicker\" style=\"height:34px;margin-top:0;display:inline;\">\r\n                        ");
            EndContext();
            BeginContext(2225, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d840967d7acae316bc9609cbbe26f245ac266fc15751", async() => {
                BeginContext(2233, 2, true);
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
            BeginContext(2244, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2270, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d840967d7acae316bc9609cbbe26f245ac266fc16947", async() => {
                BeginContext(2278, 2, true);
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
            BeginContext(2289, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2315, 19, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d840967d7acae316bc9609cbbe26f245ac266fc18143", async() => {
                BeginContext(2323, 2, true);
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
            BeginContext(2334, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2360, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d840967d7acae316bc9609cbbe26f245ac266fc19339", async() => {
                BeginContext(2368, 3, true);
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
            BeginContext(2380, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2406, 20, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d840967d7acae316bc9609cbbe26f245ac266fc110536", async() => {
                BeginContext(2414, 3, true);
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
            BeginContext(2426, 7645, true);
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
    Vue.component(""product-show-comp"", {
        props: ['post'],

        template: `
            <div v-bind:id=post.containerId>
            <ul v-bind:id=post.tabid class= ""nav nav-tabs"">
            <li role=""presentation"" v-for=""item in post.tabitems"" v-bind:key=""item.id"" v-bind:class=""{ active: item.isActive }""  v-show=""post.tabitems.length!=0"" >
            <a v-bind:href=item.targetid  data-toggle=""tab"" v-on:click=""OnChange(item)"">{{item.text}}</a></li></ul>
            </div>`,
        methods: {
            OnChange: f");
            WriteLiteral(@"unction (e) {
                var ntype = -1;
                $.each(this.post.tabitems, function (i, item) {
                    if (item.targetid === e.targetid) {
                        ntype = item.Typeid;
                        return false;
                    }
                });
                $.ajax({
                    url: ""../MyGameCenter/GetMyGameListInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { type: ntype },
                    success: (arrdata)=> {
                        if (arrdata != null) {
                            this.$parent.facilities1 = arrdata.data;
                            this.$parent.pageCount = arrdata.Total;
                            this.$parent.ntype = ntype;
                        }

                    }
                });
            }

        }
    });
    //vue
    var app = new Vue({
        el:'#webapp',
        data: {
            facilities1: [],
            pa");
            WriteLiteral(@"geCount: 0,
            pageindex: 1,
            ntype: 0,
            selectPageSize: 10,
            isprevDisable: { disabled: true },
            isNextDisable: { disabled: false },
            posts: {
                containerId: 'maintab',
                tabid: 'mainul',

                tabitems: [
                    {
                        Typeid: 0,
                        targetid: '#home',
                        text: '全部游戏',
                        isActive: true,
                    },
                    {
                        Typeid: 1,
                        targetid: '#web',
                        text: '网页游戏',
                        isActive: false,
                    },
                    {
                        Typeid: 2,
                        targetid: '#app',
                        text: 'APP游戏',
                        isActive: false,
                    },
                ]
            },
        },
        mounted: function () {
  ");
            WriteLiteral(@"          $.ajax({
                url: ""../MyGameCenter/GetMyGameListInfo"",
                type: ""post"",
                dataType: ""json"",
                data: { type: 0, rows: this.selectPageSize },
                success: (arrdata)=> {
                    if (arrdata != null) {
                        this.facilities1 = arrdata.data;
                        this.pageCount = arrdata.Total;

                    }

                }
            });
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
                        url: ""../MyGameCenter/GetMyGameListInfo"",
                        type: ""post"",
                        dataType: ""json"",");
            WriteLiteral(@"
                        data: { page: this.pageindex, rows: this.selectPageSize,type: this.ntype },
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
                        url: ""../MyGameCenter/GetMyGameListInfo"",
                        type: ""post"",
                        dataType: ""json"",
                        data: { page: this.pageindex, rows: this.selectPageSize,type: this.ntype },
                        success:(arrdata)=> {
                            if (arrdata != null) {
                                this.facilities1 = arrdat");
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
                    url: ""../MyGameCenter/GetMyGameListInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize,type: this.ntype },
                    success: (arrdata)=> {
                        if (arrdata != null) {
                            this.facilities1 = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
            selectChanged");
            WriteLiteral(@": function (e) {
                $.ajax({
                    url: ""../MyGameCenter/GetMyGameListInfo"",
                    type: ""post"",
                    dataType: ""json"",
                    data: { page: this.pageindex, rows: this.selectPageSize, type: this.ntype },
                    success:  (arrdata)=> {
                        if (arrdata != null) {
                            this.facilities1 = arrdata.data;
                            this.pageCount = arrdata.Total;

                        }

                    }
                });
            },
            CancelMygame: function (e) {
                $.ajax(
                    {
                        url: ""/MyGameCenter/CancelMyGameItem"",
                        type: ""post"",
                        data: { gid: e },
                        dataType: ""json"",
                        success: function (o) {
                            if (o.SuccessCode == ""0"") {
                                window.location.href ");
            WriteLiteral(@"= ""../MyGameCenter/Index"";
                                return;
                            }
                            else {
                                alert(o.msg);
                            }

                        }
                        ,
                        error: function (o) {
                            alert(o.msg);
                        }

                    }); //ajax
            },
        },

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