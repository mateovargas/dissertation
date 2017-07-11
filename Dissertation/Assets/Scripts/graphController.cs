using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;
using UnityEngine.UI;

public class graphController : MonoBehaviour {

	private Text title;
	private Text sus_text;
	private Text inf_text;
	private Text rec_text;
	private Text x_title;
	private Text y_title;

	// Use this for initialization
	void Start () {

		title = GameObject.Find ("title").GetComponent<Text> ();
		sus_text = GameObject.Find ("sus_text").GetComponent<Text> ();
		inf_text = GameObject.Find ("inf_text").GetComponent<Text> ();
		rec_text = GameObject.Find ("rec_text").GetComponent<Text> ();
		x_title = GameObject.Find ("x_title").GetComponent<Text> ();
		y_title = GameObject.Find ("y_title").GetComponent<Text> ();


		title.text = "SIR Model over Time in Days";
		sus_text.text = "Susceptible";
		inf_text.text = "Infected";
		rec_text.text = "Recovered";
		x_title.text = "Number of Days";
		y_title.text = "Number of Individuals";



		int total = gameManager.instance.total;
		List<int> day = gameManager.instance.day;
		List<int> sus_count = gameManager.instance.susceptible_count;
		List<int> inf_count = gameManager.instance.infected_count;
		List<int> rec_count = gameManager.instance.recovered_count;

		//int x_length = (Screen.width / (day.Count));


		for (int i = 1; i < day.Count; i++) {

			int x_one = ((day [i-1] * Screen.width) / day.Count);
			int x_two = ((day [i] * Screen.width) / day.Count);
			int y_sus_one = ((sus_count [i - 1] * Screen.height) / total);
			int y_sus_two = ((sus_count [i] * Screen.height) / total);
			int y_inf_one = ((inf_count [i - 1] * Screen.height) / total);
			int y_inf_two = ((inf_count [i] * Screen.height) / total);
			int y_rec_one = ((rec_count [i - 1] * Screen.height) / total);
			int y_rec_two = ((rec_count [i] * Screen.height) / total);




			VectorLine.SetLine (Color.black, new Vector2 (x_one, y_sus_one), 
				new Vector2 (x_two, y_sus_two));
			VectorLine.SetLine (Color.red, new Vector2 (x_one, y_inf_one), 
				new Vector2 (x_two, y_inf_two));
			VectorLine.SetLine (Color.green, new Vector2 (x_one, y_rec_one),
				new Vector2 (x_two, y_rec_two));

		}



	}

}
