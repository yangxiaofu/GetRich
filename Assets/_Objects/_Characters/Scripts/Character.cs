    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Core;
using Game.Objects.Items;

namespace Game.Objects.Characters{
	public class Character : MonoBehaviour, ICharacter {
		[HeaderAttribute("General Character")]
		[SerializeField] CharacterConfig _config;
        [SerializeField] CharacterState _characterState = CharacterState.Resting;
        public bool continueSearch = false;
        EnergyLevelBehaviour _energy;
		Clock _clock;
		CharacterMovement _characterMovement;
		HomePoint _homePoint;
        Tags _tags;
        public enum CharacterState{Working, Resting}
        ItemParent _itemParent;
        
        void Awake()
        {
            _energy = gameObject.AddComponent<EnergyLevelBehaviour>();
            _energy.Setup(_config);
        }
		void Start()
        {
            _characterState = CharacterState.Resting;
            RegisterToNotifiers();
            SetupVariables();
        }
        void Update()
        {
            UpdateCharacterState();
            _energy.AdjustEnergyLevel(_characterState);
        }

        private void UpdateCharacterState()
        {
            var energy = _energy.energy;
            
            if (energy.level == energy.maxEnergyLevel && _characterState != Character.CharacterState.Working && !continueSearch) {

                SearchForWorkStation();

            } else if (energy.level < energy.energyLevelToRest && _characterState != Character.CharacterState.Resting && !continueSearch) {

                SearchForRestArea();

            } else if (continueSearch) {

                SearchForWorkStation();

            }
        }

        private void SearchForRestArea()
        {
            _characterMovement.ResetTheWalkTargetObject();
            _characterMovement.WalkToTargetObjectWithTag(_tags.RESTORE_ITEM, _characterState);
            _characterState = CharacterState.Resting;
        }

        private void SearchForWorkStation()
        {
            _characterMovement.ResetTheWalkTargetObject();
            _characterMovement.WalkToTargetObjectWithTag(_tags.DESK, _characterState);
            _characterState = CharacterState.Working;
        }

        private void SetupVariables()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            Assert.IsNotNull(_characterMovement);

            _homePoint = GameObject.FindObjectOfType<HomePoint>();
            Assert.IsNotNull(_homePoint);

            _itemParent = GameObject.FindObjectOfType<ItemParent>();
            Assert.IsNotNull(_itemParent);

            _tags = FindObjectOfType<Tags>();
            Assert.IsNotNull(_tags);
        }

        private void RegisterToNotifiers()
        {
            _clock = GameObject.FindObjectOfType<Clock>();
            _clock.OnEndOfDay += OnEndOfDay;
        }
        private void OnEndOfDay()
        {
            _characterState = CharacterState.Resting;
			_characterMovement.SetTarget(_homePoint.transform);
        }

        public void Setup(CharacterConfig config){
			_config = config;
		}

		public float GetCostPerHour()
		{
			return _config.GetCostPerHour();
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
    }
}
