using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividuelltProjektBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Accounts
            List<string[]> bankAccounts = new List<string[]>
            {
                new string[] {"Sven", "Häst123", "Lönekonto", "13000.00", "Sparkonto", "23.83"},
                new string[] {"Javier", "Volvo55", "Lönekonto", "10000.00", "Sparkonto", "40000.00"},
                new string[] {"Anna", "skog55", "Lönekonto", "25000.00", "Sparkonto", "20000.00"},
                new string[] {"Sara", "Äpple22", "Lönekonto", "3000.00", "Sparkonto", "70000.00"},
                new string[] {"Maja", "Harv55", "Lönekonto", "200.00", "Sparkonto", "8530000.00"},
            };

            WelcomeMessage();
          
            DisplayMenu(UserExist(bankAccounts, UserNameInput(), UserPassInput()));
        }
        static void WelcomeMessage()
        {
            Console.WriteLine("Välkommen till Derome Bank!");
            Console.WriteLine("Du kommer att få 3 försök på att logga in.");
        }
        static string UserNameInput()
        {
            string userName;
            Console.WriteLine("Skriv ditt användernamn.");
            return userName = Console.ReadLine();
            
        }
        static string UserPassInput()
        {
            string userPass;
            Console.WriteLine("Skriv ditt lösenord.");
            return userPass = Console.ReadLine();
        }
        static bool UserExist(List<string[]> bankAccounts, string userName, string userPass)
        {
            foreach (string[] user in bankAccounts)
            {
                if (user.Contains(userName) && user.Contains(userPass))
                {
                    return true;
                }
            }
            return false;
        }
        static void DisplayMenu(bool isLoggedIn)
        {
            isLoggedIn = false;
            if (isLoggedIn == false)
            {
                Console.WriteLine("You are not logged in.");
            }
            while (isLoggedIn)
            {
                Console.WriteLine($"You are logged in.");

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
