using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;

namespace Game.Core{
	public struct SearchArgs{
		public string tag;
		public Transform gameObjectsParent;

		public SearchArgs(string tag, Transform gameObjectsParent)
		{
			this.tag = tag;
			this.gameObjectsParent = gameObjectsParent;
		}
	}
}
