using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Items;
using Game.Objects.Characters;

namespace Game.Core{
	public class Search{
		private readonly string tag;
		private readonly Transform parent;
		public Search(SearchArgs args)
		{
			parent = args.gameObjectsParent;
			tag = args.tag;
		}
		public GameObject FindUnOccupiedItemWithTag()
		{
			foreach(Transform child in parent)
			{
				if (child.gameObject.GetComponent<ItemBehaviour>().isOccupied == false){
					return child.gameObject;
				}
			}

			return null;
		}
	}



}
