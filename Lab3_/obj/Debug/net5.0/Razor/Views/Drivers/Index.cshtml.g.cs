#pragma checksum "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97b47c787deb5e63e55720ffa955e88eb6e98688"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drivers_Index), @"mvc.1.0.view", @"/Views/Drivers/Index.cshtml")]
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
#line 1 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\_ViewImports.cshtml"
using Lab3_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\_ViewImports.cshtml"
using Lab3_.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97b47c787deb5e63e55720ffa955e88eb6e98688", @"/Views/Drivers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9fe6a2458ebae819c0cc3396d3bd8bf3b7cb15", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Drivers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Driver>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
  
    ViewData["Title"] = "Водители";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Водители</h2>\n\n<p>\n</p>\n<table class=\"table\">\n    <thead>\n    <tr>\n        <th>\n            Паспорт\n        </th>\n        <th>\n            Фамилия\n        </th>\n        <th>\n            Имя\n        </th>\n    </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 27 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 31 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Passport));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 34 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 37 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 40 "D:\Course 3\Sem1\РПБДИС\лаб3\Lab3_\Lab3_\Views\Drivers\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Driver>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591