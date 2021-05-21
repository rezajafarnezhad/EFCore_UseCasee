using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {

        public CreateProductCategory CreateProductCategory { get; set; }

        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public IActionResult OnGet()
        {
            ViewData["error"] = false;
            return Page();
        }

        public IActionResult OnPost(CreateProductCategory commend)
        {
          
            _productCategoryApplication.Create(commend);
            return RedirectToPage("Index");
        }
    }
}
