
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model.Context
{
    [Table("Products")]
    public class Product  
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
   

        [Column("Value")]
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Value { get; set; }

        [Column("Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column("Category_Name")]
        [Required]
        [StringLength(500)]
        public string CategoryName { get; set; }

        [Column("Image_Url")][Required]
        [StringLength(300)]
        public string  ImageUrl { get; set; }



    } 
}
    

