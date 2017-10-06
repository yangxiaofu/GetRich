using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
	public class EnergyLevelBehaviour : MonoBehaviour {
		[SerializeField] EnergyLevel _energy;
		CharacterConfig _config;
		Character _character;
		public float GetEnergyAsPercentage() {return _energy.GetEnergyAsPercentage();}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			_character = GetComponent<Character>();
		}

		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		void Update()
		{
			if (_energy.level <= _energy.energyLevelToRest)
			{
				_character.isWorking = false;
				_character.SetState(Character.CharacterState.Transition);
			} else if (_energy.level == 100){
				Debug.Log("Energy at full capacity");
				_character.isWorking = true;
				_character.SetState(Character.CharacterState.Transition);
			}	
		}

		public void Setup(CharacterConfig config)
		{
			_config = config;
			SetupEnergyLevel();
		}

		public void IncreaseEnergy()
		{
			_energy.IncreaseEnergy();
		}

		public void DecreaseEnergy()
		{
			_energy.DecreaseEnergy();
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