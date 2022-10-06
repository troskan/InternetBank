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
        //Does the user have an account?
        static bool DoesUserExist(List<string[]> bankAccounts, string userName, string userPass)
        {
            //For loop to set the max login tries.
            for (int i = 1; i < 3; i++)
            {
                //Foreach to expouse all content from bank
                foreach (string[] user in bankAccounts)
                {
                    if (user.Contains(userName) && user.Contains(userPass))
                    {
                        return true;
                    }
                }
                Console.Clear();
                Console.WriteLine("Lösenord eller användarenamn stämmer inte, försök igen.");
                UserNameInput();
                UserPassInput();
            }
            Console.WriteLine("Inloggning har misslyckats! Programmet kommer nu avslutas.");
            Console.ReadKey();
            return false;
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
                        Console.WriteLine("Your account.");
                        DisplayAccountBalance(bankAccounts, userName);
                        Console.ReadKey();
                        break;
                    case 2:
                        TransferMoney(bankAccounts, userName, account);
                        Console.ReadKey();

                        Console.WriteLine("Transfer");
                        break;
                    case 3:
                        Console.WriteLine("Ta ut pengar");
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
            account = InputConversion(bankAccounts, userName);

            Console.WriteLine("Från vilket konto vill du göra en överförning?");
            int transferFrom = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Till vilket konto vill du göra en överförning?");
            int transferTo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hur mycket pengar vill du överföra?");
            decimal cashAmount = Convert.ToDecimal(Console.ReadLine());
            bool isRunning = true;

            //while (isRunning)
            //{
            //    if (cashAmount > account[transferFrom])
            //    {
            //        Console.WriteLine("Aj då! Så mycket pengar finns inte på kontot!");
            //        isRunning = false;
            //    }
            //    else if (cashAmount <= 0)
            //    {
            //        Console.WriteLine("Aj då.. minsta belopp att föra över är 1 krona.");
            //        isRunning = false;
            //    }

            account[transferFrom] = account[transferFrom] - cashAmount;
            account[transferTo] = account[transferTo] + cashAmount;

            OutputConversion(bankAccounts, userName, account);
           
            Console.WriteLine(account[1]);
            Console.WriteLine(account[2]);

            //}
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
            bankAccounts[user][3] = account[1].ToString();
            bankAccounts[user][5] = account[2].ToString();
            return bankAccounts;
        }
        static void WithdrawMoney()
        {
            
        }
    }
}
