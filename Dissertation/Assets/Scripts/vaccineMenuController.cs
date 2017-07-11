using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *Class that dictates the behavior of the vaccine menu. This pops up regularly to assess whether the player wants to
 *make more vaccines.
 **/
public class vaccineMenuController : MonoBehaviour {

	public Image vaccine_menu;
	public Button yes_button;
	public Button no_button;
	public Text vaccine_text;

	/**
	 *Method to initialize the menu. 
	 **/
	void Start () {

		vaccine_menu = vaccine_menu.GetComponent<Image> ();

		vaccine_text = vaccine_text.GetComponent<Text> ();
		vaccine_text.text = "Would you like to make a vaccine?";

		yes_button = yes_button.GetComponent<Button> ();

		no_button = no_button.GetComponent<Button> ();

		vaccine_menu.gameObject.SetActive(false);

	}


	/**
	 *Method that adds a vaccine to the vaccine counter when the yes button is pressed on the menu.
	 **/
	public void yesPress(){
	
		sirGameModel sir = GameObject.Find ("gameManager").GetComponent<sirGameModel> ();
		sir.set_vaccine_counter (sir.get_vaccine_counters () + 1);

		gameManager.instance.calculatePower ();

		vaccine_menu.gameObject.SetActive (false);
		Time.timeScale = 1;

	}

	/**
	 *Method that closes the vaccine menu when the no button is pressed.
	 **/
	public void noPress(){
	
		vaccine_menu.gameObject.SetActive (false);
		Time.timeScale = 1;
	
	}
}
