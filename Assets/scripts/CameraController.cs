using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject[] allPlayer;

	private static float MINIMUMDISTANCE = 13f;

	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

	public float angleFactor;
	public float fovXFactor;
	public float fovZFactor;

	public float HEIGHT = 20f;
	public float zOffset;


	private float zPos = -25f;

	// Use this for initialization
	void Start () {
		allPlayer = GameObject.FindGameObjectsWithTag("Player");
		float fov = GetComponent<Camera> ().fieldOfView;
		float aspect = GetComponent<Camera> ().aspect;

		float angle = transform.eulerAngles.x * Mathf.Deg2Rad;

		Debug.Log (angle);

		angleFactor = Mathf.Tan(angle);


		Debug.Log (angleFactor);
		zOffset = HEIGHT / angleFactor;

		fovXFactor = 1 / (2 * Mathf.Tan (fov / 2));
		fovZFactor = aspect * 1 / ( 2 *Mathf.Tan (fov / 2));
	}

	// Update is called once per frame
	void Update () {
		calculateContainingRectangle ();

		float speedFactor = 1.8f;

		Vector3 distance = transform.position - new Vector3 ((xMin + xMax) / 2, HEIGHT, (zMin + zMax) / 2);
		if (distance.magnitude > 9) {
			speedFactor = 0.5f;
		}

		Vector3 panVector = Vector3.Lerp (new Vector3(transform.position.x, HEIGHT ,transform.position.z), new Vector3 ((xMin + xMax) / 2, HEIGHT,(zMin + zMax) / 2 - zOffset), Time.deltaTime / speedFactor);

		transform.position = panVector;
	}

	void calculateContainingRectangle(){
		xMin = 30000;
		xMax = -30000;
		zMin = 30000;
		zMax = -30000;
		foreach (GameObject player in allPlayer) {
			if(player!=null){
				float x = player.transform.position.x;

				xMin = Mathf.Min (x,xMin);
				xMax = Mathf.Max (x, xMax);

				float z = player.transform.position.z;

				zMin = Mathf.Min (z, zMin);
				zMax = Mathf.Max (z, zMax);
			}

		}
	}
}