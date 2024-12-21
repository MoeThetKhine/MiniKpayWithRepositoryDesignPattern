namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Transaction
{
    public class TransactionRequestModel
    {

        public string FromPhoneNumber { get; set; } = null!;

        public string ToPhoneNumber { get; set; } = null!;

        public decimal Amount { get; set; }

        public string Pin { get; set; } = null!;
    }
}
