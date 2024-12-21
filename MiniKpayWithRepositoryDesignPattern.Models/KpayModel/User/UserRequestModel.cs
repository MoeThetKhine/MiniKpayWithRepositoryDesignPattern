namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;

#region UserRequestModel

public class UserRequestModel
{
    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

}

#endregion