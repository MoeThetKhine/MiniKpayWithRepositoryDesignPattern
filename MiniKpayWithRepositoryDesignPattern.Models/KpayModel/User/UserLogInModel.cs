using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User
{
    public class UserLogInModel
    {
        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
