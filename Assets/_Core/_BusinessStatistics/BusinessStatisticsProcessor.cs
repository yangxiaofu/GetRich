using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core{
	public class BusinessStatisticsProcessor
    {
        public delegate void BusinessStatisticsHandler(BusinessStatisticsArgs args);
        BusinessStatisticsArgs _args;
        public BusinessStatisticsArgs args{get{return _args;}}
        public BusinessStatisticsProcessor(BusinessStatisticsArgs args)
        {
            _args = args;
        }
        public void Process(BusinessStatisticsHandler statisticsHandler)
        {
            statisticsHandler(_args);
        }
    }
}
