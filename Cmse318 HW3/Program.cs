using System;

using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Cmse318_HW3
{
    class Program
    {
        static void Main(string[] args)
        {
          File.getfile();
          Global.text = System.IO.File.ReadAllText(@"D:\" + Global.name + ".txt"); // Read the file and saves as string
          Global.text =  Global.text.Replace(Environment.NewLine, ""); // Remove newlines
          Global.text = Global.text.Replace(" ", ""); // Remove Spaces


          Arithmetic.G();  // Start Parser function

        }
    }
}
