using BackendEcommerce.Models;

namespace BackendEcommerce.Repositories
{
    public interface ProductCategoryRepository
    {
        ICollection<ProductCategory> GetCategory();
    }
}
