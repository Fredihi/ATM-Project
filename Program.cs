using System;

namespace ATM_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogIn();
        }
        public static void LogIn()
        {
            //A 2d string array for Users
            string[,] Users = new string[5, 2];
            Users[0, 0] = "Alfred";
            Users[0, 1] = "1234";

            Users[1, 0] = "Rolf";
            Users[1, 1] = "5454";

            Users[2, 0] = "Niklas";
            Users[2, 1] = "1337";

            Users[3, 0] = "Hilma";
            Users[3, 1] = "9999";

            Users[4, 0] = "Seb";
            Users[4, 1] = "0201";

            //A jagged decimal array of Accounts
            decimal[][] Account = new decimal[5][];
            Account[0] = new decimal[2];
            Account[1] = new decimal[2];
            Account[2] = new decimal[3];
            Account[3] = new decimal[4];
            Account[4] = new decimal[4];

            Account[0][0] = 19042.42m;
            Account[0][1] = 4000.21m;

            Account[1][0] = 13235.40m;
            Account[1][1] = 2000;

            Account[2][0] = 5644.34m;
            Account[2][1] = 2405.50m;
            Account[2][2] = 64613.34m;

            Account[3][0] = 12567.90m;
            Account[3][1] = 735.34m;
            Account[3][2] = 1395.20m;
            Account[3][3] = 4041.12m;

            Account[4][0] = 56456.21m;
            Account[4][1] = 13550.78m;
            Account[4][2] = 409.59m;
            Account[4][3] = 1754.12m;

            int LogInAttempts = 3;
            bool LoggedIn = false;
            bool CorrectCred = false;

            //Keeps program running until you've run out of attempts to log in.
            while (LoggedIn == false && LogInAttempts != 0)
            {
                while (CorrectCred == false)//Runs this loop until you've entered the right credentials
                {
                    Console.WriteLine("Välkommen till banken, vänligen logga in.");
                    Console.Write("Användarnamn:");
                    string UserName = Console.ReadLine();
                    Console.Write("Pinkod:");
                    string PinKod = Console.ReadLine();
                    ExistingUser(Users, UserName, PinKod);
                    
                    if (ExistingUser(Users, UserName, PinKod))//If UserName exists and the right Pin has been entered it logs in to the program
                    {
                        Console.Clear();
                        LoggedIn = true;
                        BankMenu(UserName, Users, Account, LoggedIn);


                    }
                    else if (!ExistingUser(Users, UserName, PinKod))
                    {
                        Console.WriteLine("Fel användarnamn eller pinkod, försök igen.");
                        System.Threading.Thread.Sleep(500);//Pauses the console a little bit before letting you try again
                        Console.Clear();
                        CorrectCred = false;
                        LogInAttempts--;
                    }
                    while (LogInAttempts == 0)
                    {
                        Console.WriteLine("Du har försökt för många gånger, försök igen senare");
                        Console.ReadKey();
                        Environment.Exit(0); //Exits the program if there are no more attempts
                    }
                }
            }
        }
        //Checks if Username matches a user in Users array
        static bool ExistingUser(string[,] Users, string UserName, string PinKod)
        {
            for (int i = 0; i < Users.GetLength(0); i++)
            {
                if (Users[i, 0] == UserName && Users[i, 1] == PinKod)
                {
                    return true; //If UserName and PinKod matches one in the Users array it will return true
                }
            }
            return false;//If it does not match a user it will return false
        }
        //Method for the bankmenu
        public static void BankMenu(string UserName, string[,]Users, decimal[][] Account, bool LoggedIn)
        {
            int Menu = 0;
            do
            {
                try
                {
                    Console.WriteLine("Vänligen välj ett alternativ nedan");
                    Console.WriteLine("1 - Se konton & saldo");
                    Console.WriteLine("2 - Överföring av pengar");
                    Console.WriteLine("3 - Ta ut pengar");
                    Console.WriteLine("4 - Logga ut");
                    Menu = int.Parse(Console.ReadLine());
                    switch (Menu)
                    {
                        case 1:
                            Console.Clear();
                            Accounts(UserName, Users, Account);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Transfer(Users, Account, UserName);
                            Console.Clear();
                            break;
                        case 3:
                            //Ta ut pengar
                            Console.Clear();
                            break;
                        case 4:
                            Console.WriteLine("Du har loggat ut.");
                            System.Threading.Thread.Sleep(1500); //"Pauses" the console a little bit before "logging out"
                            LoggedIn = false; //Changes LoggedIn bool to false so it can go back to "LogIn()" loop
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Vänligen välj något av valen");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                }
            } while (LoggedIn == true);
        }
        //Checks which user that is active and sets an index to it which we can use to edit the balance of the accounts of the user
        public static int ActiveUser(string[,] Users, string UserName)
        {
            for (int i = 0; i < Users.GetLength(0); i++)
            {
                if (Users[i, 0] == UserName)
                {
                    return i;
                }
            }
            return 0;
        }
        //Method to check balance of accounts
        public static void Accounts(string UserName, string[,] Users, decimal[][] Account)
        {
            int IndexUser = ActiveUser(Users, UserName);//Index of the user that is currently logged in
            string[] Acc = { "Lönekonto.", "Sparkonto.", "Semesterkonto.", "Pensionkonto." };//Array for all the accounts names
            Console.WriteLine("Konton");
            for (int i = 0; i < Account[IndexUser].Length; i++)//Loops throught the account of the user
            {
                if (Account[IndexUser][i] != 0)
                {
                    Console.WriteLine($"Du har {Account[IndexUser][i]}kr på ditt {Acc[i]} ");
                }
            }
        }
        //Method to transfer money from accounts within the user
        public static void Transfer(string[,] Users, decimal[][] Account, string UserName)
        {
            Console.Clear();
            int IndexUser = ActiveUser(Users, UserName);//Index of the user that is currently logged in
            try
            {
                string[] Acc = { "Lönekonto", "Sparkonto", "Semesterkonto", "Pensionkonto" };//Array for all the accounts names
                string[] AccChoice = { "1 - Lönekonto\n", "2 - Sparkonto\n", "3 - Semestersparande\n", "4 - Pension\n" };//Array for choices
                Console.WriteLine("Ifrån vilket konto vill du flytta över ifrån?");
                for (int i = 0; i < Account[IndexUser].Length; i++)
                {
                    foreach (var item in AccChoice[i])//Prints the choices that the use can choose from (depending on how many accounts)
                    {
                        Console.Write(item);
                    }
                }
                int FirstCh = int.Parse(Console.ReadLine());//Which account to transfer from
                switch (FirstCh)
                {
                    case 1:
                        FirstCh = 0;
                        break;
                    case 2:
                        FirstCh = 1;
                        break;
                    case 3:
                        FirstCh = 2;
                        break;
                    case 4:
                        FirstCh = 3;
                        break;
                }

                Console.Clear();

                Console.WriteLine("Vilket konto vill du flytta över till?");
                for (int i = 0; i < Account[IndexUser].Length; i++)
                {
                    foreach (var item in AccChoice[i])//Prints the choices that the use can choose from (depending on how many accounts)
                    {
                        Console.Write(item);
                    }
                }
                int SecondCh = int.Parse(Console.ReadLine());//Which account to transfer to
                switch (SecondCh)
                {
                    case 1:
                        SecondCh = 0;
                        break;
                    case 2:
                        SecondCh = 1;
                        break;
                    case 3:
                        SecondCh = 2;
                        break;
                    case 4:
                        SecondCh = 3;
                        break;
                }

                Console.Clear();
                Console.WriteLine("Hur mycket vill du flytta över?");
                decimal Sum = decimal.Parse(Console.ReadLine());//Amount to transfer
                Console.Clear();

                if (Sum > Account[IndexUser][FirstCh])//If the amount to transfer is more than what is available on the account
                {
                    Console.WriteLine("Beloppet du försöker överföra överskrider summan på kontot.");
                }
                else
                {
                    decimal A1 = Account[IndexUser][FirstCh] - Sum;//Amount to be removed from the first to choice stored in a variable
                    decimal A2 = Account[IndexUser][SecondCh] + Sum;//Amount to be added to the second choice stored in a variable
                    Account[IndexUser][FirstCh] = A1;//Declaring that the first account has been subtracted the amount stored in "Sum"
                    Account[IndexUser][SecondCh] = A2;//Declaring that the second account has been added the amount stored in "Sum"
                    Console.WriteLine($"Du har flyttat över {Sum} från ditt {Acc[FirstCh]} till ditt {Acc[SecondCh]}.");
                    Console.WriteLine();
                    Console.WriteLine("Nuvarande saldo på konton");

                    for (int i = 0; i < Account[IndexUser].Length; i++)
                    {
                        if (Account[IndexUser][i] != 0)
                        {
                            Console.Write(Acc[i]);
                            Console.Write(": ");
                            Console.WriteLine(Account[IndexUser][i]);
                        }
                    }
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Fel inmatning");
            }
            Console.ReadKey();
        }
    }
}
