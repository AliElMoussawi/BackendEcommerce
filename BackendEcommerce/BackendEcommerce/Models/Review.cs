namespace BackendEcommerce.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public Product? Product{ get; set; }
        public User? User { get; set; }
        }
}
