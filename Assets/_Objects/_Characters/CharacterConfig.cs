using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
    [CreateAssetMenuAttribute(menuName = "Game/Character")]
    public class CharacterConfig : ObjectConfig
    {
		[HeaderAttribute("Character Specific")]
		[SerializeField] int _productSalesPerHour = 0;
		[SerializeField] int _productDemandCreatedPerHour = 0;
		[SerializeField] int _ordersEnteredPerHour = 0;

		public int GetProductSalesPerHour()
		{
			return _productSalesPerHour;
		}

		public int GetProductDemandCreatedPerHour()
		{
			return _productDemandCreatedPerHour;
		}

		public int GetOrdersEnteredPerHour()
		{
			return _ordersEnteredPerHour;
		}
    }

}
