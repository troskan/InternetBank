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
                new string[] {"Sven", "Häst123", "Lönekonto", "13000", "Sparkonto", "23.83"},
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

            DoWhatUserDecides(userName, userLoggedIn,  bankAccounts);
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
                        TransferMoney(bankAccounts, userName);
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
        static void DisplayCorrectAccount(List<string[]> bankAccounts, int whichArray)
        {
            Console.WriteLine("1." + bankAccounts[whichArray][2]);
            Console.WriteLine("2." + bankAccounts[whichArray][3]);
            Console.WriteLine("3." + bankAccounts[whichArray][4]);
            Console.WriteLine("4." + bankAccounts[whichArray][5]);
        }
        static void TransferMoney(List<string[]> bankAccounts, string userName)
        {
            int whichUser = DisplayAccountBalance(bankAccounts, userName);
            Console.WriteLine("Välj ett konto att göra en överförning ifrån.");

            int withdrawFrom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Välj ett konto att göra en överförning till.");

            int withdrawTo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hur mycket vill du föra över?");

            double salaryAccount = Convert.ToDouble(bankAccounts[whichUser][4]);
            double savingsAccount = Convert.ToDouble(bankAccounts[whichUser][6]);
            double startAccount = Convert.ToDouble(bankAccounts[whichUser][withdrawFrom]);
            double endAccount = Convert.ToDouble(bankAccounts[whichUser][withdrawTo]);

            double cashAmount = Convert.ToInt32(Console.ReadLine());
            bool isRunning = true;

            while (isRunning)
            {
                if (cashAmount > startAccount)
                {
                    Console.WriteLine("Aj då! Så mycket pengar finns inte på kontot!");
                    isRunning = false;
                }
                else if (cashAmount <= 0)
                {
                    Console.WriteLine("Aj då.. minsta belopp att föra över är 1 krona.");
                    isRunning = false;
                }
                endAccount = +cashAmount;
                startAccount = -cashAmount;
                DisplayAccountBalance(bankAccounts, userName);

            }
        }
        static void WithdrawMoney()
        {

        }
    }
}
