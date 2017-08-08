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
	
	}

	/**
	 *Method to load the next level of the game. Exits game after the last level.
	 **/
	public void onNextPress(){
				
		Application.Quit ();
	
	}


}
