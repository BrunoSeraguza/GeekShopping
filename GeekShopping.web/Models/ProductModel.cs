namespace GeekShopping.web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

    }
}
