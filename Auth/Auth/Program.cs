using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Auth.UserCheck(Environment.UserName, "Admin"));
            Console.WriteLine(Environment.UserName);
            Console.ReadLine();
        }
    }
}
