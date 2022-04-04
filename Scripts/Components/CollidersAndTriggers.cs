using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class CollidersAndTriggers : MonoBehaviour 
{
	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;




	[HideInInspector] public CollisionDetector CollisionDetector;
	public UIEventBasedOnCollisionDetectorType[] UIEventsBasedOnCollisionDetectorType;

	[Serializable]
	public class UIEventBasedOnCollisionDetectorType 
	{
		public string runFor;
		public UIEvents functionsToRun;
	}




	void UpdateFunctionNames () 
	{
		for (int i = 0; i < UIEventsBasedOnCollisionDetectorType.Length; i++) 
		{
			for (int j = 0; j < UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events.Length; j++) 
			{
				string finalValue = "";
				if(UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.parameters != null)
				{
					for (int k = 0; k < UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}

						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}

				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;

				if(UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].disable){evActive = "X ";}
				if(UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].delay > 0){delay = UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].delay.ToString() + " ";}
				if(UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].randomDelay.Length > 0){randomDelay = "[" + UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].randomDelay[0].ToString() + "," + UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].randomDelay[1].ToString() + "] ";}

				string space = ". ";
				if(j > 9){space = "";}
				UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.methodName + " (" + finalValue + ")" + "  [" + UIEventsBasedOnCollisionDetectorType[i].functionsToRun.events[j].ev.target.GetType() + "]";
			}

		}
	}








}
