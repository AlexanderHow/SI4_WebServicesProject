using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{

    public class IntermediaryService : IIntermerdiaryService
    {
        private static List<string> defaultInitCache = new List<string>() { "stations" };
        private CacheManager cache = new CacheManager(defaultInitCache);

        public IntermediaryService()
        {
            //connection
            //adresse reference = http://localhost:8733/IntermediaryWS
        }

        public async Task<string> GetContract(string contractName)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("name", contractName);
            string result = await cache.manageRequest("contracts", addParam);
            return result;
        }

        public async Task<string> GetContracts()
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            string result = await cache.manageRequest("contracts", addParam);
            return result;
        }

        public async Task<string> GetNbBikes(string idStation, string contractName)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", contractName.ToLower());
            string result = await cache.manageRequest("stations/" + idStation + "/available_bikes", addParam);
            return result;
        }

        public async Task<string> GetNbBikes(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await cache.manageRequest("stations/available_bikes", addParam);
            return result;
        }

        public async Task<string> GetPosition(string idStation, string contractName)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", contractName.ToLower());
            string result = await cache.manageRequest("stations/" + idStation + "/position", addParam);
            return result;
        }

        public async Task<string> GetPositions(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await cache.manageRequest("stations/position", addParam);
            return result;
        }

        public async Task<string> GetStation(string idStation, string contractName)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", contractName.ToLower());
            string result = await cache.manageRequest("stations/"+idStation, addParam);
            return result;
        }

        public async Task<string> GetStations()
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            string result = await cache.manageRequest("stations", addParam);
            return result;
        }

        public async Task<string> GetStations(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await cache.manageRequest("stations", addParam);
            return result;
        }
    }
}
