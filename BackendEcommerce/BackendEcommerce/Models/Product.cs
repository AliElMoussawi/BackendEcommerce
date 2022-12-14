﻿namespace BackendEcommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public ProductCategory? ProductCategory{ get; set; }
        public ICollection<Review> Reviews { get; set; }

      
    }
}
