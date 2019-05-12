using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    [ServiceContract]
    public interface IMonitoringService
    {
        [OperationContract]
        int GetNbRqtToJCDCo();

        [OperationContract]
        int GetNbRqtFromCache();

        [OperationContract]
        int GetTotalRqt();

        [OperationContract]
        long GetAverageTimePerRqt();

        [OperationContract]
        string GetDateLastRqt();

    }
}
