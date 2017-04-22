using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Platform
    {
        [HiddenInput(DisplayValue = false)]
        public int PlatformID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        public string Abbreviation { get; set; }
       


    }
}
