using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Items;
using Game.Core;

namespace Game.UI{
	[RequireComponent(typeof(Button))]
	public class AddItemButton : MonoBehaviour {
		[SerializeField] ItemConfig _itemConfig;

		Button _button;
		Text _text;

		CameraRaycaster _cameraRaycaster;

		void Start(){
			Assert.IsNotNull(_itemConfig);

			_button = GetComponent<Button>();
			_button.onClick.AddListener(InstantiateItemToMouse);

			_text = GetComponentInChildren<Text>();
			_text.text = _itemConfig.itemName;

			_cameraRaycaster = FindObjectOfType<CameraRaycaster>();

			Assert.IsNotNull(
				_cameraRaycaster, 
				"There is no camera raycaster attached to a game object in the scene."
			);

		}

		void InstantiateItemToMouse()
		{
			var itemObject = Instantiate(_itemConfig.GetItemPrefab());
			itemObject.transform.position = _cameraRaycaster.GetMousePositionOnGround();
			itemObject.AddComponent<Draggable>();
			print("Item to Mouse.  Item can be draggable on the mouse. ");
		}


	}

}
