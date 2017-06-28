using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class character : movementController {

	private Animator animator;

	protected override void Start () {

		animator = GetComponent<Animator>();
		base.Start();
	}

	protected override void attemptMove <T> (int x_direction, int y_direction){

		base.attemptMove <T> (x_direction, y_direction); 

	}

	public void moveCharacter(){

		int x_direction = 0;
		int y_direction = 0;


		x_direction = Random.Range (0, 1);
		y_direction = Random.Range (0,1);

		attemptMove <character> (x_direction, y_direction);

	}

	protected override void onCantMove <T> (T component){

		//Character hit_character = component as Character;
		//infect?? this may be where to call it
		//trigger animator if infected?

	}

}