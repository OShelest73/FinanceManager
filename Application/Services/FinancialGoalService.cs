using Application.Abstractions;
using Application.Dtos.FinancialGoalDtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services;

public class FinancialGoalService : IFinancialGoalService
{
    private readonly IFinancialGoalRepository _goalRepository;
    private readonly IMoneyTransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public FinancialGoalService(IFinancialGoalRepository goalRepository, IMoneyTransactionRepository transactionRepository, IMapper mapper)
    {
        _goalRepository = goalRepository;
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<FinancialGoalDto>> GetUserFinancialGoals(int userId)
    {
        var dbGoals = await _goalRepository.GetUsersGoalsAsync(userId);

        var viewGoals = _mapper.Map<List<FinancialGoalDto>>(dbGoals);

        int goalLength = viewGoals.Count;

        for (int i = 0; i < goalLength; i++)
        {
            viewGoals[i].CurrentTotal = await CalculateTotal(dbGoals[i], userId);
        }

        return viewGoals;
    }

    public async Task<FinancialGoalDto> GetGoalDetailedAsync(int goalId, int userId)
    {
        var dbGoal = await _goalRepository.GetGoalWihCategoryAsync(goalId);

        var viewGoal = _mapper.Map<FinancialGoalDto>(dbGoal);

        viewGoal.CurrentTotal = await CalculateTotal(dbGoal, userId);

        return viewGoal;
    }

    public async Task CreateFinancialGoal(CreateFinancialGoalDto goalDto)
    {
        var dbGoal = _mapper.Map<FinancialGoal>(goalDto);

        await _goalRepository.CreateAsync(dbGoal);
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
}
