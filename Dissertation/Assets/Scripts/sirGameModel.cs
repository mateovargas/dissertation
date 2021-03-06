﻿using System.Collections;
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
	private float time_for_vaccine;
	private int day;
	private bool done;

	public float timer_in_seconds = 0;
	public float level_timer = 0;

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
	 *Method to get the vaccine counters. 
	 **/
	public int get_vaccine_counters(){
	
		return vaccine_counter;
	
	}

	/**
	 *Method to get the number of days.
	 **/
	public int get_days(){
	
		return day;
	
	}

	public Dictionary<float, int> get_susceptible_dict(){
	
		return susceptible_data;
	
	}

	public Dictionary<float, int> get_infected_dict(){
	
		return infected_data;

	}

	public Dictionary<float, int> get_recovered_dict(){
	
		return recovered_data;

	}

	public bool get_done_flag(){
	
		return done;
	
	}


	public void set_done_flag(bool flag){
	
		done = flag;
	
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
	 *Method to set the vaccine counters.
	 **/
	public void set_vaccine_counter(int v){
	
		vaccine_counter = v;
	
	}
		
	/**
	 *Method to set up the SIR model. This is called from gameManager.cs, in the initGame method.
	 *It places each character gameobject into a dictionary with the appropriate status, be it susceptible or infected.
	 **/
	public void setupModel(){
		
		done = false;

		population = new Dictionary<GameObject, string> ();

		boardManager board = GetComponent<boardManager> ();

		susceptible_count = board.individual_count - 10;
		infected_count = 10;
		recovered_count = 0;
		vaccine_counter = 2;
		day = 1;

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


		level_timer = 0.0f;
		time_for_vaccine = Time.fixedTime + .0f;
	
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

	/**
	 *Method to vaccinate a unit. Takes in the unit to vaccinate as an argument.
	 **/
	public void vaccinate(GameObject character){
	
		if (vaccine_counter > 0) {
		
			population [character] = "recovered";
			susceptible_count--;
			recovered_count++;
			vaccine_counter--;

		}

	}
		
	/**
	 *Method to update the model every five seconds.
	 **/
	void FixedUpdate(){

		if (Time.fixedTime >= time_for_vaccine) {

			day++;

			time_for_vaccine = Time.fixedTime + 5.0f;
		
		}


	}

}
