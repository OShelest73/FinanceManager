using Application.Dtos.MoneyTransactionDtos;

namespace Application.Abstractions;
public interface IMoneyTransactionService
{
    Task CreateTransaction(CreateTransactionDto transactionDto);

    Task DeleteTransaction(int transactionId);

    Task<TransactionViewDto> GetTransactionByIdAsync(int transactionId);

    Task<List<TransactionPreviewDto>> GetUserTransactionsByCategoryAsync(int userId, int categoryId);

    Task UpdateTransaction(TransactionViewDto transactionDto);
}