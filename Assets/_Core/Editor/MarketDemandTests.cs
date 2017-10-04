using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Game.Objects.Characters;
using Game.Objects.Products;
using Game.Core;

namespace Game.Core.Tests{
	[CategoryAttribute("Market Demand Tests")]
	[TestFixtureAttribute]
	public class MarketDemandTests {
		[TestAttribute]
		public void T01aGetMarketDemandQuantityPerHour_ReturnCharacterMarketCreatedOnePerson()
		{
			int characterMarketDemandCreation = 5;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(0, 0, characterMarketDemandCreation, 0);
			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);

			var productStub = new ProductConfigStub(0, 0);
			
			var marketDemand = new MarketDemand(productStub, characters);
			var result = marketDemand.GetMarketDemandQuantityPerHour();

			Assert.AreEqual(characterMarketDemandCreation, result);
		}


		[TestAttribute]
		public void T01bGetMarketDemandQuantityPerHour_ReturnCharacterMarketCreatedTwoPerson()
		{
			int characterMarketDemandCreation = 5;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(0, 0, characterMarketDemandCreation, 0);
			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);
			characters.Add(characterStub);

			var productStub = new ProductConfigStub(0, 0);
			
			var marketDemand = new MarketDemand(productStub, characters);
			var result = marketDemand.GetMarketDemandQuantityPerHour();

			Assert.AreEqual(characterMarketDemandCreation * 2, result);
		}

		[TestAttribute]
		public void T02aSetMarketDemandList_()
		{

		}

	}
}

