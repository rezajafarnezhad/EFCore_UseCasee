using System.Collections.Generic;

namespace EFCore.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetProductForEdit(int id);
        void Remove(int id);
        void Restore(int id);

    }
}
