using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController
{
    private TransactionService _transactionService;
    public TransactionController(TransactionService transactionService)
    {
        _transactionService =  transactionService;
    }
    

    [HttpGet("Transaction")]
    public async Task<Response<List<GetTransaction>>> GetTransaction()
    {
        return  await _transactionService.GetTransaction();
    }

       [HttpPost("InsertTransaction")]
    public async Task<Response<GetTransaction>> InsertTransaction(AddTransaction std)
    {
        return await _transactionService.InsertTransaction(std);
    }

    [HttpPut("UpdateTransaction")]
    public async Task<Response<GetTransaction>> UpdateTransaction( AddTransaction empl)
    {
        return await _transactionService.UpdateTransaction(empl);
    }
    [HttpDelete("DeleteAccount")]
    public async Task<Response<string>> DeleteTransaction(int id)
    {
        return await _transactionService.DeleteTransaction(id);
    }
    [HttpPost("AddBalance")]
    public async Task<Response<GetTopUpBalanceDto>> TopUpBalance([FromForm]AddTopUpBalanceDto topUpDto){
        return await _transactionService.TopUpBalance(topUpDto);
}
    
    [HttpGet("GetBalance")]
    public decimal GetBalance(string phoneNumber){
        return  _transactionService.GetBalanceFromWallet(phoneNumber);
}
}