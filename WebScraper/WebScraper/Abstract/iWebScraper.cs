using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Abstract
{
    abstract class iWebScraper
    {
        public string GetURL(String upc)
        {
            throw new NotImplementedException();
        }
    }
}
