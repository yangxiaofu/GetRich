using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class BusinessStatisticsStub: IBusinessStatistics{
		public List<float> marketDemandCreatedByHour = new List<float>();
		public List<float> marketDemandCreatedAcummulated = new List<float>();
		public List<float> marketDemandClosedByHour = new List<float>();
		public List<float> personnelCostsByHour = new List<float>();
		public List<float> profitPerHour = new List<float>();

        public BusinessStatisticsStub()
        {
            marketDemandClosedByHour.Add(0);
            marketDemandCreatedAcummulated.Add(0);
            marketDemandClosedByHour.Add(0);
            personnelCostsByHour.Add(0);
            profitPerHour.Add(0);
        }

        public List<float> GetMarketDemandCreatedByHour()
        {
            return marketDemandCreatedByHour;
        }

        public List<float> GetMarketDemandConvertedByHour()
        {
            return marketDemandClosedByHour;
        }

        public List<float> GetMarketDemandCreatedAccumulated()
        {
            return marketDemandCreatedAcummulated;
        }

        public List<float> GetPersonnelCostsByHour()
        {
            return personnelCostsByHour;
        }

        public List<float> GetProfitPerHour()
        {
            return profitPerHour;
        }
	}
}

