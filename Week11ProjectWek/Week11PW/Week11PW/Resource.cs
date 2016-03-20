using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Week11PW
{
    abstract class Resource
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public uint Length { get; set; }
        public string Status { get; set; }
        public static string Filename { get; set; }

        public static void CheckOutResource(List<Resource> resources)
        {
            //StringBuilder sb = new StringBuilder();

            Console.Clear();

            for (int i = 0; i < resources.Count; i++)
            {
                Console.WriteLine("{0} - Status: {1}", resources[i].Title, resources[i].Status);
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            for (int i = 0; i < resources.Count; i++)
            {
                int counter = 1;
                if (input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (resources[i].Status == "Available")
                    {
                        resources[i].Status = "Checked Out";
                        Console.WriteLine("{0} has been checked out.", resources[i].Title);
                        //sb.Append(resources[i].Title + " (DVD)");
                        //WriteDVDFile(dvd1, dvd2, dvd3);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That resource is not available.");
                    }
                }
                else
                {
                    counter++;
                    continue;
                }
            }   
        }

        public static void CheckInResource(List<Resource> resources)
        {
            Console.Clear();

            for (int i = 0; i < resources.Count; i++)
            {
                Console.WriteLine("{0} - Status: {1}", resources[i].Title, resources[i].Status);
            }

            Console.WriteLine("\n\nEnter the name of the resource you want to check out: ");
            string input = Console.ReadLine();

            for (int i = 0; i < resources.Count; i++)
            {
                int counter = 1;
                if (input.Equals(resources[i].Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (resources[i].Status == "Checked Out")
                    {
                        resources[i].Status = "Available";
                        Console.WriteLine("{0} has been checked out.", resources[i].Title);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That resource is not available.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    counter++;
                    continue;
                }
            }
        }

        public void EditResource (List<Resource> resources)
        {
            Console.WriteLine("Enter the name of the resource you want to edit: ");

        }

    }
}
