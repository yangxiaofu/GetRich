using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class TaskManager : MonoBehaviour {
		[SerializeField] List<Task> _tasks = new List<Task>();
		public List<Task> tasks{get{return _tasks;}}
	}

}
