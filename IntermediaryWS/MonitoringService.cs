using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    class MonitoringService : IMonitoringService
    {

        public long GetAverageTimePerRqt()
        {
            return Monitoring.Instance.AverageTimePerRqt;
        }

        public string GetDateLastRqt()
        {
            return Monitoring.Instance.LastRqtDate.ToString();
        }

        public int GetNbRqtFromCache()
        {
            return Monitoring.Instance.CptRqtFromCache;
        }

        public int GetNbRqtToJCDCo()
        {
            return Monitoring.Instance.CptRqtToJCDCo;
        }

        public int GetTotalRqt()
        {
            return Monitoring.Instance.TotalRqt;
        }
    }
}
