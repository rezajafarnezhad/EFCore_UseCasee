using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infra.EFCore.Repository
{
    public class ProductRepo : IProductRepo
    {

        private readonly EFContext _context;

        public ProductRepo(EFContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public bool Exists(string name, int categoryid)
        {
            return _context.Products.Any(c => c.Name == name && c.CategoryId == categoryid);
        }

        

        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(c=> c.category).Select(c => new ProductViewModel()
            {
                Id = c.Id,
                Name=c.Name,
                UnitPrice=c.UnitPrice,
                IsRemove=c.IsRemoved,
                CreationDate=c.CreationDate.ToString("dd/MM/yyyy"),
                Category =c.category.Name
            });

            if (searchModel.IsRemoved==true)
            {
                query = query.Where(c => c.IsRemove == true);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(c => c.Name.Contains(searchModel.Name));
            }

            return query.OrderByDescending(c => c.Id).AsNoTracking().ToList();

        }

        

    }
}
