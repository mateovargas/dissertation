using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour {


	public TextAsset text_file;
	public string[] text_lines;
	// Use this for initialization
	void Start () {

		if (text_file != null) {
		
			text_lines = (text_file.text.Split('\n'));

		}
	}

}
