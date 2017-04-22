using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Title { get; set; }
        public string TitleSearch { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string UPC { get; set; }
        public string Description { get; set; }      
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int PlatformID { get; set; }
  
        public virtual Platform Platform { get; set; }
       
        public virtual Price Price { get; set; }
    }
}
