    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace ChefDish.Models
    {
        public class Dish
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int DishId { get; set; }
            
            [Required]// MySQL VARCHAR and TEXT types can be represeted by a string
            public string Name { get; set; }
            public Chef Creator { get; set; }
            [Required]
            public int Tastiness { get; set; }
            [Required]
            public int Calories { get; set; }
            [Required]
            public string Description { get; set; }
            
            public int ChefId { get; set; }
            
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;}
            public DateTime UpdatedAt {get;set;}
        }

        
    }