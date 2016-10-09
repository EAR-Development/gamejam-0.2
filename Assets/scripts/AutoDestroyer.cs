using UnityEngine;
using System.Collections;

public class AutoDestroyer : MonoBehaviour {
	bool decay;
	Transform trans;
	// Use this for initialization
	void Start () {
		trans = transform;
		decay = false;
		Invoke ("Decay",3);
		Invoke ("delayedDestroy",5);
	}

	void Update(){
		if(decay){
			trans.position = Vector3.MoveTowards (trans.position, trans.position + Vector3.down , Time.deltaTime /5);
		}
	}
	
	public void delayedDestroy(){
		GameObject.Destroy (gameObject);
	}

	public void Decay(){

		decay = true;

	}


}
