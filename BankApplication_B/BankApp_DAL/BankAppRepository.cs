using BankApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
    }
}
