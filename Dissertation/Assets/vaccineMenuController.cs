using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vaccineMenuController : MonoBehaviour {

	public Image vaccine_menu;
	public Button yes_button;
	public Button no_button;
	public Text vaccine_text;

	void Start () {

		vaccine_menu = vaccine_menu.GetComponent<Image> ();

		vaccine_text = vaccine_text.GetComponent<Text> ();
		vaccine_text.text = "Would you like to make a vaccine?";

		yes_button = yes_button.GetComponent<Button> ();

		no_button = no_button.GetComponent<Button> ();

		vaccine_menu.gameObject.SetActive(false);

	}


	public void yesPress(){
	
		sirGameModel sir = GameObject.Find ("gameManager").GetComponent<sirGameModel> ();
		sir.set_vaccine_counter (sir.get_vaccine_counters () + 1);

		vaccine_menu.gameObject.SetActive (false);
		Time.timeScale = 1;

	}

	public void noPress(){
	
		vaccine_menu.gameObject.SetActive (false);
		Time.timeScale = 1;
	
	}
}
