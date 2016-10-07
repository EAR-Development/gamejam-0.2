using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GUIController : MonoBehaviour {

	public GameObject lives;
	public GameObject ammo;

	Transform target;
	LivingEntity targetEntity;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {

			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetEntity = target.GetComponent<LivingEntity> ();
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetEntity != null) {
			lives.GetComponent<Text> ().text = "" + targetEntity.health;
			ammo.GetComponent<Text> ().text = "" + targetEntity.GetComponent<GunController> ().equippedGun.projectilesRemainingInMag;
		}
	}
}
