using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var result = _user.GetUserAsync(pageNo, pageSize, cs);
            return Ok(result);
        }
    }
}
