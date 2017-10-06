using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{

    public class CharacterStub : ICharacter
    {

		private readonly float _costPerHour;
        private readonly float _productDemandCreatedPerHour;
        private readonly float _ordersEnteredPerHour;
        bool _isWorking = false;

        Character.CharacterState _state;
        public void SetIsWorking(bool value){
            _isWorking = value;
        }
        
		public CharacterStub(CharacterStubArgs args)
        {
			_costPerHour = args.costPerHour;
            _productDemandCreatedPerHour = args.productDemandCreatedPerHour;
            _ordersEnteredPerHour = args.ordersEnteredPerHour;
		}
        public float GetCostPerHour()
        {
            return _costPerHour;
        }

        public bool GetIsWorking()
        {
            return _state == Character.CharacterState.Working;
        }

        public float GetOrderEnterMaxPerHour()
        {
            return _ordersEnteredPerHour;
        }

        public float GetProductDemandCreatedPerHour()
        {
            return _productDemandCreatedPerHour;
        }
        public void SetState(Character.CharacterState state)
        {
            _state = state;
        }
    }

   

}