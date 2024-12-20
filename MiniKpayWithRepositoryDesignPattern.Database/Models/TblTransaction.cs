﻿namespace MiniKpayWithRepositoryDesignPattern.Database.Models;

#region TblTransaction

public partial class TblTransaction
{
    public long TransactionId { get; set; }

    public string FromPhoneNumber { get; set; } = null!;

    public string ToPhoneNumber { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Pin { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}

#endregion