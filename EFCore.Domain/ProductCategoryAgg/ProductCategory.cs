using EFCore.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }

        public List<Product> Products { get; set; }

        public ProductCategory(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Products = new List<Product>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
