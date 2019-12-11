    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace ProductsCategories.Models
    
    {
        public class Association
        {
           [Key]
           public int AssociationId {get;set;}
           public string Name {get;set;}
           public int ProductId {get;set;}
           public int CategoryId {get;set;}
           public Product
           public Category
        }
    }