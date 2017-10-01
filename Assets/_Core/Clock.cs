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
		[SerializeField] float _minute = 0;
		public int minute{get{return (int)_minute;}}
		public bool isAM{get{return _hour < 12;}}
		
		[SerializeField] float _minutesPassedPerSecond = 1;
		float _minutesInAnHour = 60f;

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

		public bool openHours{
			get{return _hour >= _startTimeOfDay && _hour <= _endTimeOfDay;}
		}

		public delegate void EndOfDay();
		public event EndOfDay OnEndOfDay;

		public delegate void TimeForUpdate();
		public event TimeForUpdate OnTimeForUpdate;

		void Start()
        {
            _currentTimeOfDay = _startTimeOfDay;
			_hour = _startTimeOfDay;
        }

		void Update()
		{
			_minute += UnityEngine.Time.deltaTime * _minutesPassedPerSecond;
			UpdateHourHand(_minute);
		}

		///<summary>Used for Unit Testing</summary>
		public void SetupTime(Core.Time time) 
		{ 
			_hour = time.hour;
			_minute = time.minute;
			UpdateHourHand(minute);
		}

		private void UpdateHourHand(float minutes)
        {
            if (minutes < _minutesInAnHour) return;

            _minute = 0;
            _hour += 1;

            NotifyTimeUpdateObservers();

            if (_hour >= 24) _hour = 0;
        }

        private void NotifyTimeUpdateObservers()
        {
            if (OnTimeForUpdate != null) OnTimeForUpdate();
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
