using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marcus_s_bank
{
    internal class Bank
    {
        Account[] accounts = new Account[3];
        int count = 0;
        public bool AddAccounts(Account account)
        {
            if(count > accounts.Length)
            {
                Account[] temp = new Account[accounts.Length * 2];
                for (int i = 0; i < accounts.Length; i++)
                {
                    temp[i] = accounts[i];
                }
                accounts = temp;
            }
            for(int i = 0; i < count; i++)
            {
                if (accounts[i].Username == account.Username)
                {
                 
                    return false;
                }
            }
            accounts[count] = account;
            count++;
            return true;
        }

        public void RemoveAccount(string username, string password)
        {
            for (int i = 0; i < count; i++)
            {
                if (username == accounts[i].Username && password == accounts[i].Password)
                {
                    accounts[i] = null;
                    count--;
                    for(int j = i; j < count; j++)
                    {
                        accounts[j] = accounts[j + 1];
                    }
                    accounts[count] = null;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                accounts[i].Print();
            }

        }
        //take in 
        public Account LogIn(string username, string password)
        {
            for (int i = 0; i < count; i++)
            {
                if (username == accounts[i].Username && password == accounts[i].Password)
                {
                    return accounts[i];
                }
            }
            return null;
        }
        public Account FindAccount(string username)
        {
            for(int i = 0; i < count; i++)
            {
                if(username == accounts[i].Username)
                {
                    return accounts[i];
                }
            }
            return null;
        }
        public int Add(int a, int b)
        {
            int answer;
            answer = a + b;

            return answer;
        }
    }
}
