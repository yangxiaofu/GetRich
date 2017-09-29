using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Game.Core{
	public class Clock : MonoBehaviour {
		[SerializeField] int _startTimeOfDay = 8;
		public int startTimeOfDay{
			get{return _startTimeOfDay;}
		}
		[SerializeField] int _endTimeOfDay = 5;
		int _currentTimeOfDay = 8;
		public int currentTimeOfDay{
			get{return _currentTimeOfDay;}
		}
		
		void Start(){
			_currentTimeOfDay = _startTimeOfDay;
		}

		public void AdvanceClock(int hours)
		{
			_currentTimeOfDay += hours;
		}

		public void ResetClock()
		{
			_currentTimeOfDay = _startTimeOfDay;
		}

	}

}
