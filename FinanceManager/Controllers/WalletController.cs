using Application.Abstractions;
using Application.Dtos.WalletDtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    public async Task<ActionResult> GetUserWallets(int userId)
    {
        var wallets = await _walletService.GetUserWalletsAsync(userId);

        return Ok(wallets);
    }

    [HttpPost]
    public async Task<ActionResult> CreateWallet(CreateWalletDto walletDto)
    {
        await _walletService.CreateWalletAsync(walletDto);

        return Ok();
    }
}
