using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{	
	public Texture2D cursorTexture;


    void Start()
	{
		//cursorSet(cursorTexture);
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
    
    
	void cursorSet(Texture2D tex)
	{
		CursorMode mode = CursorMode.Auto;
		int xspot = tex.width*2;
		int yspot = tex.height*2;
		Vector2 hotSpot = new Vector2(xspot,yspot);
		Cursor.SetCursor(tex, hotSpot, mode);
	}

	

}
