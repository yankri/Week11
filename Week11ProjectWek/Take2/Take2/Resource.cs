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

        public virtual void WriteIndividualResourceTypeFile(List<Resource> resources){}

        public void RewriteAllFiles (List<Resource> resources)
        {
            StreamWriter writer1 = new StreamWriter("DVDList.txt");
            using (writer1)
            {
                for (int i = 0; i < 3; i++)
                {
                    writer1.WriteLine(resources[i].Title + "-" + resources[i].ISBN + "-" + resources[i].Length + "-" + resources[i].Status);
                }
            }
            StreamWriter writer2 = new StreamWriter("BookList.txt");
            using (writer2)
            {
                for (int i = 6; i < resources.Count; i++)
                {
                    writer2.WriteLine(resources[i].Title + "-" + resources[i].ISBN + "-" + resources[i].Length + "-" + resources[i].Status);
                }
            }
            StreamWriter writer3 = new StreamWriter("MagazineList.txt");
            using (writer3)
            {
                for (int i = 3; i < 6; i++)
                {
                    writer3.WriteLine(resources[i].Title + "-" + resources[i].ISBN + "-" + resources[i].Length + "-" + resources[i].Status);
                }
            }
        }

        public virtual void EditResource (List<Resource> resource){}
    }
}

