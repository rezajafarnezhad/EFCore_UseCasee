using EFCore.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductAgg
{

    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime CreationDate { get; private set; }

        public int CategoryId { get; set; }

        public ProductCategory category { get; set; }

        public Product(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
        }


        public void Edit(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
