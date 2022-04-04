using UnityEngine;
using System.Collections;

public class GuiSwipe : MonoBehaviour {
	
	public float minimumSwipeSpeed;
	public float minimumSwipeDistance;
	public LayerMask layerMask;
	public Camera rayCastCamera;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public UIEvents onTopSwipe,onRightSwipe,onDownSwipe,onLeftSwipe;




	private float resolutionFactor;
	void Start () 
	{
		resolutionFactor = (480.0f + 800.0f) / (Screen.width + Screen.height);
	}

	private Touch touch;
	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.touches[0];
			if (touch.phase == TouchPhase.Began){CastRay(touch.position);}

			if (fingerTouchedCollider)
			{
				if (touch.phase == TouchPhase.Ended)
				{
					FingerLifted(touch.position);
				}
			}
		}
		
#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0)) {CastRay(Input.mousePosition);}
		if(fingerTouchedCollider) 
		{
			if(Input.GetMouseButtonUp(0)) 
			{
				FingerLifted(Input.mousePosition);
			}
		}
#endif
	}

	private Ray ray;
	private RaycastHit hit;
	public void CastRay(Vector3 fingerPosition) 
	{
		GuiSwipe guiSwipe = null;
		fingerTouchedCollider = false;
		ray = rayCastCamera.ScreenPointToRay(fingerPosition);
		if(Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask))
		{
			guiSwipe = hit.collider.GetComponent<GuiSwipe>();
			if(guiSwipe == null){guiSwipe = hit.collider.transform.parent.GetComponent<GuiSwipe>();}
			if(guiSwipe != null)
			{
				guiSwipe.FingerTouchedCollider(fingerPosition);
			}
			//Debug.DrawLine(ray.origin, hit.point,Color.red,5);
		}
	}

	public bool fingerTouchedCollider;
	private Vector3 fingerRecordedPosition;
	private float fingerRecordedTime;
	public void FingerTouchedCollider(Vector3 fingerPosition) 
	{
		fingerTouchedCollider = true;
		fingerRecordedPosition = fingerPosition;
		fingerRecordedTime = Time.realtimeSinceStartup;
	}

	private Vector3 fingerCurrentPosition;
	private float fingerCurrentTime;
	private void FingerLifted(Vector3 fingerPosition) 
	{
		fingerCurrentPosition = fingerPosition;
		fingerCurrentTime = Time.realtimeSinceStartup;
		fingerTouchedCollider = false;
		swipe_detector ();
	}

	[HideInInspector] public float swipeSpeed;
	private float swipeDistance;
	private string swipeDirection;
	private float swipeAngle;
	private void swipe_detector() 
	{
		swipeDistance = (Vector3.Distance (fingerRecordedPosition, fingerCurrentPosition) * resolutionFactor)/40;
		swipeSpeed = swipeDistance/(fingerCurrentTime - fingerRecordedTime);
		//print (swipeDistance);
		if(swipeDistance > minimumSwipeDistance)
		{
			if(swipeSpeed > minimumSwipeSpeed)
			{
				Vector2 temp_1 = new Vector2 ( fingerRecordedPosition.x,fingerRecordedPosition.y);
				Vector2 temp_2 = new Vector2 ( fingerCurrentPosition.x,fingerCurrentPosition.y  );
				swipeAngle = (Mathf.Atan2(temp_2.y-temp_1.y, temp_2.x-temp_1.x)*180) / Mathf.PI;
				if(swipeAngle < 0){swipeAngle += 360;}
				
				if(swipeAngle > 315 || swipeAngle  <= 45  ){swipeDirection = "right"; onRightSwipe.Invoke(gameObject);}
				if(swipeAngle > 45  && swipeAngle  <= 135 ){swipeDirection = "up";    onTopSwipe.Invoke(gameObject);}
				if(swipeAngle > 135 && swipeAngle  <= 225 ){swipeDirection = "left";  onLeftSwipe.Invoke(gameObject);}
				if(swipeAngle > 225 && swipeAngle  <= 315 ){swipeDirection = "down";  onDownSwipe.Invoke(gameObject);}
				//print(swipeDirection);
			}
		}

	}



	UIEvents functionsToRun; 
	void UpdateFunctionNames () 
	{
		/*onFingerDown.events = new UIEvents.UIEvent[onFingerUp.events.Length];
		for (int i = 0; i < onFingerUp.events.Length; i++) 
		{
			onFingerDown.events[i] = onFingerUp.events[i];
		}*/
		
		
		for (int z = 0; z < 4; z++) 
		{
			if(z == 0){functionsToRun = onTopSwipe;}
			if(z == 1){functionsToRun = onRightSwipe;}
			if(z == 2){functionsToRun = onDownSwipe;}
			if(z == 3){functionsToRun = onLeftSwipe;}
			
			for (int i = 0; i < functionsToRun.events.Length; i++) 
			{
				string finalValue = "";
				if(functionsToRun.events[i].ev.parameters != null)
				{
					for (int j = 0; j < functionsToRun.events[i].ev.parameters.Length; j++) 
					{
						string value = string.Empty;
						try   {value = functionsToRun.events[i].ev.parameters[j].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(j != functionsToRun.events[i].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(functionsToRun.events[i].disable){evActive = "X ";}
				if(functionsToRun.events[i].delay > 0){delay = functionsToRun.events[i].delay.ToString() + " ";}
				if(functionsToRun.events[i].randomDelay.Length > 0){randomDelay = "[" + functionsToRun.events[i].randomDelay[0].ToString() + "," + functionsToRun.events[i].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(i > 9){space = "";}
				functionsToRun.events[i].label = "" + i + space + "  " + evActive + delay + randomDelay + functionsToRun.events[i].ev.methodName + " (" + finalValue + ")" + "  [" + functionsToRun.events[i].ev.target.GetType() + "]";
				
				
			}
		}
		
		
	}













}
