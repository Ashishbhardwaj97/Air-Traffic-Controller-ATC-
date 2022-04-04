using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GuiRayReceiver : MonoBehaviour 
{
	public AudioClip soundToPlay;
	public float soundVolume = 1;
	public Vector3 pressedScale = new Vector3(.95f,.95f,.95f);
	public float guiBtnsDisableTimeWhenPressed;
	public float thisBtnDisableTimeWhenPressed;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public UIEvents onFingerDown,onFingerMoved,onFingerUp;
	[HideInInspector] public Vector3 fingerPosition;
	[HideInInspector] public Transform selfTransform;

	private int fingerID;
	public bool mouseHeldDown;
	private Touch touch;


	void Awake () {selfTransform = transform;}

	void Update () 
	{
		if(mouseHeldDown)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				touch = Input.touches[i];
				if(touch.fingerId == fingerID)
				{
					if (touch.phase == TouchPhase.Moved){FingerMoved(touch.position);}
					if (touch.phase == TouchPhase.Ended){FingerLifted(touch.position);}
				}
			}
			
			if(Input.mousePresent)
			{
				FingerMoved(Input.mousePosition);
				if(Input.GetMouseButtonUp(0)) {FingerLifted(Input.mousePosition) ;}
			}
		}
	}

	[HideInInspector] public Vector3 fingerRecordedPosition;
	public void FingerTouched(int fingerID_Local,Vector3 fingerPositionLocal) 
	{
		mouseHeldDown = true;
		if(soundToPlay != null){SoundManager.instance.PlaySound (soundToPlay,soundVolume);}
		selfTransform.localScale = pressedScale;
		fingerID = fingerID_Local;
		fingerRecordedPosition = fingerPositionLocal;
		fingerPosition = fingerPositionLocal;
		InvokeFunctionsOnTouchOrMoveOrLifted(onFingerDown);
	}
	
	public void FingerMoved(Vector3 fingerPositionLocal) 
	{
		if(mouseHeldDown)
		{
			fingerPosition = fingerPositionLocal;
			InvokeFunctionsOnTouchOrMoveOrLifted(onFingerMoved);
		}
	}
	
	public void FingerLifted(Vector3 fingerPositionLocal) 
	{
		if(mouseHeldDown)
		{
			mouseHeldDown = false;
			selfTransform.localScale = new Vector3(1,1,1);
			fingerPosition = fingerPositionLocal;
			if(Vector3.Distance(fingerRecordedPosition,fingerPositionLocal) > 20){return;}
			InvokeFunctionsOnTouchOrMoveOrLifted(onFingerUp);
		}
	}

	private float fingerTouchedRecordedTime;
	public void InvokeFunctionsOnTouchOrMoveOrLifted(UIEvents functions) 
	{
		if(functions != null)
		{
			if(Time.realtimeSinceStartup - fingerTouchedRecordedTime < thisBtnDisableTimeWhenPressed){return;}
			fingerTouchedRecordedTime = Time.realtimeSinceStartup;
			
			if(guiBtnsDisableTimeWhenPressed > 0)
			{
				GuiRayCaster.ins.fingerTouchedScreenRecordedTime = Time.realtimeSinceStartup;
				GuiRayCaster.ins.stopExecutionTime = guiBtnsDisableTimeWhenPressed;
			}
			functions.Invoke (gameObject);
		}
	}



	public void InvokeAllFunctions() 
	{
		onFingerUp.Invoke(gameObject);
		onFingerDown.Invoke(gameObject);
	}






	UIEvents functionsToRun; 
	void UpdateFunctionNames () 
	{
		/*onFingerDown.events = new UIEvents.UIEvent[onFingerUp.events.Length];
		for (int i = 0; i < onFingerUp.events.Length; i++) 
		{
			onFingerDown.events[i] = onFingerUp.events[i];
		}*/


		for (int z = 0; z < 3; z++) 
		{
			if(z == 0){functionsToRun = onFingerDown;}
			if(z == 1){functionsToRun = onFingerMoved;}
			if(z == 2){functionsToRun = onFingerUp;}

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
				functionsToRun.events[i].label = "" + i + space + "  " + evActive + delay + randomDelay + functionsToRun.events[i].ev.methodName + " (" + finalValue + ")" + "  [" + functionsToRun.events[i].ev.target.ToString() + "]";

				
			}
		}


	}
































}
