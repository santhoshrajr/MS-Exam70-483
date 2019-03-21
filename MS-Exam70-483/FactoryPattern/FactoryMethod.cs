using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.FactoryPattern
{
    /*Let's assume two credit unions merge and now they share an API that pulls 
     * account information from each company that merged. One call Citi Credit Union 
     * and the other National Credit Union.
     * Returns savings account object based on the account number passed in
     */
    //Product
    public abstract class ISavingsAccount
    {
        public decimal Balance { get; set; }
    }
    //concrete product
    public class CitiSavingsAccount : ISavingsAccount
    {
        public CitiSavingsAccount()
        {
            Balance = 5000;
        }
    }
    //Concrete Product
    public class NationalSavingsAccount : ISavingsAccount
    {
        public NationalSavingsAccount()
        {
            Balance = 10000;
        }
    }
    //Creator
    public interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }
    //Concrete Creator
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITI")) { return new CitiSavingsAccount(); }
            if (acctNo.Contains("NATIONAL")) { return new NationalSavingsAccount(); }
            throw new ArgumentException("Invalid Account Number");

        }
    }
}

