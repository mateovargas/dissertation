using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
	public class sirModel{

		private Dictionary<int, string> population; //dictionary for entire pop. with <individual id, infection status>
		private int susceptible_count;
		private int infected_count;
		private int recovered_count;
		private double contacts;
		private int total_pop;
		private double recovery_rate;

		public void setUp(int susceptible, int infected, double b, double k){

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

				population.Add ((i + 1) + j, "infected");
			}

		}

		//Getter Methods
		public Dictionary<int, string> get_population(){

			return population;

		}

		public int get_susceptible_count(){

			return susceptible_count;

		}

		public int get_infected_count(){

			return infected_count;

		}

		public int get_recovered_count(){

			return recovered_count;

		}

		public double get_contacts(){

			return contacts;

		}

		public double get_recovery_rate(){

			return recovery_rate;

		}

		//Setter Methods
		public void set_susceptible_count(int susceptible){

			susceptible_count = susceptible;

		}

		public void set_infected_count(int infected){

			infected_count = infected;

		}

		public void set_recovered_count(int recovered){

			recovered_count = recovered;
		}

		public void set_contacts(double b){

			contacts = b;

		}

		public void set_recovery_rate(double k){

			recovery_rate = k;

		}

		//Method to infect a certain amount of people on the given day
		public void infect(){


			//THIS WILL CHANGE WHEN SWITCHING TO THE GAME. WILL BE BASED ON ACTUAL GAME COLLISIONS
			double rate_of_infection = -(contacts) * (susceptible_count / total_pop) * (infected_count);
			float infection = (float)rate_of_infection;

			int i = 0;
			while(i < infection) {

				for (int j = 0; j < population.Count; j++) {

					if (population [j] == "susceptible") {
						population [j] = "infected";
						infected_count++;
						susceptible_count--;
						i++;
					}
				}
			}
		}

		//Method to recover a certain amount of people on the given day
		public void recover(){

			double rate_of_recovery = recovery_rate * (infected_count);
			float recovery = (float)rate_of_recovery;

			int i = 0;
			while (i < recovery) {

				for (int j = population.Count; j > 0; j--){

					if (population [j] == "infected") {

						population [j] = "recovered";
						infected_count--;
						recovered_count++;
						i++;

					}
				}
			}
		}


		public static void Main(string[] args){

			sirModel test_model = new sirModel ();

			test_model.setUp (90, 10, (1 / 2), (1 / 3));

			Dictionary<int, string> population = test_model.get_population();

			if (population.Count != 110) {

				Console.WriteLine("Error in model initialization. Wrong number of individuals.");

			} 
			else {

				for (int i = 0; i < population.Count; i++) {
					Console.WriteLine("The current individual is: " + i +
						" and the status is: " + population [i]);
				}
			}
		}
	}
}
