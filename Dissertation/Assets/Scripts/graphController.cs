using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class graphController : MonoBehaviour {



	// Use this for initialization
	void Start () {


		List<int> day = gameManager.instance.day;
		List<int> sus_count = gameManager.instance.susceptible_count;

		for (int i = 1; i < day.Count; i++) {
		
			VectorLine.SetLine (Color.green, new Vector2 (day[i-1], sus_count[i-1]), 
				new Vector2 (day[i], sus_count[i]));
		
		}

		/**foreach (KeyValuePair<float, int> sus in sir.get_susceptible_dict()) {

			susceptible_time.Add (sus.Key);
			susceptible_count.Add (sus.Value);
		
		}

		foreach (KeyValuePair<float, int> inf in sir.get_infected_dict()) {
		
			infected_time.Add (inf.Key);
			infected_count.Add (inf.Value);
		
		}

		foreach (KeyValuePair<float, int> rec in sir.get_recovered_dict()) {
		
			recovered_time.Add (rec.Key);
			recovered_count.Add (rec.Value);
		
		}

		int max_count = 0;

		if ((susceptible_time.Count >= infected_time.Count) && (susceptible_time.Count >= recovered_time.Count)) {
		
			max_count = susceptible_time.Count;
		
		} else if ((infected_time.Count >= susceptible_time.Count) && (infected_time.Count >= recovered_time.Count)) {
		
			max_count = infected_time.Count;
		
		} 
		else if ((recovered_time.Count >= susceptible_time.Count) && (recovered_time.Count >= infected_time.Count)) {
		
			max_count = recovered_time.Count;
		
		}

		for (int i = 0; i < max_count; i++) {
		
			VectorLine.SetLine (Color.blue, new Vector2 (susceptible_time [i], susceptible_count [i]), 
				new Vector2 (susceptible_time [i + 1], susceptible_time [i + 1]));
		
		}**/


		//VectorLine.SetLine (Color.green, new Vector2 (0, 0), new Vector2 (Screen.width - 1, Screen.height - 1));

	}

}
