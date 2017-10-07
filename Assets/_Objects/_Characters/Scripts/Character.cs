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
        [SerializeField] float _distanceToWalkTarget = 2f;
        EnergyLevelBehaviour _energy;
		Clock _clock;
		CharacterMovement _characterMovement;
		HomePoint _homePoint;
        Tags _tags;
        public enum CharacterState{Working, Resting}
        //Serialization For testing purposes. 
        ItemParent _itemParent;
        ItemBehaviour _walkTarget;
        public void SetTarget(ItemBehaviour target){
            _walkTarget = target;
        }
        [SerializeField] CharacterState _state;
        public void SetCharacterState(CharacterState state)
        {
            _state = state;
        }

        void Awake()
        {
            _energy = gameObject.AddComponent<EnergyLevelBehaviour>();
            _energy.Setup(_config);
        }
		void Start()
        {
            RegisterToNotifiers();
            SetupVariables();
        }
        void Update()
        {
            UpdateCharacterState();
            _energy.AdjustEnergyLevel(_walkTarget, _distanceToWalkTarget, _state);
        }

        private void UpdateCharacterState()
        {
            var energy = _energy.energy;
            if (energy.level == 100 && _state != Character.CharacterState.Working)
            {
                ResetTheWalkTargetObject();
                _characterMovement.WalkToTargetObjectWithTag(_walkTarget, _tags.DESK, _state);
            }
            else if (energy.level < energy.energyLevelToRest && _state != Character.CharacterState.Resting)
            {
                ResetTheWalkTargetObject();
                _characterMovement.WalkToTargetObjectWithTag(_walkTarget, _tags.RESTORE_ITEM, _state);
            }
        }

        private void ResetTheWalkTargetObject()
        {
            if (_walkTarget)
            {
                _walkTarget.isOccupied = false;
            }

            _walkTarget = null;
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
            _state = CharacterState.Resting;
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

        void OnDrawGizmos(){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.transform.position, _distanceToWalkTarget);
        }
    }



}
