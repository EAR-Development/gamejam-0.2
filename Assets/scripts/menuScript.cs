using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas startMenu;
	public Canvas playerMenu;

	public Canvas secondPlayerCard;

	public Button toggleSecondPlayerButton;
	public Sprite plusSprite;
	public Sprite minusSprite;


	public Button startText;
	public Button exitText;

	public InputField playerOneNameField;
	public InputField playerTwoNameField;

	public ScoreKeeper score;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		playerMenu = playerMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		quitMenu.enabled = false;
		playerMenu.enabled = false;
		secondPlayerCard.enabled = false;
		startMenu.enabled = true;

		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
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

	public void toggleSecondPlayerPress(){
		if (secondPlayerCard.enabled) {
			toggleSecondPlayerButton.image.overrideSprite = plusSprite;
		} else {
			toggleSecondPlayerButton.image.overrideSprite = minusSprite;
		}
		secondPlayerCard.enabled = !secondPlayerCard.enabled;
	}

	public void BackPress(){
		startMenu.enabled = true;
		playerMenu.enabled = false;
	}

	public void StartPress(){
		secondPlayerCard.enabled = false;

		startMenu.enabled = false;
		playerMenu.enabled = true;
	}

	public void RunPress(){
		ScoreKeeper.playerTwoEnabled = secondPlayerCard.enabled;
		ScoreKeeper.playerOneName = playerOneNameField.text;
		ScoreKeeper.playerTwoName = playerTwoNameField.text;

		SceneManager.LoadScene ("scenes/SebLag/game");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}


