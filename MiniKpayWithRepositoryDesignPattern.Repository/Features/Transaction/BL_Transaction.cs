namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.Transaction;

public class BL_Transaction
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly AppDbContext _appDbContext;


    public BL_Transaction(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Result<TransactionRequestModel>> CreateTransactionAsync(TransactionRequestModel request, CancellationToken cs)
    {
        Result<TransactionRequestModel> response;

        try
        {
            if (request.Amount is null || request.Amount <= 0)
            {
                response = Result<TransactionRequestModel>.Fail("Transaction amount must be greater than 0.");
            }

            var sender = await _appDbContext.TblUsers.FirstOrDefaultAsync(x => x.PhoneNumber == request.FromPhoneNumber);
            var receiver = await _appDbContext.TblUsers.FirstOrDefaultAsync(x => x.PhoneNumber == request.ToPhoneNumber);

            if (request.FromPhoneNumber == request.ToPhoneNumber)
            {
                response = Result<TransactionRequestModel>.Fail("Sender and Receiver Phone Number must be different.");
            }

            if (sender is null)
            {
                response = Result<TransactionRequestModel>.Fail("Sender Phone Number does not exist.");
            }
            if (receiver is null)
            {
                response = Result<TransactionRequestModel>.Fail("Receiver Phone Number does not exists");
            }
            if (sender.Balance < request.Amount)
            {
                response = Result<TransactionRequestModel>.Fail("Insufficient balance.");
            }
            sender.Balance -= request.Amount.Value;
            receiver.Balance += request.Amount.Value;

            _appDbContext.TblUsers.Update(sender);
            _appDbContext.TblUsers.Update(receiver);

            await _appDbContext.SaveChangesAsync();


            response = await _transactionRepository.CreateTransactionAsync(request, cs);

        }
        catch (Exception ex)
        {
            response = Result<TransactionRequestModel>.Fail(ex);
        }
    result:
        return response;
    }

    public async Task<Result<List<TransationModel>>> GetTransactionAsync(CancellationToken cs)
    {
        Result<List<TransationModel>> response;
        try
        {
            response = await _transactionRepository.GetTransactionAsync(cs);
        }
        catch (Exception ex)
        {
            response = Result<List<TransationModel>>.Fail(ex);
        }
    result:
        return response;

    }
}
