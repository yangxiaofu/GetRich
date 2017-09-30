using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	[RequireComponent(typeof(Clock))]
	public class DayManager : MonoBehaviour {
		[SerializeField] List<Task> _tasksForTheDay = new List<Task>();
		public List<Task> GetTasksForTheDay(){
			return _tasksForTheDay;
		}
		[SerializeField] int _currentDay = 0;
		public int currentDay{
			get{return _currentDay;}
		}

		public void AdvanceDay()
		{
			_currentDay += 1;
		}

		public void ResetDayManager()
		{
			_currentDay = 0;
		}
	}

}
