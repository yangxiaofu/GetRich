﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{

    public class CharacterStub : ICharacter
    {

		private readonly float _costPerHour;
		private readonly float _productSalesPerHour;
        private readonly float _productDemandCreatedPerHour;
        private readonly float _ordersEnteredPerHour;

		public CharacterStub(CharacterStubArgs args)
        {
			_costPerHour = args.costPerHour;
			_productSalesPerHour = args.productSalesPerHour;
            _productDemandCreatedPerHour = args.productDemandCreatedPerHour;
            _ordersEnteredPerHour = args.ordersEnteredPerHour;
		}
        public float GetCostPerHour()
        {
            return _costPerHour;
        }

        public float GetOrderEnterMaxPerHour()
        {
            return _ordersEnteredPerHour;
        }

        public float GetProductDemandCreatedPerHour()
        {
            return _productDemandCreatedPerHour;
        }

        public float GetOpportunitiesClosedPerHour()
        {
            return _productSalesPerHour;
        }
    }

    public struct CharacterStubArgs{
        public float costPerHour;
        public float productSalesPerHour;
        public float productDemandCreatedPerHour;
        public float ordersEnteredPerHour;

        public CharacterStubArgs(float costPerHour, float productSalesPerHour, float productDemandCreatedPerHour, float ordersEnteredPerHour){
            this.costPerHour = costPerHour;
            this.productSalesPerHour = productSalesPerHour;
            this.productDemandCreatedPerHour = productDemandCreatedPerHour;
            this.ordersEnteredPerHour = ordersEnteredPerHour;
        }
    }

}