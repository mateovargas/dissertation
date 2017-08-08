using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *Class that defines the sound controller to control all the sounds in the game. 
 **/
public class soundController : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static soundController instance = null;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;


	/**
	 *Method to initialize the sound controller. Follows the singleton pattern. 
	 **/
	void Awake () {

		if (instance == null) {
		
			instance = this;
		
		} 
		else if (instance != this) {
		
			Destroy (gameObject);
		
		}

		DontDestroyOnLoad (gameObject);

	}

	/**
	 *Method to play a single sound. 
	 **/
	public void PlaySingle (AudioClip clip){
	
		efxSource.clip = clip;

		efxSource.Play ();
	
	}

	/**
	 *Method to randomize sound. Remained unused in prototype. 
	 **/
	public void RandomizeSfx(params AudioClip[] clips){
	
		int randomIndex = Random.Range (0, clips.Length);

		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;

		efxSource.Play ();
	
	}

}

