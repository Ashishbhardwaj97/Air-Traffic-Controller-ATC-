using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pathpoints : MonoBehaviour
{
    public enum pathpoint { normal, runway, parkingSpot, openSpot };
    [SerializeField]
    public pathpoint pathpointType;
    public bool tuningAnimationOff;
    public enum turningAnimationType { Roll, Yaw, Pitch };
    [SerializeField]
    public turningAnimationType turningAnimation;


    public float turningRotationAngle;
    public float turningRotationAnimTime;
    public bool junction;

    public bool pathpointJunction;
    public string pathpointName;
    public Transform pathpointTransform;
    public bool isNotificationActive;
    public string notificationText;
    public Transform airoplane;
    public Animator airoplaneAnimator;

    [Space]
    public bool headWindCondition;
    //...By Divyansh....//

    [Space]                                                              
    public string tipsText;                                              
    public string infoText;                                               
    public float tipsDelayTime;                                           
    public float infoDelayTime;                                           
    public bool easy;                                                     
    public bool medium;                                                   
    public bool hard;
    [Space]
    [Space]
    public bool isLeftRotation;
    public bool isRightRotation;
    [Space]
    public float turningRotForHeadWind;
    //............//
     [Space]
    public float animSpeed = 0.2f;
    void Awake()
    {
        pathpointTransform = this.transform;
    }
    void Start()
    {
        animSpeed = 0.2f;
        turningRotForHeadWind = 12f;
    }
    void Update()
    {

    }
    //...........Arrival PathPoint..............//

    public void OnTriggerEnter(Collider Col)
    {
        //......by Divyansh....//
        //.......Tyre Rotation....//
        if (Col.gameObject.tag == "Player" && isLeftRotation == true && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<AircraftScripts>().StopLeftRotationCoroutine(animSpeed);
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeft(animSpeed);
        }

        if (Col.gameObject.tag == "Player" && isRightRotation == true && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<AircraftScripts>().StopRightRotationCoroutine(animSpeed);
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRight(animSpeed);
        }
        //...................//

        //......Tipes and Info...........//

        if (Col.gameObject.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(GameManagerScript.instanceGMS.firstFlightNum) && GameManagerScript.instanceGMS.tipsCounter == 0)
            {
                if (Col.gameObject.GetComponent<AircraftScripts>().flightNumber == GameManagerScript.instanceGMS.firstFlightNum)
                {
                    if (gameObject.name == "34R_GoAroundPoints_0")
                    {
                        GameManagerScript.instanceGMS.tipsCounter = 1;
                    }

                    if (tipsDelayTime != 0 || infoDelayTime != 0)
                    {
                        TipsAndAlertController.instance.PathPointHit(tipsText, infoText, tipsDelayTime, infoDelayTime, easy, medium, hard);
                    }
                }
            }
        }

        //...................//

        //....Arrival Runway UI Selection ....//

        if (Col.gameObject.tag == "Player" && pathpointName == "CS_0" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            // UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
           // print("Arrival Auto RunwayUISelection......00000000..");
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);
            Col.gameObject.GetComponent<RadarScript>().isAirCraftIRunway = true;
            UIManager.instance.Arv_RunwaySelection(Col.gameObject.transform,false);

            //.........runway status i.e. safe, unsafe or danger.......//
            UIManager.instance.currentLevelSelected.CheckLandingStatusForArrivalAricraft();

            UIManager.instance.currentLevelSelected.TailWindForRedColor();
            //.........................................................//

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
           

        }
        //....Arrival Auto RunwayUISelection ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "CS_1" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (GameManagerScript.instanceGMS.autoselectrunway == false)
            {
                UIManager.instance.Auto_Arv_RunwaySelection(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
                GameManagerScript.instanceGMS.autoselectrunway = true;
            }
            GameManagerScript.instanceGMS.autoselectrunway = false;

            NintendoController.instance.NpadButtonB2();  // divyansh
            //print("Arrival Auto RunwayUISelection........");
        }
        //.... Detour Selection ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "CS_2" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            //UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);
            Col.gameObject.GetComponent<RadarScript>().isAirCraftDetour = true;

            UIManager.instance.Arv_DetourSelection();
            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //....Auto Detour Close ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "CS_3" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            //print("0000000000000");
            if (GameManagerScript.instanceGMS.DetourwaySelected == false)
            {
                //print("111111111");
                UIManager.instance.Arv_DetourNotSelected(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
                GameManagerScript.instanceGMS.DetourwaySelected = true;
            }
            //print("222222222222");
            GameManagerScript.instanceGMS.DetourwaySelected = false;

            NintendoController.instance.NpadButtonB2();  // divyansh
            //Col.gameObject.GetComponent<RadarScript>().isArvSlowSpeedCtrl = true;                       
        }

        //.........Speed Variable started from here.......................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "CP_0" || gameObject.name == "DetourPoints_0") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform,true);

            if (Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed == 2.2f)
            {
                Col.gameObject.GetComponent<RadarScript>().isArvSlowSpeedCtrl = true;
                StartCoroutine(UIManager.instance.Slow_SpeedControl(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber, 0));  //....speed show ui icon...//
            }
            else if (Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed == 2.4f)
            {
                Col.gameObject.GetComponent<RadarScript>().isArvMediumSpeedCtrl = true;
                StartCoroutine(UIManager.instance.Medium_SpeedControl(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber, 0));  //....speed show ui icon...//
            }
            else if (Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed == 2.6f)
            {
                Col.gameObject.GetComponent<RadarScript>().isArvFastSpeedCtrl = true;
                StartCoroutine(UIManager.instance.Fast_SpeedControl(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber, 0));  //....speed show ui icon...//
            }

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }

        //.........Speed Variable stoped here.......................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "CP_7" || gameObject.name == "DetourPoints_7") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            UIManager.instance.SpeedControl_All(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber); //...Stop all speed control...//
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform,false);
        }
        //........Arrival TowerControl Hand_Off On..........//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_AirRoutesPoints_0" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            //UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);
            Col.gameObject.GetComponent<RadarScript>().isAirCraftArv_TowerControl = true;           

            UIManager.instance.Arv_TowerControlHand_Off_Call(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }

        //........Arrival TowerControlHand_Off Off....Auto Close......//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_AirRoutesPoints_4" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
           if(Col.gameObject.GetComponent<AircraftScripts>().arv_TowerCHandoff == false)
            {
                UIManager.instance.Arv_TowerControlHand_Off_AutoClosed(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            }
            Col.gameObject.GetComponent<AircraftScripts>().arv_TowerCHandoff = false;

            NintendoController.instance.NpadButtonB2();  // divyansh
        }

        //.................................//

        //.... Arrival CleartoLanding & GoAround UI ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_AirRoutesPoints_7" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            // UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);
            Col.gameObject.GetComponent<RadarScript>().isAirCraftCleartolanding = true;

            UIManager.instance.Arv_CleartoLanding_GoAround();

            //.............Check clear to landing is closed or not..............//
            UIManager.instance.currentLevelSelected.GetComponent<Level>().CheckFastWindForce(Col.gameObject.transform);
            //...............................................................//

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //.... Arrival GoAround ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_AirRoutesPoints_10" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (UIManager.instance.goaroundok == false && Col.gameObject.GetComponent<AircraftScripts>().airoplaneEMGEvent != AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                UIManager.instance.arv_cleartolanding_goaround_selection.SetActive(false);
                GameManagerScript.instanceGMS.GoAround34R_34L(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
                //UIManager.instance.Arv_Mask_All_Off(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
                UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, false);

                Col.gameObject.GetComponent<RadarScript>().isAirCraftCleartolanding = false;

                UIManager.instance.AirplaneStatusIconHandling(Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip, 4);    //...Aeroplane status...//
                
                NintendoController.instance.NpadButtonB2();  // divyansh

                //..............by basant..............
                ScoreManager.instance.Penalty(500);
                TipsAndAlertController.instance.OnPenalty(Control_Text.instance.tailwindStr, Col.gameObject.GetComponent<AircraftScripts>().flightNumber);
                ScoreManager.instance.forgotLandingApprovalCount++;
                RadarManagerScript.instance.IncreaseGoAroundCount(GameManagerScript.instanceGMS.PlaneList, Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
                //.....................................
            }
            else if (Col.gameObject.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                GameManagerScript.instanceGMS.ClearToLanding();

                UIManager.instance.References(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber, UIManager.instance.tWRSound);

                //if (Col.gameObject.GetComponent<RadarScript>().goAroundCount > 0)
                //{
                //    ScoreManager.instance.ClickForBonus(200);
                //}
                //else
                //{
                //    ScoreManager.instance.ClickForBonus(500);
                //}
                //...................................

                string str = RadarManagerScript.instance.airSpeed.text;
                string _windDir1 = str.Substring(0, 3);
                string _windForce1 = str.Substring(6, 2);
                UIManager.instance.TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalClearToLanding(UIManager.instance.planeNoArr, UIManager.instance.runwayNoArr, _windDir1, _windForce1);
                UIManager.instance.TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

                UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.ArrivalClearToLandingAudio(UIManager.instance.currentFlightNoClip, UIManager.instance.runwayNoArrClip1, UIManager.instance.runwayNoArrClip2, UIManager.instance.runwayNoArrClip3, UIManager.instance._windDir1Clip, UIManager.instance._windDir2Clip, UIManager.instance._windDir3Clip, UIManager.instance._windForce1Clip, UIManager.instance._windForce2Clip, UIManager.instance.tWRSound);
                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = UIManager.instance.audioClipsPlaneArr;
                SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
                GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, UIManager.instance.TWR);
            }
            UIManager.instance.goaroundok = false;

        }
        //.... WheelOpen BeforeLandOnRunway ....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_AirRunwayRoute_3"|| gameObject.name == "34L_AirRunwayRoute_3") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().FlapOpen();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().SlatOpen();
            Soundmaster.instance.FlapDown(Col.gameObject.transform.GetChild(0).GetComponent<AudioSource>());

            StartCoroutine(GearOpen(Col.gameObject.transform));

            UIManager.instance.AirplaneStatusIconHandling(Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip, 2); //...Aeroplane status...//

            //Invoke("GearOpen", 5f);
        }
        //.... Plane SpeedControl .. and open C8 and C9.. and L6 and L9...//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_AirRunwayRoute_9" || gameObject.name == "34L_AirRoutesPoints_9") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Soundmaster.instance.Slip_L(Col.gameObject.transform.GetChild(0).GetComponent<AudioSource>());

            Col.gameObject.GetComponent<FX>().TyreBurnoutSmoke = true; //....smoke from tyre...//           
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);


            if (gameObject.name == "34R_AirRunwayRoute_9")
            {               

                GameManagerScript.instanceGMS.C8_C9_Path(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

                //..........To Reach On Ground After Landing with same speed...//

                Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed = 2.2f;
                Col.gameObject.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
                //..................................//
            }
            else if (gameObject.name == "34L_AirRoutesPoints_9")
            {          
                GameManagerScript.instanceGMS.L6_L9_Path(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

                Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed = 1.9f; //.....when aircraft Land on runway speed of Aircraft default...bcz runway is short...//
                Col.gameObject.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;

            }
            GameManagerScript.instanceGMS.AircraftSpeed(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            UIManager.instance.AirplaneStatusIconHandling(Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip, 1); //...Aeroplane status...//

            Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).gameObject.SetActive(false);     // .......speed icon off...//
            Col.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);  // .....start ST light off...//

            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().TxLightOpen();     //...Texi light On...//
            Col.gameObject.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(true);  //...Texi light On...//

            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
            StartCoroutine(BackTyreRotation(Col.gameObject.transform));



            //.................Check Emergency plane..............//
            UIManager.instance.currentLevelSelected.CheckEmergencyPlane(Col.gameObject.transform);
            UIManager.instance.currentLevelSelected.CheckEmergencyAircraftAgainAtRunwayExit(Col.gameObject.transform);
            //....................................................//

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //.... Auto Select C9 ....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_RunwayPoints_3" || gameObject.name == "34L_RunwayPoints_2") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (gameObject.name == "34R_RunwayPoints_3")
            {
                //....if not click on any one C8 && C9...//
                if (GameManagerScript.instanceGMS.autoConnect == false)
                {
                    UIManager.instance.Arv_TaxiRouteC9_ActiveButton(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
                    NintendoController.instance.NpadButtonB2();  // divyansh
                }
                GameManagerScript.instanceGMS.autoConnect = false;
            }
            else if (gameObject.name == "34L_RunwayPoints_2")
            {
                //....if not click on any one L6 && L9...//
                if (GameManagerScript.instanceGMS.autoConnect == false)
                {
                    UIManager.instance.Arv_TaxiRouteL9_ActiveButton(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
                    NintendoController.instance.NpadButtonB2();  // divyansh
                }
                GameManagerScript.instanceGMS.autoConnect = false;
            }

            //........
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().EngineStop();
            CloseOtherThings(Col.gameObject.transform);
        }
        //............//

        if (Col.gameObject.tag == "Player" &&( gameObject.name == "34R_AirRunwayRoute_8"|| gameObject.name == "34L_AirRunwayRoute_8") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            //.....By Harshit.....//
            if (Col.gameObject.transform.GetComponentInChildren<CameraMovement>()!= null)
            {
                StartCoroutine(SetCameraMinimumValue(4, 0));
            }
            Col.gameObject.transform.GetComponent<AircraftScripts>().AircraftOnGround = true;

            //..............//

            UIManager.instance.PeneltyForArrivalLanding(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_AirRunwayRoute_10" || gameObject.name == "34L_AirRoutesPoints_10") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<FX>().TyreBurnoutSmoke = false; //....stop smoke from tyre...//
        }

        //.... After GoAround Reset All Items ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_GoAroundPoints_11" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponent<RadarScript>().isGoAround = true;
            GameManagerScript.instanceGMS.Gamestart(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            
        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_TaxiRoutePoints_5" || gameObject.name == "C9_TaxiRoutePoints_11" || gameObject.name == "L6_TaxiRoutePoints_5" || gameObject.name == "L9_TaxiRoutePoints_10") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (Col.gameObject.GetComponent<AircraftScripts>().arv_selectroute == false)
            {
                if (Col.gameObject.GetComponent<AircraftScripts>().restart_standby)
                {
                    StartCoroutine(UIManager.instance.Arv_RecallSpotButtons(Col.gameObject.transform));
                    Col.gameObject.GetComponent<AircraftScripts>().restart_standbyAgain = true;
                }
                else
                {
                    if (!Col.gameObject.GetComponent<AircraftScripts>().restart_standbyAgain)
                    {
                        Col.gameObject.GetComponent<AircraftScripts>().restart_standbyAgain = true;
                    }
                }
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;

                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStopRotate();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Stop();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Stop();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Stop();

            }
            else if (Col.gameObject.GetComponent<AircraftScripts>().arv_selectroute == true && Col.gameObject.GetComponent<AircraftScripts>().arv_selectrouteABC == false)
            {

                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f; 
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;


                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStopRotate();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Stop();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Stop();
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Stop();


                //..nothing..//
            }
        }

        //................//


        //.... PlaneRoll Rotation ....//

        if (Col.gameObject.tag == "Player" && gameObject.transform.GetComponent<Pathpoints>() != null && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (!gameObject.transform.GetComponent<Pathpoints>().tuningAnimationOff)
            {
                if (Col.gameObject.transform.GetComponentInChildren<CameraMovement>()!= null)
                {

                    if (gameObject.transform.GetComponent<Pathpoints>().turningAnimation == turningAnimationType.Roll)
                    {
                        GameManagerScript.instanceGMS.RollAnimation(turningRotationAngle, turningRotationAnimTime, Col.gameObject.transform); //:::::::::::::::::::::::::: 20 TO -20
                        StartCoroutine(RollAnimation1(Col.gameObject.transform));
                    }

                    if (gameObject.transform.GetComponent<Pathpoints>().turningAnimation == turningAnimationType.Yaw)
                    {
                        GameManagerScript.instanceGMS.YawAnimation(turningRotationAngle, turningRotationAnimTime, Col.gameObject.transform); //:::::::::::::::::::::::::: 10 TO -10
                        StartCoroutine(YawAnimation1(Col.gameObject.transform));
                    }

                    //if (gameObject.transform.GetComponent<Pathpoints>().turningAnimation == turningAnimationType.Pitch)
                    //{
                    //    GameManagerScript.instanceGMS.PitchAnimation(turningRotationAngle, turningRotationAnimTime, Col.gameObject.transform);//:::::::::::::::::::::::::: 10 TO -10
                    //    StartCoroutine(PitchAnimation1(Col.gameObject.transform));
                    //}

                    if (turningAnimation == turningAnimationType.Pitch)
                    {
                        if (!headWindCondition)
                        {
                            GameManagerScript.instanceGMS.PitchAnimation(turningRotationAngle, turningRotationAnimTime, Col.gameObject.transform);
                            StartCoroutine(PitchAnimation1(Col.gameObject.transform));

                        }
                        else
                        {
                            ShakingAirplaneCondition(Col.gameObject.transform);

                        }

                    }
                }
            }
        }

        #region Path Wheel Rotation Arrival

        //if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_WR1" || gameObject.name == "C8_2_2_WR1" || gameObject.name == "C8_2_3_WR1" || gameObject.name == "C8_2_3_WR4" ||
        //                                       gameObject.name == "C8_3_1_WR1" || gameObject.name == "C8_3_2_WR1" || gameObject.name == "C8_3_2_WR5" || gameObject.name == "C8_3_3_WR1" ||
        //                                       gameObject.name == "C8_3_3_WR4" || gameObject.name == "C8_403_1_WR2" || gameObject.name == "C8_403_1_WR4" || gameObject.name == "C8_403_2_WR2" ||
        //                                       gameObject.name == "C8_403_2_WR4" || gameObject.name == "C8_403_3_WR2" || gameObject.name == "C8_403_3_WR3"

        //                                       || gameObject.name == "C9_2_1_WR1" || gameObject.name == "C9_2_2_WR1" || gameObject.name == "C9_2_3_WR1" || gameObject.name == "C9_2_3_WR4" ||
        //                                       gameObject.name == "C9_3_1_WR1" || gameObject.name == "C9_3_2_WR1" || gameObject.name == "C9_3_2_WR5" || gameObject.name == "C9_3_3_WR1" ||
        //                                       gameObject.name == "C9_3_3_WR4" || gameObject.name == "C9_403_1_WR2" || gameObject.name == "C9_403_2_WR1" || gameObject.name == "C9_403_2_WR4" ||
        //                                       gameObject.name == "C9_403_2_WR6" || gameObject.name == "C9_403_3_WR2" || gameObject.name == "C9_403_3_WR3") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        //{
        //    GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRight(animSpeed);
        //}
        //if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_WRS1" || gameObject.name == "C8_2_2_WRS1" || gameObject.name == "C8_2_3_WRS1" || gameObject.name == "C8_2_3_WRS4" ||
        //                                       gameObject.name == "C8_3_1_WRS1" || gameObject.name == "C8_3_2_WRS1" || gameObject.name == "C8_3_2_WRS5" || gameObject.name == "C8_3_3_WRS1" ||
        //                                       gameObject.name == "C8_3_3_WRS4" || gameObject.name == "C8_403_1_WRS2" || gameObject.name == "C8_403_1_WRS4" || gameObject.name == "C8_403_2_WRS2" ||
        //                                       gameObject.name == "C8_403_2_WRS4" || gameObject.name == "C8_403_3_WRS2" || gameObject.name == "C8_403_3_WRS3"

        //                                       || gameObject.name == "C9_2_1_WRS1" || gameObject.name == "C9_2_2_WRS1" || gameObject.name == "C9_2_3_WRS1" || gameObject.name == "C9_2_3_WRS4" ||
        //                                       gameObject.name == "C9_3_1_WRS1" || gameObject.name == "C9_3_2_WRS1" || gameObject.name == "C9_3_2_WRS5" || gameObject.name == "C9_3_3_WRS1" ||
        //                                       gameObject.name == "C9_3_3_WRS4" || gameObject.name == "C9_403_1_WRS2" || gameObject.name == "C9_403_2_WRS1" || gameObject.name == "C9_403_2_WRS4" ||
        //                                       gameObject.name == "C9_403_2_WRS6" || gameObject.name == "C9_403_3_WRS2" || gameObject.name == "C9_403_3_WRS3") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        //{
        //    GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRightReset(animSpeed);
        //}

        //if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_WR2" || gameObject.name == "C8_2_1_WR3" || gameObject.name == "C8_2_2_WR2" || gameObject.name == "C8_2_2_WR3" ||
        //                                       gameObject.name == "C8_2_3_WR2" || gameObject.name == "C8_2_3_WR3" || gameObject.name == "C8_2_3_WR5" || gameObject.name == "C8_3_1_WR2" ||
        //                                       gameObject.name == "C8_3_1_WR3" || gameObject.name == "C8_3_2_WR2" || gameObject.name == "C8_3_2_WR3" || gameObject.name == "C8_3_2_WR4" ||
        //                                       gameObject.name == "C8_3_3_WR2" || gameObject.name == "C8_3_3_WR3" || gameObject.name == "C8_3_3_WR5" || gameObject.name == "C8_403_1_WR1" ||
        //                                       gameObject.name == "C8_403_1_WR3" || gameObject.name == "C8_403_2_WR1" || gameObject.name == "C8_403_2_WR3" || gameObject.name == "C8_403_2_WR1" ||
        //                                       gameObject.name == "C8_403_3_WR4" ||


        //                                       gameObject.name == "C9_2_1_WR2" || gameObject.name == "C9_2_1_WR3" || gameObject.name == "C9_2_2_WR2" || gameObject.name == "C9_2_2_WR3" ||
        //                                       gameObject.name == "C9_2_3_WR2" || gameObject.name == "C9_2_3_WR3" || gameObject.name == "C9_2_3_WR5" || gameObject.name == "C9_3_1_WR2" ||
        //                                       gameObject.name == "C9_3_1_WR3" || gameObject.name == "C9_3_2_WR2" || gameObject.name == "C9_3_2_WR3" || gameObject.name == "C9_3_2_WR4" ||
        //                                       gameObject.name == "C9_3_3_WR2" || gameObject.name == "C9_3_3_WR3" || gameObject.name == "C9_3_3_WR5" || gameObject.name == "C9_403_1_WR1" ||
        //                                       gameObject.name == "C9_403_2_WR2" || gameObject.name == "C9_403_2_WR3" || gameObject.name == "C9_403_2_WR5" || gameObject.name == "C9_403_3_WR1" ||
        //                                       gameObject.name == "C9_403_3_WR4") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        //{
        //    GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeft(animSpeed);
        //}
        //if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_WRS2" || gameObject.name == "C8_2_1_WRS3" || gameObject.name == "C8_2_2_WRS2" || gameObject.name == "C8_2_2_WRS3" ||
        //                                       gameObject.name == "C8_2_3_WRS2" || gameObject.name == "C8_2_3_WRS3" || gameObject.name == "C8_2_3_WRS5" || gameObject.name == "C8_3_1_WRS2" ||
        //                                       gameObject.name == "C8_3_1_WRS3" || gameObject.name == "C8_3_2_WRS2" || gameObject.name == "C8_3_2_WRS3" || gameObject.name == "C8_3_2_WRS4" ||
        //                                       gameObject.name == "C8_3_3_WRS2" || gameObject.name == "C8_3_3_WRS3" || gameObject.name == "C8_3_3_WRS5" || gameObject.name == "C8_403_1_WRS1" ||
        //                                       gameObject.name == "C8_403_1_WRS3" || gameObject.name == "C8_403_2_WRS1" || gameObject.name == "C8_403_2_WRS3" || gameObject.name == "C8_403_2_WRS1" ||
        //                                       gameObject.name == "C8_403_3_WRS4" ||


        //                                       gameObject.name == "C9_2_1_WRS2" || gameObject.name == "C9_2_1_WRS3" || gameObject.name == "C9_2_2_WRS2" || gameObject.name == "C9_2_2_WRS3" ||
        //                                       gameObject.name == "C9_2_3_WRS2" || gameObject.name == "C9_2_3_WRS3" || gameObject.name == "C9_2_3_WRS5" || gameObject.name == "C9_3_1_WRS2" ||
        //                                       gameObject.name == "C9_3_1_WRS3" || gameObject.name == "C9_3_2_WRS2" || gameObject.name == "C9_3_2_WRS3" || gameObject.name == "C9_3_2_WRS4" ||
        //                                       gameObject.name == "C9_3_3_WRS2" || gameObject.name == "C9_3_3_WRS3" || gameObject.name == "C9_3_3_WRS5" || gameObject.name == "C9_403_1_WRS1" ||
        //                                       gameObject.name == "C9_403_2_WRS2" || gameObject.name == "C9_403_2_WRS3" || gameObject.name == "C9_403_2_WRS5" || gameObject.name == "C9_403_3_WRS1" ||
        //                                       gameObject.name == "C9_403_3_WRS4") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        //{
        //    GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeftReset(animSpeed);
        //}

        #endregion

        //...................Arrival Last Point to Stop Plane..................................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_last" || gameObject.name == "C8_2_2_last" || gameObject.name == "C8_2_3_last" ||
                                               gameObject.name == "C9_2_1_last" || gameObject.name == "C9_2_2_last" || gameObject.name == "C9_2_3_last" ||

                                               gameObject.name == "C8_3_1_last" || gameObject.name == "C8_3_2_last" || gameObject.name == "C8_3_3_last" ||
                                               gameObject.name == "C9_3_1_last" || gameObject.name == "C9_3_2_last" || gameObject.name == "C9_3_3_last" ||

                                               gameObject.name == "C8_403_1_last" || gameObject.name == "C8_403_2_last" || gameObject.name == "C8_403_3_last" ||
                                               gameObject.name == "C9_403_1_last" || gameObject.name == "C9_403_2_last" || gameObject.name == "C9_403_3_last" ||

                                               gameObject.name == "L6_2_1_last" || gameObject.name == "L6_2_2_last" || gameObject.name == "L6_2_3_last" ||
                                               gameObject.name == "L9_2_1_last" || gameObject.name == "L9_2_2_last" || gameObject.name == "L9_2_3_last" ||

                                               gameObject.name == "L6_3_1_last" || gameObject.name == "L6_3_2_last" || gameObject.name == "L6_3_3_last" ||
                                               gameObject.name == "L9_3_1_last" || gameObject.name == "L9_3_2_last" || gameObject.name == "L9_3_3_last" ||

                                               gameObject.name == "L6_403_1_last" || gameObject.name == "L6_403_2_last" || gameObject.name == "L6_403_3_last" ||
                                               gameObject.name == "L9_403_1_last" || gameObject.name == "L9_403_2_last" || gameObject.name == "L9_403_3_last" ||

                                               gameObject.name == "V1 Emg 34R_last" || gameObject.name == "V1 Emg 16R_last" || gameObject.name == "V1 Emg 16L_last" || //...V1 Emg Last point...//
                                               gameObject.name == "67_203_3_last" || gameObject.name == "23_65_3_last" || gameObject.name == "144_15_3_last"   //...Spot to spot Last point...//

                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            Col.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            

            Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
            Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;

            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStopRotate();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Stop();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Stop();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Stop();

            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().LightStop();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TxLightClosed(); //...Texi light off...//
            Col.gameObject.transform.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(false); //...Texi light off...//

            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().EngineStop();
            Col.gameObject.transform.GetComponent<FX>().Heat_Haze = false;

            if(gameObject.name == "67_203_3_last" || gameObject.name == "23_65_3_last" || gameObject.name == "144_15_3_last" )   //...Spot to spot Last point...//)
            {
                GameManagerScript.instanceGMS.flightStrapsParent = UIManager.instance._Canvas.transform.GetChild(4);
                GameManagerScript.instanceGMS.MidToRightSlide(Col.gameObject.transform);
            }
            else
            {
                GameManagerScript.instanceGMS.flightStrapsParent = UIManager.instance._Canvas.transform.GetChild(3);
                GameManagerScript.instanceGMS.MidToRightSlide(Col.gameObject.transform);
            }      
           
            UIManager.instance.AirplaneStatusIconHandling(Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip, 6); //...Aeroplane status...//

            //........for Bording Bridge...............//

            if (UIManager.instance.BBspot2)
            {
                //GameManagerScript.instanceGMS.boardingBridges[1].GetComponent<PbbScript>().BBIn();
                //Soundmaster.instance.Boarding(GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].transform.GetChild(0).GetComponent<AudioSource>());

            }
            if (UIManager.instance.BBspot3)
            {
                //GameManagerScript.instanceGMS.boardingBridges[2].GetComponent<PbbScript>().BBIn();
                //Soundmaster.instance.Boarding(GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].transform.GetChild(0).GetComponent<AudioSource>());
            }

            //.......................................//

            //..............Ground Vehicles fadeOut.........................// 
            if (UIManager.instance.BBspot2)
            {
                GameManagerScript.instanceGMS.Arv_GroundItemVechicles_Off();
                GameManagerScript.instanceGMS.GroundItems[1].SetActive(true);
                FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
                print("Last point...............>");
                Invoke("FadeoutGrounditem", 20f);
            }
            if (UIManager.instance.BBspot3)
            {
                GameManagerScript.instanceGMS.Arv_GroundItemVechicles_Off();
                GameManagerScript.instanceGMS.GroundItems[2].SetActive(true);
                FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
                print("Last point...............>");
                Invoke("FadeoutGrounditem", 20f);
            }
            if (UIManager.instance.BBspot403)
            {
                GameManagerScript.instanceGMS.Arv_GroundItemVechicles_Off();
                GameManagerScript.instanceGMS.GroundItems[3].SetActive(true);
                FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
                print("Last point...............>");
                Invoke("FadeoutGrounditem", 20f);
            }
            //.............................................................//
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_HCS" || gameObject.name == "C8_2_2_HCS" || gameObject.name == "C8_2_3_HCS" ||
                                              gameObject.name == "C8_3_1_HCS" || gameObject.name == "C8_3_2_HCS" || gameObject.name == "C8_3_3_HCS" ||
                                              gameObject.name == "C8_403_1_HCS" || gameObject.name == "C8_403_2_HCS" || gameObject.name == "C8_403_3_HCS"||

                                              gameObject.name == "C9_2_1_HCS" || gameObject.name == "C9_2_2_HCS" || gameObject.name == "C9_2_3_HCS" ||
                                              gameObject.name == "C9_3_1_HCS" || gameObject.name == "C9_3_2_HCS" || gameObject.name == "C9_3_3_HCS" ||
                                              gameObject.name == "C9_403_1_HCS" || gameObject.name == "C9_403_2_HCS" || gameObject.name == "C9_403_3_HCS"||

                                              gameObject.name == "L6_2_1_HCS" || gameObject.name == "L6_2_2_HCS" || gameObject.name == "L6_2_3_HCS" ||
                                              gameObject.name == "L6_3_1_HCS" || gameObject.name == "L6_3_2_HCS" || gameObject.name == "L6_3_3_HCS" ||
                                              gameObject.name == "L6_403_1_HCS" || gameObject.name == "L6_403_2_HCS" || gameObject.name == "L6_403_3_HCS" ||

                                              gameObject.name == "L9_2_1_HCS" || gameObject.name == "L9_2_2_HCS" || gameObject.name == "L9_2_3_HCS" ||
                                              gameObject.name == "L9_3_1_HCS" || gameObject.name == "L9_3_2_HCS" || gameObject.name == "L9_3_3_HCS" ||
                                              gameObject.name == "L9_403_1_HCS" || gameObject.name == "L9_403_2_HCS" || gameObject.name == "L9_403_3_HCS"

                                              ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            Col.gameObject.transform.GetComponent<RadarScript>().arv_IsAirCraft_Hold = true;
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);
            UIManager.instance.Arv_HoldPosition_Call(Col.gameObject.transform, false);

        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "C8_2_1_HCL" || gameObject.name == "C8_2_2_HCL" || gameObject.name == "C8_2_3_HCL" ||
                                               gameObject.name == "C8_3_1_HCL" || gameObject.name == "C8_3_2_HCL" || gameObject.name == "C8_3_3_HCL" ||
                                               gameObject.name == "C8_403_1_HCL" || gameObject.name == "C8_403_2_HCL" || gameObject.name == "C8_403_3_HCL"||

                                               gameObject.name == "C9_2_1_HCL" || gameObject.name == "C9_2_2_HCL" || gameObject.name == "C9_2_3_HCL" ||
                                               gameObject.name == "C9_3_1_HCL" || gameObject.name == "C9_3_2_HCL" || gameObject.name == "C9_3_3_HCL" ||
                                               gameObject.name == "C9_403_1_HCL" || gameObject.name == "C9_403_2_HCL" || gameObject.name == "C9_403_3_HCL"||

                                               gameObject.name == "L6_2_1_HCL" || gameObject.name == "L6_2_2_HCL" || gameObject.name == "L6_2_3_HCL" ||
                                              gameObject.name == "L6_3_1_HCL" || gameObject.name == "L6_3_2_HCL" || gameObject.name == "L6_3_3_HCL" ||
                                              gameObject.name == "L6_403_1_HCL" || gameObject.name == "L6_403_2_HCL" || gameObject.name == "L6_403_3_HCL" ||

                                              gameObject.name == "L9_2_1_HCL" || gameObject.name == "L9_2_2_HCL" || gameObject.name == "L9_2_3_HCL" ||
                                              gameObject.name == "L9_3_1_HCL" || gameObject.name == "L9_3_2_HCL" || gameObject.name == "L9_3_3_HCL" ||
                                              gameObject.name == "L9_403_1_HCL" || gameObject.name == "L9_403_2_HCL" || gameObject.name == "L9_403_3_HCL"

                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))

        {

            
            Col.gameObject.transform.GetComponent<RadarScript>().arvIsFinalHoldContinueStopTrigger = true;

            if (GameManagerScript.instanceGMS.currentPlaneActive == Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber)
            {
                UIManager.instance.Arv_HoldPosnAndContinuePosUIButtonsDeactive();
            }

            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, false);

            if (Col.gameObject.transform.GetComponent<RadarScript>().arvIsContinue) {

                UIManager.instance.HoldCorotineArrival();
                UIManager.instance.ContinueCorotineArrival();
            }
           

            Col.gameObject.transform.GetComponent<RadarScript>().arv_IsAirCraft_Hold = false;
            Col.gameObject.transform.GetComponent<RadarScript>().arv_IsAirCraft_Continue = false;
        }
        //............................................................................//

        //........Arrival PathPoint End...........//

        //...........Departure PathPoint..............//

        //.... PushBack Movement ....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "Back_Upto_R" || gameObject.name == "Back_Upto_L") && !Col.gameObject.transform.GetComponent<AircraftScripts>().isPushbackComplete)
        {
            StartCoroutine(Col.gameObject.transform.GetComponent<AircraftScripts>().PushBackBackTwo());

            if (gameObject.name == "Back_Upto_R")
            {
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRight(animSpeed);
            }
            else if (gameObject.name == "Back_Upto_L")
            {
                Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeft(animSpeed);
            }
           
        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "Plane_Left" || gameObject.name == "Plane_Right") && !Col.gameObject.transform.GetComponent<AircraftScripts>().isPushbackComplete)
        {
            StartCoroutine(Col.gameObject.transform.GetComponent<AircraftScripts>().PushBackBackThree());

            if (gameObject.name == "Plane_Right")
            {
                StartCoroutine(FrontWheelstraightRight(Col.gameObject.transform));  //....Reset Wheel....//
            }
            if (gameObject.name == "Plane_Left")
            {
                StartCoroutine(FrontWheelstraightLeft(Col.gameObject.transform));  //....Reset Wheel....//
            }


        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "Plane_Right_1" || gameObject.name == "Plane_Left_1") && !Col.gameObject.transform.GetComponent<AircraftScripts>().isPushbackComplete)
        {
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TyreNBackwordStopRotate();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB1Stop();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB2Stop();
            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB3Stop();

            Col.gameObject.transform.GetComponent<AircraftScripts>().pusshbackthird = false;
            Col.gameObject.transform.GetComponent<AircraftScripts>().isPushbackComplete = true;

            //.........For Departure Plane ..............//

            //if (Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 1 || Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 4 ||
            //    Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 8 || Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 9)

            if (Col.gameObject.transform.GetComponent<RadarScript>().isDeparture)
            {

                StartCoroutine(UIManager.instance.IMaskOnForCT_SB(Col.gameObject.transform));
                StartCoroutine(UIManager.instance.ATC_BeforeClearToTexi(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));


                //...............................................................Ashish........................................................................//
                Col.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Col.gameObject.transform.transform.GetChild(0).GetComponent<Collider>().enabled = true;
                Col.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = true;
                //..............................................................................................................................................//


            }
            //.........For Spot To Spot Plane ..............//

            //else if (Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 5 || Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 6 ||
            //    Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber == 7)

            else if (Col.gameObject.transform.GetComponent<RadarScript>().isSpottoSpot)
            {

                Col.gameObject.transform.GetComponentInChildren<AircraftScripts>().pushBackTowingCar.GetComponent<Animator>().SetInteger("PushMove", 1); //.....for Spot to Spot...//
                Col.gameObject.transform.GetComponentInChildren<AircraftScripts>().pushBackTowingCar.gameObject.GetComponentInChildren<PushbackCar>().enabled = false;

                StartCoroutine(CallTowingCarMove(Col.gameObject.transform));

                //...............................................................Ashish........................................................................//
                Col.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Col.gameObject.transform.transform.GetChild(0).GetComponent<Collider>().enabled = true;
                Col.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = true;
                //..............................................................................................................................................//

                //Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
                //Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
                //Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
                //Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();

                //Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TxLightOpen();
                //UIManager.instance.Dep_Taxi(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);  //......Departure AirplaneStatus......//

                //Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
                //Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
            }
            //.............................................//

        }
        //................................//

        //..........Take Off Approvel , Hold shortoff and Line and wait.......//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_Hit" || gameObject.name == "54_34R_2_Hit" || gameObject.name == "54_34R_3_Hit" ||
                                               gameObject.name == "54_16R_1_Hit" || gameObject.name == "54_16R_2_Hit" || gameObject.name == "54_16R_3_Hit" ||
                                               gameObject.name == "54_16L_1_Hit" || gameObject.name == "54_16L_2_Hit" || gameObject.name == "54_16L_3_Hit" ||

                                               gameObject.name == "141_34R_1_Hit" || gameObject.name == "141_34R_2_Hit" || gameObject.name == "141_34R_3_Hit" ||
                                               gameObject.name == "141_16R_1_Hit" || gameObject.name == "141_16R_2_Hit" || gameObject.name == "141_16R_3_Hit" ||
                                               gameObject.name == "141_16L_1_Hit" || gameObject.name == "141_16L_2_Hit" || gameObject.name == "141_16L_3_Hit" ||

                                               gameObject.name == "113_34R_1_Hit" || gameObject.name == "113_34R_2_Hit" || gameObject.name == "113_34R_3_Hit" ||
                                               gameObject.name == "113_16R_1_Hit" || gameObject.name == "113_16R_2_Hit" || gameObject.name == "113_16R_3_Hit" ||
                                               gameObject.name == "113_16L_1_Hit" || gameObject.name == "113_16L_2_Hit" || gameObject.name == "113_16L_3_Hit" ||

                                               
                                               gameObject.name == "107_34R_1_Hit" || gameObject.name == "107_34R_2_Hit" || gameObject.name == "107_34R_3_Hit" ||
                                               gameObject.name == "107_16R_1_Hit" || gameObject.name == "107_16R_2_Hit" || gameObject.name == "107_16R_3_Hit" ||
                                               gameObject.name == "107_16L_1_Hit" || gameObject.name == "107_16L_2_Hit" || gameObject.name == "107_16L_3_Hit" ||

                                               gameObject.name == "108_34R_1_Hit" || gameObject.name == "108_34R_2_Hit" || gameObject.name == "108_34R_3_Hit" ||
                                               gameObject.name == "108_16R_1_Hit" || gameObject.name == "108_16R_2_Hit" || gameObject.name == "108_16R_3_Hit" ||
                                               gameObject.name == "108_16L_1_Hit" || gameObject.name == "108_16L_2_Hit" || gameObject.name == "108_16L_3_Hit" ||

                                               gameObject.name == "109_34R_1_Hit" || gameObject.name == "109_34R_2_Hit" || gameObject.name == "109_34R_3_Hit" ||
                                               gameObject.name == "109_16R_1_Hit" || gameObject.name == "109_16R_2_Hit" || gameObject.name == "109_16R_3_Hit" ||
                                               gameObject.name == "109_16L_1_Hit" || gameObject.name == "109_16L_2_Hit" || gameObject.name == "109_16L_3_Hit" ||

                                               gameObject.name == "101_34R_1_Hit" || gameObject.name == "101_34R_2_Hit" || gameObject.name == "101_34R_3_Hit" ||
                                               gameObject.name == "101_16R_1_Hit" || gameObject.name == "101_16R_2_Hit" || gameObject.name == "101_16R_3_Hit" ||
                                               gameObject.name == "101_16L_1_Hit" || gameObject.name == "101_16L_2_Hit" || gameObject.name == "101_16L_3_Hit" ||

                                               gameObject.name == "V1_34R_1_Hit" || gameObject.name == "V1_34R_2_Hit" || gameObject.name == "V1_34R_3_Hit" ||
                                               gameObject.name == "V1_16R_1_Hit" || gameObject.name == "V1_16R_2_Hit" || gameObject.name == "V1_16R_3_Hit" ||
                                               gameObject.name == "V1_16L_1_Hit" || gameObject.name == "V1_16L_2_Hit" || gameObject.name == "V1_16L_3_Hit"


                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly == false && Col.gameObject.transform.GetComponent<AircraftScripts>().holdshort == false && Col.gameObject.transform.GetComponent<AircraftScripts>().linewait == false) //....if not selected any one..//
            {               
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;
              
            }
            else if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly == false && Col.gameObject.transform.GetComponent<AircraftScripts>().holdshort == true)  //....if holdshort approved...//
            {
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;
               
                StartCoroutine(CallTakeoffApprovedAgain(Col.gameObject.transform));
            }
            else if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly == false && Col.gameObject.transform.GetComponent<AircraftScripts>().linewait == true) //....if Line wait approved...//
            {
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;

                //UIManager.instance.Dep_Mask_Blue_On(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);

            }
            else if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly == true) //....if approved take off....//
            {
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;
            }
            
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "V1 Emg 34R_0" || gameObject.name == "V1 Emg 16R_0" || gameObject.name == "V1 Emg 16L_0") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponent<FX>().Emergency_smoke = true; //....Emg smoke from tyre...// 

            Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed = 0;
            Col.gameObject.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0;

            UIManager.instance.TakeOffCancelATC(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            
            Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(4).gameObject.SetActive(true);
            for (int i = 0; i < Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(4).childCount; i++)
            {
                Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(4).GetChild(i).gameObject.SetActive(false);
            }
            Col.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(4).GetChild(0).gameObject.SetActive(true); //...On Emg Button...//
        }

        //.... SpeedUp34R ....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_0" || gameObject.name == "16L_Departure_0" || gameObject.name == "16R_Departure_0") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().StLightStart();  //.....st light start..//
            Col.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true); //...ST light mesh on...//

            if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly)
            {
                StartCoroutine(Col.gameObject.GetComponent<AircraftScripts>().TakeoffApprovedSpeed(0));

                Col.gameObject.GetComponentInChildren<PlaneAnimationController>().LDLightOpen(); //..Landing Light On..//
                Col.gameObject.GetComponentInChildren<AircraftScripts>().landingLight.SetActive(true); //..Landing Light On..//
                Col.gameObject.GetComponentInChildren<PlaneAnimationController>().TxLightOpen();  //...Texi light On...//
                Col.gameObject.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(true);  //...Texi light On...//

            }
            else if (Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly == false && Col.gameObject.transform.GetComponent<AircraftScripts>().linewait == true)
            {
                Col.gameObject.GetComponent<AircraftScripts>().PlaneSpeed = 0;
                Col.gameObject.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0;
                //UIManager.instance.ReCallTakeoffApproval = true;
                Col.gameObject.transform.GetComponent<RadarScript>().dep_TakeoffApprovalOnly = true;
                StartCoroutine(UIManager.instance.TakeoffApprovalOnlyIMask(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
                StartCoroutine(UIManager.instance.TakeoffApprovalOnlyOneButton(Col.gameObject.transform, 0));
            }
        }


        //.... After go Around DCHO ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_GoAroundPoints_1" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            //UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform, true);

            Col.gameObject.GetComponent<RadarScript>().goAroundDCH = true;
            UIManager.instance.Arv_DepartureControlHand_Off_Call(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            StartCoroutine(UIManager.instance.Arv_DepartureControlHand_Off_AutoClosed(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }

        //.... After go Around ACHo ....//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_GoAroundPoints_4" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            //goAroundACH
            //UIManager.instance.Arv_Mask_Blue_On(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Arv_Mask_Green_On(Col.gameObject.transform,true);
            Col.gameObject.GetComponent<RadarScript>().goAroundACH = true;
            UIManager.instance.Arv_ApproachControlHand_Off_Call(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber);

            StartCoroutine(UIManager.instance.Arv_ApproachControlHand_Off_AutoClosed(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //UIManager.instance.SpeedControl_All();

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//

            
        }


        //.........Reset Radar By basant plane spot...//

        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_GoAroundPoints_5" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        if (Col.gameObject.tag == "Player" && gameObject.name == "34R_GoAroundPoints_12" && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            GameManagerScript.instanceGMS.PlaneList[Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber].GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
        //............................................//


        //.... TyreIn ....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_3" || gameObject.name == "16L_Departure_2" || gameObject.name == "16R_Departure_2") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Stop();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Stop();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Stop();

            GameManagerScript.instanceGMS.bg_Building.SetActive(false);  //....Demo_Building...// 

            if (Col.gameObject.transform.GetComponentInChildren<CameraMovement>()!= null)
            {
                StartCoroutine(SetCameraMinimumValue(1, -40));
            }
            Col.gameObject.GetComponent<AircraftScripts>().AircraftOnGround = false;

            //........In Air Departure.status...//
            //UIManager.instance.Dep_InAir(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Dep_AirplaneStatusIconHandling(Col.gameObject.transform.GetComponent<AircraftScripts>().airPlaneStrip, 0); //......Departure AirplaneStatus......//
            //......................................//
        }


        //...........Dep_Departure HandOff.........Active.................//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_5" || gameObject.name == "16L_Departure_4" || gameObject.name == "16R_Departure_4") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().dep_DepartureHandOff = true;
            //UIManager.instance.Dep_Mask_Blue_On(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform,true);
            UIManager.instance.DepartureHandOff_Call(Col.gameObject.transform); //....DepartureHandOff active...//

            
            Soundmaster.instance.GearUp(Col.gameObject.transform.GetChild(0).GetComponent<AudioSource>());
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearWheelNoseClosed();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearWheelBoeingClosed();
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().LDLightClosed(); //..Landing Light Off..//
            Col.gameObject.GetComponentInChildren<AircraftScripts>().landingLight.SetActive(false); //..Landing Light Off..//
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().TxLightClosed();  //...Texi light off...//
            Col.gameObject.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(false); //...Texi light off...//

            RadarManagerScript.instance.ChangeDepRadarCamera(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber); // Radar By Basant

            //.....check condition for penalty when there is delay..........
            int currentGameTime = ScoreManager.instance.ConvertTextTimeIntoSeconds(ScoreManager.instance.timeTextGame.text);
            int planeDep_ArrTimeInSec = Col.gameObject.GetComponent<RadarScript>().aircraftDepArrTimeInSec;
            if (currentGameTime > planeDep_ArrTimeInSec)
            {
                // Give penalty = exceed time * 5
                int exceedTimeInSec = currentGameTime - planeDep_ArrTimeInSec;
                int exceedTimeInMin = (int)exceedTimeInSec / 60;

                int penaltyAmt = exceedTimeInMin * 5;
                ScoreManager.instance.Penalty(penaltyAmt);
                TipsAndAlertController.instance.OnPenalty(Control_Text.instance.delayStr, Col.gameObject.GetComponent<AircraftScripts>().flightNumber);
            }
            if (Col.gameObject.transform.GetComponentInChildren<CameraMovement>()!= null)
            {
                //RadarManagerScript.instance.startPath.SetActive(false);
                var color = RadarManagerScript.instance.startPath.GetComponent<Image>().color;
                color.a = .3f;
                RadarManagerScript.instance.startPath.GetComponent<Image>().color = color;
            }

            Col.gameObject.transform.GetComponent<AircraftScripts>().goandfly = false;
            Col.gameObject.transform.GetComponent<AircraftScripts>().linewait = false;
            Col.gameObject.transform.GetComponent<AircraftScripts>().holdshort = false;

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//

        }
        //...........Dep_Departure HandOff.........Auto close.................//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_10" || gameObject.name == "16L_Departure_9" || gameObject.name == "16R_Departure_9") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().dep_DepartureHandOff = false;
           // UIManager.instance.Dep_Mask_All_Off(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            if (Col.gameObject.GetComponent<AircraftScripts>().dep_DepCtrlHandOffClick == false)
            {
                StartCoroutine(UIManager.instance.DepartureHandOff_AutoClosed(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));  //.......Auto closed......//
            }
            Col.gameObject.GetComponent<AircraftScripts>().dep_DepCtrlHandOffClick = false;
            NintendoController.instance.NpadButtonB2();  // divyansh
        }
        //.....................................//
        //...........Radar Control.........Active.................//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_11" || gameObject.name == "16L_Departure_12" || gameObject.name == "16R_Departure_12") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().dep_RadarControlOff = true;
            //UIManager.instance.Dep_Mask_Blue_On(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform,true);
            UIManager.instance.RadarControlOff_Call(Col.gameObject.transform); //....RadarControlOff active...//

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //...........Radar Control .........Auto close.................//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_14" || gameObject.name == "16L_Departure_15" || gameObject.name == "16R_Departure_15") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (Col.gameObject.GetComponent<AircraftScripts>().dep_RadarCtrlClick == false)
            {
                StartCoroutine(UIManager.instance.RadarControlOff_AutoClosed(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            }
            Col.gameObject.GetComponent<AircraftScripts>().dep_RadarCtrlClick = false;
            NintendoController.instance.NpadButtonB2();  // divyansh
        }

        //...........continue own nav .........Active.................//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_15" || gameObject.name == "16L_Departure_16" || gameObject.name == "16R_Departure_16") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
           
            Col.gameObject.transform.GetComponent<RadarScript>().dep_ContinueOwnNav = true;
            //UIManager.instance.Dep_Mask_Blue_On(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, true);

            UIManager.instance.ContinueOwnNav_Call(Col.gameObject.transform); //....ContinueOwnNav active...//
            StartCoroutine(UIManager.instance.ContinueOwnNav_AutoClosed(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //..............................................................//

        #region Path Wheel Rotation Departure

        ////...........Juggaaaaad..............//
        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_WR1" || gameObject.name == "54_34R_2_WR1" || gameObject.name == "54_34R_3_WR2" || gameObject.name == "54_34R_3_WR3" ||
                                               gameObject.name == "54_16R_1_WR3" || gameObject.name == "54_16R_2_WR3" || gameObject.name == "54_16L_1_WR2" || gameObject.name == "54_16L_1_WR3" ||
                                               gameObject.name == "54_16L_2_WR1" || gameObject.name == "54_16L_2_WR4" || gameObject.name == "54_16L_2_WR5" || gameObject.name == "54_16L_3_WR2" ||
                                               gameObject.name == "54_16L_3_WR4") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeft(animSpeed);

        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_WRS1" || gameObject.name == "54_34R_2_WRS1" || gameObject.name == "54_34R_3_WRS2" || gameObject.name == "54_34R_3_WRS3" ||
                                               gameObject.name == "54_16R_1_WRS3" || gameObject.name == "54_16R_2_WRS3" || gameObject.name == "54_16L_1_WRS2" || gameObject.name == "54_16L_1_WRS3" ||
                                               gameObject.name == "54_16L_2_WRS1" || gameObject.name == "54_16L_2_WRS4" || gameObject.name == "54_16L_2_WRS5" || gameObject.name == "54_16L_3_WRS2" ||
                                               gameObject.name == "54_16L_3_WRS4") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeftReset(animSpeed);
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_WR2" || gameObject.name == "54_34R_1_WR3" || gameObject.name == "54_34R_1_WR2" || gameObject.name == "54_34R_1_WR3" ||
                                               gameObject.name == "54_34R_1_WR3" || gameObject.name == "54_34R_1_WR2" || gameObject.name == "54_34R_1_WR3" || gameObject.name == "54_16R_1_WR1" ||
                                               gameObject.name == "54_16R_1_WR2" || gameObject.name == "54_16R_1_WR4" || gameObject.name == "54_16R_1_WR5" || gameObject.name == "54_16R_2_WR1" ||
                                               gameObject.name == "54_16R_2_WR2" || gameObject.name == "54_16R_2_WR4" || gameObject.name == "54_16R_2_WR5" || gameObject.name == "54_16R_3_WR1" ||
                                               gameObject.name == "54_16R_3_WR2" || gameObject.name == "54_16R_3_WR3" || gameObject.name == "54_16R_3_WR4" || gameObject.name == "54_16R_3_WR5" ||
                                               gameObject.name == "54_16L_1_WR1" || gameObject.name == "54_16L_2_WR2" || gameObject.name == "54_16L_2_WR3" || gameObject.name == "54_16L_3_WR1" ||
                                               gameObject.name == "54_16L_3_WR3" || gameObject.name == "54_16L_3_WR5") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRight(animSpeed);
        }
        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_WRS2" || gameObject.name == "54_34R_1_WRS3" || gameObject.name == "54_34R_1_WRS2" || gameObject.name == "54_34R_1_WRS3" ||
                                               gameObject.name == "54_34R_1_WRS3" || gameObject.name == "54_34R_1_WRS2" || gameObject.name == "54_34R_1_WRS3" || gameObject.name == "54_16R_1_WRS1" ||
                                               gameObject.name == "54_16R_1_WRS2" || gameObject.name == "54_16R_1_WRS4" || gameObject.name == "54_16R_1_WRS5" || gameObject.name == "54_16R_2_WRS1" ||
                                               gameObject.name == "54_16R_2_WRS2" || gameObject.name == "54_16R_2_WRS4" || gameObject.name == "54_16R_2_WRS5" || gameObject.name == "54_16R_3_WRS1" ||
                                               gameObject.name == "54_16R_3_WRS2" || gameObject.name == "54_16R_3_WRS3" || gameObject.name == "54_16R_3_WRS4" || gameObject.name == "54_16R_3_WRS5" ||
                                               gameObject.name == "54_16L_1_WRS1" || gameObject.name == "54_16L_2_WRS2" || gameObject.name == "54_16L_2_WRS3" || gameObject.name == "54_16L_3_WRS1" ||
                                               gameObject.name == "54_16L_3_WRS3" || gameObject.name == "54_16L_3_WRS5") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRightReset(animSpeed);
        }

        #endregion

        //...........Departure  End..............//

        //........Departure Tower Hand_Off.....//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_TC" || gameObject.name == "54_34R_2_TC" || gameObject.name == "54_34R_3_TC" ||
                                               gameObject.name == "54_16R_1_TC" || gameObject.name == "54_16R_2_TC" || gameObject.name == "54_16R_3_TC" ||
                                               gameObject.name == "54_16L_1_TC" || gameObject.name == "54_16L_2_TC" || gameObject.name == "54_16L_3_TC" ||

                                               gameObject.name == "141_34R_1_TC" || gameObject.name == "141_34R_2_TC" || gameObject.name == "141_34R_3_TC" ||
                                               gameObject.name == "141_16R_1_TC" || gameObject.name == "141_16R_2_TC" || gameObject.name == "141_16R_3_TC" ||
                                               gameObject.name == "141_16L_1_TC" || gameObject.name == "141_16L_2_TC" || gameObject.name == "141_16L_3_TC" ||

                                               gameObject.name == "113_34R_1_TC" || gameObject.name == "113_34R_2_TC" || gameObject.name == "113_34R_3_TC" ||
                                               gameObject.name == "113_16R_1_TC" || gameObject.name == "113_16R_2_TC" || gameObject.name == "113_16R_3_TC" ||
                                               gameObject.name == "113_16L_1_TC" || gameObject.name == "113_16L_2_TC" || gameObject.name == "113_16L_3_TC" ||


                                               gameObject.name == "107_34R_1_TC" || gameObject.name == "107_34R_2_TC" || gameObject.name == "107_34R_3_TC" ||
                                               gameObject.name == "107_16R_1_TC" || gameObject.name == "107_16R_2_TC" || gameObject.name == "107_16R_3_TC" ||
                                               gameObject.name == "107_16L_1_TC" || gameObject.name == "107_16L_2_TC" || gameObject.name == "107_16L_3_TC" ||

                                               gameObject.name == "108_34R_1_TC" || gameObject.name == "108_34R_2_TC" || gameObject.name == "108_34R_3_TC" ||
                                               gameObject.name == "108_16R_1_TC" || gameObject.name == "108_16R_2_TC" || gameObject.name == "108_16R_3_TC" ||
                                               gameObject.name == "108_16L_1_TC" || gameObject.name == "108_16L_2_TC" || gameObject.name == "108_16L_3_TC" ||

                                               gameObject.name == "109_34R_1_TC" || gameObject.name == "109_34R_2_TC" || gameObject.name == "109_34R_3_TC" ||
                                               gameObject.name == "109_16R_1_TC" || gameObject.name == "109_16R_2_TC" || gameObject.name == "109_16R_3_TC" ||
                                               gameObject.name == "109_16L_1_TC" || gameObject.name == "109_16L_2_TC" || gameObject.name == "109_16L_3_TC" ||

                                               gameObject.name == "101_34R_1_TC" || gameObject.name == "101_34R_2_TC" || gameObject.name == "101_34R_3_TC" ||
                                               gameObject.name == "101_16R_1_TC" || gameObject.name == "101_16R_2_TC" || gameObject.name == "101_16R_3_TC" ||
                                               gameObject.name == "101_16L_1_TC" || gameObject.name == "101_16L_2_TC" || gameObject.name == "101_16L_3_TC" ||

                                               gameObject.name == "V1_34R_1_TC" || gameObject.name == "V1_34R_2_TC" || gameObject.name == "V1_34R_3_TC" ||
                                               gameObject.name == "V1_16R_1_TC" || gameObject.name == "V1_16R_2_TC" || gameObject.name == "V1_16R_3_TC" ||
                                               gameObject.name == "V1_16L_1_TC" || gameObject.name == "V1_16L_2_TC" || gameObject.name == "V1_16L_3_TC"


                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            
            Col.gameObject.transform.GetComponent<RadarScript>().dep_TowerControlHand_Off = true;
            
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform,true);
            UIManager.instance.TowerControlHand_Off_Call(Col.gameObject.transform);

            StartCoroutine(Col.gameObject.transform.GetComponent<AircraftScripts>().TowerControlHand_Off_AutoClosed()); //....Auto close...//

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }
        //....................................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_TOA" || gameObject.name == "54_34R_2_TOA" || gameObject.name == "54_34R_3_TOA" ||
                                               gameObject.name == "54_16R_1_TOA" || gameObject.name == "54_16R_2_TOA" || gameObject.name == "54_16R_3_TOA" ||
                                               gameObject.name == "54_16L_1_TOA" || gameObject.name == "54_16L_2_TOA" || gameObject.name == "54_16L_3_TOA" ||

                                               gameObject.name == "141_34R_1_TOA" || gameObject.name == "141_34R_2_TOA" || gameObject.name == "141_34R_3_TOA" ||
                                               gameObject.name == "141_16R_1_TOA" || gameObject.name == "141_16R_2_TOA" || gameObject.name == "141_16R_3_TOA" ||
                                               gameObject.name == "141_16L_1_TOA" || gameObject.name == "141_16L_2_TOA" || gameObject.name == "141_16L_3_TOA" ||

                                               gameObject.name == "113_34R_1_TOA" || gameObject.name == "113_34R_2_TOA" || gameObject.name == "113_34R_3_TOA" ||
                                               gameObject.name == "113_16R_1_TOA" || gameObject.name == "113_16R_2_TOA" || gameObject.name == "113_16R_3_TOA" ||
                                               gameObject.name == "113_16L_1_TOA" || gameObject.name == "113_16L_2_TOA" || gameObject.name == "113_16L_3_TOA" ||


                                               gameObject.name == "107_34R_1_TOA" || gameObject.name == "107_34R_2_TOA" || gameObject.name == "107_34R_3_TOA" ||
                                               gameObject.name == "107_16R_1_TOA" || gameObject.name == "107_16R_2_TOA" || gameObject.name == "107_16R_3_TOA" ||
                                               gameObject.name == "107_16L_1_TOA" || gameObject.name == "107_16L_2_TOA" || gameObject.name == "107_16L_3_TOA" ||

                                               gameObject.name == "108_34R_1_TOA" || gameObject.name == "108_34R_2_TOA" || gameObject.name == "108_34R_3_TOA" ||
                                               gameObject.name == "108_16R_1_TOA" || gameObject.name == "108_16R_2_TOA" || gameObject.name == "108_16R_3_TOA" ||
                                               gameObject.name == "108_16L_1_TOA" || gameObject.name == "108_16L_2_TOA" || gameObject.name == "108_16L_3_TOA" ||

                                               gameObject.name == "109_34R_1_TOA" || gameObject.name == "109_34R_2_TOA" || gameObject.name == "109_34R_3_TOA" ||
                                               gameObject.name == "109_16R_1_TOA" || gameObject.name == "109_16R_2_TOA" || gameObject.name == "109_16R_3_TOA" ||
                                               gameObject.name == "109_16L_1_TOA" || gameObject.name == "109_16L_2_TOA" || gameObject.name == "109_16L_3_TOA" ||

                                               gameObject.name == "101_34R_1_TOA" || gameObject.name == "101_34R_2_TOA" || gameObject.name == "101_34R_3_TOA" ||
                                               gameObject.name == "101_16R_1_TOA" || gameObject.name == "101_16R_2_TOA" || gameObject.name == "101_16R_3_TOA" ||
                                               gameObject.name == "101_16L_1_TOA" || gameObject.name == "101_16L_2_TOA" || gameObject.name == "101_16L_3_TOA" ||

                                               gameObject.name == "V1_34R_1_TOA" || gameObject.name == "V1_34R_2_TOA" || gameObject.name == "V1_34R_3_TOA" ||
                                               gameObject.name == "V1_16R_1_TOA" || gameObject.name == "V1_16R_2_TOA" || gameObject.name == "V1_16R_3_TOA" ||
                                               gameObject.name == "V1_16L_1_TOA" || gameObject.name == "V1_16L_2_TOA" || gameObject.name == "V1_16L_3_TOA"



                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            Col.gameObject.transform.GetComponentInChildren<PlaneAnimationController>().TxLightClosed(); //...Texi light off...//
            Col.gameObject.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(false); //...Texi light off...//

            Col.gameObject.transform.GetComponent<RadarScript>().dep_TakeoffApproval = true;
            UIManager.instance.Dep_Mask_Blue_On(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber);
            UIManager.instance.TakeoffApproval_AllThree(Col.gameObject.transform);

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }


        //...................Departure Last Point to Stop Plane..................................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "34R_Departure_18" || gameObject.name == "16L_Departure_21" || gameObject.name == "16R_Departure_21") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {

            GameManagerScript.instanceGMS.flightStrapsParent = UIManager.instance._Canvas.transform.GetChild(4);

            GameManagerScript.instanceGMS.MidToRightSlide(Col.gameObject.transform);

            //Col.gameObject.SetActive(false);
        }

        //.......................................................................................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_H" || gameObject.name == "54_34R_2_H" || gameObject.name == "54_34R_3_H"||
                                               gameObject.name == "54_16R_1_H" || gameObject.name == "54_16R_2_H" || gameObject.name == "54_16R_3_H" ||
                                               gameObject.name == "54_16L_1_H" || gameObject.name == "54_16L_2_H" || gameObject.name == "54_16L_3_H" ||

                                               gameObject.name == "141_34R_1_H" || gameObject.name == "141_34R_2_H" || gameObject.name == "141_34R_3_H" ||
                                               gameObject.name == "141_16R_1_H" || gameObject.name == "141_16R_2_H" || gameObject.name == "141_16R_3_H" ||
                                               gameObject.name == "141_16L_1_H" || gameObject.name == "141_16L_2_H" || gameObject.name == "141_16L_3_H" ||

                                               gameObject.name == "113_34R_1_H" || gameObject.name == "113_34R_2_H" || gameObject.name == "113_34R_3_H" ||
                                               gameObject.name == "113_16R_1_H" || gameObject.name == "113_16R_2_H" || gameObject.name == "113_16R_3_H" ||
                                               gameObject.name == "113_16L_1_H" || gameObject.name == "113_16L_2_H" || gameObject.name == "113_16L_3_H" ||

                                               gameObject.name == "107_34R_1_H" || gameObject.name == "107_34R_2_H" || gameObject.name == "107_34R_3_H" ||
                                               gameObject.name == "107_16R_1_H" || gameObject.name == "107_16R_2_H" || gameObject.name == "107_16R_3_H" ||
                                               gameObject.name == "107_16L_1_H" || gameObject.name == "107_16L_2_H" || gameObject.name == "107_16L_3_H" ||

                                               gameObject.name == "108_34R_1_H" || gameObject.name == "108_34R_2_H" || gameObject.name == "108_34R_3_H" ||
                                               gameObject.name == "108_16R_1_H" || gameObject.name == "108_16R_2_H" || gameObject.name == "108_16R_3_H" ||
                                               gameObject.name == "108_16L_1_H" || gameObject.name == "108_16L_2_H" || gameObject.name == "108_16L_3_H" ||

                                               gameObject.name == "109_34R_1_H" || gameObject.name == "109_34R_2_H" || gameObject.name == "109_34R_3_H" ||
                                               gameObject.name == "109_16R_1_H" || gameObject.name == "109_16R_2_H" || gameObject.name == "109_16R_3_H" ||
                                               gameObject.name == "109_16L_1_H" || gameObject.name == "109_16L_2_H" || gameObject.name == "109_16L_3_H" ||

                                               gameObject.name == "101_34R_1_H" || gameObject.name == "101_34R_2_H" || gameObject.name == "101_34R_3_H" ||
                                               gameObject.name == "101_16R_1_H" || gameObject.name == "101_16R_2_H" || gameObject.name == "101_16R_3_H" ||
                                               gameObject.name == "101_16L_1_H" || gameObject.name == "101_16L_2_H" || gameObject.name == "101_16L_3_H" 

                                               //gameObject.name == "V1_34R_1_H" || gameObject.name == "V1_34R_2_H" || gameObject.name == "V1_34R_3_H" ||
                                               //gameObject.name == "V1_16R_1_H" || gameObject.name == "V1_16R_2_H" || gameObject.name == "V1_16R_3_H" ||
                                               //gameObject.name == "V1_16L_1_H" || gameObject.name == "V1_16L_2_H" || gameObject.name == "V1_16L_3_H"



                                            ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().dep_isAirCraft_Hold = true;
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, true);
            UIManager.instance.HoldPosition_UIOn(Col.gameObject.transform, false);

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.transform.GetComponent <AircraftScripts>().PlaneNumber));
            //..................................................//
           
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "54_34R_1_C" || gameObject.name == "54_34R_2_C" || gameObject.name == "54_34R_3_C" ||
                                               gameObject.name == "54_16R_1_C" || gameObject.name == "54_16R_2_C" || gameObject.name == "54_16R_3_C" ||
                                               gameObject.name == "54_16L_1_C" || gameObject.name == "54_16L_2_C" || gameObject.name == "54_16L_3_C" ||

                                               gameObject.name == "141_34R_1_C" || gameObject.name == "141_34R_2_C" || gameObject.name == "141_34R_3_C" ||
                                               gameObject.name == "141_16R_1_C" || gameObject.name == "141_16R_2_C" || gameObject.name == "141_16R_3_C" ||
                                               gameObject.name == "141_16L_1_C" || gameObject.name == "141_16L_2_C" || gameObject.name == "141_16L_3_C" ||

                                               gameObject.name == "113_34R_1_C" || gameObject.name == "113_34R_2_C" || gameObject.name == "113_34R_3_C" ||
                                               gameObject.name == "113_16R_1_C" || gameObject.name == "113_16R_2_C" || gameObject.name == "113_16R_3_C" ||
                                               gameObject.name == "113_16L_1_C" || gameObject.name == "113_16L_2_C" || gameObject.name == "113_16L_3_C" ||

                                               gameObject.name == "107_34R_1_C" || gameObject.name == "107_34R_2_C" || gameObject.name == "107_34R_3_C" ||
                                               gameObject.name == "107_16R_1_C" || gameObject.name == "107_16R_2_C" || gameObject.name == "107_16R_3_C" ||
                                               gameObject.name == "107_16L_1_C" || gameObject.name == "107_16L_2_C" || gameObject.name == "107_16L_3_C" ||

                                               gameObject.name == "108_34R_1_C" || gameObject.name == "108_34R_2_C" || gameObject.name == "108_34R_3_C" ||
                                               gameObject.name == "108_16R_1_C" || gameObject.name == "108_16R_2_C" || gameObject.name == "108_16R_3_C" ||
                                               gameObject.name == "108_16L_1_C" || gameObject.name == "108_16L_2_C" || gameObject.name == "108_16L_3_C" ||

                                               gameObject.name == "109_34R_1_C" || gameObject.name == "109_34R_2_C" || gameObject.name == "109_34R_3_C" ||
                                               gameObject.name == "109_16R_1_C" || gameObject.name == "109_16R_2_C" || gameObject.name == "109_16R_3_C" ||
                                               gameObject.name == "109_16L_1_C" || gameObject.name == "109_16L_2_C" || gameObject.name == "109_16L_3_C" ||

                                               gameObject.name == "101_34R_1_C" || gameObject.name == "101_34R_2_C" || gameObject.name == "101_34R_3_C" ||
                                               gameObject.name == "101_16R_1_C" || gameObject.name == "101_16R_2_C" || gameObject.name == "101_16R_3_C" ||
                                               gameObject.name == "101_16L_1_C" || gameObject.name == "101_16L_2_C" || gameObject.name == "101_16L_3_C" 

                                               //gameObject.name == "V1_34R_1_C" || gameObject.name == "V1_34R_2_C" || gameObject.name == "V1_34R_3_C" ||
                                               //gameObject.name == "V1_16R_1_C" || gameObject.name == "V1_16R_2_C" || gameObject.name == "V1_16R_3_C" ||
                                               //gameObject.name == "V1_16L_1_C" || gameObject.name == "V1_16L_2_C" || gameObject.name == "V1_16L_3_C"

                                            ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().depIsFinalHoldContinueStopTrigger = true;

            if (GameManagerScript.instanceGMS.currentPlaneActive == Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber)
            {
                
                UIManager.instance.HoldPosnAndContinuePosUIButtonsDeactive();
            }

            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, false);

            if (Col.gameObject.transform.GetComponent<RadarScript>().depIsContinue)
            {
                UIManager.instance.StopCorotineHold();
                UIManager.instance.StopCorotineContinue();
            }

            Col.gameObject.transform.GetComponent<RadarScript>().dep_isAirCraft_Hold = false;
            Col.gameObject.transform.GetComponent<RadarScript>().dep_isAirCraft_Continue = false;
        }

        //..........Cross Runway and StandBy..............//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "144_15_3_CRY" || gameObject.name == "113_34R_1_CRY" || gameObject.name == "113_34R_2_CRY" || gameObject.name == "113_34R_3_CRY" ||
                                               gameObject.name == "141_34R_1_CRY" || gameObject.name == "141_34R_2_CRY" || gameObject.name == "141_34R_3_CRY" ||
                                               gameObject.name == "113_34R_1_CRY" || gameObject.name == "113_34R_2_CRY" || gameObject.name == "113_34R_3_CRY" ||                                               
                                               gameObject.name == "107_34R_1_CRY" || gameObject.name == "107_34R_2_CRY" || gameObject.name == "107_34R_3_CRY" ||
                                               gameObject.name == "108_34R_1_CRY" || gameObject.name == "108_34R_2_CRY" || gameObject.name == "108_34R_3_CRY" ||
                                               gameObject.name == "109_34R_1_CRY" || gameObject.name == "109_34R_2_CRY" || gameObject.name == "109_34R_3_CRY" ||
                                               gameObject.name == "101_34R_1_CRY" || gameObject.name == "101_34R_2_CRY" || gameObject.name == "101_34R_3_CRY" ||

                                               gameObject.name == "54_16R_1_CRY" || gameObject.name == "54_16R_2_CRY" || gameObject.name == "54_16R_3_CRY" ||
                                               gameObject.name == "107_16R_1_CRY" || gameObject.name == "107_16R_2_CRY" || gameObject.name == "107_16R_3_CRY" ||
                                               gameObject.name == "108_16R_1_CRY" || gameObject.name == "108_16R_2_CRY" || gameObject.name == "108_16R_3_CRY" ||
                                               gameObject.name == "109_16R_1_CRY" || gameObject.name == "109_16R_2_CRY" || gameObject.name == "109_16R_3_CRY" ||
                                               gameObject.name == "113_16R_1_CRY" || gameObject.name == "113_16R_2_CRY" || gameObject.name == "113_16R_3_CRY" ||
                                               gameObject.name == "141_16R_1_CRY" || gameObject.name == "141_16R_2_CRY" || gameObject.name == "141_16R_3_CRY" ||
                                               gameObject.name == "101_16R_1_CRY" || gameObject.name == "101_16R_2_CRY" || gameObject.name == "101_16R_3_CRY" ||
                                               gameObject.name == "V1_16R_1_CRY" || gameObject.name == "V1_16R_2_CRY" || gameObject.name == "V1_16R_3_CRY" ||

                                               gameObject.name == "107_16L_1_CRY" || gameObject.name == "107_16L_2_CRY" || gameObject.name == "107_16L_3_CRY" ||
                                               gameObject.name == "108_16L_1_CRY" || gameObject.name == "108_16L_2_CRY" || gameObject.name == "108_16L_3_CRY" ||
                                               gameObject.name == "109_16L_1_CRY" || gameObject.name == "109_16L_2_CRY" || gameObject.name == "109_16L_3_CRY" ||

                                               gameObject.name == "113_16L_1_CRY" || gameObject.name == "113_16L_2_CRY" || gameObject.name == "113_16L_3_CRY" ||
                                               gameObject.name == "141_16L_1_CRY" || gameObject.name == "141_16L_2_CRY" || gameObject.name == "141_16L_3_CRY" ||
                                               gameObject.name == "101_16L_1_CRY" || gameObject.name == "101_16L_2_CRY" || gameObject.name == "101_16L_3_CRY" ||

                                               gameObject.name == "L6_2_1_CRY" || gameObject.name == "L6_2_2_CRY" || gameObject.name == "L6_2_3_CRY" ||
                                               gameObject.name == "L6_3_1_CRY" || gameObject.name == "L6_3_2_CRY" || gameObject.name == "L6_3_3_CRY" ||
                                               gameObject.name == "L6_403_1_CRY" || gameObject.name == "L6_403_2_CRY" || gameObject.name == "L6_403_3_CRY" ||

                                               gameObject.name == "L9_2_1_CRY" || gameObject.name == "L9_2_2_CRY" || gameObject.name == "L9_2_3_CRY" ||
                                               gameObject.name == "L9_3_1_CRY" || gameObject.name == "L9_3_2_CRY" || gameObject.name == "L9_3_3_CRY" ||
                                               gameObject.name == "L9_403_1_CRY" || gameObject.name == "L9_403_2_CRY" || gameObject.name == "L9_403_3_CRY"


                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            StartCoroutine(UIManager.instance.BeforeCrossRunway(Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber));
            StartCoroutine(UIManager.instance.IMaskOnForCrossRunway(Col.gameObject.transform));
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "144_15_3_CRStop" || gameObject.name == "113_34R_1_CRStop" || gameObject.name == "113_34R_2_CRStop" || gameObject.name == "113_34R_3_CRStop" ||                                               
                                               gameObject.name == "113_16L_1_CRStop" || gameObject.name == "113_16L_2_CRStop" || gameObject.name == "113_16L_3_CRStop" ||
                                               gameObject.name == "141_16L_1_CRStop" || gameObject.name == "141_16L_2_CRStop" || gameObject.name == "141_16L_3_CRStop" ||
                                               gameObject.name == "107_34R_1_CRStop" || gameObject.name == "107_34R_2_CRStop" || gameObject.name == "107_34R_3_CRStop" ||
                                               gameObject.name == "108_34R_1_CRStop" || gameObject.name == "108_34R_2_CRStop" || gameObject.name == "108_34R_3_CRStop" ||
                                               gameObject.name == "109_34R_1_CRStop" || gameObject.name == "109_34R_2_CRStop" || gameObject.name == "109_34R_3_CRStop" ||
                                               gameObject.name == "101_34R_1_CRStop" || gameObject.name == "101_34R_2_CRStop" || gameObject.name == "101_34R_3_CRStop" ||

                                               gameObject.name == "54_16R_1_CRStop" || gameObject.name == "54_16R_2_CRStop" || gameObject.name == "54_16R_3_CRStop" ||
                                               gameObject.name == "107_16R_1_CRStop" || gameObject.name == "107_16R_2_CRStop" || gameObject.name == "107_16R_3_CRStop" ||
                                               gameObject.name == "108_16R_1_CRStop" || gameObject.name == "108_16R_2_CRStop" || gameObject.name == "108_16R_3_CRStop" ||
                                               gameObject.name == "109_16R_1_CRStop" || gameObject.name == "109_16R_2_CRStop" || gameObject.name == "109_16R_3_CRStop" ||
                                               gameObject.name == "113_16R_1_CRStop" || gameObject.name == "113_16R_2_CRStop" || gameObject.name == "113_16R_3_CRStop" ||
                                               gameObject.name == "141_16R_1_CRStop" || gameObject.name == "141_16R_2_CRStop" || gameObject.name == "141_16R_3_CRStop" ||
                                               gameObject.name == "101_16R_1_CRStop" || gameObject.name == "101_16R_2_CRStop" || gameObject.name == "101_16R_3_CRStop" ||
                                               gameObject.name == "V1_16R_1_CRStop" || gameObject.name == "V1_16R_2_CRStop" || gameObject.name == "V1_16R_3_CRStop" ||

                                               gameObject.name == "107_16L_1_CRStop" || gameObject.name == "107_16L_2_CRStop" || gameObject.name == "107_16L_3_CRStop" ||
                                               gameObject.name == "108_16L_1_CRStop" || gameObject.name == "108_16L_2_CRStop" || gameObject.name == "108_16L_3_CRStop" ||
                                               gameObject.name == "109_16L_1_CRStop" || gameObject.name == "109_16L_2_CRStop" || gameObject.name == "109_16L_3_CRStop" ||

                                               gameObject.name == "113_16L_1_CRStop" || gameObject.name == "113_16L_2_CRStop" || gameObject.name == "113_16L_3_CRStop" ||
                                               gameObject.name == "141_16L_1_CRStop" || gameObject.name == "141_16L_2_CRStop" || gameObject.name == "141_16L_3_CRStop" ||
                                               gameObject.name == "101_16L_1_CRStop" || gameObject.name == "101_16L_2_CRStop" || gameObject.name == "101_16L_3_CRStop" ||

                                               gameObject.name == "L6_2_1_CRStop" || gameObject.name == "L6_2_2_CRStop" || gameObject.name == "L6_2_3_CRStop" ||
                                               gameObject.name == "L6_3_1_CRStop" || gameObject.name == "L6_3_2_CRStop" || gameObject.name == "L6_3_3_CRStop" ||
                                               gameObject.name == "L6_403_1_CRStop" || gameObject.name == "L6_403_2_CRStop" || gameObject.name == "L6_403_3_CRStop" ||

                                               gameObject.name == "L9_2_1_CRStop" || gameObject.name == "L9_2_2_CRStop" || gameObject.name == "L9_2_3_CRStop" ||
                                               gameObject.name == "L9_3_1_CRStop" || gameObject.name == "L9_3_2_CRStop" || gameObject.name == "L9_3_3_CRStop" ||
                                               gameObject.name == "L9_403_1_CRStop" || gameObject.name == "L9_403_2_CRStop" || gameObject.name == "L9_403_3_CRStop"

                                               ) && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            if (Col.gameObject.GetComponent<AircraftScripts>().crossrunway == false)
            {
                Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
                Col.gameObject.transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;

                //UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, true);
                Col.gameObject.transform.GetComponent<RadarScript>().isAirCraft_CR_SB = true;
                UIManager.instance.Active_CR_and_SB(Col.gameObject.transform, false);

                Col.gameObject.transform.GetComponent<AircraftScripts>().recallCrossrunway = true;

                //..........Disable command when atc is open........//
                StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(Col.gameObject.GetComponent<AircraftScripts>().PlaneNumber));
                //..................................................//


            }
            Col.gameObject.GetComponent<AircraftScripts>().crossrunway = false;
        }

        //...............................................//

        //...............................spot to spot........................................................//

        if (Col.gameObject.tag == "Player" && (gameObject.name == "67_203_3_STS_H" || gameObject.name == "23_65_3_STS_H" || gameObject.name == "144_15_3_STS_H") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().sts_isAirCraft_Hold = true;
            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, true);
            UIManager.instance.STS_HoldPosition_UIOn(Col.gameObject.transform, false);
            
        }

        if (Col.gameObject.tag == "Player" && (gameObject.name == "67_203_3_STS_C" || gameObject.name == "23_65_3_STS_C" || gameObject.name == "144_15_3_STS_C") && Col.gameObject.transform.GetComponent<AircraftScripts>().AirPoint.Contains(gameObject))
        {
            Col.gameObject.transform.GetComponent<RadarScript>().stsIsFinalHoldContinueStopTrigger = true;

            if (GameManagerScript.instanceGMS.currentPlaneActive == Col.gameObject.transform.GetComponent<AircraftScripts>().PlaneNumber)
            {
                UIManager.instance.STS_HoldPosnAndContinuePosUIButtonsDeactive();
            }

            UIManager.instance.Dep_Mask_green_On(Col.gameObject.transform, false);

            if (Col.gameObject.transform.GetComponent<RadarScript>().stsIsContinue)
            {
                UIManager.instance.STS_StopCorotineHold();
                UIManager.instance.STS_StopCorotineContinue();
            }

            Col.gameObject.transform.GetComponent<RadarScript>().sts_isAirCraft_Hold = false;
            Col.gameObject.transform.GetComponent<RadarScript>().sts_isAirCraft_Continue = false;
        }


    }
    //................//


    IEnumerator CallTowingCarMove(Transform airplaneTransform)
    {
        yield return new WaitForSeconds(10f);

        airplaneTransform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        airplaneTransform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        airplaneTransform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        airplaneTransform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();

        airplaneTransform.GetComponentInChildren<PlaneAnimationController>().TxLightOpen(); //...Texi light On...//
        airplaneTransform.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(true); //...Texi light On...//

        UIManager.instance.Dep_AirplaneStatusIconHandling(airplaneTransform.GetComponent<AircraftScripts>().airPlaneStrip, 1); //......Departure AirplaneStatus......//
        //UIManager.instance.Dep_Taxi(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber);  //......Departure AirplaneStatus......//

        airplaneTransform.GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
        airplaneTransform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;

    }


    IEnumerator CallTakeoffApprovedAgain(Transform airplaneTransform)
    {
        yield return new WaitForSeconds(10f);

        airplaneTransform.GetComponent<RadarScript>().dep_TakeoffApproval = true;
        UIManager.instance.Dep_Mask_Blue_On(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber);
        UIManager.instance.TakeoffApproval_AllThree(airplaneTransform);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber));
        //..................................................//
    }

    void FadeoutGrounditem()
    {
        FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);
    }

    IEnumerator GearOpen(Transform _currentPlaneTransform)
    {
        yield return new WaitForSeconds(5);

        Soundmaster.instance.GearDown(_currentPlaneTransform.GetChild(0).GetComponent<AudioSource>());
        _currentPlaneTransform.GetComponentInChildren<PlaneAnimationController>().GearWheelBoeingOpen();
        _currentPlaneTransform.GetComponentInChildren<PlaneAnimationController>().GearWheelNoseOpen();
        //GameManagerScript.instanceGMS.PlaneList[_OpengearplaneNo].GetComponentInChildren<PlaneAnimationController>().TxLightOpen();
        _currentPlaneTransform.GetComponentInChildren<PlaneAnimationController>().LDLightOpen(); //..Landing Light On..//
        _currentPlaneTransform.GetComponentInChildren<AircraftScripts>().landingLight.SetActive(true); //..Landing Light On..//

        //Invoke("RadarCamTransitionFromAirToGround", 10f);
        StartCoroutine(RadarCamTransitionFromAirToGround(_currentPlaneTransform.GetComponent<AircraftScripts>().PlaneNumber));
    }

    IEnumerator RadarCamTransitionFromAirToGround(int _planeno)
    {
        yield return new WaitForSeconds(35);
        RadarManagerScript.instance.ChangeArrRadarCamera(_planeno); // Radar By basant
    }
    //................//
    IEnumerator BackTyreRotation(Transform _BtrTranform)
    {
        yield return new WaitForSeconds(2);
        _BtrTranform.gameObject.GetComponentInChildren<PlaneAnimationController>().SpoilerOpen();
        _BtrTranform.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        _BtrTranform.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        _BtrTranform.gameObject.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        //Invoke("EngineMain", 2f);

        _BtrTranform.gameObject.GetComponentInChildren<PlaneAnimationController>().EngineStart();
    }
    //void EngineMain()
    //{
    //    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.planeno].GetComponentInChildren<PlaneAnimationController>().EngineStart();
    //}
    //.................//

    void CloseOtherThings(Transform _planeTransform)
    {
        Soundmaster.instance.FlapDown(_planeTransform.GetChild(0).GetComponent<AudioSource>());
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().SpoilerClosed();
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().FlapClosed();
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().SlatClosed();

        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().StLightStop();
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().LDLightClosed(); //..Landing Light Off..//
        _planeTransform.gameObject.GetComponentInChildren<AircraftScripts>().landingLight.SetActive(false); //..Landing Light Off..//
    }
    //.................//


    IEnumerator FrontWheelstraightLeft(Transform _planeTransform)
    {
        yield return new WaitForSeconds(4f);
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeftReset(animSpeed);
    }
    IEnumerator FrontWheelstraightRight(Transform _planeTransform)
    {
        yield return new WaitForSeconds(4f);
        _planeTransform.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRightReset(animSpeed);
    }

    IEnumerator RollAnimation1(Transform animObj)
    {
        yield return new WaitForSeconds(turningRotationAnimTime);
        GameManagerScript.instanceGMS.RollAnimation(0, turningRotationAnimTime, animObj);
    }

    IEnumerator YawAnimation1(Transform animObj)
    {
        yield return new WaitForSeconds(turningRotationAnimTime);
        GameManagerScript.instanceGMS.YawAnimation(0, turningRotationAnimTime, animObj);
    }

    IEnumerator PitchAnimation1(Transform animObj)
    {
        yield return new WaitForSeconds(turningRotationAnimTime);
        GameManagerScript.instanceGMS.PitchAnimation(0, turningRotationAnimTime, animObj);
    }

    IEnumerator YawPitchAnimationReset(Transform animObj, float animTime)
    {
        yield return new WaitForSeconds(animTime);
        //print("YawAnimation1........");
        GameManagerScript.instanceGMS.PitchYawAnimation(0, animTime, animObj);
    }

   
    public void ShakingAirplaneCondition(Transform animObj)
    {
        //print("ShakingAirplaneCondition..............");
        RadarManagerScript.instance.CheckWindDir();
        if (RadarManagerScript.instance.posWindDir)
        {
            GameManagerScript.instanceGMS.PitchYawAnimation(turningRotForHeadWind, turningRotationAnimTime, animObj);
            StartCoroutine(YawPitchAnimationReset(animObj, turningRotationAnimTime));
        }
        else if (RadarManagerScript.instance.negWindDir)
        {
            GameManagerScript.instanceGMS.PitchYawAnimation(-turningRotForHeadWind, turningRotationAnimTime, animObj);
            StartCoroutine(YawPitchAnimationReset(animObj, turningRotationAnimTime));
        }

        if (!RadarManagerScript.instance.posWindDir && !RadarManagerScript.instance.negWindDir)
        {
            GameManagerScript.instanceGMS.PitchAnimation(turningRotationAngle, turningRotationAnimTime, animObj);
            StartCoroutine(PitchAnimation1(animObj));
        }


    }


    IEnumerator SetCameraMinimumValue(float value, float rotationValue)
    {
        yield return new WaitForSeconds(1f);

        //cameraOrbit.transform.parent = PlaneList[0].transform;
        AnimateTransformFunctions.ins.AnimateTransform(CameraMovement.instanceCam.transform, CameraMovement.instanceCam.transform.eulerAngles, Vector3.zero, 5f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.World, "Linear");
        yield return new WaitForSeconds(value);
        CameraMovement.instanceCam.minRotation = rotationValue;

        //print("CameraMovement.instanceCam.minRotation- "+ CameraMovement.instanceCam.minRotation);
       // print("rotationValue- " + rotationValue);

    }
}
