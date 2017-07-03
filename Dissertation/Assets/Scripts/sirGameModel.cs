using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Random = UnityEngine.Random;



/**
 *Class that defines the SIR Model of infection. This version was used to produce the initial phase data and tests
 *that are included in the evaluation. This is the basis of the class that will be modified and extended to work within
 *Unity.
 **/
public class sirGameModel : MonoBehaviour {

	private Dictionary<GameObject, string> population;
	private int susceptible_count;
	private int infected_count;
	private int recovered_count;
	private double contacts;
	private int total_pop;
	private double recovery_rate;
	private Dictionary<float, int> susceptible_data = new Dictionary<float, int>();
	private Dictionary<float, int> infected_data = new Dictionary<float, int>();
	private Dictionary<float, int> recovered_data = new Dictionary<float, int>();
	private int vaccine_counter;

	public float timer_in_seconds = 0;
	public float level_timer = 0;
	public bool update_timer = false;


	/**
	 *Method to get the population dictionary.
	 **/
	public Dictionary<GameObject, string> get_population(){

		return population;

	}

	/**
	 *Method to get the number of susceptible individuals.
	 **/
	public int get_susceptible_count(){

		return susceptible_count;

	}

	/**
	 *Method to get the number of infected inviduals.
	 **/
	public int get_infected_count(){

		return infected_count;

	}

	/**
	 *Method to get the number of recovered individuals.
	 **/
	public int get_recovered_count(){

		return recovered_count;

	}

	/**
	 *Method to get the contact rate.
	 **/
	public double get_contacts(){

		return contacts;

	}

	/**
	 *Method to get the recovery rate.
	 **/
	public double get_recovery_rate(){

		return recovery_rate;

	}

	/**
	 *Method to get the individual's status.
	 **/
	public string get_individual_status (GameObject individual){

			return population[individual];
	
	}

	/**
	 *Method to set the number of susceptible individuals.
	 **/
	public void set_susceptible_count(int susceptible){

		susceptible_count = susceptible;

	}

	/**
	 *Method to set the number of infected individuals.
	 **/
	public void set_infected_count(int infected){

		infected_count = infected;

	}

	/**
	 *Method to set the number of recovered individuals.
	 **/
	public void set_recovered_count(int recovered){

		recovered_count = recovered;
	}

	/**
	 *Method to set the contact rate.
	 **/
	public void set_contacts(double b){

		contacts = b;

	}

	/**
	 *Method to set the recovery rate.
	 **/
	public void set_recovery_rate(double k){

		recovery_rate = k;

	}
		
	/**
	 *Method to set up the SIR model. This is called from gameManager.cs, in the initGame method.
	 *It places each character gameobject into a dictionary with the appropriate status, be it susceptible or infected.
	 **/
	public void setupModel(){
		
		population = new Dictionary<GameObject, string> ();

		boardManager board = GetComponent<boardManager> ();

		susceptible_count = 40;
		infected_count = 10;
		recovered_count = 0;
		vaccine_counter = 1;

		total_pop = susceptible_count + infected_count + recovered_count;

		susceptible_data.Add (timer_in_seconds, susceptible_count);
		infected_data.Add (timer_in_seconds, infected_count);
		recovered_data.Add (timer_in_seconds, recovered_count);

		List <GameObject> character_tiles = board.getCharacters();

		int i = 0;
		while (i < susceptible_count) {

			population.Add (character_tiles[i], "susceptible");
			i++;

		}

		for (int j = 0; j < infected_count; j++) {

			population.Add (character_tiles[(i + j)], "infected");

		}

		update_timer = true;
		level_timer = 0.0f;
	
	}

	/**
	 *Method to determine the spread of the infection amongst characters. This method is called upon the detection of a 
	 *collision between two character game objects. It takes two arguments, the characters who collide. It then chooses
	 *a random number to determine whether the collision will result in the spread of the infection and, if so change
	 *the newly infected characters status to infected and initiate an animation and sound cue (TO BE DONE).
	 */
	public void infect(GameObject moving_character, GameObject hit_character){

		if (population [moving_character] != "infected" && population [hit_character] != "infected") {
		
			return;

		}

		int random_chance = Random.Range (0, 1000); //CHANGE DEPENDING ON THE INFECTION RATE (USING 1/3)


		if ((population [moving_character] == "infected") && (population [hit_character] == "susceptible")) {

			if (random_chance > 500) {

				population [hit_character] = "infected";
				infected_count++;
				susceptible_count--;


			}
		}
		else if((population[moving_character] == "susceptible") && (population[hit_character] == "infected")){
		
			if(random_chance > 500){

				population[moving_character] = "infected";
				infected_count++;
				susceptible_count--;

			}

		}
	}

	/**
	 *Method to determine the recovery of individuals. This method is called with every update, and is only called
	 *for individuals who are infected. It takes in the current character that it is called in as an argument.
	 * */
	public void recover(GameObject character){
	
		int random_chance = Random.Range (0, 1000);

		if (random_chance < 333) {

			population [character] = "recovered";
			infected_count--;
			recovered_count++;

		}

	}

	public void vaccinate(GameObject character){
	
		if (vaccine_counter > 0) {
		
			population [character] = "recovered";
			susceptible_count--;
			recovered_count++;

		}

	}

	/**
	 *Method to record population totals at each timepoint for the production of graphs and figures.
	 **/
	public void add_data(){
		
		if (!susceptible_data.ContainsKey (timer_in_seconds)) {
		
			susceptible_data.Add (timer_in_seconds, susceptible_count);

		}

		if (!infected_data.ContainsKey (timer_in_seconds)) {
		
			infected_data.Add (timer_in_seconds, infected_count);
		
		}

		if (!recovered_data.ContainsKey (timer_in_seconds)) {
		
			recovered_data.Add (timer_in_seconds, recovered_count);
		
		}
			

	
	}

	/**
	 *Method to print out the recorded data at each timepoint to csvs to be used as data tables. 
	 **/
	public void print_data(){
	
		using (var writer_s = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/susceptible.csv")) {

			foreach (KeyValuePair<float, int> sus in susceptible_data) {
				
				string item_one_s = sus.Key.ToString();
				string item_two_s = sus.Value.ToString();
				string line = string.Format ("{0}, {1}", item_one_s, item_two_s);
				writer_s.WriteLine (line);
				writer_s.Flush ();

			}
		}


		using (var writer_i = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/infected.csv")) {

			foreach (KeyValuePair<float, int> inf in infected_data) {
				
				string item_one_i = inf.Key.ToString();
				string item_two_i = inf.Value.ToString();
				string line = string.Format ("{0}, {1}", item_one_i, item_two_i);
				writer_i.WriteLine (line);
				writer_i.Flush ();

			}
		}

		using (var writer_r = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/recovered.csv")) {

			foreach (KeyValuePair<float, int> rec in recovered_data) {
				
				string item_one_r = rec.Key.ToString();
				string item_two_r = rec.Value.ToString();
				string line = string.Format ("{0}, {1}", item_one_r, item_two_r);
				writer_r.WriteLine (line);
				writer_r.Flush ();

			}
		}
	
	}
}
