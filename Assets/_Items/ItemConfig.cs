using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items{
	[CreateAssetMenuAttribute(menuName = "Game/Item")]
	public class ItemConfig : ScriptableObject {
		[SerializeField] string _itemName;
		public string itemName{get{return _itemName;}}
		[SerializeField] GameObject _itemPrefab;

		public GameObject GetItemPrefab()
		{
			return _itemPrefab;
		}

		
	}

}
