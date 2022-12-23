using System.Net;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using AutoMapper;
namespace Infrastructure.Services;
public class TransactionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public TransactionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task<Response<List<GetTransaction>>> GetTransaction()
    {
        var list = await _context.Transactions.Select(j => new GetTransaction()
        {
            ID = j.ID,
            AccountId = j.Acount.AccountId,
            Resipent = j.Resipent,
            Comission = j.Comission,
            CreatedAt = j.CreatedAt,
            Status = j.Status,
            Amount = j.Amount,
            PaymentMethod = j.PaymentMethod,
            PaymentType = j.PaymentType
        }).ToListAsync();

        return new Response<List<GetTransaction>>(list);
    }
    public async Task<Response<GetTransaction>> InsertTransaction(AddTransaction tran)
    {
        var newTransaction = _mapper.Map<Transaction>(tran);
        //save file 
        _context.Transactions.Add(newTransaction);
        await _context.SaveChangesAsync();
        var response = _mapper.Map<GetTransaction>(newTransaction);
        return new Response<GetTransaction>(response);
    }
    public async Task<Response<GetTransaction>> UpdateTransaction(AddTransaction tran)
    {
        var find = await _context.Transactions.FindAsync(tran.ID);

        find.Comission = tran.Comission;
        find.Resipent = tran.Resipent;
        find.CreatedAt = tran.CreatedAt;
        find.Status = tran.Status;
        find.PaymentMethod = tran.PaymentMethod;
        find.PaymentType = tran.PaymentType;
        await _context.SaveChangesAsync();
        var response = _mapper.Map<GetTransaction>(find);
        return new Response<GetTransaction>(response);
    }
    public  decimal  GetBalanceFromWallet(string PhoneNumber)
    {
        var c  = (from b in _context.Transactions where b.Resipent == PhoneNumber || b.Resipent == b.Sender
                 select new GetBalanceDto
                 {
                     Amount = b.Amount
                 }
        ).ToList();
                         decimal balance = 0; 
                          foreach (var bal in c)
                          balance += bal.Amount;
                          return balance;
    }
    public async Task<Response<GetTopUpBalanceDto>> TopUpBalance(AddTopUpBalanceDto topup)
    {
                         var balance = _mapper.Map<Transaction>(topup);
               var account= _context.Acounts.FirstOrDefault(p => p.PhoneNumber == topup.PhoneNumber);
                       balance.AcountId = account.AccountId;
                       balance.Sender = topup.PhoneNumber;
                       balance.Resipent = account.PhoneNumber;
                       balance.PaymentType = PaymentType.TopUp;
                       _context.Transactions.Add(balance);
               var get = new GetTopUpBalanceDto()
        {
                Name = account.Name,
               Surname = account.Surname,
               PhoneNumber = topup.PhoneNumber,
                Amount = topup.Amount
        };
        await _context.SaveChangesAsync();
        return new Response<GetTopUpBalanceDto>(_mapper.Map<GetTopUpBalanceDto>(get));
    }
    public async Task<Response<string>> DeleteTransaction(int id)
    {
        var find = await _context.Transactions.FindAsync(id);
        _context.Transactions.Remove(find);
        await _context.SaveChangesAsync();
        if (find != null) return new Response<string>("Transaction deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Transaction not found");
    }

}

