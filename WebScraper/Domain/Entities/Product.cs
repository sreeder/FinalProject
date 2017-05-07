using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Scraper;

namespace Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product Title")]
        public string Title { get; set; }
        public string TitleSearch { get; set; }
        public string UPC { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }      
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        [HiddenInput(DisplayValue = false)]
        //[Required]
        public int PlatformID { get; set; }

        [Required(ErrorMessage = "Please select a Platform")]
        public virtual Platform Platform { get; set; }

        [Required]
        public virtual Price Price { get; set; }

        public Dictionary<string, decimal> PriceComparison
        {
            get
            {
                PCWebScraper pc = new PCWebScraper();
                Dictionary<string, decimal> answer = pc.GetPrices(UPC);
                return answer;

            }
        }

    }
}
