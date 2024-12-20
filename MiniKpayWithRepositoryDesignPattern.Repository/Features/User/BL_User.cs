using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;
using MiniKpayWithRepositoryDesignPattern.Utils;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.User;

public class BL_User
{
    private readonly UserRepository _userRepository;

    public BL_User(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<IEnumerable<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<UserModel>> response;
        try
        {
            response = await _userRepository.GetUserAsync(pageNo, pageSize, cs);
        }
        catch (Exception ex)
        {
            response =  Result<IEnumerable<UserModel>>.Fail(ex);
        }
        result: 
        return response;
    }
}
