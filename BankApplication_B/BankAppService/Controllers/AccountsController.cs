using BankApp_DAL;
using BankApp_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        BankAppRepository repository;

        public AccountsController(BankAppRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAllAccounts()
        {
            //List<Account> accounts =  repository.GetAllAccounts();
            var accounts = await repository.GetAllAccounts();
            if (accounts == null || accounts.Count == 0)
            {
                return NotFound("No notifications found.");
            }
            return Ok(accounts);
        }
    }
}
