namespace WebApplicationEXAM_N1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public List<UserToProduct> UserToProducts { get; set; }
    }
}