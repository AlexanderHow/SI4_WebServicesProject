using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Console.VelibSOAP;
using Client_Console.Monitoring;
using Newtonsoft.Json.Linq;

namespace Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IntermediaryServiceClient serviceClient = new IntermediaryServiceClient();

            Console.WriteLine("---Bienvenue sur la version console de Velib WS---");

            Console.WriteLine("---Commandes disponibles---");
            Console.WriteLine("villes --- liste des villes disponibles");
            Console.WriteLine("stations <ville> --- liste des stations d'une ville");
            Console.WriteLine("velibS <idstation> <ville> --- nombre de velibs disponibles sur une station");
            Console.WriteLine("velibC <ville> --- nombre de velibs disponibles sur une ville");
            Console.WriteLine("position <idstation> <ville>  --- position d'une station");
            Console.WriteLine("monitoring --- accéder au menu Monitoring");
            Console.WriteLine("help --- afficher les commandes");
            Console.WriteLine("quitter --- quitter l'application");

            string input = "";

            while (true)
            {
                Console.Write(">>>");

                input = Console.ReadLine();
                string[] argsT = input.Split(' ');
                if (argsT.Length < 1)
                {
                    continue;
                }

                if (argsT[0] == "quit")
                {
                    Environment.Exit(0);
                }
                else if (argsT[0] == "help")
                {
                    Console.WriteLine("---Commandes disponibles---");
                    Console.WriteLine("villes --- liste des villes disponibles");
                    Console.WriteLine("stations <ville> --- liste des stations d'une ville");
                    Console.WriteLine("velibS <idstation> <ville> --- nombre de velibs sur une station");
                    Console.WriteLine("velibC <ville> --- nombre de velibs sur une ville");
                    Console.WriteLine("position <idstation> <ville> --- position d'une station");
                    Console.WriteLine("monitoring --- accéder au menu Monitoring");
                    Console.WriteLine("help --- afficher les commandes");
                    Console.WriteLine("quitter --- quitter l'application\n");
                }
                else if (argsT[0] == "villes")
                {
                    string cities = serviceClient.GetCities();
                    showCorrectData(cities, "name");
                }
                else if (argsT[0] == "stations")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        string stations = serviceClient.GetStationsCity(argsT[1]);
                        showCorrectData(stations, "name");
                    }
                    else
                    {
                        Console.WriteLine("Argument Manquant");
                    }
                }
                else if (argsT[0] == "velibS")
                {
                    if (argsT.Length > 2 && argsT.Length < 4)
                    {
                        string dispo = serviceClient.GetNbBikes(argsT[1], argsT[2]);
                        dispo = dispo.Substring(2, dispo.Length-3);
                        Console.WriteLine("Nombre de vélibs disponibles : " + dispo);
                    }
                    else
                    {
                        Console.WriteLine("Argument Manquant");
                    }
                }
                else if (argsT[0] == "velibC")
                {
                    if (argsT.Length > 1 && argsT.Length < 3)
                    {
                        int nbVelib = 0;
                        int tmp = 0;
                        string dispo = serviceClient.GetNbBikesCity(argsT[1]);
                        dispo = dispo.Substring(2, dispo.Length - 3);
                        string[] result = dispo.Split(',');
                        foreach (string s in result)
                        {
                            tmp = Int32.Parse(s);
                            nbVelib += tmp;
                        }
                        Console.WriteLine("Nombre de vélibs disponibles à " + argsT[1] + " : " + nbVelib);
                    }
                    else
                    {
                        Console.WriteLine("Argument Manquant");
                    }
                }
                else if (argsT[0] == "position")
                {
                    if (argsT.Length > 2 && argsT.Length < 4)
                    {
                        string position = serviceClient.GetPosition(argsT[1], argsT[2]);
                        Console.Write("Latitude : ");
                        showCorrectData(position, "lat");
                        Console.Write("Longitude : ");
                        showCorrectData(position, "lng");
                    }
                    else
                    {
                        Console.WriteLine("Argument Manquant");
                    }
                }
                else if (argsT[0] == "monitoring")
                {
                    handleMonitoring();
                }
                else
                {
                    Console.WriteLine("La commande entrée n'est pas prise en compte, tapez help pour voir les commandes disponibles");
                }
                Console.WriteLine("");
            }
        }

        static void showCorrectData(string input, string attribute)
        {
            JArray jArray = JArray.Parse(input);
            foreach (JObject o in jArray.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    if (p.Name.Equals(attribute))
                    {
                        Console.WriteLine(p.Value);
                    }
                }
            }
        }

        static void handleMonitoring()
        {
            string input = "";
            MonitoringServiceClient monitor = new MonitoringServiceClient();

            Console.WriteLine("Bienvenue sur la version monitoring de Velib WS");
            Console.WriteLine("---Commandes disponibles---");
            Console.WriteLine("rqtJCDCO --- nombre de requêtes effectuées vers l'API JCDECAUX");
            Console.WriteLine("rqtCache --- nombre de requêtes effectuées depuis le cache");
            Console.WriteLine("rqtTotal --- nombre total de requêtes effectuées");
            Console.WriteLine("tmpMoyen --- temps moyen de réponse des requêtes effectuées");
            Console.WriteLine("quit --- retourner au menu principal\n");

            while (true)
            {
                Console.Write("Monitoring>");

                input = Console.ReadLine();
                string[] argsT = input.Split(' ');
                if (argsT.Length < 1)
                {
                    continue;
                }

                if (argsT[0] == "quit")
                {
                    return;
                }
                else if (argsT[0] == "help")
                {
                    Console.WriteLine("---Commandes disponibles---");
                    Console.WriteLine("rqtJCDCO --- nombre de requêtes effectuées vers l'API JCDECAUX");
                    Console.WriteLine("rqtCache --- nombre de requêtes effectuées depuis le cache");
                    Console.WriteLine("rqtTotal --- nombre total de requêtes effectuées");
                    Console.WriteLine("tmpMoyen --- temps moyen de réponse des requêtes effectuées");
                    Console.WriteLine("quit --- retourner au menu principal\n");
                }
                else if (argsT[0] == "rqtJCDCO")
                {
                    Console.WriteLine("  Nombre de requêtes effectuées vers l'API JCDCAUX : " + monitor.GetNbRqtToJCDCo());
                    if (!(monitor.GetTotalRqt() == 0))
                    {
                        Console.WriteLine("  Soit un pourcentage de " + (monitor.GetNbRqtToJCDCo() / monitor.GetTotalRqt()) * 100 + " % des requêtes totales");
                    }
                }
                else if (argsT[0] == "rqtCache")
                {
                    Console.WriteLine("  Nombre de requêtes effectuées vers le cache : " + monitor.GetNbRqtFromCache());
                    if (!(monitor.GetTotalRqt() == 0))
                    {
                        Console.WriteLine("  Soit un pourcentage de " + (monitor.GetNbRqtFromCache() / monitor.GetTotalRqt()) * 100 + " % des requêtes totales");
                    }
                }
                else if (argsT[0] == "rqtTotal")
                {
                    Console.WriteLine("  Nombre de total de requêtes effectuées : " + monitor.GetTotalRqt());
                }
                else if (argsT[0] == "tmpMoyen")
                {
                    Console.WriteLine("  Temps moyen de réponse pour une requête : " + monitor.GetAverageTimePerRqt() + " ms");
                }
                else
                {
                    Console.WriteLine("  La commande entrée n'est pas prise en compte, tapez help pour voir les commandes disponibles");
                }
                Console.WriteLine("");
            }
        }
    }
}
