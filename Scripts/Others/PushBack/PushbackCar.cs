using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackCar : MonoBehaviour
{

	GameObject atl_root;
	GameObject atl01;
	GameObject atl_rotate;
	GameObject atl_tyre_t;
	
	Vector3 oldPosCar;
	Vector3 oldPosBar;
	

    // Start is called before the first frame update
    void Start()
    {
        atl_root = this.transform.Find("atl_root").gameObject;
        atl01 = atl_root.transform.Find("atl01").gameObject;
        atl_rotate = atl01.transform.Find("atl_rotate").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    
    	//------------- Tow-Bar
    
    	Vector3 newPosBar = atl_root.transform.position;
    	Vector3 relativePosBar = newPosBar - oldPosBar;
    	
    	if (oldPosBar != newPosBar)
        {           
    		Quaternion lookatBar = Quaternion.LookRotation(relativePosBar);
        	atl_root.transform.rotation = Quaternion.Slerp(atl_root.transform.rotation, lookatBar, 0.02f); 
        }
        oldPosBar = newPosBar;
        
        //------------- Towing-Car
    
    	Vector3 newPosCar = atl01.transform.position;
    	Vector3 relativePosCar = newPosCar - oldPosCar;
		
		if (oldPosCar != newPosCar)
        {          
            Quaternion lookatCar = Quaternion.LookRotation(relativePosCar);
        	atl01.transform.rotation = Quaternion.Slerp(atl01.transform.rotation, lookatCar, 0.05f); 
        }
        oldPosCar = newPosCar;    
        

    }
}
