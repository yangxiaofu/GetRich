using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Game.Finances;
using Game.Objects.Characters;
using Game.Objects.Products;

namespace Game.Core.Test{
	[TestFixtureAttribute]
	public class BusinessStatisticsTests{

		[CategoryAttribute("Business Statistics")]
		[TestAttribute]
		public void T01aUpdateMarketDemandStatistics_ReturnsCharacterMarketDemandCreation()
		{
			float characterMarketDemandCreation = 5f;

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

			var processor = new BusinessStatisticsProcessor(bsArgs);
			var filter = new BusinessStatisticsFilter();
			BusinessStatisticsProcessor.BusinessStatisticsHandler handler = 
			filter.UpdateMarketDemandStatistics;

			processor.Process(handler);

			Assert.AreEqual(characterMarketDemandCreation, processor.args.businessStatistics.GetMarketDemandCreatedByHour().LastOrDefault());

		}

		[TestAttribute]
		public void T01bUpdateMarketDemandStatistics_ReturnsCharacterMarketDemandCreation()
		{
			float characterMarketDemandCreation = 5f;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(0, characterMarketDemandCreation, 0);
			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);

			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bs = new BusinessStatisticsStub();
			var fsDummy = new FinanceSystemStub();
			var bsArgs = new BusinessStatisticsArgs(characters, products, bs, fsDummy);

			var processor = new BusinessStatisticsProcessor(bsArgs);
			var filter = new BusinessStatisticsFilter();
			BusinessStatisticsProcessor.BusinessStatisticsHandler handler = 
			filter.UpdateMarketDemandStatistics;

			processor.Process(handler);

			Assert.AreEqual(characterMarketDemandCreation * 4, processor.args.businessStatistics.GetMarketDemandCreatedByHour().LastOrDefault());

		}

		[TestAttribute]
		public void T02aUpdateClosedOrders_ReturnsOrdersEntered()
		{
			float characterMarketDemandCreation = 5f;
			float characterMarketDemandConverted = 3;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(
				1, 
				characterMarketDemandCreation, 
				characterMarketDemandConverted
			);

			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);

			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bs = new BusinessStatisticsStub();
			bs.marketDemandCreatedAcummulated = new List<float>(){4, 10};
			var fsDummy = new FinanceSystemStub();
			var bsArgs = new BusinessStatisticsArgs(characters, products, bs, fsDummy);

			var processor = new BusinessStatisticsProcessor(bsArgs);
			var filter = new BusinessStatisticsFilter();
			BusinessStatisticsProcessor.BusinessStatisticsHandler handler = 
			filter.UpdateClosedOrders;

			processor.Process(handler);

			Assert.AreEqual(characterMarketDemandConverted, processor.args.businessStatistics.GetMarketDemandConvertedByHour().LastOrDefault());

		}

		[TestAttribute]
		public void T02bUpdateClosedOrders_ReturnsOrdersEntered()
		{
			float characterMarketDemandCreation = 3f;
			float characterMarketDemandConverted = 3f;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(
				1, 
				characterMarketDemandCreation, 
				characterMarketDemandConverted
			);

			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);

			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bs = new BusinessStatisticsStub();
			bs.marketDemandCreatedAcummulated = new List<float>(){20, 10};
			var fsDummy = new FinanceSystemStub();
			var bsArgs = new BusinessStatisticsArgs(characters, products, bs, fsDummy);

			var processor = new BusinessStatisticsProcessor(bsArgs);
			var filter = new BusinessStatisticsFilter();
			BusinessStatisticsProcessor.BusinessStatisticsHandler handler = 
			filter.UpdateClosedOrders;

			processor.Process(handler);

			Assert.AreEqual(characterMarketDemandConverted * 6, processor.args.businessStatistics.GetMarketDemandConvertedByHour().LastOrDefault());

		}

		[TestAttribute]
		public void T02cUpdateClosedOrders_ReturnsNoMoreThanMarketCreated()
		{
			float characterMarketDemandCreation = 3f;
			float characterMarketDemandConverted = 3f;

			var characters = new List<ICharacter>();
			var characterStubArgs = new CharacterStubArgs(
				1, 
				characterMarketDemandCreation, 
				characterMarketDemandConverted
			);

			var characterStub = new CharacterStub(characterStubArgs);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);
			characters.Add(characterStub);

			List<IProductConfig> products = new List<IProductConfig>();
			var productStub = new ProductConfigStub(0, 0);
			products.Add(productStub);

			var bs = new BusinessStatisticsStub();
			bs.marketDemandCreatedAcummulated = new List<float>(){10, 10};
			var fsDummy = new FinanceSystemStub();
			var bsArgs = new BusinessStatisticsArgs(characters, products, bs, fsDummy);

			var processor = new BusinessStatisticsProcessor(bsArgs);
			var filter = new BusinessStatisticsFilter();
			BusinessStatisticsProcessor.BusinessStatisticsHandler handler = 
			filter.UpdateClosedOrders;

			processor.Process(handler);

			Assert.AreEqual(10, processor.args.businessStatistics.GetMarketDemandConvertedByHour().LastOrDefault());

		}
	}
}


