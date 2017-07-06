using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {


	private bool door_open;
	private SpriteRenderer renderer;
	private BoxCollider2D box_collider;

	void Start(){

		renderer = GetComponent<SpriteRenderer> ();
		box_collider = GetComponent<BoxCollider2D> ();

		door_open = true;

		renderer.enabled = false;
		box_collider.enabled = false;

	
	}


	void doorControl(){
	
		if (door_open == true) {

			renderer.enabled = true;
			box_collider.enabled = true;

			//renderer.gameObject.SetActive (true);

			door_open = false;

			//Debug.Log ("Render is: " + renderer.gameObject.activeInHierarchy);
		
		} 
		else if (door_open == false) {

			renderer.enabled = false;
			box_collider.enabled = false;
		

			door_open = true;

		
		}
	
	}

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
