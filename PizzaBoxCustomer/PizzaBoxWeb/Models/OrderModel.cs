using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxWeb.Models
{
    public class OrderModel
    {
        [DisplayName("Cost")]
        public decimal cost { get; set; }
        [DisplayName("User")]
        public string username { get; set; }
        [DisplayName("Location")]
        public string locationAddress { get; set; }
        [DisplayName("Order Time")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Status")]
        public string OrderStatus { get; set; }
        public List<PizzaModel> Pizzas { get; set; }

        public OrderModel()
        {
            Pizzas = new List<PizzaModel>();
        }
    }
}
