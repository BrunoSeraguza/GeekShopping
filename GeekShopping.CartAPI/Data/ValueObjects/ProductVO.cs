﻿
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    [Table("Products")]
    public class ProductVO
    {    
        public long Id { get; set; }
        public string Name { get; set; }     
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string  ImageUrl { get; set; }
    } 
}
    

