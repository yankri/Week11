using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take2
{
    class Book : Resource
    {
        string filename = "BookList.txt";

        public override string Filename
        {
            get
            {
                return filename;
            }
        }
        public override string LengthType
        {
            get
            {
                return "pages";
            }
        }

        public override void CheckInResource(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            string namevalue = GetNameValue(students);

            if (students[namevalue].Count == 0)
            {
                Console.WriteLine("That student doesn't have anything checked out.");
                Console.ReadKey();
                return;
            }
            Console.Clear();

            var books = resources.Where(x => x.GetType().Name == "Book");

            foreach (Book book in books)
            {
                Console.WriteLine("{0} - Status: {1}", book.Title, book.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} pages", book.ISBN, book.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (!books.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var booktoCheckout = resources.Where(x => x.Status == "Checked Out" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));

            var book2CO = booktoCheckout.First();
            
            if (booktoCheckout.Count() > 0 && students[namevalue].Contains(book2CO.Title.ToString(), StringComparer.InvariantCultureIgnoreCase))
            {
                book2CO.Status = "Available";
                Console.WriteLine("{0} has been checked in.", book2CO.Title);
                students[namevalue].Remove(book2CO.Title);
                WriteIndividualResourceTypeFile(resources, books);
                WriteStudentFile(students, namevalue);
                Program.WriteAllResourcesFile(resources);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That resource is not checked out.");
                Console.ReadKey();
                return;
            }
        }

        public override void WriteIndividualResourceTypeFile(List<Resource> resources, IEnumerable<Resource> resourcestowrite)
        {
            resourcestowrite = resources.Where(x => x.GetType().Name == "Book").ToList();

            base.WriteIndividualResourceTypeFile(resources, resourcestowrite);
        }

        public void BookEditResource(List<Resource> resource)
        {
            Console.Clear();

            var books = resource.Where(x => x.GetType().Name == "Book").ToList();

            EditResource(resource, books);
        }

        public override void CheckOutResource(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            string namevalue = GetNameValue(students);

            Console.Clear();

            var books = resources.Where(x => x.GetType().Name == "Book");

            foreach (Book book in books)
            {
                Console.WriteLine("{0} - Status: {1}", book.Title, book.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} pages", book.ISBN, book.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            if (!books.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var booktoCheckout = resources.Where(x => x.Status == "Available" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));

            if (booktoCheckout.Count() > 0)
            {
                var book2CO = booktoCheckout.First();
                book2CO.Status = "Checked Out";
                Console.WriteLine("{0} has been checked out.", book2CO.Title);
                students[namevalue].Add(book2CO.Title);
                WriteIndividualResourceTypeFile(resources, books);
                WriteStudentFile(students, namevalue);
                Program.WriteAllResourcesFile(resources);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That resource is not available.");
                Console.ReadKey();
                return;
            }
        }
    }
}
