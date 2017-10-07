using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
	public interface ICharacter{
		float GetCostPerHour();
		float GetProductDemandCreatedPerHour();
		float GetOrderEnterMaxPerHour();
	}
}
