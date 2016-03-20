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

        public string Filename { get; set; }

        public Magazine()
        {
            Filename = filename;
        }

        public override void CheckInResource(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            string namevalue;
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
                    namevalue = name;
                    break;
                }
                else
                {
                    Console.WriteLine("That student does not exist.");
                    Console.ReadKey();
                    continue;
                }
            }

            if (students[namevalue].Count == 0)
            {
                Console.WriteLine("That student doesn't have anything checked in.");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            for (int i = 3; i < 6; i++)
            {
                Console.WriteLine("{0} - Status: {1}", resources[i].Title, resources[i].Status);
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            for (int i = 3; i < 6; i++)
            {
                if (input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (resources[i].Status == "Checked Out")
                    {
                        resources[i].Status = "Available";
                        Console.WriteLine("{0} has been checked in.", resources[i].Title);
                        Console.ReadKey();
                        students[namevalue].Remove(resources[i].Title);
                        WriteIndividualResourceTypeFile(resources);
                        WriteStudentFile(students, namevalue);
                        Program.WriteAllResourcesFile(resources);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That resource is not available.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (i == 5 && !input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("That resource does not exist.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        public override void WriteIndividualResourceTypeFile(List<Resource> resources)
        {
            StreamWriter writer = new StreamWriter(Filename);

            using (writer)
            {
                for (int i = 3; i < 6; i++)
                {
                    writer.WriteLine(resources[i].Title + "-" + resources[i].ISBN + "-" + resources[i].Length + "-" + resources[i].Status);
                }
            }
        }

        public override void CheckOutResource(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            string namevalue;
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
                    namevalue = name;
                    break;
                }
                else
                {
                    Console.WriteLine("That student does not exist.");
                    Console.ReadKey();
                    continue;
                }
            }

            Console.Clear();

            for (int i = 3; i < 6; i++)
            {
                Console.WriteLine("{0} - Status: {1}", resources[i].Title, resources[i].Status);
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            for (int i = 3; i < 6; i++)
            {
                if (input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (resources[i].Status == "Available")
                    {
                        resources[i].Status = "Checked Out";
                        Console.WriteLine("{0} has been checked out.", resources[i].Title);
                        students[namevalue].Add(resources[i].Title);
                        WriteIndividualResourceTypeFile(resources);
                        WriteStudentFile(students, namevalue);
                        Program.WriteAllResourcesFile(resources);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That resource is not available.");
                    }
                }
                else if (i == 5 && !input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("That resource does not exist.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        public override void EditResource(List<Resource> resource)
        {
            Console.Clear();
            for (int i = 3; i < 6; i++)
            {
                Console.WriteLine(resource[i].Title);
            }

            Console.WriteLine("\n\nEnter the resource you want to edit:");
            string input = Console.ReadLine();

            for (int i = 3; i < 6; i++)
            {
                if (input.Equals(resource[i].Title, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("Current Information: ");
                    Console.WriteLine("Title: {0}", resource[i].Title);
                    Console.WriteLine("ISBN: {0}", resource[i].ISBN);
                    Console.WriteLine("Length: {0} pages", resource[i].Length);
                    Console.WriteLine("Status: {0}", resource[i].Status);

                    Console.WriteLine("\n\nEnter new information: ");
                    Console.WriteLine("Title: ");
                    string title = Console.ReadLine();
                    resource[i].Title = title;

                    Console.WriteLine("ISBN: ");
                    string isbn = Console.ReadLine();
                    resource[i].ISBN = isbn;

                    Console.WriteLine("Length: ");
                    uint length = uint.Parse(Console.ReadLine());
                    resource[i].Length = length;

                    Console.Clear();
                    Console.WriteLine("Edited information: ");
                    Console.WriteLine("Title: {0}", resource[i].Title);
                    Console.WriteLine("ISBN: {0}", resource[i].ISBN);
                    Console.WriteLine("Length: {0} pages", resource[i].Length);
                    Console.WriteLine("Status: {0}", resource[i].Status);
                    RewriteAllFiles(resource);
                    Program.WriteAllResourcesFile(resource);
                    Console.ReadKey();
                    return;
                }
                else if (i == 5 && !input.Equals(resource[i].Title, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("That resource does not exist.");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
    