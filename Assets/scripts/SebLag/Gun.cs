using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {

	public string weaponName;
	public Player owner;
	public enum FireMode {Auto, Burst, Single};
	public FireMode fireMode;

	public Sprite weaponImage;

	public Transform[] projectileSpawn;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	public int burstCount;
	public int projectilesPerMag;
	public float reloadTime = .3f;
	public float damage = 1;
	public int maxAmmo=200;

	[Header("Recoil")]
	public Vector2 kickMinMax = new Vector2(.05f,.2f);
	public Vector2 recoilAngleMinMax = new Vector2(3,5);
	public float recoilMoveSettleTime = .1f;
	public float recoilRotationSettleTime = .1f;

	[Header("Effects")]
	public Transform shell;
	public Transform shellEjection;
	public AudioClip shootAudio;
	public AudioClip reloadAudio;

	MuzzleFlash muzzleflash;
	float nextShotTime;


	bool triggerReleasedSinceLastShot;
	int shotsRemainingInBurst;
	public int projectilesRemainingInMag;
	bool isReloading;
	public bool spinUp = true;
	//public bool preFire = false;
	public float preFireDuration;
	public float preFireDurationMax;

	Vector3 recoilSmoothDampVelocity;
	float recoilRotSmoothDampVelocity;
	float recoilAngle;
	public string weaponType;
	public CapsuleCollider hitCollider; 
	public List<Enemy> EnemysHit;

	void Start() {
		muzzleflash = GetComponent<MuzzleFlash> ();
		shotsRemainingInBurst = burstCount;
		projectilesRemainingInMag = projectilesPerMag;
	}

	void LateUpdate() {
		// animate recoil
		transform.localPosition = Vector3.SmoothDamp (transform.localPosition, Vector3.zero, ref recoilSmoothDampVelocity, recoilMoveSettleTime);
		recoilAngle = Mathf.SmoothDamp (recoilAngle, 0, ref recoilRotSmoothDampVelocity, recoilRotationSettleTime);
		transform.localEulerAngles = transform.localEulerAngles + Vector3.left * recoilAngle;

		//if (!isReloading && projectilesRemainingInMag == 0) {
		if(Input.GetButtonDown("Reload")){
			Reload();
		}

		foreach(Enemy e in EnemysHit){
			e.TakeDamage (damage,owner);
		}
	}

	void Shoot() {
		if (!isReloading && Time.time > nextShotTime && projectilesRemainingInMag > 0) {
			if (preFireDuration > 0) {				
				preFireDuration -= Time.deltaTime;
			} else {				

				if (fireMode == FireMode.Burst) {
					if (shotsRemainingInBurst == 0) {
						return;
					}
					shotsRemainingInBurst--;
				} else if (fireMode == FireMode.Single) {
					if (!triggerReleasedSinceLastShot) {
						return;
					}
				}

				for (int i = 0; i < projectileSpawn.Length; i++) {

					//play shot sound
					if (weaponType == "Carbine") {
						//AudioManager.instance.PlaySound2D ("MechaWalking");
					} else if (weaponType == "Rocket") {
						//AudioManager.instance.PlaySound2D ("Rocketlauncher_Shot");
					} else if (weaponType == "Minigun") {
						//AudioManager.instance.PlaySound2D ("Minigun_Shot");
					}


					if (projectilesRemainingInMag == 0) {
						break;
					}
					projectilesRemainingInMag--;

					if (projectilesRemainingInMag == 0) {
						Reload ();
					}

					nextShotTime = Time.time + msBetweenShots / 1000;
					if (weaponType == "Flamethrower") {
						hitCollider.enabled = true;
					} else {
						Projectile newProjectile = Instantiate (projectile, projectileSpawn [i].position, projectileSpawn [i].rotation) as Projectile;
						newProjectile.SetSpeed (muzzleVelocity);
						newProjectile.owner = owner;
						newProjectile.damage = damage;
					}
				}

				Instantiate (shell, shellEjection.position, shellEjection.rotation);
				muzzleflash.Activate ();
				transform.localPosition -= Vector3.forward * Random.Range (kickMinMax.x, kickMinMax.y);
				recoilAngle += Random.Range (recoilAngleMinMax.x, recoilAngleMinMax.y);
				recoilAngle = Mathf.Clamp (recoilAngle, 0, 30);

			}


		}

	}

	public void Reload() {
		if (!isReloading && projectilesRemainingInMag != projectilesPerMag) {
			StartCoroutine (AnimateReload ());

		}
	}

	IEnumerator AnimateReload() {
		isReloading = true;
		yield return new WaitForSeconds (.2f);
		//AudioManager.instance.PlaySound2D ("Mecha_Reload");

		float reloadSpeed = 1f / reloadTime;
		float percent = 0;
		Vector3 initialRot = transform.localEulerAngles;
		float maxReloadAngle = 30;
		while (percent < 1) {
			percent += Time.deltaTime * reloadSpeed;
			float interpolation = (-Mathf.Pow(percent,2) + percent) * 4;
			float reloadAngle = Mathf.Lerp(0, maxReloadAngle, interpolation);
			transform.localEulerAngles = initialRot + Vector3.left * reloadAngle;

			yield return null;
		}

	
		isReloading = false;
		projectilesRemainingInMag = projectilesPerMag;
	}

	public void Aim(Vector3 aimPoint) {
		if (!isReloading) {
			transform.LookAt (aimPoint);
		}
	}

	public void OnTriggerHold() {
		Shoot ();
		triggerReleasedSinceLastShot = false;
		if (spinUp && preFireDuration > 0) {
			//AudioManager.instance.PlaySound2D ("Minigun_SpinUp");
			spinUp = false;
		}
	}

	public void OnTriggerRelease() {
		triggerReleasedSinceLastShot = true;
		spinUp = true;
		shotsRemainingInBurst = burstCount;
		preFireDuration = preFireDurationMax;
		if (hitCollider) {
			
			hitCollider.enabled = false;
		
		}
	}

	public void OnTriggerEnter(Collider col){
		if(weaponType == "Flamethrower" && col.gameObject.tag == "Enemy"){
			EnemysHit.Add(col.GetComponent<Enemy>());
		}
	}

	public void OnTriggerExit(Collider col){
		if(weaponType == "Flamethrower" && col.gameObject.tag == "Enemy"){
			EnemysHit.Remove(col.GetComponent<Enemy>());
		}
	}
}
