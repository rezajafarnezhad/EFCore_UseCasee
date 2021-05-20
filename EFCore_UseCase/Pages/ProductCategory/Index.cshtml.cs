using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        private IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public List<ProductCategoryViewModel> productCategoryViewModels { get; set; }

        public void OnGet(string name)
        {

            productCategoryViewModels = _productCategoryApplication.Search(name);

        }
    }
}
