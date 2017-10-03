using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Game.Core	;

namespace Game.Core.Tests{
	[TestFixtureAttribute]
	public class ClockTests{
		Clock _clock;

		[SetUpAttribute]
		public void Setup()
		{
			_clock = GameObject.FindObjectOfType<Clock>();
		}

		[TestAttribute]
		public void T01AdvanceClock_ReturnsClockAdvancedByTwo()
		{
			int hoursToAdvance = 2;
			int hour = 8;
			int AnyMinute = 0;

			var time = new Core.Time(hour, AnyMinute);

			_clock.SetupTime(time);
			_clock.AdvanceClockBy(hoursToAdvance);

			Assert.AreEqual(
				hour + hoursToAdvance, 
				_clock.hour
			);
		}

		[TestAttribute]
		public void T02ResetClock_ResetsClockAtStartTime()
		{
			int anyNumberOtherThanZero = 5;
			_clock.AdvanceClockBy(anyNumberOtherThanZero);
			_clock.ResetClock();
			Assert.AreEqual(_clock.startHour, _clock.hour);
		}

		[TestAttribute]
		public void T03AdvanceClock_TriggersOnEndOfDayObservers()
		{
			int anyNumberOtherThanNine = 10;
			var clockFake = new ClockFake();
			clockFake.RegisterToClock();
			_clock.AdvanceClockBy(anyNumberOtherThanNine);

			Assert.IsTrue(clockFake.endOfDayTriggered);
		}

		[TestAttribute]
		public void T04AdvanceClock_DoesNotTriggerEndOfDayObservers()
		{
			int anyNumberOtherThanNine = 2;
			var clockFake = new ClockFake();
			clockFake.RegisterToClock();
			_clock.ResetClock();
			_clock.AdvanceClockBy(anyNumberOtherThanNine);

			Assert.IsFalse(clockFake.endOfDayTriggered);
		}

		[TestAttribute]
		public void T05AdvanceClock_DayAdvancesADay()
		{
			int oneHour = 1;

			_clock.SetupTime(new Core.Time(23, 0));

			_clock.GetComponent<DayManager>().ResetDayManager();

			_clock.AdvanceClockBy(oneHour);

			var sut = _clock.GetComponent<DayManager>();

			Assert.AreEqual(1, sut.currentDay);
		}

		[TestAttribute]
		public void T06UpdateHourHand_HourAdvancesByOne(){
			int hour = 5;
			int minuteAtSixty = 60;

			var time = new Core.Time(hour, minuteAtSixty);
			_clock.SetupTime(time);
			Assert.AreEqual(hour + 1, _clock.hour);
		}

		[TestAttribute]
		public void T07IsAM_ReturnsAM()
		{
			int hour = 8;
			int AnyMinute = 60;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.AreEqual(true, _clock.isAM);
		}

		[TestAttribute]
		public void T08isAM_ReturnsPM()
		{
			int hour = 12;
			int AnyMinute = 60;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.AreEqual(false, _clock.isAM);
		}

		[TestAttribute]
		public void T09UpdateHourHand_ReturnsZero()
		{
			int hour = 24;
			int AnyMinute = 60;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.AreEqual(0, _clock.hour);
		}

		[TestAttribute]
		public void T10UpdateHourHand_ReturnsOne()
		{
			int hour = 0;
			int AnyMinute = 60;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.AreEqual(1, _clock.hour);
		}

		[TestAttribute]
		public void T11UpdateHourHand_ReturnsTrueOpenHours()
		{
			int hour = 8;
			int AnyMinute = 0;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.IsTrue(_clock.openHours);
		}

		[TestAttribute]
		public void T12UpdateHourHand_ReturnsFalseOpenHours()
		{
			int hour = 7;
			int AnyMinute = 0;
			var time = new Core.Time(hour, AnyMinute);
			_clock.SetupTime(time);
			Assert.IsFalse(_clock.openHours);
		}
	}	

}
