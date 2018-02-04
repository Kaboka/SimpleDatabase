using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DBMS dbms = new DBMS();
            Console.WriteLine("Welcome to Simple DB");
            bool running = true;
            while (running)
            {
                string[] data = Console.ReadLine().Split(' ');
                string dbCommand = data[0];
                string value = "";
                int key = 0;
                if (dbCommand.Equals("db_write") || dbCommand.Equals("db_read"))
                {
                   bool passed = int.TryParse(data[1], out key);
                    if (passed == false)
                        dbCommand = "error";
                }
                if (dbCommand.Equals("db_write"))
                    try
                    {
                        value = data[2];
                    }catch(IndexOutOfRangeException ex)
                    {
                        dbCommand = "error";
                    }
                switch (dbCommand)
                {
                    case "db_write": dbms.WriteData(key, value);
                        break;
                    case "db_read": Console.WriteLine(dbms.ReadData(key));
                        break;
                    case "exit": running = false;
                        break;
                    default: Console.WriteLine("This is not a supported command");
                        break;
                }
                dbms.CloseDonw();
            }
        }
    }
}
