using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Objects.Characters;

namespace Game.UI{
	public class EnergyBarUI : MonoBehaviour {

		EnergyLevelBehaviour _energyLevel;
		RawImage _rawImage;

		void Start()
		{
			_energyLevel = GetComponentInParent<EnergyLevelBehaviour>();	
			_rawImage = GetComponent<RawImage>();
		}


		void Update(){
			float xValue = (_energyLevel.GetEnergyAsPercentage() / 2f) - 0.5f;
			_rawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);

		}
	}

}
