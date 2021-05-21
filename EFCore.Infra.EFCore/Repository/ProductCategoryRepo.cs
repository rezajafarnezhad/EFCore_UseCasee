using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infra.EFCore.Repository
{
    public class ProductCategoryRepo : IProductCategoryRepo
    {
        private readonly EFContext _context;

        public ProductCategoryRepo(EFContext context)
        {
            _context = context;
        }

        public void Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
        }

        public bool Exists(string name)
        {
            return _context.ProductCategories.Any(c => c.Name == name);
        }

        public List<ProductCategoryViewModel> GetAll()
        {

            return _context.ProductCategories.Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name=c.Name,
                CreationDate=c.CreationDate.ToString()
            }).ToList();   
         
        }

        public ProductCategory GetProductCategory(int ProductCategoryId)
        {
            return _context.ProductCategories.Find(ProductCategoryId);
        }

      

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _context.ProductCategories
                .Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name=c.Name,
                CreationDate=c.CreationDate.ToString("dd/MM/yyyy"),

            });

            if(!string.IsNullOrWhiteSpace(name))
                query = query.Where(c => c.Name.Contains(name));

            return query.OrderByDescending(c => c.Id).ToList();
        }
    }
}
