using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public Edit Edit{ get; set; }

        public IActionResult OnGet(int id)
        {
            Edit = _productCategoryApplication.GetForEdit(id);
            return Page();
        }

        public IActionResult OnPost(Edit command)
        {
         
            _productCategoryApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
