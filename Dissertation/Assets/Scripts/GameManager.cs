using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;
	private boardManager board_script;
	private sirGameModel sir_model;
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

	// Use this for initialization
	void Awake () {

		if (instance == null) {

			instance = this;

		} else if (instance != this) {
		
			Destroy (gameObject);

		}

		DontDestroyOnLoad (gameObject);

		board_script = GetComponent<boardManager> ();
		sir_model = GetComponent <sirGameModel> ();
		time_to_choose = Time.fixedTime + 5.0f;
			
		InitGame ();

	}

	//initializes the game for each level
	void InitGame(){
	
		board_script.SetupScene ();
		sir_model.setupModel ();

		score = 1000;
		power = 100;
		paused = false;

		susceptible_text = GameObject.Find ("susceptible_text").GetComponent<Text> ();
		infected_text = GameObject.Find ("infected_text").GetComponent<Text> ();
		recovered_text = GameObject.Find ("recovered_text").GetComponent<Text> ();
		vaccine_text = GameObject.Find ("Vaccines").GetComponent<Text> ();
		score_text = GameObject.Find ("Score").GetComponent<Text> ();
		power_text = GameObject.Find ("Power").GetComponent<Text> ();
		day_text = GameObject.Find ("Days").GetComponent<Text> ();
		pause_menu = GameObject.Find ("PauseMenu").GetComponent<Image> ();
		vaccine_menu = GameObject.Find ("VaccineMenu").GetComponent<Image> ();

		updateText ();


	}

	void updateText(){

		susceptible_text.text = "Susceptible: " + sir_model.get_susceptible_count ();

		infected_text.text = "Infected: " + sir_model.get_infected_count ();

		recovered_text.text = "Recovered: " + sir_model.get_recovered_count ();

		vaccine_text.text = "Vaccines: " + sir_model.get_vaccine_counters ();

		score_text.text = "Score: " + score;

		power_text.text = "Power: " + power;

		day_text.text = "Day: " + sir_model.get_days ();

	}

	void calculateScore(){

		score = score - (sir_model.get_infected_count () * 10)  - (sir_model.get_susceptible_count())
				+ (sir_model.get_recovered_count()*5) ;
	
	}

	void calculatePower(){
	
		if (power <= 25) {

			return;
		
		} 
		else {

			power = power - ((sir_model.get_vaccine_counters()-2) * 25);
		
		}
	
	}

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
			
			}
			else {
				

				calculatePower ();

				calculateScore ();

				updateText ();

			}

		}

	}
}
