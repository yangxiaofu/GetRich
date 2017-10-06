﻿using System;
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
		public float energyLevelRestoredPerSecond = 0;
		ICharacter _character;

		public float GetEnergyAsPercentage()
        {
            return level / 100;
        }
		
		public EnergyLevel(EnergyLevelArgs args)
		{
			_character = args.character;
			energyLevelToRest = args.energyLevelToRest;
			energyLevelConsumedPerSecond = args.energyLevelConsumedPerSecond;
			energyLevelRestoredPerSecond = args.energyLevelRestoredPerSecond;
			level = args.level;
		}

 

        public void UpdateLevel()
        {
			if (_character.GetIsWorking())
			{
				level -= UnityEngine.Time.deltaTime * energyLevelConsumedPerSecond;
				level = Mathf.Clamp(level, 0, 100);

			} else {

				level += UnityEngine.Time.deltaTime * energyLevelRestoredPerSecond;
				level = Mathf.Clamp(level, 0, 100);

			}
        }

		public void CheckLevel()
        {
            if (_character.GetIsWorking())
            {
                if (level <= energyLevelToRest)
                {
                    _character.SetIsWorking(false);
                }
            }
            else
            {
                if (level == 100)
                {
                    _character.SetIsWorking(true);
                }
            }
        }
	}
}
