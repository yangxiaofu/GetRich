using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{	
	public struct EnergyLevelArgs{
		public float level;
		public float energyLevelToRest;
		public float energyLevelConsumedPerSecond;
		public ICharacter character;
		public EnergyLevelBehaviour behaviour;
		public EnergyLevelArgs(float level, float energyLevelToRest, float energyLevelConsumedPerSecond, ICharacter character, EnergyLevelBehaviour behaviour)
		{
			this.level = level;
			this.energyLevelToRest = energyLevelToRest;
			this.energyLevelConsumedPerSecond = energyLevelConsumedPerSecond;
			this.character = character;
			this.behaviour = behaviour;
		}
	}
}
