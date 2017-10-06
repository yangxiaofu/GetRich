using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects.Characters;
using Game.Core;

namespace Game.Objects.Items{
	public class ItemBehaviour : MonoBehaviour {
		[SerializeField] float _inRangeRadius = 5f;
		SphereCollider _sphereCollider;
		ItemConfig _itemConfig;
		Character _character;
		Tags _tags;

		void Start()
		{
			_sphereCollider = gameObject.AddComponent<SphereCollider>();
			_sphereCollider.isTrigger = true;
			_sphereCollider.radius = _inRangeRadius;

			_tags = FindObjectOfType<Tags>();
			Assert.IsNotNull(_tags);
		}

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

		void OnTriggerEnter(Collider other)
		{
			
			if (other.gameObject.GetComponent<Character>() == _character)
			{
				if (this.gameObject.CompareTag(_tags.DESK)){
					other.gameObject.GetComponent<Character>().SetState(Character.CharacterState.Working);
				} else if (this.gameObject.CompareTag(_tags.RESTORE_ITEM)){
					other.gameObject.GetComponent<Character>().SetState(Character.CharacterState.Resting);
				}
				
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.GetComponent<Character>() == _character)
			{
				_isOccupied = false;
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, _inRangeRadius);			
		}

	}

}
