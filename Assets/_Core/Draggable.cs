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
                Destroy(this);
            }
        }
    }
}

