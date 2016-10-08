using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {

	public string[] enemyTypes;
	public int[] enemyCount;


	public List<Enemy> spawnedUnits;

	public float spawnTime = 0.3f;

	public int totalEnemys = 10;


	private float spawnTimer = 0;
	private int spawnCount = 0;

	float intervallTimer=0;
	 float intervallPause = 0;
	public float maxIntervallPause = 5;
	public float minIntervalPause=3;

	public float maxIntevallUntis = 3;
	public float minIntervallUnits = 2;

	public gameControllerScript gcs;






	// Use this for initialization
	void Start () {
		spawnedUnits = new List<Enemy> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		intervallTimer += Time.deltaTime;

		if(intervallTimer>=intervallPause){

			float intervallUnits = 0;


			intervallUnits = Random.Range (maxIntevallUntis,maxIntervallPause);
			if(spawnCount +intervallUnits> totalEnemys){

				intervallUnits = totalEnemys - spawnCount;

			}

			spawnTimer += Time.deltaTime;


		
			int spawnedCounter=0;
			while(spawnedCounter<intervallUnits){

				for(int i=0;i<enemyTypes.Length;i++){
					float r =(int) Random.Range (0,1);
					if(r<0.5f){
						print (enemyTypes[i]);
						Enemy e = (Instantiate (((Resources.Load(enemyTypes[i]) as GameObject)), transform.position, transform.rotation) as GameObject).GetComponent<Enemy>();
						spawnedCounter++;
						e.spawner = this;
						spawnedUnits.Add (e);

					}
				


				}

			
			}

			spawnCount += spawnedCounter;
			intervallTimer = 0;
			intervallPause = Random.Range (minIntervalPause, maxIntervallPause);


		}
	
		if(spawnCount>=totalEnemys&&spawnedUnits.Count==0){
			print ("nextWave");
			gcs.spawnNextWave ();
		}
	
	}

	public void spawnWave(int amount){
		spawnCount += amount;
	}
}
