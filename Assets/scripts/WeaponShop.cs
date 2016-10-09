using UnityEngine;
using System.Collections;

public class WeaponShop: MonoBehaviour {

	public bool playerEntered = false;
	public Animator animController;
	public float cost;
	public Gun gun;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(playerEntered){
			if (Input.GetKeyDown (KeyCode.E)) {
				if (gameControllerScript.playerOne.points >= cost) {
					Player p = gameControllerScript.playerOne;
					animController.SetBool ("open", !animController.GetBool ("open"));
					p.points -= cost;



				
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
