using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models

{
    public class Wedding
    {
    public int WeddingId {get;set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public DateTime Date {get; set;}
    public int UserId {get;set;}
    
    public User Creator {get;set;}
    [Required]
    public string Address {get;set;}
    public List<GuestList> Guests {get;set;}
    
    


    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
            
    }
}