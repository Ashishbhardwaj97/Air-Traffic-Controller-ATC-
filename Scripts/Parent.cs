using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parent : MonoBehaviour
{

    public GameObject Object;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Object.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Object.transform.position + offset;
    }
}