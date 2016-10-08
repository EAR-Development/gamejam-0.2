using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GUIController : MonoBehaviour {

	public GameObject lives;
	public GameObject ammo;
	public GameObject waveAnnouncer;

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

			lives.GetComponent<Text> ().text = "" + targetEntity.health;
			ammo.GetComponent<Text> ().text = "" + currentAmmo + " / " + maxAmmo;
		}
	}

	public void OnNextWave(int waveNumber){
		Debug.Log("OnNextWave called");
		StartCoroutine (ShowWaveAnnouncer (waveNumber));
	}

	IEnumerator ShowWaveAnnouncer(int waveNumber){
		Debug.Log("Die Nächste Welle kommt : " + waveNumber);
		waveAnnouncer.GetComponent<Text> ().text = "Die Nächste Welle kommt : " + waveNumber; 
		yield return new WaitForSeconds (2);
		Debug.Log("clear");
		waveAnnouncer.GetComponent<Text> ().text = ""; 
	}
}
