using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Take2
{
    class Magazine : Resource
    {
        string filename = "MagazineList.txt";

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

            var magazines = resources.Where(x => x.GetType().Name == "Magazines");

            foreach (Magazine mags in magazines)
            {
                Console.WriteLine("{0} - Status: {1}", mags.Title, mags.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} pages", mags.ISBN, mags.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (!magazines.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var magazinetocheckout = resources.Where(x => x.Status == "Checked Out" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));
            var magtoCO = magazinetocheckout.First();

            if (magazinetocheckout.Count() > 0 && students[namevalue].Contains(magtoCO.Title.ToString(), StringComparer.InvariantCultureIgnoreCase))
            {
                magtoCO.Status = "Available";
                Console.WriteLine("{0} has been checked in.", magtoCO.Title);
                students[namevalue].Remove(magtoCO.Title);
                WriteIndividualResourceTypeFile(resources, magazines);
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

            var magazines = resources.Where(x => x.GetType().Name == "Magazine");
            foreach (Magazine mags in magazines)
            {
                Console.WriteLine("{0} - Status: {1}", mags.Title, mags.Status);
                Console.WriteLine("\tISBN: {0}\n\tLength: {1} pages", mags.ISBN, mags.Length);
                Console.WriteLine();
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            if (!magazines.Select(x => x.Title).ToArray().Contains(input, StringComparer.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("That resource does not exist.");
                Console.ReadKey();
                return;
            }

            var magazinetocheckout = resources.Where(x => x.Status == "Available" && x.Title.Equals(input, StringComparison.InvariantCultureIgnoreCase));

            if (magazinetocheckout.Count() > 0)
            {
                var mag2CO = magazinetocheckout.First();
                mag2CO.Status = "Checked Out";
                Console.WriteLine("{0} has been checked out.", mag2CO.Title);
                students[namevalue].Add(mag2CO.Title);
                WriteIndividualResourceTypeFile(resources, magazines);
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

        public void MagEditResource(List<Resource> resource)
        {
            Console.Clear();

            var mags = resource.Where(x => x.GetType().Name == "Magazine").ToList();

            EditResource(resource, mags);
        }
    }
}

    