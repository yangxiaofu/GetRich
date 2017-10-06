using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;

namespace Game.Core{
	public struct SearchArgs{
		public string tag;
		public GameObject[] gameobjects;
		public Character character;

		public SearchArgs(string tag, GameObject[] gameObjects, Character character)
		{
			this.tag = tag;
			this.gameobjects = gameObjects;
			this.character = character;
		}
	}
}
