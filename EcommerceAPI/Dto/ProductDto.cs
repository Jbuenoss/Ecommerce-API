using EcommerceAPI.Data.Enums;

namespace EcommerceAPI.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public ProductCategory Category { get; set; }
        //to promotion products
        public bool IsOnPromotion { get; set; }
        public double PromotionPrice { get; set; }
    }
}
