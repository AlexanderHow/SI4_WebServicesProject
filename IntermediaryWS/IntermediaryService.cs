using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IntermediaryWS
{
    
    public class IntermediaryService : IIntermerdiaryService
    {
        public IntermediaryService()
        {
            //connection
        }
        public List<string> GetCities()
        {
            throw new NotImplementedException();
        }

        public string GetNbBikes(string station)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNbBikesInStations(string station)
        {
            throw new NotImplementedException();
        }

        public List<string> GetStations(string city)
        {
            throw new NotImplementedException();
        }
    }
}
