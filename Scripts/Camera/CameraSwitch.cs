//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CameraSwitch : MonoBehaviour
//{
//    public static CameraSwitch ins;
//    public List<GameObject> Cam_View;
//    public int CamCount;
//    //public GameObject GameUIclose;
//    public Text camName;

//    Vector3 currentPosition;
//    Quaternion currentRotation;


//    public float minFOV;                                            // by divyansh
//    public float maxFOV;                                            // by divyansh
//    public float minFOVBirdEye;                                     // by divyansh
//    public float maxFOVBirdEye;                                     // by divyansh
//    public float dragSpeed;                                         // by divyansh

//    public GameObject mainCamera;                                   // by divyansh
//    public GameObject mainCamera2;                                   // by divyansh
//    public GameObject activeCam;                                    // by divyansh



//    private void Awake()
//    {
//        ins = this;
//    }

//    void Start()
//    {
//        CamCount = 0;
//        camName.text = "LOOK AT AIRPLANE VIEW";
//    }
//    void Update()
//    {
//        if (activeCam != null)
//        {
//            CameraSwitch.ins.mainCamera.SetActive(false);
//        }
//        else
//        {
//            CameraSwitch.ins.mainCamera.SetActive(true);

//        }
//    }

//    public void Switch_Cam()
//    {

//        CamCount = CamCount + 1;
//        if (CamCount < (Cam_View.Count + 1))
//        {
//            activeCam = Cam_View[CamCount - 1];                              // By Divyansh

//            //print("CAMCOUNT " + CamCount);

//            //for (int i = 0; i < 5; i++)
//            //{
//            //    UIManager.instance._Canvas.transform.GetChild(i).gameObject.SetActive(true);
//            //}

//            if (CamCount == 6)
//            {
//                PassengerWindowViewCameraSwitchig();
//                //for (int i = 0; i < 5; i++)
//                //{
//                //    UIManager.instance._Canvas.transform.GetChild(i).gameObject.SetActive(false);
//                //}

//                //UIManager.instance._Canvas.transform.GetChild(6).gameObject.SetActive(true);
//                RadarManagerScript.instance.cameraRadar.SetActive(false);
//                RadarManagerScript.instance.canvasRadar.SetActive(false);
//                RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(false);
//            }



//            Cam_View[CamCount - 1].SetActive(true);
//            if (!camName.transform.parent.gameObject.activeInHierarchy)
//            {
//                camName.transform.parent.gameObject.SetActive(true);
//            }
//            camName.text = Cam_View[CamCount - 1].name;
//            if (CamCount >= 2)
//            {
//                Cam_View[CamCount - 2].SetActive(false);
//            }
//        }
//        else
//        {
//            Cam_View[CamCount - 2].SetActive(false);
//           // camName.transform.parent.gameObject.SetActive(false);
//            print("Camera");
//            CamCount = 0;
//            camName.text = "LOOK AT AIRPLANE VIEW";
//            RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(true);
//            RadarManagerScript.instance.radarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

//            //for (int i = 0; i < 8; i++)
//            //{
//            //    UIManager.instance._Canvas.transform.GetChild(i).gameObject.SetActive(true);
//            //}

//            //........Reset the rotaion of Other camera.............

//            Cam_View[0].transform.localRotation = Quaternion.Euler(90, -160, 0);
//            Cam_View[1].transform.localRotation = Quaternion.Euler(0, 180, 0);
//            Cam_View[2].transform.localRotation = Quaternion.Euler(0, -29, 0);
//            Cam_View[3].transform.localRotation = Quaternion.Euler(0, 0, 0);
//            Cam_View[4].transform.localRotation = Quaternion.Euler(22, 0, 0);

//            //..............................................
//        }
//        //............UI OFF ON...........

//        //if (CamCount > 0)
//        //{
//        //    GameUIclose.SetActive(false);
//        //}
//        //else
//        //{
//        //    GameUIclose.SetActive(true);
//        //}
//        //.......................


//    }

//    public void PassengerWindowViewCameraSwitchig()
//    {
//        Cam_View[CamCount - 1].transform.SetParent(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(0));
//        Cam_View[CamCount - 1].transform.localEulerAngles = new Vector3(0f, -90f, 0f);
//        Cam_View[CamCount - 1].transform.localPosition = new Vector3(0f, 0.1f, -0.04f);
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch ins;
    public List<GameObject> Cam_View;
    public int CamCount;
    //public GameObject GameUIclose;
    public Text camName;

    Vector3 currentPosition;
    Quaternion currentRotation;


    public float minFOV;                                            // by divyansh
    public float maxFOV;                                            // by divyansh
    public float minFOVBirdEye;                                     // by divyansh
    public float maxFOVBirdEye;                                     // by divyansh
    public float dragSpeed;                                         // by divyansh

    public GameObject mainCamera;                                   // by divyansh
    public GameObject mainCamera2;                                   // by divyansh
    public GameObject activeCam;                                    // by divyansh



    private void Awake()
    {
        ins = this;
    }

    void Start()
    {
        CamCount = 0;
        camName.text = "LOOK AT AIRPLANE VIEW";
    }
    void Update()
    {
        if (activeCam != null)
        {
            CameraSwitch.ins.mainCamera.SetActive(false);
        }
        else
        {
            CameraSwitch.ins.mainCamera.SetActive(true);

        }
    }

    public void Switch_Cam()
    {

        CamCount = CamCount + 1;
        if (CamCount < (Cam_View.Count + 1))
        {

            for (int i = 0; i < Cam_View.Count; i++)
            {
                Cam_View[i].SetActive(false);
                activeCam = null;
            }

            for (int i = 0; i <= Cam_View.Count; i++)
            {
                if (i == 0)
                {
                    if (SaveAndLoad.airportBirdCamera == 2 && CamCount == 1)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;
                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }
                        continue;

                    }
                }

                if (i == 1)
                {

                    if (SaveAndLoad.terminal1Camera == 2 && CamCount == 2)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;
                    }

                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }
                        continue;
                    }
                }

                if (i == 2)
                {
                    if (SaveAndLoad.IntTerminalCamera == 2 && CamCount == 3)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }

                        continue;
                    }
                }

                if (i == 3)
                {
                    if (SaveAndLoad.runwayCamera == 2 && CamCount == 4)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }
                        continue;
                    }
                }

                if (i == 4)
                {
                    if (SaveAndLoad.radioTowerCamera == 2 && CamCount == 5)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }
                        continue;
                    }
                }

                if (i == 5)
                {
                    if (SaveAndLoad.passengerWindowCamera == 2 && CamCount == 6)
                    {
                        if (CamCount == 6)
                        {
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            PassengerWindowViewCameraSwitchig();
                            RadarManagerScript.instance.cameraRadar.SetActive(false);
                            RadarManagerScript.instance.canvasRadar.SetActive(false);
                            RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(false);
                            break;

                        }
                    }

                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount++;
                        }
                        continue;
                    }
                }
            }

            if(activeCam == null)
            {
                print("Camera");
                CamCount = 0;
                camName.text = "LOOK AT AIRPLANE VIEW";
                RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(true);
                RadarManagerScript.instance.radarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                //........Reset the rotaion of Other camera.............

                Cam_View[0].transform.localRotation = Quaternion.Euler(90, -160, 0);
                Cam_View[1].transform.localRotation = Quaternion.Euler(0, 180, 0);
                Cam_View[2].transform.localRotation = Quaternion.Euler(0, -29, 0);
                Cam_View[3].transform.localRotation = Quaternion.Euler(0, 0, 0);
                Cam_View[4].transform.localRotation = Quaternion.Euler(22, 0, 0);
                print("CAMCOUNT " + CamCount);
            }
        }

        else
        {

            for (int i = 0; i < Cam_View.Count; i++)
            {
                Cam_View[i].SetActive(false);
                activeCam = null;
            }

            //Cam_View[CamCount - 2].SetActive(false);
            print("Camera");
            CamCount = 0;
            camName.text = "LOOK AT AIRPLANE VIEW";
            RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(true);
            RadarManagerScript.instance.radarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            //........Reset the rotaion of Other camera.............

            Cam_View[0].transform.localRotation = Quaternion.Euler(90, -160, 0);
            Cam_View[1].transform.localRotation = Quaternion.Euler(0, 180, 0);
            Cam_View[2].transform.localRotation = Quaternion.Euler(0, -29, 0);
            Cam_View[3].transform.localRotation = Quaternion.Euler(0, 0, 0);
            Cam_View[4].transform.localRotation = Quaternion.Euler(22, 0, 0);
            print("CAMCOUNT " + CamCount);
            //..............................................
        }

    }


    public void Switch_CamBack()
    {

        CamCount--;

        if (CamCount < 0)
        {
            CamCount = Cam_View.Count;

            for (int i = 0; i < Cam_View.Count; i++)
            {
                Cam_View[i].SetActive(false);
            }
            if (SaveAndLoad.passengerWindowCamera == 2)
            {
                PassengerWindowViewCameraSwitchig();
                activeCam = Cam_View[CamCount - 1];                              // By Divyansh
                Cam_View[CamCount - 1].SetActive(true);
                camName.text = Cam_View[CamCount - 1].name;
                RadarManagerScript.instance.cameraRadar.SetActive(false);
                RadarManagerScript.instance.canvasRadar.SetActive(false);
                RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(false);
            }
            else
            {
                //.......................................................................................................................//
                for (int i = Cam_View.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        if (SaveAndLoad.airportBirdCamera == 2 && CamCount == 1)
                        {
                            Cam_View[CamCount - 1].SetActive(true);
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            break;
                        }
                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }
                            continue;

                        }
                    }

                    if (i == 1)
                    {

                        if (SaveAndLoad.terminal1Camera == 2 && CamCount == 2)
                        {
                            Cam_View[CamCount - 1].SetActive(true);
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            break;
                        }

                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }
                            continue;
                        }
                    }

                    if (i == 2)
                    {
                        if (SaveAndLoad.IntTerminalCamera == 2 && CamCount == 3)
                        {
                            Cam_View[CamCount - 1].SetActive(true);
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            break;

                        }
                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }

                            continue;
                        }
                    }

                    if (i == 3)
                    {
                        if (SaveAndLoad.runwayCamera == 2 && CamCount == 4)
                        {
                            Cam_View[CamCount - 1].SetActive(true);
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            break;

                        }
                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }
                            continue;
                        }
                    }

                    if (i == 4)
                    {
                        if (SaveAndLoad.radioTowerCamera == 2 && CamCount == 5)
                        {
                            Cam_View[CamCount - 1].SetActive(true);
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            break;

                        }
                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }
                            continue;
                        }
                    }

                    if (i == 5)
                    {
                        if (SaveAndLoad.passengerWindowCamera == 2 && CamCount == 6)
                        {
                            if (CamCount == 6)
                            {
                                activeCam = Cam_View[CamCount - 1];
                                camName.text = Cam_View[CamCount - 1].name;
                                PassengerWindowViewCameraSwitchig();
                                RadarManagerScript.instance.cameraRadar.SetActive(false);
                                RadarManagerScript.instance.canvasRadar.SetActive(false);
                                RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(false);
                                break;

                            }
                        }

                        else
                        {
                            if (CamCount - 1 == i)
                            {
                                CamCount--;
                            }
                            continue;
                        }
                    }
                }
                //...........................................................................................................................//

            }


        }

        else if (CamCount > 0)
        {
            for (int i = 0; i < Cam_View.Count; i++)
            {
                Cam_View[i].SetActive(false);
            }
            //.......................................................................................................................//
            for (int i = Cam_View.Count - 2; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (SaveAndLoad.airportBirdCamera == 2 && CamCount == 1)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;
                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }
                        continue;

                    }
                }

                if (i == 1)
                {

                    if (SaveAndLoad.terminal1Camera == 2 && CamCount == 2)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;
                    }

                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }
                        continue;
                    }
                }

                if (i == 2)
                {
                    if (SaveAndLoad.IntTerminalCamera == 2 && CamCount == 3)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }

                        continue;
                    }
                }

                if (i == 3)
                {
                    if (SaveAndLoad.runwayCamera == 2 && CamCount == 4)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }
                        continue;
                    }
                }

                if (i == 4)
                {
                    if (SaveAndLoad.radioTowerCamera == 2 && CamCount == 5)
                    {
                        Cam_View[CamCount - 1].SetActive(true);
                        activeCam = Cam_View[CamCount - 1];
                        camName.text = Cam_View[CamCount - 1].name;
                        break;

                    }
                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }
                        continue;
                    }
                }

                if (i == 5)
                {
                    if (SaveAndLoad.passengerWindowCamera == 2 && CamCount == 6)
                    {
                        if (CamCount == 6)
                        {
                            activeCam = Cam_View[CamCount - 1];
                            camName.text = Cam_View[CamCount - 1].name;
                            PassengerWindowViewCameraSwitchig();
                            RadarManagerScript.instance.cameraRadar.SetActive(false);
                            RadarManagerScript.instance.canvasRadar.SetActive(false);
                            RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(false);
                            break;

                        }
                    }

                    else
                    {
                        if (CamCount - 1 == i)
                        {
                            CamCount--;
                        }
                        continue;
                    }
                }
            }
            //...........................................................................................................................//

        if(activeCam == null)
            {

                Cam_View[0].SetActive(false);
                print("Camera");
                mainCamera.SetActive(true);
                CamCount = 0;
                camName.text = "LOOK AT AIRPLANE VIEW";
                RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(true);
                RadarManagerScript.instance.radarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

                //........Reset the rotaion of Other camera.............

                Cam_View[0].transform.localRotation = Quaternion.Euler(90, -160, 0);
                Cam_View[1].transform.localRotation = Quaternion.Euler(0, 180, 0);
                Cam_View[2].transform.localRotation = Quaternion.Euler(0, -29, 0);
                Cam_View[3].transform.localRotation = Quaternion.Euler(0, 0, 0);
                Cam_View[4].transform.localRotation = Quaternion.Euler(22, 0, 0);
                print("CAMCOUNT " + CamCount);
            }
            
        }

        else if (CamCount == 0)
        {
            Cam_View[0].SetActive(false);
            print("Camera");
            mainCamera.SetActive(true);
            CamCount = 0;
            camName.text = "LOOK AT AIRPLANE VIEW";
            RadarManagerScript.instance.radarButton.transform.gameObject.SetActive(true);
            RadarManagerScript.instance.radarButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            //........Reset the rotaion of Other camera.............

            Cam_View[0].transform.localRotation = Quaternion.Euler(90, -160, 0);
            Cam_View[1].transform.localRotation = Quaternion.Euler(0, 180, 0);
            Cam_View[2].transform.localRotation = Quaternion.Euler(0, -29, 0);
            Cam_View[3].transform.localRotation = Quaternion.Euler(0, 0, 0);
            Cam_View[4].transform.localRotation = Quaternion.Euler(22, 0, 0);
            print("CAMCOUNT " + CamCount);
        }

    }

    public void PassengerWindowViewCameraSwitchig()
    {
        Cam_View[CamCount - 1].transform.SetParent(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(0));
        Cam_View[CamCount - 1].transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        Cam_View[CamCount - 1].transform.localPosition = new Vector3(0f, 0.1f, -0.04f);
    }
}
