using UnityEngine;
using System.Collections;

public class AlignToMesh : MonoBehaviour {

	public float updateInterval;
	public bool smoothUpdating;
	public bool xAxis;
	public bool yAxis;
	public bool zAxis;
	public bool drawRay;
	public LayerMask layerMask;
	public Transform rayCastingPoint;
	public Transform objectToAlign;


	void Awake () 
	{
		if(rayCastingPoint == null){rayCastingPoint = transform;}
		if(objectToAlign == null)  {objectToAlign = transform;}
	}


	// Use this for initialization
	void OnEnable () 
	{
		StartCoroutine ("InitiateMeshAligning");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private RaycastHit raycastHitInfo;
	private float xAxisValue;
	private float yAxisValue;
	private float zAxisValue;
	private Quaternion fromRotation;
	private Quaternion toRotation;
	IEnumerator InitiateMeshAligning()
	{
		while (true) 
		{
			Ray ray = new Ray(rayCastingPoint.position + new Vector3(0,100,0),Vector3.down); 
			if(Physics.Raycast(ray,out raycastHitInfo,1000,layerMask))
			{
				fromRotation = objectToAlign.rotation;
				toRotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.up, raycastHitInfo.normal), Vector3.Cross(Vector3.up, raycastHitInfo.normal));
				//toRotation = objectToAlign.rotation;  

				if(smoothUpdating)
				{
					StopCoroutine("AnimateRotationCoroutine");
					StartCoroutine("AnimateRotationCoroutine");
				}
				else
				{
					objectToAlign.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.up, raycastHitInfo.normal), Vector3.Cross(Vector3.up, raycastHitInfo.normal));
					if(xAxis){xAxisValue = objectToAlign.localEulerAngles.x; }else{xAxisValue = 0;}
					if(yAxis){yAxisValue = objectToAlign.localEulerAngles.y; }else{yAxisValue = 0;}
					if(zAxis){zAxisValue = objectToAlign.localEulerAngles.z; }else{zAxisValue = 0;}
					objectToAlign.localEulerAngles = new Vector3(xAxisValue,yAxisValue,zAxisValue);
				}

#if UNITY_EDITOR
				if(drawRay){Debug.DrawLine(rayCastingPoint.position + new Vector3(0,100,0),raycastHitInfo.point,Color.blue,2);}
#endif
				yield return new WaitForSeconds(updateInterval);
			}
		}
	}

	IEnumerator AnimateRotationCoroutine() 
	{
		float percentage = 0;
		while (percentage < 1) 
		{
			percentage += 1/updateInterval * Time.deltaTime;
			if(percentage > 1){percentage = 1;}
			objectToAlign.rotation = Quaternion.Lerp(fromRotation,toRotation,percentage); 
			if(xAxis){xAxisValue = objectToAlign.localEulerAngles.x; }else{xAxisValue = 0;}
			if(yAxis){yAxisValue = objectToAlign.localEulerAngles.y; }else{yAxisValue = 0;}
			if(zAxis){zAxisValue = objectToAlign.localEulerAngles.z; }else{zAxisValue = 0;}
			objectToAlign.localEulerAngles = new Vector3(xAxisValue,yAxisValue,zAxisValue);
			yield return null;
		}
	}
}
