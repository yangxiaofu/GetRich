using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Core;

namespace Game.UI{
	public class TaskUI : MonoBehaviour {
		Task _task;
		Canvas _canvas;
		public void Setup(Task task)
		{
			_task = task;
			_canvas = GameObject.FindObjectOfType<Canvas>();
            GetComponent<Text>().text = task.name;
			if(!_canvas) Debug.LogError("There is no canvas in the parent");
            var button = gameObject.AddComponent<Button>();
			button.onClick.AddListener(OpenTaskUI);
		}

		void OpenTaskUI()
        {
            DestroyMainPanel();
            
            var uiPanelPrefab = _task.GetUIPanel();
            var uiPanelObject = Instantiate(uiPanelPrefab) as GameObject;
            uiPanelObject.transform.SetParent(_canvas.transform, false);
             var mainPanel = uiPanelObject.AddComponent<MainPanel>();
            mainPanel.Setup(_task);
        }

        private void DestroyMainPanel()
        {
            var mainPanel = GameObject.FindObjectOfType<MainPanel>();
            if (mainPanel) Destroy(mainPanel.gameObject);
        }
    }

}
