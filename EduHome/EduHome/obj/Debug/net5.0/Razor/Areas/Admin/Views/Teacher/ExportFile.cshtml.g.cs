#pragma checksum "D:\P320\4. ASP .NET\2. MVC\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Teacher\ExportFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "078b25964e8ba51dc3acb74861f3681eab47877a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Teacher_ExportFile), @"mvc.1.0.view", @"/Areas/Admin/Views/Teacher/ExportFile.cshtml")]
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
#line 2 "D:\P320\4. ASP .NET\2. MVC\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"078b25964e8ba51dc3acb74861f3681eab47877a", @"/Areas/Admin/Views/Teacher/ExportFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3e794b749043775922a8b5663fb937443e47922", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Teacher_ExportFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\P320\4. ASP .NET\2. MVC\EduHome-BackEnd-project\EduHome\EduHome\Areas\Admin\Views\Teacher\ExportFile.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "078b25964e8ba51dc3acb74861f3681eab47877a3510", async() => {
                WriteLiteral(@"
	<meta charset=""UTF-8"">
    <title>Report Product</title>
     <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.1/css/bootstrap.css"">
	<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css"">
	<link rel=""stylesheet"" href=""https://cdn.datatables.net/buttons/1.5.2/css/buttons.bootstrap4.min.css"">
	<link rel=""stylesheet"" href=""https://cdn.datatables.net/responsive/2.2.3/css/responsive.bootstrap4.min.css"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "078b25964e8ba51dc3acb74861f3681eab47877a4989", async() => {
                WriteLiteral(@"
	<table id=""example"" class=""table table-striped table-bordered dt-responsive nowrap"" style=""width:100%"">
        <thead>
            <tr>
                <th>First name</th>
                <th>Last name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Age</th>
                <th>Start date</th>
                <th>Salary</th>
                <th>Extn.</th>
                <th>E-mail</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr> 
              <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</");
                WriteLiteral(@"td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>   
            <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr> 
              <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
  ");
                WriteLiteral(@"              <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <t");
                WriteLiteral(@"r>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
               ");
                WriteLiteral(@" <td>d.snider@datatables.net</td>
            </tr> 
              <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>   
            <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
          ");
                WriteLiteral(@"      <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>  
             <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
                <td>27</td>
                <td>2011/01/25</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>   
            <tr>
                <td>Donna</td>
                <td>Snider</td>
                <td>Customer Support</td>
                <td>New York</td>
     ");
                WriteLiteral(@"           <td>27</td>
                <td>2012/11/55</td>
                <td>$112,000</td>
                <td>4226</td>
                <td>d.snider@datatables.net</td>
            </tr>
        </tbody>
    </table>
   <script src=""https://code.jquery.com/jquery-3.3.1.js""></script>
     <script src=""https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js""></script>
     <script src=""https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.5.2/js/buttons.bootstrap4.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1");
                WriteLiteral(@".5.2/js/buttons.html5.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.5.2/js/buttons.colVis.min.js""></script>
     <script src=""https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap4.min.js""></script>
   
   <script>
	$(document).ready(function() {
	    var table = $('#example').DataTable( {
	        buttons: [ 'copy', 'excel', 'csv', 'pdf', 'print', 'colvis' ],
	    } );
	 
	    table.buttons().container()
	        .appendTo( '#example_wrapper .col-md-6:eq(0)' );
	} );
     </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591