using UnityEngine;
using System.Collections;

public class RigidbodyFunctions : MonoBehaviour {

	public static RigidbodyFunctions instance; 
	void Awake() {instance = this;}


	public void SetVelocity (Rigidbody subject,Vector3 velocity) {subject.velocity = velocity;}

	public void SetAngularVelocity (Rigidbody subject,Vector3 angularVelocity) {subject.angularVelocity = angularVelocity;}

	public void MatchVelocity (Rigidbody subject,Rigidbody target) {subject.velocity = target.velocity;}

	public void MatchAngularVelocity (Rigidbody subject,Rigidbody target) 
	{
		subject.angularVelocity = target.angularVelocity;
	}


}
