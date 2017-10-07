using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Items{
	[CreateAssetMenuAttribute(menuName = "Game/Item")]
	public class ItemConfig : ObjectConfig {
		public string tag = "";

		[SerializeField] float energyRestoredPerSecond = 1f;
		public float GetEnergyRestoredPerSecond()
		{
			return energyRestoredPerSecond;
		}
    }

}
