using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	//Otherwise you can do it publicly.  
	public Texture2D cursor;

	public void OnPointerEnter()
	{
		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);
	}

	public void OnPointerExit()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

}
