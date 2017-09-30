using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
	public class DayList : List
	{
		DayManager _dayManager;
		void Start()
		{
			DestroyChildrenIn(this.transform);
			SetupVariables();
			
			_dayManager = GameObject.FindObjectOfType<DayManager>();
			InstantiateTasksUIButtons(_dayManager.GetTasksForTheDay());
		}
    }
}
