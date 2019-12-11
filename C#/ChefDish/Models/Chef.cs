    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace ChefDish.Models
    {
        public class Chef
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int ChefId { get; set; }
            
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public int Age { get; set; }
            
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;}
            public DateTime UpdatedAt {get;set;}
        }

        
    }