#pragma checksum "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\Orders\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b42eee09ccdcb20b5aa78553dfd6c14f386bf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Orders_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Orders/Delete.cshtml")]
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
#line 1 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\_ViewImports.cshtml"
using Shop101V3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\_ViewImports.cshtml"
using Shop101V3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\_ViewImports.cshtml"
using Shop101V3.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b42eee09ccdcb20b5aa78553dfd6c14f386bf9", @"/Areas/Admin/Views/Orders/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e6e93d203da55e2a9aebdb9d8b638c22f3dfb52", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Orders_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Are you sure to delete this <b>ORDER</b></h1>\r\n\r\n\r\n        <p>Address : ");
#nullable restore
#line 5 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\Orders\Delete.cshtml"
                Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Email : ");
#nullable restore
#line 6 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\Orders\Delete.cshtml"
              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Description : ");
#nullable restore
#line 7 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\Orders\Delete.cshtml"
                    Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 198, "\"", 244, 2);
            WriteAttributeValue("", 205, "/admin/orders/deleteconfirmed/", 205, 30, true);
#nullable restore
#line 8 "C:\Users\Asus\source\repos\Shop101V3\Shop101V3\Areas\Admin\Views\Orders\Delete.cshtml"
WriteAttributeValue("", 235, Model.Id, 235, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
