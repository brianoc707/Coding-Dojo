#pragma checksum "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2c75ea26fd974f4d7907ead8f15ddd204f0b165"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Wedding), @"mvc.1.0.view", @"/Views/Home/Wedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Wedding.cshtml", typeof(AspNetCore.Views_Home_Wedding))]
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
#line 1 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2c75ea26fd974f4d7907ead8f15ddd204f0b165", @"/Views/Home/Wedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Wedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 76, true);
            WriteLiteral("<a href=\"/dashboard\">Dashboard</a>\n<a href=\"/logout\">Logout</a>\n<h1>Wedding ");
            EndContext();
            BeginContext(77, 28, false);
#line 3 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml"
       Write(ViewBag.PlannedWeddings.Name);

#line default
#line hidden
            EndContext();
            BeginContext(105, 10, true);
            WriteLiteral("</h1>\n<h3>");
            EndContext();
            BeginContext(116, 28, false);
#line 4 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml"
Write(ViewBag.PlannedWeddings.Date);

#line default
#line hidden
            EndContext();
            BeginContext(144, 24, true);
            WriteLiteral("</h3>\n\n<h3>Guests</h3>\n\n");
            EndContext();
#line 8 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml"
  
    foreach(var i in ViewBag.AllGuests)
    {

#line default
#line hidden
            BeginContext(217, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(229, 12, false);
#line 11 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml"
      Write(i.Guest.Name);

#line default
#line hidden
            EndContext();
            BeginContext(241, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
#line 12 "/Users/THABOSSMAN/Documents/Coding_Dojo/C#/WeddingPlanner/Views/Home/Wedding.cshtml"
    }

#line default
#line hidden
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
