using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {

        void Create(CreateProductCategory command);
        void Edit(Edit command);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> Search(string name);
        Edit GetForEdit(int id);
        
    }
}
