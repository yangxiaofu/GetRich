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
	public class BusinessLogicSystem : MonoBehaviour {
		[SerializeField] List<float> _marketDemandCreatedByHour = new List<float>();
		[SerializeField] List<float> _marketDemandCreatedAcummulated = new List<float>();
		[SerializeField] List<float> _marketDemandClosedByHour = new List<float>();
		[SerializeField] List<float> _personnelCostsByHour = new List<float>();
		[SerializeField] List<float> _profitPerHour = new List<float>();
		
		CharacterParent _characterParent;
		Clock _clock;
		ProductSystem _productSystem;
		FinanceSystem _financeSystem;

		void Start()
		{
			_marketDemandCreatedByHour.Add(0);
			_marketDemandCreatedAcummulated.Add(0);
			_marketDemandClosedByHour.Add(0);
			_personnelCostsByHour.Add(0);

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
            var characters = GetCharacters().Cast<ICharacter>().ToList();
            UpdateMarketDemandStatistics(characters);
            float ordersClosed = UpdateClosedOrders(characters);
            UpdatedAccumulatedOrders(ordersClosed);
			UpdateProductProfit(ordersClosed);
			UpdatePersonnelCosts(characters);
			
        }

        private void UpdateProductProfit(float ordersClosed)
        {
			//TODO: change this for contract manfuacturer ship time later. 
            var products = _productSystem.GetProducts();
			var profit = products[0].GetPricePerUnit() - products[0].GetCostPerUnit();
			var totalProfit = ordersClosed * profit;
			_profitPerHour.Add(totalProfit);
			_financeSystem.AddCash(totalProfit);
        }

        private void UpdatePersonnelCosts(List<ICharacter> characters)
        {
			float totalPersonnelCosts = 0;
            for(int i = 0; i < characters.Count; i++)
			{
				totalPersonnelCosts += characters[i].GetCostPerHour();
			}
			_financeSystem.UseCash(totalPersonnelCosts);
			_personnelCostsByHour.Add(totalPersonnelCosts);
        }

        private void UpdatedAccumulatedOrders(float ordersClosed)
        {
            var originalMarketDemandAccumulated = _marketDemandCreatedAcummulated[_marketDemandCreatedAcummulated.Count - 1];
            _marketDemandCreatedAcummulated[_marketDemandCreatedAcummulated.Count - 1] = originalMarketDemandAccumulated - ordersClosed;
        }

        private float UpdateClosedOrders(List<ICharacter> characters)
        {
            float totalOpportunitiesClosedPotential = GetTotalPotentialOpporutinitiesClosed(characters);

            var totalDemand = _marketDemandCreatedAcummulated[_marketDemandCreatedAcummulated.Count - 2];
            var ordersClosed = Mathf.Min(totalDemand, totalOpportunitiesClosedPotential);
            _marketDemandClosedByHour.Add(ordersClosed);
            return ordersClosed;
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

        private void UpdateMarketDemandStatistics(List<ICharacter> characters)
        {
			var products = _productSystem.GetProducts();

            for (int i = 0; i < products.Count; i++)
            {
                var marketDemand = new MarketDemand(products[i], characters);
                UpdateMarketDemandCreatedByHour(marketDemand);
                UpdateMarketDemandAccumulated(marketDemand);
            }
        }

        private List<Character> GetCharacters()
		{
			List<Character> characters = new List<Character>();

			foreach(Transform child in _characterParent.transform)
			{
				characters.Add(child.gameObject.GetComponent<Character>());
			}

			return characters;
		}

		public void UpdateMarketDemandCreatedByHour(MarketDemand marketDemand)
        {
            _marketDemandCreatedByHour.Add(marketDemand.GetMarketDemandQuantityPerHour());		
        }

        private void UpdateMarketDemandAccumulated(MarketDemand marketDemand)
        {
            var lastValue = _marketDemandCreatedAcummulated[_marketDemandCreatedAcummulated.Count - 1];
			var total = lastValue + marketDemand.GetMarketDemandQuantityPerHour();
			_marketDemandCreatedAcummulated.Add(total);
        }
    }
}

