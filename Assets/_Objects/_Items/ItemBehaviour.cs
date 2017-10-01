using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Objects.Items{
	public class ItemBehaviour : MonoBehaviour {
		ItemConfig _itemConfig;
		public void SetupConfig(ItemConfig itemConfig)
		{
			_itemConfig = itemConfig;
			Assert.AreNotEqual("", _itemConfig.tag);
			this.gameObject.tag = _itemConfig.tag;
		}

		//Used for designed. Remove serialization when testing complete. 
		[SerializeField] private bool _isOccupied = false;
		public bool isOccupied{get{return _isOccupied;}}
		public void SetIsOccuppied(bool occupied)
		{
			_isOccupied = occupied;
		}

	}

}
