using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Products;
using Game.Objects.Characters;
using NUnit.Framework;

namespace Game.Finances.Test{
	[TestFixtureAttribute]
	public class FinanceCalculatorTests{

		[TestAttribute]
		public void T01GetTotalProductProfitPerHour_Returns50()
		{
			float productPrice = 100;
			float productCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);

			float ordersEnteredPerHour = 5;

			List<ICharacter> characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(10, 10, 10, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);
			characters.Add(character);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetProductProfitPerHour();
			
			Assert.AreEqual(50, result);
		}

		[TestAttribute]
		public void T02GetTotalProductProfit_Returns75(){
			float productPrice = 100;
			float productCost = 50;

			float productPrice2 = 50;
			float productCost2 = 25;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			var product2 = new ProductConfigStub(productPrice2, productCost2);
			products.Add(product);
			products.Add(product2);

			List<ICharacter> characters = new List<ICharacter>();
			float ordersEnteredPerHour = 5;
			var characterStubArgs = new CharacterStubArgs(10, 10, 10, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);
			characters.Add(character);
			characters.Add(character);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetProductProfitPerHour();

			Assert.AreEqual(75, result);
		}

		[TestAttribute]
		public void T03aGetTotalOpportunitiesClosedPerHour_ReturnsLessProductDemand(){
			
			float characterCostPerHour = 10;
			float opportunitesClosedPerHour = 5;
			float productDemandCreatedPerHour = 20;
			float ordersEnteredPerHour = 5;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, opportunitesClosedPerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			float AnyProductPrice = 100;
			float AnyProductCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(AnyProductPrice, AnyProductCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalOpportunitiesClosedPerHour();

			Assert.AreEqual(opportunitesClosedPerHour, result);
		}

		[TestAttribute]
		public void T03bGetTotalOpportunitiesClosedPerHour_ReturnsNoMoreThanDemandCreated(){
			
			float characterCostPerHour = 10;
			float opportunitesClosedPerHour = 3;
			float productDemandCreatedPerHour = 5;
			float ordersEnteredPerHour = 5;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, opportunitesClosedPerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			float AnyProductPrice = 100;
			float AnyProductCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(AnyProductPrice, AnyProductCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalOpportunitiesClosedPerHour();

			Assert.Less(result, productDemandCreatedPerHour);
		}

		[TestAttribute]
		public void T04GetPersonnelCostsPerHour_ReturnsFive(){
			
			float characterCostPerHour = 10;
			float productSalesPerHour = 5;
			float productDemandCreatedPerHour = 10;
			float ordersEnteredPerHour = 5;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, productSalesPerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);


			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);
			characters.Add(character);

			float AnyProductPrice = 100;
			float AnyProductCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(AnyProductPrice, AnyProductCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetPersonnelCostsPerHour();

			Assert.AreEqual(20, result);
		}

		[TestAttribute]
		public void T05GetGrossProfitMinusPersonnelCostsPerHour_Returns240Profit(){
			
			float characterCostPerHour = 10;
			float productSalesPerHour = 5;
			float productDemandCreatedPerHour = 10;
			float ordersEnteredPerHour = 5;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, productSalesPerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			float AnyProductPrice = 100;
			float AnyProductCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(AnyProductPrice, AnyProductCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetGrossProfitMinusPersonnelCostsPerHour();

			Assert.AreEqual(240, result);
		}

		[TestAttribute]
		public void T06GetTotalProductDemandCreatedPerHour_Returns10(){
			
			float characterCostPerHour = 10;
			float productSalesPerHour = 5;
			float productDemandCreatedPerHour = 10;
			float ordersEnteredPerHour = 5;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, productSalesPerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			float AnyProductPrice = 100;
			float AnyProductCost = 50;

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(AnyProductPrice, AnyProductCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalProductDemandCreatedPerHour();

			Assert.AreEqual(productDemandCreatedPerHour, result);
		}

		[TestAttribute]
		public void T07GetProductProfitPerHour_Returns100(){
			
			float characterCostPerHour = 10;
			float productSalesClosurePerHour = 5;
			float productDemandCreatedPerHour = 2;
			float ordersEnteredPerHour = 5;

			float productPrice = 100;
			float productCost = 50;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, productSalesClosurePerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetProductProfitPerHour();

			Assert.AreEqual(100, result);
		}


		[TestAttribute]
		public void T08GetProductProfitMinusPersonnelCostsPerHour_Returns90(){
			
			float characterCostPerHour = 10;
			float productSalesClosurePerHour = 5;
			float productDemandCreatedPerHour = 2;
			float ordersEnteredPerHour = 5;

			float productPrice = 100;
			float productCost = 50;

			var characterStubArgs = new CharacterStubArgs(characterCostPerHour, productSalesClosurePerHour, productDemandCreatedPerHour, ordersEnteredPerHour);
			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetGrossProfitMinusPersonnelCostsPerHour();

			Assert.AreEqual(90, result);
		}

		[TestAttribute]
		public void T09aGetOrderEnteredPotential_ReturnsLessThanOpportunitiesClosed(){
			
			float characterCostPerHour = 10;
			float productDemandCreatedPerHour = 20;
			float opportunitiesClosedPerHour = 10;
			float ordersEnteredPerHour = 5;

			float productPrice = 100;
			float productCost = 50;

			var characterStubArgs = new CharacterStubArgs(
				characterCostPerHour, 
				opportunitiesClosedPerHour, 
				productDemandCreatedPerHour, 
				ordersEnteredPerHour
			);

			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalOrdersEnteredPerHour();

			Assert.Less(result, opportunitiesClosedPerHour);
		}

		[TestAttribute]
		public void T09bGetOrderEnteredPerHour_ReturnsSameAsOpportunitiesClosed(){
			
			float characterCostPerHour = 10;
			float productDemandCreatedPerHour = 10;
			float opportunitiesClosedPerHour = 3;
			float ordersEnteredPerHour = 5;

			float productPrice = 100;
			float productCost = 50;

			var characterStubArgs = new CharacterStubArgs(
				characterCostPerHour, 
				opportunitiesClosedPerHour, 
				productDemandCreatedPerHour, 
				ordersEnteredPerHour
			);

			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalOrdersEnteredPerHour();

			Assert.AreEqual(opportunitiesClosedPerHour, result);
		}

		[TestAttribute]
		public void T10GetTotalProductDemand_ReturnsProductDemandTimesProductPrice(){
			
			float characterCostPerHour = 0;
			float productDemandCreatedPerHour = 5;
			float opportunitiesClosedPerHour = 0;
			float ordersEnteredPerHour = 0;

			float productPrice = 60;
			float productCost = 30;

			var characterStubArgs = new CharacterStubArgs(
				characterCostPerHour, 
				opportunitiesClosedPerHour, 
				productDemandCreatedPerHour, 
				ordersEnteredPerHour
			);

			var character = new CharacterStub(characterStubArgs);

			List<ICharacter> characters = new List<ICharacter>();
			characters.Add(character);

			List<IProductConfig> products = new List<IProductConfig>();
			var product = new ProductConfigStub(productPrice, productCost);
			products.Add(product);

			var args = new OrderCalculatorArgs(products, characters);
			var sut = new OrderCalculator(args);
			var result = sut.GetTotalProductDemandCreatedPerHour();

			Assert.AreEqual(productDemandCreatedPerHour * productPrice, result);
		}
	}
}

