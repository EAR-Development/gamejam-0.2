using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public Object normalEnemy;

	public Transform target;

	public float spawnTime = 2.5f;
	private float spawnTimer = 0;
	private int spawnCount = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= spawnTime) {
			if (spawnCount > 0) {
				GameObject e = (GameObject)Instantiate (normalEnemy, transform.position, transform.rotation);
				enemyAgent eAgent = e.GetComponent<enemyAgent> ();
				eAgent.target = this.target;
				spawnCount -= 1;
			}
			spawnTimer = 0;
		}
	}

	void SpawnWave(){
		spawnCount = 5;
	}
}
