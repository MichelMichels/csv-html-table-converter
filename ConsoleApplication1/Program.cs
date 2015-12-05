using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicImplementation;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.parseEditionsFromList();
            logic.writeFile();
            Console.WriteLine("All done");
            Console.Read();
        }
    }
}
