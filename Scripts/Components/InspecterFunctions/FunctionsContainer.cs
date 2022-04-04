using UnityEngine;
using System.Collections;
using System;

public class FunctionsContainer : MonoBehaviour 
{
	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public UIEvents functionsToRun;
	public UIEventsWithTag[] functionsToRunWithTags;

	public void InvokeFunctions()
	{
		functionsToRun.Invoke (gameObject);
	}

	public void InvokeFunctionsWithTag(string tag)
	{
		for (int i = 0; i < functionsToRunWithTags.Length; i++) 
		{
			if(functionsToRunWithTags[i].tag == tag)
			{
				functionsToRunWithTags[i].functionsToRun.Invoke(gameObject);
				break;
			}
		}
	}

	[Serializable]
	public class UIEventsWithTag
	{
		public string tag;
		public UIEvents functionsToRun;
	}


	void UpdateFunctionNames () 
	{
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


		for (int i = 0; i < functionsToRunWithTags.Length; i++) 
		{
			for (int j = 0; j < functionsToRunWithTags[i].functionsToRun.events.Length; j++) 
			{
				string finalValue = "";
				if(functionsToRunWithTags[i].functionsToRun.events[j].ev.parameters != null)
				{
					for (int k = 0; k < functionsToRunWithTags[i].functionsToRun.events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = functionsToRunWithTags[i].functionsToRun.events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != functionsToRunWithTags[i].functionsToRun.events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(functionsToRunWithTags[i].functionsToRun.events[j].disable){evActive = "X ";}
				if(functionsToRunWithTags[i].functionsToRun.events[j].delay > 0){delay = functionsToRunWithTags[i].functionsToRun.events[j].delay.ToString() + " ";}
				if(functionsToRunWithTags[i].functionsToRun.events[j].randomDelay.Length > 0){randomDelay = "[" + functionsToRunWithTags[i].functionsToRun.events[j].randomDelay[0].ToString() + "," + functionsToRunWithTags[i].functionsToRun.events[j].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(j > 9){space = "";}
				functionsToRunWithTags[i].functionsToRun.events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + functionsToRunWithTags[i].functionsToRun.events[j].ev.methodName + " (" + finalValue + ")" + "  [" + functionsToRunWithTags[i].functionsToRun.events[j].ev.target.GetType() + "]";
			}
			
		}
	}
}
