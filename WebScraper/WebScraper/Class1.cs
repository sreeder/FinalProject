using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public class Class1
    {
        public Dictionary<string, decimal> GetPrices(Product product)
        {
            return new Dictionary<string, decimal>();
        }  
        public string GetURL (Product product)
        {
            string baseURL = "https://www.pricecharting.com/game";
            baseURL += product.Platform.Name.Replace(' ', '-');

            return "";
        }
        //ebay
        //amazon
        //gamestop
        //pricecharting


    }
}
