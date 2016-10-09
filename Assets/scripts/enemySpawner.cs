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

	public float maxUnitsAlive;
	public gameControllerScript gcs;






	// Use this for initialization
	void Start () {
		spawnedUnits = new List<Enemy> ();

	}

	// Update is called once per frame
	void Update () {

		intervallTimer += Time.deltaTime;

		if(intervallTimer>=intervallPause){
			intervallTimer = 0;
			if(spawnedUnits.Count<maxUnitsAlive){
				
		
			float intervallUnits = 0;


			intervallUnits = Random.Range (maxIntevallUntis,maxIntervallPause);
			if(spawnCount +intervallUnits> totalEnemys){

				intervallUnits = totalEnemys - spawnCount;

			}

			spawnTimer += Time.deltaTime;



			int spawnedCounter=0;
			int breakCondition = 0;
			while(spawnedCounter<intervallUnits){

				for(int i=0;i<enemyTypes.Length;i++){
					float r =(int) Random.Range (0,2);
					int s=(int)Random.Range(0,4);
					//print ( r +" " +enemyCount[i]/totalEnemys );
					if(/*r<enemyCount[i]/totalEnemys*/true){
						//print (enemyTypes[i]);
						Enemy e = (Instantiate (((Resources.Load(enemyTypes[i]) as GameObject)), gcs.getClosestSpawnPoints(4,gcs.target.position)[s], transform.rotation) as GameObject).GetComponent<Enemy>();
						spawnedCounter++;
						e.spawner = this;
						spawnedUnits.Add (e);

					}



				}
				breakCondition++;
				if(breakCondition>10){
					break;
				}

			}

			spawnCount += spawnedCounter;
			
			intervallPause = Random.Range (minIntervalPause, maxIntervallPause);


		}
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