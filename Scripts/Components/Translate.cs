using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float zSpeed;

	public Transform selfTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		selfTransform.Translate (xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,zSpeed*Time.deltaTime);
	}
}
