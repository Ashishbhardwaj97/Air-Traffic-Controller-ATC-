using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftScripts : MonoBehaviour
{
    public Transform airoplaneSpawnPoint;
    public string airoplaneSpawnTime;
    public string airoplaneCategoryType;
    public string flightNumber;
    public string originAirportName;
    public string destinitionAirportName;

    //...............................//
    public string spotNameStart, spotNumberStart;
    public string spotNameEnd, spotNumberEnd;

    public GameObject spotCommand, spotHighlighter;

    public GameObject pathPoint34R, pathPoint16R, pathPoint16L;

    public GameObject pathHighlighterObj;
    //............................//

    public enum towingCarType { None, Normal, Flat };
    [SerializeField]
    public towingCarType towingCar;

    public enum accomodationLadderType { Normal, VIP };
    [SerializeField]
    public accomodationLadderType accomodationLadder;

    public GameObject contrail;

    // If in parking spot: Objects+position to spawn vehicles if airplane is parked
    //If stop on runway(EMG plane) : Objects+position to spawn vehicles if emergency plane stops there
    //If in open spot: objects+position to spawn vehicles if parked in open spot

    public Texture airoplaneTexture;

    public enum airoplaneSizeType { Tiny, Small, Medium, Big };
    [SerializeField]
    public airoplaneSizeType airoplaneSize;

    public enum airoplaneEMGEventType { Normal, OutOfFuel, SickPerson, SmokeFromEngine, TakeOffCancel, EmeregencyDeparture, RadioTrouble };
    [SerializeField]
    public airoplaneEMGEventType airoplaneEMGEvent;

    public enum parkingCategoryType { Terminal1, InternationalTerminal, CargoArea };
    [SerializeField]
    public parkingCategoryType parkingCategory;

    public float flySpeedValue;
    public float driveSpeed;

    //Takeoff distance fixer(Property to change after what distance the plane goes in the air (in takeoff))
    //Takeoff pattern variation seed (A property to make takeoff animations look different)

    public enum flySpeedType { SlowPlane, MidPlane, FastPlane };
    [SerializeField]
    public flySpeedType flySpeed;

    public AudioClip engineSound;

    public enum cabinAnnouncementSoundType { Default, Extra };
    [SerializeField]
    public cabinAnnouncementSoundType cabinAnnouncementSound;

    //In air collision box size
    //On ground collision box size

    public AudioClip pilotOffice;
    public GameObject FxSmokeFromEngine;
    public GameObject FxSmokeFromTires;
    public GameObject FxContrail;
    public GameObject FxHeathaze;

    public bool AircraftOnGround;
    int TargetNo = 0;
    public List<GameObject> AirPoint;
    public float PlaneSpeed;
    public float RotationPlaneSpeed;
    public GameObject boardingBridge, groundVehicles, pushBackTowingCar;
    public GameObject texiLight, landingLight;
    //.................................................//

    //public static AircraftScripts instanceAS;

    public List<string> RunwaySelected;
    public int PlaneNumber;
    //public int dep_pno;

    //.................................................//
    //public List<GameObject> targetPBB;
    public Transform PushBackMain;
    public Transform Dep_startlight;
    public Transform airPlaneStrip;

    public bool pushbackone, pusshbacktwo, pusshbackthird;
    public bool AfterPuchBackSpeedUp, TakeoffSpeedUp, AfterHoldPressSpeedDown;
    public bool isPushbackComplete;

    //public string taxipathway_C8C9L6L9;
    public int taxipathway_C8C9L6L9;
    public int pathspot2_3_403;
    public bool restart_standby, restart_standbyAgain;

    public bool goandfly, ReCallTakeoffApproval;
    public bool holdshort, linewait;

    public bool arv_selectroute, arv_selectrouteABC;

    public bool arv_TowerCHandoff;

    public bool crossrunway, recallCrossrunway;

    public bool dep_DepCtrlHandOffClick;
    public bool dep_RadarCtrlClick;
    public string _otherFlightNo;           //Ashish


    public GameObject planePictogram;


    //......By basant........//
    //public string airserveNo;
    //public string currentSpot;
    //public string endSpot;

    //public AudioClip airserveAudioClip;
    //public AudioClip currentSpotClip;
    //public AudioClip endSpotClip;
    //.....................//

    public Animator _ladderAnim;

    void Awake()
    {
        //instanceAS = this;
    }
    void OnEnable()
    {
        if (PushBackMain != null)
        {
            PushBackMain.gameObject.SetActive(true);
        }

        isPushbackComplete = false;
    }
    void Start()
    {
        // pushBackTowingCar.GetComponent<Animator>().SetInteger("PushMove", 1);  //.....only for Spot to Spot..//
        if (planePictogram != null)
        {
            planePictogram.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = flightNumber;
        }


        crossrunway = false;
        recallCrossrunway = false;

        restart_standbyAgain = false;
        restart_standby = false;
        goandfly = false;
        holdshort = false;
        linewait = false;
        ReCallTakeoffApproval = false;

        arv_selectroute = false;
        arv_selectrouteABC = false;

        //if (boardingBridge != null)
        //{

        //}
        //LadderInAnim();

    }

    void Update()
    {
        if (AirPoint.Count > 0)
        {
            PlaneMovementOnPath();
        }

        //......................divyansh................//
        if (SaveAndLoad.aircraftStatus == 1)
        {
            if (planePictogram != null)
            {
                planePictogram.SetActive(true);
                for (int i = 0; i < airPlaneStrip.transform.GetChild(1).childCount; i++)
                {
                    if (airPlaneStrip.transform.GetChild(1).GetChild(i).gameObject.activeInHierarchy)
                    {
                        planePictogram.transform.GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
                    }
                }

            }
        }
        if (SaveAndLoad.aircraftStatus == 2)
        {
            if (planePictogram != null && CameraSwitch.ins.activeCam != CameraSwitch.ins.Cam_View[0])
            {
                planePictogram.SetActive(false);
            }

        }

        if (SaveAndLoad.aircraftStatus == 2 && CameraSwitch.ins.activeCam == CameraSwitch.ins.Cam_View[0])
        {
            if (planePictogram != null)
            {
                planePictogram.SetActive(true);
                for (int i = 0; i < airPlaneStrip.transform.GetChild(1).childCount; i++)
                {
                    if (airPlaneStrip.transform.GetChild(1).GetChild(i).gameObject.activeInHierarchy)
                    {
                        planePictogram.transform.GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
                    }
                }
            }
        }
        if (UIManager.instance.arv_runwayselection_birdeyeview || UIManager.instance.dep_runwayselection_birdeyeview || UIManager.instance.sts_spotselection_birdeyeview)
        {
            if (planePictogram != null)
            {
                planePictogram.SetActive(false);
            }
        }

        //.............................................................//
    }

    //.........Ladder In/Out Animations.........//
    public void LadderInAnim(GameObject obj)
    {
        _ladderAnim = obj.GetComponentInChildren<Animator>();
        //print("LadderInAnim........." + _ladderAnim);
        if (_ladderAnim != null)
            _ladderAnim.SetInteger("LadderVal", 1);
    }

    public void LadderOutAnim(GameObject obj)
    {
        _ladderAnim = obj.GetComponentInChildren<Animator>();
        //print("LadderOutAnim........." + _ladderAnim);
        if (_ladderAnim != null)
            _ladderAnim.SetInteger("LadderVal", 2);
    }
    //.........................................//

    public void ChangeWindowShader()
    {

        Material[] mats = transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().materials;
        if (EmissionOnOFF.instance.isDay)
        {
            mats[5] = EmissionOnOFF.instance.planeShadeMatDay;
        }
        else
        {
            mats[5] = EmissionOnOFF.instance.planeShadeMatNight;

        }
        transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().materials = mats;

    }

    void PlaneMovementOnPath()
    {
        //....... for plane move towards point ........       
        GameObject TargetChange = AirPoint[TargetNo];
        this.transform.position = Vector3.MoveTowards(this.transform.position, TargetChange.transform.position, Time.deltaTime * PlaneSpeed); //... plane speed

        //....... for plane Rotation towards point ........

        Vector3 targetDir = TargetChange.transform.position - this.transform.position;
        Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, 0.1f, 0.0f);
        var tt = Quaternion.LookRotation(newDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, tt, Time.deltaTime * RotationPlaneSpeed); // 1.7f);  //... plane movement speed

        //print("this.transform-> "+ this.transform.localEulerAngles);

        //if (pushBackTowingCar != null)
        //{
        //    pushBackTowingCar.transform.eulerAngles = transform.eulerAngles;   // Quaternion.Slerp(transform.rotation, tt, Time.deltaTime * RotationPlaneSpeed); //...........new
        //}
        //...........     
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (TargetNo < (AirPoint.Count - 1) && AirPoint.Contains(Col.gameObject))  //.....List Contain Gameobject ....... 
        {
            TargetNo = TargetNo + 1;
        }

        if (Col.gameObject.tag == "GameOverCollider")
        {
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().PlaneSpeed = 0;
            PlaneSpeed = 0;
            ScoreManager.instance.headOnGameOver = true;
            ScoreManager.instance.StartGameOverCoroutine();
            StartCoroutine(GameOverCameraSwitch());
        }

        if (Col.gameObject.tag == "GameOverWarning")
        {
            _otherFlightNo = Col.gameObject.transform.GetComponentInParent<AircraftScripts>().flightNumber;
            string a = "Near miss alert for ## and @@";
            TipsAndAlertController.instance.OnAlert(a, flightNumber, _otherFlightNo);
        }

        if (Col.gameObject.tag == "NearMissWarning")
        {
            _otherFlightNo = Col.gameObject.transform.GetComponentInParent<AircraftScripts>().flightNumber;
            string a = "Near miss alert for ## and @@";
            TipsAndAlertController.instance.OnAlert(a, flightNumber, _otherFlightNo);
            airPlaneStrip.GetChild(4).gameObject.SetActive(true);
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().airPlaneStrip.GetChild(4).gameObject.SetActive(true);

            airPlaneStrip.GetChild(4).GetChild(1).gameObject.SetActive(true);
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().airPlaneStrip.GetChild(4).GetChild(1).gameObject.SetActive(true);
        }

        if (Col.gameObject.tag == "NearMissCollider")
        {
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().PlaneSpeed = 0;
            PlaneSpeed = 0;
            ScoreManager.instance.nearMissGameOver = true;
            ScoreManager.instance.StartGameOverCoroutine();
            StartCoroutine(GameOverCameraSwitch());
        }

        //.........By ashish.............//

        if (Col.gameObject.tag == "Spot2" || Col.gameObject.tag == "Spot3" || Col.gameObject.tag == "Spot403")
        {
            Achievements.instance.parkingCounter++;
        }

        //......................//
    }

    public void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "NearMissWarning")
        {
            airPlaneStrip.GetChild(4).gameObject.SetActive(false);
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().airPlaneStrip.GetChild(4).gameObject.SetActive(false);

            airPlaneStrip.GetChild(4).GetChild(1).gameObject.SetActive(false);
            Col.gameObject.transform.GetComponentInParent<AircraftScripts>().airPlaneStrip.GetChild(4).GetChild(1).gameObject.SetActive(false);
        }
    }



    public void BBOutDeparturePlane()
    {
        StartCoroutine(BBOutDeparturePlaneCoroutine());
        //Invoke("DepartureAndStandByCall", 30f);
    }

    IEnumerator BBOutDeparturePlaneCoroutine()
    {

        yield return new WaitForSeconds(20f);
        if (boardingBridge.CompareTag("BoardingBridgeAnim"))
        {
            boardingBridge.transform.GetChild(0).GetComponent<PbbScript>().BBOut(); //..Bording Bridge remove from plane...Departure 1 plane.
        }
        else if (boardingBridge.CompareTag("LadderAnim"))
        {
            LadderOutAnim(boardingBridge);
        }

        TowingCarFadeInFadeOut(true);
        yield return new WaitForSeconds(30f);

        transform.GetComponent<RadarScript>().dep_isAirCraft_DA_SB = true;
        UIManager.instance.Active_DA_and_SB(transform, false);
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);


        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//

    }

    public void TowingCarFadeInFadeOut(bool isFadeIn)
    {
        FadeInFadeOut.instance.towingCarMats = pushBackTowingCar.GetComponentInChildren<SkinnedMeshRenderer>().materials;

        if (isFadeIn)
        {
            FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.towingCarMats);
        }
        else
        {
            FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.towingCarMats);
            StartCoroutine(pushBackTowingCarOff());
        }
    }
    IEnumerator pushBackTowingCarOff() //....PushBack False...//
    {
        yield return new WaitForSeconds(4f);
        pushBackTowingCar.SetActive(false);
        BowandshakeFadeIn();
        yield return new WaitForSeconds(74f);
        BowandshakeFadeout();
    }


    //public void GroundVehiclesFadeIn()
    //{
    //    FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
    //    FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
    //}

    //public void GroundVehiclesFadeOut()
    //{
    //    FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
    //    FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);
    //    Invoke("GroundItemVechicles_Off", 8f);
    //}
    //void GroundItemVechicles_Off()
    //{
    //    groundVehicles.SetActive(false);
    //}

    //..................................//

    //............................Ground Vehicles Fadein and fadeout................................................//


    public void GroundVehiclesFadeIn()
    {
        StartCoroutine("CoroutineGroundVehiclesFadeIn");
    }

    IEnumerator CoroutineGroundVehiclesFadeIn()
    {
        if (groundVehicles.transform.childCount > 0)
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
            FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
            yield return new WaitForSeconds(1f);
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
            FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
            yield return new WaitForSeconds(1f);
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(1).GetChild(1).GetComponent<SkinnedMeshRenderer>().materials;
        }
        else
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
        }

        FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
    }


    public void GroundVehiclesFadeOut()
    {
        StartCoroutine("CoroutineGroundVehiclesFadeOut");
    }

    IEnumerator CoroutineGroundVehiclesFadeOut()
    {
        if (groundVehicles.transform.childCount > 0)
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
            FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);
            yield return new WaitForSeconds(1f);
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(0).GetComponent<MeshRenderer>().materials;
            FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);
            yield return new WaitForSeconds(1f);
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(1).GetChild(1).GetComponent<SkinnedMeshRenderer>().materials;
        }
        else
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
        }


        FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);
        //Invoke("GroundItemVechicles_Off", 8f);
    }

    void GroundItemVechicles_Off()
    {
        groundVehicles.SetActive(false);
    }

    //..............//

    public void BowandshakeFadeIn()
    {
        if (groundVehicles.transform.childCount > 0)
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(2).GetChild(0).GetComponent<SkinnedMeshRenderer>().materials;
        }
        else
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
        }

        FadeInFadeOut.instance.FadeIn(FadeInFadeOut.instance.groundVehicleMats);
    }

    public void BowandshakeFadeout()
    {
        if (groundVehicles.transform.childCount > 0)
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.transform.GetChild(2).GetChild(0).GetComponent<SkinnedMeshRenderer>().materials;
        }
        else
        {
            FadeInFadeOut.instance.groundVehicleMats = groundVehicles.GetComponentInChildren<MeshRenderer>().materials;
        }
        FadeInFadeOut.instance.FadeOut(FadeInFadeOut.instance.groundVehicleMats);

        Invoke("GroundItemVechicles_Off", 8f);

    }
    
    //..............................
    public void ReCall_DA_and_SB() //.......ReCall Departure Approval and Stand By Option.....
    {
        StartCoroutine(ReCall_DA_and_SB_Coroutine());
    }

    IEnumerator ReCall_DA_and_SB_Coroutine()
    {
        yield return new WaitForSeconds(32f);
        transform.GetComponent<RadarScript>().dep_isAirCraft_DA_SB = true;
        UIManager.instance.Active_DA_and_SB(transform, false);
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//
        
    }

    public IEnumerator Runwaycall_BirdEyeview()
    {
        yield return new WaitForSeconds(80f);
        UIManager.instance.Dep_AirplaneStatusIconHandling(airPlaneStrip, 7); //......Departure AirplaneStatus......//
        
        transform.GetComponent<RadarScript>().dep_isAirCraftIRunway = true;
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
        
        UIManager.instance.Runwaycall_BirdEyeview(transform, false);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//

        //.........runway status i.e. safe, unsafe or danger.......//
        UIManager.instance.currentLevelSelected.CheckLandingStatusForArrivalAricraft();

        UIManager.instance.currentLevelSelected.TailWindForRedColor();
        //.........................................................//

    }

    public IEnumerator PushBackCalltoMove()
    {
        yield return new WaitForSeconds(30f);
        pushbackone = true;
        StartCoroutine(PushBackBackOne());
        if (transform.GetComponent<RadarScript>().isDeparture)
        {
            StartCoroutine(LobbySounds.ins.PushBackLobby(PlaneNumber));
        }
        transform.GetComponentInChildren<PlaneAnimationController>().LightStart();
        transform.GetComponentInChildren<PlaneAnimationController>().TyreNBackwordStartRotate();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB1Start();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB2Start();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateBackwordTyreB3Start();
        Dep_startlight.gameObject.SetActive(true);

        transform.GetComponentInChildren<PlaneAnimationController>().StLightStop(); //...ST light Off...//
        transform.GetChild(0).GetChild(3).gameObject.SetActive(false); //...ST light mesh Off...//
    }

    public void CleartotaxiWay()
    {


        UIManager.instance.dep_cleartotaxi_standby.SetActive(false);

        //Invoke("pushbackOff", 30f);
        StartCoroutine(pushbackOff());

        transform.GetComponentInChildren<PlaneAnimationController>().TxLightOpen(); //...Texi light On...//
        transform.GetComponentInChildren<AircraftScripts>().texiLight.SetActive(true); //...Texi light On...//

        groundVehicles.transform.GetChild(2).gameObject.SetActive(true);  //...Bow and Shake gameobject true....//

        transform.GetComponent<FX>().Heat_Haze = true;
        TowingCarFadeInFadeOut(false);
    }

    IEnumerator pushbackOff() //.....Towing car remove and speedup for taxing...
    {
        yield return new WaitForSeconds(30f);
        pushBackTowingCar.SetActive(false);
        transform.GetComponentInChildren<PlaneAnimationController>().LeftEngineRotationStart();
        transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();

        StartCoroutine(SpeedupAfterPuchback());
        yield return new WaitForSeconds(3f);
        transform.GetComponentInChildren<PlaneAnimationController>().RightEngineRotationStart();

    }
    public void Recall_CT_and_SB()
    {
        StartCoroutine(Recall_CT_and_SBCoroutine());
    }


    IEnumerator Recall_CT_and_SBCoroutine()
    {
        yield return new WaitForSeconds(40f);
        transform.GetComponent<RadarScript>().dep_isAirCraft_CT_SB = true;
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);

        UIManager.instance.Select_Dep_Cleartotaxiway_standby(transform, false);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//
    }

    public IEnumerator SpeedupAfterPuchback()
    {

        yield return new WaitForSeconds(10f);
        AfterPuchBackSpeedUp = true;

        while (AfterPuchBackSpeedUp == true)
        {
            yield return null;
            if (PlaneSpeed >= 0f)
            {
                PlaneSpeed = PlaneSpeed + 0.0001f;
                RotationPlaneSpeed = 1f;
            }
            if (PlaneSpeed >= 0.05f)
            {
                //RotationPlaneSpeed = 1f;
                AfterPuchBackSpeedUp = false;

                transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
            }
        }

    }

    public IEnumerator TowerControlHand_Off_AutoClosed()  //....Auto close TowerControlHand_Off Buton.....//
    {
        yield return new WaitForSeconds(10f);
        //UIManager.instance.Dep_Mask_All_Off(PlaneNumber);
        UIManager.instance.Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[PlaneNumber].transform, false);
        UIManager.instance.towercontrol_handoff.SetActive(false);

        transform.GetComponent<RadarScript>().dep_TowerControlHand_Off = false;
        //...Penalty Add...//

        StartCoroutine(UIManager.instance.TokyoTwrCtrlHandOff(PlaneNumber, 0));

        NintendoController.instance.NpadButtonB2();  // divyansh
    }



    //........TakeoffApproved.............//

    public IEnumerator TakeoffApprovedSpeed(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        TakeoffSpeedUp = true;
        //pushbackone = true;
        while (TakeoffSpeedUp == true)
        {
            yield return null;
            if (transform.GetComponent<AircraftScripts>().PlaneSpeed >= 0f)
            {
                transform.GetComponent<AircraftScripts>().PlaneSpeed = (transform.GetComponent<AircraftScripts>().PlaneSpeed) + 0.003f;
            }
            if (transform.GetComponent<AircraftScripts>().PlaneSpeed >= 2.2f)
            {
                transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;// 0.8f;
                TakeoffSpeedUp = false;
                goandfly = false;
                Invoke("Runingstart", 1f);
            }
        }
    }

    //................//

    void Runingstart()
    {
        transform.GetComponentInChildren<PlaneAnimationController>().FlapOpen();
        transform.GetComponentInChildren<PlaneAnimationController>().SlatOpen();
        Invoke("RuningAir", 5f);
    }
    void RuningAir()
    {
        transform.GetComponentInChildren<PlaneAnimationController>().FlapClosed();
        transform.GetComponentInChildren<PlaneAnimationController>().SlatClosed();
    }
    //................//

    public IEnumerator SpeedDownHoldButton() //.....Speed Reduce Hold Button Clicked...//
    {
        yield return new WaitForSeconds(0f);
        AfterHoldPressSpeedDown = true;

        while (AfterHoldPressSpeedDown == true)
        {
            yield return null;

            if (PlaneSpeed >= 0f)
            {
                PlaneSpeed = PlaneSpeed - 0.0001f;
            }
            if (PlaneSpeed <= 0f)
            {
                RotationPlaneSpeed = 0f;
                PlaneSpeed = 0f;


                transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStopRotate();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Stop();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Stop();
                transform.GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Stop();

                AfterHoldPressSpeedDown = false;
            }
        }
    }

    //....................PushBack Movement.......//

    public IEnumerator PushBackBackOne()
    {
        pushbackone = true;
        while (pushbackone == true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, PushBackMain.GetChild(0).transform.position, Time.deltaTime * 0.025f);
        }
    }
    public IEnumerator PushBackBackTwo()
    {

        pushbackone = false;
        pusshbacktwo = true;
        while (pusshbacktwo == true)
        {
            yield return null;
            transform.rotation = Quaternion.Slerp(transform.rotation, PushBackMain.GetChild(1).transform.rotation, Time.deltaTime * 0.09f);
            transform.position = Vector3.MoveTowards(transform.position, PushBackMain.GetChild(1).transform.position, Time.deltaTime * 0.025f);
        }
    }
    public IEnumerator PushBackBackThree()
    {

        pusshbacktwo = false;
        pusshbackthird = true;
        while (pusshbackthird == true)
        {
            yield return null;

            transform.position = Vector3.MoveTowards(transform.position, PushBackMain.GetChild(2).transform.position, Time.deltaTime * 0.015f);
            transform.rotation = Quaternion.Slerp(transform.rotation, PushBackMain.GetChild(2).transform.rotation, Time.deltaTime * 0.12f);
        }
    }

    //.................................................//


    //..............For Spot To Spot ..................//

    public void BBOutSpotToSpotPlane()
    {
        StartCoroutine(BBOutSpotToSpotPlaneCoroutine());
    }

    IEnumerator BBOutSpotToSpotPlaneCoroutine()
    {

        yield return new WaitForSeconds(20f);
        boardingBridge.transform.GetChild(0).GetComponent<PbbScript>().BBOut(); //..Bording Bridge remove from plane..//
        TowingCarFadeInFadeOut(true);
        yield return new WaitForSeconds(30f);


        transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB = true;
        UIManager.instance.Active_STS_and_SB(transform, false);
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//


        //if (PlaneNumber == 5)
        //{           
        //    transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB_203 = true;
        //    UIManager.instance.Active_STS_and_SB_203(transform, false);
        //    UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
        //}

        //if (PlaneNumber == 6)
        //{            
        //    transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB_65 = true;
        //    UIManager.instance.Active_STS_and_SB_65(transform, false);
        //    UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
        //}

        //if (PlaneNumber == 7)
        //{           
        //    transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB_15 = true;
        //    UIManager.instance.Active_STS_and_SB_15(transform, false);
        //    UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
        //}
        //UIManager.instance.Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[PlaneNumber].transform, true);
        //UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
    }
    public void Recall_STS_SB()
    {
        StartCoroutine(Recall_STS_to_SB());
    }

    public IEnumerator Recall_STS_to_SB()
    {
        yield return new WaitForSeconds(34f);
        transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB = true;
        UIManager.instance.Active_STS_and_SB(transform, false);
        UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(PlaneNumber));
        //..................................................//
    }
    //public void Recall_STS_SB_65()
    //{
    //    StartCoroutine(Recall_STS_to_SB_65());
    //}

    //public IEnumerator Recall_STS_to_SB_65()
    //{
    //    yield return new WaitForSeconds(20f);
    //    transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB_65 = true;
    //    UIManager.instance.Active_STS_and_SB_65(transform, false);
    //    UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
    //}
    //public void Recall_STS_SB_15()
    //{
    //    StartCoroutine(Recall_STS_to_SB_15());
    //}

    //public IEnumerator Recall_STS_to_SB_15()
    //{
    //    yield return new WaitForSeconds(20f);
    //    transform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB_15 = true;
    //    UIManager.instance.Active_STS_and_SB_15(transform, false);
    //    UIManager.instance.Dep_Mask_Blue_On(PlaneNumber);
    //}


    //..........By divyansh...for Towing Car Rotation and tyre reset...//

    public void StopLeftRotationCoroutine(float animSpeed)
    {
        StartCoroutine(StopLeftRotation(animSpeed));

    }

    public void StopRightRotationCoroutine(float animSpeed)
    {
        StartCoroutine(StopRightRotation(animSpeed));

    }

    IEnumerator StopLeftRotation(float animSpeed)
    {
        print("RotationLeft");
        if (transform.GetComponent<RadarScript>().isSpottoSpot)
        {
            if (transform.GetComponent<AircraftScripts>().pushBackTowingCar.activeInHierarchy)
            {
                print("RotationLeft1111111111111");
                transform.GetComponent<AircraftScripts>().pushBackTowingCar.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).transform);
            }
        }

        yield return new WaitForSeconds(9f); //.....After 5 sec tyre reset...//
        transform.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateLeftReset(animSpeed); //..Left..tyre reset...//

        //if (this.gameObject.GetComponent<RadarScript>().isSpottoSpot)
        //{
        //    if (this.gameObject.GetComponent<AircraftScripts>().pushBackTowingCar.activeInHierarchy)
        //    {
        //        this.gameObject.GetComponent<AircraftScripts>().pushBackTowingCar.transform.SetParent(this.gameObject.transform.GetChild(0).transform);
        //    }
        //}

    }

    IEnumerator StopRightRotation(float animSpeed)
    {
        print("RotationRight");
        if (transform.GetComponent<RadarScript>().isSpottoSpot)
        {
            if (transform.GetComponent<AircraftScripts>().pushBackTowingCar.activeInHierarchy)
            {
                print("RotationRight111111111111111");
                transform.GetComponent<AircraftScripts>().pushBackTowingCar.transform.SetParent(transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).transform);
            }
        }

        yield return new WaitForSeconds(9f); //.....After 5 sec tyre reset...//
        this.gameObject.GetComponentInChildren<PlaneAnimationController>().GearNoseRotateRightReset(animSpeed); //..Right..tyre reset...//

        //if (this.gameObject.GetComponent<RadarScript>().isSpottoSpot)
        //{
        //    if (this.gameObject.GetComponent<AircraftScripts>().pushBackTowingCar.activeInHierarchy)
        //    {
        //        this.gameObject.GetComponent<AircraftScripts>().pushBackTowingCar.transform.SetParent(this.gameObject.transform.GetChild(0).transform);
        //    }
        //}

    }

    IEnumerator GameOverCameraSwitch()
    {

       
        GameManagerScript.instanceGMS.cameraOrbit.transform.parent = null;
        GameManagerScript.instanceGMS.cameraOrbit.transform.parent = transform;
        float distance = Vector3.Distance(GameManagerScript.instanceGMS.cameraOrbit.transform.localPosition, Vector3.zero);
       
        if (CameraSwitch.ins.CamCount > 0)
        {
            if (CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].gameObject.name == "PASSENGER WINDOW VIEW")
            {
                CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].gameObject.SetActive(false);
                //CameraSwitch.ins.PassengerWindowViewCameraSwitchig();
            }
        }
        AnimateTransformFunctions.ins.AnimateTransform(GameManagerScript.instanceGMS.cameraOrbit.transform, GameManagerScript.instanceGMS.cameraOrbit.transform.localPosition, Vector3.zero, 2, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
        yield return new WaitForSeconds(0.1f);
        AnimateTransformFunctions.ins.AnimateTransform(GameManagerScript.instanceGMS.cameraOrbit.transform, GameManagerScript.instanceGMS.cameraOrbit.transform.localEulerAngles, new Vector3(0, GameManagerScript.instanceGMS.cameraOrbit.transform.localEulerAngles.y, GameManagerScript.instanceGMS.cameraOrbit.transform.localEulerAngles.z), 1f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
        yield return new WaitForSeconds(0.1f);
        // cameraOrbit.transform.LookAt(PlaneList[planeno].transform);
        AnimateTransformFunctions.ins.AnimateTransform(GameManagerScript.instanceGMS.cameraOrbit.transform, GameManagerScript.instanceGMS.cameraOrbit.transform.localEulerAngles, Vector3.zero, 1f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
        // SetMinRotationOfOrbitCamera(planeno);


        //....................................................................//
    }
}
