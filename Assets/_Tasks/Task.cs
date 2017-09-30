using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Core{
	[CreateAssetMenuAttribute(menuName = "Game/Task")]
	public class Task : ScriptableObject, ITask {
		[SerializeField] int _hourConsumption = 1;
		[SerializeField] GameObject _ui;
		public int GetHourConsumption()
		{
			return _hourConsumption;
		}
		public GameObject GetUIPanel()
		{
			return _ui;
		}
		
	}

}
