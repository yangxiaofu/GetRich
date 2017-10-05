using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;

namespace Game.Core{
 public class BusinessStatisticsFilter
    {
        public void UpdateMarketDemandStatistics(BusinessStatisticsArgs args)
        {
            for (int i = 0; i < args.products.Count; i++)
            {
                //Adds to the existing market demand section.
                var marketDemand = new MarketDemand(args);
                args.businessStatistics.GetMarketDemandCreatedByHour().Add(marketDemand.GetMarketDemandQuantityPerHour());		    
                var lastValue = args.businessStatistics.GetMarketDemandCreatedAccumulated()[args.businessStatistics.GetMarketDemandCreatedAccumulated().Count - 1];
			    var total = lastValue + marketDemand.GetMarketDemandQuantityPerHour();
			    args.businessStatistics.GetMarketDemandCreatedAccumulated().Add(total);
            }
        }

        public void UpdateClosedOrders(BusinessStatisticsArgs args)
        {
            float totalOpportunitiesClosedPotential = GetTotalPotentialOpporutinitiesClosed(args.characters);
            var totalDemand = args.businessStatistics.GetMarketDemandCreatedAccumulated()[args.businessStatistics.GetMarketDemandCreatedAccumulated().Count - 2];
            var ordersClosed = Mathf.Min(totalDemand, totalOpportunitiesClosedPotential);
            args.businessStatistics.GetMarketDemandConvertedByHour().Add(ordersClosed);
            args.ordersClosed = ordersClosed;
        }

        private float GetTotalPotentialOpporutinitiesClosed(List<ICharacter> characters)
        {
            float totalOpportunitiesClosedPotential = 0;
            for (int i = 0; i < characters.Count; i++)
            {
                totalOpportunitiesClosedPotential += characters[i].GetOrderEnterMaxPerHour();
            }

            return totalOpportunitiesClosedPotential;
        }

        public void UpdatedAccumulatedOrders(BusinessStatisticsArgs args)
        {
            var originalMarketDemandAccumulated = args.businessStatistics.GetMarketDemandCreatedAccumulated()[args.businessStatistics.GetMarketDemandCreatedAccumulated().Count - 1];
            args.businessStatistics.GetMarketDemandCreatedAccumulated()[args.businessStatistics.GetMarketDemandCreatedAccumulated().Count - 1] = originalMarketDemandAccumulated - args.ordersClosed;
        }

        public void UpdateProductProfit(BusinessStatisticsArgs args)
        {
			//TODO: change this for contract manfuacturer ship time later. 

			var profit = args.products[0].GetPricePerUnit() - args.products[0].GetCostPerUnit();
			var totalProfit = args.ordersClosed * profit;
			args.businessStatistics.GetProfitPerHour().Add(totalProfit);
			args.financeSystem.AddCash(totalProfit);
        }

        public void UpdatePersonnelCosts(BusinessStatisticsArgs args)
        {
			float totalPersonnelCosts = 0;
            for(int i = 0; i < args.characters.Count; i++)
			{
				totalPersonnelCosts += args.characters[i].GetCostPerHour();
			}
			args.financeSystem.UseCash(totalPersonnelCosts);
			args.businessStatistics.GetPersonnelCostsByHour().Add(totalPersonnelCosts);
        }
    }
	}