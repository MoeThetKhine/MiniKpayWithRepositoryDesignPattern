using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniKpayWithRepositoryDesignPattern.Models.KpayModel.Transaction;

namespace MiniKpayWithRepositoryDesignPattern.RestApi.Controllers.Transaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly BL_Transaction _bL_Transaction;

        public TransactionController(BL_Transaction bL_Transaction)
        {
            _bL_Transaction = bL_Transaction;
        }
        public async Task<IActionResult>CreateTransactionAsync(TransactionRequestModel request, CancellationToken cs)
        {
            var transaction = await _bL_Transaction.CreateTransactionAsync(request, cs);
            return Ok(transaction);

        }
    }
}
