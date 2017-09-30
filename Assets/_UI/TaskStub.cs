using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
    public class TaskStub : ITask
    {
		int _hourConsumption = 1;

		public TaskStub(int hourConsumption)
		{
			_hourConsumption = hourConsumption;
		}

        public int GetHourConsumption()
        {
            return _hourConsumption;
        }
    }

}
