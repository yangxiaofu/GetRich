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

namespace Game.Core{
	public class BusinessLogicSystem : MonoBehaviour {
        [SerializeField] BusinessStatistics _businessStatistics;
		CharacterParent _characterParent;
		Clock _clock;
		ProductSystem _productSystem;
		FinanceSystemBehaviour _financeSystem;

		void Start()
        {
            _businessStatistics.Clear(); //remove later when the logic is complete. 
            InitializeBusinessStatistics();
            GetComponents();
            RegisterToNotifiers();
        }

        private void RegisterToNotifiers()
        {
            _clock.OnTimeForUpdate += UpdateTasks;
        }

        private void GetComponents()
        {
            _clock = GetComponent<Clock>();
            Assert.IsNotNull(_clock);

            _productSystem = GetComponent<ProductSystem>();
            Assert.IsNotNull(_productSystem);

            _characterParent = FindObjectOfType<CharacterParent>();
            Assert.IsNotNull(_characterParent);

            _financeSystem = GetComponent<FinanceSystemBehaviour>();
            Assert.IsNotNull(_financeSystem);
        }

        private void InitializeBusinessStatistics()
        {
            _businessStatistics.marketDemandCreatedByHour.Add(0);
            _businessStatistics.marketDemandCreatedAcummulated.Add(0);
            _businessStatistics.marketDemandClosedByHour.Add(0);
            _businessStatistics.personnelCostsByHour.Add(0);
            _businessStatistics.profitPerHour.Add(0);
        }

        private void UpdateTasks()
        {
            //Updates Market Demand.
            var characters = GetCharacters().Cast<ICharacter>().ToList();
            var products = _productSystem.GetProducts();
            
            var bsArgs = new BusinessStatisticsArgs(characters, products.Cast<IProductConfig>().ToList(), _businessStatistics, _financeSystem);

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

