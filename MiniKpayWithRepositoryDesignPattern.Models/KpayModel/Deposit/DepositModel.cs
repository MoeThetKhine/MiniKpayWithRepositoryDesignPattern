namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Deposit;

#region DepositModel

public class DepositModel
{
    public long DepositId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool DeleteFlag { get; set; }
}

#endregion