#pragma checksum "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20e869465123124e6ed45e9743e92bf2165d1999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Detail), @"mvc.1.0.view", @"/Views/Teacher/Detail.cshtml")]
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
#line 2 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e869465123124e6ed45e9743e92bf2165d1999", @"/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0d73ee00f5bafdb859aa388ca80ee98895e0db9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("teacher"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Banner Area Start -->
<div class=""banner-area-wrapper"">
    <div class=""banner-area text-center"">	
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>teachers / details</h2> 
                        </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>    
<!-- Banner Area End -->
<!-- Teacher Start -->
<div class=""teacher-details-area pt-150 pb-60"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""teacher-details-img"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "20e869465123124e6ed45e9743e92bf2165d19994673", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 876, "~/img/teacher/", 876, 14, true);
#nullable restore
#line 28 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 890, Model.ImagePath, 890, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("  \r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7 col-sm-7 col-xs-12\">\r\n                <div class=\"teacher-details-content ml-50\">\r\n                    <h2>");
#nullable restore
#line 33 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h5>");
#nullable restore
#line 34 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                   Write(Model.Job);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h4>about me</h4>\r\n                    <p>");
#nullable restore
#line 36 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                  Write(Model.TeacherDetail.AboutTeacher);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    <ul>\r\n                            <li><span>degree: </span>");
#nullable restore
#line 38 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                Write(Model.TeacherDetail.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral(" in ");
#nullable restore
#line 38 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                                               Write(ViewBag.TeacherCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </li>\r\n                            <li><span>experience: </span>");
#nullable restore
#line 39 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                    Write(Model.TeacherDetail.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n                            <li><span>hobbies: </span>");
#nullable restore
#line 40 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                 Write(Model.TeacherDetail.Hobies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span>faculty: </span> ");
#nullable restore
#line 41 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                  Write(ViewBag.TeacherCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-md-3 col-sm-4"">
                <div class=""teacher-contact"">
                    <h4>contact information</h4>
                    <p><span>mail me : </span>");
#nullable restore
#line 51 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                         Write(Model.TeacherDetail.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>make a call : </span>");
#nullable restore
#line 52 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                             Write(Model.TeacherDetail.PhoneNumbers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>skype : </span> ");
#nullable restore
#line 53 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                        Write(Model.TeacherDetail.SkypeProfile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <ul>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 2250, "\"", 2275, 1);
#nullable restore
#line 55 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue("", 2257, Model.FacebookUrl, 2257, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-facebook\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 2352, "\"", 2378, 1);
#nullable restore
#line 56 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue("", 2359, Model.PinterestUrl, 2359, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-pinterest\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 2456, "\"", 2481, 1);
#nullable restore
#line 57 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue("", 2463, Model.VkontaktUrl, 2463, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-vimeo\"></i></a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 2555, "\"", 2579, 1);
#nullable restore
#line 58 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue("", 2562, Model.TwitterUrl, 2562, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""zmdi zmdi-twitter""></i></a></li>
                    </ul>
                </div>
            </div>
            <div class=""col-md-9 col-sm-8"">
                <div class=""skill-area"">
                    <h4>skills</h4>
                </div>  
                <div class=""skill-wrapper"">     
                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>language</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 3239, "\"", 3388, 11);
            WriteAttributeValue("", 3247, "width:", 3247, 6, true);
#nullable restore
#line 72 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 3253, Model.TeacherDetail.LanguagePoint, 3254, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3288, "%;", 3288, 2, true);
            WriteAttributeValue(" ", 3290, "visibility:", 3291, 12, true);
            WriteAttributeValue(" ", 3302, "visible;", 3303, 9, true);
            WriteAttributeValue(" ", 3311, "animation-duration:", 3312, 20, true);
            WriteAttributeValue(" ", 3331, "1.5s;", 3332, 6, true);
            WriteAttributeValue(" ", 3337, "animation-delay:", 3338, 17, true);
            WriteAttributeValue(" ", 3354, "1.2s;", 3355, 6, true);
            WriteAttributeValue(" ", 3360, "animation-name:", 3361, 16, true);
            WriteAttributeValue(" ", 3376, "fadeInLeft;", 3377, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 73 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.LanguagePoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>team leader</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 4014, "\"", 4164, 11);
            WriteAttributeValue("", 4022, "width:", 4022, 6, true);
#nullable restore
#line 82 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 4028, Model.TeacherDetail.TeamLiderPoint, 4029, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4064, "%;", 4064, 2, true);
            WriteAttributeValue(" ", 4066, "visibility:", 4067, 12, true);
            WriteAttributeValue(" ", 4078, "visible;", 4079, 9, true);
            WriteAttributeValue(" ", 4087, "animation-duration:", 4088, 20, true);
            WriteAttributeValue(" ", 4107, "1.5s;", 4108, 6, true);
            WriteAttributeValue(" ", 4113, "animation-delay:", 4114, 17, true);
            WriteAttributeValue(" ", 4130, "1.2s;", 4131, 6, true);
            WriteAttributeValue(" ", 4136, "animation-name:", 4137, 16, true);
            WriteAttributeValue(" ", 4152, "fadeInLeft;", 4153, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 83 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.TeamLiderPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>development</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 4791, "\"", 4942, 11);
            WriteAttributeValue("", 4799, "width:", 4799, 6, true);
#nullable restore
#line 92 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 4805, Model.TeacherDetail.DevlopemntPoint, 4806, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4842, "%;", 4842, 2, true);
            WriteAttributeValue(" ", 4844, "visibility:", 4845, 12, true);
            WriteAttributeValue(" ", 4856, "visible;", 4857, 9, true);
            WriteAttributeValue(" ", 4865, "animation-duration:", 4866, 20, true);
            WriteAttributeValue(" ", 4885, "1.5s;", 4886, 6, true);
            WriteAttributeValue(" ", 4891, "animation-delay:", 4892, 17, true);
            WriteAttributeValue(" ", 4908, "1.2s;", 4909, 6, true);
            WriteAttributeValue(" ", 4914, "animation-name:", 4915, 16, true);
            WriteAttributeValue(" ", 4930, "fadeInLeft;", 4931, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 93 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.DevlopemntPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>design</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 5565, "\"", 5712, 11);
            WriteAttributeValue("", 5573, "width:", 5573, 6, true);
#nullable restore
#line 102 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 5579, Model.TeacherDetail.DesingPoint, 5580, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5612, "%;", 5612, 2, true);
            WriteAttributeValue(" ", 5614, "visibility:", 5615, 12, true);
            WriteAttributeValue(" ", 5626, "visible;", 5627, 9, true);
            WriteAttributeValue(" ", 5635, "animation-duration:", 5636, 20, true);
            WriteAttributeValue(" ", 5655, "1.5s;", 5656, 6, true);
            WriteAttributeValue(" ", 5661, "animation-delay:", 5662, 17, true);
            WriteAttributeValue(" ", 5678, "1.2s;", 5679, 6, true);
            WriteAttributeValue(" ", 5684, "animation-name:", 5685, 16, true);
            WriteAttributeValue(" ", 5700, "fadeInLeft;", 5701, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 103 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.DesingPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>innovation</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 6335, "\"", 6486, 11);
            WriteAttributeValue("", 6343, "width:", 6343, 6, true);
#nullable restore
#line 112 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 6349, Model.TeacherDetail.InnovationPoint, 6350, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6386, "%;", 6386, 2, true);
            WriteAttributeValue(" ", 6388, "visibility:", 6389, 12, true);
            WriteAttributeValue(" ", 6400, "visible;", 6401, 9, true);
            WriteAttributeValue(" ", 6409, "animation-duration:", 6410, 20, true);
            WriteAttributeValue(" ", 6429, "1.5s;", 6430, 6, true);
            WriteAttributeValue(" ", 6435, "animation-delay:", 6436, 17, true);
            WriteAttributeValue(" ", 6452, "1.2s;", 6453, 6, true);
            WriteAttributeValue(" ", 6458, "animation-name:", 6459, 16, true);
            WriteAttributeValue(" ", 6474, "fadeInLeft;", 6475, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 113 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.InnovationPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""skill-bar-item"">
                                <span>communication</span>
                                <div class=""progress"">
                                    <div data-wow-delay=""1.2s"" data-wow-duration=""1.5s""");
            BeginWriteAttribute("style", " style=\"", 7116, "\"", 7269, 11);
            WriteAttributeValue("", 7124, "width:", 7124, 6, true);
#nullable restore
#line 122 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 7130, Model.TeacherDetail.ComunicationPoint, 7131, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7169, "%;", 7169, 2, true);
            WriteAttributeValue(" ", 7171, "visibility:", 7172, 12, true);
            WriteAttributeValue(" ", 7183, "visible;", 7184, 9, true);
            WriteAttributeValue(" ", 7192, "animation-duration:", 7193, 20, true);
            WriteAttributeValue(" ", 7212, "1.5s;", 7213, 6, true);
            WriteAttributeValue(" ", 7218, "animation-delay:", 7219, 17, true);
            WriteAttributeValue(" ", 7235, "1.2s;", 7236, 6, true);
            WriteAttributeValue(" ", 7241, "animation-name:", 7242, 16, true);
            WriteAttributeValue(" ", 7257, "fadeInLeft;", 7258, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                        <span class=\"text-top\">");
#nullable restore
#line 123 "D:\P320\4. ASP .NET\2. MVC\BackEnd Final Project\EduHome-BackEnd-project\EduHome\EduHome\Views\Teacher\Detail.cshtml"
                                                          Write(Model.TeacherDetail.ComunicationPoint);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>   
                </div>     
            </div>
        </div>
    </div>
</div>
<!-- Teacher End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
