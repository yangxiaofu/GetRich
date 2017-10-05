using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;
using Game.Objects.Products;
using Game.Finances;

namespace Game.Core{
	public class BusinessStatisticsArgs {
		[SerializeField] public List<ProductConfig> products;
		public List<ICharacter> characters;
		public BusinessStatistics businessStatistics;
		public float ordersClosed;

		public FinanceSystem financeSystem;
		public BusinessStatisticsArgs(List<ICharacter> characters, List<ProductConfig> products, BusinessStatistics businessStatistics, FinanceSystem financeSystem){
			this.characters = characters;
			this.products = products;
			this.businessStatistics = businessStatistics;
			this.financeSystem = financeSystem;
		}
	}
}

