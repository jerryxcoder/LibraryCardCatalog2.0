using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace LibraryCardCatalog_Jin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter file name");
            string fname = Console.ReadLine();
            CardCatalog clog = new CardCatalog(fname);


            start:
            Console.WriteLine("Please Choose what you want to do");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Save and Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    clog.ListBook();
                    goto start;
                case 2:
                    clog.AddBook();
                    goto start;
                case 3:
                    clog.Save();
                    break;
            }
        }
    }

}
