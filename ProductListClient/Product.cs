using System;

namespace ProductList.Models
{
    public class Product
    {
        public enum UnitTypes
        {
            Item, Meter, Box, Roll, Sheet
        }

        public enum CategoryTypes
        {
            Electrical, Equipment, Building, Cables
        }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public CategoryTypes Category { get; set; }
        public UnitTypes Unit { get; set; }

        public decimal ProductPrice { get; set; }
    }

}
