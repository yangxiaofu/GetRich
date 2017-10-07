using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Game.Objects.Items;
using Game.Core;
using System;
using UnityEngine.Assertions;

namespace Game.Objects.Characters{
	public class CharacterMovement : MonoBehaviour {
		[SerializeField] float _distanceToWalkTarget = 2f;
		public float distanceToWalkTarget{get{return _distanceToWalkTarget;}}
		Character _character;
		AICharacterControl _aiCharacterControl;
		ItemParent _itemParent;
		Tags _tags;
		GameObject _walkTarget;
        public ItemBehaviour GetWalkTargetItemBehaviour()
        {
            return _walkTarget.GetComponent<ItemBehaviour>();
        }
		public GameObject walkTarget{get{return _walkTarget;}}

		void Start()
		{
			_character = GetComponent<Character>();
			
			_aiCharacterControl = GetComponent<AICharacterControl>();
			_tags = FindObjectOfType<Tags>();
			Assert.IsNotNull(_tags);

			_itemParent = FindObjectOfType<ItemParent>();
			Assert.IsNotNull(_itemParent);
		}

		public void SetTarget(Transform destination)
		{
			_aiCharacterControl.SetTarget(destination);
		}

		public void WalkToTargetObjectWithTag(string tag, Character.CharacterState characterState)
        {
            Assert.IsNull(_walkTarget, "You must Reset the target object befor making this call. ");

            var targetObject = FindUnOccupiedTargetToWalkTo(tag);
            //Set the target to the work station. 
            if (targetObject)
            {		
                SetTarget(targetObject.transform);
                _walkTarget = targetObject;
                _walkTarget.GetComponent<ItemBehaviour>().isOccupied = true;
                _character.continueSearch = false;
            } else {
                _character.continueSearch = true;
            }
        }

		public void ResetTheWalkTargetObject()
        {
            if (_walkTarget)
            {
                _walkTarget.GetComponent<ItemBehaviour>().isOccupied = false;
            }

            _walkTarget = null;
        }

		private GameObject FindUnOccupiedTargetToWalkTo(string tag){
            foreach(Transform child in _itemParent.transform){
                if (child.gameObject.GetComponent<ItemBehaviour>().isOccupied == false && child.gameObject.CompareTag(tag)){
                    return child.gameObject;
                }
            }
            return null;
        }

		void OnDrawGizmos(){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.transform.position, _distanceToWalkTarget);
        }
	}

}
