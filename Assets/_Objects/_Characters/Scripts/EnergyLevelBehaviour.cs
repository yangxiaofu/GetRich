using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Items;

namespace Game.Objects.Characters{
	public class EnergyLevelBehaviour : MonoBehaviour {
		[SerializeField] EnergyLevel _energy;
		public EnergyLevel energy{get{return _energy;}}

		CharacterConfig _config;
		Character _character;
		public float GetEnergyAsPercentage() {return _energy.GetEnergyAsPercentage();}

		void Start()
		{
			_character = GetComponent<Character>();
		}
		public void Setup(CharacterConfig config)
		{
			_config = config;
			SetupEnergyLevel();
		}

		public void AdjustEnergyLevel(Character.CharacterState characterState)
		{
            var walkTarget = GetComponent<CharacterMovement>().walkTarget;
			if (walkTarget)
            { 
                var distanceFromTarget = Vector3.Distance(this.transform.position, walkTarget.transform.position);

                if (distanceFromTarget < GetComponent<CharacterMovement>().distanceToWalkTarget)
                {
                    if (characterState == Character.CharacterState.Working)
                    {
                        _energy.DecreaseEnergy();
                    }
                    else if (characterState == Character.CharacterState.Resting)
                    {
                        _energy.IncreaseEnergy();
                    }
                }
            }
		}

		private void SetupEnergyLevel()
        {
            var energyLevelArgs = new EnergyLevelArgs(
                _config.energyLevel,
                _config.GetEnergyLevelToRest(),
                _config.GetEnergyLevelConsumedPerSecond(),
                GetComponent<Character>(), 
                this
            );

            _energy = new EnergyLevel(energyLevelArgs);
        }
	}
}