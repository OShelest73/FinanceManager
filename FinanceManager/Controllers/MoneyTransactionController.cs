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

    [HttpGet("goal-transactions")]
    public async Task<ActionResult> GetGoalTransactions(int userId, int goalId, bool isIncome, DateTime startDate, DateTime dueDate)
    {
        var transactions = await _moneyTransactionService.GetUserTransactionsByCategoryAsync(userId, goalId, isIncome, startDate, dueDate);

        return Ok(transactions);
    }

    [HttpGet("detailed-transaction")]
    public async Task<ActionResult> GetTransactionDetailed(int transactionId)
    {
        var transaction = await _moneyTransactionService.GetTransactionByIdAsync(transactionId);

        return Ok(transaction);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMoneyTransaction(CreateTransactionDto transactionDto)
    {
        await _moneyTransactionService.CreateTransactionAsync(transactionDto);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTransaction(int transactionId)
    {
        await _moneyTransactionService.DeleteTransaction(transactionId);

        return Ok();
    }
}
