using BackendEcommerce.Models;

namespace BackendEcommerce.Repositories
{
    public interface ProductRepository
    {
        ICollection<Product> GetProducts();

        Product GetProduct(int id);
        Product GetProduct(string name);

        public decimal GetProductPrice(int id);
        public decimal GetProductRating(int id);
    }
}
