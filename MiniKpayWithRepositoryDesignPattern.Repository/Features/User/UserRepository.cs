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

    public async Task<Result<IEnumerable<UserModel>>> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<UserModel>> result;

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

            result = Result<IEnumerable<UserModel>>.Success();
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<UserModel>>.Fail(ex.Message);
        }
        return result;

    }
}
