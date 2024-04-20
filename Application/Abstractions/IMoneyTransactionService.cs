using Application.Dtos.MoneyTransactionDtos;

namespace Application.Abstractions;
public interface IMoneyTransactionService
{
    Task<List<TransactionPreviewDto>> GetUserTransactionsAsync(int userId);

    Task<TransactionViewDto> GetTransactionByIdAsync(int transactionId);

    Task<List<TransactionPreviewDto>> GetUserTransactionsByCategoryAsync(int userId, int categoryId);

    Task CreateTransactionAsync(CreateTransactionDto transactionDto);

    Task DeleteTransaction(int transactionId);

    Task UpdateTransaction(TransactionViewDto transactionDto);
}