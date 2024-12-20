﻿namespace MiniKpayWithRepositoryDesignPattern.RestApi.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly BL_User _user;

    public UserController(BL_User user)
    {
        _user = user;
    }

    #region GetUserAsync

    [HttpGet]
    public async Task<IActionResult> GetUserAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        var result = await _user.GetUserAsync(pageNo, pageSize, cs);
        return Ok(result);
    }

    #endregion

    #region CreateUserAsync

    [HttpPost]
    public async Task<IActionResult>CreateUserAsync([FromForm]UserRequestModel userRequestModel, CancellationToken cs)
    {
        var result = await _user.CreateUserAsync(userRequestModel, cs);
        return Ok(result);
    }

    #endregion

    #region UpdateUserProfileAsync

    [HttpPatch]
    public async Task<IActionResult>UpdateUserProfileAsync(string phono, UserResponseModel responseModel,CancellationToken cs)
    {
        var result = await _user.UpdateUserProfileAsync(phono, responseModel, cs);
        return Ok(result);
    }

    #endregion

    #region LogOutUserAsync

    [HttpDelete]
    public async Task<IActionResult> LogOutUserAsync(string phno, CancellationToken cs)
    {
        var result = await _user.LogOutUserAsync(phno, cs);
        return Ok(result);
    }

    #endregion

    #region LogInUserAsync

    [HttpPut]
    public async Task<IActionResult> LogInUserAsync(UserLogInModel userLogInModel, CancellationToken cs)
    {
        var result = await _user.LogInUserAsync(userLogInModel, cs);
        return Ok(result);
    }

    #endregion
}
