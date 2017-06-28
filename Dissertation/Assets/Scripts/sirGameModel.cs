using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/**
 *Class that defines the SIR Model of infection. This version was used to produce the initial phase data and tests
 *that are included in the evaluation. This is the basis of the class that will be modified and extended to work within
 *Unity.
 **/
public class sirGameModel : MonoBehaviour {

	public Dictionary<GameObject, string> population; //dictionary for entire pop. with <individual id, infection status>
	public int susceptible_count;
	public int infected_count;
	public int recovered_count;
	public double contacts;
	public int total_pop;
	public double recovery_rate;


	/**
	 *Public constructor to create an instance of the SIR model. It takes the intial number of susceptible individuals,
	 *infected individuals, the contact rate, and the recovery rate as arguments. This will be adjusted for the model
	 *that will be used in the game (as the first two parameters will have to be linked to the game objects that
	 *represent individuals.
	 **/
	/**public sirGameModel(int susceptible, int infected, double b, double k){

		population = new Dictionary<int, string> ();
		susceptible_count = susceptible;
		infected_count = infected;
		recovered_count = 0;
		total_pop = susceptible_count + infected_count + recovered_count;
		contacts = b;
		recovery_rate = k;

		int i = 0;
		while (i < susceptible) {

			population.Add (i, "susceptible");
			i++;

		}

		for (int j = 0; j < infected; j++) {

			population.Add ((i) + j, "infected");
		}

	}**/

	//Method to get the population dictionary.
	public Dictionary<GameObject, string> get_population(){

		return population;

	}

	//Method to get the number of susceptible individuals.
	public int get_susceptible_count(){

		return susceptible_count;

	}

	//Method to get the number of infected inviduals.
	public int get_infected_count(){

		return infected_count;

	}

	//Method to get the number of recovered individuals.
	public int get_recovered_count(){

		return recovered_count;

	}

	//Method to get the contact rate.
	public double get_contacts(){

		return contacts;

	}

	//Method to get the recovery rate.
	public double get_recovery_rate(){

		return recovery_rate;

	}

	//Method to set the number of susceptible individuals.
	public void set_susceptible_count(int susceptible){

		susceptible_count = susceptible;

	}

	//Method to set the number of infected individuals.
	public void set_infected_count(int infected){

		infected_count = infected;

	}

	//Method to set the number of recovered individuals.
	public void set_recovered_count(int recovered){

		recovered_count = recovered;
	}

	//Method to set the contact rate.
	public void set_contacts(double b){

		contacts = b;

	}

	//Method to set the recovery rate.
	public void set_recovery_rate(double k){

		recovery_rate = k;

	}

	//Method to infect and recover a certain amount of people on the given day.
	public void infect_and_recover(){


		//THIS WILL CHANGE WHEN SWITCHING TO THE GAME. WILL BE BASED ON ACTUAL GAME COLLISIONS
		/**double rate_of_infection = -(contacts) * ((double)susceptible_count / (double)total_pop) * (infected_count);
		double rate_of_recovery = recovery_rate * (infected_count);

		//loop over to infect
		int i = 0;
		for (int j = 0; j < population.Count; j++) {

			if (population [j] == "susceptible" && i > rate_of_infection) {
				population [j] = "infected";
				infected_count++;
				susceptible_count--;
				i = i - 1;
			}
		}

		//loop over to recover
		int k = 0;
		for (int j = population.Count-1; j >= 0; j--){

			if (population [j] == "infected" && k < rate_of_recovery) {

				population [j] = "recovered";
				infected_count--;
				recovered_count++;
				k = k + 1;

			}
		}**/
	}
		
	public void setupModel(){
		
		population = new Dictionary<GameObject, string> ();

		boardManager board = GetComponent<boardManager> ();


		total_pop = susceptible_count + infected_count + recovered_count;

		List <GameObject> character_tiles = board.getCharacters();

		int i = 0;
		while (i < susceptible_count) {

		population.Add (character_tiles[i], "susceptible");
			i++;

		}

		for (int j = 0; j < infected_count; j++) {

			population.Add (character_tiles[(i + j)], "infected");

		}
	
	
	}
}
