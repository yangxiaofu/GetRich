using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public struct Time {
		public int hour;
		public int minute;
		public Time(int hour, int minute)
		{
			this.hour = hour;
			this.minute = minute;
		}
	}
}

