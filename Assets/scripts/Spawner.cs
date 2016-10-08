

using UnityEngine;
using System.Collections;


using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	//public int maxUnits;



	public int maxIntervalPause;
	public int minIntervalPause;

	public int maxIntervalUnits;//Einheitenzahl innerhalb eines Wellenintervalls
	public string[] unitPool;
	public bool pause;
	public int intervalPause;
	private float counter;
	public float maxrange;
	public Vector3 aim;
	public List<Enemy> unity;



	int checkAfks;


	int waveUnits;
	public int maxWaveUnits;//Maximale Einheitenzahl der Welle

	public bool SpeedUpLastUnits;
	bool lastUnitsStanding;

	// Use this for initialization
	void Start () {
		
		pause = false;
		counter = 0;
		intervalPause = 1;
		waveUnits = 0;
	}

	// Update is called once per frame
	void Update () {



		/*	if (!pause) {
			counter += Time.deltaTime;

			for(int i=0;i<units.Count;i++){
				
				Enemy spawned = units [i] as IUnits<Vector3,GameObject,player>;
			
		       }*/
		/*	
			Enemy[] unitarray = GetComponents < Enemy> ();
			for (int i = 0; i < enemy.units.Count; i++) {


				//	unitarray [i-1].amove (aim);



			}

			if (counter >= intervalPause) {
				int interval;
				interval = Random.Range (0, maxIntervalUnits);//einheitenzahl der welle = random

				for (int i = 0; i < interval; i++) {
					
					Vector3 randomdir = Random.onUnitSphere * maxrange;
					randomdir += u.getPos ();
					aim = u.getPos ();
					NavMeshHit hit;
					NavMesh.SamplePosition (randomdir, out hit, maxrange, 1);
					int unitrandom = Random.Range (0, unitPool.Length);
					GameObject obj = Instantiate (Resources.Load(), hit.position, Quaternion.Euler (0, 0, 0))as GameObject;




					Vector3 finalPosition = hit.position;
					obj.transform.position = finalPosition;
					obj.transform.position += new Vector3 (0, 18f);
					Enemy spawned = obj.GetComponent<IUnits<Vector3,GameObject,player> > ();
					spawned.setPlayer (enemy);
					waveUnits++;
				}

				counter = 0;
				intervalPause = Random.Range (minIntervalPause, maxIntervalPause);
			}

			if (waveUnits >= maxWaveUnits) {

				pause = true;

			}
		} else {

			if(enemy.getUnits().Count==0){
				GetComponentInParent<WaveTimer> ().endNight ();
				Destroy (gameObject);
			}


	}	*/
	}

	void LateUpdate(){

		if(SpeedUpLastUnits&&maxWaveUnits - waveUnits <=3){
			if(!lastUnitsStanding){
				Invoke ("speedUpUnits",5f);
				lastUnitsStanding = true;
			}

		}

		/*for (int i = 0; i < enemy.units.Count; i++) {
			if (enemy.units [i].getLightCounter () == 0 && !Afkunits.Contains (enemy.units [i])) {
				Afkunits.Add (enemy.units [i]);
			
			}
		
		
		}
		for (int i = 0; i < Afkunits.Count; i++) {
			if (Afkunits [i].getLightCounter!=0) {
				Afkunits.RemoveAt (i);
			}
*/}

	void speedUpUnits(){
		/*for(int i=0;i<enemy.units.Count;i++){
			enemy.units [i].setSpeed (enemy.units [i].getSpeed()*2);
		}*/
		lastUnitsStanding = false;
	}


}
