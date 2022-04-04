using UnityEngine;
using System.Collections;
using System;

public class CollisionDetector : MonoBehaviour 
{
	public string type;
	public float collisionDetectInterval;


	public void OnTriggerEnter(Collider other)
	{
		//print ("OnTriggerEnter");
		CollidersAndTriggers CollidersAndTriggersScript = other.GetComponent<CollidersAndTriggers>();
		if (CollidersAndTriggersScript != null) {Run(CollidersAndTriggersScript);}
	}

	public Collision collisionInfo;
	void OnCollisionEnter(Collision other)
	{
		//print ("OnCollisionEnter");
		collisionInfo = other;
		CollidersAndTriggers CollidersAndTriggersScript = other.collider.GetComponent<CollidersAndTriggers>();
		if (CollidersAndTriggersScript != null) {Run(CollidersAndTriggersScript);}
	}

	float collisionDetectRecordedTime;
	public void Run(CollidersAndTriggers CollidersAndTriggersScript)
	{
		if(Time.realtimeSinceStartup - collisionDetectRecordedTime > collisionDetectInterval)
		{
			for (int i = 0; i < CollidersAndTriggersScript.UIEventsBasedOnCollisionDetectorType.Length; i++) 
			{
				if(type == CollidersAndTriggersScript.UIEventsBasedOnCollisionDetectorType[i].runFor)
				{
					CollidersAndTriggersScript.CollisionDetector = this;
					collisionDetectRecordedTime = Time.realtimeSinceStartup;
					CollidersAndTriggersScript.UIEventsBasedOnCollisionDetectorType[i].functionsToRun.Invoke(CollidersAndTriggersScript.gameObject);
					break;
				}
			}
		}
	}

}
