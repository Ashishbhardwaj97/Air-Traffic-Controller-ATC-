using UnityEngine;
using System.Collections;

public class GuiDragableObject : MonoBehaviour 
{

	public enum DirectionEnum{Horizontal, Vertical, Both};
	public DirectionEnum direction = DirectionEnum.Both;

	public Transform transformToScroll;
	public Camera raycastCamera;
	public LayerMask layerMask;

	private bool horizontal;
	private bool vertical;

	public float xLowerLimit;
	public float xUpperLimit;
	public float yLowerLimit;
	public float yUpperLimit;



	private float xResolutionFactor;
	private float yResolutionFactor;

	public UIEvents OnFingerDown;
	public UIEvents OnFingerMoved;
	public UIEvents OnFingerUp;


	void Start () 
	{
		if(Screen.width > Screen.height)
		{
			xResolutionFactor = 40.0f*(Screen.width/1280.0f);
			yResolutionFactor = 40.0f*(Screen.height/720.0f);
			//print ("fjkfkjvb");
		}
		else
		{
			xResolutionFactor = 40*(Screen.width/480.0f);
			yResolutionFactor = 40*(Screen.height/800.0f);
		}
		if(direction == DirectionEnum.Horizontal || direction == DirectionEnum.Both) {horizontal = true;}
		if(direction == DirectionEnum.Vertical || direction == DirectionEnum.Both) {vertical = true;}
	}
	

	private Touch touch;
	void Update () 
	{
		if(Input.touchCount > 0)
		{
			touch = Input.touches[0];
			if (touch.phase == TouchPhase.Began){CastRay(touch.position);}
			
			if (fingerTouchedCollider)
			{
				if (touch.phase == TouchPhase.Ended)
				{
					FingerLifted();
				}

				if (touch.phase == TouchPhase.Moved)
				{
					FingerMoved(touch.position);
				}
			}
			
		}
		
		if(Input.mousePresent)
		{
			if(Input.GetMouseButtonDown(0)) {CastRay(Input.mousePosition);}
			if(fingerTouchedCollider) 
			{
				FingerMoved(Input.mousePosition);
				if(Input.GetMouseButtonUp(0)) 
				{
					FingerLifted();
				}
			}
		}
		
	}

	private Ray ray;
	private RaycastHit hit;
	public void CastRay(Vector3 fingerPosition) 
	{
		GuiDragableObject guiScrollableArea = null;
		fingerTouchedCollider = false;
		ray = raycastCamera.ScreenPointToRay(fingerPosition);
		if(Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask))
		{
			guiScrollableArea = hit.collider.GetComponent<GuiDragableObject>();
			if(guiScrollableArea == null){guiScrollableArea = hit.collider.transform.parent.GetComponent<GuiDragableObject>();}
			if(guiScrollableArea != null)
			{
				guiScrollableArea.FingerTouchedCollider(fingerPosition);
			}
			Debug.DrawLine(ray.origin, hit.point,Color.red,5);
		}
	}

	private bool fingerTouchedCollider;
	private Vector3 fingerRecordedPosition;
	private Vector3 transformToScrollRecordedPosition;
	public void FingerTouchedCollider(Vector3 fingerPosition) 
	{
		fingerTouchedCollider = true;
		fingerRecordedPosition = fingerPosition;
		transformToScrollRecordedPosition = transformToScroll.localPosition;
		OnFingerDown.Invoke (gameObject);
	}

	private void FingerMoved(Vector3 fingerPosition) 
	{
		if(horizontal)
		{
			float tempX = transformToScrollRecordedPosition.x + ((fingerPosition.x - fingerRecordedPosition.x)/xResolutionFactor);
			transformToScroll.localPosition = new Vector3(tempX,transformToScroll.localPosition.y,transformToScroll.localPosition.z);
			if(transformToScroll.localPosition.x < xLowerLimit){transformToScroll.localPosition = new Vector3(xLowerLimit,transformToScroll.localPosition.y,transformToScroll.localPosition.z);}
			if(transformToScroll.localPosition.x > xUpperLimit){transformToScroll.localPosition = new Vector3(xUpperLimit,transformToScroll.localPosition.y,transformToScroll.localPosition.z);}
		}

		if(vertical)
		{
			float tempY = transformToScrollRecordedPosition.y + ((fingerPosition.y - fingerRecordedPosition.y)/yResolutionFactor);
			transformToScroll.localPosition = new Vector3(transformToScroll.localPosition.x,tempY,transformToScroll.localPosition.z);
			if(transformToScroll.localPosition.y < yLowerLimit){transformToScroll.localPosition = new Vector3(transformToScroll.localPosition.x,yLowerLimit,transformToScroll.localPosition.z);}
			if(transformToScroll.localPosition.y > yUpperLimit){transformToScroll.localPosition = new Vector3(transformToScroll.localPosition.x,yUpperLimit,transformToScroll.localPosition.z);}
		}
		OnFingerMoved.Invoke (gameObject);
	}

	private void FingerLifted() 
	{
		fingerTouchedCollider = false;
		OnFingerUp.Invoke (gameObject);
	}

	public void SetYUpperLimitBasedOnMeshRendererYSize(MeshRenderer meshRenderer,float offset) 
	{
		StartCoroutine (SetYUpperLimitBasedOnMeshRendererYSizeCoroutine(meshRenderer,offset));
	}

	IEnumerator SetYUpperLimitBasedOnMeshRendererYSizeCoroutine(MeshRenderer meshRenderer,float offset) 
	{
		yield return new WaitForEndOfFrame ();
		yUpperLimit = meshRenderer.bounds.size.y;
		yUpperLimit += offset;
		if(yUpperLimit < yLowerLimit){yUpperLimit = yLowerLimit;}

		BoxCollider collider = transformToScroll.GetComponent<BoxCollider> ();
		collider.size = new Vector3 (collider.size.x,meshRenderer.bounds.size.y,0);
		collider.center = new Vector3 (collider.center.x,-meshRenderer.bounds.size.y/2.0f,0);
	}
}
