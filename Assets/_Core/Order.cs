using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class Order : MonoBehaviour {
		[SerializeField] bool _orderedFilled = false;
		public bool filled{
			get{return _orderedFilled;}
			set{_orderedFilled = value;}
		}

	}

}
