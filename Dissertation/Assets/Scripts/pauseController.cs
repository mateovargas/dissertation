using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *Class that defines a controller for the pause menu during gameplay. This menu is activated by pressing the escape
 *button. Provides the player with the options to resume, quit to the menu, or to quit the application entirely.
 **/
public class pauseController : MonoBehaviour {


	public Image pause_menu;
	public Button resume_text;
	public Button exit_text;
	public Button quit_text;
	public Text pause_text;

	/**
	 *Method to initialize the pause menu. 
	 **/
	void Start () {

		pause_menu = pause_menu.GetComponent<Image> ();

		pause_text = pause_text.GetComponent<Text> ();
		pause_text.text = "PAUSED";

		resume_text = resume_text.GetComponent<Button> ();

		exit_text = exit_text.GetComponent<Button> ();

		quit_text = quit_text.GetComponent<Button> ();

		pause_menu.gameObject.SetActive(false);
		
	}

	/**
	 *Method that calls the pause function when the resume button is pressed. Only available when the resume menu is
	 *active.
	 **/
	public void resumePress(){
	
		pause ();
		
	}

	/**
	 *Method that loads the main menu when the exit to main menu button is pressed. 
	 **/
	public void exitPress(){
	
		SceneManager.LoadScene (0);
	
	}

	/**
	 *Method to exit the application when the quit game is presssed. 
	 **/
	public void quitPress(){
	
		Application.Quit ();
	
	}

	/**
	 *Method to pause the game. 
	 **/
	public void pause(){

			if (pause_menu.gameObject.activeInHierarchy == false) {

				pause_menu.gameObject.SetActive (true);

				Time.timeScale = 0;

			} else {

				pause_menu.gameObject.SetActive (false);

				Time.timeScale = 1;


			}

		}
		
	/**
	 *Method to check for the escape key press and call the pause method. 
	 **/
	void Update(){
	
		if (Input.GetKeyDown (KeyCode.Escape)) {
		
			pause ();

		}
	
	}
		
}
