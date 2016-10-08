using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GUIController : MonoBehaviour {

	public GameObject lives;
	public GameObject ammo;
	public GameObject waveAnnouncer;

	public GameObject playerOneName;
	public GameObject playerOneWeapon;
	public GameObject playerOneWeaponText;

	public GameObject playerTwoName;

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

			lives.GetComponent<Text> ().text = "" + targetEntity.health;
			ammo.GetComponent<Text> ().text = "" + currentAmmo + " / " + maxAmmo;
		}
	}

	public void OnNextWave(int waveNumber){
		Debug.Log("OnNextWave called");
		StartCoroutine (ShowWaveAnnouncer (waveNumber));
	}

	public void setScoreKeeper(ScoreKeeper sk){
		scoreKeeper = sk;
		Debug.Log(scoreKeeper.playerOneName);
		playerOneName.GetComponent<Text> ().text = scoreKeeper.playerOneName;
	}

	IEnumerator ShowWaveAnnouncer(int waveNumber){
		Debug.Log("Die Nächste Welle kommt : " + waveNumber);
		waveAnnouncer.GetComponent<Text> ().text = "Die Nächste Welle kommt : " + waveNumber; 
		yield return new WaitForSeconds (2);
		Debug.Log("clear");
		waveAnnouncer.GetComponent<Text> ().text = ""; 
	}
}