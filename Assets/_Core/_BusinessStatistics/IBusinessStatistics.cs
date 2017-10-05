using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public interface IBusinessStatistics{
		List<float> GetMarketDemandCreatedByHour();
		List<float> GetMarketDemandCreatedAccumulated();
		List<float> GetMarketDemandConvertedByHour();
		List<float> GetPersonnelCostsByHour();
		List<float> GetProfitPerHour();
	}
}

