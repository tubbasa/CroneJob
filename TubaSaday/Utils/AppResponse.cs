using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TubaSaday.Models;

namespace TubaSaday.Utils
{
    public class AppResponse
    {
        public string type { get; set; }
        public List<Product> products{ get; set; }  
    }
}