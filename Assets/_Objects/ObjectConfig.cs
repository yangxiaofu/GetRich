using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects{
	public abstract class ObjectConfig : ScriptableObject{
		[HeaderAttribute("General Object")]
		[SerializeField] string _objectName;
		public string objectName{get{return _objectName;}}
		[SerializeField] GameObject _objectPrefab;
		[SerializeField] float _initialCost = 100f;
		[SerializeField] float _costPerHour = 50f;
		
		public GameObject GetObjectPrefab()
		{
			return _objectPrefab;
		}

		public float GetInitialCost(){
			return _initialCost;
		}

		public float GetCostPerHour()
		{
			return _costPerHour;
		}
	}
}

