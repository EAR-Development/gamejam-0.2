using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public Object normalEnemy;

	public Transform target;

	public float spawnTime = 500f;
	private float spawnTimer = 0;
	private int spawnCount = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= spawnTime) {
			spawnTimer = 0;
			if (spawnCount > 0) {
				spawnCount -= 1;
				GameObject e = (GameObject)Instantiate (normalEnemy, transform.position, transform.rotation);
				enemyAgent eAgent = e.GetComponent<enemyAgent> ();
				eAgent.target = this.target;
			}
		}
	}

	void SpawnWave(){
		spawnCount = 5;
	}
}
