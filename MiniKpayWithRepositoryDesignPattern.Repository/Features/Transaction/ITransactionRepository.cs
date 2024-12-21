using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Transaction;

namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.Transaction;

public interface ITransactionRepository
{
    Task<Result<TransactionRequestModel>> CreateTransactionAsync(TransactionRequestModel transactionRequest,CancellationToken cs);
}
