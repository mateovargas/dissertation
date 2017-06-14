using System.Collections;
using System.Collections.Generic;
using System;
//using UnityEngine;


/**
 * This is the class that dictates the behavior of the SIR model that will be the backing of the game.
 * It uses a dictionary to keep track of the entire population, with the individual ID as the key and the infection
 * status as the value. The main method is used to both test the functionality of the model and to produce experimental
 * data to ensure the accuracy of the model.
 **/
public class sirModel{

	private Dictionary<int, string> population; //dictionary for entire pop. with <individual id, infection status>
	private int susceptible_count;
	private int infected_count;
	private int recovered_count;
	private double contacts;
	private int total_pop;
	private double recovery_rate;


	/**
	 *Public constructor to create an instance of the SIR model. It takes the intial number of susceptible individuals,
	 *infected individuals, the contact rate, and the recovery rate as arguments. This will be adjusted for the model
	 *that will be used in the game (as the first two parameters will have to be linked to the game objects that
	 *represent individuals.
	 **/
	public sirModel(int susceptible, int infected, double b, double k){
		
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

	}

	//Method to get the population dictionary.
	public Dictionary<int, string> get_population(){

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

	//Method to infect a certain amount of people on the given day
	public void infect(){


		//THIS WILL CHANGE WHEN SWITCHING TO THE GAME. WILL BE BASED ON ACTUAL GAME COLLISIONS
		double rate_of_infection = -(contacts) * ((double)susceptible_count / (double)total_pop) * (infected_count);
		int i = 0;
		for (int j = 0; j < population.Count; j++) {

				if (population [j] == "susceptible" && i > rate_of_infection) {
				population [j] = "infected";
				infected_count++;
				susceptible_count--;
				i = i - 1;
			}
		}
	}

	//Method to recover a certain amount of people on the given day
	public void recover(){

		Console.WriteLine ("The recovery rate is : " + recovery_rate.ToString ("N8"));
		Console.WriteLine ("The infected count is: " + infected_count);
		double rate_of_recovery = recovery_rate * (infected_count);
		Console.WriteLine ("The rate of recovery is: " + rate_of_recovery.ToString ("N8"));
		int i = 0;
		for (int j = population.Count-1; j >= 0; j--){

			if (population [j] == "infected" && i < rate_of_recovery) {

				population [j] = "recovered";
				infected_count--;
				recovered_count++;
				i = i + 1;

			}
		}
	}

	public static void Main(string[] args){

		sirModel test_model;
		test_model = new sirModel (90, 10, ((double)1/(double)2), ((double)1/(double)3));

		Dictionary<int, string> population = test_model.get_population();

		if (population.Count != 100) {

			Console.WriteLine("Error in model initialization. Wrong number of individuals.");

		} 
		else {

			for (int i = 0; i < population.Count; i++) {
				Console.WriteLine ("The current individual is: " + i +
					" and the status is: " + population [i]);
			}
		}

		Console.WriteLine ("");
		Console.WriteLine ("The test model has a susceptible count of: " + test_model.susceptible_count);
		Console.WriteLine ("The test model has an infection count of: " + test_model.infected_count);
		Console.WriteLine ("The test model has a recovered count of: " + test_model.recovered_count);
		Console.WriteLine ("The test model has a contact rate of: " + test_model.contacts.ToString("N8"));
		Console.WriteLine ("The test model has a recovery rate of: " + test_model.recovery_rate.ToString("N8"));
		Console.WriteLine ("The test model has a population of: " + test_model.total_pop);
		Console.WriteLine ("Testing infection method.");
		test_model.infect ();

		for (int i = 0; i < population.Count; i++) {
			Console.WriteLine ("The current individual is: " + i +
				" and the status is: " + population [i]);
		}

		Console.WriteLine ("After 1 infection cycle, the test model has a susceptible count of: " 
							+ test_model.susceptible_count);
		Console.WriteLine ("After 1 infection cycle, the test model has an infection count of: " 
							+ test_model.infected_count);

		Console.WriteLine ("");
		Console.WriteLine ("Testing recovery model.");
		test_model.recover ();
	
		for (int i = 0; i < population.Count; i++) {
			Console.WriteLine ("The current individual is: " + i +
				" and the status is: " + population [i]);
		}

		Console.WriteLine ("After 1 recovery cycle, the test model has a susceptible count of: " 
							+ test_model.susceptible_count);
		Console.WriteLine ("After 1 recovery cycle, the test model has an infection count of: " 
							+ test_model.infected_count);
		Console.WriteLine ("After 1 recovery cycle, the test model has a recovered count of: " 
							+ test_model.recovered_count);

		/**while (test_model.get_recovered_count () != 100) {
		
			test_model.infect ();
			test_model.recover ();
			Console.WriteLine ("           ");
			for (int i = 0; i < population.Count; i++) {
				Console.WriteLine ("The current individual is: " + i +
					" and the status is: " + population [i]);
			}
		}**/

	}
}
