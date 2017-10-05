using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Finances{
    public class FinanceSystemStub : IFinanceSystem
    {
		public float cash = 0;
        public void AddCash(float cash)
        {
            cash += cash;
        }

        public void UseCash(float cash)
        {
            cash -= cash;
        }
    }

}
