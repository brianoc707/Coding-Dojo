    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    namespace WeddingPlanner.Models
    
    {
        public class User
        {
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

            public List<Wedding> Planned {get;set;}

            public List <GuestList> Attending {get;set;}
            
            [Required]
            [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
           
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
            
            [NotMapped]
            [Compare("Password")]
            [DataType(DataType.Password)]
            public string ConfirmPW {get;set;}
        }
    }