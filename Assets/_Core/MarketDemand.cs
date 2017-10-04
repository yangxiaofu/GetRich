using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;
using Game.Objects.Products;

namespace Game.Core{
	public class MarketDemand {
		private readonly IProductConfig _productConfig;
		private readonly List<ICharacter> _characters;
		
		public MarketDemand(IProductConfig productConfig, List<ICharacter> characters)
		{
			_productConfig = productConfig;
			_characters = characters;
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
