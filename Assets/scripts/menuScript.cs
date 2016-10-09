using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas startMenu;
	public Canvas playerMenu;
	public Canvas afterGameScreen;

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

	public GameObject ScoreKeeperPrefab;
	public ScoreKeeper scoreKeeper;

	[Header("After Game Screen")]
	public GameObject p1_name;
	public GameObject p1_points;
	public GameObject p1_shots;
	public GameObject p1_hits;
	public GameObject p1_acc;
	public GameObject p1_kills;

	public Canvas playerTwoAfterScreen;

	public GameObject p2_name;
	public GameObject p2_points;
	public GameObject p2_shots;
	public GameObject p2_hits;
	public GameObject p2_acc;
	public GameObject p2_kills;
	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startMenu = startMenu.GetComponent<Canvas> ();
		playerMenu = playerMenu.GetComponent<Canvas> ();
		afterGameScreen = afterGameScreen.GetComponent<Canvas> ();
		playerTwoAfterScreen = playerTwoAfterScreen.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		scoreKeeper = (ScoreKeeper)FindObjectOfType (typeof(ScoreKeeper));

		if (scoreKeeper == null) {
			scoreKeeper = Object.Instantiate (ScoreKeeperPrefab).GetComponent<ScoreKeeper> ();
		}

		quitMenu.enabled = false;
		playerMenu.enabled = false;
		afterGameScreen.enabled = false;
		playerTwoAfterScreen.enabled = false;
		secondPlayerCard.enabled = false;
		startMenu.enabled = true;

		if (scoreKeeper.afterGame) {
			showAfterScreen ();
		}

		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;

		playerOnePortrait.GetComponent<Image> ().overrideSprite = Mech01;
		playerTwoPortrait.GetComponent<Image> ().overrideSprite = Mech02;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (playerMenu.enabled) {
			if (Input.GetButtonDown ("p2_use") && !secondPlayerCard.enabled) {
				toggleSecondPlayerPress ();
			}
			if (Input.GetButtonDown ("p2_back") && secondPlayerCard.enabled) {
				toggleSecondPlayerPress ();
			}
		}
	}

	public void showAfterScreen(){
		p1_name.GetComponent<Text>().text = "" + scoreKeeper.playerOneName;
		p1_points.GetComponent<Text>().text = "" + scoreKeeper.playerOnePoints;
		p1_shots.GetComponent<Text>().text = "" + (scoreKeeper.playerOneHit + scoreKeeper.playerOneMissed);
		p1_hits.GetComponent<Text>().text = "" + scoreKeeper.playerOneHit;

		string acc;

		int allShots = scoreKeeper.playerOneHit + scoreKeeper.playerOneMissed;
		if (allShots == 0) {
			 acc = "--";
		} else {
			acc = Mathf.Round(scoreKeeper.playerOneHit / allShots * 100).ToString();
		}

		playerTwoAfterScreen.enabled = scoreKeeper.playerTwoEnabled;

		p1_acc.GetComponent<Text>().text = acc;
		p1_kills.GetComponent<Text>().text = "" + scoreKeeper.playerOneKills;

		p2_name.GetComponent<Text>().text = "" + scoreKeeper.playerTwoName;
		p2_points.GetComponent<Text>().text = "" + scoreKeeper.playerTwoPoints;
		p2_shots.GetComponent<Text>().text = "" + (scoreKeeper.playerTwoHit + scoreKeeper.playerTwoMissed);
		p2_hits.GetComponent<Text>().text = "" + scoreKeeper.playerTwoHit;

		allShots = scoreKeeper.playerTwoHit + scoreKeeper.playerTwoMissed;
		if (allShots == 0) {
			acc = "--";
		} else {
			acc = Mathf.Round(scoreKeeper.playerTwoHit / allShots * 100).ToString();
		}

		p2_acc.GetComponent<Text>().text = acc;
		p2_kills.GetComponent<Text>().text = "" + scoreKeeper.playerTwoKills;


		startMenu.enabled = false;
		afterGameScreen.enabled = true;
	}

	public void LeaveAfterscreenPress(){
		GameObject.Destroy (scoreKeeper.gameObject);
		scoreKeeper = Object.Instantiate (ScoreKeeperPrefab).GetComponent<ScoreKeeper> ();
		BackPress ();
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
		afterGameScreen.enabled = false;
		playerTwoAfterScreen.enabled = false;
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


