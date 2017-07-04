using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

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

	void initializeList(){

		grid_positions.Clear ();

		for (int x = -10; x < columns+6; x++) {

			for (int y = -6; y < rows+2; y++) {

				grid_positions.Add (new Vector3 (x, y, 0f));

			}

		}
			
	}

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

	Vector3 RandomPosition(){
	
		int random_index = Random.Range (0, grid_positions.Count);
		Vector3 random_position = grid_positions [random_index];
		grid_positions.RemoveAt (random_index);
		return random_position;

	}

	void LayoutIndividualAtRandom(GameObject[] array){


		for (int i = 0; i < individual_count; i++) {
		
			Vector3 random_position = RandomPosition ();
			GameObject tile = array [0];
			GameObject instance = Instantiate (tile, random_position, Quaternion.identity);
			characters.Add (instance);

		}

	}


	void LayoutInnerWalls(){
		
		GameObject wall_tile = wall_tiles [0];
		/**Vector3 quarantine_wall_one = new Vector3 (4, 7, 0f);
		GameObject wall_tile = wall_tiles [0];
		Instantiate (wall_tile, quarantine_wall_one, Quaternion.identity);
		grid_positions.Remove(quarantine_wall_one);


		Vector3 quarantine_wall_two = new Vector3 (4, 6, 0f);
		Instantiate (wall_tile, quarantine_wall_two, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_two);

		Vector3 quarantine_wall_three = new Vector3 (4, 5, 0f);
		Instantiate (wall_tile, quarantine_wall_three, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_three);

		Vector3 quarantine_wall_four = new Vector3 (4, 4, 0f);
		Instantiate (wall_tile, quarantine_wall_four, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_four);

		Vector3 quarantine_wall_six = new Vector3 (5, 4, 0f);
		Instantiate (wall_tile, quarantine_wall_six, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_six);

		Vector3 quarantine_wall_seven = new Vector3 (6, 4, 0f);
		Instantiate (wall_tile, quarantine_wall_seven, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_seven);

		Vector3 quarantine_wall_eight = new Vector3 (7, 4, 0f);
		Instantiate (wall_tile, quarantine_wall_eight, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_eight);

		Vector3 quarantine_wall_nine = new Vector3 (7, 5, 0f);
		Instantiate (wall_tile, quarantine_wall_nine, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_nine);

		Vector3 quarantine_wall_ten = new Vector3 (7, 6, 0f);
		Instantiate (wall_tile, quarantine_wall_ten, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_ten);

		Vector3 quarantine_wall_eleven = new Vector3 (7, 7, 0f);
		Instantiate (wall_tile, quarantine_wall_eleven, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_eleven);

		Vector3 quarantine_wall_twelve = new Vector3 (6, 7, 0f);
		Instantiate (wall_tile, quarantine_wall_twelve, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_twelve);

		Vector3 quarantine_wall_thirteen = new Vector3 (5, 7, 0f);
		Instantiate (wall_tile, quarantine_wall_thirteen, Quaternion.identity);
		grid_positions.Remove (quarantine_wall_thirteen);
					

		Vector3 inside_quarantine = new Vector3 (5, 6, 0f);
		grid_positions.Remove (inside_quarantine);

		inside_quarantine = new Vector3 (6, 6, 0f);
		grid_positions.Remove (inside_quarantine);

		inside_quarantine = new Vector3 (5, 5, 0f);
		grid_positions.Remove (inside_quarantine);

		inside_quarantine = new Vector3 (6, 5, 0f);
		grid_positions.Remove (inside_quarantine);**/

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
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
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
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
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
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
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
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 11, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);

		wall_vec = new Vector3 (-7, 12, 0f);
		Instantiate (wall_tile, wall_vec, Quaternion.identity);
		grid_positions.Remove (wall_vec);


	}

	public void SetupScene(){
	
		initializeList ();

		boardSetup ();

		LayoutInnerWalls ();

		LayoutIndividualAtRandom (individual_tiles);

	}

	public List <GameObject> getCharacters(){
	
		return characters;

	}

}
