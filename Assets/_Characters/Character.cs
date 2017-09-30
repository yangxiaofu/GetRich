using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Game.Characters{
	public class Character : MonoBehaviour {
		AICharacterControl _aiCharacterControl;

		void Start(){
			_aiCharacterControl = GetComponent<AICharacterControl>();
			_aiCharacterControl.SetTarget(GameObject.Find("Walk Target").transform);
		}
	}

}
