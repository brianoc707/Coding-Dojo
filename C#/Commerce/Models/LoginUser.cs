using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Commerce.Models
{
    public class LoginUser
    {
    public string Email {get; set;}
    public string Password { get; set; }
    }
}