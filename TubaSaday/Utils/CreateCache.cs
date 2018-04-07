using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using TubaSaday.Models;

namespace TubaSaday.Utils
{
    public static class CreateCache
    {
        public static Cache cache = new Cache();

        public static void Create()
        {

            if (cache["Products"] == null)
            {

                ProductContext _con = new ProductContext();
                var products = _con.Product.ToList();
                cache.Insert("Products", products, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);  //absolute time caching

            }
        }
    }
}