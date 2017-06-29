using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class character : movementController {

	//private Animator animator;
	private string status;
	private sirGameModel sir;

	protected override void Start () {

		sir = GameObject.Find ("gameManager").GetComponent<sirGameModel> ();
		//animator = GetComponent<Animator>();
		base.Start();
	}

	protected override void attemptMove <T> (int x_direction, int y_direction){

		base.attemptMove <T> (x_direction, y_direction); 

	}

	public void moveCharacter(){

		int x_direction = 0;
		int y_direction = 0;


		int x_random_chance = Random.Range (0, 1);
		int y_random_chance = Random.Range (0 , 1);

		if (x_random_chance > (1 / 2)) {
		
			x_direction = 1;

		} 
		else {
		
			x_direction = -1;

		}

		if (y_random_chance > 1 / 2) {
		
			y_direction = 1;
		
		}
		else {
		
			y_direction = -1;

		}

		attemptMove <character> (x_direction, y_direction);

	}

	protected override void onCantMove <T> (T component){

		//Character hit_character = component as Character;
		character hit_character = component as character;

		infect (hit_character);

		//moveCharacter ();

		//infect?? this may be where to call it
		//trigger animator if infected?

	}

	public void infect (character hit_character){


		sir.infect (this.gameObject, hit_character.gameObject);

	}

	public void recover(){
	
		sir.recover (this.gameObject);
	
	}

	void Update(){
	
	//	Debug.Log ("UPDATING");
		moveCharacter ();
	
	}

}