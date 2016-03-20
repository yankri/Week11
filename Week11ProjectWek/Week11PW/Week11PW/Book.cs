using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Week11PW
{
    class Book : Resource
    {
        static string filename = "BookList.txt";

        public Book(string[] splits)
        {
            Filename = filename;
            Title = splits[0];
            ISBN = splits[1];
            Length = uint.Parse(splits[2]);
            Status = splits[3];
        }

        public static void WriteBookFile(Book book1, Book book2, Book book3)
        {
            StreamWriter writer = new StreamWriter(filename);

            using (writer)
            {
                writer.WriteLine(book1.Title + "-" + book1.ISBN + "-" + book1.Length + "-" + book1.Status);
                writer.WriteLine(book2.Title + "-" + book2.ISBN + "-" + book2.Length + "-" + book2.Status);
                writer.WriteLine(book3.Title + "-" + book3.ISBN + "-" + book3.Length + "-" + book3.Status);
            }
        }

        public static string BookCheckOutResource(Book book1, Book book2, Book book3)
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", book1.Title, book1.Status);
            Console.WriteLine("{0} - Status: {1}", book2.Title, book2.Status);
            Console.WriteLine("{0} - Status: {1}", book3.Title, book3.Status);

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            if (input.Equals(book1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book1.Status == "Available")
                {
                    book1.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", book1.Title);
                    sb.Append(book1.Title + " (Book)");
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(book2.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book2.Status == "Available")
                {
                    book2.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", book2.Title);
                    sb.Append(book2.Title + " (Book)");
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(book3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book3.Status == "Available")
                {
                    book3.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", book3.Title);
                    sb.Append(book3.Title + " (Book)");
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else
            {
                Console.WriteLine("That resource does not exist.");
            }

            return sb.ToString();
        }

        public static void BookCheckInResource(Book book1, Book book2, Book book3)
        {
            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", book1.Title, book1.Status);
            Console.WriteLine("{0} - Status: {1}", book2.Title, book2.Status);
            Console.WriteLine("{0} - Status: {1}", book3.Title, book3.Status);

            Console.WriteLine("Enter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (input.Equals(book1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book1.Status == "Checked Out")
                {
                    book1.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", book1.Title);
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(book2.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book2.Status == "Checked Out")
                {
                    book2.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", book2.Title);
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(book3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (book3.Status == "Checked Out")
                {
                    book3.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", book3.Title);
                    WriteBookFile(book1, book2, book3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else
            {
                Console.WriteLine("That resource does not exist.");
            }
        }
    }
}
