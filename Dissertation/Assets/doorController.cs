using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *Class that dictates the behavior of the door tiles. 
 **/
public class doorController : MonoBehaviour {


	private bool door_open;
	private SpriteRenderer renderer;
	private BoxCollider2D box_collider;

	/**
	 *Initializes all doors to be open at the beginning.
	 **/
	void Start(){

		renderer = GetComponent<SpriteRenderer> ();
		box_collider = GetComponent<BoxCollider2D> ();

		door_open = true;

		renderer.enabled = false;
		box_collider.enabled = false;

	
	}

	/**
	 *Method to control the opening and closing of the door. 
	 **/
	void doorControl(){
	
		if (door_open == true) {

			renderer.enabled = true;
			box_collider.enabled = true;

			door_open = false;
		
		} 
		else if (door_open == false) {

			renderer.enabled = false;
			box_collider.enabled = false;
		
			door_open = true;

		}
	
	}

	/**
	 *Method to check for key presses every frame. Each door is tagged with DoorOne-DoorFour respectively. The
	 *key pressed of Alpha1-Alpha4, as well as the tag, determine which door to open when a key press is detected.
	 **/
	void Update(){


		if (Input.GetKeyDown (KeyCode.Alpha1) && this.tag == "DoorOne") {
		
			doorControl ();
		
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha2) && this.tag == "DoorTwo") {
		
			doorControl ();
		
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha3) && this.tag == "DoorThree") {
		
			doorControl ();

		}
		else if(Input.GetKeyDown(KeyCode.Alpha4) && this.tag == "DoorFour"){
		
			doorControl();
		
		}
	
	}

}
