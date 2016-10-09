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

	public Sprite Mech01;
	public Sprite Mech02;

	public GameObject playerOnePortrait;
	public GameObject playerTwoPortrait;

	public Button startText;
	public Button exitText;

	public InputField playerOneNameField;
	public InputField playerTwoNameField;
	public bool characterFlipped;

	public ScoreKeeper scoreKeeper;


	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		playerMenu = playerMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		scoreKeeper = scoreKeeper.GetComponent<ScoreKeeper> ();

		quitMenu.enabled = false;
		playerMenu.enabled = false;
		secondPlayerCard.enabled = false;
		startMenu.enabled = true;

		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;

		playerOnePortrait.GetComponent<Image> ().overrideSprite = Mech01;
		playerTwoPortrait.GetComponent<Image> ().overrideSprite = Mech02;
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

	public void FlipPress(){
		characterFlipped = !characterFlipped;

		if (!characterFlipped) {
			playerOnePortrait.GetComponent<Image> ().overrideSprite = Mech01;
			playerTwoPortrait.GetComponent<Image> ().overrideSprite = Mech02;
		} else {
			playerOnePortrait.GetComponent<Image> ().overrideSprite = Mech02;
			playerTwoPortrait.GetComponent<Image> ().overrideSprite = Mech01;
		}
	}

	public void BackPress(){
		startMenu.enabled = true;
		playerMenu.enabled = false;
		secondPlayerCard.enabled = false;
	}

	public void StartPress(){
		secondPlayerCard.enabled = false;

		startMenu.enabled = false;
		playerMenu.enabled = true;
	}

	public void RunPress(){
		bool playerTwoEnabled = secondPlayerCard.enabled;
		string playerOneName = playerOneNameField.text;
		string playerTwoName = playerTwoNameField.text;

		scoreKeeper.playerTwoEnabled = playerTwoEnabled;
		scoreKeeper.playerOneName = playerOneName;
		scoreKeeper.playerTwoName = playerTwoName;

		Debug.Log (playerOneName);

		SceneManager.LoadScene ("scenes/SebLag/game");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}


