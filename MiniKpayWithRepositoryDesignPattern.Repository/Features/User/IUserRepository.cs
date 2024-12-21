using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;
using MiniKpayWithRepositoryDesignPattern.Utils;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.User;

public interface IUserRepository
{
    Task<Result<List<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs);
    Task<Result<UserRequestModel>> CreateUserAsync(UserRequestModel userRequestModel, CancellationToken cs);
    Task<Result<UserResponseModel>> UpdateUserProfileAsync(string phno, UserResponseModel responseModel, CancellationToken cs);
    Task<Result<UserModel>> LogOutUserAsync(string phno, CancellationToken cs);
}
