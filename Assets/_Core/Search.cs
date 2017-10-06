using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Items;
using Game.Objects.Characters;

namespace Game.Core{
	public class Search{
		private readonly string _tag;
		private readonly GameObject[] _targets;
		private readonly Character _character;
		public Search(SearchArgs args)
		{
			_tag = args.tag;
			_targets = args.gameobjects;
			_character = args.character;
		}

		public GameObject FindGameObjectWithTag()
		{
			for(int i = 0; i < _targets.Length; i++)
			{
				if (!_targets[i].GetComponent<ItemBehaviour>().isOccupied){

					var itemComponent = _targets[i].GetComponent<ItemBehaviour>();
					itemComponent.SetIsOccuppied(true);
					itemComponent.SetCharacter(_character);
					return _targets[i];
				}
			}

			return null;
		}
	}



}
