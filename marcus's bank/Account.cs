using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marcus_s_bank
{
    internal class Account
    {
        public string Username;
        public string Password;
        public decimal Balance;

        public Account(string Username, string Password, decimal Balance)
        {
            this.Username = Username;
            this.Password = Password;
            this.Balance = Balance;
        }

        public void Print()
        {
            Console.WriteLine($"Username = {Username}, Password = {Password}, Balance = {Balance}");
        }
        public bool Deposit (int money)
        {
            if(money < 0)
            {
                return false;
            }

            Balance = Balance + money;
            return true;
        }
        public bool withdraw (int money)
        {
            if(money > Balance)
            {
                return false;
            }
            else if(money < 0)
            { 
                return false;
            }

            Balance = Balance - money;
            return true;
        }
        public bool Transfer (int money, Account account)
        {
            withdraw(money);
            account.Deposit(money);

            if(money < 0)
            {
                return false;
            }
            else if(money > Balance)
            {
                Console.WriteLine("You cant do that!!!");
                return false;
            }
            else if(account == null)
            {
                return false;
            }
            return true;
        }
    }
}
