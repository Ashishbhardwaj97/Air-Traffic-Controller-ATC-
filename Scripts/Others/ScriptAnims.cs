using UnityEngine;
using System.Collections;
using System;

public class ScriptAnims : MonoBehaviour 
{
	
	public static ScriptAnims instance;
	public AnimationCurve activeAnimCurve;
	public AnimationCurve linear;
	public AnimationCurve easeOut;
	public AnimationCurve easeIn;
	public AnimationCurve easeOutEaseIn;
	public AnimationCurve slipperyStart;
	public AnimationCurve slipperyEnd;
	
	
	public Transform selfTransform;
	public GameObject selfGameObject;
	
	private float animValue;
	private float evaluateValue;
	
	public void AssignVariables () 
	{
		selfTransform = transform;
		selfGameObject = gameObject;
	}
	
	
	void Awake () 
	{

			instance = this;

		if(selfTransform == null){AssignVariables ();}
	}
	
	public void AnimateTransform(Transform transformToAnimate,Vector3 from,Vector3 destination,float time,string whichTransform,bool snapAllAxis,string easing = "Linear",float waitBeforeAnimating = 0,Action functionToRunOnAnimationComplete = null,string fromMode = null,string destinationMode = null) 
	{
		StartCoroutine (AnimateTransformCoroutine(transformToAnimate,from,destination,time,whichTransform,snapAllAxis,easing,waitBeforeAnimating,functionToRunOnAnimationComplete,fromMode,destinationMode));
	}
	
	private void SelectActiveAnimCurve(string easing) 
	{
		if(easing == "Linear")         {activeAnimCurve = linear;        return;} 
		if(easing == "EaseOut")        {activeAnimCurve = easeOut;       return;}
		if(easing == "EaseIn")         {activeAnimCurve = easeIn;        return;}
		if(easing == "EaseOutEaseIn")  {activeAnimCurve = easeOutEaseIn; return;}
		if(easing == "SlipperyStart")  {activeAnimCurve = slipperyStart; return;}
		if(easing == "SlipperyEnd")    {activeAnimCurve = slipperyEnd;   return;}
	}
	
	private bool position = false;
	private bool rotation = false;
	private bool scale = false;
	private float value_x = 0;
	private float value_y = 0;
	private float value_z = 0;
	private float amount_x;
	private float amount_y;
	private float amount_z;
	private Vector3 tempVector_3;
	private IEnumerator AnimateTransformCoroutine(Transform transformToAnimate,Vector3 from,Vector3 destination,float time,string whichTransform,bool snapAllAxis,string easing,float waitBeforeAnimating,Action functionToRunOnAnimationComplete,string fromMode,string destinationMode ) 
	{
		yield return new WaitForSeconds(waitBeforeAnimating);
		SelectActiveAnimCurve(easing);
		if(whichTransform == "Position")
		{
			if(fromMode == "W")
			{
				selfTransform.parent = transformToAnimate.parent;
				selfTransform.position = from;
				from = selfTransform.localPosition;
			}
			
			if(destinationMode == "W")
			{
				selfTransform.parent = transformToAnimate.parent;
				selfTransform.position = destination;
				destination = selfTransform.localPosition;
			}
		}

		amount_x = destination.x - from.x;
		amount_y = destination.y - from.y;
		amount_z = destination.z - from.z;
		
		if(whichTransform == "Position") {position = true; rotation = false; scale = false; tempVector_3 = transformToAnimate.localPosition;}
		if(whichTransform == "Rotation") {position = false; rotation = true; scale = false; tempVector_3 = transformToAnimate.localEulerAngles;}
		if(whichTransform == "Scale")    {position = false; rotation = false; scale = true; tempVector_3 = transformToAnimate.localScale;}
		
		if(snapAllAxis)
		{
			value_x = from.x;
			value_y = from.y;			
			value_z = from.z;
		}
		else
		{
			if(amount_x == 0){value_x = transformToAnimate.localPosition.x;}else{value_x = from.x;}
			if(amount_y == 0){value_y = transformToAnimate.localPosition.y;}else{value_y = from.y;}
			if(amount_z == 0){value_z = transformToAnimate.localPosition.z;}else{value_z = from.z;}
		}
		
		if(position) {transformToAnimate.localPosition =    new Vector3(value_x,value_y,value_z);}
		if(rotation) {transformToAnimate.localEulerAngles = new Vector3(value_x,value_y,value_z);}
		if(scale) 	 {transformToAnimate.localScale =       new Vector3(value_x,value_y,value_z);}

		if(time > 0)
		{
			evaluateValue = 0;
			while(evaluateValue < 1)
			{
				if(evaluateValue > 1){evaluateValue = 1;}
				evaluateValue += 1/time * Time.deltaTime;
				animValue = activeAnimCurve.Evaluate(evaluateValue);
				
				if(position) {tempVector_3 = transformToAnimate.localPosition;}
				if(rotation) {tempVector_3 = transformToAnimate.localEulerAngles;}
				if(scale)    {tempVector_3 = transformToAnimate.localScale;}
				
				if(amount_x == 0){value_x = tempVector_3.x;}
				if(amount_y == 0){value_y = tempVector_3.y;}
				if(amount_z == 0){value_z = tempVector_3.z;}
				
				if(position) {transformToAnimate.localPosition =    new Vector3(value_x + amount_x*animValue,value_y + amount_y*animValue,value_z + amount_z*animValue);}
				if(rotation) {transformToAnimate.localEulerAngles = new Vector3(value_x + amount_x*animValue,value_y + amount_y*animValue,value_z + amount_z*animValue);}
				if(scale)    {transformToAnimate.localScale =       new Vector3(value_x + amount_x*animValue,value_y + amount_y*animValue,value_z + amount_z*animValue);}
				yield return null;
			}
		}
		else
		{
			if(snapAllAxis)
			{
				value_x = destination.x;
				value_y = destination.y;
				value_z = destination.z;
			}
			else
			{
				if(amount_x == 0){value_x = transformToAnimate.localPosition.x;}else{value_x = destination.x;}
				if(amount_y == 0){value_y = transformToAnimate.localPosition.y;}else{value_y = destination.y;}
				if(amount_z == 0){value_z = transformToAnimate.localPosition.z;}else{value_z = destination.z;}
			}
			
			if(position) {transformToAnimate.localPosition =    new Vector3(value_x,value_y,value_z);}
			if(rotation) {transformToAnimate.localEulerAngles = new Vector3(value_x,value_y,value_z);}
			if(scale) 	 {transformToAnimate.localScale =       new Vector3(value_x,value_y,value_z);}
		}
		
		if (functionToRunOnAnimationComplete != null) {functionToRunOnAnimationComplete();}
		GF.instance.despawn(selfTransform);
	}
	
	
}
