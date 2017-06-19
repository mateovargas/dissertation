using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textboxManager : MonoBehaviour {


	public GameObject text_box;
	public Text text;
	public TextAsset text_file;
	public Button continue_text;
	public Button repeat_text;
	public string[] text_lines;
	public int current_line;
	public int end_at_line;



	// Use this for initialization
	void Start () {

		continue_text = continue_text.GetComponent<Button> ();
		repeat_text = repeat_text.GetComponent<Button> ();

		continue_text.gameObject.SetActive (false);
		repeat_text.gameObject.SetActive (false);

		if (text_file != null) {

			text_lines = (text_file.text.Split('\n'));

		}

		if (end_at_line == 0) {
		
			end_at_line = text_lines.Length - 1;

		}
			
	}


	void Update(){

		text.text = text_lines [current_line];

		if (Input.GetKeyDown (KeyCode.Return)) {

			current_line = current_line + 1;

		}

		if (current_line == end_at_line) {

			continue_text.gameObject.SetActive (true);
			repeat_text.gameObject.SetActive (true);

		}

	}

	public void continuePress(){

		//continue to main game scene

	}

	public void repeatPress(){
	
		current_line = 10;

	}

}
