using UnityEngine;
using System.Collections;

public class DoubleTapDetector : MonoBehaviour 
{
	public static DoubleTapDetector ins; 
	void Awake() {ins = this;}

	public UIEvents events;
	public bool active;

	void Update () 
	{
		if(active)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(!detectTapRunning){StartCoroutine("DetectTap");}
			}
		}
	}

	bool detectTapRunning;
	IEnumerator DetectTap ()
	{
		yield return new WaitForSeconds (.09f);
		detectTapRunning = true;
		float timeSpended = 0;
		while (timeSpended < .4f) 
		{

			timeSpended += 1*Time.deltaTime;
			if(Input.GetMouseButtonDown(0)) { events.Invoke(gameObject); detectTapRunning = false; yield break;}
			yield return null;
		}
		detectTapRunning = false;
	}


}
