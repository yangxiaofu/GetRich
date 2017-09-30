using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Core{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
		GameObject _draggedItem;
        public void OnBeginDrag(PointerEventData eventData)
        {	
			//Instantae an object and set it to the game object. 
        }

        public void OnDrag(PointerEventData eventData)
        {
			this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
			
        }
    }
}

