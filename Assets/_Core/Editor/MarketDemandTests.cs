using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Game.Objects.Characters;
using Game.Objects.Products;
using Game.Core;
using Game.Finances;

namespace Game.Core.Tests{
	[CategoryAttribute("Market Demand Tests")]
	[TestFixtureAttribute]
	public class MarketDemandTests {
		[TestAttribute]
		public void T01aGetMarketDemandQuantityPerHour_ReturnCharacterMarketCreatedOnePerson()
		{
			int characterMarketDemandCreation = 5;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(0, characterMarketDemandCreation, 0);
			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);

			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bs = new BusinessStatisticsStub();
			var fsDummy = new FinanceSystemStub();
			var bsArgs = new BusinessStatisticsArgs(characters, products, bs, fsDummy);

			var marketDemand = new MarketDemand(bsArgs);
			var result = marketDemand.GetMarketDemandQuantityPerHour();

			Assert.AreEqual(characterMarketDemandCreation, result);
		}


		[TestAttribute]
		public void T01bGetMarketDemandQuantityPerHour_ReturnCharacterMarketCreatedTwoPerson()
		{
			int characterMarketDemandCreation = 5;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(0, characterMarketDemandCreation, 0);
			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);
			characters.Add(characterStub);
			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bsStub = new BusinessStatisticsStub();
			
			var bs = new BusinessStatisticsArgs(characters, products, bsStub, new FinanceSystemStub());
			
			var marketDemand = new MarketDemand(bs);
			var result = marketDemand.GetMarketDemandQuantityPerHour();

			Assert.AreEqual(characterMarketDemandCreation * 2, result);
		}
	}
}

