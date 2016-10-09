using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class gameControllerScript : MonoBehaviour {

	public Canvas pausemenu;
	public Canvas endMenu;

	public Transform target;
	LivingEntity targetEntity;

	public GameObject ScoreKeeperPrefab;
	public ScoreKeeper scoreKeeper;

	public float timeBetweenWaves = 10f;
	public float spawnTimeInWave = 2.5f;
	public int enemysPerSpawner = 5;
	public float waveFactor = 1.2f;


	int nextWave = 0;
	public GameObject[] allSpawner;
	public enemySpawner currentSpawner;

	GUIController guiController;


	public List<Transform> spawnpoints;
	public Transform spawnPointsParent;

	public static Player playerOne{ get; set;}
	public static Player playerTwo{ get; set;}
	public static gameControllerScript controller{ get; set;}


	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;

		scoreKeeper = (ScoreKeeper)FindObjectOfType (typeof(ScoreKeeper));

		if (scoreKeeper == null) {
			scoreKeeper = Object.Instantiate (ScoreKeeperPrefab).GetComponent<ScoreKeeper> ();

			scoreKeeper.playerTwoEnabled = false;
			scoreKeeper.playerOneName = "Peter Lustig";
			scoreKeeper.playerTwoName = "";
		}

		Debug.Log ("Start");

		if (GameObject.FindGameObjectWithTag ("Player") != null) {

			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetEntity = target.GetComponent<LivingEntity> ();
			gameControllerScript.playerOne = target.GetComponent<Player> ();
			//player 2 TODO
			targetEntity.OnDeath += OnPlayerDeath;
		}

		guiController = GetComponent<GUIController> ();

		guiController.setScoreKeeper(scoreKeeper);

		pausemenu = pausemenu.GetComponent<Canvas> ();
		pausemenu.enabled = false;

		endMenu = endMenu.GetComponent<Canvas> ();
		endMenu.enabled = false;

		setupSpawnpoints ();
		gameControllerScript.controller = this;

	}

	void OnAwake(){
		



	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			EscapeKeyPressed ();
		}


	}

	public void spawnNextWave (){

		/*if( currentSpawner.spawnedUnits.Count){
			waveTimer = 0;
			foreach (enemySpawner s in allSpawner){
				s.spawnWave (enemysPerSpawner);
			}
			enemysPerSpawner = Mathf.FloorToInt(enemysPerSpawner * waveFactor);

			guiController.OnNextWave (nextWave);
			nextWave++;
		}*/


		Destroy (currentSpawner.gameObject);
		currentSpawner = (Instantiate (allSpawner [nextWave]) as GameObject).GetComponent<enemySpawner> ();
		currentSpawner.gcs = this;
		nextWave++;

	}

	public void EscapeKeyPressed(){
		pausemenu.enabled = ! pausemenu.enabled;

		if (pausemenu.enabled) {
			Cursor.visible = true;
		} else {
			Cursor.visible = false;
		}

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Player controller = player.GetComponent<Player> ();
			controller.pause = !controller.pause;
		}

		if (Time.timeScale == 1.0F) {
			Time.timeScale = 0.0F;
		} else {
			Time.timeScale = 1.0F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	public void ExitButtonPressed(){
		SceneManager.LoadScene ("scenes/menu");
	}

	public void ResumeButtonPressed(){
		EscapeKeyPressed ();
	}

	public void RestartButtonPressed(){
		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		SceneManager.LoadScene ("scenes/SebLag/game");
	}

	void OnPlayerDeath() {
		Time.timeScale = 0.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		Cursor.visible = true;
		endMenu.enabled = true;
	}

	public Vector3[] getClosestSpawnPoints(int range, Vector3 pos){



		spawnpoints.Sort (((Transform x, Transform y) =>(int)Vector3.Distance(x.position,pos) -(int) Vector3.Distance(y.position,pos)));
		Vector3[] ret=new Vector3[range];

		for(int i=0;i<range;i++) {

			ret [i] = spawnpoints [i].position;

		}

		return ret;

	}

	public void setupSpawnpoints(){


		spawnpoints = new List<Transform> ();
		spawnpoints.AddRange (spawnPointsParent.GetComponentsInChildren<Transform>());

	}

	public void enableSpawnerPoints(Transform[] points){

		for(int i=0;i<spawnpoints.Count;i++){

			for(int j=0;j<points.Length;i++){

				if(points[j]==spawnpoints[i]){
					spawnpoints [i].gameObject.SetActive (true);
				}

			}

		}

	}
}