using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Core;

namespace Game.Objects.Characters{
	public class Character : MonoBehaviour, ICharacter {
		[HeaderAttribute("General Character")]
		[SerializeField] int _dailySalary = 10;
		[SerializeField] CharacterConfig _config;

		//TODO: Remove after testing complete.
		[SerializeField] bool _isWorking = true;
		

		[HeaderAttribute("Energy Levels")]
		[SerializeField] EnergyLevel _energy;
		Clock _clock;
		CharacterMovement _characterMovement;
		HomePoint _homePoint;
		
		void Start()
        {
            SetupEnergyLevel();
            RegisterToNotifiers();
            SetupVariables();
        }

        void Update()
        {
            _energy.CheckLevel();
            _energy.UpdateLevel();
        }

        private void SetupVariables()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _homePoint = GameObject.FindObjectOfType<HomePoint>();
        }

        private void SetupEnergyLevel()
        {
            var energyLevelArgs = new EnergyLevelArgs(
                _config.energyLevel,
                _config.GetEnergyLevelToRest(),
                _config.GetEnergyLevelConsumedPerSecond(),
                _config.GetEnergyLevelRestoredPerSecond(),
                this
            );

            _energy = new EnergyLevel(energyLevelArgs);
        }

        private void RegisterToNotifiers()
        {
            _clock = GameObject.FindObjectOfType<Clock>();
            _clock.OnEndOfDay += OnEndOfDay;
            _clock.OnStartOfDay += OnStartOfDay;
        }

        private void OnStartOfDay()
        {
            _isWorking = true;
			_characterMovement.FindOpenDesk();
        }

        private void OnEndOfDay()
        {
            _isWorking = false;
			_characterMovement.SetTarget(_homePoint.transform);
        }

        public void Setup(CharacterConfig config){
			_config = config;
			SetupEnergyLevel();
		}

		public float GetCostPerHour()
		{
			return _config.GetCostPerHour();
		}

		public float GetOpportunitiesClosedPerHour()
		{
			return _config.GetProductSalesPerHour();
		}

		public float GetOrderEnterMaxPerHour()
		{
			return _config.GetOrdersEnteredPerHour();
		}

        public float GetProductDemandCreatedPerHour()
        {
			Assert.IsNotNull(_config);
            return _config.GetProductDemandCreatedPerHour();
        }

        public bool GetIsWorking()
        {
            return _isWorking;
        }

        public void SetIsWorking(bool value)
        {
            _isWorking = value;
        }
    }



}
