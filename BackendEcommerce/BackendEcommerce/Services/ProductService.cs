using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using System.Web.Http;

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
        public bool ProductExist(int id)
        {
            return context.Users.Any(p => p.Id == id);
        }
        public Product AddProduct(Product product)
        {

            context.Products.Add(product);
            context.SaveChanges();
            return product;

        }
        public Product UpdateProduct(Product product,int id)
        {
            Product UpdateProduct = GetProduct(id);
            if (UpdateProduct != null)
            {
            }
                return null;
        }
        public Product DeleteProduct(int id) {
            var product=GetProduct(id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
            return product;}

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
