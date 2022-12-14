using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BackendEcommerce.Services
{
    public class ProductService:ProductRepository
    {
        private readonly AppDbContext context;
        public ProductService(AppDbContext context) {
            this.context = context;
        }
        public ICollection<Product> GetProducts()
        {
            return context.Products.OrderBy(p=>p.Id).ToList();
        }
        public Product GetProduct(int id) {
            return context.Products.Where(p => p.Id == id).FirstOrDefault();
        }
        public Product GetProduct(string name)
        {
            return context.Products.Where(p => p.Name == name).FirstOrDefault();
        }
        public decimal GetProductPrice(int id) {
            var result =context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (result == null)
                return -1;
            return result.Price;
        }
        public decimal GetProductRating(int id) {
            var review = context.Reviews.Where(p => p.Product.Id == id);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating)! / review.Count());
        }
    }
}
