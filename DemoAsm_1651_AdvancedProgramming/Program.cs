using System;
using System.Collections.Generic;

namespace Demo_SecondChange_1651
{
    class Program
    {
        public bool isLoggedIn = false;
        private IMenu menu;
        public void Login()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("         Welcome to Login          ");
            Console.WriteLine("===================================");
            Console.WriteLine();

            while (!isLoggedIn)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                if (username == "Duc" && password == "281103")
                {
                    isLoggedIn = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Login successfully!");
                    Console.ResetColor();
                    ShowMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid username or password. Please try again.");
                    Console.ResetColor();
                }
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Welcome Menu Products!");
            Console.WriteLine("1. Menu Books");
            Console.WriteLine("2. Menu Comics");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-----------------------------------");
            Console.Write("Please enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > 3)
            {
                Console.WriteLine("Incorrect choice, please re-enter!!");
                Console.Write("Please enter your choice: ");
            }
            switch (choice)
            {
                case 1:
                    menu = new BookManagement();
                    menu.showMenu();
                    break;
                case 2:
                    menu = new ComicManagement();
                    menu.showMenu();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Incorrect choice, please try again!!");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Login();

            Information i;

            List<Products> product = new List<Products>();
            foreach (var p in product)
            {
                i = p;
                i.ShowInformation();
            }
        }
    }
}
