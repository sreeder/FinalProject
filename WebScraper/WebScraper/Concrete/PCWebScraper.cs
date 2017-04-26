﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAP = HtmlAgilityPack;
//using Scraper.Abstract;
using Domain.Entities;

namespace Scraper
{
    public class PCWebScraper
    {
        public Dictionary<string, decimal> GetPrices(Product product)
        {
            var url= GetURL(product.UPC);
            using (var client = new System.Net.WebClient())
            {
                var filename = System.IO.Path.GetTempFileName();

                client.DownloadFile(url, filename);

                var doc = new HAP.HtmlDocument();
                doc.Load(filename);

                var root = doc.DocumentNode;

                //var a_nodes = root.Descendants("a").ToList();
                var table = root.Descendants("tr").ToList();//.SelectNodes("//*[contains(@class,'price')]").ToList();
                //var div_nodes = .SelectNodes("//*[contains(@class,'price')]");

                foreach (var node in table)
                {
                    Console.WriteLine();
                    Console.WriteLine(node);
                    //Console.WriteLine("LINK: {0}", node.GetAttributeValue("href", ""));
                    node.GetAttributeValue("data-source-name", "");
                    Console.WriteLine("TEXT: {0}", node.InnerText.Trim());
                }
            }



            return new Dictionary<string, decimal>();
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
