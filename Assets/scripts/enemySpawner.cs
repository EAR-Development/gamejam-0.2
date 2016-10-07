using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

	public Object normalEnemy;

	public Transform target;

	public float innerSpawnTime = 0.3f;
	public float outerSpawnTime = 7f;

	public int enemysPerWave = 10;


	private float spawnTimer = 0;
	private int spawnCount = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= innerSpawnTime && spawnCount > 0) {
			spawnTimer = 0;
			spawnCount -= 1;
			GameObject e = (GameObject)Instantiate (normalEnemy, transform.position, transform.rotation);
		}else if(outerSpawnTime <= spawnTimer && spawnCount == 0){
			spawnWave ();
		}
	}

	void spawnWave(){
		spawnCount += enemysPerWave;
		enemysPerWave *= 2;
	}
}
