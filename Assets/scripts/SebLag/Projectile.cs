using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Player owner;
	public LayerMask collisionMask;
	public Color trailColour;
	float speed = 10;
	public float damage = 1;

	float lifetime = 3;
	float skinWidth = .1f;

	public string projectileType;
	Camera viewCamera;
	Vector3 point;
	public float airShotHeight;
	public bool mousePosSaved = false;

	void Start() {
		viewCamera = Camera.main;
		Destroy (gameObject, lifetime);

		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .1f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject(initialCollisions[0], transform.position);
		}

		GetComponent<TrailRenderer> ().material.SetColor ("_TintColor", trailColour);
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}
	
	void Update () {
		float moveDistance = speed * Time.deltaTime;
		CheckCollisions (moveDistance);

		if (!mousePosSaved) {
			// Look input
			Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
			Plane groundPlane = new Plane (Vector3.up, Vector3.up * 5);
			float rayDistance;

			if (groundPlane.Raycast (ray, out rayDistance)) {
				point = ray.GetPoint (rayDistance);
				Debug.DrawLine (ray.origin, point, Color.red);
				mousePosSaved = true;
			}
		} else {
			if (transform.position.y >= airShotHeight && projectileType == "AirShot") {
				transform.LookAt (point);
				transform.Translate (Vector3.forward * moveDistance);	
			} else {
				transform.Translate (Vector3.forward * moveDistance);
			}
		}


	}


	void CheckCollisions(float moveDistance) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide)) {
			OnHitObject(hit.collider, hit.point);
		}
	}

	void OnHitObject(Collider c, Vector3 hitPoint) {
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) {
			damageableObject.TakeHit (damage, hitPoint, transform.forward, owner);
		} else {
			owner.misses++;
		}
		GameObject.Destroy (gameObject);
	}

	void OnDestroy(){
		

		print (owner.hits / (owner.hits+owner.misses));
	}
}
