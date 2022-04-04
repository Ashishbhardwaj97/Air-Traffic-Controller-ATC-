using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour
{
    //// Define possible states for enemy using an enum 
    //public enum CameraView { birdeyeView, terminal1View, internationalTerminalView, runwayView, radioTowerView, windowView, freeCamera };

    //[SerializeField]
    //public CameraView activeCameraView;

    

    ////......BirdEyeView............
    //public float dragSpeed;
    //private Vector3 dragOrigin;
    ////................................

    //public float rotateSpeed = 2f;   

    //private void Start()
    //{
    //    dragSpeed = 0.1f;
    //    // birdeyeview = false;
    //    // terminal1view = false;
    //    //INRterminalview = false;
    //    //runwayView = false;
    //    //radiotowerview = false;
        
    //}

    //void Update()
    //{

       

    //    //if (npadState.GetButton(NpadButton.R))
    //    //{
            
    //    //}

    //    if (activeCameraView == CameraView.birdeyeView)
    //    {
    //        BirdEyeView();
    //    }
    //    else if (activeCameraView == CameraView.terminal1View)
    //    {
    //        INR_And_Terminal1_View_And_Runwayview();
    //    }
    //    else if (activeCameraView == CameraView.internationalTerminalView)
    //    {
    //        INR_And_Terminal1_View_And_Runwayview();
    //    }
    //    else if (activeCameraView == CameraView.runwayView)
    //    {
    //        INR_And_Terminal1_View_And_Runwayview();
    //    }
    //    else if (activeCameraView == CameraView.radioTowerView)
    //    {
    //        RadioTowerView();
    //    }
    //    else if (activeCameraView == CameraView.windowView)
    //    {
    //        WindowView();
    //    }
    //    else if (activeCameraView == CameraView.freeCamera)
    //    {
    //        FreeCamera();
    //    }

    //}

    //#region BirdEyeView

    //public void BirdEyeView()
    //{

    //    ZoomInZoomOutInXandYDirection();
    //    CameraDrag();

    //}

    //#endregion

    //#region INR And Terminal 1_view And RunwayView

    //public void INR_And_Terminal1_View_And_Runwayview()
    //{
    //    ZoomInOutWithFOV();
    //    AllDirectionHorizontalRotation();
    //}
    //#endregion

    //#region Radio Tower View

    //public void RadioTowerView()
    //{
    //    AllDirectionHorizontalRotation();
    //    // ZoomInZoomOutWithCameraPosition();
    //    ZoomInOutWithFOV();
    //}
    //#endregion

    //#region Window View
    //public void WindowView()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        float h = rotateSpeed * Input.GetAxis("Mouse X");
    //        Vector3 newRot = new Vector3(this.transform.localEulerAngles.x, Mathf.Clamp(this.transform.localEulerAngles.y + h, 0f, 20f), 0);
    //        transform.localEulerAngles = newRot;

    //    }
    //}
    //#endregion

    //public void FreeCamera()
    //{
    //    ZoomInOutWithFOV();
    //    AllDirectionHorizontalRotation();
    //    CameraDrag();
    //}

    //public void CameraDrag()
    //{
    //    //.........Camera Drag.........//
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        dragOrigin = Input.mousePosition;
    //        return;
    //    }

    //    if (!Input.GetMouseButton(0)) return;

    //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //    Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

    //    transform.Translate(move, Space.World);

    //}

    //public void ZoomInZoomOutInXandYDirection()
    //{

    //    //............for zoom In Out In X and Y direction..............//

    //    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //    {
    //        if (this.transform.localPosition.y <= 30 && this.transform.localPosition.y > 2)
    //        {
    //            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 1, transform.localPosition.z);
    //        }
    //        if (this.transform.localRotation.eulerAngles.x <= 90 && this.transform.localRotation.eulerAngles.x > 64)
    //        {
    //            this.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x - 1, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    //        }
    //    }
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //    {
    //        if (this.transform.localPosition.y >= 2 && this.transform.localPosition.y < 30)
    //        {
    //            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
    //        }

    //        if (this.transform.localRotation.eulerAngles.x >= 63 && this.transform.localRotation.eulerAngles.x < 90)
    //        {
    //            this.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x + 1, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    //        }
    //    }

    //}

    //public void AllDirectionHorizontalRotation()
    //{
    //    //............360 Horizontal Rotation...........//
    //    int mouseValue = 0;
    //    if (activeCameraView == CameraView.freeCamera)
    //    {
    //        mouseValue = 1;
    //    }

    //    if (Input.GetMouseButton(mouseValue))
    //    {
    //        float h = rotateSpeed * Input.GetAxis("Mouse X");
    //        float v = rotateSpeed * Input.GetAxis("Mouse Y");

    //        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + h, 0);
    //    }


    //    //if (Input.GetMouseButton(0))
    //    //{
    //    //    float h = rotateSpeed * Input.GetAxis("Mouse X");
    //    //    Vector3 newRot = new Vector3(this.transform.eulerAngles.x, Mathf.Clamp(this.transform.eulerAngles.y + h, 0f, 20f), 0);
    //    //    transform.eulerAngles = newRot;

    //    //}

    //}

    ////[Space(2)]
    ////[Header("Only For ZoomInZoomOutWithCameraPosition")]
    ////public float posMinValue;
    ////public float posMaxValue;
    ////public void ZoomInZoomOutWithCameraPosition()
    ////{
    ////    //............for zoom In Out with Camera Position..............//

    ////    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    ////    {
    ////        if (this.transform.localPosition.z <= 10 && this.transform.localPosition.z > posMinValue)
    ////        {
    ////            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.5f);
    ////        }

    ////    }
    ////    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    ////    {
    ////        if (this.transform.localPosition.z >= -3 && this.transform.localPosition.z < posMaxValue)
    ////        {
    ////            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.5f);
    ////        }
    ////    }

    ////}

    //[Space(2)]
    //[Header("Only For ZoomInZoomOutWithFOV")]
    //public float fovMinValue;
    //public float fovMaxValue;


    //public void ZoomInOutWithFOV()
    //{

    //    //............for zoom In Out With FOV..............//
    //    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //    {
    //        if (this.GetComponent<Camera>().fieldOfView > fovMinValue)
    //        {
    //            this.GetComponent<Camera>().fieldOfView--;
    //            if (activeCameraView == CameraView.radioTowerView)
    //            {
    //                if (this.GetComponent<Camera>().fieldOfView < 60)
    //                {
    //                    this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    //                }
                   
                    
    //            }
    //        }
    //    }
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //    {
    //        if (this.GetComponent<Camera>().fieldOfView < fovMaxValue)
    //        {
    //            this.GetComponent<Camera>().fieldOfView++;
    //            if (this.GetComponent<Camera>().fieldOfView >= 59)
    //            {
    //                this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    //            }
    //        }
    //    }

    //}
       



}
