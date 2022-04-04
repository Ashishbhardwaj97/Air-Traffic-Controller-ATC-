using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instanceGMS;
    public GameObject LevelPlaneList;

    public GameObject AllPath;
    public List<GameObject> PlaneList;
    public List<GameObject> PlaneStrip;
    public List<string> Planetime;
    public GameObject cameraOrbit;

    public List<GameObject> GroundItems;    
    public int planeno = 0;

    public bool SpeedReduce, TakeoffSpeedUp, autoConnect, DetourwaySelected;
    public List<GameObject> targetPBB;
    public bool CleartoLandingOk;
    public bool autoselectrunway;

    public bool AfterHoldPressSpeedDown, AfterPuchBackSpeedUp;
    public int currentPlaneActive;
    public int currentDepPlaneNo;
    public GameObject Dep_startlight1;

    public Transform[] boardingBridges;
    public Transform[] GroundVechiclesItems;
    public int planeNumberForATCBarUIScript;

    public GameObject bg_Building;
    public int planeCountForEachLevel;
    public int tipsCounter;
    public string firstFlightNum;           //....Divyansh.......//

    //...........By basant..........//
    public string preAtcContainer;
    public string currentAtcContainer;
    public GameObject[] commandList;

    public bool _onceCamReset;  
    public int levelnumber;
    public int PlaneActivate;

    public AudioSource backGroundSound;

    void Awake()
    {
        instanceGMS = this;
    }
    void Start()
    {
        SFXSound.ins.SFX.clip = SFXSound.ins.levelStarts;         //Ashish
        SFXSound.ins.SFX.Play();
        //......Level Wise planeCount For EachLevel ....//
        _onceCamReset = false;
        levelnumber = SaveAndLoad.level;
        PlaneActivate = 0;
      
        //.....................................//

        //........for Level plane assign.......//

        PlaneList.Clear();
        RadarManagerScript.instance.PlaneListRadar.Clear();
        foreach (Transform child in LevelPlaneList.transform.GetChild(levelnumber - 1).GetChild(0))
        {
            if (child.tag == "Player")
            {
                PlaneList.Add(child.gameObject);
                RadarManagerScript.instance.PlaneListRadar.Add(child.gameObject);
            }
        }
        PlaneStrip.Clear();
        foreach (Transform child in LevelPlaneList.transform.GetChild(levelnumber - 1).GetChild(0))
        {
            if (child.tag == "Player")
            {
                PlaneStrip.Add(child.gameObject.GetComponent<AircraftScripts>().airPlaneStrip.gameObject);
            }
        }
        foreach (Transform child in LevelPlaneList.transform.GetChild(levelnumber - 1).GetChild(0))
        {
            if (child.tag == "Player")
            {
                Planetime.Add(child.gameObject.GetComponent<AircraftScripts>().airoplaneSpawnTime);
            }
        }
        //...... Arrival and Departure strip move to Canvas ........//

        for (int i = 3; i < 5; i++)
        {
            LevelPlaneList.transform.GetChild(levelnumber - 1).GetChild(1).GetChild(0).transform.parent = UIManager.instance._Canvas.transform.GetChild(i);
        }
        //..........................................................//
        
        Dep_startlight1.SetActive(false);
        autoselectrunway = false;
        autoConnect = false;
        CleartoLandingOk = false;
        DetourwaySelected = false;

        //......................//

        StartCoroutine(Firstflight());

        //........Assign flight no to respective plane strip........//

        for (int i = 0; i < PlaneList.Count; i++)
        {
            PlaneStrip[i].transform.GetChild(6).GetComponent<Text>().text = PlaneList[i].GetComponent<AircraftScripts>().flightNumber;
        }
        highlightedCmdGameObj = new List<GameObject>();
        cameraOrbit.transform.parent = PlaneList[0].transform;
        planeCountForEachLevel = PlaneList.Count;

        //...........Sound initialise.............//
        for (int i = 0; i < PlaneList.Count; i++)
        {
            PlaneList[i].GetComponent<AudioSource>().volume = SaveAndLoad.atcVol;
        }
        backGroundSound.volume = SaveAndLoad.backVol;

        SFXSound.ins.SFX.volume = SaveAndLoad.ingameVol;
        SFXSound.ins.SFX2.volume = SaveAndLoad.ingameVol;
        //........................................//
    }

    //.............Divyansh...........//
    public IEnumerator Firstflight()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < PlaneList.Count; i++)
        {
            if (PlaneList[i].activeInHierarchy)
            {
                firstFlightNum = PlaneList[i].GetComponent<AircraftScripts>().flightNumber;
            }
        }
    }
    //................................//

    //.........By basant.........//
    void StartPlaneGeneration(int _startPlaneNo)
    {
        UIManager.instance.References(_startPlaneNo, UIManager.instance.aPRSound);

        if (PlaneList[_startPlaneNo].GetComponent<RadarScript>().isGoAround)
        {
            UIManager.instance.APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalApproachCtrlHandOffTokyo(UIManager.instance.planeNoArr, UIManager.instance._altStr);
            UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.ArrivalApproachCtrlHandOffTokyoAudio(UIManager.instance.currentFlightNoClip, UIManager.instance._altClip, UIManager.instance._thousandClip, UIManager.instance.aPRSound);
        }
        else
        {
            int randomNo = UnityEngine.Random.Range(0, UIManager.instance.arvPilotSounds.Count);
            PlaneList[_startPlaneNo].GetComponent<RadarScript>().pilotSound = UIManager.instance.arvPilotSounds[randomNo];

            PlaneList[_startPlaneNo].GetComponent<RadarScript>().currentATC = "APR";

            if (PlaneList[_startPlaneNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal || PlaneList[_startPlaneNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine )
            {
                UIManager.instance.APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalApproach(UIManager.instance.planeNoArr, UIManager.instance._altA, UIManager.instance._altB, UIManager.instance._atisCode);
                UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.ArrivalApproachAudio(UIManager.instance.currentFlightNoClip, UIManager.instance._altA1Clip, UIManager.instance._altA2Clip, UIManager.instance._thousandClip, UIManager.instance._altB1Clip, UIManager.instance._altB2Clip, UIManager.instance._thousandClip, UIManager.instance._atisCodeClip, UIManager.instance.aPRSound);
            }
            else
            {
                if (PlaneList[_startPlaneNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.OutOfFuel)
                {
                    UIManager.instance.APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.FirstLineWhenAirplaneComesIn(UIManager.instance.planeNoArr);
                    UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.FirstLineWhenAirplaneComesInAudio(UIManager.instance.currentFlightNoClip, UIManager.instance.aPRSound);
                }
                else if (PlaneList[_startPlaneNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SickPerson)
                {
                    UIManager.instance.APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerComesIn(UIManager.instance.planeNoArr);
                    UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.SickPassengerComesInAudio(UIManager.instance.currentFlightNoClip, UIManager.instance.aPRSound);
                }
                else if (PlaneList[_startPlaneNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.RadioTrouble)
                {
                    UIManager.instance.APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RadioTroubleStart(UIManager.instance.planeNoArr);
                    UIManager.instance.audioClipsPlaneArr = CommandReceiver.instance.RadioTroubleStartAudio(UIManager.instance.currentFlightNoClip, UIManager.instance.aPRSound);
                }

                StartCoroutine(EmergencyComandOn(_startPlaneNo));
                StartCoroutine(AutoCloseEmergency(_startPlaneNo));
            }
        }
        UIManager.instance.APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        PlaneList[_startPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = UIManager.instance.audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(PlaneList[_startPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, PlaneList[_startPlaneNo].GetComponent<AudioSource>());
        SetPilotStripAnimation(_startPlaneNo);

        //..........Disable command when atc is open........//
        StartCoroutine(DisableAtcCommandOnTriggerEnter(_startPlaneNo));
        //..................................................//
    }

    public IEnumerator EmergencyComandOn(int _planeNo)
    {
        yield return new WaitForSeconds(18);
        PlaneList[_planeNo].GetComponent<RadarScript>().arv_isAirCraftEmg = true;
        UIManager.instance.Arv_Mask_Green_On(PlaneList[_planeNo].transform, true);

        UIManager.instance.Arv_EmergencySelection(_planeNo);
        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_planeNo));
        //..................................................//
    }
    public IEnumerator AutoCloseEmergency(int emgPlaneNo)
    {
        yield return new WaitForSeconds(30);
        UIManager.instance.Arv_EmergencyNotSelected(emgPlaneNo);
    }

    void Update()
    {
        if (SpeedReduce)
        {
            AircraftSpeed(decreasedSpeedPlaneNo);
        }

        PlaneGeneration();
    }
    public void PlaneGeneration()
    {
        if (PlaneActivate < Planetime.Count)
        {
            if (ScoreManager.instance.timer >= (ScoreManager.instance.initialTimeInSeconds + (int.Parse(Planetime[PlaneActivate]) * 60)))
            {
                if (PlaneList[PlaneActivate].GetComponent<RadarScript>().isArrival)
                {
                    PlaneList[PlaneActivate].SetActive(true);
                    PlaneStrip[PlaneActivate].SetActive(true);

                    PlaneList[PlaneActivate].GetComponent<AircraftScripts>().PlaneSpeed = 2.2f;
                    PlaneList[PlaneActivate].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;

                    flightStrapsParent = UIManager.instance._Canvas.transform.GetChild(3);
                    StartCoroutine(LeftToMidSlide(PlaneStrip[PlaneActivate].transform));

                    if (_onceCamReset == false)
                    {
                        StartCoroutine(FirstplanesAutoselectionEachLevel(PlaneActivate)); //.....Auto Information Get....//
                        SetMinRotationOfOrbitCamera(PlaneActivate);

                        AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localPosition, Vector3.zero, 4f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
                        AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localEulerAngles, Vector3.zero, 4f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");

                        _onceCamReset = true;
                    }
                    int arvPlaneNo = PlaneList[PlaneActivate].GetComponent<AircraftScripts>().PlaneNumber;
                    Gamestart(PlaneActivate);

                    //......basant......//
                    StartPlaneGeneration(PlaneActivate);
                    //..................//  

                    PlaneActivate = PlaneActivate + 1;
                }
                else if (PlaneList[PlaneActivate].GetComponent<RadarScript>().isDeparture || PlaneList[PlaneActivate].GetComponent<RadarScript>().isSpottoSpot)
                {
                    PlaneList[PlaneActivate].SetActive(true);
                    ActiveDepPlane1(PlaneActivate);

                    if (_onceCamReset == false)
                    {
                        StartCoroutine(FirstplanesAutoselectionEachLevel(PlaneActivate)); //.....Auto Information Get....//
                        SetMinRotationOfOrbitCamera(PlaneActivate);

                        AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localPosition, Vector3.zero, 4f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
                        AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localEulerAngles, Vector3.zero, 4f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");

                        _onceCamReset = true;
                    }
                    PlaneStrip[PlaneActivate].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = PlaneList[PlaneActivate].GetComponent<AircraftScripts>().spotNameStart;    // "SPOT";
                    PlaneStrip[PlaneActivate].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = PlaneList[PlaneActivate].GetComponent<AircraftScripts>().spotNumberStart;  //" 54";                

                    //.........basant.........//
                    PlaneList[PlaneActivate].GetComponent<RadarScript>().towardsTerminal.SetActive(true);
                    //.......................//

                    PlaneActivate = PlaneActivate + 1;
                }
            }
        }
    }

    public IEnumerator FirstplanesAutoselectionEachLevel(int airplaneNumber)
    {
        yield return new WaitForSeconds(13);
        AeroplaneHit(airplaneNumber);
        RadarManagerScript.instance.ClickPlane(airplaneNumber);
        RadarManagerScript.instance.ChangeArrRadarCamera(airplaneNumber);
    }
    public void Arv_GroundItemVechicles_Off()
    {
        for (int i = 0; i < GroundItems.Count; i++)
        {
            GroundItems[i].SetActive(false);
        }
    }
    //...................................................................................................................//

    public void Gamestart(int _planeNo)
    {
        //............By basant.........//
        if (PlaneList[_planeNo].GetComponent<RadarScript>().isGoAround)
        {
            StartPlaneGeneration(_planeNo);
        }
        //..............................//

        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().GearWheelNoseClosed();
        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().GearWheelBoeingClosed();
        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().LeftEngineRotationStart();
        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().LightStart();
        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().StLightStart();

        SpeedReduce = false;
        foreach (Transform child in AllPath.transform.GetChild(0))
        {
            PlaneList[_planeNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
        }
        StartCoroutine(RightEngineRotationStartforPlane(_planeNo));
    }

    IEnumerator RightEngineRotationStartforPlane(int _planeNo)
    {
        yield return new WaitForSeconds(3);
        PlaneList[_planeNo].GetComponentInChildren<PlaneAnimationController>().RightEngineRotationStart();
    }
    //..........Active plane And There Strips..............//

    void ActiveDepPlane1(int depNo)
    {
        if (PlaneList[depNo].transform.GetComponent<AircraftScripts>().boardingBridge.CompareTag("BoardingBridgeAnim"))
        {
            PlaneList[depNo].transform.GetComponent<AircraftScripts>().boardingBridge.transform.GetChild(0).GetComponent<PbbScript>().BBIn(); //..Bording Bridge towards plane...Departure 1 plane.
        }
        else if (PlaneList[depNo].transform.GetComponent<AircraftScripts>().boardingBridge.CompareTag("LadderAnim"))
        {
            //print("LadderInAnim.....strt");
            PlaneList[depNo].transform.GetComponent<AircraftScripts>().LadderInAnim(PlaneList[depNo].transform.GetComponent<AircraftScripts>().boardingBridge);
        }


        PlaneList[depNo].transform.GetComponent<AircraftScripts>().groundVehicles.SetActive(true);
        PlaneList[depNo].transform.GetComponent<AircraftScripts>().GroundVehiclesFadeIn();        
        StartCoroutine(ActiveDepPlane1Strip(depNo));
    }
    IEnumerator ActiveDepPlane1Strip(int depNo)
    {
        StartCoroutine(LobbySounds.ins.BeforeBoardingBridge(depNo));
        yield return new WaitForSeconds(12f);
        PlaneStrip[depNo].SetActive(true);  //...Departure Plane 1 strip active.

        flightStrapsParent = UIManager.instance._Canvas.transform.GetChild(4);
        StartCoroutine(LeftToMidSlide(PlaneStrip[depNo].transform));        

        int randomNo = UnityEngine.Random.Range(0, UIManager.instance.depPilotSounds.Count);
        PlaneList[depNo].GetComponent<RadarScript>().pilotSound = UIManager.instance.depPilotSounds[randomNo];

        if (PlaneList[depNo].GetComponent<RadarScript>().isDeparture)
        {
            PlaneList[depNo].transform.GetComponent<AircraftScripts>().BBOutDeparturePlane();

            //.......By basant..........//
            if (PlaneList[depNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                UIManager.instance.References(depNo, UIManager.instance.cLRSound);
                UIManager.instance.CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureOnGround(UIManager.instance.planeNo);
                UIManager.instance.audioClipsPlaneDep = CommandReceiver.instance.DepartureOnGroundAudio(UIManager.instance.planeNoClipDep, UIManager.instance.cLRSound);

                SetPilotStripAnimation(depNo);
                UIManager.instance.CLR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
            }
            else
            {
                if (PlaneList[depNo].transform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.EmeregencyDeparture)
                {
                    //UIManager.instance.References(depNo, UIManager.instance.tWRSound);
                    UIManager.instance.TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EmergencyCallForRescueEvents();
                    UIManager.instance.audioClipsPlaneDep = CommandReceiver.instance.EmergencyCallForRescueEventsAudio(UIManager.instance.tWRSound);
                    SetATCStripAnimation(depNo, UIManager.instance.TWR);

                    StartCoroutine(EmergencyDepAgain(depNo));
                    UIManager.instance.TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
                }
            }
        }
        else if (PlaneList[depNo].GetComponent<RadarScript>().isSpottoSpot)
        {
            PlaneList[depNo].transform.GetComponent<AircraftScripts>().BBOutSpotToSpotPlane();

            //........By Basant..........//
            UIManager.instance.References(depNo, UIManager.instance.gNDSound);
            UIManager.instance.GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SpotChangeAircraft(UIManager.instance._airserveNo, UIManager.instance._currentSpot, UIManager.instance._endSpot);

            preAtcContainer = "GND";
            UIManager.instance.audioClipsPlaneDep = CommandReceiver.instance.SpotChangeAircraftAudio(UIManager.instance._airserveClip, UIManager.instance._currentSpotClip, UIManager.instance._endSpotClip, UIManager.instance.gNDSound);

            SetPilotStripAnimation(depNo);
            UIManager.instance.GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
            //......................................//
        }

        UIManager.instance.audioSourcePlaneDep = PlaneList[depNo].GetComponent<AudioSource>();
        PlaneList[depNo].GetComponent<RadarScript>().currentAirCraftAudioClips = UIManager.instance.audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(PlaneList[depNo].GetComponent<RadarScript>().currentAirCraftAudioClips, UIManager.instance.audioSourcePlaneDep);
    }

    IEnumerator EmergencyDepAgain(int _planeNo)
    {
        yield return new WaitForSeconds(20);

        GameObject _pilotSound = PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        UIManager.instance.TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EmergencyCallForRescueEventsPilot();

        UIManager.instance.audioClipsPlaneDep = CommandReceiver.instance.EmergencyCallForRescueEventsPilotAudio(_pilotSound);
        SetPilotStripAnimation(_planeNo);
        StartCoroutine(EmergencyDepAgainAgain(_planeNo));
    }

    IEnumerator EmergencyDepAgainAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);

        UIManager.instance.GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EmergencyCallForRescueEventAgain();
        UIManager.instance.audioClipsPlaneDep = CommandReceiver.instance.EmergencyCallForRescueEventAgainAudio(UIManager.instance.gNDSound);
        SetPilotStripAnimation(_planeNo);

        UIManager.instance.GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = UIManager.instance.audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, UIManager.instance.audioSourcePlaneDep);
    }

    //..................................Arrival........................................//

    public void DetourWay()
    {
        foreach (Transform child in AllPath.transform.GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);      // changed           
            }
        }
        RadarManagerScript.instance.AddDetourWay(PlaneList, currentPlaneActive);//Radar system path highlight
        RadarManagerScript.instance.SelectDetour(PlaneList, currentPlaneActive);

        Arrival34R_34LAirRoutes(currentPlaneActive);
        DetourwaySelected = true;   //.....working
    }
    public void Arrival34R_34LAirRoutes(int _planeNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(3))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_planeNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    //.......Circle way selected...........//

    public void CircleWay(int _planeNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_planeNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        Arrival34R_34LAirRoutes(_planeNo);

        //..............//
        RadarManagerScript.instance.AddCircleWay(PlaneList, _planeNo); //Radar system path highlight
        //.............//
    }
    //......................................//

    //..........Clear to Landing.......................//

    public void ClearToLanding()
    {
        if (PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34R") 
        {
            Runway34R();           
        }
        else if (PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34L")
        {
            Runway34L();          
        }
        RadarManagerScript.instance.AddClearToLanding(PlaneList, currentPlaneActive);//Radar system path highlight
    }
    //.............Arrival Runway 34R,34L Path Add .....................//

    public void Runway34R()
    {
        foreach (Transform child in AllPath.transform.GetChild(4).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Runway34L()
    {
        foreach (Transform child in AllPath.transform.GetChild(4).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    //..........................................................//

    public void GoAround34R_34L(int _GoaroundplaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(5).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_GoaroundplaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        RadarManagerScript.instance.AddGoAround34R_34L(PlaneList, _GoaroundplaneNo);//Radar system path highlight        
    }

    //...........................................//
    //...................................................................................................................//
    //.................Default Starting point..........................//

    public void SelectedAircraftHighlight(int _planeNo)
    {
        for (int i = 0; i < PlaneStrip.Count; i++)
        {
            PlaneStrip[i].transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
        }
        PlaneStrip[_planeNo].transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
    }

    public void AeroplaneHit(int AirplaneNo)
    {
        currentPlaneActive = AirplaneNo;
        currentDepPlaneNo = AirplaneNo;
        SelectedAircraftHighlight(AirplaneNo);

        ClickOnAircraftStrip(AirplaneNo);
        ClickOnDepAircraftStrip(AirplaneNo);
        ClickOnSTS_AircraftStrip(AirplaneNo);

        StartCoroutine(AeroplaneHitCoroutine(AirplaneNo));        
    }

    float animatePositionSpeed;

    IEnumerator AeroplaneHitCoroutine(int AirplaneNo)
    {
        if (AirplaneNo != planeno)
        {
            planeno = AirplaneNo;
            cameraOrbit.transform.parent = null;
            cameraOrbit.transform.parent = PlaneList[planeno].transform;
            float distance = Vector3.Distance(cameraOrbit.transform.localPosition, Vector3.zero);
            if (distance >= 300)
            {
                animatePositionSpeed = 4f;
            }
            else
            {
                animatePositionSpeed = 2f;
            }
            if (CameraSwitch.ins.CamCount > 0)
            {
                if (CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].gameObject.name == "PASSENGER WINDOW VIEW")
                {
                    CameraSwitch.ins.PassengerWindowViewCameraSwitchig();
                }
            }
            AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localPosition, Vector3.zero, animatePositionSpeed, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
            yield return new WaitForSeconds(animatePositionSpeed + 0.1f - 2);
            AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localEulerAngles, new Vector3(0, cameraOrbit.transform.localEulerAngles.y, cameraOrbit.transform.localEulerAngles.z), 1f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
            yield return new WaitForSeconds(animatePositionSpeed + 0.1f - 2);
            // cameraOrbit.transform.LookAt(PlaneList[planeno].transform);
            AnimateTransformFunctions.ins.AnimateTransform(cameraOrbit.transform, cameraOrbit.transform.localEulerAngles, Vector3.zero, 1f, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
            SetMinRotationOfOrbitCamera(planeno);
        }
    }

    public void SetMinRotationOfOrbitCamera(int planeNo)
    {
        if (PlaneList[planeNo].transform.GetComponent<AircraftScripts>().AircraftOnGround)
        {
            CameraMovement.instanceCam.minRotation = 0;
            bg_Building.SetActive(true);
            if (DayAndNight.instance.isRain)
            {
                EmissionOnOFF.instance.godRay.SetActive(false);
            }
            else
            {
                if (DayAndNight.instance.isSunRays)
                {
                    EmissionOnOFF.instance.godRay.SetActive(true);
                }
            }
        }
        else
        {
            CameraMovement.instanceCam.minRotation = -40;
            bg_Building.SetActive(false);
            EmissionOnOFF.instance.godRay.SetActive(false);
        }
    }

    //........................Path Add In palne........................//
    //..........Arrival Plane............//

    #region Taxiway C8 C9
    //.................Taxiway...C8 & C9...............

    public void C8_C9_Path(int _TaxiwayPlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(6).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_TaxiwayPlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[_TaxiwayPlaneNo].GetComponent<RadarScript>().isAirCraftC8_C9 = true;
        UIManager.instance.Arv_TaxiRouteC8_C9_Call(_TaxiwayPlaneNo);  //...enable taxiroute c8 and c9...//  
    }
    public void C8_Path(int _C8PlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(6).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_C8PlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        autoConnect = true;
    }
    public void C9_Path(int _C9PlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(6).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_C9PlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        autoConnect = true;
    }
    #endregion

    #region Taxiway L6 L9
    //.................Taxiway...L & L9...............

    public void L6_L9_Path(int _TaxiwayPlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(7).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_TaxiwayPlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[_TaxiwayPlaneNo].GetComponent<RadarScript>().isAirCraftL6_L9 = true;
        UIManager.instance.Arv_TaxiRouteL6_L9_Call(_TaxiwayPlaneNo);  //...enable taxiroute c8 and c9...//  
    }
    public void L6_Path(int _L9PlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(7).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_L9PlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        autoConnect = true;
    }
    public void L9_Path(int _L9PlaneNo)
    {
        foreach (Transform child in AllPath.transform.GetChild(7).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[_L9PlaneNo].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        autoConnect = true;
    }
    #endregion

    #region Terminal1_C8_Spot2_3Way
    //..........Terminal 1- Spot 2 (3 Ways..)....................

    public void C8_2_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //........
    public void C8_2_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C8_2_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    #endregion

    #region Terminal1_C8_Spot3_3Way
    //...........Terminal 1- Spot 3 (3 Ways..).................................

    public void C8_3_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(1).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //........
    public void C8_3_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(1).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C8_3_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(0).GetChild(1).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    #endregion

    #region Terminal1_C8_Spot403_3Way
    //...........Terminal 1- Spot 3 (3 Ways..).................................

    public void C8_403_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(4).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //........
    public void C8_403_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(4).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C8_403_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(8).GetChild(4).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    #endregion

    #region Terminal1_C9_Spot2_3Way
    //..........Terminal 1- Spot 2 (3 Ways..)....................

    public void C9_2_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //........
    public void C9_2_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C9_2_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    #endregion

    #region Terminal1_C9_Spot3_3Way
    //...........Terminal 1- Spot 3 (3 Ways..).................................

    public void C9_3_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(1).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //........
    public void C9_3_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(1).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C9_3_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(0).GetChild(1).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();

            }
        }
    }
    #endregion

    #region Terminal1_C9_Spot403_3Way
    //...........Terminal 1- Spot 3 (3 Ways..).................................

    public void C9_403_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(4).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                // CloseAllUI();
            }
        }
    }
    //........
    public void C9_403_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(4).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    //.......
    public void C9_403_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(9).GetChild(4).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                //CloseAllUI();
            }
        }
    }
    #endregion

    //........Departure plane...........//

    #region Towards34R-Terminal2_54_34R

    public void Dep54_34R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(1).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {               
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_34R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(1).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_34R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(1).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards16R-Terminal2_54_16R

    public void Dep54_16R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(1).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_16R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(1).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_16R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(1).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards16L-Terminal2_54_16L

    public void Dep54_16L_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(1).GetChild(0).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_16L_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(1).GetChild(0).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep54_16L_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(1).GetChild(0).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion


    #region Towards34R-InternationalTerminal_141_34R

    public void Dep141_34R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(6).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_34R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(6).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_34R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(6).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards34R-InternationalTerminal_141_16R

    public void Dep141_16R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(6).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_16R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(6).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_16R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(6).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards34R-InternationalTerminal_141_16L

    public void Dep141_16L_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(6).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_16L_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(6).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep141_16L_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(6).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards34R-InternationalTerminal_113_34R

    public void Dep113_34R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(5).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_34R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(5).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_34R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(12).GetChild(2).GetChild(5).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards34R-InternationalTerminal_113_16R

    public void Dep113_16R_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(5).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_16R_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(5).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_16R_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(13).GetChild(2).GetChild(5).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion

    #region Towards34R-InternationalTerminal_113_16L

    public void Dep113_16L_Path1()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(5).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_16L_Path2()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(5).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    public void Dep113_16L_Path3()
    {
        foreach (Transform child in AllPath.transform.GetChild(14).GetChild(2).GetChild(5).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
    }
    #endregion


    #region Departure AirRoute 34R,16R,16L

    public void Dep34R_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(15))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();       
        UIManager.instance.dep_runwayselected = 0;
    }

    public void Dep16L_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(16))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }          
        }        
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        UIManager.instance.dep_runwayselected = 0;
    }
    public void Dep16R_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(17))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        UIManager.instance.dep_runwayselected = 0;
    }

    #endregion

    #region Departure Emergency AirRoute 34R,16R,16L

    public void DepEmg34R_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(19).GetChild(0))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        UIManager.instance.dep_runwayselected = 0;
    }

    public void DepEmg16L_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(19).GetChild(2))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        UIManager.instance.dep_runwayselected = 0;
    }
    public void DepEmg16R_Air()
    {
        foreach (Transform child in AllPath.transform.GetChild(19).GetChild(1))
        {
            if (child.tag == "CirclePoint")
            {
                PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
            }
        }
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        PlaneList[currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        UIManager.instance.dep_runwayselected = 0;
    }

    #endregion

    //........................................//
    //........Spot To Spot plane...........//

    #region Towards ALL Path Point Spot

    public void StsALL_Path()
    {
        if (PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().spotNumberStart == "67")
        {
            foreach (Transform child in AllPath.transform.GetChild(18).GetChild(0).GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
        }
        else if (PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().spotNumberStart == "23")
        {
            foreach (Transform child in AllPath.transform.GetChild(18).GetChild(2).GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
        }
        else if (PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().spotNumberStart == "144")
        {
            foreach (Transform child in AllPath.transform.GetChild(18).GetChild(4).GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    PlaneList[currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
        }
    }

    #endregion

    //.............not in work.......//

    //.........................................//
    //..................Speed of Aircraft.............................//

    int decreasedSpeedPlaneNo;

    public void AircraftSpeed(int _ASSPlaneNO)
    {
        SpeedReduce = true;
        decreasedSpeedPlaneNo = _ASSPlaneNO;
        if (PlaneList[_ASSPlaneNO].GetComponent<AircraftScripts>().PlaneSpeed >= 0.05f)
        {
            PlaneList[_ASSPlaneNO].GetComponent<AircraftScripts>().PlaneSpeed = (PlaneList[_ASSPlaneNO].GetComponent<AircraftScripts>().PlaneSpeed) - 0.23f * Time.deltaTime;
        }
        if (PlaneList[_ASSPlaneNO].GetComponent<AircraftScripts>().PlaneSpeed <= 0.05f)
        {
            PlaneList[_ASSPlaneNO].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
            SpeedReduce = false;
        }
    }

    public void RollAnimation(float rotationAngle, float rotationAnimTime, Transform animObj)
    {
        AnimateTransformFunctions.ins.AnimateTransform(animObj.transform.GetChild(0), new Vector3(0f, 0f, animObj.transform.GetChild(0).localEulerAngles.z), new Vector3(0f, 0f, rotationAngle), rotationAnimTime, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
    }
    public void YawAnimation(float rotationAngle, float rotationAnimTime, Transform animObj)
    {
        AnimateTransformFunctions.ins.AnimateTransform(animObj.transform.GetChild(0), new Vector3(0f, animObj.transform.GetChild(0).localEulerAngles.y, 0f), new Vector3(0f, rotationAngle, 0f), rotationAnimTime, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
    }
    public void PitchAnimation(float rotationAngle, float rotationAnimTime, Transform animObj)
    {
        AnimateTransformFunctions.ins.AnimateTransform(animObj.transform.GetChild(0), new Vector3(animObj.transform.GetChild(0).localEulerAngles.x, 0f, 0f), new Vector3(rotationAngle, 0f, 0f), rotationAnimTime, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
    }

    public void PitchYawAnimation(float rotationAngle, float rotationAnimTime, Transform animObj)
    {
        if (RadarManagerScript.instance.posWindDir)
            AnimateTransformFunctions.ins.AnimateTransform(animObj.transform.GetChild(0), new Vector3(animObj.transform.GetChild(0).localEulerAngles.x, animObj.transform.GetChild(0).localEulerAngles.y, 0), new Vector3(-rotationAngle, rotationAngle, 0), rotationAnimTime, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
        else if (RadarManagerScript.instance.negWindDir)
            AnimateTransformFunctions.ins.AnimateTransform(animObj.transform.GetChild(0), new Vector3(animObj.transform.GetChild(0).localEulerAngles.x, animObj.transform.GetChild(0).localEulerAngles.y, 0), new Vector3(rotationAngle, rotationAngle, 0), rotationAnimTime, AnimateTransformFunctions.TransformTypes.Rotation, AnimateTransformFunctions.AnimAxis.Local, "EaseInEaseOut");
    }
    //..................Recall All Function for I mask................................//

    public void ClickOnAircraftStrip(int _planeNo)
    {
        UIManager.instance.Arv_DetourSelection();   // detour for all plane
        UIManager.instance.Arv_TowerControlHand_Off_Call(_planeNo);
        UIManager.instance.Arv_CleartoLanding_GoAround();
        UIManager.instance.Arv_TaxiRouteC8_C9_Call(_planeNo);
        UIManager.instance.Arv_TaxiRouteL6_L9_Call(_planeNo);
        UIManager.instance.Arv_ApproachControlHand_Off_Call(_planeNo);
        UIManager.instance.Arv_DepartureControlHand_Off_Call(_planeNo);

        StartCoroutine(UIManager.instance.Slow_SpeedControl(_planeNo, 0));
        StartCoroutine(UIManager.instance.Medium_SpeedControl(_planeNo, 0));
        StartCoroutine(UIManager.instance.Fast_SpeedControl(_planeNo, 0));

        
        UIManager.instance.Arv_RunwaySelection(PlaneList[_planeNo].transform, true);  // runway selection for all plane
        UIManager.instance.Arv_Spot2_3_Call(PlaneList[_planeNo].transform, true);
        UIManager.instance.Arv_ParkingLine_ABC_Call(_planeNo);
        UIManager.instance.Arv_EmergencySelection(_planeNo);
    }

    public void ClickOnDepAircraftStrip(int _planeNo)
    {
        UIManager.instance.Active_DA_and_SB(PlaneList[_planeNo].transform, true);
        UIManager.instance.Runwaycall_BirdEyeview(PlaneList[_planeNo].transform, true);
        UIManager.instance.Select_Dep_Cleartotaxiway_standby(PlaneList[_planeNo].transform, true);

        if (PlaneList[_planeNo].transform.GetComponent<RadarScript>().dep_isAirCraft_Hold)
        {
            UIManager.instance.HoldPosition_UIOn(PlaneList[_planeNo].transform, true);
        }
        else
        {
            StartCoroutine(UIManager.instance.ContinueTaxi_UIOn(PlaneList[_planeNo].transform, 0, true));
        }

        if (PlaneList[_planeNo].transform.GetComponent<RadarScript>().arv_IsAirCraft_Hold)
        {
            UIManager.instance.Arv_HoldPosition_Call(PlaneList[_planeNo].transform, true);
        }
        else
        {
            StartCoroutine(UIManager.instance.ArvContinueTaxi_UIOn(PlaneList[_planeNo].transform, 0, true));
        }

        UIManager.instance.TowerControlHand_Off_Call(PlaneList[_planeNo].transform);
        UIManager.instance.DepartureHandOff_Call(PlaneList[_planeNo].transform);
        UIManager.instance.ContinueOwnNav_Call(PlaneList[_planeNo].transform);
        UIManager.instance.RadarControlOff_Call(PlaneList[_planeNo].transform);
        UIManager.instance.TakeoffApproval_AllThree(PlaneList[_planeNo].transform);

        StartCoroutine(UIManager.instance.TakeoffApprovalOnlyOneButton(PlaneList[_planeNo].transform, 0));
    }

    public void ClickOnSTS_AircraftStrip(int _planeNo)
    {
        UIManager.instance.Active_STS_and_SB(PlaneList[_planeNo].transform, true);

        if (PlaneList[_planeNo].transform.GetComponent<RadarScript>().sts_isAirCraft_Hold)
        {
            UIManager.instance.STS_HoldPosition_UIOn(PlaneList[_planeNo].transform, true);
        }
        else
        {
            StartCoroutine(UIManager.instance.STS_ContinueTaxi_UIOn(PlaneList[_planeNo].transform, 0, true));
        }
        UIManager.instance.Active_CR_and_SB(PlaneList[_planeNo].transform, true);
    }

    //.............................................................................//
    //..................................................//

    #region Set ATC And Pilot Animation

    public void SetPilotStripAnimation(int _atcPplaneNo)
    {
        StartCoroutine(WaitTimeForAudioClips(_atcPplaneNo));
    }
    IEnumerator WaitTimeForAudioClips(int _planeNo)
    {
        yield return new WaitForSeconds(.2f);

        if (PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips.Count != 0)
        {
            PlaneStrip[_planeNo].transform.GetChild(0).GetComponent<Animator>().SetBool("isATC_Radio", true);
            for (int i = 0; i < PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips.Count; i++)
            {
                yield return new WaitForSeconds(PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips[i].length);
            }
            PlaneStrip[_planeNo].transform.GetChild(0).GetComponent<Animator>().SetBool("isATC_Radio", false);
        }
    }
    public void SetATCStripAnimation(int _planeNo, Transform ATCBar)
    {
        StartCoroutine(WaitTimeForAudioclip(_planeNo, ATCBar));
    }

    IEnumerator WaitTimeForAudioclip(int _planeNo, Transform ATCBar)
    {
        yield return new WaitForSeconds(.2f);
        if (PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips.Count != 0)
        {
            ATCBar.GetComponent<Animator>().SetBool("isATC", true);
            for (int i = 0; i < PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips.Count; i++)
            {
                yield return new WaitForSeconds(PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips[i].length);
            }
            yield return new WaitForSeconds(2f);
            ATCBar.GetComponent<Animator>().SetBool("isATC", false);
        }
    }
    //...........................ATC depart plane icon..............
    public void SetRunwaySignal(int _planeNo)
    {
        for (int i = 0; i < PlaneStrip.Count; i++)
        {
            PlaneStrip[i].transform.GetChild(0).GetChild(3).gameObject.GetComponent<Image>().color = new Color32(0, 207, 255, 255);
        }
        PlaneStrip[_planeNo].transform.GetChild(0).GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 162, 0, 255);
    }
    #endregion

    // For Flight Strap UpSideDown
    public Transform flightStrapsParent;
    public List<Transform> flightStraps;
    //-10.3 , -7 , -3.7 , -0.4 ,2.9 ,6.2

    public void AddingStrapsTOAminateUpSideDown(float animTime)
    {
        flightStraps.Clear();
        for (int i = 0; i < flightStrapsParent.GetChild(0).childCount; i++)
        {
            if (flightStrapsParent.GetChild(0).GetChild(i).gameObject.activeInHierarchy)
            {
                flightStraps.Add(flightStrapsParent.GetChild(0).GetChild(i));
            }
        }
        if (flightStraps.Count != 0)
        {
            for (int j = 0; j < flightStraps.Count; j++)
            {
                if (j == 0)
                {
                    DownSlideStrap(flightStraps[j], -10.3f, animTime);
                }
                if (j == 1)
                {
                    DownSlideStrap(flightStraps[j], -7f, animTime);
                }
                if (j == 2)
                {
                    DownSlideStrap(flightStraps[j], -3.7f, animTime);
                }
                if (j == 3)
                {
                    DownSlideStrap(flightStraps[j], -0.4f, animTime);
                }
                if (j == 4)
                {
                    DownSlideStrap(flightStraps[j], 2.9f, animTime);
                }
                if (j == 5)
                {
                    DownSlideStrap(flightStraps[j], 6.2f, animTime);
                }
                if (j == 6)
                {
                    DownSlideStrap(flightStraps[j], 9.5f, animTime);
                }

                //if (j == 7)
                //{
                //    DownSlideStrap(flightStraps[j], 12.8f, animTime);
                //}
            }
        }  
    }

    //40 for MidToRightslide
    //-35 For LeftToMid

    public IEnumerator LeftToMidSlide(Transform animObj)
    {
        float xPosition;
        if (animObj.GetChild(0).GetChild(2).GetComponent<Image>().color == UIManager.instance.GND.GetComponent<ATCBarUIScript>().controlBarColor)
        {
            xPosition = -1.85f;
        }
        else
        {
            xPosition = -3.3f;
        }
        //..................//
        if (FlightStripMgr.instance.dep == 1)
        {
            FlightStripMgr.instance.CheckDEPFlight();
        }
        if (FlightStripMgr.instance.arr == 1)
        {
            FlightStripMgr.instance.CheckARRFlight();
        }
        //........................//
        AnimateTransformFunctions.ins.AnimateTransform(animObj, new Vector3(-35f, 9.5f, animObj.localPosition.z), new Vector3(xPosition, 9.5f, animObj.localPosition.z),                //...2.9
            2f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "Linear");
        yield return new WaitForSeconds(2.2f);
        AddingStrapsTOAminateUpSideDown(2);
    }
    public void DownSlideStrap(Transform animObj, float animeValue, float animTime)
    {
        AnimateTransformFunctions.ins.AnimateTransform(animObj, animObj.localPosition, new Vector3(animObj.localPosition.x, animeValue, animObj.localPosition.z),
            animTime, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "Linear");
    }

    int randomVal;
    void ChooseRandomValueOfStripForCameraSwitching(Transform airplaneTransform)
    {
        randomVal = UnityEngine.Random.Range(0, PlaneStrip.Count);
        if (!PlaneStrip[randomVal].activeInHierarchy)
        {
            ChooseRandomValueOfStripForCameraSwitching(airplaneTransform);
        }

        else
        {
            if (FlightStripMgr.instance.dep == 1 && FlightStripMgr.instance.Active_ARR_FlightList.Count != 0)
            {
                FlightStripMgr.instance.currSelectedFLTNum = 0;
                FlightStripMgr.instance.currSelectedFLT = FlightStripMgr.instance.Active_ARR_FlightList[FlightStripMgr.instance.currSelectedFLTNum];
                FlightStripMgr.instance.arr = 1;
                FlightStripMgr.instance.dep = 0;
            }

            else if (FlightStripMgr.instance.arr == 1 && FlightStripMgr.instance.Active_DEP_FlightList.Count != 0)
            {
                FlightStripMgr.instance.currSelectedFLTNum = 0;
                FlightStripMgr.instance.currSelectedFLT = FlightStripMgr.instance.Active_DEP_FlightList[FlightStripMgr.instance.currSelectedFLTNum];
                FlightStripMgr.instance.dep = 1;
                FlightStripMgr.instance.arr = 0;
            }

            if (FlightStripMgr.instance.currSelectedFLT != null)
            {
                FlightStripMgr.instance.currSelectedFLTBtn = FlightStripMgr.instance.currSelectedFLT.transform.GetChild(0).GetChild(0).gameObject;
                FlightStripMgr.instance.currSelectedFLTBtn.GetComponent<Button>().onClick.Invoke();
                airplaneTransform.gameObject.SetActive(false);
            }



            //AeroplaneHit(randomVal);
            //RadarManagerScript.instance.ClickPlane(randomVal);
            //RadarManagerScript.instance.ChangeArrRadarCamera(randomVal);
        }
    }
    public void MidToRightSlide(Transform airplaneTransform)
    {
        StartCoroutine(MidToRightSlideCoroutine(airplaneTransform));  
    }

    IEnumerator MidToRightSlideCoroutine(Transform airplaneTransform)
    {
        Transform flightSripe = airplaneTransform.GetComponent<AircraftScripts>().airPlaneStrip;
        yield return new WaitForSeconds(6f);
        AnimateTransformFunctions.ins.AnimateTransform(flightSripe, flightSripe.localPosition, new Vector3(40f, flightSripe.localPosition.y, flightSripe.localPosition.z),
            2f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "Linear");
        yield return new WaitForSeconds(2.2f);
        flightSripe.gameObject.SetActive(false);
        yield return new WaitForSeconds(.2f);

        AddingStrapsTOAminateUpSideDown(1);

        airplaneTransform.GetComponent<AircraftScripts>().AirPoint.Clear();
        if (airplaneTransform.GetComponentInChildren<SpriteRenderer>())
        {
            airplaneTransform.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
       // if (airplaneTransform.GetComponent<RadarScript>().isDeparture)
       // {
            
       // }

        yield return new WaitForSeconds(2f);

        UIManager.instance.currentLevelSelected.allAppearedPlaneCountforLevel++;
        if (UIManager.instance.currentLevelSelected.allAppearedPlaneCountforLevel >= planeCountForEachLevel)
        {
            ScoreManager.instance.StartGameOverCoroutine();
        }
        else
        {
            if (airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == currentPlaneActive)
            {
                ChooseRandomValueOfStripForCameraSwitching(airplaneTransform);
            }
        }

       // airplaneTransform.gameObject.SetActive(false);

    }

    //..................By Basant.................//
    #region Check Atc On same tower
    //.............Check Atc On same tower................//
    //................Check On Trigger when atc is open then command should be disable until or unless atc is closed........//
    public IEnumerator DisableAtcCommandOnTriggerEnter(int _planeNo)
    {
        yield return new WaitForSeconds(0.01f);
        currentAtcContainer = PlaneList[_planeNo].GetComponent<RadarScript>().currentATC;
        ATCBarUIScript currentAirplaneATCScript = GameObject.Find(currentAtcContainer).transform.GetComponent<ATCBarUIScript>();

        if (currentAirplaneATCScript.aTCOpen && currentAtcContainer == PlaneList[currentPlaneActive].GetComponent<RadarScript>().currentATC)//_planeNo == currentPlaneActive && )
        {
            GameObject _obj = FindHighlightedCmd(commandList);

            highlightedCmdGameObj.Clear();
            FindAllDeactiveCmd(_obj);
            DisableEnableCommandGameObject(highlightedCmdGameObj, true);

            if (EnableCmdAutometicCorotineForTrigger != null)
            {
                StopCoroutine(EnableCmdAutometicCorotineForTrigger);

            }

            if (FlightStripMgr.instance.currSelectedFLTBtn != null)
            {
                FlightStripMgr.instance.currSelectedFLTBtn.GetComponent<Button>().onClick.Invoke();
            }

            EnableCmdAutometicCorotineForTrigger = StartCoroutine(EnableCmdAutometic(currentAirplaneATCScript));
            preAtcContainer = currentAtcContainer;
            currentAtcContainer = "";

        }
        else
        {

            if (currentAtcContainer == PlaneList[currentPlaneActive].GetComponent<RadarScript>().currentATC)
            {
                GameObject _obj = FindHighlightedCmd(commandList);
                highlightedCmdGameObj.Clear();
                FindAllDeactiveCmd(_obj);
                DisableEnableCommandGameObject(highlightedCmdGameObj, false);
            }

            preAtcContainer = currentAtcContainer;
            currentAtcContainer = "";

        }
    }
   

    public IEnumerator CheckAtcOnSameTower(int _planeNo)
    {
        yield return new WaitForSeconds(0.03f);

        currentAtcContainer = PlaneList[_planeNo].GetComponent<RadarScript>().currentATC;
        ATCBarUIScript currentAirplaneATCScript = GameObject.Find(currentAtcContainer).transform.GetComponent<ATCBarUIScript>();

        if (currentAtcContainer == preAtcContainer)
        {


            if (currentAirplaneATCScript.aTCOpen)
            {
                GameObject _obj = FindHighlightedCmd(commandList);
                highlightedCmdGameObj.Clear();
                FindAllDeactiveCmd(_obj);
                DisableEnableCommandGameObject(highlightedCmdGameObj, true);
                if (EnableCmdAutometicCorotine != null)
                {
                    StopCoroutine(EnableCmdAutometicCorotine);

                }
                EnableCmdAutometicCorotine = StartCoroutine(EnableCmdAutometic(currentAirplaneATCScript));
            }
            else
            {
                GameObject _obj = FindHighlightedCmd(commandList);
                highlightedCmdGameObj.Clear();
                FindAllDeactiveCmd(_obj);
                DisableEnableCommandGameObject(highlightedCmdGameObj, false);
            }
        }
        else
        {
            if (!currentAirplaneATCScript.aTCOpen)
            {
                GameObject _obj = FindHighlightedCmd(commandList);
                highlightedCmdGameObj.Clear();
                FindAllDeactiveCmd(_obj);
                DisableEnableCommandGameObject(highlightedCmdGameObj, false);
            }
            else
            {
                GameObject _obj = FindHighlightedCmd(commandList);
                highlightedCmdGameObj.Clear();
                FindAllDeactiveCmd(_obj);
                DisableEnableCommandGameObject(highlightedCmdGameObj, true);
                if (EnableCmdAutometicCorotine != null)
                {
                    StopCoroutine(EnableCmdAutometicCorotine);

                }
                EnableCmdAutometicCorotine = StartCoroutine(EnableCmdAutometic(currentAirplaneATCScript));
            }
            preAtcContainer = currentAtcContainer;
            currentAtcContainer = "";
        }
    }

    Coroutine EnableCmdAutometicCorotine;
    Coroutine EnableCmdAutometicCorotineForTrigger;
    public IEnumerator EnableCmdAutometic(ATCBarUIScript _atcBarScript)
    {
        while (_atcBarScript.aTCOpen)
        {
            yield return new WaitForSeconds(.1f);
        }
        if (!_atcBarScript.aTCOpen)
        {
            DisableEnableCommandGameObject(highlightedCmdGameObj, false);
        }
    }
    //............Find highlighted gameObject in given list........//

    public GameObject obj;
    public GameObject FindHighlightedCmd(GameObject[] allCommands)
    {
        for (int i = 0; i < allCommands.Length; i++)
        {
            if (allCommands[i].activeInHierarchy)
            {
                obj = allCommands[i];
            }
        }
        return obj;
    }
    //........Find all de-active button command ..............//

    public List<GameObject> highlightedCmdGameObj;  
    public void FindAllDeactiveCmd(GameObject _obj)
    {
        if (_obj != null)
        {
            for (int i = 0; i < _obj.transform.childCount; i++)
            {
                Transform child = _obj.transform.GetChild(i);
                if (child.tag == "deactiveBtn")
                {
                    highlightedCmdGameObj.Add(child.gameObject);
                }
                if (child.childCount > 0)
                {
                    FindAllDeactiveCmd(child.gameObject);
                }
            }
        }
    }
    //..........Disable game object list..........//
    public bool isCommandDisable;
    public void DisableEnableCommandGameObject(List<GameObject> _objList, bool isDisable)
    {
        if (isDisable)
        {
            for (int i = 0; i < _objList.Count; i++)
            {
                _objList[i].GetComponent<Button>().enabled = false;
                _objList[i].GetComponent<Image>().color = new Color32(75, 75, 75, 255);
                isCommandDisable = true;
            }
        }
        else
        {
            for (int i = 0; i < _objList.Count; i++)
            {
                _objList[i].GetComponent<Button>().enabled = true;
                _objList[i].GetComponent<Image>().color = new Color32(75, 75, 75, 0);
                isCommandDisable = false;
            }
        }
    }
    #endregion   
}