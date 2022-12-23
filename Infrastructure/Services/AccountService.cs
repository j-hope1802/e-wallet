using System.Net;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using AutoMapper;
namespace Infrastructure.Services;
public class AccountService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public AccountService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<GetAccount>>> GetAccount()
    {
        var list = await _context.Acounts.Select(j => new GetAccount()
        {
            AccountId = j.AccountId,
            Name = j.Name,
            Surname = j.Surname,
            Autenticated = j.Autenticated,
            PhoneNumber = j.PhoneNumber
        }).ToListAsync();

        return new Response<List<GetAccount>>(list);
    }
    public async Task<Response<GetAccount>> InsertAccount(AddAccount account)
    {

        var newAccount = _mapper.Map<Acount>(account);
        //save file 

        _context.Acounts.Add(newAccount);
        await _context.SaveChangesAsync();
        var response = _mapper.Map<GetAccount>(newAccount);
        return new Response<GetAccount>(response);
    }
    public async Task<Response<GetAccount>> UpdateAccount(AddAccount account)
    {
        var find = await _context.Acounts.FindAsync(account.AccountId);

        find.Name = account.Name;
        find.Surname = account.Surname;
        find.PhoneNumber = account.PhoneNumber;
        find.Autenticated = account.Autenticated;
        await _context.SaveChangesAsync();
        var response = _mapper.Map<GetAccount>(find);
        return new Response<GetAccount>(response);
    }

    public async Task<Response<string>> DeleteAccount(int id)
    {
        var find = await _context.Acounts.FindAsync(id);

        if (find != null)
            _context.Acounts.Remove(find);
        await _context.SaveChangesAsync();

        return new Response<string>("Acount deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Acount not found");
    }
    
    public async Task<Response<List<GetAccount>>> CheckAcountWallet(string phoneNumber)
    {
        var find = await (from a in _context.Acounts
                          where a.PhoneNumber == phoneNumber
                          select new GetAccount()
                          {
                              AccountId = a.AccountId,
                              Autenticated = a.Autenticated,
                              Name = a.Name,
                              Surname = a.Surname,
                              PhoneNumber = a.PhoneNumber
                          }).ToListAsync();

        return new Response<List<GetAccount>>(find);

    }
}
