namespace Domain.Dtos;
using Domain.Entities;
public class AddAccount{
 public int AccountId {get;set;}

    public string Name{get;set;}
    public string Surname{get;set;}
    public bool Autenticated{get;set;}
    public string PhoneNumber{get;set;}
}
public class GetAccount{ 
     public int AccountId {get;set;}
    public string Name{get;set;}
    public string Surname{get;set;}
    public bool Autenticated{get;set;}
    public string PhoneNumber{get;set;}
}
public class CheckAccount
{
    public string Checkaccount { get; set; }
}