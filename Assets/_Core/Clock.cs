using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System;

namespace Game.Core{
	[RequireComponent(typeof(DayManager))]
	public class Clock : MonoBehaviour {

		[HeaderAttribute("Timer")]
		[SerializeField] int _hour = 0;
		public int hour {get{return _hour;}}
		[SerializeField] float _minutes = 0;
		public int minute{get{return (int)_minutes;}}
		public bool isAM{
			get{
				return _hour < 12;
			}
		}

		[SerializeField] float _minutesPassedPerSecond = 1;
		float _minutesInAnHour = 60;

		[HeaderAttribute("Work Day Variables")]
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
			_hour = _startTimeOfDay;
        }

		void Update()
		{
			_minutes += Time.deltaTime * _minutesPassedPerSecond;
			UpdateHourHand(_minutes);
		}

		///<summary>Used for Unit Testing</summary>
		public void SetupMinutes(float minutes, int hour) 
		{ 
			_hour = hour;
			UpdateHourHand(minutes);
		}

		private void UpdateHourHand(float minutes)
		{
			if (minutes < _minutesInAnHour) return;
			
			_hour += 1;

			if (_hour >= 24) _hour = 0;

			minutes = 0;
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
