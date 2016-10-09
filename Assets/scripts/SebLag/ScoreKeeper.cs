using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public bool playerTwoEnabled;
	public string playerOneName;
	public string playerTwoName;
	public bool flippedMenu=false;

	public bool afterGame = false;

	public int playerOneHit = 0;
	public int playerOneMissed = 0;
	public int playerOneKills = 0;
	public int playerOnePoints = 0;

	public int playerTwoHit = 0;
	public int playerTwoMissed = 0;
	public int playerTwoKills = 0;
	public int playerTwoPoints = 0;

	void Start(){
		Object.DontDestroyOnLoad (this);
	}
}