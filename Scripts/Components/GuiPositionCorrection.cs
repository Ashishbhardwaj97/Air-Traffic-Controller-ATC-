using UnityEngine;
using System.Collections;
using System;

public class GuiPositionCorrection : MonoBehaviour {

	public Transform selfTransform;
	public bool snapTop;
	public bool snapRight;
	public bool snapBottom;
	public bool snapLeft;


	public Camera rayCastCam;
	public LayerMask layerMask;






	RaycastHit hit;
	Ray ray;
	void Start () 
	{
		if(snapTop)
		{
			ray = rayCastCam.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height) );
			if(Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
			{
				selfTransform.position = new Vector3(selfTransform.position.x,hit.point.y,selfTransform.position.z);
				Debug.DrawLine(ray.origin, hit.point,Color.red,5);
			}
		}

		if(snapBottom)
		{
			ray = rayCastCam.ScreenPointToRay(new Vector2(Screen.width/2,0) );
			if(Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
			{
				selfTransform.position = new Vector3(selfTransform.position.x,hit.point.y,selfTransform.position.z);
				Debug.DrawLine(ray.origin, hit.point,Color.red,5);
			}
		}
	}
	
}
