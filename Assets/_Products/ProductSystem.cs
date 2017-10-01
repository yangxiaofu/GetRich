using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Products{
	public class ProductSystem : MonoBehaviour {
		
		[SerializeField] List<ProductConfig> _products = new List<ProductConfig>();
		public List<ProductConfig> GetProducts()
		{
			return _products;
		}

	}

}
