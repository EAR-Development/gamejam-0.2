using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float moveSpeed = 5;
	public float runSpeed = 20;
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
		gunController.setup ();
		gunController.owner = this;
		gunController.pickUpNewWeapon(0);
	
		viewCamera = Camera.main;
		//gunController.RefillStacheAmmo (1,singleWeapon: false);
		//FindObjectOfType<Spawner> ().OnNewWave += OnNewWave;
	}

	void Update () {
		if (!pause) {
			if (usingController) {
				Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal2"), 0, Input.GetAxisRaw ("Vertical2"));
				Vector3 rightStickInput = new Vector3 (Input.GetAxisRaw ("RightStickX"), 0, Input.GetAxisRaw ("RightStickY"));

				Vector3 moveVelocity = moveInput.normalized * currentSpeed;

				controller.Move (moveVelocity);

				if (!chargeJump) {
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

					// Weapon input
					if (Input.GetAxis ("RightTrigger") < 0) {
						gunController.OnTriggerHold ();
					}
					if (Input.GetAxis ("RightTrigger") >= 0) {
						gunController.OnTriggerRelease ();
						animator.SetTrigger ("ShootWeapon1");
						if (gunController.equippedGun.weaponType == "Flamethrower") {
							gunController.equippedGun.hitCollider.enabled = true;
						}
					}
					if (Input.GetButtonDown ("p2_reload")) {
						gunController.Reload ();
					}
					if (Input.GetButtonDown ("p2_change")) {
						if (gunController.euqippedGunNr < gunController.allGuns.Length - 1) {
							gunController.euqippedGunNr++;

						} else {
							gunController.euqippedGunNr = 0;
						}

						gunController.EquipGun (gunController.euqippedGunNr, this);
					}

				}
				if (Input.GetKeyDown (KeyCode.R)) {
					gunController.Reload ();
				}
				if (Input.GetKeyDown (KeyCode.Q)) {
					/*if (gunController.euqippedGunNr < gunController.allGuns.Length - 1) {
						gunController.euqippedGunNr++;


					if (Input.GetKeyDown (KeyCode.Space)) {
						animator.SetTrigger ("Jump");		
					}*/


					gunController.switchWeapon ();
				}

				if (Input.GetKeyDown (KeyCode.LeftShift)) {
					//animator.SetTrigger ("Jump");
					if (!runCoolingDown) {
						currentSpeed = runSpeed;
						Invoke ("ResetRunSpeed", runDuration);
						currentRunCooldown = runCooldown;
						runCoolingDown = true;
					}
				}


				if (runCoolingDown) {					
					if (currentRunCooldown > 0) {
						currentRunCooldown -= Time.deltaTime;

					} else {
						runCoolingDown = false;

					}

				}
			} else {
				
				// Movement input
				Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
				Vector3 moveVelocity = moveInput.normalized * currentSpeed;
				controller.Move (moveVelocity);

				if (!chargeJump) {
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

					// Weapon input
					if (Input.GetMouseButton (0)) {
						gunController.OnTriggerHold ();
					}
					if (Input.GetMouseButtonUp (0)) {
						gunController.OnTriggerRelease ();
						animator.SetTrigger ("ShootWeapon1");
						if (gunController.equippedGun.weaponType == "Flamethrower") {
							gunController.equippedGun.hitCollider.enabled = true;
						}
					}
					if (Input.GetKeyDown (KeyCode.R)) {
						gunController.Reload ();
					}
					if (Input.GetKeyDown (KeyCode.Q)) {
						if (gunController.euqippedGunNr < gunController.allGuns.Length - 1) {
							gunController.euqippedGunNr++;

						} else {
							gunController.euqippedGunNr = 0;
						}

						gunController.EquipGun (gunController.euqippedGunNr, this);
					}

					if (Input.GetButtonDown ("p2_special")) {
						animator.SetTrigger ("Jump");		
					}

					if (Input.GetButtonDown ("p2_sprint")) {
						if (!runCoolingDown) {
							currentSpeed = runSpeed;
							Invoke ("ResetRunSpeed", runDuration);
							currentRunCooldown = runCooldown;
							runCoolingDown = true;
						}
					}

					if (runCoolingDown) {					
						if (currentRunCooldown > 0) {
							currentRunCooldown -= Time.deltaTime;

						} else {
							runCoolingDown = false;

						}

					}
				}
			}
		}

	}

	public override void Die ()
	{
		base.Die ();
	}

	public void ResetRunSpeed(){
		currentSpeed = moveSpeed;
	}
}
