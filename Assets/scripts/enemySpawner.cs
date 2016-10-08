using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public Object normalEnemy;

	public float spawnTime = 0.3f;

	public int enemysPerWave = 10;


	private float spawnTimer = 0;
	private int spawnCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= spawnTime && spawnCount > 0) {
			spawnTimer = 0;
			spawnCount -= 1;
			GameObject e = (GameObject)Instantiate (normalEnemy, transform.position, transform.rotation);
		}
	}

	public void spawnWave(int amount){
		spawnCount += amount;
	}
}
