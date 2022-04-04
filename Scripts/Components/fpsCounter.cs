using UnityEngine;
using System.Collections;

public class fpsCounter : MonoBehaviour {
	int fps;
    public tk2dTextMesh textMesh;
	IEnumerator Start(){
		while (true) {
			fps = (int)(1.0f / Time.smoothDeltaTime);
            if(textMesh!=null)textMesh.text = fps.ToString();
            yield return new WaitForSeconds (1);
		}
	}
	void OnGUI()
	{
		GUI.Label(new Rect(0, 0, 100, 100), fps.ToString ());        
	}
}
