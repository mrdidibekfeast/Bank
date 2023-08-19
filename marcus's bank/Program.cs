using System.ComponentModel;
using System.Runtime.InteropServices;
//print out all accounts, add account to bank, remove account from bank, log into account in bank, when they log into the account they should be able to withdraw money, deposit money and transfer money
namespace marcus_s_bank
{
    internal class Program
    {
        static string QuestionResponse (string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        static void Main(string[] args)
        {
            Bank bank = new Bank();
            while(true)
            {
                Console.WriteLine("Welcome to the bank");
                string userResponse = QuestionResponse("Would you like to (1)add an account or (2)print the accounts or (3)log in or (4)remove an account");
                
                if(userResponse == "1")
                {
                     Console.WriteLine("Please give a username");
                     string userGeneratedUsername = Console.ReadLine();
                     Console.WriteLine("Please give a password");
                     string userGeneratedPassword = Console.ReadLine();
                     Console.WriteLine("Please give amount of money you want to deposit");
                     decimal userDeposit = decimal.Parse(Console.ReadLine());
                     Account accounts = new Account(userGeneratedUsername,userGeneratedPassword,userDeposit);
                     bank.AddAccounts(accounts);
                }
                else if(userResponse == "2") 
                {
                    bank.Print();
                }
                else if(userResponse == "3")
                {
                    Console.WriteLine("Please give a username");
                    string Username = Console.ReadLine();
                    Console.WriteLine("Please give a password");
                    string Password = Console.ReadLine();
                    Account user = bank.LogIn(Username, Password);
       
                    while(true)                        
                    {
                        Console.WriteLine($"Welcome {user.Username}");
                        string accountOptionResponse = QuestionResponse("Would you like to (1)deposit money or (2)withdraw money or (3)transfer money or (4)check balance or (5)log out");
                        if (accountOptionResponse == "1")
                        {
                            int depositMoneyResponse = int.Parse(QuestionResponse("How much money would you like to add to your account?"));
                            user.Deposit(depositMoneyResponse);
                            if (user.Deposit(depositMoneyResponse) == false)
                            {
                                Console.WriteLine("You cant do that!!!");
                            }
                        }
                        else if (accountOptionResponse == "2")
                        {
                            int withdrawMoneyResponse = int.Parse(QuestionResponse("How much money do you +want to withdraw"));
                            user.withdraw(withdrawMoneyResponse);
                            if (user.withdraw(withdrawMoneyResponse) == false);
                            {
                                Console.WriteLine("You cant do that!!!");
                            }
                        }
                        else if(accountOptionResponse == "3")
                        {
                            string transferMoneyResponse = QuestionResponse("What account would you like to transfer money to? Please provide a username.");
                            Account transferAccount = bank.FindAccount(transferMoneyResponse);
                            int transferAmount = int.Parse(QuestionResponse("How much money would you like to transfer?"));

                            user.Transfer(transferAmount, transferAccount);
                          
                        }
                        else if(accountOptionResponse == "4")
                        {
                            Console.WriteLine($"{user.Balance}");
                        }
                        else if(accountOptionResponse == "5")
                        {
                            break;
                        }
                    }
                }
                else if(userResponse == "4")
                {
                    Console.WriteLine("Please give the username of the account you want to remove");
                    string removeAccountUser = Console.ReadLine();
                    Console.WriteLine("Please give the password of the account you want to remove");
                    string removeAccountPass = Console.ReadLine();
                    bank.RemoveAccount(removeAccountUser, removeAccountPass);
                    Console.WriteLine("Successfully removed account");
                }
            }
            

        }
    }
}