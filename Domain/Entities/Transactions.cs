namespace Domain.Entities;
public class Transaction
{
    public int ID{get;set;}
    public string Resipent {get;set;}
    public int  Comission  {get;set;}
    public DateTime CreatedAt{get;set;}
    public Status Status {get;set;}
    public decimal Amount{get;set;}
    public PaymentMethod PaymentMethod{get;set;}
    public string Sender{get;set;}
    public PaymentType PaymentType {get;set;}
    public int AcountId{get;set;}
    public Acount Acount{get;set;}

}
 public enum Status 
{
Succes,Failed,InProgres
}
public enum PaymentMethod {
    Wallet,Card,Bonus

}
public enum PaymentType
{
    TopUp,TopOff
}
