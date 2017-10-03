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
		[SerializeField] int _startHour = 8;
		public int startHour{
			get{return _startHour;}
		}
		[SerializeField] int _endHour = 17;
		public bool openHours{
			get{return _hour >= _startHour && _hour <= _endHour;}
		}

		public delegate void EndOfDay();
		public event EndOfDay OnEndOfDay;

		public delegate void StartOfDay();
		public event EndOfDay OnStartOfDay;

		public delegate void TimeForUpdate();
		public event TimeForUpdate OnTimeForUpdate;

		void Start()
        {
            _hour = _startHour;
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

		private void UpdateHourHand(float minute)
        {
            if (minute >= _minutesInAnHour)
			{
				Debug.Log(1);
				_minute = 0;
				_hour += 1;

				NotifyTimeUpdateObservers();

				if (_hour >= 24){
					_hour = 0;
				} 
			}
        }

        private void NotifyTimeUpdateObservers()
        {
            if (OnTimeForUpdate != null) OnTimeForUpdate();
        }

        public void AdvanceClockBy(int hours)
		{
			_hour += hours;
			
			if (_hour == 24)
			{
				_hour = 0;
			}

			if (_hour == 0)
			{
				GetComponent<DayManager>().AdvanceDay();
			}

			if (_hour >= _endHour) 
			{
				if (OnEndOfDay != null){
				 	OnEndOfDay();
				}
			}

			if (_hour >= _startHour - 1)
			{
				if (OnStartOfDay != null) OnStartOfDay();
			}
		}

		public void ResetClock()
		{
			_hour = _startHour;
		}

	}

}
