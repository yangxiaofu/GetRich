using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
	public class EnergyLevelBehaviour : MonoBehaviour {
		[SerializeField] EnergyLevel _energy;
		CharacterConfig _config;
		public float GetEnergyAsPercentage() {return _energy.GetEnergyAsPercentage();}
		public void Setup(CharacterConfig config)
		{
			_config = config;
			SetupEnergyLevel();
		}

		void Update()
		{
			_energy.CheckLevel();
            _energy.UpdateLevel();
		}

		private void SetupEnergyLevel()
        {
            var energyLevelArgs = new EnergyLevelArgs(
                _config.energyLevel,
                _config.GetEnergyLevelToRest(),
                _config.GetEnergyLevelConsumedPerSecond(),
                _config.GetEnergyLevelRestoredPerSecond(),
                GetComponent<Character>()
            );

            _energy = new EnergyLevel(energyLevelArgs);
        }
	}
}