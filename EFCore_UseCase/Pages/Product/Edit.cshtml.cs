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
    public class EditModel : PageModel
    {

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public EditProduct EditProduct { get; set; }
        public SelectList Categories;

        public IActionResult OnGet(int id)
        {
            EditProduct = _productApplication.GetProductForEdit(id);
            Categories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
            return Page();
        }


        public IActionResult OnPost(EditProduct command)
        {

            _productApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
