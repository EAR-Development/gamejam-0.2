using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour {

	public Transform weaponHold;
	public Gun[] allGuns;
	public Gun equippedGun;
	public int euqippedGunNr =0;
	public int currentWeaponSlots=2;
	public int maxWeaponslots=3;
	public List<Gun> carriedGuns;
	public Player owner;


	void Start() {
		owner = GetComponent<Player> ();


	}

	public void setup(){
		carriedGuns = new List<Gun> ();


	}

	public void EquipGun(Gun gunToEquip,Player owner) {
		if (equippedGun != null) {
			Destroy(equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponHold.position,weaponHold.rotation) as Gun;
		equippedGun.transform.parent = weaponHold;
		equippedGun.GetComponent<Gun> ().owner=owner;
	}

	public void EquipGun(int weaponIndex, Player owner) {
		EquipGun (allGuns [weaponIndex],owner);
		euqippedGunNr = weaponIndex;
	}

	public void OnTriggerHold() {
		if (equippedGun != null) {
			equippedGun.OnTriggerHold();
		}
	}

	public void OnTriggerRelease() {
		if (equippedGun != null) {
			equippedGun.OnTriggerRelease();
		}
	}

	public float GunHeight {
		get {
			return weaponHold.position.y;
		}
	}

	public void Aim(Vector3 aimPoint) {
		if (equippedGun != null) {
			equippedGun.Aim(aimPoint);
		}
	}

	public void Reload() {
		
		if (equippedGun != null && carriedGuns[euqippedGunNr] ) {
			equippedGun.Reload ();

		} 
	}

	public void pickUpNewWeapon(Gun gun){

		carriedGuns.Add (gun);
		EquipGun (gun, owner);
		euqippedGunNr = carriedGuns.Count;
	}



}