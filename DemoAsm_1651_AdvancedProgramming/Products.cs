using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SecondChange_1651
{
    public abstract class Products : Information
    {
        private int id;
        private string name;
        private string author;
        private double price;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual void ShowInformation()
        {
            Console.WriteLine($"Product ID: {ID}, Name: {Name}, Author: {Author}, Price: {Price}");
        }
    }
}
