using Application.Abstractions;
using Application.Dtos.WalletDtos;
using Application.Exceptions;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public WalletService(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<List<WalletViewDto>> GetUserWalletsAsync(int userId)
    {
        var dbWallets = await _walletRepository.GetAllUserWalletsAsync(userId);

        var outputList = _mapper.Map<List<WalletViewDto>>(dbWallets);

        return outputList;
    }

    public async Task CreateWalletAsync(CreateWalletDto walletDto)
    {
        var dbWallet = _mapper.Map<Wallet>(walletDto);

        await _walletRepository.CreateWalletAsync(dbWallet);
    }

    public async Task UpdateWalletAsync(UpdateWalletDto walletDto)
    {
        var dbWallet = _mapper.Map<Wallet>(walletDto);

        await _walletRepository.UpdateWalletAsync(dbWallet);
    }

    public async Task DeleteWalletAsync(int id)
    {
        var wallet = await _walletRepository.GetWalletByIdAsync(id);

        if (wallet == null)
        {
            throw new WalletNotFoundException(id);
        }

        await _walletRepository.DeleteWalletAsync(wallet);
    }
}
