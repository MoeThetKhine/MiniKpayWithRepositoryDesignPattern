namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;

#region UserResponseModel

public class UserResponseModel
{
    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}

#endregion