﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniKpayWithRepositoryDesignPattern.Models.Models.Transaction
{
    public class TransationModel
    {
        public long TransactionId { get; set; }

        public string FromPhoneNumber { get; set; } = null!;

        public string ToPhoneNumber { get; set; } = null!;

        public decimal Amount { get; set; }

        public string Pin { get; set; } = null!;

        public bool DeleteFlag { get; set; }
    }
}