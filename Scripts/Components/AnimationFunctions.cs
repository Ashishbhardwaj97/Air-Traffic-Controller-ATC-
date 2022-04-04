using UnityEngine;
using System.Collections;

public class AnimationFunctions : MonoBehaviour 
{
	public static AnimationFunctions instance; 
	void Awake() {instance = this;}


	public void PlayAnimation(Animation animationComp,string animationName,float speed = 1)
	{
		animationComp.Play (animationName);
		animationComp[animationName].speed = speed;
	}
	
	public void StopAnimation(Animation animationComp)
	{
		animationComp.Stop ();
	}
}
