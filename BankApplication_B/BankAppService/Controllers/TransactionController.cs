using BankApp_DAL;
using BankApp_DAL.CustomModels;
using BankApp_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        BankAppRepository repository;
        public TransactionController(BankAppRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetTransactionHistory()
        {
            try
            {
                var transactions = await repository.GetAllTransactionsAsync();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching transaction history.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TransferFunds([FromBody] TransferRequest transferRequest)
        {
            // Validate the incoming request model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return BadRequest if the model is invalid
            }

            try
            {
                // Call the repository directly to transfer funds
                var result = await repository.TransferFundsAsync(transferRequest);

                // If the transfer was unsuccessful, return BadRequest with the error message
                if (result == null)
                {
                    return BadRequest(new { Message = "An error occurred while processing the transfer." });
                }

                // Return success response with transaction details
                return Ok(new
                {
                    Message = "Transfer successful"
                    //TransactionDetails = result.TransactionTime
                });
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is implemented)
                // You can log the exception here if needed (e.g., using a logging service)

                // Return a generic error message with a 500 Internal Server Error status
                return StatusCode(500, new { Message = "An error occurred while processing the request.", Error = ex.Message });
            }
        }
    }
}
