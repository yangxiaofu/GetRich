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

		[HeaderAttribute("Energy Level")]
		[SerializeField] float _energyLevel = 100f;
		public float energyLevel {get{return _energyLevel;}}
		[SerializeField] float _energyLevelConsumedPerSecond = 1f;
		[SerializeField] float _energyLevelRestoredPerSecond = 3f;
		[SerializeField] float _energyLevelToRest = 50f;
		
		public float GetEnergyLevelConsumedPerSecond()
		{
			return _energyLevelConsumedPerSecond;
		}

		public float GetEnergyLevelRestoredPerSecond()
		{
			return _energyLevelRestoredPerSecond;
		}

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

		public float GetEnergyLevelToRest()
		{
			return _energyLevelToRest;
		}

    }

}
