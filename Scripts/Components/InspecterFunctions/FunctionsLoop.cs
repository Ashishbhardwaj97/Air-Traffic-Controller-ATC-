using UnityEngine;
using System.Collections;
using System;

public class FunctionsLoop : MonoBehaviour {

	public bool startOnEnable;
	public bool loop = true;
	public float[] initialDelay;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public EventsWithWait[] eventsArrayWithWait;

	[Serializable]
	public class EventsWithWait
	{
		public UIEvents events;
		public float[] waitTime;
	}


	void OnEnable()
	{
		if(startOnEnable){StartEventsLoop();}
	}

	public void StartEventsLoop()
	{
		StartCoroutine ("EventsLoopCoroutine");
	}

	public void StopEventsLoop()
	{
		StopCoroutine ("EventsLoopCoroutine");
	}

	IEnumerator EventsLoopCoroutine()
	{
		if(initialDelay.Length > 0){yield return new WaitForSeconds(UnityEngine.Random.Range(initialDelay[0],initialDelay[1]));}
		while (true) 
		{
			for (int i = 0; i < eventsArrayWithWait.Length; i++) 
			{
				eventsArrayWithWait[i].events.Invoke(gameObject);

				if(Time.timeScale == 1)
				{
					yield return new WaitForSeconds(UnityEngine.Random.Range(eventsArrayWithWait[i].waitTime[0],eventsArrayWithWait[i].waitTime[1]));
				}
				else
				{
					float recordedTime = Time.realtimeSinceStartup;
					while (Time.realtimeSinceStartup - recordedTime < UnityEngine.Random.Range(eventsArrayWithWait[i].waitTime[0],eventsArrayWithWait[i].waitTime[1])) {yield return null;}
				}


			}
			if(!loop){yield break;}
		}

	}





	void UpdateFunctionNames () 
	{
		for (int i = 0; i < eventsArrayWithWait.Length; i++) 
		{
			for (int j = 0; j < eventsArrayWithWait[i].events.events.Length; j++) 
			{
				string finalValue = "";
				if(eventsArrayWithWait[i].events.events[j].ev.parameters != null)
				{
					for (int k = 0; k < eventsArrayWithWait[i].events.events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = eventsArrayWithWait[i].events.events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != eventsArrayWithWait[i].events.events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(eventsArrayWithWait[i].events.events[j].disable){evActive = "X ";}
				if(eventsArrayWithWait[i].events.events[j].delay > 0){delay = eventsArrayWithWait[i].events.events[j].delay.ToString() + " ";}
				if(eventsArrayWithWait[i].events.events[j].randomDelay.Length > 0){randomDelay = "[" + eventsArrayWithWait[i].events.events[j].randomDelay[0].ToString() + "," + eventsArrayWithWait[i].events.events[j].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(j > 9){space = "";}
				eventsArrayWithWait[i].events.events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + eventsArrayWithWait[i].events.events[j].ev.methodName + " (" + finalValue + ")" + "  [" + eventsArrayWithWait[i].events.events[j].ev.target.GetType() + "]";
			}
			
		}
	}























}
