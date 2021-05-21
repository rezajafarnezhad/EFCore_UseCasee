using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_UseCase.Pages.Product
{
    public class CreateModel : PageModel
    {

        public CreateProduct CreateProduct { get; set; }
        public SelectList Categories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public IActionResult OnGet()
        {
            Categories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
            return Page();
        }

        public IActionResult OnPost(CreateProduct commend)
        {

            _productApplication.Create(commend);
            return RedirectToPage("Index");
        }
    }
}
