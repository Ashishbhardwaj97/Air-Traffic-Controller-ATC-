using UnityEngine;
using System.Collections;
using System;

public class GuiRayCaster : MonoBehaviour 
{
	public static GuiRayCaster ins; 
	void Awake() 
	{
		ins = this;
		if(hover){StartCoroutine("HoverDetectionCoroutine");}
	}

	public bool hover;
	public Vector3 hoverScale;

	public raycastCam[] raycastCams;
	private RaycastHit hit;
	private Ray ray;
	private Touch touch;

	[Serializable]
	public class raycastCam
	{
		public Camera cam;
		public LayerMask layerMask;
		[HideInInspector] public GuiRayReceiver hoverGuiRayReciever;
	}

	bool compActive = true;
	public void SetCompActiveState (bool activeState) 
	{
		compActive = activeState;
	}


	void Update () 
	{
		if(!compActive){return;}
		if(Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				touch = Input.touches[i];
				if (touch.phase == TouchPhase.Began)
				{
					FingerTouchedScreen(touch.position,touch.fingerId);
				}
			}
		}
		
		if(Input.mousePresent)
		{
			if(Input.GetMouseButtonDown(0)) 
			{
				FingerTouchedScreen(Input.mousePosition,0);
			}
		}
	}
	
	[HideInInspector] public float fingerTouchedScreenRecordedTime;
	[HideInInspector] public float stopExecutionTime;
	private void FingerTouchedScreen(Vector3 fingerPosition,int fingerID) 
	{
		if(Time.realtimeSinceStartup - fingerTouchedScreenRecordedTime < stopExecutionTime){return;}
		
		for (int i = 0; i < raycastCams.Length; i++) 
		{
			ray = raycastCams[i].cam.ScreenPointToRay(fingerPosition);
			if(Physics.Raycast(ray, out hit, Mathf.Infinity,raycastCams[i].layerMask))
			{
				GuiRayReceiver guiRayReceiver = hit.collider.GetComponent<GuiRayReceiver>();
				if(guiRayReceiver == null){guiRayReceiver = hit.collider.transform.parent.GetComponent<GuiRayReceiver>();}
				if(guiRayReceiver != null)
				{
					guiRayReceiver.FingerTouched(fingerID,fingerPosition);
				}
				Debug.DrawLine(ray.origin, hit.point,Color.red,5);
			}
		}
	}
	
	IEnumerator HoverDetectionCoroutine() 
	{
		while (true) 
		{
			for (int i = 0; i < raycastCams.Length; i++) 
			{
				ray = raycastCams[i].cam.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit, Mathf.Infinity,raycastCams[i].layerMask))
				{
					GuiRayReceiver guiRayReceiver = hit.collider.GetComponent<GuiRayReceiver>();
					if(guiRayReceiver == null){guiRayReceiver = hit.collider.transform.parent.GetComponent<GuiRayReceiver>();}
					if(guiRayReceiver != null)
					{
						if(raycastCams[i].hoverGuiRayReciever == null)
						{
							raycastCams[i].hoverGuiRayReciever = guiRayReceiver;
							raycastCams[i].hoverGuiRayReciever.selfTransform.localScale = hoverScale;
						}
						else
						{
							if(raycastCams[i].hoverGuiRayReciever != guiRayReceiver)
							{
								raycastCams[i].hoverGuiRayReciever.selfTransform.localScale = new Vector3(1,1,1);
								raycastCams[i].hoverGuiRayReciever = null;
							}
						}

					}
					else
					{
						if(raycastCams[i].hoverGuiRayReciever != null)
						{
							raycastCams[i].hoverGuiRayReciever.selfTransform.localScale = new Vector3(1,1,1);
							raycastCams[i].hoverGuiRayReciever = null;
						}
					}
				}

				Debug.DrawLine(ray.origin, hit.point,Color.yellow,5);
			}
			yield return new WaitForEndOfFrame();
		}
	}
	
}
