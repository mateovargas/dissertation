using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *Abstract class that dictates the underlying behavior of unit movement. Used an abstract class to allow for a player
 *character, however, only AI characters were used. 
 **/
public abstract class movementController : MonoBehaviour {

	public float move_time = 0.1f;
	public LayerMask blocking_layer;

	private BoxCollider2D box_collider;
	private Rigidbody2D rigidbody_2d;
	private float inverse_move_time;


	/**
	 *Method that initializes the components needed for movement for each character. This is called in character.cs 
	 **/
	protected virtual void Start () {

		box_collider = GetComponent<BoxCollider2D> ();
		rigidbody_2d = GetComponent<Rigidbody2D> ();
		inverse_move_time = 1f / move_time; //makes for more efficient computations

	}

	/**
	 *Method to move a unit. Takes in an x and y direction to move in and returns a RaycastHit2D component that 
	 *dictates whether a move is possible or not.
	 **/
	protected bool move(int x_direction, int y_direction, out RaycastHit2D hit){
	
		Vector2 start = transform.position; //casting this vector 3 into vector 2
		Vector2 end = start + new Vector2(x_direction, y_direction);

		box_collider.enabled = false;
		hit = Physics2D.Linecast (start, end, blocking_layer);
		box_collider.enabled = true;

		//Checking if space is open
		if (hit.transform == null) {
		
			StartCoroutine (smoothMovement (end));
			return true;

		}

		return false;

	}

	/**
	 *Method that checks to see if a move is possible. It takes in an x and y direction and, if a move is not possible,
	 *calls the onCantMove method in character.cs.
	 **/
	protected virtual void attemptMove <T> (int x_direction, int y_direction) where T : Component{
	
		RaycastHit2D hit;
		bool can_move = move (x_direction, y_direction, out hit);

		if (hit.transform == null) {
		
			return;	
		
		}

		T hit_component = hit.transform.GetComponent<T> ();

		if (!can_move && hit_component != null) {
			
			onCantMove (hit_component);

		}
	
	}

	/**
	 *Method that enables the units to move smoothly throughout the board. 
	 **/
	protected IEnumerator smoothMovement(Vector3 end){
	
		float square_remaining_distance = (transform.position = end).sqrMagnitude; //computationally cheaper than magnitude

		while (square_remaining_distance > float.Epsilon) {

			Vector3 new_position = Vector3.MoveTowards (rigidbody_2d.position, end, inverse_move_time * Time.deltaTime);
			rigidbody_2d.MovePosition (new_position);
			square_remaining_distance = (transform.position - end).sqrMagnitude;
			yield return null;

		}

	}

	/**
	 *Abstact method to handle a collision. 
	 **/
	protected abstract void onCantMove <T> (T component) where T : Component;

}
