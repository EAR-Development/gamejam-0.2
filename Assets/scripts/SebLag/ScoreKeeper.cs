using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public bool playerTwoEnabled;
	public string playerOneName;
	public string playerTwoName;
	public bool flippedMenu=false;

	void Start(){
		Object.DontDestroyOnLoad (this);
	}
}