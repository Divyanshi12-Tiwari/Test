#pragma checksum "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c0f41275fd86e2340720739c50e6c37ddb68403"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_State_Detail), @"mvc.1.0.view", @"/Views/State/Detail.cshtml")]
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
#nullable restore
#line 1 "D:\Blue360_Media\Blue360Media\Views\_ViewImports.cshtml"
using Blue360Media;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Blue360_Media\Blue360Media\Views\_ViewImports.cshtml"
using Blue360Media.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml"
using Blue360Media.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c0f41275fd86e2340720739c50e6c37ddb68403", @"/Views/State/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2df5cbd70a8d944aa4d7ca38c8c9664fc35ae25c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_State_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Blue360Media.Entities.State>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/pagescript/state/detail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml"
  
    ViewData["Title"] = "Detail"; 
    Layout = @HttpContextAccessor.HttpContext.Session.GetString("IsSystemAdministrator") == "True" ? "~/Views/Shared/_Layout.cshtml" : "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css\" />\r\n");
            WriteLiteral(@"<script src=""https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js""></script>
<script>
    $(document).ready(function () {

        $('#example').DataTable({
            ""scrollX"": true,
            destroy: true,
            ""aaSorting"": []
        });
    });
</script>


<div class=""main-page"">
    <div class=""blank-page widget-shadow scroll"" id=""style-2 div1"">
    <h3 class=""title1"">");
#nullable restore
#line 27 "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml"
                  Write(Model.StateDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <input type=\"hidden\" id=\"state_id\"");
            BeginWriteAttribute("value", " value=\"", 1034, "\"", 1058, 1);
#nullable restore
#line 28 "D:\Blue360_Media\Blue360Media\Views\State\Detail.cshtml"
WriteAttributeValue("", 1042, Model.StateCode, 1042, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
    <table id=""example"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>Title</th>
                <th>Number</th>
                <th>Description</th>
                <th>Number of Annotation</th>
                <th>Last Updated On</th>
                <th>Last Updated By</th>
            </tr>
        </thead>
    </table>
    </div>
</div>
<div class=""bs-example widget-shadow"" data-example-id=""contextual-table"">
</div>

");
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c0f41275fd86e2340720739c50e6c37ddb684035852", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Blue360Media.Entities.State> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
