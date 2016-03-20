using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Week11PW
{
    class Magazine : Resource
    {
        static string filename = "MagazineList.txt";

        public Magazine(string[] splits)
        {
            Filename = filename;
            Title = splits[0];
            ISBN = splits[1];
            Length = uint.Parse(splits[2]);
            Status = splits[3];
        }

        public static void WriteMagFile(Magazine mags1, Magazine mags2, Magazine mags3)
        {
            StreamWriter writer = new StreamWriter(filename);

            using (writer)
            {
                writer.WriteLine(mags1.Title + "-" + mags1.ISBN + "-" + mags1.Length + "-" + mags1.Status);
                writer.WriteLine(mags2.Title + "-" + mags2.ISBN + "-" + mags2.Length + "-" + mags2.Status);
                writer.WriteLine(mags3.Title + "-" + mags3.ISBN + "-" + mags3.Length + "-" + mags3.Status);
            }
        }

        public static string MagCheckOutResource(Magazine mags1, Magazine mags2, Magazine mags3)
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", mags1.Title, mags1.Status);
            Console.WriteLine("{0} - Status: {1}", mags2.Title, mags2.Status);
            Console.WriteLine("{0} - Status: {1}", mags3.Title, mags3.Status);

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            if (input.Equals(mags1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags1.Status == "Available")
                {
                    mags1.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", mags1.Title);
                    sb.Append(mags1.Title + " (Magazine)");
                    WriteMagFile(mags1, mags2, mags3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(mags2.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags2.Status == "Available")
                {
                    mags2.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", mags2.Title);
                    sb.Append(mags2.Title + " (Magazine)");
                    WriteMagFile(mags1, mags2, mags3);
                }
                else
                {
                    Console.WriteLine("That resource is not available.");
                }
            }
            else if (input.Equals(mags3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags3.Status == "Available")
                {
                    mags3.Status = "Checked Out";
                    Console.WriteLine("{0} has been checked out.", mags3.Title);
                    sb.Append(mags3.Title + " (Magazine)");
                    WriteMagFile(mags1, mags2, mags3);
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

        public static void MagCheckInResource(Magazine mags1, Magazine mags2, Magazine mags3)
        {
            Console.Clear();
            Console.WriteLine("{0} - Status: {1}", mags1.Title, mags1.Status);
            Console.WriteLine("{0} - Status: {1}", mags2.Title, mags2.Status);
            Console.WriteLine("{0} - Status: {1}", mags3.Title, mags3.Status);

            Console.WriteLine("\n\nEnter the name of the resource you want to check in: ");
            string input = Console.ReadLine();

            if (input.Equals(mags1.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags1.Status == "Checked Out")
                {
                    mags1.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", mags1.Title);
                    WriteMagFile(mags1, mags2, mags3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(mags2.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags2.Status == "Checked Out")
                {
                    mags2.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", mags2.Title);
                    WriteMagFile(mags1, mags2, mags3);
                }
                else
                {
                    Console.WriteLine("That resource is not checked out.");
                }
            }
            else if (input.Equals(mags3.Title, StringComparison.CurrentCultureIgnoreCase))
            {
                if (mags3.Status == "Checked Out")
                {
                    mags3.Status = "Available";
                    Console.WriteLine("{0} has been checked in.", mags3.Title);
                    WriteMagFile(mags1, mags2, mags3);
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
