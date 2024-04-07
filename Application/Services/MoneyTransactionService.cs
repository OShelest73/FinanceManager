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

    public async Task<List<TransactionPreviewDto>> GetUserTransactionsByCategoryAsync(int userId, int categoryId)
    {
        var dbTransactions = await _transactionRepository.GetUserTransactionsByCategoryAsync(userId, categoryId);

        var viewTransactions = _mapper.Map<List<TransactionPreviewDto>>(dbTransactions);

        return viewTransactions;
    }

    public async Task<TransactionViewDto> GetTransactionByIdAsync(int transactionId)
    {
        var dbTransaction = await _transactionRepository.GetByIdAsync(transactionId);

        var viewTransaction = _mapper.Map<TransactionViewDto>(dbTransaction);

        return viewTransaction;
    }

    public async Task CreateTransaction(CreateTransactionDto transactionDto)
    {
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
}
