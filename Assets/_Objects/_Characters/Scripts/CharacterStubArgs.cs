using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Characters{
	 public struct CharacterStubArgs{
        public float costPerHour;
        public float productDemandCreatedPerHour;
        public float ordersEnteredPerHour;

        public CharacterStubArgs(float costPerHour, float productDemandCreatedPerHour, float ordersEnteredPerHour){
            this.costPerHour = costPerHour;
            this.productDemandCreatedPerHour = productDemandCreatedPerHour;
            this.ordersEnteredPerHour = ordersEnteredPerHour;
        }
    }
}
