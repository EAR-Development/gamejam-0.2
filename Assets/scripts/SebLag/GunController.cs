using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public Transform weaponHold;
	public Gun[] allGuns;
	public Gun equippedGun;
	public int euqippedGunNr =-1;
	public int maxWeaponslots;
	public int weaponSlot1;
	public int weaponSlot2;
	public int weaponSlot3;

	void Start() {
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
		if (equippedGun != null) {
			equippedGun.Reload();
		}
	}

}