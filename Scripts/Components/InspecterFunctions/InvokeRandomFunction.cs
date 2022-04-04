using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InvokeRandomFunction : MonoBehaviour 
{
	public bool eventCanRepeat;
	public float eventInvokeInterval;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public UIEvents[] functionsToRun;

	List<UIEvents>  uninvokedFunctions = new List<UIEvents>();
	List<UIEvents>  invokedFunctions = new List<UIEvents>();

	void OnEnable () 
	{
		ResetAllFunctions ();
	}
	
	float eventInvokedRecordedTime;
	public void InvokeRandomEvent()
	{
		if(uninvokedFunctions.Count > 0)
		{
			if(Time.realtimeSinceStartup - eventInvokedRecordedTime < eventInvokeInterval)
			{
				eventInvokedRecordedTime = Time.realtimeSinceStartup; 
				return;
			}

			int randomEventIndex  = new System.Random().Next(0,uninvokedFunctions.Count);
			uninvokedFunctions[randomEventIndex].Invoke(gameObject);
			if(!eventCanRepeat){uninvokedFunctions.RemoveAt(randomEventIndex);}
		}
		else
		{
			ResetAllFunctions();
			InvokeRandomEvent();
		}
	}

	void ResetAllFunctions()
	{
		invokedFunctions.Clear ();
		uninvokedFunctions.Clear ();
		for (int i = 0; i < functionsToRun.Length; i++) 
		{
			uninvokedFunctions.Add(functionsToRun[i]);
		}
	}










	void UpdateFunctionNames () 
	{
		for (int i = 0; i < functionsToRun.Length; i++) 
		{
			for (int j = 0; j < functionsToRun[i].events.Length; j++) 
			{
				string finalValue = "";
				if(functionsToRun[i].events[j].ev.parameters != null)
				{
					for (int k = 0; k < functionsToRun[i].events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = functionsToRun[i].events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != functionsToRun[i].events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(functionsToRun[i].events[j].disable){evActive = "X ";}
				if(functionsToRun[i].events[j].delay > 0){delay = functionsToRun[i].events[j].delay.ToString() + " ";}
				if(functionsToRun[i].events[j].randomDelay.Length > 0){randomDelay = "[" + functionsToRun[i].events[j].randomDelay[0].ToString() + "," + functionsToRun[i].events[j].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(j > 9){space = "";}
				functionsToRun[i].events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + functionsToRun[i].events[j].ev.methodName + " (" + finalValue + ")" + "  [" + functionsToRun[i].events[j].ev.target.GetType() + "]";
			}
			
		}
	}










}
