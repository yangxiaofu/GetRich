using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Core;

namespace Game.UI{
	public class TaskList : List
    {
		void Start()
        {
			DestroyChildrenIn(this.transform);
            SetupVariables();
            InstantiateTasksUIButtons(_taskManager.tasks);
        }	  
    }
}

