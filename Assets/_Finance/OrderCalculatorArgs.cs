using System.Collections.Generic;
using Game.Objects.Products;
using Game.Objects.Characters;

namespace Game.Finances
{
    public struct OrderCalculatorArgs{
		public List<IProductConfig> products;
		public List<ICharacter> characters;
		public OrderCalculatorArgs(List<IProductConfig> products, List<ICharacter> characters){
			this.products = products;
			this.characters = characters;
		}
	}
}
