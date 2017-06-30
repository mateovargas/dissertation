using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using System.IO;

public class character : movementController {

	private SpriteRenderer renderer;
	private string status;
	private sirGameModel sir;
	private bool can_move = true;


	protected override void Start () {

		sir = GameObject.Find ("gameManager").GetComponent<sirGameModel> ();

		renderer = GetComponent<SpriteRenderer> ();

		base.Start();
	}

	protected override void attemptMove <T> (int x_direction, int y_direction){

		base.attemptMove <T> (x_direction, y_direction); 

	}

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

	protected override void onCantMove <T> (T component){

		character hit_character = component as character;

		infect (hit_character);

	}

	public void infect (character hit_character){


		sir.infect (this.gameObject, hit_character.gameObject);

	}

	public void recover(){
	
		sir.recover (this.gameObject);
	
	}

	public void color_cue(){

		if (sir.get_individual_status (this.gameObject) == "infected") {
		
			renderer.color = Color.blue;	

		} 
		else if (sir.get_individual_status (this.gameObject) == "recovered") {
		
			renderer.color = Color.green;
		
		}
	
	}

	void Update(){

		if (sir.update_timer) {
		
			sir.level_timer = sir.level_timer + Time.deltaTime * 1;

			sir.timer_in_seconds = Mathf.Round (sir.level_timer);

		}

		if ((sir.get_recovered_count() == sir.get_population().Count) || 
			(sir.get_susceptible_count() + sir.get_recovered_count() == sir.get_population().Count)) {

			sir.update_timer = false;
	
			sir.print_data();

			SceneManager.LoadScene (0);

		
		}
			
		if (sir.timer_in_seconds % 2 == 0) {
		
			moveCharacter ();

		}
			

		if (sir.get_individual_status (this.gameObject) == "infected" && sir.timer_in_seconds % 15 == 0) {
		
			recover ();

		}

		sir.add_data ();
		color_cue ();

	}

}