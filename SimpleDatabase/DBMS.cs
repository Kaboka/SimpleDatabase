using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleDatabase
{
    public class DBMS
    {
        private Dictionary<int, string> indices = new Dictionary<int, string>();

        public DBMS()
        {
            StartUp();
        }

        public string ReadData(int key) 
        {
            string dataLocation;
            indices.TryGetValue(key, out dataLocation);
            char[] myData = "Index dosent exsist".ToCharArray();
            if (dataLocation != null)
            {
                string[] data = dataLocation.Split(';');
                int offset = int.Parse(data[0]);
                int length = int.Parse(data[1]) - offset;
                myData = new char[offset + length];

                using (StreamReader sr = new StreamReader("Database.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        sr.ReadBlock(myData, offset, length);
                        /*   string line = sr.ReadLine(); //Brug readblock istedet
                           myData = line.Substring(offset, length);*/
                    }
                }
            }
            return new string(myData).Replace(" ", String.Empty);
        }

        public void WriteData(int key, string value)
        {
            long startIndex = 0;
            if (File.Exists("Database.txt"))
            {
                startIndex = new FileInfo("Database.txt").Length;
            }
            int endIndex = (int)startIndex + value.Length;
            indices.Add(key, startIndex + ";" + endIndex);
            File.AppendAllText("Database.txt",value);
        }
        
        public void CloseDonw()
        {
            using (StreamWriter file = new StreamWriter("Indices.txt"))
                foreach(var entry in indices)
                {
                    file.WriteLine("{0},{1}", entry.Key, entry.Value);
                }
        }

        private void StartUp()
        {
            if (File.Exists("Indices.txt"))
            {
                string[] tempindices = File.ReadAllLines("Indices.txt");
                foreach (string entry in tempindices)
                {
                    string[] values = entry.Split(',');
                    indices.Add(int.Parse(values[0]), values[1]);
                }
            }

        }
    }
}
