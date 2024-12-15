using BankApp_DAL;
using BankApp_DAL.CustomModels;
using BankApp_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

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


        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(int id, Account account)
        {
  
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedAccount = await repository.UpdateAccount(id,account);
            if (updatedAccount == null)
            {
                return NotFound($"Account with ID {id} not found.");
            }

            return Ok(updatedAccount);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var success = await repository.DeleteAccount(id);

            if (!success)
            {
                return NotFound($"Account with Number {id} not found.");
            }
            return NoContent();

        }
        [HttpPost]
        public async Task<ActionResult> AddNewAccount(Account account)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accounts = await repository.AddNewAccount(account);
            return Ok(accounts);

        }
        


    }
}
