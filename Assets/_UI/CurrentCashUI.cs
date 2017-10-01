using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Game.Finances;

namespace Game.UI{
	public class CurrentCashUI : MonoBehaviour {
		FinanceSystem _financeSystem;
		
		// Use this for initialization
		void Start () 
		{
			_financeSystem = FindObjectOfType<FinanceSystem>();
			Assert.IsNotNull(_financeSystem);
		}
		
		// Update is called once per frame
		void Update () 
		{
			GetComponent<Text>().text = _financeSystem.GetCurrentCash().ToString();
		}
	}
}

