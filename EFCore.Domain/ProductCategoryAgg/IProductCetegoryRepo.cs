using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCetegoryRepo
    {
        void Create(ProductCategory productCategory);
        ProductCategory GetProductCategory(int ProductCategoryId);
        List<ProductCategory> GetProductsCategory();
        void Save();

    }
}
