using System;
using System.Collections.Generic;

namespace MiniKpayWithRepositoryDesignPattern.Database.Models;

public partial class TblWithdraw
{
    public long WithdrawId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool DeleteFlag { get; set; }
}
