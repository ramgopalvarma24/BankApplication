using BankApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BankApp_DAL.CustomModels;
using System.Security.Principal;

namespace BankApp_DAL
{
    public class BankAppRepository
    {
        private BankApplication_DBContext context;
        public BankAppRepository(BankApplication_DBContext context)
        {
            this.context = context;
        }
        public async Task<List<Account>> GetAllAccounts()
        {

            return await context.Accounts.ToListAsync();
            //return AccountList;

        }
        //UpdateAccount
        public async Task<Account> AddNewAccount(Account account)
        {
            var result = context.Accounts.Add(account);
            await context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Account> UpdateAccount(int accounNumber, Account account)
        {
            var existingAccount = await context.Accounts
                .FirstOrDefaultAsync(n => n.AccountNumber == accounNumber);

            if (existingAccount == null)
            {
                return null;
            }
            existingAccount.AccountName = account.AccountName;
            existingAccount.Balance = account.Balance;

            try
            {
                await context.SaveChangesAsync();

                return existingAccount;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the Account", ex);
            }
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return false;
            }
            context.Accounts.Remove(account);
            try
            {
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the account", ex);
            }

        }

        
        public async Task<Transaction> TransferFundsAsync(TransferRequest transferRequest)
        {
            // Fetch accounts from the database
            var fromAccount = await context.Accounts
                .FirstOrDefaultAsync(n => n.AccountNumber == transferRequest.FromAccount);
            var toAccount = await context.Accounts
                .FirstOrDefaultAsync(n => n.AccountNumber == transferRequest.ToAccount);

            // Validate accounts
            if (fromAccount == null)
            {
                throw new Exception("The 'FromAccount' does not exist.");
            }
            if (toAccount == null)
            {
                throw new Exception("The 'ToAccount' does not exist.");
            }

            // Check if the balance is sufficient
            if (fromAccount.Balance < transferRequest.Amount)
            {
                throw new Exception("Insufficient balance in 'FromAccount'.");
            }

            // Create a new transaction record
            var transaction = new Transaction
            {
                FromAccount = fromAccount.AccountName,
                ToAccount = toAccount.AccountName,
                FromAccountBalance = fromAccount.Balance,
                ToAccountBalance = toAccount.Balance,
                TransactionTime = DateTime.UtcNow,
                AmountDebited = transferRequest.Amount,
                DetailsLink = $"details/{Guid.NewGuid()}"
            };

            // Update account balances
            fromAccount.Balance -= transferRequest.Amount;
            toAccount.Balance += transferRequest.Amount;

            try
            {
                // Save the transaction and account updates
                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the database.", ex);
            }

            // Return the transaction record
            return transaction;
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return await context.Transactions
                                 .OrderByDescending(t => t.TransactionTime)  // Ordering by latest transactions
                                 .ToListAsync();
        }

    }
}
