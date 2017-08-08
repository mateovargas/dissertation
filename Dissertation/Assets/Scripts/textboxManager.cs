using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* Class that defines the controller for all the textboxes in the game. Defines the text file to load (defined in Unity,
* the stop points in the text, and different methods to handle text progression using the mouse.
**/
public class textboxManager : MonoBehaviour {


	public Text text; //The text to display.
	public TextAsset text_file; //The text file to load.
	public Button continue_text; //Button to continue in certain scenarios.
	public Button repeat_text; //Button to repeat text in certain scenarios.
	public string[] text_lines; //An array of strings that contains each line in the text file. 
	public int current_line; //Index of the current line.
	public int hide_ship; //Index where to hide a sprite in the scene
	public int repeat_instructions; //Index where to begin the repeat of instructions.
	public int end_at_line; //Index where the text file ends.
	public SpriteRenderer sprite_renderer_one; //Sprite to render.
	public SpriteRenderer sprite_renderer_two; //Sprite to render.


	/**Method to initialize the textManager and load the text files. Checks to make sure the text file is not null or
	 * empty and, if not, loads them into the text_lines array.
	 * */
	void Start () {

		continue_text.gameObject.SetActive (false);
		repeat_text.gameObject.SetActive (false);
		sprite_renderer_one.enabled = true;
		sprite_renderer_two.enabled = false;
	
		if (text_file != null) {

			text_lines = (text_file.text.Split('\n'));

		}

		if (end_at_line == 0) {
		
			end_at_line = text_lines.Length - 1;

		}
			
	}


	/**
	 * Method to update the scene with current information. Uses a press of the left mouse button to progress text.
	 * Calls specific methods and enables buttons depending on line index AND current scene.
	 * */
	void Update(){

		if ((current_line == end_at_line) && (SceneManager.GetActiveScene().buildIndex == 1 )) {

			continue_text.gameObject.SetActive (true);
			repeat_text.gameObject.SetActive (true);
			return;

		}

		text.text = text_lines [current_line];

		if ((Input.GetKeyDown(KeyCode.Mouse0)) && current_line < end_at_line) {

			current_line = current_line + 1;

		}

		if (current_line == hide_ship && (SceneManager.GetActiveScene().buildIndex == 1 )) {

			sprite_renderer_one.enabled = false;
			sprite_renderer_two.enabled = true;

		}

	}

	/**
	 * Method to load the next scene or accomplish other tasks after completing the text. 
	 * */
	public void continuePress(){

		if (SceneManager.GetActiveScene ().buildIndex == 1) {

			SceneManager.LoadScene (2);

		}

	}

	/**
	 * Method to repeat text when necessary.
	 * */
	public void repeatPress(){
	
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			
			continue_text.gameObject.SetActive (false);
			repeat_text.gameObject.SetActive (false);
			current_line = 9;

		}

	}

}
