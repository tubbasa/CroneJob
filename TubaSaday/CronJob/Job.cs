using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;
using TubaSaday.Controllers;
using TubaSaday.Models;
using TubaSaday.Utils;
using WebGrease.Css.Extensions;

namespace TubaSaday.CronJob
{
    public class Job : IJob
    {
        private ProductContext _db;
        public void Execute(IJobExecutionContext context)
        {
            var cache = CreateCache.cache;
            var cachedProducts = cache["Products"] as List<Product>;
            _db =new ProductContext();
            //foreach (var item in dbProducts)
            //{
            //    if (!cachedProducts.Contains(item))
            //    {

            //    }
            //}
            IEnumerable<Product> differences=new List<Product>();
            if (_db != null&&cachedProducts!=null)
            {
                var min = DateTime.Now.AddMinutes(-3);
                differences = _db.Product.Where(x =>
                    x.LastUpdatedTime > min || x.LastUpdatedTime == null);
            }

            if (differences.Count() != 0)
            {
                foreach (var item in differences)
                {
                    var product = cachedProducts.FirstOrDefault(x => x.Id == item.Id);
                    if (product != null)
                    {
                        (cache["Products"] as List<Product>).Remove(product);
                        (cache["Products"] as List<Product>).Add(item);
                        
                    }
                    else
                    {
                        cachedProducts.Add(item);
                    }

                }
            }

            
            

        }
    }
}