using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{	
	public struct EnergyLevelArgs{
		public float level;
		public float energyLevelToRest;
		public float energyLevelConsumedPerSecond;
		public float energyLevelRestoredPerSecond;
		public ICharacter character;
		public EnergyLevelArgs(float level, float energyLevelToRest, float energyLevelConsumedPerSecond, float energyLevelRestoredPerSecond, ICharacter character)
		{
			this.level = level;
			this.energyLevelToRest = energyLevelToRest;
			this.energyLevelConsumedPerSecond = energyLevelConsumedPerSecond;
			this.energyLevelRestoredPerSecond = energyLevelRestoredPerSecond;
			this.character = character;
		}
	}
}
