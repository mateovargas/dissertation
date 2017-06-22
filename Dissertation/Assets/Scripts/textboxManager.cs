using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textboxManager : MonoBehaviour {


	public Text text;
	public TextAsset text_file;
	public Button continue_text;
	public Button repeat_text;
	public string[] text_lines;
	public int current_line;
	public int hide_sprite;
	public int repeat;
	public int end_at_line;
	public SpriteRenderer sprite_renderer;


	// Use this for initialization
	void Start () {

		continue_text.gameObject.SetActive (false);
		repeat_text.gameObject.SetActive (false);

		if (text_file != null) {

			Debug.Log (text_file.ToString ());
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

		if (current_line == hide_sprite) {

			sprite_renderer.enabled = false;

		}
			
		if (current_line == repeat) {

			continue_text.gameObject.SetActive (true);
			repeat_text.gameObject.SetActive (true);

		}

	}

	public void continuePress(){

		Application.LoadLevel (2);

	}

	public void repeatPress(){
	
		continue_text.gameObject.SetActive (false);
		repeat_text.gameObject.SetActive (false);
		current_line = 9;

	}

}
