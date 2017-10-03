using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Products{
	public class ProductConfigStub: IProductConfig {
		private readonly float _pricePerUnit;
		private readonly float _costPerUnit;

		public ProductConfigStub(float pricePerUnit, float costPerUnit){
			_pricePerUnit = pricePerUnit;
			_costPerUnit = costPerUnit;
		}

        public float GetCostPerUnit()
        {
            return _costPerUnit;
        }

        public float GetPricePerUnit()
        {
            return _pricePerUnit;
        }
    }
}

