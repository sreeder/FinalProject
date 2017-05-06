using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Scraper;
using Domain.Entities;

namespace UnitTest
{
   
    [TestClass]
    public class ScrapeTest
    {
        public static Dictionary<int, Platform> Platforms = new Dictionary<int, Platform>
        {
            { 1, new Platform { PlatformID = 1, Name = "Nintendo 64", Abbreviation = "N64" } },
            { 2, new Platform { PlatformID = 2, Name = "Nintendo", Abbreviation = "NES" } },
            { 3, new Platform { PlatformID = 3, Name = "Super Nintendo", Abbreviation = "SNES" } },
            { 4, new Platform { PlatformID = 4, Name = "Wii U", Abbreviation = "wiiu" } }
        };

        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                Title = "Legend of Zelda:Ocarina of Time",
                TitleSearch = "LegendofZeldaOcarinaofTime",
                UPC = "045496870041",
                
                PlatformID = 1,
                Platform = Platforms[1],
                Price = new Price
                {
                    PriceNew = 5.99M,
                    PriceUsed = 3.99M
                }
            },

            new Product
            {
                Title = "Assassin's Creed 3",
                TitleSearch = "AssassinsCreed3",
                UPC = "008888187233",
                
                PlatformID = 4,
                Platform = Platforms[4],
                Price = new Price
                {
                    PriceNew = 50M,
                    PriceUsed = 29.99M
                }
            }
        };


        [TestMethod]
        public void generateURL()
        {
            string upc = Products[0].UPC;
            PCWebScraper pc = new PCWebScraper();
            string url=pc.GetURL(upc);
            
            Assert.AreEqual(url, "https://www.pricecharting.com/search-products?q=045496870041&type=videogames&go=Go");
            

        }
        [TestMethod]

        public void FindZelda()
        {
            //Mock<Product> mock = new Mock<Product>();
            //mock.Setup(m => m).Returns(
            //   Products[0]);
            Product p = Products[0];

            PCWebScraper pc = new PCWebScraper();
            Dictionary<string, decimal> answer = pc.GetPrices(p);
            Assert.AreEqual(answer.Count, 4);

        }

        [TestMethod]
        public void FindAssassins()
        {
            //Mock<Product> mock = new Mock<Product>();
            //mock.Setup(m => m).Returns(
            //   Products[0]);
            Product p = Products[1];

            PCWebScraper pc = new PCWebScraper();
            Dictionary<string, decimal> answer = pc.GetPrices(p);
            Assert.AreEqual(answer.Count, 4);

        }

    }
}
// Testing to see if I can make changes -Shad