using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;
using Game.Objects.Products;

namespace Game.Core{
	[System.SerializableAttribute]
	public class MarketDemand {
		[SerializeField] List<float> _marketDemandCreatedByHour = new List<float>();
		[SerializeField] List<float> _marketDemandCreatedAcummulated = new List<float>();
		private readonly IProductConfig _productConfig;
		private readonly List<ICharacter> _characters;
		private readonly IBusinessStatistics _bs;
		
		public MarketDemand(BusinessStatisticsArgs args)
		{
			_productConfig = args.products[0];
			_characters = args.characters;
			_bs = args.businessStatistics;
		}

		public float GetMarketDemandQuantityPerHour()
		{
			float totalMarketDemandCreated = 0;
			for(int i = 0; i < _characters.Count; i++)
			{
				totalMarketDemandCreated += _characters[i].GetProductDemandCreatedPerHour();	
			}
			return totalMarketDemandCreated;
		}


	}

}
