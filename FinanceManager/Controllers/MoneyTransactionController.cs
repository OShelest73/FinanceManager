using Application.Abstractions;
using Application.Dtos.MoneyTransactionDtos;
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

    [HttpGet("wallet-transactions")]
    public async Task<ActionResult> GetGoalTransactions(int walletId)
    {
        var transactions = await _moneyTransactionService.GetWalletTransactionsAsync(walletId);

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

    [HttpGet("calculate-total-consumptions")]
    public async Task<ActionResult> GetTotalConsumptionsByCategories(int userId)
    {
        var transaction = await _moneyTransactionService.GetConsumptionsTotalsAsync(userId);

        return Ok(transaction);
    }
    [HttpGet("calculate-total-incomes")]
    public async Task<ActionResult> GetTotalIncomesByCategories(int userId)
    {
        var transaction = await _moneyTransactionService.GetIncomesTotalsAsync(userId);

        return Ok(transaction);
    }


    [HttpPost]
    public async Task<ActionResult> CreateMoneyTransaction(CreateTransactionDto transactionDto)
    {
        await _moneyTransactionService.CreateTransactionAsync(transactionDto);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTransaction(UpdateTransactionDto transactionDto)
    {
        await _moneyTransactionService.UpdateTransaction(transactionDto);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTransaction(int transactionId)
    {
        await _moneyTransactionService.DeleteTransactionAsync(transactionId);

        return Ok();
    }
}
