using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float moveSpeed = 5;
	public float runSpeed = 7;
	public float runCooldown = 10;
	public float runDuration = 2;
	public bool runCoolingDown = false;

	public Crosshairs crosshairs;

	public bool pause = false;
	public bool chargeJump = false;
	Camera viewCamera;
	PlayerController controller;
	public GunController gunController;
	public GunController backGunController;

	public float kills=0;
	public float hits=1;
	public float misses=0;

	float currentRunCooldown;
	float currentSpeed = 5;
	public bool usingController;
	public float points;
	public Transform playerLookAt;
	public AudioManager audioManager;

	protected override void Start () {
		base.Start ();
	}

	void Awake() {
		controller = GetComponent<PlayerController> ();
		gunController = GetComponent<GunController> ();
		gunController.EquipGun (0,this);
		viewCamera = Camera.main;
		//FindObjectOfType<Spawner> ().OnNewWave += OnNewWave;
	}

	void Update () {
		if (pause) {
			return;
		}

		// Overall Movement
		Vector3 moveInput;
		if (usingController) {
			moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal2"), 0, Input.GetAxisRaw ("Vertical2"));
		} else {
			moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		}

		Vector3 moveVelocity = moveInput.normalized * currentSpeed;
		controller.Move (moveVelocity);

		// AIM Movement
		if (!chargeJump && usingController) {
			Vector3 rightStickInput = new Vector3 (Input.GetAxisRaw ("RightStickX"), 0, Input.GetAxisRaw ("RightStickY"));
			Transform ProjectileSpawnTransform = gunController.equippedGun.projectileSpawn [0].transform;
			Vector3 legLookPos = controller.mechLegs.transform.position + moveInput;

			controller.mechLegs.LookAt (legLookPos);

			Vector3 point = transform.position + rightStickInput * 10;

			controller.LookAt (transform.position + rightStickInput);

			crosshairs.transform.position = ProjectileSpawnTransform.position;
			crosshairs.transform.position += ProjectileSpawnTransform.forward * rightStickInput.magnitude * 20;

			Vector3 aimPoint = crosshairs.transform.position;
			aimPoint.y = gunController.GunHeight;

			gunController.Aim (aimPoint);
		} else if (!chargeJump) {
			Vector3 legLookPos = controller.mechLegs.transform.position + moveInput;
			controller.mechLegs.LookAt (legLookPos);


			// Look input
			Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
			Plane groundPlane = new Plane (Vector3.up, Vector3.up * gunController.GunHeight);
			float rayDistance;

			if (groundPlane.Raycast (ray, out rayDistance)) {
				Vector3 point = ray.GetPoint (rayDistance);
				Debug.DrawLine (ray.origin, point, Color.red);
				controller.LookAt (point);
				crosshairs.transform.position = point;
				crosshairs.DetectTargets (ray);
				if ((new Vector2 (point.x, point.z) - new Vector2 (transform.position.x, transform.position.z)).sqrMagnitude > 1) {
					gunController.Aim (point);
				}
			}
		}

		// Tastatur Zuweisung

		if (!chargeJump && usingController) {
			if (Input.GetAxis ("RightTrigger") < 0) { OnShootHold (); }
			if (Input.GetAxis ("RightTrigger") >= 0) { OnShootUp (); }

			if (Input.GetButtonDown ("p2_reload")) { OnReloadPressed(); }
			if (Input.GetButtonDown ("p2_change")) { OnWeaponChangePressed(); }
			if (Input.GetButtonDown ("p2_special")) { OnSpecialPressed();}
			if (Input.GetButtonDown ("p2_sprint"))	{ OnSprintPressed();}
		} else if (!chargeJump) {
			if (Input.GetMouseButton (0)) { OnShootHold (); }
			if (Input.GetMouseButtonUp (0)) { OnShootUp (); }

			if (Input.GetKeyDown (KeyCode.R)) { OnReloadPressed(); }
			if (Input.GetKeyDown (KeyCode.Q)) { OnWeaponChangePressed(); }
			if (Input.GetKeyDown (KeyCode.Space)) 		{ OnSpecialPressed();}
			if (Input.GetKeyDown (KeyCode.LeftShift))	{ OnSprintPressed();}
		}

		//Cooldown
		if (runCoolingDown) {					
			if (currentRunCooldown > 0) {
				currentRunCooldown -= Time.deltaTime;

			} else {
				runCoolingDown = false;

			}

		}
	}


	// KEY ACTIONS
	public void OnShootHold(){
		gunController.OnTriggerHold ();
	}

	public void OnShootUp(){
		gunController.OnTriggerRelease ();
		animator.SetTrigger ("ShootWeapon1");
		if (gunController.equippedGun.weaponType == "Flamethrower") {
			gunController.equippedGun.hitCollider.enabled = true;
		}
	}

	public void OnWeaponChangePressed(){
			if (gunController.euqippedGunNr < gunController.allGuns.Length - 1) {
				gunController.euqippedGunNr++;

			} else {
				gunController.euqippedGunNr = 0;
			}

			gunController.EquipGun (gunController.euqippedGunNr, this);
	}

	public void OnSprintPressed(){
		if (!runCoolingDown) {
			currentSpeed = runSpeed;
			Invoke ("ResetRunSpeed", runDuration);
			currentRunCooldown = runCooldown;
			runCoolingDown = true;
		}
	}

	public void OnSpecialPressed(){
		animator.SetTrigger ("Jump");
	}

	public void OnReloadPressed(){
		gunController.Reload ();
	}




	// OTHER ACTIONS
	public override void Die ()
	{
		base.Die ();
	}

	public void ResetRunSpeed(){
		currentSpeed = moveSpeed;
	}

	public void PlayWalkSound(){
		//currentSpeed = moveSpeed;
		AudioManager.instance.PlaySound2D ("MechaWalking");
	}
		
}
