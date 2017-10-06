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
        EnergyLevelBehaviour _energy;
		Clock _clock;
		CharacterMovement _characterMovement;
		HomePoint _homePoint;
        Tags _tags;

        public enum CharacterState{
            Working, Resting, Transition
        }
        private CharacterState _state;
        
        bool _isWorking = true;
        public bool isWorking{
            get{return _isWorking;}
            set{_isWorking = value;}
        }

        
        public void SetState(CharacterState state) {_state = state;}
        void Awake()
        {
            _energy = gameObject.AddComponent<EnergyLevelBehaviour>();
            _energy.Setup(_config);
        }
		void Start()
        {
            _state = CharacterState.Transition;
            RegisterToNotifiers();
            SetupVariables();
        }

        void Update(){

            if (_state == CharacterState.Transition){
                //Walk to the destination. 
                if (_isWorking){
                    _characterMovement.MoveToItemWithTag(_tags.DESK);
                } else {
                    _characterMovement.MoveToItemWithTag(_tags.RESTORE_ITEM);
                }
            } else if (_state == CharacterState.Resting){
                //Increase the energy level. 
                _energy.IncreaseEnergy();

            } else if (_state == CharacterState.Working){
                //Decrease Energy Level. 
                _energy.DecreaseEnergy();
                //Set State to Is Working.
            }
        }

        private void SetupVariables()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            Assert.IsNotNull(_characterMovement);

            _homePoint = GameObject.FindObjectOfType<HomePoint>();
            Assert.IsNotNull(_homePoint);

            _tags = FindObjectOfType<Tags>();
            Assert.IsNotNull(_tags);
        }

        private void RegisterToNotifiers()
        {
            _clock = GameObject.FindObjectOfType<Clock>();
            _clock.OnEndOfDay += OnEndOfDay;
            _clock.OnStartOfDay += OnStartOfDay;
        }

        private void OnStartOfDay()
        {
            _state = CharacterState.Transition;
			_characterMovement.MoveToItemWithTag(_tags.DESK);
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
            return _state == CharacterState.Working;
        }
    }



}
