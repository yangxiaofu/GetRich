using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Game.Objects.Items;

namespace Game.Objects.Characters{
	public class CharacterMovement : MonoBehaviour {
		AICharacterControl _aiCharacterControl;
		const string DESK = "Desk"; //TODO: Centralize the tag names somehwere.
		bool _foundDesk = false;
		void Start()
		{
			_aiCharacterControl = GetComponent<AICharacterControl>();
		}

		void Update()
		{
			FindOpenDesk();
		}

		public void FindOpenDesk()
		{
			if (_foundDesk) return;

			var desks = GameObject.FindGameObjectsWithTag(DESK);

			for(int i  = 0; i < desks.Length; i++)
			{
				if (!desks[i].GetComponent<ItemBehaviour>().isOccupied){
					desks[i].GetComponent<ItemBehaviour>().SetIsOccuppied(true);
					_foundDesk = true;
					SetTarget(desks[i].transform);
					break;
				}
			}
		}

		public void SetTarget(Transform destination)
		{
			_aiCharacterControl.SetTarget(destination);
		}
	}

}
