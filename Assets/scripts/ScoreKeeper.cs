using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static bool playerTwoEnabled;
	public static string playerOneName;
	public static string playerTwoName;

	void Start(){
		Object.DontDestroyOnLoad (this);
	}
}
