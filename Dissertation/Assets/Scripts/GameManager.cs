using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;
	private boardManager boardScript;
	private int day = 1;

	// Use this for initialization
	void Awake () {

		if (instance == null) {

			instance = this;

		} else if (instance != this) {
		
			Destroy (gameObject);

		}

		DontDestroyOnLoad (gameObject);

		boardScript = GetComponent<boardManager> ();

		InitGame ();

	}

	//initializes the game for each level
	void InitGame(){
	
		boardScript.SetupScene ();

	}




	
}
