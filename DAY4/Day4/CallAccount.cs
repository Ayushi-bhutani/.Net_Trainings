using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsSessions
{
    public class CallAccount
    {

        //main function entry point 
         public static void Main(string[] args)
        {
            //Creating an Account instance using object initializer (constructor + property assignment in one step)
            Account account = new Account() { AccountId = 1, Name = "Account1" };


            //accessing GetAccountDetails from parent class 
            string result = account.GetAccountDetails();

            //Creating an salesAccount instance using object initializer (constructor + property assignment in one step)
            SalesAccount salesAccount = new SalesAccount() { AccountId = 1, Name = "Balu", SalesInfo = "" };


            //accessing GetSalesAccountDetails from parent class 
            var result1=salesAccount.GetSalesAccountDetails();
            Console.WriteLine(result);
            Console.WriteLine(result1);
        }
    }
}
