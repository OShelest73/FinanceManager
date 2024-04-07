using Application.Dtos.CategoryDtos;
using Application.Dtos.FinancialGoalDtos;
using Application.Dtos.MoneyTransactionDtos;
using Application.Dtos.UserDtos;
using Application.Dtos.WalletDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Settings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<RegisterDto, User>();
        CreateMap<AuthenticationRequest, User>().ReverseMap();

        CreateMap<Wallet, WalletViewDto>().ReverseMap();
        CreateMap<CreateWalletDto, Wallet>();

        CreateMap<MoneyTransaction, TransactionPreviewDto>();
        CreateMap<MoneyTransaction, TransactionViewDto>().ReverseMap();
        CreateMap<CreateTransactionDto, MoneyTransaction>();

        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<FinancialGoal, FinancialGoalDto>().ReverseMap();
        CreateMap<CreateFinancialGoalDto, FinancialGoal>();
    }
}
