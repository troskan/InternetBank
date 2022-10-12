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
                new string[] {"Sven", "1950", "Lönekonto", "13000,00", "Sparkonto", "23,83"},
                new string[] {"Javier", "1955", "Lönekonto", "10000,00", "Sparkonto", "40000,00"},
                new string[] {"Anna", "1996", "Lönekonto", "25000,00", "Sparkonto", "20000,00"},
                new string[] {"Sara", "2022", "Lönekonto", "3000,00", "Sparkonto", "70000,00"},
                new string[] {"Maja", "4050", "Lönekonto", "200,00", "Sparkonto", "8530000,00"},
            };
            WelcomeMessage();

            //Login and verify credentials.
            string userName = UserNameInput();
            string password = UserPassInput();
            bool userLoggedIn = DoesUserExist(bankAccounts, userName, password);

            //Show menu and execute choices.
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
            //Foreach to expose all content from bank
            foreach (string[] user in bankAccounts)
            {
                //Does the user exist inside array?
                if (user.Contains(userName) && user.Contains(userPass))
                {
                    return true;
                }
            }
            //User does not exist, try again "i" times.
            for (int i = 0; i < 2; i++)
            {
                //Get user input
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
            //First login attempt failed, now run try login to try X more times.
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
        static void DoWhatUserDecides(string userName, bool isLoggedIn, List<string[]> bankAccounts)
        {
            //New array to re-save the bank values in Decimal form.
            decimal[] account = new decimal[2];

            while (isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine($"Du är inloggad.");

                Console.WriteLine("1.Se dina konton och saldo");
                Console.WriteLine("2.Överföring mellan konton");
                Console.WriteLine("3.Ta ut pengar");
                Console.WriteLine("4.Logga ut");

                int.TryParse(Console.ReadLine(), out int input);
                //Main menu.
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        DisplayAccountBalance(bankAccounts, userName);

                        Console.WriteLine("Tryck på enter för att gå vidare..");
                        Console.ReadKey();
                        break;
                    case 2:
                        TransferMoney(bankAccounts, userName, account);
                        break;
                    case 3:
                        WithdrawMoney(bankAccounts, account, userName);
                        break;
                    case 4:
                        isLoggedIn = Login(bankAccounts, userName, isLoggedIn);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Number does not exist, eneter another number.");
                        break;
                }
            }
        }
        static int DisplayAccountBalance(List<string[]> bankAccounts, string userName)
        {   //If user = first array, first slot.
            if (userName == bankAccounts[0][0])
            {
                //Display correct slot in array.
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
        static void DisplayCorrectAccount(List<string[]> bankAccounts, int user)
        {
            //depending on who is the user, show correct account.
            Console.WriteLine($"1. {bankAccounts[user][2]}: {bankAccounts[user][3]} kr");
            Console.WriteLine($"2. {bankAccounts[user][4]}: {bankAccounts[user][5]} kr");
        }
        static void TransferMoney(List<string[]> bankAccounts, string userName, decimal[] account)
        {
            Console.Clear();

            //From List to Decimal to change value in bank account
            account = InputConversion(bankAccounts, userName);

            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                DisplayAccountBalance(bankAccounts, userName);

                //Decide which accounts to transfer from and to.
                Console.WriteLine("Från vilket konto vill du göra en överförning?");
                int.TryParse(Console.ReadLine(), out int transferFrom);

                Console.WriteLine("Till vilket konto vill du göra en överförning?");
                int.TryParse(Console.ReadLine(), out int transferTo);

                //If user enters a number not tied to a account.
                if (transferFrom != 1 && transferFrom != 2)
                {
                    Console.WriteLine("Kontot du avgav existerar inte.");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }

                else if (transferTo != 1 && transferTo != 2)
                {
                    Console.WriteLine("Kontot du avgav existerar inte.");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();

                    break;
                }

                Console.WriteLine("Hur mycket pengar vill du överföra?");
                decimal.TryParse(Console.ReadLine(), out decimal cashAmount);

                //Desired amount to transfer is either too low or too high.
                if (cashAmount > account[transferFrom])
                {
                    Console.WriteLine("Aj då! Så mycket pengar finns inte på kontot!");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
                else if (cashAmount <= 0)
                {
                    Console.WriteLine("Aj då.. minsta belopp att föra över är 1 krona.");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    //Remove money from first account to give to the other account.
                    account[transferFrom] = account[transferFrom] - cashAmount;
                    account[transferTo] = account[transferTo] + cashAmount;
                    
                    //Convert result to string and send back to list array.
                    OutputConversion(bankAccounts, userName, account);
                   
                    DisplayAccountBalance(bankAccounts, userName);

                    Console.WriteLine("Tryck på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void WithdrawMoney(List<string[]> bankAccounts, decimal[] account, string userName)
        {
            Console.Clear();
            //account values to decimal so we can adjust the values.
            account = InputConversion(bankAccounts, userName);

            while (true)
            {
                DisplayAccountBalance(bankAccounts, userName);

                Console.WriteLine("Från vilket konto vill du ta ut pengar?");
                int.TryParse(Console.ReadLine(), out int withdrawFrom);
                Console.WriteLine("Hur mycket pengar vill du ta ut?");
                decimal.TryParse(Console.ReadLine(), out decimal cashAmount);

                if (cashAmount > account[withdrawFrom])
                {
                    Console.WriteLine("Aj då, beloppet du har valt att ta ut finns inte på ditt konto.");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
                else if (cashAmount <= 0)
                {
                    Console.WriteLine("Minsta tillåtna belopp att ta ut är: 0kr.");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
                if (withdrawFrom != 1 && withdrawFrom != 2)
                {
                    Console.WriteLine("Tyvärr, det kontot du har valt existerar inte..");

                    Console.WriteLine("Klicka på enter för att gå vidare..");
                    Console.ReadKey();
                    break;
                }
                //User logs in again before the transaction goes through.
                string userPass = UserPassInput();
                if(DoesUserExist(bankAccounts, userName, userPass) == false)
                {
                    Console.WriteLine("Fel uppgifter, uttag kunde inte genomföras!");
                    break;
                }
                //Remove cashamount from account.
                account[withdrawFrom] = account[withdrawFrom] - cashAmount;

                //Send back the new values in string form to list array.
                OutputConversion(bankAccounts, userName, account);

                DisplayAccountBalance(bankAccounts, userName);

                Console.WriteLine("Tryck på enter för att gå vidare..");
                Console.ReadKey();
                break;

            }

        }
        static int WhichAccount(List<string[]> bankAccounts, string userName)
        {
            //Assign user to bankaccount.
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
        static bool Login(List<string[]> bankAccounts, string userName, bool isLoggedIn)
        {
            Console.Clear();
            WelcomeMessage();
            //Input
            userName = UserNameInput();
            string password = UserPassInput();
            //Is the input correct?
            bool userLoggedIn = DoesUserExist(bankAccounts, userName, password);
            if (userLoggedIn == false)
            {
               return isLoggedIn = false;
            }
            return isLoggedIn = true;
        }


        static decimal[] InputConversion(List<string[]> bankAccounts, string userName)
        {
            //Account name, password and account balance is stored in string, we need to convert to decimal
            // then back to string to edit bank values.
            decimal[] account = new decimal[3];
            int user = WhichAccount(bankAccounts, userName);

            account[1] = Convert.ToDecimal(bankAccounts[user][3]);
            account[2] = Convert.ToDecimal(bankAccounts[user][5]);

            //returning as decimal
            return account;
        }
        static List<string[]> OutputConversion(List<string[]> bankAccounts, string userName, decimal[] account)
        {
            int user = WhichAccount(bankAccounts, userName);

            //Round, so we dont end up with 99,9439439939933939
            account[1] = Math.Round(account[1], 2);
            account[2] = Math.Round(account[2], 2);

            //Convert back as string then ship it back to the string array.
            bankAccounts[user][3] = account[1].ToString();
            bankAccounts[user][5] = account[2].ToString();
            return bankAccounts;
        }

    }
}
