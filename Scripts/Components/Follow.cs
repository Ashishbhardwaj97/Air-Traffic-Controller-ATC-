using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour 
{
	public Transform target; 
	public Transform follower; 

	public bool xFollow;
	public bool yFollow;
	public bool zFollow;

	public float[] xLimitsInlocal;
	public float[] yLimitsInlocal;
	public float[] zLimitsInlocal;


	public void SetLimitInX (Vector2 limit) 
	{
		xLimitsInlocal[0] = limit.x;
		xLimitsInlocal[1] = limit.y;
	}

	public void SetLimitInY (Vector2 limit) 
	{
		yLimitsInlocal[0] = limit.x;
		yLimitsInlocal[1] = limit.y;
	}

	public void SetLimitInZ (Vector2 limit) 
	{
		zLimitsInlocal[0] = limit.x;
		zLimitsInlocal[1] = limit.y;
	}

	public void SetTarget (Transform targetTransform) 
	{
		target = targetTransform;
	}

	void Update () 
	{
		if(xFollow)
		{
			follower.position = new Vector3 (Mathf.Lerp(follower.position.x,target.position.x,.25f),follower.position.y,follower.position.z);

			if(follower.localPosition.x < xLimitsInlocal[0])
			{follower.localPosition = new Vector3(xLimitsInlocal[0],follower.localPosition.y,follower.localPosition.z);}

			if(follower.localPosition.x > xLimitsInlocal[1])
			{follower.localPosition = new Vector3(xLimitsInlocal[1],follower.localPosition.y,follower.localPosition.z);}

		}

		if(yFollow)
		{
			follower.position = new Vector3 (follower.position.x,Mathf.Lerp(follower.position.y,target.position.y,.025f),follower.position.z);

			if(follower.localPosition.y < yLimitsInlocal[0])
			{follower.localPosition = new Vector3(follower.localPosition.x,yLimitsInlocal[0],follower.localPosition.z);}

			if(follower.localPosition.y > yLimitsInlocal[1])
			{follower.localPosition = new Vector3(follower.localPosition.x,yLimitsInlocal[1],follower.localPosition.z);}

		}

		if(zFollow)
		{
			follower.position = new Vector3 (follower.position.x,follower.position.y,Mathf.Lerp(follower.position.z,target.position.z,.25f));

			if(follower.localPosition.z < zLimitsInlocal[0])
			{follower.localPosition = new Vector3(follower.localPosition.x,follower.localPosition.y,zLimitsInlocal[0]);}

			if(follower.localPosition.z > zLimitsInlocal[1])
			{follower.localPosition = new Vector3(follower.localPosition.x,follower.localPosition.y,zLimitsInlocal[1]);}

		}
	}
}
























