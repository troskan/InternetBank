using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividuelltProjektBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usernames, passwords, first account, account balance, secound account, account balance,
            List<string[]> bankAccounts = new List<string[]>
            {
                new string[] {"Sven", "Häst123", "Lönekonto", "13000,00", "Sparkonto", "23,83"},
                new string[] {"Javier", "Volvo55", "Lönekonto", "10000.00", "Sparkonto", "40000.00"},
                new string[] {"Anna", "skog55", "Lönekonto", "25000.00", "Sparkonto", "20000.00"},
                new string[] {"Sara", "Äpple22", "Lönekonto", "3000.00", "Sparkonto", "70000.00"},
                new string[] {"Maja", "Harv55", "Lönekonto", "200.00", "Sparkonto", "8530000.00"},
            };
            WelcomeMessage();

            string userName = UserNameInput();
            string password = UserPassInput();
            bool userLoggedIn = DoesUserExist(bankAccounts, userName, password);

            DisplayMenu(userLoggedIn);

            DoWhatUserDecides(userName, userLoggedIn, bankAccounts);

        }
        static void WelcomeMessage()
        {
            Console.WriteLine("Välkommen till Derome Bank!");
            Console.WriteLine("Du kommer att få 3 försök på att logga in.");
        }
        static string UserNameInput()
        {
            Console.WriteLine("Skriv ditt användernamn. Tänk på att använda stor och liten bokstav!");
            string userName = Console.ReadLine();
            return userName;
        }
        static string UserPassInput()
        {
            Console.WriteLine("Skriv ditt lösenord.");
            string userPass = Console.ReadLine();
            return userPass;
        }
        static bool DoesUserExist(List<string[]> bankAccounts, string userName, string userPass)
        {
            //Foreach to expouse all content from bank
            foreach (string[] user in bankAccounts)
            {
                //Does the user exist inside array?
                if (user.Contains(userName) && user.Contains(userPass))
                {
                    return true;
                }
            }
            //User does not exist, try again
            for (int i = 0; i < 2; i++)
            {
                if (TryLogin(userName, userPass, bankAccounts) == true)
                {
                    return true;
                }
            }
            //User has not been found.
            Console.WriteLine("För många inloggningsförsök, programmet avslutas.");
            return false;
        }
        static bool TryLogin(string userName, string userPass, List<string[]> bankAccounts)
        {
            userName = UserNameInput();
            userPass = UserPassInput();
            foreach (string[] user in bankAccounts)
            {
                //Does the user exist inside array?
                if (user.Contains(userName) && user.Contains(userPass))
                {
                    return true;
                }
            }
            return false;
        }
        static void DisplayMenu(bool isLoggedIn)
        {
            if (isLoggedIn == true)
            {
                Console.Clear();
                Console.WriteLine($"Du är inloggad.");

                Console.WriteLine("1.Se dina konton och saldo");
                Console.WriteLine("2.Överföring mellan konton");
                Console.WriteLine("3.Ta ut pengar");
                Console.WriteLine("4.Logga ut");
            }

        }
        static void DoWhatUserDecides(string userName, bool isLoggedIn, List<string[]> bankAccounts)
        {
            decimal[] account = new decimal[2];
            while (isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine($"Du är inloggad.");

                Console.WriteLine("1.Se dina konton och saldo");
                Console.WriteLine("2.Överföring mellan konton");
                Console.WriteLine("3.Ta ut pengar");
                Console.WriteLine("4.Logga ut");

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        //metod
                        Console.WriteLine("Ditt konto.");
                        DisplayAccountBalance(bankAccounts, userName);
                        Console.ReadKey();
                        break;
                    case 2:
                        TransferMoney(bankAccounts, userName, account);
                        Console.ReadKey();
                        break;
                    case 3:
                        WithdrawMoney(bankAccounts, account, userName);
                        break;
                    case 4:
                        isLoggedIn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Number does not exist, eneter another number.");
                        break;
                }
            }

        }

        static int DisplayAccountBalance(List<string[]> bankAccounts, string userName)
        {
            if (userName == bankAccounts[0][0])
            {
                DisplayCorrectAccount(bankAccounts, 0);
                return 0;
            }
            else if (userName == bankAccounts[1][0])
            {
                DisplayCorrectAccount(bankAccounts, 1);
                return 1;
            }
            else if (userName == bankAccounts[2][0])
            {
                DisplayCorrectAccount(bankAccounts, 2);
                return 2;
            }
            else if (userName == bankAccounts[3][0])
            {
                DisplayCorrectAccount(bankAccounts, 3);
                return 3;
            }
            else if (userName == bankAccounts[4][0])
            {
                DisplayCorrectAccount(bankAccounts, 4);
                return 4;
            }
            return 0;
        }
        static int WhichAccount(List<string[]> bankAccounts, string userName)
        {
            if (userName == bankAccounts[0][0])
            {
                return 0;
            }
            else if (userName == bankAccounts[1][0])
            {
                return 1;
            }
            else if (userName == bankAccounts[2][0])
            {
                return 2;
            }
            else if (userName == bankAccounts[3][0])
            {
                return 3;
            }
            else if (userName == bankAccounts[4][0])
            {
                return 4;
            }
            return 0;
        }
        static void DisplayCorrectAccount(List<string[]> bankAccounts, int user)
        {
            Console.WriteLine("1." + bankAccounts[user][2]);
            Console.WriteLine(bankAccounts[user][3]);
          
            Console.WriteLine("2." + bankAccounts[user][4]);
            Console.WriteLine(bankAccounts[user][5]);
        }
        static void TransferMoney(List<string[]> bankAccounts, string userName, decimal[] account)
        {
            //From List to Decimal to change value in bank account
            account = InputConversion(bankAccounts, userName);
            
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine($"1. Lönekonto: {account[1]}");
                Console.WriteLine($"2. Sparkonto: {account[2]}");

                Console.WriteLine("Från vilket konto vill du göra en överförning?");
                int transferFrom = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Till vilket konto vill du göra en överförning?");
                int transferTo = Convert.ToInt32(Console.ReadLine());

                if (transferFrom != 1 && transferFrom != 2)
                {
                Console.WriteLine("Kontot du avgav existerar inte.");
                    break;
                }

                else if (transferTo != 1 && transferTo != 2)
                {
                Console.WriteLine("Kontot du avgav existerar inte.");
                    break;
                }

                Console.WriteLine("Hur mycket pengar vill du överföra?");
                decimal cashAmount = Convert.ToDecimal(Console.ReadLine());

                if (cashAmount > account[transferFrom])
                {
                    Console.WriteLine("Aj då! Så mycket pengar finns inte på kontot!");
                    break;
                }
                else if (cashAmount <= 0)
                {
                    Console.WriteLine("Aj då.. minsta belopp att föra över är 1 krona.");
                    break;
                }
                else
                {
                    account[transferFrom] = account[transferFrom] - cashAmount;
                    account[transferTo] = account[transferTo] + cashAmount;

                    OutputConversion(bankAccounts, userName, account);

                    Console.WriteLine($"1. Lönekonto:{account[1]}");
                    Console.WriteLine($"2. Sparkonto:{account[2]}");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static decimal[] InputConversion(List<string[]> bankAccounts, string userName)
        {
            decimal[] account = new decimal[3];
            int user = WhichAccount(bankAccounts, userName);

            account[1] = Convert.ToDecimal(bankAccounts[user][3]);
            account[2] = Convert.ToDecimal(bankAccounts[user][5]);

            return account;
        }
        static List<string[]> OutputConversion(List<string[]> bankAccounts, string userName, decimal[] account)
        {
            int user = WhichAccount(bankAccounts, userName);

            account[1] = Math.Round(account[1], 2);
            account[2] = Math.Round(account[2], 2);

            bankAccounts[user][3] = account[1].ToString();
            
            bankAccounts[user][5] = account[2].ToString();
            return bankAccounts;
        }
        static void WithdrawMoney(List<string[]> bankAccounts, decimal[] account,string userName)
        {
           account = InputConversion(bankAccounts, userName);

            while (true)
            {
                Console.WriteLine($"1. Lönekonto: {account[1]}");
                Console.WriteLine($"2. Sparkonto: {account[2]}");

                Console.WriteLine("Från vilket konto vill du ta ut pengar?");
                int withdrawFrom = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Hur mycket pengar vill du ta ut?");
                decimal cashAmount = Convert.ToDecimal(Console.ReadLine());

                if (cashAmount > account[withdrawFrom])
                {
                    Console.WriteLine("Aj då, beloppet du har valt att ta ut finns inte på ditt konto.");
                    break;
                }
                else if (cashAmount <= 0)
                {
                    Console.WriteLine("Minsta tillåtna belopp att ta ut är: 0kr.");
                    break;
                }
                if (withdrawFrom != 1 && withdrawFrom != 2)
                {
                    Console.WriteLine("Tyvärr, det kontot du har valt existerar inte..");
                    break;
                }

                account[withdrawFrom] = account[withdrawFrom] - cashAmount;
                OutputConversion(bankAccounts, userName, account);
                Console.WriteLine($"1. Lönekonto: {account[1]}");
                Console.WriteLine($"2. Sparkonto: {account[2]}");
                Console.ReadKey();
                break;

            }

        }
    }
}
