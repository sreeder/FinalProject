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

                var root = doc.DocumentNode;






                //var a_nodes = root.Descendants("a").ToList();
                //var table = root.Descendants("//table[@id='']/tr/td").ToList();
                //.SelectNodes("//*[contains(@class,'price')]").ToList();
                //var div_nodes = .SelectNodes("//*[contains(@class,'price')]");
                //var table = root.Descendants("//div[contains(@class, 'tab-frame']").ToList();//"/table/tr").ToList();
                var table = root.Descendants("div").ToList();//div 18
                var findclasses =
                    doc.DocumentNode.Descendants("tr").Where(d => d.Attributes.Contains("data-source-name")).ToList();
                //&& d.Attributes["class"].ToString().Contains("float")).ToList();

                //foreach (HAP.HtmlNode row in doc.DocumentNode.Descendants("table"))

                //foreach (HtmlNode row in doc.DocumentNode.SelectNodes("//table[@id='table2']//tr"))
                //    foreach (HtmlNode col in row.SelectNodes("td"))
                //        Response.Write(col.InnerText);

                //.SelectNodes("//table[@id='table2']//tr"))
                //foreach (HAP.HtmlNode row in doc.DocumentNode.SelectNodes("//table[@id='table2']//tr"))



                
                var table2 = doc.DocumentNode.SelectSingleNode("//div[@id = 'price_comparison']");
                //var nodes =  table2.SelectNodes(".//table//tr");
                var certainTd = table2.SelectSingleNode(".//tbody[1]");
                var certainNodes = certainTd.SelectNodes(".//tr");



                //foreach (HAP.HtmlNode row in doc.DocumentNode.SelectNodes("//table//tr"))
                foreach (HAP.HtmlNode row in certainNodes)
                {
                    
                    var location= row.GetAttributeValue("data-source-name", "");
                    var col = row.SelectSingleNode("//td[@class ='price']");
                    
                    if (col != null)
                    {
                        var val = col.InnerHtml;
                        var price = Convert.ToDecimal(val.Replace('$', ' ').Trim());
                        //foreach (HAP.HtmlNode col in cols)
                        //{

                        //    Console.WriteLine(location);
                        //    Console.WriteLine(col.InnerHtml.Trim());
                        //}
                        values.Add(location, price);
                    }
                }
                

                //foreach (var node in table)
                //{
                //    Console.WriteLine();
                //    Console.WriteLine(node);
                //    //Console.WriteLine("LINK: {0}", node.GetAttributeValue("href", ""));
                //    node.GetAttributeValue("data-source-name", "");
                //    Console.WriteLine("TEXT: {0}", node.InnerText.Trim());
                //}
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
