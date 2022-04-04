using UnityEngine;
using System.Collections;

public class CameraFunctions : MonoBehaviour 
{
	public static CameraFunctions instance; 
	void Awake() {instance = this;}

	public void SetCameraZoom (tk2dCamera cam,float from,float to,float time) 
	{
		StartCoroutine (SetCameraZoomCoroutine(cam,from,to,time));
	}

	IEnumerator SetCameraZoomCoroutine (tk2dCamera cam,float from,float to,float time) 
	{
		float value = 0;
		float lerpValue = 0;
		float amount = Mathf.Abs (from - to);
		float speed = amount/time; 
		float recordedTime = Time.realtimeSinceStartup;
		while(lerpValue < 1)
		{
			//lerpValue += speed*Time.deltaTime;
			lerpValue = (Time.realtimeSinceStartup - recordedTime) * 1/time;
			cam.ZoomFactor = Mathf.Lerp(from,to,lerpValue);
			yield return null;
		}
	}
}
