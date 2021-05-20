using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Infra.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infra.EFCore
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options):base(options)
        {

        }

        public DbSet<Product> Products  { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var assembly =typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
           
            base.OnModelCreating(modelBuilder);
        }


    }
}
