using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class ClockFake{
		public bool endOfDayTriggered = false;
		public void RegisterToClock()
		{
			var clock = GameObject.FindObjectOfType<Clock>();
			clock.OnEndOfDay += OnEndOfDay;
		}

		private void OnEndOfDay()
		{
			endOfDayTriggered = true;
		}
	}

}
