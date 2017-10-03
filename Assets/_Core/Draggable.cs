using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using Game.Objects;
using Game.Objects.Items;
using Game.Objects.Characters;
using Game.Finances;

namespace Game.Core{
    public class Draggable : MonoBehaviour
    {  
        CameraRaycaster _cameraRaycaster;
		const string CHARACTER = "CHARACTER";
		const string ITEM = "ITEM";
        ObjectConfig _objectConfig;
        FinanceSystem _financeSystem;

        public delegate void ObjectDropped(ObjectConfig objectConfig);
        public event ObjectDropped OnObjectDropped;

        void Start()
        {
            _cameraRaycaster = FindObjectOfType<CameraRaycaster>();
            Assert.IsNotNull(_cameraRaycaster);

            _financeSystem = FindObjectOfType<FinanceSystem>();
            OnObjectDropped += _financeSystem.OnObjectDropped;
        }

        public void Setup(ObjectConfig objectConfig)
        {
            _objectConfig = objectConfig;
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
                OnObjectDropped(_objectConfig);
                transform.SetParent(FindParentFor(this.gameObject));
                AddObjectBehavoursToGameObject();
                Destroy(this);
            }
        }

        private void AddObjectBehavoursToGameObject()
        {
            if (this.gameObject.CompareTag(ITEM))
            {
                var itemBehaviour = this.gameObject.AddComponent<ItemBehaviour>();
                itemBehaviour.SetupConfig(_objectConfig as ItemConfig);
            } else if (this.gameObject.CompareTag(CHARACTER)){
                this.gameObject.GetComponent<CharacterMovement>().FindOpenDesk();
                this.gameObject.GetComponent<Character>().Setup(_objectConfig as CharacterConfig);
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

