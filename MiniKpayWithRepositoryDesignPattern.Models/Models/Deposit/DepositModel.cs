using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniKpayWithRepositoryDesignPattern.Models.Models.Deposit
{
    public class DepositModel
    {
        public long DepositId { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public decimal Balance { get; set; }

        public bool DeleteFlag { get; set; }
    }
}
