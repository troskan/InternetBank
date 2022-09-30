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
                new string[] {"Sven", "Häst123", "Lönekonto", "13000.00", "Sparkonto", "23.83"},
                new string[] {"Javier", "Volvo55", "Lönekonto", "10000.00", "Sparkonto", "40000.00"},
                new string[] {"Anna", "skog55", "Lönekonto", "25000.00", "Sparkonto", "20000.00"},
                new string[] {"Sara", "Äpple22", "Lönekonto", "3000.00", "Sparkonto", "70000.00"},
                new string[] {"Maja", "Harv55", "Lönekonto", "200.00", "Sparkonto", "8530000.00"},
            };
            
            WelcomeMessage();

            bool userLoggedIn = UserExist(bankAccounts, UserNameInput(), UserPassInput());

            DisplayMenu(userLoggedIn);
            DoWhatUserDecides(userLoggedIn);

            
        }
        static void WelcomeMessage()
        {
            Console.WriteLine("Välkommen till Derome Bank!");
            Console.WriteLine("Du kommer att få 3 försök på att logga in.");
        }
        static string UserNameInput()
        {
            Console.WriteLine("Skriv ditt användernamn.");
            string userName = Console.ReadLine();
            return userName;
        }
        static string UserPassInput()
        {
            Console.WriteLine("Skriv ditt lösenord.");
            string userPass = Console.ReadLine();
            return userPass;
        }
        static bool UserExist(List<string[]> bankAccounts, string userName, string userPass)
        {

            for (int i = 1; i < 3; i++)
            {
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
        static void DoWhatUserDecides(bool isLoggedIn)
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
                        Console.WriteLine("Your account.");
                        break;
                    case 2:
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
        static void DisplayAccountBalance()
        {

        }
        static void TransferMoney()
        {

        }
        static void WithdrawMoney()
        {

        }
    }
}
