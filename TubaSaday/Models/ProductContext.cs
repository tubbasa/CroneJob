using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TubaSaday.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(): base("Context")
        {
            Database.SetInitializer<ProductContext>(new CreateDatabaseIfNotExists<ProductContext>());
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}