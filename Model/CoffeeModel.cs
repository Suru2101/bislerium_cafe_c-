using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    // Models for CoffeeType and AddIn
    public class CoffeeType
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<AddIn> AddIns { get; set; } = new List<AddIn>();
    }

    public class AddIn
    {
        // public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
    }

    public class OrderItem
    {
        public CoffeeType CoffeeType { get; set; }
        public int Quantity { get; set; }
        public List<AddIn> SelectedAddIns { get; set; } = new List<AddIn>();
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } // Add this line to track the order date

        // ... other properties or methods
    }
}
