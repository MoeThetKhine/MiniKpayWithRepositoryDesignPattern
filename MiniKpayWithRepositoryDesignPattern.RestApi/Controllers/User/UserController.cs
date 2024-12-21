using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.User;

namespace MiniKpayWithRepositoryDesignPattern.RestApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BL_User _user;

        public UserController(BL_User user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            var result = await _user.GetUserAsync(pageNo, pageSize, cs);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>CreateUserAsync(UserRequestModel userRequestModel, CancellationToken cs)
        {
            var result = await _user.CreateUserAsync(userRequestModel, cs);
            return Ok(result);
        }
    }
}
