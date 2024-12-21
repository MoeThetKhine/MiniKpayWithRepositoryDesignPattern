namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Transaction;

#region TransactionRequestModel

public class TransactionRequestModel
{

    public string FromPhoneNumber { get; set; } = null!;

    public string ToPhoneNumber { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Pin { get; set; } = null!;
}

#endregion
