namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.User;

public class BL_User
{
    private readonly IUserRepository _userRepository;

    public BL_User(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<List<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<List<UserModel>> response;
        try
        {
            response = await _userRepository.GetUserAsync(pageNo, pageSize, cs);
        }
        catch (Exception ex)
        {
            response = Result<List<UserModel>>.Fail(ex);
        }
    result:
        return response;
    }

    public async Task<Result<UserRequestModel>> CreateUserAsync(UserRequestModel userRequestModel, CancellationToken cs)
    {
        Result<UserRequestModel> response;
        try
        {
            if (userRequestModel.FullName is null)
            {
                response = Result<UserRequestModel>.Fail("User Name is required");
            }
            if (userRequestModel.Password is null)
            {
                response = Result<UserRequestModel>.Fail("Password is required");
            }
            if (userRequestModel.Password!.Length < 8 || userRequestModel.Password.Length > 16)
            {
                response = Result<UserRequestModel>.Fail("Password must be between 8 and 16 character");
            }

            if (userRequestModel.Pin is null)
            {
                response = Result<UserRequestModel>.Fail("Pin is required");
            }

            if (userRequestModel.Pin!.Length != 4)
            {
                response = Result<UserRequestModel>.Fail("Pin Code must be 4 numbers");
            }

            if (userRequestModel.PhoneNumber is null)
            {
                response = Result<UserRequestModel>.Fail("Phone Number is required");
            }

            if (userRequestModel.PhoneNumber!.Length != 11)
            {
                response = Result<UserRequestModel>.Fail("Phone Number must be 11 numbers");
            }

            if (userRequestModel.Balance < 10000)
            {
                response = Result<UserRequestModel>.Fail("Your Balance must be atleast 10000 KS");
            }

            response = await _userRepository.CreateUserAsync(userRequestModel, cs);

        }
        catch (Exception ex)
        {
            response = Result<UserRequestModel>.Fail(ex);
        }
    result:
        return response;
    }

    public async Task<Result<UserResponseModel>> UpdateUserProfileAsync(string phno, UserResponseModel responseModel, CancellationToken cs)
    {
        Result<UserResponseModel> response;
        try
        {
            response = await _userRepository.UpdateUserProfileAsync(phno, responseModel, cs);
        }
        catch (Exception ex)
        {
            response = Result<UserResponseModel>.Fail(ex);
        }
    result:
        return response;
    }

    public async Task<Result<UserModel>> LogOutUserAsync(string phno, CancellationToken cs)
    {
        Result<UserModel> response;
        try
        {
            response = await _userRepository.LogOutUserAsync(phno, cs);
        }
        catch (Exception ex)
        {
            response = Result<UserModel>.Fail(ex);
        }
    result:
        return response;
    }

    public async Task<Result<UserLogInModel>> LogInUserAsync(UserLogInModel logInModel, CancellationToken cs)
    {
        Result<UserLogInModel> response;
        try
        {
            response = await _userRepository.LogInUserAsync(logInModel, cs);
        }
        catch(Exception ex)
        {
            response = Result<UserLogInModel>.Fail(ex);

        }
    result:
        return response;
    }
}
