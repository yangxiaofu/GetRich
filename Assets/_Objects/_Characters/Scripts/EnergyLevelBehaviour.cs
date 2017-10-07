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

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			_character = GetComponent<Character>();
		}
		public void Setup(CharacterConfig config)
		{
			_config = config;
			SetupEnergyLevel();
		}

		public void AdjustEnergyLevel(ItemBehaviour targetItem, float distanceToWalkTarget, Character.CharacterState characterState)
		{
			if (targetItem)
            { 
                var distanceFromTarget = Vector3.Distance(this.transform.position, targetItem.transform.position);

                if (distanceFromTarget < distanceToWalkTarget)
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
                _config.GetEnergyLevelRestoredPerSecond(),
                GetComponent<Character>()
            );

            _energy = new EnergyLevel(energyLevelArgs);
        }
	}
}