using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take2
{
    abstract class Resource
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public uint Length { get; set; }
        public string Status { get; set; }
        virtual public string LengthType { get; }
        virtual public string Filename { get; }

        public virtual void CheckOutResource(List<Resource> resources, Dictionary<string, List<string>> students) { }

        public virtual void CheckInResource(List<Resource> resources, Dictionary<string, List<string>> students) { }

        public static void WriteStudentFile (Dictionary<string, List<string>> students, string name)
        {
            string filename = name + ".txt";
            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine("Student: " + name);
                writer.WriteLine();
                writer.WriteLine("Checked Out Resources:");
                
                foreach (string word in students[name])
                {
                    writer.WriteLine(word);
                }
            }
        }

        public virtual void WriteIndividualResourceTypeFile(List<Resource> resources, IEnumerable<Resource> resourcestowrite)
        {
            StreamWriter writer = new StreamWriter(Filename);

            using (writer)
            {
                foreach (Resource resource in resourcestowrite)
                {
                    writer.WriteLine(resource.Title + "-" + resource.ISBN + "-" + resource.Length + "-" + resource.Status);
                }
            }
        }

        public void RewriteAllFiles (List<Resource> resources) //fix this too
        {
            var books = resources.Where(x => x.GetType().Name == "Book");
            var mags = resources.Where(x => x.GetType().Name == "Magazine");
            var dvds = resources.Where(x => x.GetType().Name == "DVD"); 

            StreamWriter writer1 = new StreamWriter("DVDList.txt");
            using (writer1)
            {
                foreach (DVD dvd in dvds)
                {
                    writer1.WriteLine(dvd.Title + "-" + dvd.ISBN + "-" + dvd.Length + "-" + dvd.Status);
                }
            }

            StreamWriter writer2 = new StreamWriter("BookList.txt");
            using (writer2)
            {
                foreach (Book book in books)
                {
                    writer2.WriteLine(book.Title + "-" + book.ISBN + "-" + book.Length + "-" + book.Status);
                }
            }
            StreamWriter writer3 = new StreamWriter("MagazineList.txt");
            using (writer3)
            {
                foreach (Magazine mag in mags)
                {
                    writer3.WriteLine(mag.Title + "-" + mag.ISBN + "-" + mag.Length + "-" + mag.Status);
                }
            }
        }


        public string GetNameValue(Dictionary<string, List<string>> students)
        {
            while (true)
            {
                Console.Clear();

                foreach (KeyValuePair<string, List<string>> pair in students)
                {
                    Console.WriteLine(pair.Key);
                }

                Console.WriteLine("Enter the name of the student to access their account: ");
                string name = Console.ReadLine();

                if (students.Keys.Contains(name))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("That student does not exist.");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public virtual void EditResource(List<Resource> resources, List<Resource> resourcetoedit)
        {
            foreach (Resource resource in resourcetoedit)
            {
                Console.WriteLine(resource.Title);
            }

            Console.WriteLine("\n\nEnter the resource you want to edit:");
            string input = Console.ReadLine();

            if (!resourcetoedit.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
            }
            else
            { 
                foreach (Resource resource in resourcetoedit)
                {
                    if (input.Equals(resource.Title, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Current Information: ");
                        Console.WriteLine("Title: {0}", resource.Title);
                        Console.WriteLine("ISBN: {0}", resource.ISBN);
                        Console.WriteLine("Length: {0} {1}", resource.Length, resource.LengthType);
                        Console.WriteLine("Status: {0}", resource.Status);

                        Console.WriteLine("\n\nEnter new information: ");
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();
                        resource.Title = title;

                        Console.WriteLine("ISBN: ");
                        string isbn = Console.ReadLine();
                        resource.ISBN = isbn;

                        Console.WriteLine("Length: ");
                        uint length = uint.Parse(Console.ReadLine());
                        resource.Length = length;

                        Console.Clear();
                        Console.WriteLine("Edited information: ");
                        Console.WriteLine("Title: {0}", resource.Title);
                        Console.WriteLine("ISBN: {0}", resource.ISBN);
                        Console.WriteLine("Length: {0} pages", resource.Length);
                        Console.WriteLine("Status: {0}", resource.Status);
                        RewriteAllFiles(resources);
                        Program.WriteAllResourcesFile(resources);
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }
    }
}

