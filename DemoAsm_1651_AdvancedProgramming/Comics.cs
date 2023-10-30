using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SecondChange_1651
{
    public class Comics : Products
    {
        private int comicid;
        private string namecomic;
        private string authorcomic;
        private double pricecomic;

        public int ComicID
        {
            get { return comicid; }
            set { comicid = value; }
        }

        public string NameComic
        {
            get { return namecomic; }
            set { namecomic = value; }
        }

        public string AuthorComic
        {
            get { return authorcomic; }
            set { authorcomic = value; }
        }

        public double PriceComic
        {
            get { return pricecomic; }
            set { pricecomic = value; }
        }

        public Comics(int comicID, string nameComic, string authorComic, double priceComic)
        {
            ComicID = comicID;
            NameComic = nameComic;
            AuthorComic = authorComic;
            PriceComic = priceComic;
        }

        public Comics() { }

        public override void ShowInformation()
        {
            Console.WriteLine($"Comic ID: {ComicID}, Name: {NameComic}, Author: {AuthorComic}, Price: {PriceComic}");
        }
    }
}
