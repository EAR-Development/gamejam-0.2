using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public bool playerTwoEnabled;
	public string playerOneName;
	public string playerTwoName;

	void Start(){
		Object.DontDestroyOnLoad (this);
	}
}