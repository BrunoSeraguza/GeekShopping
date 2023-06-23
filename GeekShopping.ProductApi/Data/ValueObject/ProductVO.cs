using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductApi.Data.ValueObject
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }       
        public decimal Value { get; set; }      
        public string Description { get; set; }        
        public string CategoryName { get; set; }      
        public string ImageUrl { get; set; }

    }
}
