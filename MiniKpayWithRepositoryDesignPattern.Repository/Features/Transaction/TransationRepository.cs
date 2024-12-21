using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Transaction;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.Transaction;

public class TransationRepository : ITransactionRepository
{
    private readonly AppDbContext _appDbContext;

    public async Task<Result<TransactionRequestModel>> CreateTransactionAsync(TransactionRequestModel request, CancellationToken cs)
    {
        Result<TransactionRequestModel> result;

        try
        {
            
            var transaction = new TblTransaction
            {
                FromPhoneNumber = request.FromPhoneNumber,
                ToPhoneNumber = request.ToPhoneNumber,
                Amount = request.Amount.Value,
                Pin = request.Pin,
            };

            _appDbContext.Add(transaction);
            await _appDbContext.SaveChangesAsync();

            result = Result<TransactionRequestModel>.Success(request);
            

        }
        catch (Exception ex)
        {
            result = Result<TransactionRequestModel>.Fail(ex.Message);
        }
        return result;
    }
}
