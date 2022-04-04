using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DistanceCalculator : MonoBehaviour 
{
	public float updateInterval;
	public Transform targetTransform;
	public Transform selfTransform;

	[HideInInspector] public float distance;

	[Space]
	public bool calculatePathLength;
	public Transform pathStartPoint;
	public Transform pathEndPoint;

	void Awake () 
	{
		if(selfTransform){selfTransform = transform;}
	}

	void Update () 
	{
#if UNITY_EDITOR
		if(calculatePathLength){CalculatePathLength(); calculatePathLength = false;}
#endif
	}
	
	void OnEnable () 
	{
		StartCoroutine ("Initiate");
	}

	IEnumerator Initiate ()
	{
		while (true) 
		{
			distance = Vector3.Distance (selfTransform.position,targetTransform.position);
			yield return new WaitForSeconds (updateInterval);
		}
	}

	public void CalculatePathLength()
	{
		float pathLength = 0;
		Transform path = pathStartPoint.parent; 
		for (int i = pathStartPoint.GetSiblingIndex(); i < pathEndPoint.GetSiblingIndex(); i++) 
		{
			print (path.GetChild(i).name);
			pathLength += Vector3.Distance(path.GetChild(i).position,path.GetChild(i + 1).position);
		}
		print ("Path Length = " + pathLength + " Meters");
	}
}
