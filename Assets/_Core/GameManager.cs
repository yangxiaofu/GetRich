using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Game.Objects.Products;
using Game.Objects.Characters;
using Game.Finances;
using System;

namespace Game.Core{
	public class GameManager : MonoBehaviour {
		Clock _clock;
		ProductSystem _productSystem;
		CharacterParent _characterParent;
		OrdersParent _ordersParent;
		FinanceSystem _financeSystem;

		//TODO: Remove SerializeField after testing.
		[SerializeField] float _totalProductDemand = 0;
		[SerializeField] float _totalOpportunitiesClosed = 0;
		[SerializeField] float _totalOrdersEntered = 0;

		void Start()
		{
			_clock = GetComponent<Clock>();
			_clock.OnTimeForUpdate += UpdateTasks;

			_productSystem = GetComponent<ProductSystem>();
			Assert.IsNotNull(_productSystem);

			_characterParent = FindObjectOfType<CharacterParent>();
			Assert.IsNotNull(_characterParent);

			_ordersParent = FindObjectOfType<OrdersParent>();
			Assert.IsNotNull(_ordersParent);

			_financeSystem = GetComponent<FinanceSystem>();
			Assert.IsNotNull(_financeSystem);
		}

		void UpdateTasks()
        {
			var products = _productSystem.GetProducts();
            var characters = GetCharacters();

            var args = new OrderCalculatorArgs(
                products.Cast<IProductConfig>().ToList(),
                characters.Cast<ICharacter>().ToList()
            );

            var orderCalculator = new OrderCalculator(args);
			//Generate Demand. 
			_totalProductDemand += orderCalculator.GetTotalProductDemandCreatedPerHour();
			//Close Orders.
			_totalOpportunitiesClosed += orderCalculator.GetTotalOpportunitiesClosedPerHour();
			//Enter Orders
			_totalOrdersEntered += orderCalculator.GetTotalOrdersEnteredPerHour();

			var ordersEnteredPerHour = orderCalculator.GetTotalOrdersEnteredPerHour();

            for (int i = 0; i < ordersEnteredPerHour; i++)
            {
                var orderObject = new GameObject("Order");
                orderObject.AddComponent<Order>();
                orderObject.transform.SetParent(_ordersParent.transform);
            }
			
            _financeSystem.AddCash(orderCalculator.GetGrossProfitMinusPersonnelCostsPerHour());
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
    }
}

