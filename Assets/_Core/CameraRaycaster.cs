using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class CameraRaycaster : MonoBehaviour {
		[SerializeField] float _boundary = 50f;
		[SerializeField] float _speed = 5f;
		int _screenWidth;
		int _screenHeight;
		Vector3 _mousePositionOnGround;
		public Vector3 GetMousePositionOnGround() {return _mousePositionOnGround;}
		float _raycastDistance = 50f;
		const int GROUND_LAYER_BIT = 8;
		
		void Start()
		{
			_screenWidth = Screen.width;
			_screenHeight = Screen.height;
		}

		void Update()
        {
            ScanForMouseInBoundaries();
        }

		void FixedUpdate()
        {
            RaycastToGround();
        }

        private void RaycastToGround()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, _raycastDistance, (1 << GROUND_LAYER_BIT)))
            {
                _mousePositionOnGround = hit.point;
            }
        }

        private void ScanForMouseInBoundaries()
        {
            if (Input.mousePosition.x > _screenWidth - _boundary && Input.mousePosition.x < _screenWidth)
            {
                this.transform.Translate(_speed * Time.deltaTime, 0, 0);
            }

            if (Input.mousePosition.x < _boundary && Input.mousePosition.x > 0)
            {
                this.transform.Translate(-_speed * Time.deltaTime, 0, 0);
            }

            if (Input.mousePosition.y > _screenHeight - _boundary && Input.mousePosition.y < _screenHeight)
            {
                this.transform.Translate(0, _speed * Time.deltaTime, 0);
            }

            if (Input.mousePosition.y < _boundary && Input.mousePosition.y > 0)
            {
                this.transform.Translate(0, -_speed * Time.deltaTime, 0);
            }
        }


	}

}

