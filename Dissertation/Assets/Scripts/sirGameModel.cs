using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



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

	public string get_individual_status (GameObject individual){

			return population[individual];
	
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

	public void infect(GameObject moving_character, GameObject hit_character){


		Debug.Log ("The moving character is: " + moving_character.GetInstanceID () + " and the status is: " + population [moving_character]);
		Debug.Log ("The hit character is: " + hit_character.GetInstanceID () + " and the status is: " + population [hit_character]);

		if (population [moving_character] != "infected" && population [hit_character] != "infected") {
		
			return;

		}

		int random_chance = Random.Range (0, 1000); //CHANGE DEPENDING ON THE INFECTION RATE (USING 1/3)

		Debug.Log ("RANDOM CHANCE IS: " + random_chance);

		if ((population [moving_character] == "infected") && (population [hit_character] == "susceptible")) {

			if (random_chance > 333) {
			
				population [hit_character] = "infected";
				infected_count++;
				susceptible_count--;
				//ADD SOME CUE TO KNOW IT'S INFECTED

			}
		}
		else if((population[moving_character] == "susceptible") && (population[hit_character] == "infected")){
		
			if(random_chance > 333){
			
				population[moving_character] = "infected";
				infected_count++;
				susceptible_count--;
				//ADD SOME CUE TO KNOW IT'S INFECTED

			}

		}

		Debug.Log ("The moving character is now: " + population [moving_character]);
		Debug.Log ("The hit character is now: " + population [hit_character]);
	}

	public void recover(GameObject character){
	
		int random_chance = Random.Range (0, 1000);

		if (random_chance < 500) {

			population [character] = "recovered";
			infected_count--;
			recovered_count++;
			//ADD SOME CUE TO KNOW IT'S
		}

	}
}
