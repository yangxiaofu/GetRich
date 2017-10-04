using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects;
using Game.Core;
using System;
using System.Linq;
using Game.Objects.Products;
using Game.Objects.Characters;

namespace Game.Finances{
	public class FinanceSystem : MonoBehaviour {
		[SerializeField] float _cash = 10000;
		public float GetCurrentCash(){return _cash;}

		public void AddCash(float cash)
		{
			_cash += cash;
		}

		public void UseCash(float cash)
		{
			_cash -= cash;
		}
		
		public void OnObjectDropped(ObjectConfig objectConfig)
		{
			_cash -= objectConfig.GetInitialCost();
		}
	}
}

