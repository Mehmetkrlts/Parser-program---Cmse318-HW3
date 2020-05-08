using System;
using System.Collections.Generic;
using System.Text;

namespace Cmse318_HW3
{
    class File
    {
       public static void getfile() // get file name
        {
            Console.WriteLine("Enter a file name");
            Console.Write("File name = ");
           Global.name = Console.ReadLine();

            if (System.IO.File.Exists(@"D:\" + Global.name + ".txt")) // Check if file exist
            {
                return;

            }

            else
                Console.Clear();
            Console.WriteLine("Invalid input\n--------------------------------------");

            getfile();
                 
                
            
        }
    }
}
