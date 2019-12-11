
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace chefDish2.Models
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
            [Over18]
            public DateTime Age { get; set; }

            public List<Dish> Dishes { get; set; }
            
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }

        public class Over18Attribute : ValidationAttribute
        {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
            DateTime today = DateTime.Today;

            if(today.AddYears(-18) < (DateTime)(value))
            {
                return new ValidationResult("Chef must be over 18");
            }
            return ValidationResult.Success;
            }
        }
        
    }