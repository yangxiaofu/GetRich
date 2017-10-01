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
			
			_clock.AdvanceClock(hoursToAdvance);

			Assert.AreEqual(
				_clock.startTimeOfDay + hoursToAdvance, 
				_clock.currentTimeOfDay
			);
		}

		[TestAttribute]
		public void T02ResetClock_ResetsClockAtStartTime()
		{
			int anyNumberOtherThanZero = 5;
			_clock.AdvanceClock(anyNumberOtherThanZero);
			_clock.ResetClock();
			Assert.AreEqual(_clock.startTimeOfDay, _clock.currentTimeOfDay);
		}

		[TestAttribute]
		public void T03AdvanceClock_TriggersOnEndOfDayObservers()
		{
			int anyNumberOtherThanNine = 10;
			var clockFake = new ClockFake();
			clockFake.RegisterToClock();
			_clock.AdvanceClock(anyNumberOtherThanNine);

			Assert.IsTrue(clockFake.endOfDayTriggered);
		}

		[TestAttribute]
		public void T04AdvanceClock_DoesNotTriggerEndOfDayObservers()
		{
			int anyNumberOtherThanNine = 2;
			var clockFake = new ClockFake();
			clockFake.RegisterToClock();
			_clock.ResetClock();
			_clock.AdvanceClock(anyNumberOtherThanNine);

			Assert.IsFalse(clockFake.endOfDayTriggered);
		}

		[TestAttribute]
		public void T05AdvanceClock_DayAdvancesADay()
		{
			
			int anyNumberGreaterThanNine = 10;
			
			_clock.GetComponent<DayManager>().ResetDayManager();
			_clock.AdvanceClock(anyNumberGreaterThanNine);
			var sut = _clock.GetComponent<DayManager>();
			Assert.AreEqual(1, sut.currentDay);
		}

		[TestAttribute]
		public void T06UpdateHourHand_ReturnsGreaterThan12(){
			_clock.SetupMinutes(60, 5);
			Assert.AreEqual(6, _clock.hour);
		}

		[TestAttribute]
		public void T07IsAM_ReturnsAM()
		{
			_clock.SetupMinutes(60, 8);
			Assert.AreEqual(true, _clock.isAM);
		}

		[TestAttribute]
		public void T08isAM_ReturnsPM()
		{
			_clock.SetupMinutes(60, 12);
			Assert.AreEqual(false, _clock.isAM);
		}

		[TestAttribute]
		public void T09UpdateHourHand_ReturnsZero()
		{
			_clock.SetupMinutes(60, 24);
			Assert.AreEqual(0, _clock.hour);
		}

		[TestAttribute]
		public void T10UpdateHourHand_ReturnsOne()
		{
			_clock.SetupMinutes(60, 0);
			Assert.AreEqual(1, _clock.hour);
		}
	}	

}
