using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {


	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false; //disables quit menu to not show

	}

	public void ExitPress(){

		quitMenu.enabled = true; //shows quit menu
		startText.gameObject.SetActive(false);//hides start text
		exitText.gameObject.SetActive(false); //hides exit text

	}

	public void NoPress(){
	
		quitMenu.enabled = false; //hides quit menu
		startText.gameObject.SetActive(true); //shows start text
		exitText.gameObject.SetActive(true); //shows exit text

	}

	public void StartLevel(){

		SceneManager.LoadScene (1);

	}

	public void ExitGame(){
	
		Application.Quit ();

	}
}
