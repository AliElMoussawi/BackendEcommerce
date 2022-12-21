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
        public bool ProductExist(int id);
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public Product DeleteProduct(int id);
    }
}
