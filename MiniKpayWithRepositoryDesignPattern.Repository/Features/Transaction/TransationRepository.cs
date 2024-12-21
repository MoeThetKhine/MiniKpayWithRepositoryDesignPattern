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

    public async Task<Result<List<TransationModel>>> GetTransactionAsync(CancellationToken cs)
    {
        Result<List<TransationModel>> result;

        try
        {
            var query =  _appDbContext.TblTransactions
                .Where(x=> x.DeleteFlag == false).AsNoTracking();

            var lst = await query.Select(x => new TransationModel()
            {
                FromPhoneNumber = x.FromPhoneNumber,
                ToPhoneNumber = x.ToPhoneNumber,
                Amount = x.Amount,
                Pin = x.Pin,
            }).ToListAsync();

            result = Result<List<TransationModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<List<TransationModel>>.Fail(ex.Message);
        }
        return result;
    }
}
