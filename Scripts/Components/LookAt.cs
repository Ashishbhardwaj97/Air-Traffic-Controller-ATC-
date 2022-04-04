using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
	public Transform lookTowards;
	public Transform lookingObject;
	public bool lockXZ;

	void Update () 
	{
        if (CameraSwitch.ins.activeCam != null && CameraSwitch.ins.Cam_View[5] != CameraSwitch.ins.activeCam)
        {
            lookTowards = CameraSwitch.ins.activeCam.transform;
           // lookingObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f); 
        }
        else
        {
            lookTowards = CameraSwitch.ins.mainCamera.transform;
           // lookingObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f); 
        }

        lookingObject.LookAt(lookTowards);
		if(!lockXZ){lookingObject.localEulerAngles = new Vector3(0,lookingObject.localEulerAngles.y,0);}

    }



}
