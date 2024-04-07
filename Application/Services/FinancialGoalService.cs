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

        foreach (var goal in viewGoals)
        {
            goal.CurrentTotal = await _transactionRepository.CalculateTotalAsync(goal.Category, userId);
        }

        return viewGoals;
    }

    public async Task CreateFinancialGoal(CreateFinancialGoalDto goalDto)
    {
        var dbGoal = _mapper.Map<FinancialGoal>(goalDto);

        await _goalRepository.CreateAsync(dbGoal);
    }
}
