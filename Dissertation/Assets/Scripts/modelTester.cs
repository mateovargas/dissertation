using System.Collections;
using System.Collections.Generic;
//using UnityEngine;


public class modelTester{

	sirModel test_model;

	public void Main(){
		
		test_model = new sirModel (90, 10, (1 / 2), (1 / 3));

		Dictionary<int, string> population = test_model.get_population();

		if (population.Count != 110) {

			Debug.Log("Error in model initialization. Wrong number of individuals.");

		} 
		else {

			for (int i = 0; i < population.Count; i++) {
				Debug.Log ("The current individual is: " + i +
				" and the status is: " + population [i]);
			}
		}
	}

}
