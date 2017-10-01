using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Core;

namespace Game.UI{
	public class ClockUI : MonoBehaviour {

		Clock _clock;
		[SerializeField] Text _hourText;
		[SerializeField] Text _minuteText;

		void Start()
		{
			Assert.IsNotNull(_hourText);
			Assert.IsNotNull(_minuteText);
			_clock = FindObjectOfType<Clock>();
			Assert.IsNotNull(_clock);
		}

		void Update()
		{
			_hourText.text = _clock.hour.ToString();
			_minuteText.text = _clock.minute.ToString();
		}
	}
}

