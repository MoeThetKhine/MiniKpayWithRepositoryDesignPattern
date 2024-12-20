namespace MiniKpayWithRepositoryDesignPattern.Models.Models.User;

public class UserModel
{
    public long UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool DeleteFlag { get; set; }
}
