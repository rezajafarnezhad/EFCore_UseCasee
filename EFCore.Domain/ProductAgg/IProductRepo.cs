using EFCore.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepo
    {
        void Create(Product product);
        Product GetProduct(int productId);
        List<Product> GetProducts();
        bool Exists(string name, int categoryid);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        
        void Save();
    }
}
