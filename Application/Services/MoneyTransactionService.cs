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

    private readonly IWalletRepository _walletRepository;

    private readonly IFinancialGoalRepository _goalRepository;

    private readonly INotificationRepository _notificationRepository;

    private readonly IMapper _mapper;

    public MoneyTransactionService(
        IMoneyTransactionRepository transactionRepository,
        IWalletRepository walletRepository,
        IFinancialGoalRepository goalRepository,
        INotificationRepository notificationRepository,
        IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _walletRepository = walletRepository;
        _goalRepository = goalRepository;
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionPreviewDto>> GetUserTransactionsAsync(int userId)
    {
        var dbTransactions = await _transactionRepository.GetUserTransactionsAsync(userId);

        var viewTransactions = _mapper.Map<List<TransactionPreviewDto>>(dbTransactions);

        return viewTransactions;
    }

    public async Task<List<TransactionPreviewDto>> GetWalletTransactionsAsync(int walletId)
    {
        var dbTransactions = await _transactionRepository.GetWalletTransactionsAsync(walletId);

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

        var dbwallet = await _walletRepository.GetByIdAsync(transactionDto.WalletId);

        dbwallet.MoneyAmount += dbTransaction.Amount;

        await _walletRepository.UpdateAsync(dbwallet);

        var goals = await _goalRepository.GetGoalsByCategoryAsync(dbTransaction.CategoryId, dbTransaction.CreatedAt, dbTransaction.UserId);

        await CreateNotifications(goals, transactionDto.UserId);
    }

    public async Task UpdateTransaction(UpdateTransactionDto transactionDto)
    {
        var dbTransaction = await _transactionRepository.GetByIdAsync(transactionDto.Id);

        dbTransaction.Wallet.MoneyAmount -= dbTransaction.Amount;

        await _walletRepository.UpdateAsync(dbTransaction.Wallet);

        dbTransaction.WalletId = transactionDto.WalletId;
        dbTransaction.CategoryId = transactionDto.CategoryId;
        dbTransaction.Amount = transactionDto.Amount;
        dbTransaction.Comment = transactionDto.Comment;
        transactionDto.CreatedAt ??= DateTime.Now;
        dbTransaction.CreatedAt = transactionDto.CreatedAt.Value;

        await _transactionRepository.UpdateAsync(dbTransaction);

        var wallet = await _walletRepository.GetByIdAsync(transactionDto.WalletId);
        wallet.MoneyAmount += transactionDto.Amount;

        await _walletRepository.UpdateAsync(wallet);

        var goals = await _goalRepository.GetGoalsByCategoryAsync(dbTransaction.CategoryId, dbTransaction.CreatedAt, dbTransaction.UserId);

        await CreateNotifications(goals, transactionDto.UserId);
    }

    public async Task DeleteTransactionAsync(int transactionId)
    {
        var transaction = await _transactionRepository.GetByIdAsync(transactionId);

        if (transaction is null)
        {
            throw new TransactionNotFoundException(transactionId);
        }

        await _transactionRepository.DeleteAsync(transaction);
    }

    public async Task<Dictionary<string, decimal>> GetConsumptionsTotalsAsync(int userId)
    {
        var result = await _transactionRepository.TotalConsumptionByCategoriesAsync(userId);

        return result;
    }

    public async Task<Dictionary<string, decimal>> GetIncomesTotalsAsync(int userId)
    {
        var result = await _transactionRepository.TotalIncomeByCategoriesAsync(userId);

        return result;
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

    private async Task<decimal> CalculateTotal(FinancialGoal goal, int userId)
    {
        if (goal.MoneyAmount > 0)
        {
            return await _transactionRepository.CalculateTotalIncomeAsync(goal.Category, userId, goal.StartDate, goal.DueDate);
        }
        else
        {
            return await _transactionRepository.CalculateTotalConsumptionAsync(goal.Category, userId, goal.StartDate, goal.DueDate);
        }
    }

    private async Task CreateNotifications(List<FinancialGoal> goals, int userId)
    {
        decimal goalTotal;

        foreach (var goal in goals)
        {
            goalTotal = await CalculateTotal(goal, userId);

            if (goalTotal / goal.MoneyAmount >= 1M)
            {
                Notification notification = new Notification
                {
                    Title = $"Вы завершили вашу цель по категории {goal.Category.CategoryName}",
                    NotificationText = $"Вы завершили цель в {Math.Round(goal.MoneyAmount)}. Текущий показатель - {Math.Round(goalTotal, 2)}",
                    UserId = userId
                };
                await _notificationRepository.CreateAsync(notification);
            }
            else if (goalTotal / goal.MoneyAmount >= 0.8M)
            {
                Notification notification = new Notification
                {
                    Title = $"Вы близки к завершению цели по категории {goal.Category.CategoryName}",
                    NotificationText = $"Вы почти достигли цели в {Math.Round(goal.MoneyAmount)}. Текущий показатель - {Math.Round(goalTotal, 2)}",
                    UserId = userId
                };
                await _notificationRepository.CreateAsync(notification);
            }
        }
    }
}
