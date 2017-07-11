using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class graphButtonController : MonoBehaviour {

	public Button next_level;
	private Text next_text;
	private gameManager game_manager;

	void Start(){
	
		next_level = next_level.GetComponent<Button> ();
		game_manager = gameManager.instance;

		//next_text = next_text.GetComponent<Text> ();
		//next_text.text = "Return to main menu.";

	
	}

	public void onNextPress(){

		Destroy (game_manager);
		SceneManager.LoadScene (0);
	
	}


}
