#pragma checksum "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e483a04e6d0b5a02f64c0feed60cc17a237d1ee0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Event_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Event/Details.cshtml")]
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
#line 2 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.Areas.Admin.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e483a04e6d0b5a02f64c0feed60cc17a237d1ee0", @"/Areas/Admin/Views/Event/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79b7b4c63ecbc563a14876e30a534b1dcc22e92d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Event_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 grid-margin stretch-card\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"card-title\">Title: ");
#nullable restore
#line 10 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                         Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h6 class=\"card-title\">StartTime ");
#nullable restore
#line 11 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                            Write(Model.StartTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <h6 class=\"card-title\">EndTime ");
#nullable restore
#line 12 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                          Write(Model.EndTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <h6 class=\"card-title\">Location ");
#nullable restore
#line 13 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                           Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <h6 class=\"card-title\">EventDate ");
#nullable restore
#line 14 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                            Write(Model.EventDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n");
#nullable restore
#line 16 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                 foreach (var item in @ViewBag.EventDetail)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-title\">Location ");
#nullable restore
#line 18 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 19 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Event\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Event> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
