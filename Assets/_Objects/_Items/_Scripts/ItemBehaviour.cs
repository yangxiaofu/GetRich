using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects.Characters;
using Game.Core;
using System;

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
		public bool isOccupied{
			get{return _isOccupied;}
			set{_isOccupied = value;}
		}

        public float GetEnergyRestoreRatePerSecond()
        {
            return _itemConfig.GetEnergyRestoredPerSecond();
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
