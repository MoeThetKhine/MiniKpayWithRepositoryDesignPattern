namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Withdraw;

#region WithdrawModel

public class WithdrawModel
{
    public long WithdrawId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool DeleteFlag { get; set; }
}

#endregion