using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour {

	public bool playerEntered = false;
	public Animator animController;
	public float cost;
	public bool OneWayUse;
	public Transform[] spawnpoints;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(playerEntered){
			if (Input.GetKeyDown (KeyCode.E) || Input.GetButtonDown ("p2_use")) {
				if (gameControllerScript.playerOne.points >= cost) {
					animController.SetBool ("open", !animController.GetBool ("open"));
					gameControllerScript.playerOne.points -= cost;
					if(OneWayUse){
						gameControllerScript.controller.enableSpawnerPoints (spawnpoints);
						Destroy (this);
					}

				//Update GUI!!
				} else {
				 //UPDATE GUI
				}


			}
			/*if(Input.Controller) {
gameControllerScript.playerTwo
								//TODO
			}*/
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Player2"){
	
		
			playerEntered = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Player2"){
			
			playerEntered = false;
		}
	}
}
