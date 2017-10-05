using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Objects.Characters;
using Game.Objects.Products;
using Game.Finances;

namespace Game.Core{
	public class BusinessStatisticsArgs {
		[SerializeField] public List<IProductConfig> products;
		public List<ICharacter> characters;
		public IBusinessStatistics businessStatistics;
		public float ordersClosed;
		public IFinanceSystem financeSystem;
		public BusinessStatisticsArgs(List<ICharacter> characters, List<IProductConfig> products, IBusinessStatistics businessStatistics, IFinanceSystem financeSystem){
			this.characters = characters;
			this.products = products;
			this.businessStatistics = businessStatistics;
			this.financeSystem = financeSystem;
		}
	}
}

