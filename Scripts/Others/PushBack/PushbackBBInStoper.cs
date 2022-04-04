using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackBBInStoper : MonoBehaviour
{

    //public Transform obj;

    public void OnTriggerEnter(Collider Col)
    { 
        if (Col.gameObject.tag == "BBInStoper")
        {
            transform.parent.GetChild(0).GetComponent<PbbScript>().BBridgeIn = false;
        }
    }

}
