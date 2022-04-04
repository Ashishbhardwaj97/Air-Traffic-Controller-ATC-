using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Private References      
    [SerializeField, Range(0.0f, 1.0f)]
    private float _lerpRate;
    private float _xRotation;
    private float _yYRotation;
    #endregion

    float val;
    public float minRotation = -70f;
    public float maxRotation = 60f;

    public static CameraMovement instanceCam;

    public GameObject cameraOrbit;                      // by divyansh
    public float xAngleCameraOrbit;                     // by divyansh
    public float yAngleCameraOrbit;                     // by divyansh
    public int rotateSpeed;                             // by divyansh

    public GameObject cameraOrbit2;                      // by divyansh
    public float xAngleCameraOrbit2;                     // by divyansh
    public float yAngleCameraOrbit2;                     // by divyansh

    #region Private Methods
    private void Rotate(float xMovement, float yMovement)
    {
        _xRotation += xMovement;
        _yYRotation += yMovement;
    }
    #endregion

    void Awake()
    {
        instanceCam = this;
    }

    #region Unity CallBacks
    void Start()
    {
        InputManager.MouseMoved += Rotate;
    }

    void Update()
    {
        xAngleCameraOrbit = transform.eulerAngles.x;                                     // By Divyansh
        yAngleCameraOrbit = transform.eulerAngles.y;                                     // By Divyansh

        xAngleCameraOrbit2 = transform.eulerAngles.x;                                     // By Divyansh
        yAngleCameraOrbit2 = transform.eulerAngles.y;                                     // By Divyansh

        _xRotation = Mathf.Lerp(_xRotation, 0, _lerpRate);
        _yYRotation = Mathf.Lerp(_yYRotation, 0, _lerpRate);

        transform.eulerAngles += new Vector3(-_yYRotation, _xRotation, 0);

        if (_yYRotation < 0 && transform.eulerAngles.x > maxRotation && transform.eulerAngles.x < 270)
        {
            transform.eulerAngles = new Vector3(maxRotation - 0.001f, transform.eulerAngles.y, 0);
        }
        else if (_yYRotation > 0 && (transform.eulerAngles.x - 360) <= minRotation && (transform.eulerAngles.x - 360) > -300)
        {

            transform.eulerAngles = new Vector3(minRotation + 0.001f, transform.eulerAngles.y, 0);
        }

        //.......................// float distance = Vector3.Distance(GameManagerScript.instanceGMS.cameraOrbit.transform.localPosition, Vector3.zero);

        if (GameManagerScript.instanceGMS.cameraOrbit.transform.localPosition.y > 0)
        {
            RadarManagerScript.instance.redPlaneSpotInBirdEyeView.SetActive(true);
            //print("greater....");
        }
        if (GameManagerScript.instanceGMS.cameraOrbit.transform.localPosition.y < 0)
        {
            GameManagerScript.instanceGMS.bg_Building.SetActive(false);
            RadarManagerScript.instance.redPlaneSpotInBirdEyeView.SetActive(false);
           // print("less...."); //..off..//
        }
    }

    void OnDestroy()
    {
        InputManager.MouseMoved -= Rotate;
    }
    #endregion
}
