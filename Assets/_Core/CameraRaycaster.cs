using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class CameraRaycaster : MonoBehaviour {
		[SerializeField] float _boundary = 50f;
		[SerializeField] float _speed = 5f;
		int _screenWidth;
		int _screenHeight;		

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			_screenWidth = Screen.width;
			_screenHeight = Screen.height;
		}

		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		void Update()
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

