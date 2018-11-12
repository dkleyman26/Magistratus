using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Global_Time_Test: MonoBehaviour
{

	//public IEnumerator Testing_The_Game_Time()
	

																			// Use the Assert: must be true in order for test to pass
		public class Accessor : MonoBehaviour
		{

		public Global_Time gt;
			//public Global_Time

			void Start()
			{
				gt = GameObject.Find("Time_Manager").GetComponent<Global_Time>();
			//Assert.AreEqual(gt.currentTime,gt.currentDay);



			}

		private void Update()
		{
			int mycurrentday = (int)gt.currentTime / 240;

			if (mycurrentday == gt.currentDay)
			{
			   Debug.Log("stop");
			}
			else
			{

				Debug.Log("How so");
			} 
		}
	}
	
}	
