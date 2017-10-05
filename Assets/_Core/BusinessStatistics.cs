using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	[System.SerializableAttribute]
	[CreateAssetMenuAttribute(menuName = "Game/Business Statistics")]
	public class BusinessStatistics: ScriptableObject, IBusinessStatistics{
		public List<float> marketDemandCreatedByHour = new List<float>();
		public List<float> marketDemandCreatedAcummulated = new List<float>();
		public List<float> marketDemandClosedByHour = new List<float>();
		public List<float> personnelCostsByHour = new List<float>();
		public List<float> profitPerHour = new List<float>();

        public List<float> GetMarketDemandCreatedByHour()
        {
            return marketDemandCreatedByHour;
        }

        public List<float> GetMarketDemandClosedByHour()
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

