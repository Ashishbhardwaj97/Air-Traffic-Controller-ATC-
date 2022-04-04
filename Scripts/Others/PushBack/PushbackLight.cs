using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackLight : MonoBehaviour
{
    public GameObject MainPB;

    void Update()
    {
        this.transform.position = new Vector3(MainPB.transform.position.x, MainPB.transform.position.y + 0.021f, MainPB.transform.position.z);
        this.transform.Rotate(0f, -1f, 0f);       
    }
}
