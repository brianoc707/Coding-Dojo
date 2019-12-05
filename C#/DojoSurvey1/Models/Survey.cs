using System.ComponentModel.DataAnnotations;
namespace DojoSurvey1.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
        public string Name {get;set;}
        [Required]
        public string Location {get;set;}
        [Required]
        public string Language {get;set;}
        [MaxLength(20, ErrorMessage = "Comment can not exceed 20 characters")]
        public string Comment {get;set;}

        
    }
   
    
}