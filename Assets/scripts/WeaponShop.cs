using UnityEngine;
using System.Collections;

public class WeaponShop: MonoBehaviour {

	public bool playerEntered = false;

	public float cost;
	public string ShopTitle;

	public Gun gun;
	public Material m;
	public Transform wobblePlate;
	public Color wobbleColor;

	Renderer renderer;

	// Use this for initialization
	void Start () {
		m = new Material ((wobblePlate.GetComponent<Material> () as Material));
		m.SetColor ("emission",Color.blue);
	}

	// Update is called once per frame
	void Update () {



		renderer = wobblePlate.GetComponent<Renderer> ();
			m = renderer.material;

			float emission = Mathf.PingPong (Time.time, 1.0f);


		Color finalColor = wobbleColor * Mathf.LinearToGammaSpace (emission);

			m.SetColor ("_EmissionColor", finalColor);


		if(playerEntered){
			if (Input.GetKeyDown (KeyCode.E)) {
				print ("ttest");
				if (gameControllerScript.playerOne.points >= cost) {
					
					Player p = gameControllerScript.playerOne;
					p.points -= cost;


					p.GetComponent<GunController> ().pickUpNewWeapon (gun);

				
					//Update GUI!!
				} else {
					//UPDATE GUI
					print("'NOT ENOUGH ROBOCACHE!");
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
