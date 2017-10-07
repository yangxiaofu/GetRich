using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters
{
	[System.SerializableAttribute]
	public class EnergyLevel{
		public float level = 0;
		public float energyLevelToRest = 50f;
		public float energyLevelConsumedPerSecond = 0;
		public float maxEnergyLevel = 100f;
		ICharacter _character;
		EnergyLevelBehaviour _behaviour;

		public float GetEnergyAsPercentage()
        {
            return level / 100;
        }
		
		public EnergyLevel(EnergyLevelArgs args)
		{
			_character = args.character;
			energyLevelToRest = args.energyLevelToRest;
			energyLevelConsumedPerSecond = args.energyLevelConsumedPerSecond;
			level = args.level;
			_behaviour = args.behaviour;
		}

		public void IncreaseEnergy()
		{
			var itemBehaviour = _behaviour.gameObject.GetComponent<CharacterMovement>().GetWalkTargetItemBehaviour();
			level += UnityEngine.Time.deltaTime * itemBehaviour.GetEnergyRestoreRatePerSecond();
			level = Mathf.Clamp(level, 0, 100);
		}

		public void DecreaseEnergy()
		{
			level -= UnityEngine.Time.deltaTime * energyLevelConsumedPerSecond;
			level = Mathf.Clamp(level, 0, 100);
		}
	}
}

