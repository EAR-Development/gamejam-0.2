using UnityEngine;
using System.Collections;

public class DroneControl : MonoBehaviour {

	public Transform owner;
	public float speed;
	public Vector3 ownerPos;
	public float rndTime;
	public Gun equippedGun;
	Camera viewCamera;
	GunController gunController;

	// Use this for initialization
	void Start () {		
		gunController = GetComponent<GunController> ();
		viewCamera = Camera.main;
		gunController.EquipGun (0, owner.GetComponent<Player> ());
		equippedGun = gunController.allGuns [0];
		//equippedGun.owner = owner.GetComponent<Player> ();
		ownerPos = new Vector3 (owner.position.x, transform.position.y, owner.position.z) + Random.onUnitSphere * 5;
		ownerPos.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		// Look input
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.up * gunController.GunHeight);
		float rayDistance;

		if (groundPlane.Raycast (ray, out rayDistance)) {
			Vector3 point = ray.GetPoint (rayDistance);
			Debug.DrawLine (ray.origin, point, Color.red);
			point.y = transform.position.y;
			transform.LookAt (point);
			if ((new Vector2 (point.x, point.z) - new Vector2 (transform.position.x, transform.position.z)).sqrMagnitude > 1) {
				Vector3 mousePos = viewCamera.ScreenToWorldPoint (Input.mousePosition);
				//mousePos.y = transform.position.y;
				equippedGun.transform.LookAt (mousePos);
			}
		}

		if (Input.GetMouseButton (0)) {
			gunController.OnTriggerHold ();
		}

		if (rndTime > 0) {
			rndTime -= Time.deltaTime;
		} else {
			rndTime = Random.Range (0.8f, 3f);
			ownerPos = new Vector3 (owner.position.x, transform.position.y, owner.position.z) + Random.onUnitSphere * 2;
			ownerPos.y = transform.position.y;
		}
		FollowOwner ();
	}

	void FollowOwner(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, ownerPos, step);
		if(Vector3.Distance(owner.position, transform.position) <= 2){
			rndTime = 0.0f;
		}
	}
}
