namespace MiniKpayWithRepositoryDesignPattern.RestApi.Controllers.Transaction;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly BL_Transaction _bL_Transaction;

    public TransactionController(BL_Transaction bL_Transaction)
    {
        _bL_Transaction = bL_Transaction;
    }

    [HttpPost]
    public async Task<IActionResult>CreateTransactionAsync(TransactionRequestModel request, CancellationToken cs)
    {
        var transaction = await _bL_Transaction.CreateTransactionAsync(request, cs);
        return Ok(transaction);
    }

    [HttpGet]
    public async Task<IActionResult>GetTransactionAsync(CancellationToken cs)
    {
        var transaction = await _bL_Transaction.GetTransactionAsync(cs);
        return Ok(transaction);
    }
}
