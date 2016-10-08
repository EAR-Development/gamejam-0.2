using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	Vector3 velocity;
	public Transform mechTorso;
	Rigidbody myRigidbody;
	GunController gunController;

	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 _velocity) {
		velocity = _velocity;
	}

	public void LookAt(Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, mechTorso.position.y, lookPoint.z);
		mechTorso.LookAt (heightCorrectedPoint);
	}

	void FixedUpdate() {
		myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
	}
}
