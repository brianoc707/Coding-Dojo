#pragma checksum "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d1615201ef8bbe66c0606d6be57184164bb2172"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/_ViewImports.cshtml"
using chefDish2;

#line default
#line hidden
#line 2 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/_ViewImports.cshtml"
using chefDish2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d1615201ef8bbe66c0606d6be57184164bb2172", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8c7a8e429faea4a2cd4dc7c3dedf217a4ad29ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 127, true);
            WriteLiteral("<h1>Chefs | <a href=\"/dishes\">Dishes</a></h1>\r\n<p><a href=\"/new\">Add a Chef</a></p>\r\n<h2>Check out our roster of Chefs</h2>\r\n\r\n");
            EndContext();
            BeginContext(131, 119, true);
            WriteLiteral("    <table>\r\n    <tr>\r\n        <th>Name</th>\r\n        <th>Age</th>\r\n        <th>Number of Dishes</th>\r\n    </tr>\r\n   \r\n");
            EndContext();
#line 13 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
     foreach(var i in ViewBag.AllChefs)
    {

#line default
#line hidden
            BeginContext(298, 18, true);
            WriteLiteral("    <tr>\r\n    <td>");
            EndContext();
            BeginContext(317, 11, false);
#line 16 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
   Write(i.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(328, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(330, 10, false);
#line 16 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
                Write(i.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(340, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(356, 5, false);
#line 17 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
   Write(i.Age);

#line default
#line hidden
            EndContext();
            BeginContext(361, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(377, 14, false);
#line 18 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
   Write(i.Dishes.Count);

#line default
#line hidden
            EndContext();
            BeginContext(391, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 20 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/chefDish2/Views/Home/Index.cshtml"
    }

#line default
#line hidden
            BeginContext(416, 20, true);
            WriteLiteral("    \r\n    </table>\r\n");
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
