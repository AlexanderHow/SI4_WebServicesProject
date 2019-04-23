using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientWCF.ServiceConnected;

namespace ClientWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient client = new MathsOperationsClient(); /* classe d’accès au service */
            Console.WriteLine(client.Add(100, 101));
            Console.WriteLine(client.Multiply(100, 101));
            Console.ReadLine();
        }
    }
}
