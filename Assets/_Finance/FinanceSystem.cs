using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects;
using Game.Core;
using System;
using Game.Objects.Products;

namespace Game.Finances{
	public class FinanceSystem : MonoBehaviour {
		[SerializeField] float _cash = 10000;
		ProductSystem _productSystem;
		Clock _clock;

		void Start()
		{
			_clock = FindObjectOfType<Clock>();
			_clock.OnTimeForUpdate += OnTimeForUpdate;

			_productSystem = GetComponent<ProductSystem>();
			Assert.IsNotNull(_productSystem);
		}

        void OnTimeForUpdate()
        {
			var products = _productSystem.GetProducts();
			_cash += products[0].GetPricePerUnit();
        }

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

