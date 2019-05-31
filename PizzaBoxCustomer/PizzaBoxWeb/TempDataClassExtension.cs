using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using PizzaBoxWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxWeb
{
    public static class TempDataClassExtension
    {
        public static void put(this ITempDataDictionary TD, string k, OrderModel model)
        {
            TD[k] = JsonConvert.SerializeObject(model);
        }

        public static OrderModel get(this ITempDataDictionary TD, string k)
        {
            object obj;
            TD.TryGetValue(k, out obj);
            return obj == null ? null : JsonConvert.DeserializeObject<OrderModel>((string)obj);
        }

        public static OrderModel peek(this ITempDataDictionary TD, string k)
        {
            object obj = TD.Peek(k);
            return obj == null ? null : JsonConvert.DeserializeObject<OrderModel>((string)obj);
        }
    }
}
