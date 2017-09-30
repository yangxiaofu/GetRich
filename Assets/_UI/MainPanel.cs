using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Core;

namespace Game.UI{
	public class MainPanel : MonoBehaviour { 
		Task _task;
		Text _hoursToConsumeText;
		Button _increaseButton;
		Button _decreaseButton;
		int _hoursToConsume;
		Button _performTaskButton;
		Clock _clock;
		
		void Update()
		{
			_hoursToConsumeText.text = _hoursToConsume.ToString();
		}

		public void Setup(Task task)
		{
			_task = task;

			_hoursToConsume = task.GetHourConsumption();
			
			_hoursToConsumeText = GetComponentInChildren<HoursToConsume>().GetComponent<Text>();
			Assert.IsNotNull(_hoursToConsumeText);

			_increaseButton = GetComponentInChildren<IncreaseButton>().GetComponent<Button>();
			Assert.IsNotNull(_increaseButton);
			_increaseButton.onClick.AddListener(IncreaseHoursToConsume);

			_decreaseButton = GetComponentInChildren<DecreaseButton>().GetComponent<Button>();
			Assert.IsNotNull(_decreaseButton);
			_decreaseButton.onClick.AddListener(DecreaseHoursToConsume);

			_performTaskButton = GetComponentInChildren<PerformTaskButton>().GetComponent<Button>();
			Assert.IsNotNull(_performTaskButton);
			_performTaskButton.onClick.AddListener(PerformTask);

			_clock = GameObject.FindObjectOfType<Clock>();
			Assert.IsNotNull(_clock);

		}

		private void IncreaseHoursToConsume()
		{
			_hoursToConsume += 1;
			_hoursToConsume = Mathf.Clamp(_hoursToConsume, 0, 9); //TODO: Remove magic numbers.
		}

		private void DecreaseHoursToConsume()
		{
			_hoursToConsume -= 1;
			_hoursToConsume = Mathf.Clamp(_hoursToConsume, 0, 9);
		}

		private void PerformTask()
		{
			_clock.AdvanceClock(_hoursToConsume);
			
			Destroy(this.gameObject);
		}


	}
}

