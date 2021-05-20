﻿using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace EFCore.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepo _ProductCategoryRepo;

        public ProductCategoryApplication(IProductCategoryRepo productCategoryRepo)
        {
            _ProductCategoryRepo = productCategoryRepo;
        }

        public void Create(CreateProduct command)
        {
            if (_ProductCategoryRepo.Exists(command.Name))
            {
                return;
            }
            var productCategory = new ProductCategory(command.Name);
            _ProductCategoryRepo.Create(productCategory);
            _ProductCategoryRepo.Save();
        }

        public void Edit(Edit command)
        {
            var productCategory = _ProductCategoryRepo.GetProductCategory(command.Id);
            productCategory.Edit(command.Name);
            _ProductCategoryRepo.Save();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _ProductCategoryRepo.Search(name);
        }
    }
}