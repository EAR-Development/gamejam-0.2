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

	/*public void switchWeapon(){
		ammoInMagazine[currentSlotNumber] = equippedGun.projectilesRemainingInMag;
	//	ammo [currentSlotNumber] = maxAmmoInStache [currentSlotNumber];
		currentSlotNumber++;

		if (currentSlotNumber > currentWeaponSlots) {
		
			currentSlotNumber = 0;
			if (WeaponSlots [currentSlotNumber] != -1) {
				pickUpWeaponFromStache (currentSlotNumber);
			} else {
				currentSlotNumber++;
				if (WeaponSlots [currentSlotNumber] != -1) {
					pickUpWeaponFromStache (currentSlotNumber);
				} 
			}

		} else {


			if (WeaponSlots [currentSlotNumber] != -1) {
				pickUpWeaponFromStache (currentSlotNumber);
			} else {
				currentSlotNumber++;
				if (currentSlotNumber > currentWeaponSlots) {
					currentSlotNumber = 0;
				}
				if (WeaponSlots [currentSlotNumber] != -1) {
					pickUpWeaponFromStache (currentSlotNumber);
				} 
			}
		}

	}*/

	/*public void RefillStacheAmmo(int slot, bool singleWeapon=true){
	
		if (singleWeapon) {
			
			ammo [slot] = maxAmmoInStache [slot];
		} else {
			for(int i=0;i<WeaponSlots.Length;i++){

				ammo [currentSlotNumber]= equippedGun.maxAmmo;
			
			}
		}

	}

	public void RefillMagazineAmmo(int slot, bool singleWeapon=true){

		if (singleWeapon) {
			ammoInMagazine [slot] = equippedGun.projectilesPerMag;
		} else {
			for(int i=0;i<WeaponSlots.Length;i++){


				ammoInMagazine [i] = equippedGun.projectilesPerMag;
			}
		}

	}

	public void pickUpWeaponFromStache(int slot){

		EquipGun (WeaponSlots [slot], owner);

		equippedGun.projectilesRemainingInMag = ammoInMagazine [slot];
		ammo [slot] = maxAmmoInStache [slot];
		print (equippedGun.projectilesRemainingInMag + "    " + ammo[currentSlotNumber]);


	}

	public void pickUpNewWeapon(int weaponNumber){

		/*EquipGun (WeaponSlots [slot], owner);
		equippedGun.projectilesRemainingInMag = ammoInMagazine [slot];
		ammo [slot] = maxAmmoInStache [slot];
		print (equippedGun.projectilesRemainingInMag + "    " + ammo[currentSlotNumber]);


	

		int freespot = -1;
		for(int i=0;i<currentWeaponSlots;i++){
			
			if(WeaponSlots[i]==-1){
				
				freespot = i;

			}

		}
		if (freespot == -1) {

			WeaponSlots [currentSlotNumber] = weaponNumber;
			EquipGun (WeaponSlots [currentSlotNumber], owner);
	
			maxAmmoInStache [currentSlotNumber] = equippedGun.maxAmmo;
			RefillMagazineAmmo (currentSlotNumber);
			RefillStacheAmmo (currentSlotNumber);

		} else {
			currentSlotNumber = freespot;
			WeaponSlots [currentSlotNumber] = weaponNumber;
			EquipGun (WeaponSlots [currentSlotNumber], owner);

			maxAmmoInStache [currentSlotNumber] = equippedGun.maxAmmo;
			RefillMagazineAmmo (currentSlotNumber);
			RefillStacheAmmo (currentSlotNumber);

		}

	}*/



}