    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace ProductsCategories.Models
    
    {
        public class Product
        {
           [Key]
           public int ProductId {get;set;}
           public string Name {get;set;}
           public string Desc {get;set;}
           public decimal Price {get;set;}
           public DateTime CreatedAt {get;set;} = DateTime.Now;
           public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }