namespace MiniKpayWithRepositoryDesignPattern.Database.Models;

#region TblDeposit

public partial class TblDeposit
{
    public long DepositId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool DeleteFlag { get; set; }
}

#endregion