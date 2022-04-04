using UnityEngine;
using System.Collections;

public class GuiTextField : MonoBehaviour {

	public GUISkin GUISkin;
	public int fontSize = 15;
	public Camera cam;

	public string placeHolderTxt;
	public tk2dTiledSprite bg;


	public void SetPlaceHolderTxt (string txt) 
	{
		placeHolderTxt = txt;
	}

	void OnGUI () 
	{
		GUI.skin = GUISkin;
		GUISkin.textArea.fontSize = (int)((Screen.width / 480.0f) * fontSize);
		Vector3 bgScreenPos = cam.WorldToScreenPoint(bg.transform.position);
		placeHolderTxt = GUI.TextField(new Rect(bgScreenPos.x,Screen.height - bgScreenPos.y,bg.dimensions.x,bg.dimensions.y),placeHolderTxt);
	}
}
