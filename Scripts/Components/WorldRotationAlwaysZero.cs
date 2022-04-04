using UnityEngine;
using System.Collections;

public class WorldRotationAlwaysZero : MonoBehaviour {

	public Transform selfTransform;
	public bool xAxis;
	public bool yAxis;
	public bool zAxis;

	public void AssignVariables () 
	{
		if(selfTransform == null){selfTransform = transform;}
	}

	// Use this for initialization
	void Start () 
	{
		AssignVariables ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(xAxis){selfTransform.eulerAngles = new Vector3 (0,selfTransform.eulerAngles.y,selfTransform.eulerAngles.z);}
		if(yAxis){selfTransform.eulerAngles = new Vector3 (selfTransform.eulerAngles.x,0,selfTransform.eulerAngles.z);}
		if(zAxis){selfTransform.eulerAngles = new Vector3 (selfTransform.eulerAngles.x,selfTransform.eulerAngles.y,0);}

	}
}
