using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects.Characters;

namespace Game.Objects.Items{
	public class ItemBehaviour : MonoBehaviour {
		[SerializeField] float _inRangeRadius = 5f;

		ItemConfig _itemConfig;
		Character _character;
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

		public void SetCharacter(Character character){
			_character = character;
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, _inRangeRadius);			
		}

	}

}
