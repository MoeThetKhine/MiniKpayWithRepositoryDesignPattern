﻿namespace MiniKpayWithRepositoryDesignPattern.Repository.Features.Transaction;

#region ITransactionRepository

public interface ITransactionRepository
{
    Task<Result<TransactionRequestModel>> CreateTransactionAsync(TransactionRequestModel transactionRequest,CancellationToken cs);
    Task<Result<List<TransationModel>>> GetTransactionAsync(CancellationToken cs);
}

#endregion