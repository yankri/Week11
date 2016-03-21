using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Take2
{
    class Program
    {
        public static Dictionary<string, List<string>> InitializeStudentDictionary ()
        {  //reads all of the student files and adds their checkouts to a list in their respective dictionary. gets names for the values from the master student list
            List<string> students = new List<string>();

            StreamReader reader = new StreamReader("StudentList.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    students.Add(line);
                }
            }
            
            Dictionary<string, List<string>> studentCheckOuts = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < students.Count; i++)
            {
                string fileName = students[i] + ".txt";

                StreamReader reading = new StreamReader(fileName);
                bool checker = false;

                studentCheckOuts.Add(students[i], new List<string>());

                using (reading)
                {
                    while (!reading.EndOfStream)
                    {
                        string line = reading.ReadLine();

                        if (line == "Checked Out Resources:")
                        {
                            checker = true;
                            continue;
                        }

                        if (checker == true)
                        {
                            if (line != null)
                            {
                                studentCheckOuts[students[i]].Add(line);
                            }
                        }
                    }
                }
            }
            return studentCheckOuts;
        }
    
        public static List<Resource> Initialize()
        {
            List<Resource> resources = new List<Resource>()
            {
                new DVD(),
                new DVD(),
                new DVD(),
                new Magazine(),
                new Magazine(),
                new Magazine(),
                new Book(),
                new Book(),
                new Book()
            };

            List<string> readfromfile = new List<string>();

            StreamReader reader = new StreamReader("DVDList.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    readfromfile.Add(line);
                }
            }

            StreamReader reader1 = new StreamReader("MagazineList.txt");
            using (reader1)
            {
                while (!reader1.EndOfStream)
                {
                    string line = reader1.ReadLine();
                    readfromfile.Add(line);
                }
            }

            StreamReader reader2 = new StreamReader("BookList.txt");
            using (reader2)
            {
                while (!reader2.EndOfStream)
                {
                    string line = reader2.ReadLine();
                    readfromfile.Add(line);
                }
            }

            int counter = 0;
            for (int j = 0; j < readfromfile.Count; j++)
            {
                string[] splits = readfromfile[j].Split('-');

                resources[counter].Title = splits[0];
                resources[counter].ISBN = splits[1];
                resources[counter].Length = uint.Parse(splits[2]);
                resources[counter].Status = splits[3];
                counter++;
            }
            return resources;
        }

        public static void WriteAllResourcesFile(List<Resource> resources)
        {
            StreamWriter writer = new StreamWriter("ResourceList.txt");

            using (writer)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    writer.WriteLine(resources[i].Title + " (" + resources[i].GetType().Name + ")");
                }
            }

            StreamWriter writing = new StreamWriter("CheckedOutResources.txt");

            using (writing)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    if (resources[i].Status == "Checked Out")
                    {
                        writing.WriteLine(resources[i].Title);
                    }
                }
            }

            StreamWriter writering = new StreamWriter("AvailableResources.txt");

            using (writering)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    if (resources[i].Status == "Available")
                    {
                        writering.WriteLine(resources[i].Title);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentCheckOuts = InitializeStudentDictionary();
            List<Resource> resources = Initialize();
            WriteAllResourcesFile(resources);

            Menu menu = new Menu();
            menu.MainMenu(resources, studentCheckOuts);
       }
    }
}
