using UnityEngine;
using System.Collections;

public class VersionTag : MonoBehaviour {
	private string VERSION;
	#if UNITY_EDITOR
	void setVersion(){
		VERSION = "developer build";
	}
	#else
	void setVersion(){
		VERSION = "0.0.01";
	}
	#endif

	public bool ShowVersionInformation = false;
	public bool ShowVersionDuringTheFirst20Seconds = true;
	Rect position = new Rect (0, 0, 100, 20);



	void Start ()
	{
		setVersion ();
		DontDestroyOnLoad (this);

		if (ShowVersionDuringTheFirst20Seconds) {
			ShowVersionInformation = true;
			Destroy (this, 20f);
		}

		position.x = 10f;
		position.y = Screen.height - position.height - 10f;


	}


	void OnGUI ()
	{
		if (!ShowVersionInformation) {
			return;
		}

		GUI.contentColor = Color.white;
		GUI.Label (position, VERSION);
	}
}