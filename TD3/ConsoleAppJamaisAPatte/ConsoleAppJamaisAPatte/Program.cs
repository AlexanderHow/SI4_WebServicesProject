using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleAppJamaisAPatte
{
    class Program
    {
        static string APYKEY= "030659a64d21952287040f96eba110fa0db31d7d";
        static string ROOTURL= "https://api.jcdecaux.com/vls/v1/stations";
        static void Main(string[] args)
        {
            //input part
            string ville = "";
            string numStation = "-1";
            Console.Write("Rentrez le nom de la ville: ");
            ville = Console.ReadLine();
            Console.Write("Rentrez le num de la station (optionnel, -1 si non renseigné): ");
            numStation = Console.ReadLine();

            //url construction
            string url = ROOTURL;
            if (!string.Equals(numStation, "-1"))
            {
                url = url + "/" + numStation;
            }
            if (!string.Equals(ville, ""))
            {
                url = url + "?contract=" + ville + "&apiKey=" + APYKEY;
            }
            else
            {
                url = url + "?apiKey=" + APYKEY;
            }
            Console.WriteLine("Votre url : " + url);

            //Request and retrieve data
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Console.WriteLine("Status: "+((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();

            //parsing data retrieved 
            //TODO add security on values["name"] if key exist
            if (string.Equals(numStation, "-1"))
            {
                JArray values = JArray.Parse(responseFromServer);
                Console.WriteLine("Nom de la 1ere stattion: " + values[0]["name"]);
            }
            else {
                JObject values = JObject.Parse(responseFromServer);
                Console.WriteLine("Nom de la station "+numStation+": " + values["name"]);
            }
            
            Console.Write("Quitter ? ");
            string oui = Console.ReadLine();

        }
    }
}
