using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LibraryCardCatalog_Jin
{
    class CardCatalog
    {
        private string _filename;

        private List<Book> books=new List<Book>();

        public CardCatalog(string filename)
        {
            _filename = filename;
        }

        public void ListBook()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + _filename;

            XmlSerializer reader = new XmlSerializer(typeof(List<Book>));
            //call list without initiate xml file first, program will crash

            StreamReader file = new StreamReader(@path);

            List<Book> booklist = (List<Book>)reader.Deserialize(file);
            books = booklist;

            file.Close();

            foreach(Book bl in books)
            {
                Console.WriteLine("Title: {0} || Author: {1}",bl.Title,bl.Author);
            }
        }

        public void AddBook()
        {
          
            Console.WriteLine("Please enter book Title");
            string title = Console.ReadLine();

            Console.WriteLine("Please enter book Author");
            string author = Console.ReadLine();

            Book book = new Book();
            book.Title = title;
            book.Author = author;

            books.Add(book);
        }

        public void Save()
        {
            var writer = new XmlSerializer(typeof(List<Book>));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + _filename;
            
            System.IO.FileStream file = System.IO.File.Create(path);
            

            writer.Serialize(file, books);
            file.Close();
        }

    }
}