using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameControllerScript : MonoBehaviour {

	public Canvas pausemenu;
	public Canvas endMenu;

	Transform target;
	LivingEntity targetEntity;

	// Use this for initialization
	void Start () {
		pausemenu = pausemenu.GetComponent<Canvas> ();
		pausemenu.enabled = false;

		endMenu = endMenu.GetComponent<Canvas> ();
		endMenu.enabled = false;

		if (GameObject.FindGameObjectWithTag ("Player") != null) {

			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetEntity = target.GetComponent<LivingEntity> ();

			targetEntity.OnDeath += OnPlayerDeath;
		}
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			EscapeKeyPressed ();
		}
	}


	public void EscapeKeyPressed(){
		pausemenu.enabled = ! pausemenu.enabled;

		if (pausemenu.enabled) {
			Cursor.visible = true;
		} else {
			Cursor.visible = false;
		}

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Player controller = player.GetComponent<Player> ();
			controller.pause = !controller.pause;
		}
			
		if (Time.timeScale == 1.0F) {
			Time.timeScale = 0.0F;
		} else {
			Time.timeScale = 1.0F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	public void ExitButtonPressed(){
		SceneManager.LoadScene ("scenes/menu");
	}

	public void ResumeButtonPressed(){
		EscapeKeyPressed ();
	}

	public void RestartButtonPressed(){
		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		SceneManager.LoadScene ("scenes/SebLag/game");
	}
		
	void OnPlayerDeath() {
		Time.timeScale = 0.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		Cursor.visible = true;
		endMenu.enabled = true;
	}
}
