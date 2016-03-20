using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Take2
{
    class Menu
    {
        public void PrintAllStudentNames()
        {
            Console.Clear();

            StreamReader reader = new StreamReader("StudentList.txt");

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }

        public void PrintAllResources()
        {
            Console.Clear();
            StreamReader reader = new StreamReader("ResourceList.txt");

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }

        public void PrintMenu() //prints the main menu
        {
            Console.Title = "Bootcamp Resources Checkout System";

            string[] mainMenu = { "1 - View All Resources", "2 - View Available Resources", "3 - Edit Resources", "4 - View Student Accounts", "5 - View All Students", "6 - Check In Resource", "7 - Check Out Resource", "8 - Exit\n" };
            Console.WriteLine("\nWelcome to Bootcamp Resources Checkout System!\n\n");
            Console.WriteLine("Enter a number to select a menu option: \n");

            foreach (string word in mainMenu)
            {
                Console.WriteLine(word);
            }
        }

        public List<string> ReadStudentFile() //reads students from file and adds them to a list
        {
            List<string> students = new List<string>();

            StreamReader reader = new StreamReader("StudentList.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                students.Add(line);

                while (line != null)
                {
                    line = reader.ReadLine();
                    students.Add(line);
                }
            }
            return students;
        }

        public void ViewStudentAccount(Dictionary<string, List<string>> students) //reads from a student's file and prints what they have checked out 
        {
            string name;
            Console.Clear();
            while (true)
            {
                foreach (KeyValuePair<string, List<string>> pair in students)
                {
                    Console.WriteLine(pair.Key);
                }

                Console.WriteLine("\nEnter a name to view the account:");
                name = Console.ReadLine();

                if (!students.Keys.Contains(name))
                {
                    Console.WriteLine("Error: That name does not exist.");
                    continue;
                }

                string fileName = name + ".txt";

                if (File.Exists(fileName))
                {
                    StreamReader reader = new StreamReader(fileName);
                    Console.Clear();
                    using (reader)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);

                        while (line != null)
                        {
                            line = reader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nERROR: That user does not have any books checked out.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public void Mario ()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(523, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(375);
            Console.Beep(392, 125);
            Thread.Sleep(375);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(375);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(1125);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(625);
        }
        public void ImperialMarch()
        {
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(698, 350);
            Console.Beep(523, 150);
            Console.Beep(415, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
        }
        public void ReadAvailableResourcesFile()
        {
            StreamReader reader = new StreamReader("AvailableResources.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    Console.WriteLine("All resources have been checked out.");
                    reader.Close();
                }
                else
                {
                    Console.WriteLine(line);
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            Console.ReadKey();
        }

        public void MainMenu(List<Resource> resources, Dictionary<string, List<string>> students)
        {
            bool close = false;
            DVD dvd = new DVD();
            Magazine mags = new Magazine();
            Book book = new Book();

            while (close == false)
            {
                Console.Clear();
                PrintMenu();

                int choice;
                string menuChoice = Console.ReadLine();
                Console.WriteLine();

                bool result = int.TryParse(menuChoice, out choice);

                switch (choice)
                {
                    case 1: //view all resources
                        PrintAllResources();
                        break;
                    case 2: //view available resources
                        ReadAvailableResourcesFile();
                        break;
                    case 3:
                        //edit resources
                        EditResourceMenu(resources, dvd, mags, book);
                        break;
                    case 4: //view student accounts
                        ViewStudentAccount(students);
                        break;
                    case 5: //view list of all students
                        PrintAllStudentNames();
                        break;
                    case 6:
                        //check in
                        CheckInMenu(resources, students, dvd, mags, book);
                        break;
                    case 7:
                        //check out
                        CheckOutMenu(resources, students, dvd, mags, book);
                        break;
                    case 8: //exit
                        ClosingImage();
                        ImperialMarch();
                        close = true;
                        break;
                    default:
                        continue;
                }
            }
        }
        public void EditResourceMenu (List<Resource> resources, DVD dvd, Magazine mags, Book book)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter a letter to select the type of resource you want to modify: ");
                Console.WriteLine("A - Book");
                Console.WriteLine("B - DVD");
                Console.WriteLine("C - Magazine");

                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        book.EditResource(resources);
                        break;
                    case "B":
                        dvd.EditResource(resources);
                        break;
                    case "C":
                        mags.EditResource(resources);
                        break;
                    default:
                        continue;
                }
                break;
            }
        }

        public void CheckInMenu(List<Resource> resources, Dictionary<string, List<string>> students, DVD dvd, Magazine mags, Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a letter to select the type of resource you want to check in: ");
                Console.WriteLine("A - Book");
                Console.WriteLine("B - DVD");
                Console.WriteLine("C - Magazine");

                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        book.CheckInResource(resources, students);
                        break;
                    case "B":
                        dvd.CheckInResource(resources, students);
                        break;
                    case "C":
                        mags.CheckInResource(resources, students);
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
        public void CheckOutMenu(List<Resource> resources, Dictionary<string, List<string>> students, DVD dvd, Magazine mags, Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a letter to select the type of resource you want to check out: ");
                Console.WriteLine("A - Book");
                Console.WriteLine("B - DVD");
                Console.WriteLine("C - Magazine");

                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        book.CheckOutResource(resources, students);
                        break;
                    case "B":
                        dvd.CheckOutResource(resources, students);
                        break;
                    case "C":
                        mags.CheckOutResource(resources, students);
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
        public void ClosingImage() //Prints a closing image on exit
        {
            Console.Clear();
            StreamReader reader = new StreamReader("ClosingImage.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("\nCome to the Dark Side. We have cookies. \n\n");
        }
    }
}
