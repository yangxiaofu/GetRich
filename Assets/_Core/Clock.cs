using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System;

namespace Game.Core{
	[RequireComponent(typeof(DayManager))]
	public class Clock : MonoBehaviour {
		[SerializeField] int _startTimeOfDay = 8;
		public int startTimeOfDay{
			get{return _startTimeOfDay;}
		}
		[SerializeField] int _endTimeOfDay = 17;
		int _currentTimeOfDay = 8;
		public int currentTimeOfDay{
			get{return _currentTimeOfDay;}
		}

		public delegate void EndOfDay();
		public event EndOfDay OnEndOfDay;

		void Start()
        {
            _currentTimeOfDay = _startTimeOfDay;
        }

        public void AdvanceClock(int hours)
		{
			_currentTimeOfDay += hours;

			if (_currentTimeOfDay < _endTimeOfDay) return;
		
			if (OnEndOfDay != null) OnEndOfDay();

			GetComponent<DayManager>().AdvanceDay();
			ResetClock();
		}

		public void ResetClock()
		{
			_currentTimeOfDay = _startTimeOfDay;
		}

	}

}
