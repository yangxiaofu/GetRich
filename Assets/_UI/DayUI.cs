using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Core;

namespace Game.UI{
	public class DayUI : MonoBehaviour {
		[SerializeField] DayManager _dayManager;
		Text _text;

		void Start()
		{
			Assert.IsNotNull(_dayManager);

			_text = GetComponent<Text>();
			Assert.IsNotNull(_text);
		}

		void Update()
		{
			_text.text = _dayManager.currentDay.ToString();
		}
	}

}
