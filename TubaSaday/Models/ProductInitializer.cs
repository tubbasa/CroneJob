using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TubaSaday.Models
{
    public class ProductInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            // we are inserting mock data
            var products = new List<Product>
            {
            new Product{Name= "Elektrikli Süpürge",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Pipet",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Su",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Kuru Mama",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Yaş Mama",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Çıngıraklı Top",LastUpdatedTime= DateTime.Now.AddMinutes(-11)},
            new Product{Name= "Tabak",LastUpdatedTime= DateTime.Now.AddMinutes(-11)}
            };
            products.ForEach(s => context.Product.Add(s));
            context.SaveChanges();
           
        }

    }
}