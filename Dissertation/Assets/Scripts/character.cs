using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using System.IO;

/**
 *Class that describes the behavior of the characters that move around on the game board. Controls the time between
 *moves for each unit, as well as their random choice of direction. This also provides methods to handle the spread
 *of infection through unit collision, as well as the recovery of units through vaccination or "natural" recovery.
 **/
public class character : movementController {

	private SpriteRenderer renderer;
	private string status;
	private sirGameModel sir;
	float time_to_move;
	float time_to_recover;
	public AudioClip infect_sound;
	public AudioClip recover_sound;
	public AudioClip game_over_sound;

	/**
	 *Method to star the character script.
	 **/
	protected override void Start () {

		sir = GameObject.Find ("gameManager").GetComponent<sirGameModel> ();

		renderer = GetComponent<SpriteRenderer> ();

		time_to_move = Time.fixedTime + 0.5f;

		time_to_recover = Time.fixedTime + 5.0f;

		color_cue ();

		base.Start();
	}

	/**
	 *Method for a character to attempt a move in a direction. Takes in two ints to represent x and y cardinal
	 *directions, chosen randomly. It passes these values into the movementController method.
	 **/
	protected override void attemptMove <T> (int x_direction, int y_direction){

		base.attemptMove <T> (x_direction, y_direction); 

	}
		
	/**
	 *Method to move the character. It randomly chooses a value between 0 and 100 to determine the direction of 
	 *movement. It calls attemptMove once the directions are randomly chosen to ensure that the movement is valid.
	 **/
	public void moveCharacter(){

		int x_direction = 0;
		int y_direction = 0;


		int x_random_chance = Random.Range (0, 100);
		int y_random_chance = Random.Range (0 , 100);

		if (x_random_chance > (50)) {
		
			x_direction = 1;

		} 
		else {
		
			x_direction = -1;

		}

		if (y_random_chance > 50) {
		
			y_direction = 1;
		
		}
		else {
		
			y_direction = -1;

		}

		attemptMove <character> (x_direction, y_direction);

	}

	/**
	 *Method to react to a character collision. When two characters collide, it records the character that is hit and
	 *then passes that into the infect method.
	 **/
	protected override void onCantMove <T> (T component){

		character hit_character = component as character;

		infect (hit_character);

	}

	/**
	 *Method to infect a character after a game collision. It takes in the hit character and then makes a call to the
	 *SIR model class's infect method, passing in the current Game Object and the hit character.
	 **/
	public void infect (character hit_character){

		int current_infect_count = sir.get_infected_count ();

		sir.infect (this.gameObject, hit_character.gameObject);

		color_cue ();

		if (sir.get_infected_count() > current_infect_count) {

			soundController.instance.PlaySingle (infect_sound);

		} 

	}

	/**
	 *Method to call the SIR model class's recover method on the current Game Object.
	 **/
	public void recover(){
	
		sir.recover (this.gameObject);

		color_cue ();

		if (sir.get_individual_status (this.gameObject) == "recovered") {

			soundController.instance.PlaySingle (recover_sound);

		} 
	
	}

	/**
	 *Method to change the color of the current character, dependent on the infection status of the individual. 
	 **/
	public void color_cue(){

		if (sir.get_individual_status (this.gameObject) == "infected") {

			renderer.color = Color.green;	

		} else if (sir.get_individual_status (this.gameObject) == "recovered") {
		
			renderer.color = Color.red;
		
		} else if (sir.get_individual_status (this.gameObject) == "susceptible") {
		
			renderer.color = Color.blue;
		
		}
	
	}

	/**
	 *Method that calls the vaccinate() method when a player clicks on an individual. This will only occur if the
	 *individual that is clicked on is of the appropriate infection status (i.e. "susceptible"). It calls the 
	 *color_cue() method at the end to notify the player of the change (if there is one).
	 **/
	void OnMouseDown(){

		if (sir.get_vaccine_counters () > 0 && sir.get_individual_status(this.gameObject) == "susceptible") {
		
			vaccinate ();
		
		}

		color_cue ();
			
	}

	//AS ABOVE. TRY TO GET IT TO APPEAR ABOVE THE WALL AND TO HAVE IT BOUNCE OFF WALL IF PLACED POORLY
	/**void OnMouseDrag(){
	
		float distance_to_screen = Camera.main.WorldToScreenPoint (gameObject.transform.position).z;

		Vector3 position_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, 
			                        Input.mousePosition.y, distance_to_screen));

		transform.position = new Vector3 (position_move.x, position_move.y, position_move.z);


	}**/

	/**
	 *Method to vaccinate the individual. Calls the sirGameModel class's vaccinate and passes in the current
	 *game object.
	 **/
	void vaccinate(){
	
		sir.vaccinate (this.gameObject);

		if (sir.get_individual_status (this.gameObject) == "recovered") {

			soundController.instance.PlaySingle (recover_sound);

		} 

	}

	/**
	 *Method to update the current state of the Game Object at a fixed rate. Movement happens every half-second and 
	 *a "day" according to the SIR model is 5 seconds.
	 **/
	void FixedUpdate(){

		color_cue ();

		if ((sir.get_recovered_count() == sir.get_population().Count) || 
			(sir.get_susceptible_count() + sir.get_recovered_count() == sir.get_population().Count)) {
	
			soundController.instance.PlaySingle (game_over_sound);
			sir.set_done_flag(true);

			SceneManager.LoadScene (3);

		}

		if (Time.fixedTime >= time_to_move) {

			moveCharacter();

			if (sir.get_individual_status (this.gameObject) == "infected" && Time.fixedTime >= time_to_recover) {

				recover ();

				time_to_recover = Time.fixedTime + 5.0f;

			}
				

			time_to_move = Time.fixedTime + 0.5f;
			
		}
			
	}

}