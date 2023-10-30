using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SecondChange_1651
{
    public class BookManagement : Books, IMenu
    {
        private List<Books> bookslist;
        public BookManagement()
        {
            this.bookslist = new List<Books>();
        }

        public void showMenu()
        {
            Program program = new Program();
            int choice;
            do
            {
                Console.WriteLine("==================================");
                Console.WriteLine("-----Welcome to BOOKS MANAGER-----");
                Console.WriteLine("==================================");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Show All Books");
                Console.WriteLine("5. Search Book");
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
                        AddBook(bookslist);
                        break;
                    case 2:
                        UpdateBook(bookslist);
                        break;
                    case 3:
                        DeleteBook(bookslist);
                        break;
                    case 4:
                        ShowInformation();
                        break;
                    case 5:
                        SearchBook(bookslist);
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

        public void AddBook(List<Books> bookslist)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Enter how many books you need to add: ");
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
                BookManagement bookmanagement = new BookManagement();
                bookmanagement.InputInforBook();
                bookslist.Add(bookmanagement);
            }
        }

        private static List<int> idAlreadyExists = new List<int>();
        public void InputInforBook()
        {
            // Book ID
            Console.WriteLine("Please enter the Book ID: ");
            bool isBookIdValid = false;
            while (!isBookIdValid)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0)
                    {
                        if (idAlreadyExists.Contains(input))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("This Book ID already exists. Please enter a different ID.");
                            Console.ResetColor();
                        }
                        else // Nếu trùng
                        {
                            BookID = input;  // nhập Book ID
                            idAlreadyExists.Add(input);
                            isBookIdValid = true;
                        }
                    }
                    else // Nếu nhỏ hơn 0
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Book ID.");
                        Console.ResetColor();
                    }
                }
                catch (FormatException) // Nếu nhập chữ
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number for the Book ID.");
                    Console.ResetColor();
                }
            }
            // Book Name
            while (string.IsNullOrWhiteSpace(NameBook))  // kiểm tra xem có phải null không, nếu có thì tiếp tục vòng lặp 
            {
                Console.WriteLine("Please enter the book name: ");
                NameBook = Console.ReadLine();  // nhập tên cuốn sách
                if (string.IsNullOrWhiteSpace(NameBook))  // kiểm tra xem nhập vào có bị trống không, nếu có thì hiện thông báo lỗi
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book name cannot be empty. Please enter a valid name.");
                    Console.ResetColor();
                }
            }
            // Author Name
            while (string.IsNullOrWhiteSpace(AuthorBook))
            {
                Console.WriteLine("Please enter the author name: ");
                AuthorBook = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(AuthorBook))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Author name cannot be empty. Please enter a valid name.");
                    Console.ResetColor();
                }
            }
            // Book Price
            Console.WriteLine("Please enter the book price (VND): ");
            while (true)
            {
                try
                {
                    double price = double.Parse(Console.ReadLine());  // chuyển đổi chuỗi thành số thực
                    if (price > 0)  // kiểm tra lớn hơn 0
                    {
                        PriceBook = price;
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
            Console.WriteLine($"Book with ID {BookID} added successfully!");
            Console.ResetColor();
            Console.WriteLine("---------------------------- ");
        }

        public void UpdateBook(List<Books> bookslist)
        {
            bool isValidID = false;
            int bookid = -1;
            Books bookToUpdate = null;
            string userInput;

            while (!isValidID)
            {
                Console.WriteLine("--- Update Book ---");
                Console.Write("Enter the ID of the book to update (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Update canceled.");
                    return;
                }
                try
                {
                    bookid = int.Parse(userInput);
                    if (bookid > 0)
                    {
                        for (int i = 0; i < bookslist.Count; i++)
                        {
                            if (bookslist[i].BookID == bookid)
                            {
                                bookToUpdate = bookslist[i];
                                isValidID = true;
                                break;
                            }
                        }
                        if (!isValidID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Book not found. Please try again or enter 'exit' to cancel.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Book ID.");
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

            Console.WriteLine("Enter the new book name (or leave blank to keep the existing name): ");
            string newBookName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newBookName))
            {
                bookToUpdate.NameBook = newBookName;
            }

            Console.WriteLine("Enter the new author name (or leave blank to keep the existing author name): ");
            string newAuthorName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthorName))
            {
                bookToUpdate.AuthorBook = newAuthorName;
            }

            Console.WriteLine("Enter the new price: ");
            while (true)
            {
                try
                {
                    double price = double.Parse(Console.ReadLine());
                    if (price > 0)
                    {
                        bookToUpdate.PriceBook = price;
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
            Console.WriteLine($"Book with ID {bookid} updated successfully!");
            Console.ResetColor();
            Console.WriteLine("---------------------------- ");
        }

        public void DeleteBook(List<Books> bookslist)
        {
            // Implement the delete book action here
            bool isValidID = false;
            int bookid = -1;
            Books bookToDelete = null;
            string userInput;

            while (!isValidID)
            {
                Console.WriteLine("--- Delete Book ---");
                Console.Write("Enter the ID of the book to delete (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Delete canceled.");
                    return;
                }
                try
                {
                    bookid = int.Parse(userInput);
                    if (bookid > 0)
                    {
                        for (int i = 0; i < bookslist.Count; i++)
                        {
                            if (bookslist[i].BookID == bookid)
                            {
                                bookToDelete = bookslist[i];
                                isValidID = true;
                                break;
                            }
                        }

                        if (!isValidID)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Book not found. Please try again.");
                            Console.ResetColor();
                        }
                        else
                        {
                            bookslist.Remove(bookToDelete); // Remove the book from the list
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Book with ID {bookid} deleted successfully!");
                            Console.ResetColor();
                            Console.WriteLine("---------------------------- ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number greater than 0 for the Book ID.");
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
            Console.WriteLine("---------------Books information---------------");
            if (bookslist.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available in the list.");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < bookslist.Count; i++)
                {
                    var book = bookslist[i];
                    Console.WriteLine($"BookID: {book.BookID}; BookName: {book.NameBook}; AuthorName: {book.AuthorBook}; Price ($): {book.PriceBook}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Displayed successfully!");
                    Console.ResetColor();
                    Console.WriteLine("---------------------------- ");
                }
            }
        }


        public void SearchBook(List<Books> bookslist)
        {
            bool continueSearching = true;

            while (continueSearching)
            {
                int bookid = -1;
                string userInput;

                Console.WriteLine("--- Search Book ---");
                Console.Write("Enter the ID of the book to search (Enter 'exit' to cancel): ");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Search canceled.");
                    return;
                }

                try
                {
                    bookid = int.Parse(userInput);

                    if (bookid <= 0)
                    {
                        throw new FormatException();
                    }

                    bool found = false;
                    foreach (var book in bookslist)
                    {
                        if (book.BookID == bookid)
                        {
                            Console.WriteLine($"BookID: {book.BookID}; BookName: {book.NameBook}; AuthorName: {book.AuthorBook}; Price ($): {book.PriceBook}");
                            found = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Book found successfully.");
                            Console.ResetColor();
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Book not found. Please try again.");
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
