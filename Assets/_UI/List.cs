using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Game.UI;

namespace Game.Core{
	public abstract class List : MonoBehaviour {
		[HeaderAttribute("General List")]
		
		[SerializeField] protected GameObject _taskUIPrefab;
		protected TaskManager _taskManager;

		protected void SetupVariables()
        {
            _taskManager = GameObject.FindObjectOfType<TaskManager>();
            Assert.IsNotNull(_taskManager);
            Assert.IsNotNull(_taskUIPrefab);
        }


		protected void DestroyChildrenIn(Transform parent)
		{
			foreach(Transform child in parent)
			{
				Destroy(child.gameObject);
			}
		}
		protected void InstantiateTaskUIButton(Task task)
		{
			var taskUIObject = Instantiate(_taskUIPrefab);
			taskUIObject.GetComponent<TaskUI>().Setup(task);
			taskUIObject.transform.SetParent(this.transform, false);
			taskUIObject.GetComponent<Text>().text = task.name;
		}

		protected void InstantiateTasksUIButtons(List<Task> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
				InstantiateTaskUIButton(tasks[i]);				
            }
        }

	}

}
