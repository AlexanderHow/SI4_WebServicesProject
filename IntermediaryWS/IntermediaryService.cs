using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{

    public class IntermediaryService : IIntermediaryService
    {

        public IntermediaryService()
        {
            //connection
            //adresse reference = http://localhost:8733/IntermediaryWS/
        }

        public async Task<string> GetCity(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("name", city);
            string result = await CacheManager.Instance.manageRequest("contracts", addParam);
            return result;
        }

        public async Task<string> GetCities()
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            string result = await CacheManager.Instance.manageRequest("contracts", addParam);
            return result;
        }

        public async Task<string> GetNbBikes(string idStation, string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations/" + idStation + "/available_bikes", addParam);
            return result;
        }

        public async Task<string> GetNbBikesCity(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations/available_bikes", addParam);
            return result;
        }

        public async Task<string> GetPosition(string idStation, string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations/" + idStation + "/position", addParam);
            return result;
        }

        public async Task<string> GetPositions(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations/position", addParam);
            return result;
        }

        public async Task<string> GetStation(string idStation, string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations/"+idStation, addParam);
            return result;
        }

        public async Task<string> GetStations()
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            string result = await CacheManager.Instance.manageRequest("stations", addParam);
            return result;
        }

        public async Task<string> GetStationsCity(string city)
        {
            Dictionary<string, string> addParam = new Dictionary<string, string>();
            addParam.Add("contract_name", city.ToLower());
            string result = await CacheManager.Instance.manageRequest("stations", addParam);
            return result;
        }
    }
}
