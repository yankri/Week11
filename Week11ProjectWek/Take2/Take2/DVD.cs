using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Take2
{
    class DVD : Resource
    {
        string filename = "DVDList.txt";

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
                return "minutes";
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

            var dvds = resources.Where(x => x.GetType().Name == "DVD");

            foreach (DVD deevdee in dvds)
            {
                Console.WriteLine("{0} - Status: {1}", deevdee.Title, deevdee.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} minutes", deevdee.ISBN, deevdee.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (!dvds.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var dvdtoCheckout = resources.Where(x => x.Status == "Checked Out" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));
            var dvd2 = dvdtoCheckout.First();

            if (dvdtoCheckout.Count() > 0 && students[namevalue].Contains(dvd2.Title.ToString(), StringComparer.InvariantCultureIgnoreCase))
            {
                dvd2.Status = "Available";
                Console.WriteLine("{0} has been checked in.", dvd2.Title);
                students[namevalue].Remove(dvd2.Title);
                WriteIndividualResourceTypeFile(resources, dvds);
                WriteStudentFile(students, namevalue);
                Program.WriteAllResourcesFile(resources);
                Console.ReadKey();
                return;
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
            base.WriteIndividualResourceTypeFile(resources, resourcestowrite);
        }

        public override void CheckOutResource(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            string namevalue = GetNameValue(students);

            Console.Clear();

            var deevdee = resources.Where(x => x.GetType().Name == "DVD");

            foreach (DVD dvd in deevdee)
            {
                Console.WriteLine("{0} - Status: {1}", dvd.Title, dvd.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} minutes", dvd.ISBN, dvd.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();
            
            if (!deevdee.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var dvdtoCheckout = resources.Where(x => x.Status == "Available" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));

            if (dvdtoCheckout.Count() > 0)
            {
                var dvd1 = dvdtoCheckout.First();
                dvd1.Status = "Checked Out";
                Console.WriteLine("{0} has been checked out.", dvd1.Title);
                students[namevalue].Add(dvd1.Title);
                WriteIndividualResourceTypeFile(resources, deevdee);
                WriteStudentFile(students, namevalue);
                Program.WriteAllResourcesFile(resources);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("That resource is not available.");
                Console.ReadKey();
                return;
            }
        }

        public void DVDEditResource(List<Resource> resource)
        {
            Console.Clear();

            var dvds = resource.Where(x => x.GetType().Name == "DVD").ToList();

            EditResource(resource, dvds);
        }
    }
}
