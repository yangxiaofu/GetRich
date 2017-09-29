using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Core{
	public class Clock : MonoBehaviour {
		[SerializeField] float _timer = 0;

		void Update()
		{
			_timer = _timer + Time.deltaTime;
		}

	}

}
