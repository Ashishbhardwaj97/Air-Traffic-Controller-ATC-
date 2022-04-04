using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimateTransformFunctions : MonoBehaviour 
{
	public static AnimateTransformFunctions ins; 
	void Awake() {ins = this;}

	public enum TransformTypes{Position,Rotation,Scale};
	public enum AnimAxis{Local,World};

	public AnimEasingCurve[] animEasingCurves;

	[Serializable]
	public class AnimEasingCurve
	{
		public string animEasingCurveName;
		public AnimationCurve animEasingCurve;
	}

	[Serializable]
	public class AnimatingTransformCoroutine
	{
		public Transform animatingTransform;
		public TransformTypes transformType;
		public Coroutine coroutine;
	}

	public void Translate(Transform transformToAnimate,Vector3 amount,float time,string easing)
	{
		AnimateTransform(transformToAnimate,transformToAnimate.localPosition,transformToAnimate.localPosition + amount,time,TransformTypes.Position,AnimAxis.Local,easing);
	}

	[HideInInspector]
	public List<AnimatingTransformCoroutine> animatingTransformCoroutines = new List<AnimatingTransformCoroutine>();


	public void AnimateTransform(Transform transformToAnimate,Vector3 start,Vector3 destination,float time,TransformTypes whichTransform,AnimAxis animAxis,string easing)
	{
		StopAnimation (transformToAnimate,whichTransform);
		AnimatingTransformCoroutine animatingTransformCoroutine = new AnimatingTransformCoroutine ();
		animatingTransformCoroutine.animatingTransform = transformToAnimate;
		animatingTransformCoroutine.transformType = whichTransform;
		animatingTransformCoroutine.coroutine = StartCoroutine (AnimateTransformCoroutine(transformToAnimate,start,destination,time,whichTransform,animAxis,easing));
		animatingTransformCoroutines.Add (animatingTransformCoroutine);
	}

	public void StopAnimation(Transform transformToAnimate,TransformTypes whichTransform)
	{
		for (int i = 0; i < animatingTransformCoroutines.Count; i++) 
		{
			if(animatingTransformCoroutines[i].animatingTransform == transformToAnimate)
			{
				if(animatingTransformCoroutines[i].transformType == whichTransform)
				{
					StopCoroutine(animatingTransformCoroutines[i].coroutine);
					animatingTransformCoroutines.Remove(animatingTransformCoroutines[i]);
					break;
				}
			}
		}
	}


	IEnumerator AnimateTransformCoroutine(Transform transformToAnimate,Vector3 start,Vector3 destination,float time,TransformTypes whichTransform,AnimAxis animAxis,string easing)
	{
		if(animAxis == AnimAxis.World)
		{
			if(whichTransform == TransformTypes.Position)
			{
				start = InstantiateTransform(transformToAnimate,start,whichTransform).localPosition;
				destination = InstantiateTransform(transformToAnimate,destination,whichTransform).localPosition;
			}

			if(whichTransform == TransformTypes.Rotation)
			{
				start = InstantiateTransform(transformToAnimate,start,whichTransform).localEulerAngles;
				destination = InstantiateTransform(transformToAnimate,destination,whichTransform).localEulerAngles;
			}

			if(whichTransform == TransformTypes.Scale)
			{
				start = InstantiateTransform(transformToAnimate,start,whichTransform).localScale;
				destination = InstantiateTransform(transformToAnimate,destination,whichTransform).localScale;
			}
		}

		AnimationCurve activeAnimCurve = null;
		for (int i = 0; i < animEasingCurves.Length; i++) 
		{
			if(easing == animEasingCurves[i].animEasingCurveName)
			{
				activeAnimCurve = animEasingCurves[i].animEasingCurve;
				break;
			}
		}

		float animValue;
		float evaluateValue = 0;
		Quaternion startRotation = Quaternion.Euler(start);
		Quaternion destinationRotation = Quaternion.Euler(destination);
		while(evaluateValue < 1)
		{
			evaluateValue += 1/time * Time.deltaTime;
			if(evaluateValue > 1){evaluateValue = 1;}
			animValue = activeAnimCurve.Evaluate(evaluateValue);

			if(whichTransform == TransformTypes.Position) {transformToAnimate.localPosition = Vector3.Lerp(start,destination,animValue);}
			if(whichTransform == TransformTypes.Rotation) {transformToAnimate.localRotation = Quaternion.Lerp(startRotation,destinationRotation,animValue);}
			if(whichTransform == TransformTypes.Scale)    {transformToAnimate.localScale = Vector3.Lerp(start,destination,animValue);}
			
			yield return null;
		}

		StopAnimation (transformToAnimate,whichTransform);
	}


	Transform InstantiateTransform(Transform transformToAnimate,Vector3 instantiatePosRotOrScale,TransformTypes whichTransform)
	{
		GameObject newGameObject = new GameObject();
		Destroy (newGameObject);
		Transform newTransform = newGameObject.transform;
		if(whichTransform == TransformTypes.Position){newTransform.position = instantiatePosRotOrScale;}
		if(whichTransform == TransformTypes.Rotation){newTransform.eulerAngles = instantiatePosRotOrScale;}
		if(whichTransform == TransformTypes.Scale){newTransform.localScale = instantiatePosRotOrScale;}
		newTransform.parent = transformToAnimate.parent;

		return newTransform;
	}

}
