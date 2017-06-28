using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loaderManager : MonoBehaviour {

	public GameObject game_manager;

	void Awake () {

		if (game_manager == null) {

			Instantiate (game_manager);
			
		}
	}
}
