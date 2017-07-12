using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *Class that describes the behavior of the button on the graph scene. 
 **/
public class graphButtonController : MonoBehaviour {

	public Button next_level;
	private Text next_text;

	void Start(){
	
		next_level = next_level.GetComponent<Button> ();
		//GameObject game_manager = GameObject.Find ("gameManager");
	
	}

	/**
	 *Method to load the next level of the game. Exits game after the last level.
	 **/
	public void onNextPress(){

		if (gameManager.instance.level >= 4) {
		
			Application.Quit ();
		
		}

		SceneManager.LoadScene (2);
	
	}


}
