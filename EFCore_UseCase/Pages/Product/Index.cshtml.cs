using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        private IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [BindProperty]
        public List<ProductViewModel> ProductViewModels { get; set; }

        public void OnGet(ProductSearchModel searchModel)
        {

            ProductViewModels = _productApplication.Search(searchModel);

        }

        public IActionResult OnPostRestore(int id)
        {

            _productApplication.Restore(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRemove(int id)
        {
            _productApplication.Remove(id);
            return RedirectToPage("index");
        }
    }
}
