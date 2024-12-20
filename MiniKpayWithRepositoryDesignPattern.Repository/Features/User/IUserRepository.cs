using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;
using MiniKpayWithRepositoryDesignPattern.Utils;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.User;

public interface IUserRepository
{
    Task<Result<IEnumerable<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs);
}
