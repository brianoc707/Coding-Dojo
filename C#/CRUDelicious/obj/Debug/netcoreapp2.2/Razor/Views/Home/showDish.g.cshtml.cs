#pragma checksum "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8300ed1fa67928947ac8dca884b434b8d4a34aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_showDish), @"mvc.1.0.view", @"/Views/Home/showDish.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/showDish.cshtml", typeof(AspNetCore.Views_Home_showDish))]
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
#line 1 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/_ViewImports.cshtml"
using CRUDelicious;

#line default
#line hidden
#line 2 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/_ViewImports.cshtml"
using CRUDelicious.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8300ed1fa67928947ac8dca884b434b8d4a34aee", @"/Views/Home/showDish.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"815eae4269ab1eac71e8261ccfa9294c33285639", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_showDish : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 42, true);
            WriteLiteral("\n<p><a href=\"/\">Home</a></p>\n\n        <h2>");
            EndContext();
            BeginContext(43, 17, false);
#line 4 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
       Write(ViewBag.Dish.Name);

#line default
#line hidden
            EndContext();
            BeginContext(60, 18, true);
            WriteLiteral("</h2>\n        <h4>");
            EndContext();
            BeginContext(79, 17, false);
#line 5 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
       Write(ViewBag.Dish.Chef);

#line default
#line hidden
            EndContext();
            BeginContext(96, 17, true);
            WriteLiteral("</h4>\n        <p>");
            EndContext();
            BeginContext(114, 24, false);
#line 6 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
      Write(ViewBag.Dish.Description);

#line default
#line hidden
            EndContext();
            BeginContext(138, 26, true);
            WriteLiteral("</p>\n        <p>Calories :");
            EndContext();
            BeginContext(165, 21, false);
#line 7 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
                Write(ViewBag.Dish.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(186, 27, true);
            WriteLiteral("</p>\n        <p>Tastiness :");
            EndContext();
            BeginContext(214, 22, false);
#line 8 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
                 Write(ViewBag.Dish.Tastiness);

#line default
#line hidden
            EndContext();
            BeginContext(236, 11, true);
            WriteLiteral("</p>\n\n<p><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 247, "\"", 280, 2);
            WriteAttributeValue("", 254, "/edit/", 254, 6, true);
#line 10 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/CRUDelicious/Views/Home/showDish.cshtml"
WriteAttributeValue("", 260, ViewBag.Dish.DishId, 260, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(281, 48, true);
            WriteLiteral(">Edit</a></p>\n<p><a href=\"\">Delete</a></p>\n    \n");
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
