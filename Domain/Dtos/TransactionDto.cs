namespace Domain.Dtos;
using Domain.Entities;
public class AddTransaction
{ 
  public int ID{get;set;}
    public string Resipent{get;set;}
    public int Comission{get;set;}
    public DateTime CreatedAt{get;set;}
    public Status Status {get;set;}
    public decimal Amount{get;set;}
    public PaymentMethod PaymentMethod{get;set;}
    public string Sender{get;set;}
    public PaymentType PaymentType {get;set;}
    public int AccountId{get;set;}

}
public class GetTransaction{
     public int ID{get;set;}
    public string Resipent{get;set;}
    public int Comission{get;set;}
    public DateTime CreatedAt{get;set;}
    public Status Status {get;set;}
    public decimal Amount{get;set;}
    public PaymentMethod PaymentMethod{get;set;}
    public string Sender{get;set;}
    public  PaymentType PaymentType {get;set;}
    public int AccountId{get;set;}
}
;
public class GetBalanceDto{
    public PaymentType PaymentType {get; set;}
    public decimal Amount {get; set;}
}
public class GetTopUpBalanceDto{
    
    public string Name {get; set;}
    public string Surname {get; set;}
    public string PhoneNumber   {get; set;}
    public decimal Amount{get; set;}

}
public class AddTopUpBalanceDto{
    public int ID { get; set; }
    public string PhoneNumber {get; set;}
    public decimal Amount{get; set;}
    public PaymentMethod PaymentMethod {get; set;}
}