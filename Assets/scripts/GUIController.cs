using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GUIController : MonoBehaviour {
	public GameObject waveAnnouncer;

	[Header("Spieler 1")]
	public GameObject playerOneStat;
	public GameObject playerOneLives;
	public GameObject playerOneAmmo;
	public GameObject playerOneName;
	public GameObject playerOneWeapon;
	public GameObject playerOneWeaponText;
	public Text playerOnePointsText;


	[Header("Spieler 2")]
	public GameObject playerTwoStat;
	public GameObject playerTwoLives;
	public GameObject playerTwoAmmo;
	public GameObject playerTwoName;
	public GameObject playerTwoWeapon;
	public GameObject playerTwoWeaponText;
	public Text playerTwoPointsText;

	[HideInInspector]
	public ScoreKeeper scoreKeeper;

	Transform target;
	LivingEntity targetEntity;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {

			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetEntity = target.GetComponent<LivingEntity> ();
		}	

		waveAnnouncer.GetComponent<Text> ().text = "";
	}

	// Update is called once per frame
	void Update () {
		if (targetEntity != null) {
			int currentAmmo = targetEntity.GetComponent<GunController> ().equippedGun.projectilesRemainingInMag;
			int maxAmmo = targetEntity.GetComponent<GunController> ().equippedGun.projectilesPerMag;

			Sprite weaponImage = targetEntity.GetComponent<GunController> ().equippedGun.weaponImage;
			string weaponName = targetEntity.GetComponent<GunController> ().equippedGun.weaponName;

			playerOneWeaponText.GetComponent<Text>().text = weaponName;

			if (weaponImage != null) {
				playerOneWeapon.GetComponent<Image> ().enabled = true;
				playerOneWeapon.GetComponent<Image> ().overrideSprite = weaponImage;
			} else {
				playerOneWeapon.GetComponent<Image> ().enabled = false;
			}

			playerOneLives.GetComponent<Text> ().text = "" + targetEntity.health;
			playerOneAmmo.GetComponent<Text> ().text = "" + currentAmmo + " / " + maxAmmo;

			playerOnePointsText.text= "" + (gameControllerScript.playerOne.points);
		}
	}

	public void OnNextWave(int waveNumber){
		Debug.Log("OnNextWave called");
		StartCoroutine (ShowWaveAnnouncer (waveNumber));
	}

	public void setScoreKeeper(ScoreKeeper sk){
		scoreKeeper = sk;
		playerOneName.GetComponent<Text> ().text = scoreKeeper.playerOneName;

		if (!scoreKeeper.playerTwoEnabled) {
			playerTwoStat.SetActive (false);
		} else {
			playerTwoStat.SetActive (true);
			playerTwoName.GetComponent<Text> ().text = scoreKeeper.playerTwoName;
		}
	}

	IEnumerator ShowWaveAnnouncer(int waveNumber){
		Debug.Log("Die Nächste Welle kommt : " + waveNumber);
		waveAnnouncer.GetComponent<Text> ().text = "Die Nächste Welle kommt : " + waveNumber; 
		yield return new WaitForSeconds (2);
		Debug.Log("clear");
		waveAnnouncer.GetComponent<Text> ().text = ""; 
	}
}