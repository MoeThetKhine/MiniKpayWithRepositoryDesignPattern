using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User
{
    public class UserResponseModel
    {
        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Pin { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
