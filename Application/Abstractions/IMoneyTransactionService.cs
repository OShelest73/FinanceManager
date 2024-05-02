using Application.Dtos.MoneyTransactionDtos;

namespace Application.Abstractions;

public interface IMoneyTransactionService
{
    Task<List<TransactionPreviewDto>> GetUserTransactionsAsync(int userId);

    Task<List<TransactionPreviewDto>> GetWalletTransactionsAsync(int walletId);

    Task<TransactionViewDto> GetTransactionByIdAsync(int transactionId);

    Task<List<TransactionPreviewDto>> GetUserTransactionsByCategoryAsync(int userId, int categoryId, bool isIncome, DateTime startDate, DateTime dueDate);

    Task<Dictionary<string, decimal>> GetConsumptionsTotalsAsync(int userId);

    Task<Dictionary<string, decimal>> GetIncomesTotalsAsync(int userId);

    Task CreateTransactionAsync(CreateTransactionDto transactionDto);

    Task DeleteTransactionAsync(int transactionId);

    Task UpdateTransaction(UpdateTransactionDto transactionDto);
}