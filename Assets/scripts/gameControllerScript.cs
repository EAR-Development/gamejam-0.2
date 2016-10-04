using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameControllerScript : MonoBehaviour {

	public Canvas pausemenu;

	// Use this for initialization
	void Start () {
		pausemenu = pausemenu.GetComponent<Canvas> ();
		pausemenu.enabled = false;
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			EscapeKeyPressed ();
		}
	}


	public void EscapeKeyPressed(){
		pausemenu.enabled = ! pausemenu.enabled;
	}

	public void ExitButtonPressed(){
		SceneManager.LoadScene ("scenes/menu");
	}

	public void ResumeButtonPressed(){
		pausemenu.enabled = false;
	}
}
