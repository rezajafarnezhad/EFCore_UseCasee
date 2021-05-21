using EFCore.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepo
    {
        void Create(ProductCategory productCategory);
        ProductCategory GetProductCategory(int ProductCategoryId);
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();
        bool Exists(string name);
        void Save();

    }
}
