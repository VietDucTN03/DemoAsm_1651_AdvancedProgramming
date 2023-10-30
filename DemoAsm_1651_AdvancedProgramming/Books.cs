using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SecondChange_1651
{
    public class Books : Products
    {
        private int bookid;
        private string namebook;
        private string authorbook;
        private double pricebook;

        public int BookID
        {
            get { return bookid; }
            set { bookid = value; }
        }

        public string NameBook
        {
            get { return namebook; }
            set { namebook = value; }
        }

        public string AuthorBook
        {
            get { return authorbook; }
            set { authorbook = value; }
        }

        public double PriceBook
        {
            get { return pricebook; }
            set { pricebook = value; }
        }

        public Books(int bookID, string nameBook, string authorBook, double priceBook)
        {
            BookID = bookID;
            NameBook = nameBook;
            AuthorBook = authorBook;
            PriceBook = priceBook;
        }

        public Books() { }

        public override void ShowInformation()
        {
            Console.WriteLine($"Book ID: {BookID}, Name: {NameBook}, Author: {AuthorBook}, Price: {PriceBook}");
        }
    }
}
