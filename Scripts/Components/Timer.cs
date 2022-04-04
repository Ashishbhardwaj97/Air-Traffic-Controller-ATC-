using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour 
{
	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;


	public bool startOnEnable;
	public float startDelay;
	public tk2dTextMesh timerTxt;
	public float defaultValue;
	public string defaultTxt;
	public int speed;
	public string prefix;
	public string suffix;

	public FunctionToRunAccordingToTimerValue[] functionsToRunAccordingToTimerValue;



	[Serializable]
	public class FunctionToRunAccordingToTimerValue
	{
		public int timerValue;
		public UIEvents functionsToRun;
	}




	void OnEnable () 
	{
		if(startOnEnable){StartCoroutine("StartTimerCoroutine",false);}
	}

	public void SetTimerTxt(string txt)
	{
		timerTxt.text = txt;
	}

	public void SetTimerValue(int amount)
	{
		timerValue = amount;
	}


	public void ChangeTimerValue(int amount)
	{
		timerValue += amount;
		timerTxt.text = prefix + timerValue.ToString() + suffix;
		if(timerValue < 10){timerTxt.text = prefix + "0" + timerValue.ToString() + suffix;}
	}


	public void PauseTimer ()
	{
		StopCoroutine("StartTimerCoroutine");
	}

	public void ResumeTimer ()
	{
		StartCoroutine("StartTimerCoroutine",true);
	}

	public void RestartTimer () 
	{
		StopCoroutine("StartTimerCoroutine");
		StartCoroutine("StartTimerCoroutine",false);
	}
	
	float timerValue = 0;
	IEnumerator StartTimerCoroutine (bool paused = false) 
	{
		if(!paused)
		{
			timerTxt.text = defaultTxt;
			timerValue = defaultValue;
			yield return new WaitForSeconds (startDelay);
		}

		while (timerValue > 0) 
		{
			timerValue -= speed;
			timerTxt.text = prefix + timerValue.ToString() + suffix;
			if(timerValue < 10){timerTxt.text = prefix + "0" + timerValue.ToString() + suffix;}

			for (int i = 0; i < functionsToRunAccordingToTimerValue.Length; i++) 
			{
				if(functionsToRunAccordingToTimerValue[i].timerValue == timerValue)
				{
					functionsToRunAccordingToTimerValue[i].functionsToRun.Invoke(gameObject);
					break;
				}
			}

			yield return new WaitForSeconds(speed);
		}
	}

	void UpdateFunctionNames () 
	{
		for (int i = 0; i < functionsToRunAccordingToTimerValue.Length; i++) 
		{
			for (int j = 0; j < functionsToRunAccordingToTimerValue[i].functionsToRun.events.Length; j++) 
			{
				string finalValue = "";
				if(functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.parameters != null)
				{
					for (int k = 0; k < functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].disable){evActive = "X ";}
				if(functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].delay > 0){delay = functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].delay.ToString() + " ";}
				if(functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].randomDelay.Length > 0){randomDelay = "[" + functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].randomDelay[0].ToString() + "," + functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(j > 9){space = "";}
				functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.methodName + " (" + finalValue + ")" + "  [" + functionsToRunAccordingToTimerValue[i].functionsToRun.events[j].ev.target.GetType() + "]";
			}
			
		}
	}

}
