using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Products{
	[CreateAssetMenuAttribute(menuName = "Game/Product")]
	public class ProductConfig : ScriptableObject, IProductConfig {
		[SerializeField] string _productName = "";
		public string productName{get{return _productName;}}
		[SerializeField] float _pricePerUnit = 10f;
		public float GetPricePerUnit()
		{
			return _pricePerUnit;
		}
		[SerializeField] float _costPerUnit = 5f;
		public float GetCostPerUnit()
		{
			return _costPerUnit;
		}
	}

	public interface IProductConfig{
		float GetPricePerUnit();
		float GetCostPerUnit();
	}

}

