using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
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

	//Method to infect and recover a certain amount of people on the given day.
	public void infect_and_recover(){


		//THIS WILL CHANGE WHEN SWITCHING TO THE GAME. WILL BE BASED ON ACTUAL GAME COLLISIONS
		double rate_of_infection = -(contacts) * ((double)susceptible_count / (double)total_pop) * (infected_count);
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
		}
	}
		
	public static void Main(string[] args){

		sirModel test_model;
		Dictionary<int, int> susceptible_data = new Dictionary<int, int> ();
		Dictionary<int, int> infected_data = new Dictionary<int, int> ();
		Dictionary<int, int> recovered_data = new Dictionary<int, int> ();
		test_model = new sirModel (99990, 10, ((double)1/(double)2), ((double)1/(double)3));

		//Dictionary<int, string> population = test_model.get_population();

		/**if (population.Count != 100) {

			Console.WriteLine("Error in model initialization. Wrong number of individuals.");

		} 
		else {

			for (int i = 0; i < population.Count; i++) {
				Console.WriteLine ("The current individual is: " + i +
					" and the status is: " + population [i]);
			}
		}**/

		Console.WriteLine ("");
		Console.WriteLine ("The test model has a susceptible count of: " + test_model.susceptible_count);
		Console.WriteLine ("The test model has an infection count of: " + test_model.infected_count);
		Console.WriteLine ("The test model has a recovered count of: " + test_model.recovered_count);
		Console.WriteLine ("The test model has a contact rate of: " + test_model.contacts.ToString("N8"));
		Console.WriteLine ("The test model has a recovery rate of: " + test_model.recovery_rate.ToString("N8"));
		Console.WriteLine ("The test model has a population of: " + test_model.total_pop);
		Console.WriteLine ("Testing infection method.");

		susceptible_data.Add (0, test_model.get_susceptible_count ());
		infected_data.Add (0, test_model.get_infected_count ());
		recovered_data.Add (0, test_model.get_recovered_count ());

		test_model.infect_and_recover ();

		/**for (int i = 0; i < population.Count; i++) {
			Console.WriteLine ("The current individual is: " + i +
				" and the status is: " + population [i]);
		}

		Console.WriteLine ("After 1 infection cycle, the test model has a susceptible count of: " 
							+ test_model.susceptible_count);
		Console.WriteLine ("After 1 infection cycle, the test model has an infection count of: " 
							+ test_model.infected_count);

		Console.WriteLine ("");

		Console.WriteLine ("After 1 recovery cycle, the test model has a susceptible count of: " 
							+ test_model.susceptible_count);
		Console.WriteLine ("After 1 recovery cycle, the test model has an infection count of: " 
							+ test_model.infected_count);
		Console.WriteLine ("After 1 recovery cycle, the test model has a recovered count of: " 
							+ test_model.recovered_count);**/

		int t = 1;
		while (test_model.get_recovered_count() != 100000) {
			
			test_model.infect_and_recover ();

			susceptible_data.Add (t, test_model.get_susceptible_count ());
			infected_data.Add (t, test_model.get_infected_count ());
			recovered_data.Add (t, test_model.get_recovered_count ());

			t = t + 1;

		}


		using (var writer_s = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/susceptible.csv")) {

			for (int x = 0; x < susceptible_data.Count; x++) {
				string item_one_s = x.ToString();
				string item_two_s = susceptible_data[x].ToString();
				string line = string.Format ("{0}, {1}", item_one_s, item_two_s);
				writer_s.WriteLine (line);
				writer_s.Flush ();
			}
		}


		using (var writer_i = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/infected.csv")) {

			for (int x = 0; x < infected_data.Count; x++) {
				string item_one_i = x.ToString();
				string item_two_i = infected_data[x].ToString();
				string line = string.Format ("{0}, {1}", item_one_i, item_two_i);
				writer_i.WriteLine (line);
				writer_i.Flush ();
			}
		}

		using (var writer_r = new StreamWriter ("/Users/mateovargas/Documents/Dissertation/data/recovered.csv")) {

			for (int x = 0; x < recovered_data.Count; x++) {
				string item_one_r = x.ToString();
				string item_two_r = recovered_data[x].ToString();
				string line = string.Format ("{0}, {1}", item_one_r, item_two_r);
				writer_r.WriteLine (line);
				writer_r.Flush ();
			}
		}
	}
}
