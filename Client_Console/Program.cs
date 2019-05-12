using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Console.VelibSOAP;

namespace Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IntermediaryServiceClient serviceClient = new IntermediaryServiceClient();

            Console.WriteLine("Bienvenue sur la version console de Velib WS");

            Console.WriteLine("---Commandes disponibles---");
            Console.WriteLine("villes --- liste des villes disponibles");
            Console.WriteLine("stations --- liste de toutes les stations");
            Console.WriteLine("stations <ville> --- liste des stations d'une ville");
            Console.WriteLine("velibS <station> --- nombre de velibs sur une station");
            Console.WriteLine("velibC <ville> --- nombre de velibs sur une ville");
            Console.WriteLine("position <station> --- position d'une station");
            Console.WriteLine("positions <ville> --- position des stations d'une ville");
            Console.WriteLine("quitter --- quitter l'application");

            string input = "";

            while (true)
            {
                Console.Write(">");

                input = Console.ReadLine();
                string[] argsT = input.Split(' ');
                if (argsT.Length < 1)
                {
                    continue;
                }

                if (argsT[0] == "quit")
                {
                    break;
                }
                else if (argsT[0] == "stations")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        string station = serviceClient.GetStationsCity(argsT[1]);
                        Console.WriteLine(station);
                    }
                    else
                    {
                        string station = serviceClient.GetStations();
                        Console.WriteLine(station);
                    }
                }
                else if (argsT[0] == "velibS")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        //string dispo = serviceClient.GetNbBikes(argsT[1]);
                        //Console.WriteLine(dispo);
                    }
                }
                else if (argsT[0] == "velibC")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        string dispo = serviceClient.GetNbBikesCity(argsT[1]);
                        Console.WriteLine(dispo);
                    }
                }
                else if (argsT[0] == "position")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        //string position = serviceClient.GetPosition(argsT[1]);
                        //Console.WriteLine(position);
                    }
                }
                else if (argsT[0] == "velibC")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        string positions = serviceClient.GetPositions(argsT[1]);
                        Console.WriteLine(positions);
                    }
                }
            }
        }
    }
}
