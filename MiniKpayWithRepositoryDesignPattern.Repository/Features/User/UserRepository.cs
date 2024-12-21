using Microsoft.EntityFrameworkCore;
using MiniKpayWithRepositoryDesignPattern.Database.Models;
using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;
using MiniKpayWithRepositoryDesignPattern.Shared;
using MiniKpayWithRepositoryDesignPattern.Utils;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<UserRequestModel>> CreateUserAsync(UserRequestModel userRequestModel, CancellationToken cs)
    {
        Result<UserRequestModel> result;

        try
        {
            var user =  new TblUser
            {
                FullName = userRequestModel.FullName,
                Password = userRequestModel.Password,
                Pin = userRequestModel.Pin,
                PhoneNumber = userRequestModel.PhoneNumber,
                Balance = userRequestModel.Balance,
            };

            _db.TblUsers.Add(user);
            await _db.SaveChangesAsync(cs);

            result = Result<UserRequestModel>.Success();

        }
        catch (Exception ex)
        {
            result = Result<UserRequestModel>.Fail(ex.Message);
        }
        return result; 

    }

    public async Task<Result<List<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<List<UserModel>> result;

        try
        {
            var query = _db.TblUsers
                .Where(x => x.DeleteFlag == false)
                .Paginate(pageNo, pageSize);

            var lst = await query.Select(x => new UserModel()
            {
                UserId = x.UserId,
                FullName = x.FullName,
                Pin = x.Pin,
                PhoneNumber = x.PhoneNumber,
                Balance = x.Balance
            }).ToListAsync();

            result = Result<List<UserModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<List<UserModel>>.Fail(ex.Message);
        }
        return result;
    }

    public async Task<Result<UserLogInModel>> LogInUserAsync(UserLogInModel logInModel, CancellationToken cs)
    {
        Result<UserLogInModel> result;
        try
        {
            var user = await _db.TblUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FullName == logInModel.FullName && x.Password == logInModel.Password && x.DeleteFlag,cs);

            if(user is null)
            {
                result = Result<UserLogInModel>.NotFound("User does not exist");
            }
            user.DeleteFlag = false;

            _db.Entry(user).State = EntityState.Modified;

            await _db.SaveChangesAsync(cs);
            result = Result<UserLogInModel>.Success("Log In Successful.");

        }
        catch(Exception ex)
        {
            result = Result<UserLogInModel>.Fail(ex.Message);
        }
        return result;
    }

    public async Task<Result<UserModel>> LogOutUserAsync(string phno, CancellationToken cs)
    {
        Result<UserModel> result;
        try
        {
            var user = await _db.TblUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PhoneNumber == phno && !x.DeleteFlag, cs);

            if(user is null)
            {
                result = Result<UserModel>.NotFound("User does not exist");
            }

            user.DeleteFlag = true;
            _db.Entry(user).State = EntityState.Modified;

            await _db.SaveChangesAsync(cs);
            result = Result<UserModel>.Success("Log Out Successful");

        }
        catch(Exception ex)
        {
            result = Result<UserModel>.Fail(ex.Message);
        }
        return result;
    }

    public async Task<Result<UserResponseModel>> UpdateUserProfileAsync(string phno, UserResponseModel responseModel, CancellationToken cs)
    {
        Result<UserResponseModel> result;

        try
        {
            var user = await _db.TblUsers.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == phno);

            if(user is null)
            {
                result = Result<UserResponseModel>.NotFound("User does not exist.");
            }

            if(!string.IsNullOrEmpty(responseModel.FullName))
            {
               user.FullName = responseModel.FullName;
            }
            if(!string.IsNullOrEmpty(responseModel.Password))
            {
                user.Password = responseModel.Password;
            }
            if(!string.IsNullOrEmpty(responseModel.Pin))
            {
                user.Pin = responseModel.Pin;
            }

            if (!string.IsNullOrEmpty(responseModel.PhoneNumber))
            {
                user.PhoneNumber = responseModel.PhoneNumber;
            }

            _db.TblUsers.Attach(user);
            _db.Entry(user).State = EntityState.Modified;

            await _db.SaveChangesAsync(cs);
            result = Result<UserResponseModel>.Success();
        }
        catch(Exception ex)
        {
            result = Result<UserResponseModel>.Fail(ex.Message);
        }
        return result;
    }
}
