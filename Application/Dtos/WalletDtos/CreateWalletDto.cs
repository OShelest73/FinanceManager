namespace Application.Dtos.WalletDtos;

public class CreateWalletDto
{
    public string WalletName { get; set; }
    public decimal MoneyAmount { get; set; }

    public int UserId { get; set; }
}
