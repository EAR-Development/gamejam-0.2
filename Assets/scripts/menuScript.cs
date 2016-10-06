using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas startMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		quitMenu.enabled = false;
		startMenu.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		startMenu.enabled = false;

		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startMenu.enabled = true;

		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartPress(){
		SceneManager.LoadScene ("scenes/main");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}


