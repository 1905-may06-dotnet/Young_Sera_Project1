#pragma checksum "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3d7d3c297ad2450e207c1f204173eacd629aa4c"
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
#line 1 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\_ViewImports.cshtml"
using PizzaBoxWeb;

#line default
#line hidden
#line 2 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\_ViewImports.cshtml"
using PizzaBoxWeb.Models;

#line default
#line hidden
#line 2 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
using PizzaBoxDomain;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d7d3c297ad2450e207c1f204173eacd629aa4c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f535ef4202bc57660f18a2cfb9cacecd4c46953f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#line 6 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
   var num = 0;

#line default
#line hidden
            BeginContext(105, 90, true);
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to Pizza Box</h1>\r\n</div>\r\n\r\n");
            EndContext();
#line 11 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(219, 53, true);
            WriteLiteral("    <div>\r\n        <hr />\r\n        <h2>Your order is ");
            EndContext();
            BeginContext(273, 17, false);
#line 15 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                     Write(Model.OrderStatus);

#line default
#line hidden
            EndContext();
            BeginContext(290, 59, true);
            WriteLiteral(".</h2>\r\n        <h3>The order location you ordered from is ");
            EndContext();
            BeginContext(350, 21, false);
#line 16 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                                              Write(Model.locationAddress);

#line default
#line hidden
            EndContext();
            BeginContext(371, 85, true);
            WriteLiteral(".</h3>\r\n        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(457, 40, false);
#line 19 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.cost));

#line default
#line hidden
            EndContext();
            BeginContext(497, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(571, 36, false);
#line 22 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(model => model.cost));

#line default
#line hidden
            EndContext();
            BeginContext(607, 36, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n");
            EndContext();
#line 25 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
         foreach (var pizza in Model.Pizzas)
        {
            { num += 1; }

#line default
#line hidden
            BeginContext(727, 23, true);
            WriteLiteral("            <h1>Pizza #");
            EndContext();
            BeginContext(751, 3, false);
#line 28 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                  Write(num);

#line default
#line hidden
            EndContext();
            BeginContext(754, 185, true);
            WriteLiteral("</h1>\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    Cost\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
            EndContext();
            BeginContext(940, 10, false);
#line 34 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
               Write(pizza.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(950, 174, true);
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Crust\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
            EndContext();
            BeginContext(1125, 45, false);
#line 40 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
               Write(Enum.GetName(typeof(PizzaCrust), pizza.Crust));

#line default
#line hidden
            EndContext();
            BeginContext(1170, 173, true);
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Size\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
            EndContext();
            BeginContext(1344, 43, false);
#line 46 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
               Write(Enum.GetName(typeof(PizzaSize), pizza.Size));

#line default
#line hidden
            EndContext();
            BeginContext(1387, 44, true);
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n");
            EndContext();
#line 49 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
            if (pizza.toppings.Count > 0)
            {
                

#line default
#line hidden
#line 51 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                 if (pizza.toppings.Count > 1)
                {

#line default
#line hidden
            BeginContext(1556, 181, true);
            WriteLiteral("                    <dl class=\"row\">\r\n                        <dt class=\"col-sm-2\">\r\n                            Toppings\r\n                        </dt>\r\n                    </dl>\r\n");
            EndContext();
#line 58 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1797, 180, true);
            WriteLiteral("                    <dl class=\"row\">\r\n                        <dt class=\"col-sm-2\">\r\n                            Topping\r\n                        </dt>\r\n                    </dl>\r\n");
            EndContext();
#line 66 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#line 67 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
         foreach (var topping in pizza.toppings)
        {

#line default
#line hidden
            BeginContext(2057, 102, true);
            WriteLiteral("                    <dl>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2160, 7, false);
#line 71 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
                       Write(topping);

#line default
#line hidden
            EndContext();
            BeginContext(2167, 60, true);
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n");
            EndContext();
#line 74 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#line 74 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
         
            }
        }

#line default
#line hidden
            BeginContext(2264, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 78 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Home\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
