using BankApp_DAL;
using BankApp_DAL.Models;

namespace BankAppConsole
{
    public class Program
    {
        static BankApplication_DBContext context;
        static BankAppRepository repository;

        static Program()
        {
            context = new BankApplication_DBContext();
            repository = new BankAppRepository(context);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //var accountss = repository.GetAllAccounts();
            //foreach (var acc in accountss)
            //{
               // Console.WriteLine("{0}\t\t{1}", acc.AccountNumber, acc.AccountName);
            //}
        }
    }
}