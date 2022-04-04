using UnityEngine;
using System.Collections;

public class BackBtnPressed : MonoBehaviour 
{
	public bool compActive = true;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;


	public UIEvents events; 

	void Update () 
	{
		if(Input.GetKeyUp("escape"))
		{
			if(compActive){events.Invoke(gameObject);}
		}
	}

	public void SetCompActiveState (bool isActive) 
	{
		compActive = isActive;
	}

	void UpdateFunctionNames () 
	{
		for (int i = 0; i < events.events.Length; i++) 
		{
			string finalValue = "";
			if(events.events[i].ev.parameters != null)
			{
				for (int j = 0; j < events.events[i].ev.parameters.Length; j++) 
				{
					string value = string.Empty;
					try   {value = events.events[i].ev.parameters[j].value.ToString();}
					catch {value = "Null,";}
					
					if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
					if(j != events.events[i].ev.parameters.Length - 1){value += ",";}
					finalValue += value;
				}
			}
			
			string evActive = string.Empty;
			string delay = string.Empty;
			string randomDelay = string.Empty;
			
			if(events.events[i].disable){evActive = "X ";}
			if(events.events[i].delay > 0){delay = events.events[i].delay.ToString() + " ";}
			if(events.events[i].randomDelay.Length > 0){randomDelay = "[" + events.events[i].randomDelay[0].ToString() + "," + events.events[i].randomDelay[1].ToString() + "] ";}
			
			string space = ". ";
			if(i > 9){space = "";}
			events.events[i].label = "" + i + space + "  " + evActive + delay + randomDelay + events.events[i].ev.methodName + " (" + finalValue + ")" + "  [" + events.events[i].ev.target.ToString() + "]";
		}
	}
}
