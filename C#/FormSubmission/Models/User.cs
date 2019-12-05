using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First name must be 4 characters")]
        public string FirstName {get;set;}
        [Required]
        [MinLength(4, ErrorMessage = "Last name must be 4 characters")]
        public string LastName {get;set;}
        [Required]
        [Range(0,100)]
        public int Age {get;set;}
        [Required]
        [EmailAddress(ErrorMessage = "Must enter a valid email")]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage = "Must be at leat 8 characters")]
        public string Password {get;set;}
    }
   
    
}