using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController
{
    private AccountService _accountService;
    public AccountController(AccountService accountService)
    {
        _accountService =  accountService;
    }

    [HttpGet("Account")]
    public async Task<Response<List<GetAccount>>> GetAccount()
    {
        return  await _accountService.GetAccount();
    }
 
       [HttpPost("InsertAccount")]
    public async Task<Response<GetAccount>> InsertAccount([FromForm]AddAccount std)
    {
        return await _accountService.InsertAccount(std);
    }

    [HttpPut("UpdateAccount")]
    public async Task<Response<GetAccount>> UpdateAccount( AddAccount empl)
    {
        return await _accountService.UpdateAccount(empl);
        
    }
    
        [HttpGet("CheckAccount")]
    public async Task<Response<List<GetAccount>>> CheckAccount(string phoneNumber)
    {
        return  await _accountService.CheckAcountWallet(phoneNumber);
    }
    [HttpDelete("DeleteAccount")]
    public async Task<Response<string>> DeleteAccount(int id)
    {
        return await _accountService.DeleteAccount(id);
    }
}