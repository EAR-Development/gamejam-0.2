using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

	public float moveSpeed = 5;

	public Crosshairs crosshairs;

	public bool pause = false;
	Camera viewCamera;
	PlayerController controller;
	GunController gunController;

	public int kills;
	public int hits;
	public int misses;

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
		if (!pause) {
			// Movement input
			Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			Vector3 moveVelocity = moveInput.normalized * moveSpeed;
			controller.Move (moveVelocity);

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

				gunController.EquipGun (gunController.euqippedGunNr,this);
			}
		}
	}

	public override void Die ()
	{
		base.Die ();
	}
		
}
