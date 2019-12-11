using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        public string Name {get;set;}
        [Required]
        public string Chef {get;set;}
        [Required]
        public int Tastiness {get;set;}
        [Required]
        [Range (0,10000)]
        public int Calories {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}