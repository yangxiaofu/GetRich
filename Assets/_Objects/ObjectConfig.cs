using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects{
	public class ObjectConfig : ScriptableObject{
		[HeaderAttribute("General Object")]
		[SerializeField] string _objectName;
		public string objectName{get{return _objectName;}}
		[SerializeField] GameObject _objectPrefab;
		[SerializeField] float _cost = 100f;
		public GameObject GetObjectPrefab()
		{
			return _objectPrefab;
		}

		public float GetCost(){
			return _cost;
		}
	}
}

