using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
    [CreateAssetMenuAttribute(menuName = "Game/Character")]
    public class CharacterConfig : ObjectConfig
    {
		[HeaderAttribute("Character Specific")]
		[SerializeField] int _demandConvertedPerHour = 0;
		[SerializeField] int _demandCreatedPerHour = 0;
		[SerializeField] int _ordersEnteredPerHour = 0;

		public int GetProductSalesPerHour()
		{
			return _demandConvertedPerHour;
		}

		public int GetProductDemandCreatedPerHour()
		{
			return _demandCreatedPerHour;
		}

		public int GetOrdersEnteredPerHour()
		{
			return _ordersEnteredPerHour;
		}
    }

}
