using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SecondChange_1651
{
    public class ComicManagement : Comics, IMenu
    {
        private List<Comics> comicslist;

        public ComicManagement()
        {
            this.comicslist = new List<Comics>();
        }
        public void showMenu()
        {
            Program program = new Program();
            int choice;
            do
            {
                Console.WriteLine("===================================");
                Console.WriteLine("-----Welcome to COMICS MANAGER-----");
                Console.WriteLine("===================================");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Comic");
                Console.WriteLine("2. Update Comic");
                Console.WriteLine("3. Delete Comic");
                Console.WriteLine("4. Show All Comics");
                Console.WriteLine("5. Search Comic");
                Console.WriteLine("6. Back to Menu Main");
                Console.WriteLine("-----------------------");
                Console.Write("Please enter your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > 6)
                {
                    Console.WriteLine("Incorrect choice, please re-enter!!");
                    Console.Write("Please enter your choice: ");
                }
                switch (choice)
                {
                    case 1:
                        AddComic(comicslist);
                        break;
                    case 2:
                        UpdateComic(comicslist);
                        break;
                    case 3:
                        DeleteComic(comicslist);
                        break;
                    case 4:
                        ShowInformation();
                        break;
                    case 5:
                        SearchComic(comicslist);
                        break;
                    case 6:
                        program.ShowMenu();
                        break;
                    default:
                        Console.WriteLine("Incorrect choice, please try again!!");
                        break;
                }
            } while (choice != 6);
        }

        public void AddComic(List<Comics> comicslist)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Enter how many comics you need to add: ");
            int n = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }
            for (int i = 0; i < n; i++)
            {
                ComicManagement comicmanagement = new ComicManagement();
                comicmanagement.InputInforComic();
                comicslist.Add(comicmanagement);
            }
        }

        private static List<int> idAlreadyExists = new List<int>();
        public void InputInforComic()
        {
            // Comic ID
            Console.WriteLine("Please enter the Comic ID: ");
            bool isComicIdValid = false;
            while (!isComicIdValid)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0)
                    {
                        if (idAlreadyExists.Contains(input))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This Comic ID already exists. Please enter a different ID.");
                            Console.ResetColor();
                        }
                        else
                        {
                            ID = input;
                            idAlreadyExists.Add(input);
                            isComicIdValid = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Comic ID.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number for the Comic ID.");
                    Console.ResetColor();
                }
            }
            // Comic Name
            while (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Please enter the comic name: ");
                Name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Comic name cannot be empty. Please enter a valid name.");
                    Console.ResetColor();
                }
            }
            // Author Name
            while (string.IsNullOrWhiteSpace(Author))
            {
                Console.WriteLine("Please enter the author name: ");
                Author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Author))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Author name cannot be empty. Please enter a valid name.");
                    Console.ResetColor();
                }
            }
            // Comic Price
            Console.WriteLine("Please enter the comic price (VND): ");
            while (true)
            {
                try
                {
                    double price = double.Parse(Console.ReadLine());
                    if (price > 0)
                    {
                        Price = price;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the price.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid price format. Please enter a valid integer price.");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Comic with ID {ID} added successfully!");
            Console.ResetColor();
            Console.WriteLine("---------------------------- ");
        }

        public void UpdateComic(List<Comics> comicslist)
        {
            bool isValidID = false;
            int comicid = -1;
            Comics comicToUpdate = null;
            string userInput;

            while (!isValidID)
            {
                Console.WriteLine("--- Update Comic ---");
                Console.Write("Enter the ID of the comic to update (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Update canceled.");
                    return;
                }
                try
                {
                    comicid = int.Parse(userInput);
                    if (comicid > 0)
                    {
                        for (int i = 0; i < comicslist.Count; i++)
                        {
                            if (comicslist[i].ID == comicid)
                            {
                                comicToUpdate = comicslist[i];
                                isValidID = true;
                                break;
                            }
                        }
                        if (!isValidID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Comic not found. Please try again or enter 'exit' to cancel.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Comic ID.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID or enter 'exit' to cancel.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Enter the new comic name (or leave blank to keep the existing name): ");
            string newComicName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newComicName))
            {
                comicToUpdate.Name = newComicName;
            }

            Console.WriteLine("Enter the new author name (or leave blank to keep the existing author name): ");
            string newAuthorComic = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthorComic))
            {
                comicToUpdate.Author = newAuthorComic;
            }

            Console.WriteLine("Enter the new price: ");
            while (true)
            {
                try
                {
                    double price = double.Parse(Console.ReadLine());
                    if (price > 0)
                    {
                        comicToUpdate.Price = price;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the price.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid price format. Please enter a valid integer price.");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Comic with ID {comicid} updated successfully!");
            Console.ResetColor();
            Console.WriteLine("---------------------------- ");
        }

        public void DeleteComic(List<Comics> comicslist)
        {
            bool isValidID = false;
            int comicid = -1;
            Comics comicToDelete = null;
            string userInput;

            while (!isValidID)
            {
                Console.WriteLine("--- Delete Comic ---");
                Console.Write("Enter the ID of the comic to delete (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Delete canceled.");
                    return;
                }
                try
                {
                    comicid = int.Parse(userInput);
                    if (comicid > 0)
                    {
                        for (int i = 0; i < comicslist.Count; i++)
                        {
                            if (comicslist[i].ID == comicid)
                            {
                                comicToDelete = comicslist[i];
                                isValidID = true;
                                break;
                            }
                        }

                        if (!isValidID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Comic not found. Please try again.");
                            Console.ResetColor();
                        }
                        else
                        {
                            comicslist.Remove(comicToDelete); // Remove the comic from the list
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Comic with ID {comicid} deleted successfully!");
                            Console.ResetColor();
                            Console.WriteLine("---------------------------- ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Comic ID.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID or enter 'exit' to cancel.");
                    Console.ResetColor();
                }
            }
        }

        public override void ShowInformation()
        {
            Console.WriteLine("---------------Comics information---------------");
            if (comicslist.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No comics available in the list.");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < comicslist.Count; i++)
                {
                    var comic = comicslist[i];
                    Console.WriteLine($"ComicID: {comic.ComicID}; ComicName: {comic.NameComic}; AuthorName: {comic.AuthorComic}; Price ($): {comic.PriceComic}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Displayed successfully!");
                    Console.ResetColor();
                    Console.WriteLine("---------------------------- ");
                }
            }
        }

        public void SearchComic(List<Comics> comicslist)
        {
            bool continueSearching = true;

            while (continueSearching)
            {
                int comicid = -1;
                string userInput;

                Console.WriteLine("--- Search Comic ---");
                Console.Write("Enter the ID of the comic to search (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Search canceled.");
                    return;
                }

                try
                {
                    comicid = int.Parse(userInput);

                    if (comicid <= 0)
                    {
                        throw new FormatException();
                    }

                    bool found = false;
                    foreach (var comic in comicslist)
                    {
                        if (comic.ID == comicid)
                        {
                            Console.WriteLine($"ComicID: {comic.ComicID}; ComicName: {comic.NameComic}; AuthorName: {comic.AuthorComic}; Price ($): {comic.PriceComic}");
                            found = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Comic found successfully.");
                            Console.ResetColor();
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Comic not found. Please try again.");
                        Console.ResetColor();
                    }
                    else
                    {
                        continueSearching = false;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID or enter 'exit' to cancel.");
                    Console.ResetColor();
                }
            }
        }
    }
}
