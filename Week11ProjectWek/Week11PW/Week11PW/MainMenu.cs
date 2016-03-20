using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Week11PW
{
    class MainMenu
    {
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

        public void ViewStudentAccount(List<string> students) //reads from a student's file and prints what they have checked out 
        {
            string name;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nEnter a name to view the account:");
                name = Console.ReadLine();

                string checkName = name.ToLower();
                if (!students.Contains(checkName, StringComparer.CurrentCultureIgnoreCase))
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

        public void WriteAllResourcesFile(DVD one, DVD two, DVD three, Magazine mag1, Magazine mag2, Magazine mag3, Book b1, Book b2, Book b3)
        {
            StreamWriter writer = new StreamWriter("ResourceList.txt");

            using (writer)
            {
                writer.WriteLine(one.Title + (" (DVD)"));
                writer.WriteLine(two.Title + (" (DVD)"));
                writer.WriteLine(three.Title + (" (DVD)"));
                writer.WriteLine(mag1.Title + (" (Magazine)"));
                writer.WriteLine(mag2.Title + (" (Magazine)"));
                writer.WriteLine(mag3.Title + (" (Magazine)"));
                writer.WriteLine(b1.Title + (" (Book)"));
                writer.WriteLine(b2.Title + (" (Book)"));
                writer.WriteLine(b3.Title + (" (Book)"));
            }

            StreamWriter writing = new StreamWriter("CheckedOutResources.txt");

            using (writing)
            {
                if (one.Status == "Checked Out")
                {
                    writing.WriteLine(one.Title);
                }
                if (two.Status == "Checked Out")
                {
                    writing.WriteLine(two.Title);
                }
                if (three.Status == "Checked Out")
                {
                    writing.WriteLine(three.Title);
                }
                if (mag1.Status == "Checked Out")
                {
                    writing.WriteLine(mag1.Title);
                }
                if (mag2.Status == "Checked Out")
                {
                    writing.WriteLine(mag2.Title);
                }
                if (mag3.Status == "Checked Out")
                {
                    writing.WriteLine(mag3.Title);
                }
                if (b1.Status == "Checked Out")
                {
                    writing.WriteLine(b1.Title);
                }
                if (b2.Status == "Checked Out")
                {
                    writing.WriteLine(b2.Title);
                }
                if (b3.Status == "Checked Out")
                {
                    writing.WriteLine(b3.Title);
                }
            }

            StreamWriter writering = new StreamWriter("AvailableResources.txt");

            using (writering)
            {
                if (one.Status == "Available")
                {
                    writering.WriteLine(one.Title);
                }
                if (two.Status == "Available")
                {
                    writering.WriteLine(two.Title);
                }
                if (three.Status == "Available")
                {
                    writering.WriteLine(three.Title);
                }
                if (mag1.Status == "Available")
                {
                    writering.WriteLine(mag1.Title);
                }
                if (mag2.Status == "Available")
                {
                    writering.WriteLine(mag2.Title);
                }
                if (mag3.Status == "Available")
                {
                    writering.WriteLine(mag3.Title);
                }
                if (b1.Status == "Available")
                {
                    writering.WriteLine(b1.Title);
                }
                if (b2.Status == "Available")
                {
                    writering.WriteLine(b2.Title);
                }
                if (b3.Status == "Available")
                {
                    writering.WriteLine(b3.Title);
                }
            }
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

        public List<string> ReadFromFile(string filename)
        {
            List<string> resources = new List<string>();

            StreamReader reader = new StreamReader(filename);

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    resources.Add(line);
                }
            }

            return resources;
        }

        public void PrintStudentFile (string name)
        {
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
                }
        }

        public void ReadAvailableResourcesFile ()
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

        public void Menu() //initializes all the classes and handles menu option input
        {
            bool close = false;
            List<string> students = ReadStudentFile();

            List<string> dvds = ReadFromFile("DVDList.txt");
            string[] splits = dvds[0].Split('-');
            DVD dvd1 = new DVD(splits);
            string[] splits2 = dvds[1].Split('-');
            DVD dvd2 = new DVD(splits2);
            string[] splits3 = dvds[2].Split('-');
            DVD dvd3 = new DVD(splits3);

            List<string> mags = ReadFromFile("MagazineList.txt");
            string[] msplits = mags[0].Split('-');
            Magazine mags1 = new Magazine(msplits);
            string[] msplits2 = mags[1].Split('-');
            Magazine mags2 = new Magazine(msplits2);
            string[] msplits3 = mags[2].Split('-');
            Magazine mags3 = new Magazine(msplits3);

            List<string> books = ReadFromFile("BookList.txt");
            string[] bsplits = books[0].Split('-');
            Book book1 = new Book(bsplits);
            string[] bsplits2 = books[1].Split('-');
            Book book2 = new Book(bsplits2);
            string[] bsplits3 = books[2].Split('-');
            Book book3 = new Book(bsplits3);

            WriteAllResourcesFile(dvd1, dvd2, dvd3, mags1, mags2, mags3, book1, book2, book3);

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
                    case 1:
                        PrintAllResources();
                        break;
                    case 2:
                        //view available resources
                        ReadAvailableResourcesFile();
                        break;
                    case 3:
                        //edit resources
                        break;
                    case 4:
                        ViewStudentAccount(students);
                        break;
                    case 5:
                        PrintAllStudentNames();
                        break;
                    case 6:
                        CheckInMenu(students, dvd1, dvd2, dvd3, book1, book2, book3, mags1, mags2, mags3); //add student accounts, list of resources
                        break;
                    case 7:
                        CheckOutMenu(students, dvd1, dvd2, dvd3, book1, book2, book3, mags1, mags2, mags3);
                        break;
                    case 8:
                        ClosingImage();
                        close = true;
                        break;
                    default:
                        continue;
                }
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

            Console.WriteLine("\nSuch quitting. Very check out. Wow.\n\n");
        }
        
        public string StudentAccountsListForCheckOutsandIns (List<string> students)
        {
            while (true)
            {
                Console.Clear();
                foreach (string kid in students)
                {
                    Console.WriteLine(kid);
                }

                Console.WriteLine("Choose a student to access their account: ");
                string input = Console.ReadLine();

                if (students.Contains(input, StringComparer.InvariantCultureIgnoreCase))
                {
                    input = input + ".txt";
                    return input;
                }
                else
                {
                    Console.WriteLine("That student does not exist.");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public void CheckOutMenu(List<string> students, DVD dvd1, DVD dvd2, DVD dvd3, Book book1, Book book2, Book book3, Magazine mags1, Magazine mags2, Magazine mags3)
        {
            while (true)
            {
                string filename = StudentAccountsListForCheckOutsandIns(students);

                PrintStudentFile(filename);

                Console.WriteLine("Enter a letter to select the type of resource you want to check out: ");
                Console.WriteLine("A - Book");
                Console.WriteLine("B - DVD");
                Console.WriteLine("C - Magazine");

                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        string bookfilecontent = Book.BookCheckOutResource(book1, book2, book3);
                        WriteStudentFile(filename, bookfilecontent);
                        break;
                    case "B":
                        string DVDfilecontent = DVD.DVDCheckOutResource(dvd1, dvd2, dvd3);
                        WriteStudentFile(filename, DVDfilecontent);
                        break;
                    case "C":
                        string magfilecontent = Magazine.MagCheckOutResource(mags1, mags2, mags3);
                        WriteStudentFile(filename, magfilecontent);
                        break;
                    default:
                        continue;
                }
                break;
            }
        }

        public string MakeStudentFileContent(string studentName) //creates the header for the student's check out file
        {
            StringBuilder header = new StringBuilder();
            header.Append("Student: " + studentName);
            header.AppendLine();

            return header.ToString();
        }

        public void WriteStudentFile (string filename, string filecontent)
        {
            StreamWriter writer = new StreamWriter(filename);

            using (writer)
            {
                writer.WriteLine(filecontent);
            }
        }
        public void CheckInMenu(List<string> students, DVD dvd1, DVD dvd2, DVD dvd3, Book book1, Book book2, Book book3, Magazine mags1, Magazine mags2, Magazine mags3)
        {
            while (true)
            {
                string filename = StudentAccountsListForCheckOutsandIns(students);
                
                PrintStudentFile(filename);

                Console.WriteLine("Enter a letter to select the type of resource you want to check in: ");
                Console.WriteLine("A - Book");
                Console.WriteLine("B - DVD");
                Console.WriteLine("C - Magazine");

                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        Book.BookCheckInResource(book1, book2, book3);
                        break;
                    case "B":
                        DVD.DVDCheckInResource(dvd1, dvd2, dvd3);
                        break;
                    case "C":
                        Magazine.MagCheckInResource(mags1, mags2, mags3);
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
