    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace BankAccounts.Models
    
    {
        public class Transaction
        {
           [Key]
           public int TransactionId {get;set;}

           [Required]
           public decimal Amount {get;set;}
            
           public int UserId {get;set;}
           public User AccountHolder {get;set;}
          
           
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }