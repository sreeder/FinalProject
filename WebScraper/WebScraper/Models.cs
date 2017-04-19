using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{

    public class Product
    {
        public string Title { get; set; }
        public string TitleSearch { get; set; }
        public string Description { get; set; }
        public string UPC { get; set; }

        public int PlatformID { get; set; }
        public Platform Platform { get; set; }
        public Price Price { get; set; }
    }

    public class Platform
    {
        public int PlatformID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class Price
    {
        public int ProductID { get; set; }
        public decimal PriceNew { get; set; }
        public decimal PriceUsed { get; set; }
    }

}
