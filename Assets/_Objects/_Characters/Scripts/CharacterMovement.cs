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
		void Start()
		{
			_character = GetComponent<Character>();
			_aiCharacterControl = GetComponent<AICharacterControl>();
			_tags = FindObjectOfType<Tags>();
		}

		public void MoveToItemWithTag(string tag){
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
			}	
		}

		public void SetTarget(Transform destination)
		{
			_aiCharacterControl.SetTarget(destination);
		}
	}

}
