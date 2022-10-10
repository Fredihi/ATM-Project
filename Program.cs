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
            string[,] Users = new string[5, 2];
            Users[0, 0] = "Alfred";
            Users[0, 1] = "1234";

            Users[1, 0] = "Rolf";
            Users[1, 1] = "5454";

            Users[2, 0] = "Niklas";
            Users[2, 1] = "1337";

            Users[3, 0] = "Mikaela";
            Users[3, 1] = "9999";

            Users[4, 0] = "Seb";
            Users[4, 1] = "0201";

            decimal[][] Account = new decimal[5][];
            Account[0] = new decimal[2];
            Account[1] = new decimal[2];
            Account[2] = new decimal[3];
            Account[3] = new decimal[4];
            Account[4] = new decimal[4];

            Account[0][0] = 19042.42m;
            Account[0][1] = 4000.21m;

            Account[1][0] = 13235.40m;
            Account[1][0] = 2000;

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
            bool CorrectCred = false;
            Console.WriteLine("Välkommen till banken, vänligen logga in");

            while (LogInAttempts != 0 && CorrectCred != true)
            {
                Console.Write("Användarnamn:");
                string UserName = Console.ReadLine();
                Console.Write("Pinkod:");
                string PinKod = Console.ReadLine();
                //ExistingUser(Users, UserName, PinKod);

                if (/*ExistingUser(Users, UserName, PinKod)*/)
                {
                    CorrectCred = true;
                    BankMenu(UserName, Users);
                }
                else
                {
                    CorrectCred = false;
                    LogInAttempts--;
                }
                while (LogInAttempts == 0)
                {
                    Console.WriteLine("Du har försökt för många gånger, försök igen senare");
                    Console.ReadKey();
                }
            }
        }

        public static void BankMenu(string UserName, string[,]Users)
        {
            int Menu = 0;
            bool LoggedIn = true;
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
                            //Accounts();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            //Transfer();
                            Console.Clear();
                            break;
                        case 3:
                            //Ta ut pengar
                            Console.Clear();
                            break;
                        case 4:
                            Console.WriteLine("Du har loggat ut.");
                            System.Threading.Thread.Sleep(1500);
                            LoggedIn = false;
                            Console.Clear();
                            Main(null);
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
    }
}
