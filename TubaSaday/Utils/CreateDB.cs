using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TubaSaday.Models;

namespace TubaSaday.Utils
{
    public static class CreateDB
    {
        public static ProductContext db { get; set; }

      
        public static void create()
        {
            try
            {
                //we are calling product context
                db = new ProductContext();
                //and we are creating db with first query
                var products = db.Product.ToList();
                //' are creating cache first time
                CreateCache.Create();
                //return "ok";
               
            }
	        catch (Exception e)
	        {

		    //return e.ToString();
	        }
        }

        public static void refreshDB()
        {

        }
    }
}