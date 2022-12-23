namespace Domain.Entities;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
 public class Acount
 {
    [Key]
    public int AccountId {get;set;}
    public string Name{get;set;}
    public string Surname{get;set;}
    public bool Autenticated{get;set;}
    public string PhoneNumber{get;set;}
    public List<Transaction> Transactions;
 

}