using UnityEngine;
using System.Collections;

public class VersionTag : MonoBehaviour {
	string VERSION = "Developer Build";

	public bool ShowVersionInformation = false;
	public bool ShowVersionDuringTheFirst20Seconds = true;
	Rect position = new Rect (0, 0, 100, 20);


	void Start ()
	{
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