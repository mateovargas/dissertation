using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;
	private boardManager board_script;
	private sirGameModel sir_model;

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

		InitGame ();

	}

	//initializes the game for each level
	void InitGame(){
	
		board_script.SetupScene ();
		sir_model.setupModel ();

	}

}
