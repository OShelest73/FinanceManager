using Application.Dtos.MoneyTransaction;
using AutoMapper;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class MoneyTransactionService
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
}
