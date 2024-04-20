using Application.Abstractions;
using Application.Dtos.MoneyTransactionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoneyTransactionController : ControllerBase
{
    private readonly IMoneyTransactionService _moneyTransactionService;

    public MoneyTransactionController(IMoneyTransactionService moneyTransactionService)
    {
        _moneyTransactionService = moneyTransactionService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllTransactions(int userId)
    {
        var transactions = await _moneyTransactionService.GetUserTransactionsAsync(userId);

        return Ok(transactions);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMoneyTransaction(CreateTransactionDto transactionDto)
    {
        await _moneyTransactionService.CreateTransactionAsync(transactionDto);

        return Ok();
    }
}
