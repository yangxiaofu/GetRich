using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Objects;
using Game.Core;

namespace Game.UI{
	[RequireComponent(typeof(Button))]
	public class AddItemButton : MonoBehaviour {
		[SerializeField] ObjectConfig _objectConfig;
		Button _button;
		Text _text;
		CameraRaycaster _cameraRaycaster;

		void Awake(){
			Assert.IsNotNull(_objectConfig);
		}
		void Start()
        {
            SetupVariables();
        }

        private void InstantiateItemToMouse()
        {
            var itemObject = Instantiate(_objectConfig.GetObjectPrefab());
            itemObject.transform.position = _cameraRaycaster.GetMousePositionOnGround();
            itemObject.AddComponent<Draggable>();
        }

       

		private void SetupVariables()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(InstantiateItemToMouse);

            _text = GetComponentInChildren<Text>();
            _text.text = _objectConfig.objectName;

            _cameraRaycaster = FindObjectOfType<CameraRaycaster>();

            Assert.IsNotNull(
                _cameraRaycaster,
                "There is no camera raycaster attached to a game object in the scene."
            );
        }

    }

}
