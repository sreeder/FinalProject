using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebScraper;

namespace UnitTest1
{
   
    [TestClass]
    public class UnitTest1
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
                Age = 6,
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
                Age = 1,
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
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void FindZelda()
        {
            Mock<Item> mock = new Mock<Item>();
            Mock.Setup(m => m.item).Returns(
               Products[0]);

                
        }
    }
}
// Testing to see if I can make changes -Shad