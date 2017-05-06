using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Routing.Constraints;
using HAP = HtmlAgilityPack;
//using Scraper.Abstract;
using Domain.Entities;

namespace Scraper
{
    public class PCWebScraper
    {
        public Dictionary<string, decimal> GetPrices(Product product)
        {

            Dictionary<string, decimal> values = new Dictionary<string, decimal>();

            var url = GetURL(product.UPC);
            using (var client = new System.Net.WebClient())
            {
                var filename = System.IO.Path.GetTempFileName();

                client.DownloadFile(url, filename);

                var doc = new HAP.HtmlDocument();
                doc.Load(filename);

                var table2 = doc.DocumentNode.SelectSingleNode("//div[@id = 'price_comparison']");
                var certainTd = table2.SelectSingleNode(".//tbody[1]");
                var certainNodes = certainTd.SelectNodes(".//tr");


                foreach (HAP.HtmlNode row in certainNodes)
                {
                    var location= row.GetAttributeValue("data-source-name", "");
                    var col = row.SelectSingleNode("//td[@class ='price']");
                    
                    if (col != null)
                    {
                        var val = col.InnerHtml;
                        var price = Convert.ToDecimal(val.Replace('$', ' ').Trim());
                        
                        values.Add(location, price);
                    }
                }

            }

            return values;
        }  
        public string GetURL (String upc)
        {
            return string.Format("https://www.pricecharting.com/search-products?q={0}&type=videogames&go=Go", upc);
           
        }

        //htmlagility - http://viziblr.com/news/2013/3/19/a-simple-example-of-web-scraping-with-the-html-agility-pack.html
        //ebay
        //amazon-- http://docs.aws.amazon.com/AWSECommerceService/latest/DG/EX_LookupbyUPC.html
        //gamestop
        //pricecharting


    }
}
