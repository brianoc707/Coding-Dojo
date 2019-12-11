    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace ProductsCategories.Models
    
    {
        public class Category
        {
           [Key]
           public int CategoryId {get;set;}
           public string Name {get;set;}
           public DateTime CreatedAt {get;set;} = DateTime.Now;
           public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }