using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour {

	public bool playerEntered = false;
	public Animator animController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerEntered){
			if (Input.GetKeyDown (KeyCode.E)) {
				animController.SetBool("open", !animController.GetBool("open"));
			}
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
