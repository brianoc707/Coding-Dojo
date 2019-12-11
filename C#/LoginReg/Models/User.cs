    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace LoginReg.Models
    
    {
        public class User
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int UserId { get; set; }
            [Required]
            [MinLength(2)]
            public string FirstName { get; set; }
            [Required]
            [MinLength(2)]
            public string LastName { get; set; }
            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Required]
            [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [NotMapped]
            [Compare("Password")]
            [DataType(DataType.Password)]
            public string ConfirmPW {get;set;}
           
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }