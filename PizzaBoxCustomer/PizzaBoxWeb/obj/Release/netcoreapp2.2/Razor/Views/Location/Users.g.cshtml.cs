#pragma checksum "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f85ba20042bb9f4e41234e1208a9bb3d5b37add"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_Users), @"mvc.1.0.view", @"/Views/Location/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Location/Users.cshtml", typeof(AspNetCore.Views_Location_Users))]
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
#line 1 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\_ViewImports.cshtml"
using PizzaBoxWeb;

#line default
#line hidden
#line 2 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\_ViewImports.cshtml"
using PizzaBoxWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f85ba20042bb9f4e41234e1208a9bb3d5b37add", @"/Views/Location/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f535ef4202bc57660f18a2cfb9cacecd4c46953f", @"/Views/_ViewImports.cshtml")]
    public class Views_Location_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PizzaBoxWeb.Models.UserModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml"
  
    ViewData["Title"] = "Users";

#line default
#line hidden
            BeginContext(93, 104, true);
            WriteLiteral("\r\n<h1>Users</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(198, 44, false);
#line 13 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
            EndContext();
            BeginContext(242, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 19 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(360, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(409, 43, false);
#line 22 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml"
           Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
            EndContext();
            BeginContext(452, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 25 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\Users.cshtml"
}

#line default
#line hidden
            BeginContext(491, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PizzaBoxWeb.Models.UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
