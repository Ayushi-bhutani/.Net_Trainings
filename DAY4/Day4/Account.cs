using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsSessions
{
    
    public class Account
    {

        //declaring fields used in subclasses
        public required string Name { get; set; }
        public required int AccountId { get; set; }

        //defining GetAccountDetails method
        public string GetAccountDetails()
        {
            return $"I am Base account . My Id is {AccountId}";
        }
      
    }

    //child class derived from parent class Accout
    public class SalesAccount : Account 
    {
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            info += base.GetAccountDetails();
            info += "I am from Sales Derived class ";
            return info;
        }
        public  required string SalesInfo { get; set; }
    }

    //child class derived from parent class Accout
    public class PurchaseAccount : Account
    {
        public required string PurchaseInfo { get; set; }
    }

}