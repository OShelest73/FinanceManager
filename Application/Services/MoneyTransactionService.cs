using Application.Abstractions;
using Application.Dtos.MoneyTransactionDtos;
using Application.Exceptions;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services;

public class MoneyTransactionService : IMoneyTransactionService
{
    private readonly IMoneyTransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public MoneyTransactionService(IMoneyTransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionPreviewDto>> GetUserTransactionsAsync(int userId)
    {
        var dbTransactions = await _transactionRepository.GetUserTransactionsAsync(userId);

        var viewTransactions = _mapper.Map<List<TransactionPreviewDto>>(dbTransactions);

        return viewTransactions;
    }

    public async Task<List<TransactionPreviewDto>> GetUserTransactionsByCategoryAsync(int userId, int categoryId, bool isIncome, DateTime startDate, DateTime dueDate)
    {
        List<MoneyTransaction> dbTransactions = new();

        if (isIncome)
        {
            dbTransactions = await GetIncomeTransactions(userId, categoryId, startDate, dueDate);
        }
        else
        {
            dbTransactions = await GetConsumptionTransactions(userId, categoryId, startDate, dueDate);
        }

        var viewTransactions = _mapper.Map<List<TransactionPreviewDto>>(dbTransactions);

        return viewTransactions;
    }

    public async Task<TransactionViewDto> GetTransactionByIdAsync(int transactionId)
    {
        var dbTransaction = await _transactionRepository.GetByIdAsync(transactionId);

        var viewTransaction = _mapper.Map<TransactionViewDto>(dbTransaction);

        return viewTransaction;
    }

    public async Task CreateTransactionAsync(CreateTransactionDto transactionDto)
    {
        transactionDto.CreatedAt ??= DateTime.Now;

        var dbTransaction = _mapper.Map<MoneyTransaction>(transactionDto);

        await _transactionRepository.CreateAsync(dbTransaction);
    }

    public async Task UpdateTransaction(TransactionViewDto transactionDto)
    {
        var dbTransaction = _mapper.Map<MoneyTransaction>(transactionDto);

        await _transactionRepository.UpdateAsync(dbTransaction);
    }

    public async Task DeleteTransaction(int transactionId)
    {
        var transaction = await _transactionRepository.GetByIdAsync(transactionId);

        if (transaction is null)
        {
            throw new TransactionNotFoundException(transactionId);
        }

        await _transactionRepository.DeleteAsync(transaction);
    }

    private async Task<List<MoneyTransaction>> GetIncomeTransactions(int userId, int categoryId, DateTime startDate, DateTime dueDate)
    {
        var result = await _transactionRepository.GetUserIncomeByCategoryAsync(userId, categoryId, startDate, dueDate);

        return result;
    }

    private async Task<List<MoneyTransaction>> GetConsumptionTransactions(int userId, int categoryId, DateTime startDate, DateTime dueDate)
    {
        var result = await _transactionRepository.GetUserConsumptionsByCategoryAsync(userId, categoryId, startDate, dueDate);

        return result;
    }
}
