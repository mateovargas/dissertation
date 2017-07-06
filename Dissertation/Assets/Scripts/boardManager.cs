using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

/**
 *This class controls the layout of the board. Instantiates the floor tiles, the wall tiles, the door tiles, and the 
 *individual tiles at the beginning of the third scene (the main game scene).
 **/
public class boardManager : MonoBehaviour {

	public int columns;
	public int rows;
	public int individual_count;
	public GameObject[] floor_tiles;
	public GameObject[] wall_tiles;
	public GameObject[] outer_wall_tiles;
	public GameObject[] individual_tiles;

	private Transform board_holder;
	private List <Vector3> grid_positions = new List<Vector3>();
	private List <GameObject> characters = new List<GameObject> ();

	/**
	 *Method that initializes a list of all the possible grid locations on the game board.
	 **/
	void initializeList(){

		grid_positions.Clear ();

		for (int x = -10; x < columns+6; x++) {

			for (int y = -6; y < rows+2; y++) {

				grid_positions.Add (new Vector3 (x, y, 0f));

			}

		}
			
	}

	/**
	 *Method to set the game board up. Instantiates all the floor tiles and the outer wall tiles for the game board.
	 **/
	void boardSetup(){
	
		board_holder = new GameObject ("Board").transform;

		for (int x = -10; x < columns+6; x++) {

			for (int y = -6; y < rows+2; y++) {

				GameObject to_instantiate = floor_tiles[0];
				GameObject instance;

				if(x == -10 || x == columns+5 || y == -6 || y == rows+1){

					to_instantiate = wall_tiles[0];
					Vector3 vector = new Vector3 (x, y, 0f);
					instance = Instantiate(to_instantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(board_holder);
					grid_positions.Remove (vector);

				}
				else{
					
					instance = Instantiate(to_instantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(board_holder);
				
				}

			}

		}

	}

	/**
	 *Method to select a random positions vector from the list created in initializeList(). Once selected, it removes
	 *that position from the list and returns the selected vector.
	 **/
	Vector3 RandomPosition(){
	
		int random_index = Random.Range (0, grid_positions.Count);
		Vector3 random_position = grid_positions [random_index];
		grid_positions.RemoveAt (random_index);
		return random_position;

	}

	/**
	 *Method to layout the character tiles at random on the game board. The random positions are determined using the
	 *RandomPosition() method. Each character is then placed in a list, to keep track of each individual.
	 **/
	void LayoutIndividualAtRandom(GameObject[] array){

		for (int i = 0; i < individual_count; i++) {
		
			Vector3 random_position = RandomPosition ();
			GameObject tile = array [0];
			GameObject instance = Instantiate (tile, random_position, Quaternion.identity);
			characters.Add (instance);

		}

	}

	/**
	 *Method to layout the inner walls that make the corner rooms. Instantiates both the inner walls and the doors.
	 *After instantiating them, the position they occupy is removed from the list of positions to prevent character
	 *tiles being spawned on top of them.
	 **/
	void LayoutInnerWalls(){
		
		GameObject wall_tile = wall_tiles [0];
		GameObject door_tile_one = wall_tiles [1];
		GameObject door_tile_two = wall_tiles [2];
		GameObject door_tile_three = wall_tiles [3];
		GameObject door_tile_four = wall_tiles [4];


		Vector3 wall_vec = new Vector3 (-9, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-8, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, -3, 0f);
		Instantiate (door_tile_three, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, -4, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, -5, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (16, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (15, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, -2, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, -3, 0f);
		Instantiate (door_tile_four, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, -4, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, -5, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (16, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (15, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, 10, 0f);
		Instantiate (door_tile_two, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, 11, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (14, 12, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-9, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-8, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 9, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 10, 0f);
		Instantiate (door_tile_one, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 11, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 12, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);


	}

	/**
	 *Method to set up the game board over all. It calls each of the required methods in their required order, with
	 *the list being first and laying out individuals being last.
	 **/
	public void SetupScene(){
	
		initializeList ();

		boardSetup ();

		LayoutInnerWalls ();

		LayoutIndividualAtRandom (individual_tiles);

	}

	/**
	 *Method to get the list of characters.
	 **/
	public List <GameObject> getCharacters(){
	
		return characters;

	}

}
