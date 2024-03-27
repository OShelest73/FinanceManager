using Application.Dtos.MoneyTransaction;
using Application.Dtos.User;
using Application.Dtos.Wallet;
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

        CreateMap<MoneyTransaction, TransactionPreviewDto>();
    }
}
