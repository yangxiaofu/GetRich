using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects;

namespace Game.Finances{
	public class FinanceSystem : MonoBehaviour {
		[SerializeField] float _cash = 10000;
		public float GetCurrentCash()
		{
			return _cash;
		}

		public void SpendCash(float amount)
		{
			_cash -= amount;

			//TODO: Notifier if below the zero level. 

			//TODO: Do another notifier if in a danger zone. 
		}

		public void OnObjectDropped(ObjectConfig objectConfig)
		{
			_cash -= objectConfig.GetCost();
		}
	}
}

