using Application.Dtos.CategoryDtos;
using Application.Dtos.FinancialGoalDtos;
using Application.Dtos.MoneyTransactionDtos;
using Application.Dtos.NotificationDtos;
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
        CreateMap<Wallet, SelectWalletDto>();
        CreateMap<CreateWalletDto, Wallet>();
        CreateMap<UpdateWalletDto, Wallet>();

        CreateMap<MoneyTransaction, TransactionPreviewDto>();
        CreateMap<MoneyTransaction, TransactionViewDto>().ReverseMap();
        CreateMap<CreateTransactionDto, MoneyTransaction>();
        CreateMap<UpdateTransactionDto, MoneyTransaction>();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryNameDto>();

        CreateMap<FinancialGoal, FinancialGoalDto>().ReverseMap();
        CreateMap<CreateFinancialGoalDto, FinancialGoal>();
        CreateMap<UpdateFinancialGoalDto, FinancialGoal>();

        CreateMap<Notification, NotificationPreviewDto>();
        CreateMap<Notification, NotificationDto>();
    }
}
