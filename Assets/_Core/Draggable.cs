using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace Game.Core{
    public class Draggable : MonoBehaviour
    {  
        CameraRaycaster _cameraRaycaster;
		const string CHARACTER = "CHARACTER";
		const string ITEM = "ITEM";

        void Start()
        {
            _cameraRaycaster = FindObjectOfType<CameraRaycaster>();
            Assert.IsNotNull(_cameraRaycaster);
        }

        void Update()
        {
            UpdateItemPosition();
            ScanForDropInput();
            ScanForItemRotatation();
        }

        private void ScanForItemRotatation()
        {
            if (Input.GetMouseButtonDown(1))
            {
                transform.Rotate(0, 90, 0);
            }
        }

        private void UpdateItemPosition()
        {
            this.transform.position = _cameraRaycaster.GetMousePositionOnGround();
        }

        private void ScanForDropInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.SetParent(FindParentFor(this.gameObject));
                Destroy(this);
            }
        }

        private Transform FindParentFor(GameObject itemObject)
        {
            if (itemObject.CompareTag(CHARACTER))
            {
                return FindObjectOfType<CharacterParent>().transform;
            }
            else if (itemObject.CompareTag(ITEM))
            {
                return  FindObjectOfType<ItemParent>().transform;
            }
            else
            {
                throw new UnityException("You forgot to set the item tag in " + itemObject.name);
            }
        }
    }
}

