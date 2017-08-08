using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 *Class that defines the countdown at the beginning of gameplay. 
 **/
public class countdownScript : MonoBehaviour {

	private gameManager game_manager;
	private Text countdown_text;
	private string[] countdown_strings = new string[] {"Ready?", "3", "2", "1", "GO!"};

	float time;
	int counter;

	/**
	 *Method to set the flag in game_manager to true and deactivate countdown UI.
	 **/
	public void setCountDown(){
	
		game_manager = GameObject.Find ("gameManager").GetComponent<gameManager> ();

		game_manager.countDownDone = true;

		this.gameObject.SetActive (false);
	
	}

	/**
	 *Method to initialize the countdown to count down every second until Go!
	 **/
	void Start(){

		countdown_text = GameObject.Find ("countdown_text").GetComponent<Text> ();

		time = Time.fixedTime + 1.0f;

		counter = 0;

		countdown_text.text = countdown_strings [counter];

	}

	/**
	 *Method to update the countdown text. 
	 **/
	void Update(){

		if (counter < countdown_strings.Length) {

			if (Time.fixedTime >= time) {
		
				countdown_text.text = countdown_strings [counter];
				counter++;

				time = Time.fixedTime + 1.0f;
			}
	
		} 
		else {
		
			setCountDown ();
		
		}
	
	}
}
