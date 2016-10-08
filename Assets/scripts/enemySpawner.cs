using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {

	public string[] enemyTypes;
	public int[] enemyCount;


	public List<Enemy> spawnedUnits;

	public float spawnTime = 0.3f;

	public int enemysPerWave = 10;


	private float spawnTimer = 0;
	private int spawnCount = 0;



	// Use this for initialization
	void Start () {
		spawnedUnits = new List<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= spawnTime && spawnCount > 0) {
			spawnTimer = 0;
			spawnCount -= 1;

			for(int i=0;i<enemyTypes.Length;i++){
				float r =(int) Random.Range (0,1);
				GameObject e = Instantiate (Resources.Load(enemyTypes[i]) as GameObject, transform.position, transform.rotation) as GameObject;
			}


		}
	}

	public void spawnWave(int amount){
		spawnCount += amount;
	}
}
