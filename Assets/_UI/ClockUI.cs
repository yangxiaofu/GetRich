using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Core;

namespace Game.UI{
	public class ClockUI : MonoBehaviour {

		[SerializeField] Clock _clock;

		Text _text;


		void Start()
		{
			if (!_clock) Debug.LogError("You need to reference the clock in the Clock UI");

			_text = GetComponent<Text>();
			if (!_text) Debug.LogError("You need to add the Text component on to this game object");
		}

		void Update()
		{
			_text.text = _clock.currentTimeOfDay.ToString();
		}
	}
}

