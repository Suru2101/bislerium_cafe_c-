using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class CustomerOrderDetails
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<OrderItem> Orders { get; set; }
        public int PurchaseCount { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public int FreeCoffeeCountReceived { get; set; }
        public List<FreeCoffeeHistory> FreeCoffeeHistory { get; set; } = new List<FreeCoffeeHistory>();
        public bool WantsFreeCoffeeNow { get; set; }
        //  property to track if the customer has been prompted
        public bool HasDiscount { get; set; }
    }

    public class FreeCoffeeHistory
    {
        public DateTime RedeemDate { get; set; }
        public int RedeemedCount { get; set; }
    }
}
