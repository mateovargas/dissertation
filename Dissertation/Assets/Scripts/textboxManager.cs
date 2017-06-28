using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textboxManager : MonoBehaviour {


	public Text text;
	public TextAsset text_file;
	public Button continue_text;
	public Button repeat_text;
	public string[] text_lines;
	public int current_line;
	public int hide_ship;
	public int repeat_instructions;
	public int end_at_line;
	public SpriteRenderer sprite_renderer_one;
	public SpriteRenderer sprite_renderer_two;


	// Use this for initialization
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


	void Update(){

		text.text = text_lines [current_line];

		if ((/**Input.GetKeyDown (KeyCode.Return) ||**/ Input.GetKeyDown(KeyCode.Mouse0)) && current_line < end_at_line) {

			current_line = current_line + 1;

		}

		if (current_line == hide_ship) {

			sprite_renderer_one.enabled = false;
			sprite_renderer_two.enabled = true;

		}
			
		if (current_line == repeat_instructions) {

			continue_text.gameObject.SetActive (true);
			repeat_text.gameObject.SetActive (true);

		}

	}

	public void continuePress(){

		SceneManager.LoadScene (2);

	}

	public void repeatPress(){
	
		continue_text.gameObject.SetActive (false);
		repeat_text.gameObject.SetActive (false);
		current_line = 9;

	}

}
