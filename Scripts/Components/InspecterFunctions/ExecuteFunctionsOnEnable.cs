using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class ExecuteFunctionsOnEnable : MonoBehaviour 
{
	public int delayInvokeByFrames;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;



	public UIEvents functionsToRun;

   // public bool onEnableActive;
	void OnEnable () 
	{
        //if (!onEnableActive)
       // {
            StartCoroutine("InvokeCoroutine");
           // onEnableActive = true;
      //  }
		
	}

	IEnumerator InvokeCoroutine () 
	{
		for (int i = 0; i < delayInvokeByFrames; i++) {
			yield return new WaitForEndOfFrame();
		}

		functionsToRun.Invoke (gameObject);
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
	}
}
