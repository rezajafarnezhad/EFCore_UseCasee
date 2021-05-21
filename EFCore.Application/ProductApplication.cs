using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application
{
    public class ProductApplication: IProductApplication
    {
        private readonly IProductRepo _productRepo;

        public ProductApplication(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public void Create(CreateProduct command)
        {
            if (_productRepo.Exists(command.Name,command.CategoryId))
            {
                return;
            }

            var Product = new Product(command.Name, command.UnitPrice, command.CategoryId);
            _productRepo.Create(Product);
            _productRepo.Save();
        }

        public void Edit(EditProduct command)
        {
            var product = _productRepo.GetProduct(command.Id);
            if (product == null)
            {
                return;
            }
            product.Edit(command.Name, command.UnitPrice, command.CategoryId);
            _productRepo.Save();
        }

        public EditProduct GetProductForEdit(int id)
        {
            var product = _productRepo.GetProduct(id);
            return new EditProduct()
            {
                Id = product.Id,
                CategoryId=product.CategoryId,
                Name=product.Name,
                UnitPrice=product.UnitPrice
            };
        }

        public void Remove(int id)
        {
            var product = _productRepo.GetProduct(id);
            product.Remove();
            _productRepo.Save();
        }

        public void Restore(int id)
        {
            var product = _productRepo.GetProduct(id);
            product.Restore();
            _productRepo.Save();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepo.Search(searchModel);
        }
    }
}
