using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *Class that controls the Start menu of the game. TO DO: Extend for credits.
 **/
public class menuScript : MonoBehaviour {


	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	/**
	 *Method that starts the menu upon entering the scene. Gets the components for the text and menu, and disables the
	 *quit menu.
	 **/
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

	}

	/**
	 *Method that enables the Quit menu popup.
	 * */
	public void ExitPress(){

		quitMenu.enabled = true; //shows quit menu
		startText.gameObject.SetActive(false);//hides start text
		exitText.gameObject.SetActive(false); //hides exit text

	}

	/**
	 *Method that closes the Quit menu popup and returns to the Start menu after enabling the Quit menu. 
	 * */
	public void NoPress(){
	
		quitMenu.enabled = false; //hides quit menu
		startText.gameObject.SetActive(true); //shows start text
		exitText.gameObject.SetActive(true); //shows exit text

	}

	/**
	 *Method that starts the next scene upon pressing the start button. 
	 **/
	public void StartLevel(){

		SceneManager.LoadScene (1);

	}

	/**
	 *Method that exits the game after pressing the exit button on the quit menu. 
	 **/
	public void ExitGame(){
	
		Application.Quit ();

	}
}
