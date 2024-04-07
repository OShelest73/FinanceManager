namespace Domain.Entities;

public class Wallet
{
    public int Id { get; set; }
    public string WalletName { get; set; }
    public decimal MoneyAmount { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
