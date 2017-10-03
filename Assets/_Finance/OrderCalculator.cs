using System;
using System.Collections.Generic;
using Game.Objects.Products;
using Game.Objects.Characters;
using UnityEngine;

namespace Game.Finances
{
    public class OrderCalculator{
		List<IProductConfig> _productConfigs;
		List<ICharacter> _characters;
		public OrderCalculator(OrderCalculatorArgs args)
		{
			_productConfigs = args.products;
			_characters = args.characters;
		}

		public float GetProductProfitPerHour()
		{
			float totalProductProfit = 0;

            for (int i = 0; i < _productConfigs.Count; i++)
            {
                totalProductProfit += CalculateProfit(_productConfigs[i]);
            }

            return totalProductProfit;
		}

		public float GetPersonnelCostsPerHour()
		{
			float totalOverheadCosts = 0;
			
			for(int i = 0; i < _characters.Count; i++)
			{
				totalOverheadCosts += _characters[i].GetCostPerHour();
			}
			return totalOverheadCosts;
		}

		public float GetTotalOpportunitiesClosedPerHour()
		{
  			float opportunitiesClosedPotentialPerHour = 0;
			for(int i = 0; i < _characters.Count; i++)
			{
				opportunitiesClosedPotentialPerHour += _characters[i].GetOpportunitiesClosedPerHour();
			}

			float opportunitiesClosedPerHour = Mathf.Clamp(opportunitiesClosedPotentialPerHour, 0, GetTotalProductDemandCreatedPerHour());

			return opportunitiesClosedPotentialPerHour;
		}

		public float GetTotalOrdersEnteredPerHour()
		{
			float ordersEnteredPotential = 0;
			for (int i = 0; i < _characters.Count; i++)
			{
				ordersEnteredPotential += _characters[i].GetOrderEnterMaxPerHour();
			}
			return Mathf.Clamp(ordersEnteredPotential, 0, GetOrdersCreatedPerHour());
		}

		public float GetGrossProfitMinusPersonnelCostsPerHour()
        {
            float ordersEntered = GetTotalOrdersEnteredPerHour(); //TODO: change to shipments per hour later.
            return (GetProductProfitPerHour() * ordersEntered) - GetPersonnelCostsPerHour();
        }

        public float GetOrdersCreatedPerHour()
        {
            return Mathf.Clamp(
				GetTotalOpportunitiesClosedPerHour(), 
				0, 
				GetTotalProductDemandCreatedPerHour()
			);
        }

        public float GetTotalProductDemandCreatedPerHour()
		{
			float productDemandCreated = 0;
			for (int i = 0; i < _characters.Count; i++)
			{
				productDemandCreated += _characters[i].GetProductDemandCreatedPerHour();
			}

			return productDemandCreated;
		}

		private float CalculateProfit(IProductConfig productConfig)
		{
			var totalRevenue = productConfig.GetPricePerUnit(); 
			var totalCost = productConfig.GetCostPerUnit();
			return totalRevenue - totalCost;
		}
	}
}
