using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;
using Game.Objects.Characters;
using Game.Objects.Products;
using Game.Finances;
using UnityEngine.Assertions;
using System;
using System.Linq;

namespace Game.Objects.Characters{
    public class BusinessStatisticsProcessor
    {
        public delegate void BusinessStatisticsHandler(BusinessStatisticsArgs args);
        BusinessStatisticsArgs _args;
        public BusinessStatisticsProcessor(BusinessStatisticsArgs args)
        {
            _args = args;
        }
        public void Process(BusinessStatisticsHandler statisticsHandler)
        {
            statisticsHandler(_args);
        }
    }

    public class BusinessStatisticsFilter
    {
        public void UpdateMarketDemandStatistics(BusinessStatisticsArgs args)
        {
            for (int i = 0; i < args.products.Count; i++)
            {
                //Adds to the existing market demand section.
                var marketDemand = new MarketDemand(args.products[i], args.characters, args.businessStatistics);
                args.businessStatistics.marketDemandCreatedByHour.Add(marketDemand.GetMarketDemandQuantityPerHour());		    
                
                var lastValue = args.businessStatistics.marketDemandCreatedAcummulated[args.businessStatistics.marketDemandCreatedAcummulated.Count - 1];
			    var total = lastValue + marketDemand.GetMarketDemandQuantityPerHour();
			    args.businessStatistics.marketDemandCreatedAcummulated.Add(total);
            }
        }

        public void UpdateClosedOrders(BusinessStatisticsArgs args)
        {
            float totalOpportunitiesClosedPotential = GetTotalPotentialOpporutinitiesClosed(args.characters);
            var totalDemand = args.businessStatistics.marketDemandCreatedAcummulated[args.businessStatistics.marketDemandCreatedAcummulated.Count - 2];
            var ordersClosed = Mathf.Min(totalDemand, totalOpportunitiesClosedPotential);
            args.businessStatistics.marketDemandClosedByHour.Add(ordersClosed);
            args.ordersClosed = ordersClosed;
        }

        private float GetTotalPotentialOpporutinitiesClosed(List<ICharacter> characters)
        {
            float totalOpportunitiesClosedPotential = 0;
            for (int i = 0; i < characters.Count; i++)
            {
                totalOpportunitiesClosedPotential += characters[i].GetOpportunitiesClosedPerHour();
            }

            return totalOpportunitiesClosedPotential;
        }

        public void UpdatedAccumulatedOrders(BusinessStatisticsArgs args)
        {
            var originalMarketDemandAccumulated = args.businessStatistics.marketDemandCreatedAcummulated[args.businessStatistics.marketDemandCreatedAcummulated.Count - 1];
            args.businessStatistics.marketDemandCreatedAcummulated[args.businessStatistics.marketDemandCreatedAcummulated.Count - 1] = originalMarketDemandAccumulated - args.ordersClosed;
        }

        public void UpdateProductProfit(BusinessStatisticsArgs args)
        {
			//TODO: change this for contract manfuacturer ship time later. 

			var profit = args.products[0].GetPricePerUnit() - args.products[0].GetCostPerUnit();
			var totalProfit = args.ordersClosed * profit;
			args.businessStatistics.profitPerHour.Add(totalProfit);
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
			args.businessStatistics.personnelCostsByHour.Add(totalPersonnelCosts);
        }
    }


	public class BusinessLogicSystem : MonoBehaviour {
        [SerializeField] BusinessStatistics _businessStatistics;
		CharacterParent _characterParent;
		Clock _clock;
		ProductSystem _productSystem;
		FinanceSystem _financeSystem;

		void Start()
		{
			_businessStatistics.marketDemandCreatedByHour.Add(0);
			_businessStatistics.marketDemandCreatedAcummulated.Add(0);
			_businessStatistics.marketDemandClosedByHour.Add(0);
			_businessStatistics.personnelCostsByHour.Add(0);

			_clock = GetComponent<Clock>();
			Assert.IsNotNull(_clock);

			_productSystem = GetComponent<ProductSystem>();
			Assert.IsNotNull(_productSystem);

			_characterParent = FindObjectOfType<CharacterParent>();
			Assert.IsNotNull(_characterParent);

			_financeSystem = GetComponent<FinanceSystem>();
			Assert.IsNotNull(_financeSystem);

			_clock.OnTimeForUpdate += UpdateTasks;
		}

        private void UpdateTasks()
        {
            //Updates Market Demand.
            var characters = GetCharacters().Cast<ICharacter>().ToList();
            var products = _productSystem.GetProducts();
            var bsArgs = new BusinessStatisticsArgs(characters, products, _businessStatistics, _financeSystem);

            var processor = new BusinessStatisticsProcessor(bsArgs);
            var filter = new BusinessStatisticsFilter();
            BusinessStatisticsProcessor.BusinessStatisticsHandler handler = filter.UpdateMarketDemandStatistics;

            handler += filter.UpdateClosedOrders;
            handler += filter.UpdatedAccumulatedOrders;
            handler += filter.UpdateProductProfit;
            handler += filter.UpdatePersonnelCosts;
            
            processor.Process(handler);			
        }

        private List<ICharacter> GetCharacters()
		{
			List<ICharacter> characters = new List<ICharacter>();

			foreach(Transform child in _characterParent.transform)
			{
				characters.Add(child.gameObject.GetComponent<Character>());
			}

			return characters;
		}

    }
}

