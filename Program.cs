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

        public static void BankMenu()
        {

        }
    }
}
