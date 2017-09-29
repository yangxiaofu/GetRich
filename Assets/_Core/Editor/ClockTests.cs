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
	}	

}
