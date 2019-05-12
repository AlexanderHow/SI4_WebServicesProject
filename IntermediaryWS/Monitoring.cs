using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    public sealed class Monitoring
    {
        private static readonly Lazy<Monitoring> lazy =
        new Lazy<Monitoring>(() => new Monitoring());

        public int CptRqtToJCDCo { get; set; } = 0;
        public int CptRqtFromCache { get; set; } = 0;
        public int TotalRqt { get { return CptRqtFromCache + CptRqtToJCDCo; } }
        public long AverageTimePerRqt { get; set; } = 0;
        public DateTime LastRqtDate { get; set; } = DateTime.Now;
        private DateTime LastResetDate { get; set; } = DateTime.Now;


        public static Monitoring Instance { get { return lazy.Value; } }

        private Monitoring()
        {
        }

        public bool doesNeedToReset()
        {
            double timespan = DateTime.Now.Subtract(LastResetDate).TotalMinutes;
            if(timespan > 1) { LastResetDate = DateTime.Now; }
            return timespan > 1;
        }

        public void countRqtToJCDCo(int n)
        {
            if ((this.CptRqtToJCDCo + n) >= 0)
            {
                this.CptRqtToJCDCo += n;
            }
        }

        public void countRqtFromCache(int n)
        {
            if ((this.CptRqtFromCache + n) >= 0)
            {
                this.CptRqtFromCache += n;
            }
        }

        public void countAverageTimePerRqt(long time)
        {
            this.AverageTimePerRqt = ((this.AverageTimePerRqt*(TotalRqt-1)) + time) / TotalRqt;
        }

    }
}