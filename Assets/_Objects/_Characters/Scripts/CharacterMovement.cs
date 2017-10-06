using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Game.Objects.Items;
using Game.Core;
using System;

namespace Game.Objects.Characters{
	public class CharacterMovement : MonoBehaviour {
		Character _character;
		AICharacterControl _aiCharacterControl;
		Tags _tags;
		bool _foundItem = false;
		void Start()
		{
			_character = GetComponent<Character>();
			_aiCharacterControl = GetComponent<AICharacterControl>();
			_tags = FindObjectOfType<Tags>();
		}

		void Update()
		{
			if (_character.GetIsWorking()){
				FindItemWithTag(_tags.DESK);
				_foundItem = false;
			} else {
				FindItemWithTag(_tags.RESTORE_ITEM);
				_foundItem = false;
			}
		}

		public void FindItemWithTag(string tag){
			if (_foundItem) return;

			var args = new SearchArgs(
				tag, 
				GameObject.FindGameObjectsWithTag(tag), 
				_character
			);

			var search = new Search(args);
			var target = search.FindGameObjectWithTag();

			if (target != null)
			{
				SetTarget(target.transform);
				_foundItem = true;
			}
			
			
		}

		public void SetTarget(Transform destination)
		{
			_aiCharacterControl.SetTarget(destination);
		}
	}

}
