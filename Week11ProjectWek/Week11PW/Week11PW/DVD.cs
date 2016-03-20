using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week11PW
{
    class DVD : Resource
    {
        static string filename = "DVDList.txt";

        public DVD(string[] splits)
        {
            Filename = filename;
            Title = splits[0];
            ISBN = splits[1];
            Length = uint.Parse(splits[2]);
            Status = splits[3];
        }

        public static void WriteDVDFile(DVD dvd1, DVD dvd2, DVD dvd3)
        {
            StreamWriter writer = new StreamWriter(filename);

            using (writer)
            {
                writer.WriteLine(dvd1.Title + "-" + dvd1.ISBN + "-" + dvd1.Length + "-" + dvd1.Status);
                writer.WriteLine(dvd2.Title + "-" + dvd2.ISBN + "-" + dvd2.Length + "-" + dvd2.Status);
                writer.WriteLine(dvd3.Title + "-" + dvd3.ISBN + "-" + dvd3.Length + "-" + dvd3.Status);
            }
        }

        public static string DVDCheckOutResource(DVD dvd1, DVD dvd2, DVD dvd3)
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", dvd1.Title, dvd1.Status);
            Console.WriteLine("{0} - Status: {1}", dvd2.Title, dvd2.Status);
            Console.WriteLine("{0} - Status: {1}", dvd3.Title, dvd3.Status);

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            if (input.Equals(dvd1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if(dvd1.Status == "Available")
                {
                    dvd1.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", dvd1.Title);
                    sb.Append(dvd1.Title + " (DVD)");
                    WriteDVDFile(dvd1, dvd2, dvd3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(dvd2.Title, StringComparison.CurrentCultureIgnoreCase) )
            {
                if(dvd2.Status == "Available")
                {
                    dvd2.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", dvd2.Title);
                    sb.Append(dvd2.Title + " (DVD)");
                    WriteDVDFile(dvd1, dvd2, dvd3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(dvd3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (dvd3.Status == "Available")
                {
                    dvd3.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", dvd3.Title);
                    sb.Append(dvd3.Title + " (DVD)");
                    WriteDVDFile(dvd1, dvd2, dvd3);
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

        public static void DVDCheckInResource(DVD dvd1, DVD dvd2, DVD dvd3)
        {
            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", dvd1.Title, dvd1.Status);
            Console.WriteLine("{0} - Status: {1}", dvd2.Title, dvd2.Status);
            Console.WriteLine("{0} - Status: {1}", dvd3.Title, dvd3.Status);

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (input.Equals(dvd1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (dvd1.Status == "Checked Out")
                {
                    dvd1.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", dvd1.Title);
                    WriteDVDFile(dvd1, dvd2, dvd3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(dvd2.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (dvd2.Status == "Checked Out")
                {
                    dvd2.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", dvd2.Title);
                    WriteDVDFile(dvd1, dvd2, dvd3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(dvd3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (dvd3.Status == "Checked Out")
                {
                    dvd3.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", dvd3.Title);
                    WriteDVDFile(dvd1, dvd2, dvd3);
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
