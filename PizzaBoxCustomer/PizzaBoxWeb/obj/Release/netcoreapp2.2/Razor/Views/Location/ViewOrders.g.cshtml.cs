#pragma checksum "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "463b8ca8c4b9daf3a638b3955acf46a9a47da01d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_ViewOrders), @"mvc.1.0.view", @"/Views/Location/ViewOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Location/ViewOrders.cshtml", typeof(AspNetCore.Views_Location_ViewOrders))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"463b8ca8c4b9daf3a638b3955acf46a9a47da01d", @"/Views/Location/ViewOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f535ef4202bc57660f18a2cfb9cacecd4c46953f", @"/Views/_ViewImports.cshtml")]
    public class Views_Location_ViewOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PizzaBoxWeb.Models.OrderModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
  
    ViewData["Title"] = "ViewOrders";

#line default
#line hidden
            BeginContext(97, 33, true);
            WriteLiteral("\r\n<h1>View Orders</h1>\r\n<table>\r\n");
            EndContext();
#line 8 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(171, 77, true);
            WriteLiteral("        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(249, 40, false);
#line 13 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
               Write(Html.DisplayNameFor(model => model.cost));

#line default
#line hidden
            EndContext();
            BeginContext(289, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(357, 44, false);
#line 16 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
               Write(Html.DisplayNameFor(model => model.username));

#line default
#line hidden
            EndContext();
            BeginContext(401, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(469, 45, false);
#line 19 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
               Write(Html.DisplayNameFor(model => model.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(514, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(582, 47, false);
#line 22 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
               Write(Html.DisplayNameFor(model => model.OrderStatus));

#line default
#line hidden
            EndContext();
            BeginContext(629, 137, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(767, 39, false);
#line 29 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.cost));

#line default
#line hidden
            EndContext();
            BeginContext(806, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(862, 43, false);
#line 32 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.username));

#line default
#line hidden
            EndContext();
            BeginContext(905, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(961, 44, false);
#line 35 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(1005, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1061, 46, false);
#line 38 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderStatus));

#line default
#line hidden
            EndContext();
            BeginContext(1107, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 41 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
        if (item.Pizzas.Count != 0)
        {

#line default
#line hidden
            BeginContext(1191, 110, true);
            WriteLiteral("            <tr>\r\n                <th>\r\n                    Pizzas\r\n                </th>\r\n            </tr>\r\n");
            EndContext();
#line 49 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
             foreach (var p in item.Pizzas)
            {


#line default
#line hidden
            BeginContext(1365, 462, true);
            WriteLiteral(@"                <thead>
                    <tr>
                        <th>
                            Cost
                        </th>
                        <th>
                            Size
                        </th>
                        <th>
                            Crust
                        </th>
                    </tr>
                </thead>
                <tr>
                    <td>
                        ");
            EndContext();
            BeginContext(1828, 6, false);
#line 67 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                   Write(p.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(1834, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1914, 54, false);
#line 70 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                   Write(Enum.GetName(typeof(PizzaBoxDomain.PizzaSize), p.Size));

#line default
#line hidden
            EndContext();
            BeginContext(1968, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2048, 56, false);
#line 73 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                   Write(Enum.GetName(typeof(PizzaBoxDomain.PizzaCrust), p.Crust));

#line default
#line hidden
            EndContext();
            BeginContext(2104, 255, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            Toppings\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n");
            EndContext();
#line 83 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                foreach (var t in p.toppings)
                {

#line default
#line hidden
            BeginContext(2425, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2510, 1, false);
#line 87 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                       Write(t);

#line default
#line hidden
            EndContext();
            BeginContext(2511, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 90 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
                }
            }

#line default
#line hidden
#line 91 "D:\Revature\PizzaBox\PizzaBoxCustomer\PizzaBoxWeb\Views\Location\ViewOrders.cshtml"
             
        }
    }

#line default
#line hidden
            BeginContext(2623, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PizzaBoxWeb.Models.OrderModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
