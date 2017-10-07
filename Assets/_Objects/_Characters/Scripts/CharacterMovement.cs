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
		Character _character;
		AICharacterControl _aiCharacterControl;
		ItemParent _itemParent;
		Tags _tags;
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

		public void WalkToTargetObjectWithTag(ItemBehaviour walkTarget, string tag, Character.CharacterState characterState)
        {
            Assert.IsNull(walkTarget, "You must Reset the target object befor making this call. ");

            var targetObject = FindUnOccupiedTargetToWalkTo(tag);
            //Set the target to the work station. 
            if (targetObject)
            {
				
                SetTarget(targetObject.transform);
                walkTarget = targetObject.GetComponent<ItemBehaviour>();
                walkTarget.isOccupied = true;
				GetComponent<Character>().SetTarget(walkTarget);

                if (tag == _tags.RESTORE_ITEM)
                {
					GetComponent<Character>().SetCharacterState(Character.CharacterState.Resting);
                }
                else if (tag == _tags.DESK)
                {
                    GetComponent<Character>().SetCharacterState(Character.CharacterState.Working);
                }
            }
        }

		private GameObject FindUnOccupiedTargetToWalkTo(string tag){
            foreach(Transform child in _itemParent.transform){
                if (child.gameObject.GetComponent<ItemBehaviour>().isOccupied == false && child.gameObject.CompareTag(tag)){
                    return child.gameObject;
                }
            }
            return null;
        }
	}

}
