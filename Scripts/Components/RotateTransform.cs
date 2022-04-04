using UnityEngine;
using System.Collections;

public class RotateTransform : MonoBehaviour {

	public Transform selfTransform;
	public float xAxisSpeed;
	public float yAxisSpeed;
	public float zAxisSpeed;

	void Start () 
	{
		if(selfTransform == null){selfTransform = transform;}
	}
	
	// Update is called once per frame
	void Update () 
	{
		selfTransform.Rotate (xAxisSpeed*Time.deltaTime,yAxisSpeed*Time.deltaTime,zAxisSpeed*Time.deltaTime);
	}
}
