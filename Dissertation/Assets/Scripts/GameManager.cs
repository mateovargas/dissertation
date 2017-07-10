using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *Class that controls the overall behavior of the game. Instantiates the board and the SIR model, as well as the
 *necessary UI. 
 **/
public class gameManager : MonoBehaviour {

	public static gameManager instance = null;
	private boardManager board_script;
	public sirGameModel sir_model;
	public List<int> day;
	public List<int> susceptible_count;
	public List<int> infected_count;
	public List<int> recovered_count;
	private int score;
	private int power;
	private bool paused;
	private float time_to_choose;

	private Text susceptible_text;
	private Text infected_text;
	private Text recovered_text;
	private Text vaccine_text;
	private Text score_text;
	private Text power_text;
	private Text day_text;
	private Image pause_menu;
	private Image vaccine_menu;

	/**
	 *Initializes the game manager overall. 
	 **/
	void Awake () {

		if (instance == null) {
			
			instance = this;

		} else if (instance != this) {
		
			Destroy (gameObject);

		} 

		//ENSURES THAT GAMEOBJECT AND ALL ATTACHED OBJECTS ARE RETAINED BETWEEN SCENES!
		DontDestroyOnLoad (gameObject);

		board_script = GetComponent<boardManager> ();
		sir_model = GetComponent <sirGameModel> ();

		day = new List<int> ();
		susceptible_count = new List<int> ();
		infected_count = new List<int> ();
		recovered_count = new List<int> ();
	
		time_to_choose = Time.fixedTime + 5.0f;
			
		InitGame ();

	}

	/**
	 *Method to initialize the game. Sets up the board and the model, as well as the initial score. Initializes all the
	 *UI text.
	 **/
	void InitGame(){
	
		board_script.SetupScene ();
		sir_model.setupModel ();

		score = 1000;
		power = 100;
		paused = false;

		add_data ();
	
		susceptible_text = GameObject.Find ("susceptible_text").GetComponent<Text> ();
		infected_text = GameObject.Find ("infected_text").GetComponent<Text> ();
		recovered_text = GameObject.Find ("recovered_text").GetComponent<Text> ();
		vaccine_text = GameObject.Find ("Vaccines").GetComponent<Text> ();
		score_text = GameObject.Find ("Score").GetComponent<Text> ();
		power_text = GameObject.Find ("Power").GetComponent<Text> ();
		day_text = GameObject.Find ("Days").GetComponent<Text> ();
		pause_menu = GameObject.Find ("PauseMenu").GetComponent<Image> ();
		vaccine_menu = GameObject.Find ("VaccineMenu").GetComponent<Image> ();

		//graph = GameObject.Find ("Graph").GetComponent<Image> ();
		//graph.gameObject.SetActive (false);

		updateText ();


	}

	/**
	 *Method that updates the text with the current values for each UI element.
	 **/
	void updateText(){

		susceptible_text.text = "Susceptible: " + sir_model.get_susceptible_count ();

		infected_text.text = "Infected: " + sir_model.get_infected_count ();

		recovered_text.text = "Recovered: " + sir_model.get_recovered_count ();

		vaccine_text.text = "Vaccines: " + sir_model.get_vaccine_counters ();

		score_text.text = "Score: " + score;

		power_text.text = "Power: " + power;

		day_text.text = "Day: " + sir_model.get_days ();

	}

	/**
	 *Method that calculates the current score. TO BE WORKED ON/
	 **/
	void calculateScore(){

		score = score - (sir_model.get_infected_count () * 10)  - (sir_model.get_susceptible_count())
				+ (sir_model.get_recovered_count()*5) ;
	
	}

	/**
	 *Method to calculate the current power. TO BE WORKED ON.
	 **/
	void calculatePower(){
	
		if (power <= 25) {

			return;
		
		} 
		else {

			power = power - ((sir_model.get_vaccine_counters()-2) * 25);
		
		}
	
	}

	void add_data(){
	
		day.Add (sir_model.get_days ());
		susceptible_count.Add (sir_model.get_susceptible_count ());
		infected_count.Add (sir_model.get_infected_count ());
		recovered_count.Add (sir_model.get_recovered_count ());
	
	}

	/**
	 *Method to update the current state of the game. Checks for the press of a space, so the player can pause the
	 *movement of characters. Also checks to see if the pause menu is activated.
	 **/
	void Update(){

		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (2)) {

			if (pause_menu.gameObject.activeInHierarchy == true) {
			
				Time.timeScale = 0;

			
			} else if (Input.GetKeyDown (KeyCode.Space)) {
			
				if (paused == true) {
					
					Time.timeScale = 1;

					paused = false;

				} 
				else if (paused == false) {
				
					Time.timeScale = 0;

					paused = true;
				
				}
				
			
			} 
			else if (Time.fixedTime >= time_to_choose) {
				
				vaccine_menu.gameObject.SetActive (true);

				Time.timeScale = 0;

				time_to_choose = Time.fixedTime + 5.0f;

			//	day.Add (sir_model.get_days ());
			//	susceptible_count.Add (sir_model.get_susceptible_count ());

				add_data ();

			
			}
			else {
				

				calculatePower ();

				calculateScore ();

				updateText ();

			}

		}

	}
}
