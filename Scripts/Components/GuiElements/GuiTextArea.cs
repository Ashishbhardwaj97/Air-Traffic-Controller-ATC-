using UnityEngine;
using System.Collections;

public class GuiTextArea : MonoBehaviour {

	public GUISkin GUISkin;
	public int fontSize;
	public Camera cam;
	public tk2dTiledSprite bg;

	public string placeHolderTxt;

	public void SetPlaceHolderTxt (string txt) 
	{
		placeHolderTxt = txt;
	}

	void Start () 
	{
	}

	void OnGUI () 
	{
		GUI.skin = GUISkin;
		GUISkin.textArea.fontSize = (int)((Screen.width / 480.0f) * fontSize);
		Vector3 bgScreenPos = cam.WorldToScreenPoint(bg.transform.position);
		//placeHolderTxt = GUI.TextArea(new Rect(bgScreenPos.x,Screen.height - bgScreenPos.y,bg.dimensions.x,bg.dimensions.y),placeHolderTxt);
		placeHolderTxt = GUI.TextArea(new Rect(bgScreenPos.x,Screen.height - bgScreenPos.y,bg.dimensions.x,bg.dimensions.y),placeHolderTxt);
	}
}
