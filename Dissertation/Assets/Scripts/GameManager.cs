using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;

	private Dictionary<int, string> population;
	private bool doingSetup = true;

	//Called before any start functions
	void Awake(){
		//Check if instance already exists
		if (instance == null) {
			//if not, set it to this
			instance = this;

		} //if instance exists and is not this
		else if (instance != this) {
			//destroy it
			Destroy (gameObject);

		}

		DontDestroyOnLoad (gameObject);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
