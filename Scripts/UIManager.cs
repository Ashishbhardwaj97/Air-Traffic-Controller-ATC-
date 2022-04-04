using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //.........................................//
    public static UIManager instance;
    public Transform APR, TWR, GND, CLR, DEP;
    //.........................................//

    //.....Arrival & Departure Commands.....//

    public GameObject arrivalUI, departureUI, spottospotUI;
    public GameObject _Canvas;

    //........Departure..........//
    public Sprite RedspriteEmg;
    //bool Dep_Maskdata;
    public GameObject PathselectionLine;

    public GameObject Dep_birdeyeviewcam;
    public bool dep_runwayselection_birdeyeview;

    public GameObject dep_departureapproved_standby;
    public GameObject dep_departureapproved_activebutton, dep_standby_activebutton;

    public GameObject dep_runwayselection; //......RunwaySelection......34R,16R,16L.....//
    public GameObject dep_34Rrunwayactivebutton, dep_16Rrunwayactivebutton, dep_16Lrunwayactivebutton;
    public GameObject dep_runwayrouteselection; //......RunwayRouteSelection....
    public GameObject dep_A_Activebutton, dep_B_Activebutton, dep_C_Activebutton;
    public GameObject dep_cleartotaxi_standby;
    public GameObject dep_cleartotaxi_activebutton, dep_standby_activebutton_CT;

    public int dep_runwayselected;
    public bool hold_cont;
    public GameObject holdposn_continueposn;
    public GameObject holdposition, continuetaxi;
    public GameObject holdposition_activebutton, continuetaxi_activebutton;

    public GameObject towercontrol_handoff;
    public GameObject towercontrol_handOff_activebutton;

    public GameObject takeoffapproval_Holdshort_lineupwait;
    public GameObject takeoffapproval_activebutton, Holdshort_activebutton, lineupwait_activebutton;

    public bool takeoffspecialcase, holdSpecialCase;

    public GameObject takeoffapprovalOnly;
    public GameObject takeoffapprovalOnly_activebutton;

    public GameObject departure_handOff;
    public GameObject departure_handOff_activebutton;

    public GameObject dep_continueownnav;
    public GameObject dep_continueownnav_activebutton;

    public GameObject dep_radarcontroloff;
    public GameObject dep_radarcontroloff_activebutton;

    //.............Ashish.........................//
    public List<AudioClip> LobbyAudioClipsPlaneArr = new List<AudioClip>();
    public List<AudioClip> LobbyAudioClipsPlaneDep = new List<AudioClip>();
    //............................................//

    //........Arrival..........//

    //bool Arv_Maskdata;
    int arv_runwayselected;

    public GameObject arv_birdeyeviewcam;
    public bool arv_runwayselection_birdeyeview;

    //.....Runway...ui selection....//

    public List<GameObject> totalRunwayUI;
    //public GameObject arv_runwayselection_all_ui;
    //public List<GameObject> arrivalTotalRunwayUI;
    //public List<GameObject> depTotalRunwayUI;

    public List<GameObject> totalRunwayUILine;
    //public List<GameObject> depTotalRunwayUILine;
    //public GameObject arv_34R_runway_red, arv_34L_runway_red;
    //public GameObject arv_34R_runway_redbg, arv_34L_runway_redbg;

    //public GameObject dep_16R_runway_red, dep_16L_runway_red;
    //public GameObject dep_16R_runway_redbg, dep_16L_runway_redbg;

    //.............................//

    //..... Emergency selection....//

    public GameObject arv_Emergency_selection;
    public GameObject arv_Emergency_selectionactivebutton;

    //.............................//

    //..... Crossrunway_standby selection....//

    public GameObject crossrunway_standby;
    public GameObject crossrunway_activebutton, cross_standby_activebutton;

    //......................................//

    public GameObject arv_runwayselection; //...... Arrival RunwaySelection....34R,34L.....//
    public GameObject arv_34R_runwayactivebutton, arv_34L_runwayactivebutton;

    public GameObject arv_detour_selection; //...... Detour Route selection.....//   
    public GameObject arv_detour_selectionactivebutton; //...... Detour Active Button selection.....//

    public GameObject arv_cleartolanding_goaround_selection;
    public GameObject arv_cleartolanding_activebutton, arv_goaround_activebutton;
    public bool goaroundok;

    //...plane Speed Ui...//
    public GameObject all_speedui;

    public GameObject arv_s_maintain;
    public GameObject arv_s_keepspeed_activeButton_ks_as, arv_s_accelerate_activeButton_ks_as;

    public GameObject arv_m_maintain;
    public GameObject arv_m_decelerate_activeButton_ds_ks_as, arv_m_keepspeed_activeButton_ds_ks_as, arv_m_accelerate_activeButton_ds_ks_as;

    public GameObject arv_f_maintain;
    public GameObject arv_f_decelerate_activeButton_ds_ks, arv_f_keepspeed_activeButton_ds_ks;

    //.....................//
    public GameObject arv_towercontrol_handoff;
    public GameObject arv_towercontrol_handOff_activebutton;

    //...........................//
    public GameObject arv_departurecontrolhand_off;
    public GameObject arv_departurecontrolhand_off_activebutton;

    public GameObject arv_approachcontrolhand_Off;
    public GameObject arv_approachcontrolhand_Off_activebutton;

    public GameObject arv_taxirouteC8_C9;
    public GameObject arv_taxirouteC8_activebutton, arv_taxirouteC9_activebutton;

    public GameObject arv_taxirouteL6_L9;
    public GameObject arv_taxirouteL6_activebutton, arv_taxirouteL9_activebutton;


    public GameObject arv_AllTexiSpot;
    public GameObject arv_spot2_activebutton, arv_spot3_activebutton, arv_spot403_activebutton, arv_standby_activebutton;

    public GameObject arv_parking_abc;
    public GameObject arv_parking_a_activebutton, arv_parking_b_activebutton, arv_parking_c_activebutton;

    public GameObject arv_holdposn_continueposn;
    public GameObject arv_holdposition;
    public GameObject arv_holdposition_activebutton;

    public GameObject arv_continuetaxi;
    public GameObject arv_continuetaxi_activebutton;

    //.........Spot to Spot.............//

    public GameObject sts_birdeyeviewcam;

    public bool sts_spotselection_birdeyeview;
    //public bool sts_spotselection_birdeyeview203, sts_spotselection_birdeyeview65, sts_spotselection_birdeyeview15;

    public GameObject sts_spot203_standby, sts_spot203_activebutton, sts_standby203_activebutton; //..67_203..//
    public GameObject sts_spot65_standby, sts_spot65_activebutton, sts_standby65_activebutton; //..23_65..//
    public GameObject sts_spot15_standby, sts_spot15_activebutton, sts_standby15_activebutton; //..144_15..//

    public GameObject sts_holdposition, sts_continuetaxi;
    public GameObject sts_holdposition_activebutton, sts_continuetaxi_activebutton;

    //..................................//
    //........by basant.........//
    
    public string planeNo;
    public string planeNoArr;
    public string runwayNo;
    public string runwayNoArr;
    public string planeSpeedArr;
    public string taxiWaysArr;

    AudioClip taxiWaysArrClip1;
    AudioClip taxiWaysArrClip2;

    //public string taxiWaysArrL6_L9;

    //AudioClip taxiWaysArrL6L9Clip1;
    //AudioClip taxiWaysArrL6L9Clip2;

    //.................//
    public string _rWYArrival = "-";
    public string _from = "-";
    public string _depRWYText = "-";
    public string _planeDescription = "-";
    public string _ATC_CommandHistory = "";
    public string _destination = "";
    public string _flightLvl = "";
    public string _flightCode = "";
    public string _flyDir = "";
    public string _wayPoint = "";
    public string _altNew = "";
    public string _cardinalDry = "";
    public string _apprRoute = "";
    public string _LRDir = "";
    public string _altStr = "";
    public string _altA = "";
    public string _altB = "";
    public string _atisCode = "";

    public string _airserveNo;
    public string _currentSpot;
    public string _endSpot;

    public AudioClip currentFlightNoClip;

    public AudioClip _depRouteClip;
    public AudioClip _flightLvl1Clip;
    public AudioClip _flightLvl2Clip;
    public AudioClip _flightLvl3Clip;
    public AudioClip _code1Clip;
    public AudioClip _code2Clip;
    public AudioClip _code3Clip;
    public AudioClip _code4Clip;
    
    public AudioClip _flyDir1Clip;
    public AudioClip _flyDir2Clip;
    public AudioClip _flyDir3Clip;
    public AudioClip _wayPointClip;
    public AudioClip _altNew1Clip;
    public AudioClip _thousandClip;
    public AudioClip _cardinalDryClip;
    public AudioClip _LRDirClip;

    public AudioClip _atisCodeClip;

    public AudioClip _altClip;

    public AudioClip _altA1Clip;
    public AudioClip _altA2Clip;

    public AudioClip _altB1Clip;
    public AudioClip _altB2Clip;

    public AudioClip _airserveClip;
    public AudioClip _currentSpotClip;
    public AudioClip _endSpotClip;

    public AudioClip _apprRouteClip;
    public AudioClip _windDir1Clip, _windDir2Clip, _windDir3Clip, _windForce1Clip, _windForce2Clip;

    //........................//

    public AudioSource audioSourcePlaneArr;
    public AudioSource audioSourcePlaneDep;
    AudioClip flySpeedClip1;
    AudioClip flySpeedClip2;
    AudioClip flySpeedClip3;

    public AudioClip runwayNoArrClip1;
    public AudioClip runwayNoArrClip2;
    public AudioClip runwayNoArrClip3;

    AudioClip runwayNoDepClip1;
    AudioClip runwayNoDepClip2;
    AudioClip runwayNoDepClip3;

    public AudioClip destinationDepClip;

    public AudioClip planeNoClipDep;
    public List<AudioClip> audioClipsPlaneArr = new List<AudioClip>();
    public List<AudioClip> audioClipsPlaneDep = new List<AudioClip>();

    public ATCBarUIScript[] atcBarScript = new ATCBarUIScript[5];
    public Coroutine[] yellowPlane;
    public Coroutine[] RedPlane;
    public Coroutine[] BluePlane;

    public Coroutine[] yellowPlaneDep;
    public Coroutine[] RedPlaneDep;
    public Coroutine[] BluePlaneDep;

    public bool BBspot2, BBspot3, BBspot403;

    private Coroutine slowSpeedCorotine;
    private Coroutine mediumSpeedCorotine;
    private Coroutine fastSpeedCorotine;
    private Coroutine blueIMaskForSlowSpeedCorotine;
    private Coroutine blueIMaskForMediumSpeedCorotine;
    private Coroutine blueIMaskForFastSpeedCorotine;

    public string spotNoArv;
    public AudioClip arv_spotNo1;
    public AudioClip arv_spotNo2;
    public AudioClip arv_spotNo3;

    public GameObject clearToLandingCmd;
    public Level currentLevelSelected;

    //...................Added by Ashish....................//
    public int accelerateCounter = 0;
    public int goAroundCounter = 0;
    public int spotCounter2 = 0;
    public int spotCounter3 = 0;
    public int spotCounter403 = 0;
    //........................................................//

    #region Random sounds for diffrent ATC

    public GameObject aPRSound;
    public GameObject tWRSound;
    public GameObject gNDSound;
    public GameObject cLRSound;
    public GameObject dEPSound;

    public List<GameObject> depPilotSounds;
    public List<GameObject> arvPilotSounds;

    public void AssignRandomAudioSound()
    {      
        int randomNo = Random.Range(0, SoundManager.instance.peopleSoundsList.Count);
        aPRSound = SoundManager.instance.peopleSoundsList[randomNo];
        SoundManager.instance.peopleSoundsList.RemoveAt(randomNo);

        int randomNo2 = Random.Range(0, SoundManager.instance.peopleSoundsList.Count);
        tWRSound = SoundManager.instance.peopleSoundsList[randomNo2];
        SoundManager.instance.peopleSoundsList.RemoveAt(randomNo2);

        int randomNo3 = Random.Range(0, SoundManager.instance.peopleSoundsList.Count);
        gNDSound = SoundManager.instance.peopleSoundsList[randomNo3];
        SoundManager.instance.peopleSoundsList.RemoveAt(randomNo3);

        int randomNo4 = Random.Range(0, SoundManager.instance.peopleSoundsList.Count);
        dEPSound = SoundManager.instance.peopleSoundsList[randomNo4];
        SoundManager.instance.peopleSoundsList.RemoveAt(randomNo4);

        cLRSound = SoundManager.instance.peopleSoundsList[0];
        SoundManager.instance.peopleSoundsList.RemoveAt(0);

        depPilotSounds.Add(aPRSound);
        depPilotSounds.Add(dEPSound);
        arvPilotSounds.Add(cLRSound);
        arvPilotSounds.Add(dEPSound);       
    }
    #endregion

    //...........Set Wind Force and Wind Dir...........//
    public void SetWindDirAndForceText(int _index)
    {
        RadarManagerScript.instance.RotateAirDir("-" + currentLevelSelected.setWindForceTimings[_index].windAngle.ToString());
        RadarManagerScript.instance.RotateBirdEyeViewDir("-" + currentLevelSelected.setWindForceTimings[_index].windAngle.ToString());
        RadarManagerScript.instance.SetAirSpeed(currentLevelSelected.setWindForceTimings[_index].windAngle.ToString(), currentLevelSelected.setWindForceTimings[_index].windForce.ToString());
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //...Arrival...//      
        yellowPlane = new Coroutine[20];
        RedPlane = new Coroutine[20];
        BluePlane = new Coroutine[20];
        yellowPlaneDep = new Coroutine[20];
        RedPlaneDep = new Coroutine[20];
        BluePlaneDep = new Coroutine[20];

        //Arv_Maskdata = false;
        arv_runwayselection_birdeyeview = false;
        goaroundok = false;

        BBspot2 = false;
        BBspot3 = false;
        BBspot403 = false;
        //..............//

        //...Departure...//
        //Dep_Maskdata = false;
        takeoffspecialcase = false;
        dep_runwayselection_birdeyeview = false;
        //..............//
        //............By basant............//
        atcBarScript[0] = APR.GetComponent<ATCBarUIScript>();
        atcBarScript[1] = TWR.GetComponent<ATCBarUIScript>();
        atcBarScript[2] = GND.GetComponent<ATCBarUIScript>();
        atcBarScript[3] = CLR.GetComponent<ATCBarUIScript>();
        atcBarScript[4] = DEP.GetComponent<ATCBarUIScript>();

        AssignRandomAudioSound();
    }
    //......................................................//

    void Update()
    {
        #region Runwayselection_birdeyeview

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArrival)
        {
            arrivalUI.SetActive(true);
            departureUI.SetActive(false);
            spottospotUI.SetActive(false);

            //.... arrival Bird eye view on off......//

            if (arv_runwayselection_birdeyeview && SaveAndLoad.autoBirdEyeView == 1) 
            {
                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(false);
                //}
                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(false);
                }
                arv_birdeyeviewcam.SetActive(true);

                CameraSwitch.ins.mainCamera.SetActive(false);
            }
            else if (!arv_runwayselection_birdeyeview)
            {
                arv_birdeyeviewcam.SetActive(false);

                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(true);
                //}
                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(true);
                }
                if (!CameraSwitch.ins.mainCamera.activeInHierarchy && CameraSwitch.ins.activeCam == null)
                {
                    CameraSwitch.ins.mainCamera.SetActive(true);
                }
            }
            //...............................//
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isDeparture)
        {
            arrivalUI.SetActive(false);
            departureUI.SetActive(true);
            spottospotUI.SetActive(false);

            //.... Departure Bird eye view on off......//

            if (dep_runwayselection_birdeyeview && SaveAndLoad.autoBirdEyeView == 1)
            {
                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(false);
                //}

                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(false);
                }

                Dep_birdeyeviewcam.SetActive(true);
                CameraSwitch.ins.mainCamera.SetActive(false);
            }
            else if (!dep_runwayselection_birdeyeview)
            {
                Dep_birdeyeviewcam.SetActive(false);

                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(true);
                //}

                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(true);
                }

                if (!CameraSwitch.ins.mainCamera.activeInHierarchy && CameraSwitch.ins.activeCam == null)
                {
                    CameraSwitch.ins.mainCamera.SetActive(true);
                }
            }
            //.........................................//
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isSpottoSpot)
        {
            arrivalUI.SetActive(false);
            departureUI.SetActive(false);
            spottospotUI.SetActive(true);

            //.... Spot to Spot Bird eye view on-off......//

            if (sts_spotselection_birdeyeview && SaveAndLoad.autoBirdEyeView == 1)
            {
                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(false);
                //}

                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(false);
                }

                sts_birdeyeviewcam.SetActive(true);
                CameraSwitch.ins.mainCamera.SetActive(false);
            }
            else if (!sts_spotselection_birdeyeview)
            {
                sts_birdeyeviewcam.SetActive(false);

                //if (CameraSwitch.ins.CamCount > 0)
                //{
                //    CameraSwitch.ins.Cam_View[CameraSwitch.ins.CamCount - 1].SetActive(true);
                //}

                if (CameraSwitch.ins.activeCam != null)
                {
                    CameraSwitch.ins.activeCam.SetActive(true);
                }

                if (!CameraSwitch.ins.mainCamera.activeInHierarchy && CameraSwitch.ins.activeCam == null)
                {
                    CameraSwitch.ins.mainCamera.SetActive(true);
                }
            }
            //.........................................//
        }
        #endregion
    }

    #region Current Plane Properties references

    public int ConvertAtcSoundsIntoNo(GameObject atcSound)
    {
        if (atcSound.CompareTag("M1"))
            return 0;
        else if (atcSound.CompareTag("M2"))
            return 1;
        else if (atcSound.CompareTag("M3"))
            return 2;
        else if (atcSound.CompareTag("W1"))
            return 3;
        else if (atcSound.CompareTag("W2"))
            return 4;
        else
            return 0;
    }
    public void References(int _planeNo, GameObject _atcSound)
    {
        //................................ TEXT ........................................//
        planeNo = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        runwayNo = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().runwayNo;
        runwayNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().runwayNo;
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;

        _flyDir = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().flyDir;
        _rWYArrival = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().rWYArrival;
        _from = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().from;
        _planeDescription = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().planeDescription;
        _ATC_CommandHistory = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().ATC_CommandHistory;
        _destination = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().destination;
        _flightLvl = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().flightLvl;
        _flightCode = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().flightCode;
        _flyDir = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().flyDir;
        _wayPoint = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().wayPoint;
        _altNew = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().altNew;
        _cardinalDry = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().cardinalDry;
        _apprRoute = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().apprRoute;
        _LRDir = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().LRDir;
        _altStr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().alt;
        _altA = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().altA;
        _altB = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().altB;

        _atisCode = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().atisCode;

        _depRWYText = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().depRoute;

        _airserveNo = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().airserveNo;
        _currentSpot = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentSpot;
        _endSpot = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().endSpot;

        taxiWaysArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().taxiWaysArr;
        //.......................................................................//

        //.................................. AUDIO .............................//

        int _soundIndex = ConvertAtcSoundsIntoNo(_atcSound);       
        ATC atcScript = _atcSound.GetComponent<ATC>();
        if (runwayNoArr == "34R")
        {
            runwayNoArrClip1 = atcScript.three;
            runwayNoArrClip2 = atcScript.four;
            runwayNoArrClip3 = atcScript.right;
        }
        else if (runwayNoArr == "34L")
        {
            runwayNoArrClip1 = atcScript.three;
            runwayNoArrClip2 = atcScript.four;
            runwayNoArrClip3 = atcScript.left;
        }

        if (runwayNo == "34R")
        {
            runwayNoDepClip1 = atcScript.three;
            runwayNoDepClip2 = atcScript.four;
            runwayNoDepClip3 = atcScript.right;
        }
        else if (runwayNo == "16L")
        {
            runwayNoDepClip1 = atcScript.one;
            runwayNoDepClip2 = atcScript.six;
            runwayNoDepClip3 = atcScript.left;
        }
        else if (runwayNo == "16R")
        {
            runwayNoDepClip1 = atcScript.one;
            runwayNoDepClip2 = atcScript.six;
            runwayNoDepClip3 = atcScript.right;
        }
        
        if (taxiWaysArr == "C8")
        {
            taxiWaysArrClip1 = atcScript.c;
            taxiWaysArrClip2 = atcScript.eight;
        }
        else if (taxiWaysArr == "C9")
        {
            taxiWaysArrClip1 = atcScript.c;
            taxiWaysArrClip2 = atcScript.nine;
        }

        if (taxiWaysArr == "L6")
        {
            taxiWaysArrClip1 = atcScript.l_down;
            taxiWaysArrClip2 = atcScript.six;
        }
        else if (taxiWaysArr == "L9")
        {
            taxiWaysArrClip1 = atcScript.l_down;
            taxiWaysArrClip2 = atcScript.nine;
        }

        planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        destinationDepClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightDestination;
        _depRouteClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].depRouteClip;
        _flightLvl1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightLvl1Clip;
        _flightLvl2Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightLvl2Clip;
        _flightLvl3Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightLvl3Clip;
        _code1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].code1Clip;
        _code2Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].code2Clip;
        _code3Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].code3Clip;
        _code4Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].code4Clip;

        _atisCodeClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].atisCodeClip;

        _altClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altClip;

        _altA1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altA1Clip;
        _altA2Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altA2Clip;

        _altB1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altB1Clip;
        _altB2Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altB2Clip;

        _flyDir1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flyDir1Clip;
        _flyDir2Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flyDir2Clip;
        _flyDir3Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flyDir3Clip;
        _wayPointClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].wayPointClip;
        _altNew1Clip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].altNewClip;
        _thousandClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].thousandClip;
        _cardinalDryClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].cardinalDryClip;
        _LRDirClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].LRDirClip;

        _airserveClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].airserveAudioClip;
        _currentSpotClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].currentSpotClip;
        _endSpotClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].endSpotClip;
        _apprRouteClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].apprRoute;

        int index = currentLevelSelected.CheckCurrentWindForce();
        _windDir1Clip = currentLevelSelected.setWindForceTimings[index].windForceClipObject[_soundIndex].windAngleClip1;
        _windDir2Clip = currentLevelSelected.setWindForceTimings[index].windForceClipObject[_soundIndex].windAngleClip2;
        _windDir3Clip = currentLevelSelected.setWindForceTimings[index].windForceClipObject[_soundIndex].windAngleClip3;

        _windForce1Clip = currentLevelSelected.setWindForceTimings[index].windForceClipObject[_soundIndex].windForceClip1;
        _windForce2Clip = currentLevelSelected.setWindForceTimings[index].windForceClipObject[_soundIndex].windForceClip2;
        //..............................................................//
    }

    #endregion

    //.............................Departure Process........................................//

    #region Departure Process    

    #region Departure Approved and standby

    public void Active_DA_and_SB(Transform airplaneTransform, bool isOnClick) //...Active Departure Approved and standby
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_isAirCraft_DA_SB && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            dep_departureapproved_standby.SetActive(true);
            dep_departureapproved_activebutton.SetActive(false);
            dep_standby_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    dep_departureapproved_standby.SetActive(false);
                    dep_departureapproved_activebutton.SetActive(false);
                    dep_standby_activebutton.SetActive(false);
                }
            }
            else
            {
                dep_departureapproved_standby.SetActive(false);
                dep_departureapproved_activebutton.SetActive(false);
                dep_standby_activebutton.SetActive(false);
            }
        }
    }
    public void Select_Dep_ApprovedDeactiveButton() //....Select DepartureApproved Deactive Button....//
    {
        dep_departureapproved_activebutton.SetActive(true);
        dep_standby_activebutton.SetActive(false);
    }
    public void Select_StandByDeactiveButton() //....Select Standby Deactive Button....//
    {
        dep_standby_activebutton.SetActive(true);
        dep_departureapproved_activebutton.SetActive(false);
    }
    public void Select_Dep_ApprovedAactiveButton() //.......Select DepartureApproved Active Button.. //..Mask
    {
        dep_departureapproved_activebutton.SetActive(false);
        dep_standby_activebutton.SetActive(false);
        dep_departureapproved_standby.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pushBackTowingCar.SetActive(true); //..pushBack on..//

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().Runwaycall_BirdEyeview());
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_DA_SB = false;

        //.......by basant.............//
        ScoreManager.instance.ClickForBonus(200);
        References(GameManagerScript.instanceGMS.currentPlaneActive, cLRSound);        
        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureApproval(planeNo, _destination, _depRWYText, _flightLvl, _flightCode); 
        CLR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureApprovalAudio(planeNoClipDep, destinationDepClip, _depRouteClip, _flightLvl1Clip, _flightLvl2Clip, _flightLvl3Clip, _code1Clip, _code2Clip, _code3Clip, _code4Clip, cLRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, CLR);

        StartCoroutine(DepApprovalAgain(GameManagerScript.instanceGMS.currentPlaneActive, _destination, _depRWYText, _flightLvl, _flightCode));
    }

    public void Select_StandByAactiveButton() //.......Select Standby Active Button..
    {
        dep_departureapproved_activebutton.SetActive(false);
        dep_standby_activebutton.SetActive(false);
        dep_departureapproved_standby.SetActive(false);

        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().ReCall_DA_and_SB();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_DA_SB = false;

        //.........By basant......//
        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepStandBy(planeNo);

        CLR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        int _soundIndex = ConvertAtcSoundsIntoNo(cLRSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        StartCoroutine(StandByAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        audioClipsPlaneDep = CommandReceiver.instance.DepStandByAudio(planeNoClipDep, cLRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, CLR);
    }
    //........by basant.......//
    IEnumerator StandByAgain(int _planeNo)
    {
        yield return new WaitForSeconds(14f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepStandByAgain(planeNo);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DepStandByAgainAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    IEnumerator DepApprovalAgain(int _planeNo, string _destination, string _depRWYText, string _flightLvl, string _flightCode)
    {
        yield return new WaitForSeconds(14f);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);

        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureApprovalAgain(_destination, _depRWYText, _flightLvl, _flightCode, planeNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureApprovalAgainAudio(destinationDepClip, _depRouteClip, _flightLvl1Clip, _flightLvl2Clip, _flightLvl3Clip, _code1Clip, _code2Clip, _code3Clip, _code4Clip, planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        StartCoroutine(DepPushBack(_planeNo));
    }

    IEnumerator DepPushBack(int _depPushBackPlaneNo)
    {
        yield return new WaitForSeconds(13f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<AircraftScripts>().flightNumber;
        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DeparturePushBack(planeNo);
     
        int _soundIndex = ConvertAtcSoundsIntoNo(cLRSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DeparturePushBackAudio(planeNoClipDep,cLRSound);
        GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_depPushBackPlaneNo, CLR);

        StartCoroutine(DepPushBackAgain(_depPushBackPlaneNo));
    }

    IEnumerator DepPushBackAgain(int _depPushBackAgainPlaneNo)
    {
        yield return new WaitForSeconds(13f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<AircraftScripts>().flightNumber;

        CLR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DeparturePushBackReady(planeNo);
        
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DeparturePushBackReadyAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depPushBackAgainPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depPushBackAgainPlaneNo);

        StartCoroutine(DepPushBackTokyoGND(_depPushBackAgainPlaneNo));
    }

    IEnumerator DepPushBackTokyoGND(int _depPushBackTokyoGND_PlaneNo)
    {
        yield return new WaitForSeconds(13f);
        //............................1st shift.....................//

        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[_depPushBackTokyoGND_PlaneNo].transform, -1.85f);
        GameManagerScript.instanceGMS.PlaneStrip[_depPushBackTokyoGND_PlaneNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[_depPushBackTokyoGND_PlaneNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;

        //...........................................................//
        planeNo = GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepPushBackRequest(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<RadarScript>().currentATC = "GND";
        if (_depPushBackTokyoGND_PlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "GND";
        }
        audioClipsPlaneDep = CommandReceiver.instance.DepPushBackRequestAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depPushBackTokyoGND_PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depPushBackTokyoGND_PlaneNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_depPushBackTokyoGND_PlaneNo));
        //..................................................//
    }
    //....................//
    #endregion

    #region Runwaycall_BirdEyeview

    public void Runwaycall_BirdEyeview(Transform airplaneTransform, bool isOnClick)
    {
        dep_runwayrouteselection.SetActive(false);

        if (airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter != null)
        {
            for (int i = 0; i < airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.childCount; i++)
            {
                if (airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).childCount > 0)
                {
                    for (int j = 0; j < airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).childCount; j++)
                    {
                        airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).GetChild(j).gameObject.SetActive(true);
                    }
                }
                
            }
            for (int i = 0; i < airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.childCount; i++)
            {
                airplaneTransform.GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).gameObject.SetActive(false);
            }         
        }

        dep_34Rrunwayactivebutton.SetActive(false);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_16Lrunwayactivebutton.SetActive(false);

        dep_A_Activebutton.SetActive(false);
        dep_B_Activebutton.SetActive(false);
        dep_C_Activebutton.SetActive(false);

       

        if (airplaneTransform.GetComponent<RadarScript>().dep_isAirCraftIRunway && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            dep_runwayselection_birdeyeview = true; //....Call Bird Eye View...//.

            for (int i = 0; i < totalRunwayUI.Count; i++)
            {
                totalRunwayUI[i].SetActive(false);
                totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
            }

            for (int i = 0; i < totalRunwayUILine.Count; i++)
            {
                totalRunwayUILine[i].SetActive(false);
            }
            
            totalRunwayUI[0].SetActive(true);
            totalRunwayUI[2].SetActive(true);
            totalRunwayUI[3].SetActive(true);
            
            //......................//

            if (dep_runwayselected <= 0 || !dep_runwayselection.activeInHierarchy)
            {
                dep_runwayselection.SetActive(true);    //....Call Departure RunwayList..34R,16R,16L...//  
            }
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    dep_runwayselection_birdeyeview = false; //....Call Bird Eye View...//.
                    dep_runwayselection.SetActive(false);    //....Call Departure RunwayList..34R,16R,16L...//
                }
            }
            else
            {
                dep_runwayselection_birdeyeview = false; //....Call Bird Eye View...//.
                dep_runwayselection.SetActive(false);    //....Call Departure RunwayList..34R,16R,16L...//
            }
        }
    }
    #endregion

    #region Departure RunwayList Selection

    public void Select_Dep_Runway34RDeactiveButton() //.......Select DepartureRunway 34R..
    {

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }
        totalRunwayUILine[0].SetActive(true);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        totalRunwayUI[0].transform.GetChild(1).gameObject.SetActive(true);


        dep_34Rrunwayactivebutton.SetActive(true);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_16Lrunwayactivebutton.SetActive(false);
        GameObject _spotHighlight = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter;
        _spotHighlight.transform.GetChild(0).gameObject.SetActive(true);
        _spotHighlight.transform.GetChild(1).gameObject.SetActive(false);
        _spotHighlight.transform.GetChild(2).gameObject.SetActive(false);

        for (int i = 0; i < _spotHighlight.transform.GetChild(0).childCount; i++)
        {
            _spotHighlight.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
    }
    public void Select_Dep_Runway16RDeactiveButton() //.......Select DepartureRunway 16R..
    {

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }
        totalRunwayUILine[2].SetActive(true);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        totalRunwayUI[2].transform.GetChild(1).gameObject.SetActive(true);
        dep_16Rrunwayactivebutton.SetActive(true);
        dep_34Rrunwayactivebutton.SetActive(false);
        dep_16Lrunwayactivebutton.SetActive(false);
        GameObject _spotHighlight = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter;

        _spotHighlight.transform.GetChild(1).gameObject.SetActive(true);
        _spotHighlight.transform.GetChild(0).gameObject.SetActive(false);
        _spotHighlight.transform.GetChild(2).gameObject.SetActive(false);

        for (int i = 0; i < _spotHighlight.transform.GetChild(1).childCount; i++)
        {
            _spotHighlight.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
        }
    }
    public void Select_Dep_Runway16LDeactiveButton() //.......Select DepartureRunway 16L..
    {

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }
        totalRunwayUILine[3].SetActive(true);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        totalRunwayUI[3].transform.GetChild(1).gameObject.SetActive(true);
        dep_16Lrunwayactivebutton.SetActive(true);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_34Rrunwayactivebutton.SetActive(false);
        GameObject _spotHighlight = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter;

        _spotHighlight.transform.GetChild(2).gameObject.SetActive(true);
        _spotHighlight.transform.GetChild(0).gameObject.SetActive(false);
        _spotHighlight.transform.GetChild(1).gameObject.SetActive(false);

        for (int i = 0; i < _spotHighlight.transform.GetChild(2).childCount; i++)
        {
            _spotHighlight.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
        }

    }
    //................................................//

    public void Select_Dep_Runway34R_ActiveButton()
    {
        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        dep_16Lrunwayactivebutton.SetActive(false);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_34Rrunwayactivebutton.SetActive(false);

        dep_runwayselection.SetActive(false); //....RunwaySelection must be Deactive...//
        dep_runwayrouteselection.SetActive(true); //....RunwayRouteSelection Active....//

        dep_runwayselected = 1;

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        runwayNo = "34R";
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().runwayNo = runwayNo;
        Achievements.instance.OneRunway(runwayNo);          //...Added by Ashish...//
        ATC atcScript = gNDSound.GetComponent<ATC>();
        runwayNoDepClip1 = atcScript.three;
        runwayNoDepClip2 = atcScript.four;
        runwayNoDepClip3 = atcScript.right;
    }    
    public void Select_Dep_Runway16R_ActiveButton()
    {
        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        dep_16Lrunwayactivebutton.SetActive(false);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_34Rrunwayactivebutton.SetActive(false);

        dep_runwayselection.SetActive(false); //....RunwaySelection must be Deactive...
        dep_runwayrouteselection.SetActive(true); //....RunwayRouteSelection Active...        
        dep_runwayselected = 2;

        //.....by basant......//      

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        runwayNo = "16R";
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().runwayNo = runwayNo;
        Achievements.instance.OneRunway(runwayNo);          //...by Ashish...//

        ATC atcScript = gNDSound.GetComponent<ATC>();
        runwayNoDepClip1 = atcScript.one;
        runwayNoDepClip2 = atcScript.six;
        runwayNoDepClip3 = atcScript.right;
    }
    public void Select_Dep_Runway16L_ActiveButton()
    {
        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        dep_16Lrunwayactivebutton.SetActive(false);
        dep_16Rrunwayactivebutton.SetActive(false);
        dep_34Rrunwayactivebutton.SetActive(false);

        dep_runwayselection.SetActive(false); //....RunwaySelection must be Deactive...
        dep_runwayrouteselection.SetActive(true); //....RunwayRouteSelection Active...       
        dep_runwayselected = 3;

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        runwayNo = "16L";
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().runwayNo = runwayNo;
        Achievements.instance.OneRunway(runwayNo);              //by Ashish
        ATC atcScript = gNDSound.GetComponent<ATC>();
        runwayNoDepClip1 = atcScript.one;
        runwayNoDepClip2 = atcScript.six;
        runwayNoDepClip3 = atcScript.left;
    }
    
    //.............By basant..............
    void ATCAudioRunwaySelectonForDep(int _atcRunwaySelectionPlaneNo, string planeNo, string runwayNo)
    {
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DeparturePushBackApproved(planeNo, runwayNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        StartCoroutine(DepPushBackApprovedAgain(_atcRunwaySelectionPlaneNo));
        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_atcRunwaySelectionPlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DeparturePushBackApprovedAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, gNDSound);
        GameManagerScript.instanceGMS.PlaneList[_atcRunwaySelectionPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_atcRunwaySelectionPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_atcRunwaySelectionPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_atcRunwaySelectionPlaneNo, GND);
    }

    IEnumerator DepPushBackApprovedAgain(int _depPushBackPlaneNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_depPushBackPlaneNo, _pilotSound);

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DeparturePushBackApprovedAgain(planeNo, runwayNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.DeparturePushBackApprovedAgainAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3,_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depPushBackPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depPushBackPlaneNo);
    }
    //..........................//
    #endregion

    #region Departure A B C Routes 

    public void Select_Dep_A_DeactiveRoute() //...Select Departure A DeactiveRoute....//
    {
        dep_A_Activebutton.SetActive(true);
        dep_B_Activebutton.SetActive(false);
        dep_C_Activebutton.SetActive(false);

        if (dep_runwayselected == 1)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 2)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 3)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        }
    }
    public void Select_Dep_B_DeactiveRoute() //....Select Departure B DeactiveRoute...//
    {
        dep_B_Activebutton.SetActive(true);
        dep_A_Activebutton.SetActive(false);
        dep_C_Activebutton.SetActive(false);

        if (dep_runwayselected == 1)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 2)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 3)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        }
    }
    public void Select_Dep_C_DeactiveRoute() //...Select Departure C DeactiveRoute....//
    {
        dep_C_Activebutton.SetActive(true);
        dep_A_Activebutton.SetActive(false);
        dep_B_Activebutton.SetActive(false);

        if (dep_runwayselected == 1)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 2)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        else if (dep_runwayselected == 3)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
    }

    public void Select_Dep_A_ActiveRoute() //....Select Departure A ActiveButton....//
    {
        dep_C_Activebutton.SetActive(false);
        dep_A_Activebutton.SetActive(false);
        dep_B_Activebutton.SetActive(false);

        dep_runwayrouteselection.SetActive(false); //....RunwayRouteSelection Deactive...       
        dep_runwayselection_birdeyeview = false;

        //......Path Added in Aircraft........//

        if (dep_runwayselected == 1)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(0))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 34R";
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(0).gameObject;
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "34R");
            RadarManagerScript.instance.TowardsRunWay34R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 2)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(0))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16R");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16R";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(0).gameObject;
            RadarManagerScript.instance.TowardsRunWay16R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 3)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(0))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16L");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16L";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(0).gameObject;
            RadarManagerScript.instance.TowardsRunWay16L(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        dep_runwayselected = 0;   //..........After 1st dep plane enable other plane 34R/16L/16R Comand...............//

        //..................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().GroundVehiclesFadeOut();
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PushBackCalltoMove());
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<RadarScript>().dep_isAirCraftIRunway = false;
        //.....Route Must be Add in Aircraft According to selected Route....
        //...................By Basant.........................................
        
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-A");  // plane no. has to be changed
        References(GameManagerScript.instanceGMS.currentPlaneActive,gNDSound);
        ATCAudioRunwaySelectonForDep(GameManagerScript.instanceGMS.currentPlaneActive, planeNo, runwayNo);

        //.........................................................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().towardsTerminal = null;
        RadarManagerScript.instance.SetTerminal(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
    }
    public void Select_Dep_B_ActiveRoute() //.......Select Departure B ActiveButton..
    {
        dep_C_Activebutton.SetActive(false);
        dep_A_Activebutton.SetActive(false);
        dep_B_Activebutton.SetActive(false);

        dep_runwayrouteselection.SetActive(false); //....RunwayRouteSelection Deactive...//        
        dep_runwayselection_birdeyeview = false;

        //......Path Added in Aircraft........//

        if (dep_runwayselected == 1)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(1))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "34R");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 34R";
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(1).gameObject;
            RadarManagerScript.instance.TowardsRunWay34R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 2)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(1))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16R");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16R";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(1).gameObject;
            RadarManagerScript.instance.TowardsRunWay16R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 3)
        {

            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(1))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }

            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16L");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16L";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(1).gameObject;
            RadarManagerScript.instance.TowardsRunWay16L(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);       
        dep_runwayselected = 0;   //..........After 1st dep plane enable other plane 34R/16L/16R Comand...............//
        //..................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().GroundVehiclesFadeOut();
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PushBackCalltoMove());
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<RadarScript>().dep_isAirCraftIRunway = false;
        //.....Route Must be Add in Aircraft According to selected Route....//

        //...................By basant..................................//
        
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-B");  // plane no. has to be changed
        References(GameManagerScript.instanceGMS.currentPlaneActive, gNDSound);
        ATCAudioRunwaySelectonForDep(GameManagerScript.instanceGMS.currentPlaneActive, planeNo, runwayNo);
        //...............................................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().towardsTerminal = null;
        RadarManagerScript.instance.SetTerminal(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
    }
    public void Select_Dep_C_ActiveRoute() //.......Select Departure C ActiveButton..
    {
        dep_C_Activebutton.SetActive(false);
        dep_A_Activebutton.SetActive(false);
        dep_B_Activebutton.SetActive(false);

        dep_runwayrouteselection.SetActive(false); //....RunwayRouteSelection Deactive...//        
        dep_runwayselection_birdeyeview = false;

        //......Path Added in Aircraft........//

        if (dep_runwayselected == 1)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "34R");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 34R";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(0).GetChild(2).gameObject;
            RadarManagerScript.instance.TowardsRunWay34R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 2)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16R");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16R";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(1).GetChild(2).gameObject;
            RadarManagerScript.instance.TowardsRunWay16R(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        else if (dep_runwayselected == 3)
        {
            foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(2))
            {
                if (child.tag == "CirclePoint")
                {
                    GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                }
            }
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "16L");
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
            GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 16L";

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).GetChild(2).gameObject;
            RadarManagerScript.instance.TowardsRunWay16L(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
        }
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        dep_runwayselected = 0;   //..........After 1st dep plane enable other plane 34R/16L/16R Comand...............//
        //..................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().GroundVehiclesFadeOut();
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PushBackCalltoMove());
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<RadarScript>().dep_isAirCraftIRunway = false;

        //.....Route Must be Add in Aircraft According to selected Route....
        //......................By basant...............................//

        
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-C");  // plane no. has to be changed

        References(GameManagerScript.instanceGMS.currentPlaneActive, gNDSound);
        ATCAudioRunwaySelectonForDep(GameManagerScript.instanceGMS.currentPlaneActive, planeNo, runwayNo);
        //...............................................................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().towardsTerminal = null;
        RadarManagerScript.instance.SetTerminal(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
    }

    #endregion

    #region ClearTaxiWay And Standby

    public IEnumerator IMaskOnForCT_SB(Transform airplaneTransform)
    {
        yield return new WaitForSeconds(15f);
        airplaneTransform.GetComponent<RadarScript>().dep_isAirCraft_CT_SB = true;
        Dep_Mask_Blue_On(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber);
        Select_Dep_Cleartotaxiway_standby(airplaneTransform, false);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber));
        //..................................................//
    }
    public void Select_Dep_Cleartotaxiway_standby(Transform airplaneTransform, bool isOnClick) //.......Select ClearTaxiWay Deactive Button..
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_isAirCraft_CT_SB && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            dep_cleartotaxi_standby.SetActive(true); //...Clear to taxi UI on.   
            airplaneTransform.GetComponent<AircraftScripts>().PushBackMain.gameObject.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    dep_cleartotaxi_standby.SetActive(false); //...Clear to taxi UI off.
                }
            }
            else
            {
                dep_cleartotaxi_standby.SetActive(false); //...Clear to taxi UI off.
            }
        }
    }
    public void Select_Dep_CleartotaxiDeactiveButton() //.......Select ClearTaxiWay Deactive Button..
    {
        dep_cleartotaxi_activebutton.SetActive(true);
        dep_standby_activebutton_CT.SetActive(false);
    }
    public void Select_StandByDeactiveButton_CT() //.......Select Standby_CT Deactive Button..
    {
        dep_standby_activebutton_CT.SetActive(true);
        dep_cleartotaxi_activebutton.SetActive(false);
    }
    public void Select_Dep_Cleartotaxi_AeactiveButton() //.......Select ClearTaxiWay Aeactive Button..
    {
        //.................divyansh.....................//
        string startPoint = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNumberStart;
        PictogramSpots.instance.ChangeSpotColor(startPoint, false);
        //..............................................//

        ////...............................................................Ashish........................................................................//
        //GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(1).gameObject.SetActive(true);
        //GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(0).GetComponent<Collider>().enabled = true;
        //GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = true;
        ////..............................................................................................................................................//
        dep_cleartotaxi_activebutton.SetActive(false);
        dep_standby_activebutton_CT.SetActive(false);
        dep_cleartotaxi_standby.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().CleartotaxiWay();
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_CT_SB = false;

        Dep_AirplaneStatusIconHandling(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip, 1); //......Departure AirplaneStatus......//
        //Dep_Taxi(GameManagerScript.instanceGMS.currentPlaneActive);

        //........By basant.............
        References(GameManagerScript.instanceGMS.currentPlaneActive, gNDSound);
        
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureClearToTexi(planeNo, runwayNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureClearToTexiAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);

        StartCoroutine(DepClearToTextiAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    public void Select_StandBy_ActiveButton_CT() //.......Select Standby_CT Aeactive Button..
    {
        dep_standby_activebutton_CT.SetActive(false);
        dep_cleartotaxi_activebutton.SetActive(false);
        dep_cleartotaxi_standby.SetActive(false);
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_CT_SB = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().Recall_CT_and_SB();
        
        //......by basant...............
        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.StandByText(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        //Invoke("DepStandByAgain", 15);
        StartCoroutine(DepStandByAgain(GameManagerScript.instanceGMS.currentPlaneActive));

        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);

        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.StandByTextAudio(planeNoClipDep,dEPSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);
    }
    
    //...........By basant............
    IEnumerator DepStandByAgain(int _PlaneNo)
    {
        yield return new WaitForSeconds(15f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.StandByTextAgain(planeNo);

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.StandByTextAgainAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_PlaneNo);
    }

    IEnumerator DepClearToTextiAgain(int _clearToTexiPlaneNo)
    {
        yield return new WaitForSeconds(15f);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_clearToTexiPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_clearToTexiPlaneNo, _pilotSound);

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureClearToTexiAgain(planeNo, runwayNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureClearToTexiAgainAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_clearToTexiPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_clearToTexiPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_clearToTexiPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_clearToTexiPlaneNo);
    }
    //..............................//

    //...........................Before clear to texi...................//
    internal IEnumerator ATC_BeforeClearToTexi(int _PlaneNo)
    {
        yield return new WaitForSeconds(0f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureReqTexi(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DepartureReqTexiAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_PlaneNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_PlaneNo));
        //..................................................//
    }
    //...............................//

    #endregion

    #region Hold Position / Continue Taxi

    public void HoldPosition_UIOn(Transform airplaneTransform, bool isOnClick)
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_isAirCraft_Hold && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            holdposn_continueposn.SetActive(true);
            holdposition.SetActive(true);
            continuetaxi.SetActive(false);
            holdposition_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    HoldPosnAndContinuePosUIButtonsDeactive();
                }
            }
            else
            {
                HoldPosnAndContinuePosUIButtonsDeactive();
            }
        }
    }
    public void HoldPosnAndContinuePosUIButtonsDeactive()
    {
        holdposn_continueposn.SetActive(false);
        holdposition.SetActive(false);
        continuetaxi.SetActive(false);
    }
    public void HoldPosition_DeactiveButton()
    {
        holdposn_continueposn.SetActive(true);
        holdposition_activebutton.SetActive(true);
        continuetaxi_activebutton.SetActive(false);
    }
    public Coroutine holdCorotine, ContinueCorotine;
    public void StopCorotineHold()
    {
        if (holdCorotine != null)
        {
            print(holdCorotine);            
            StopCoroutine(holdCorotine);
        }
    }
    public void StopCorotineContinue()
    {
        if (ContinueCorotine != null)
        {
            print(ContinueCorotine);           
            StopCoroutine(ContinueCorotine);
        }
    }
    public void HoldPosition_ActiveButton()
    {
        holdposition_activebutton.SetActive(false);
        holdposn_continueposn.SetActive(false);
        continuetaxi_activebutton.SetActive(false);

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().SpeedDownHoldButton());

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_Hold = false;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().depIsHold = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().depIsContinue = false;

        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        holdCorotine = StartCoroutine(GreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, true));

        //............by basant...............//

        ScoreManager.instance.stopTexiingCount++;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().lineUpAndWaitCount++;      //........plane no. has to be changed

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHoldOn(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        StartCoroutine(DepHoldOnAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureHoldOnAudio(planeNoClipDep,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);
    }

    public IEnumerator GreenOnForContinue(int _ContinueplaneNo, float waitTime, bool isAirCraft_Continue)  //..............for continue and hold
    {
        yield return new WaitForSeconds(waitTime);
        if (isAirCraft_Continue)
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().dep_isAirCraft_Continue = true;
            StartCoroutine(ContinueTaxi_UIOn(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, 0, false));

            //.....Penalty for stop Texxing when there is a Long delay......//
            ScoreManager.instance.PenaltyForLongDelay(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<AircraftScripts>().flightNumber);
        }
        else
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().dep_isAirCraft_Hold = true;
            HoldPosition_UIOn(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, false);

            //..........Disable command when atc is open........//
            StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform.GetComponent<AircraftScripts>().PlaneNumber));
            //..................................................//
        }

        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, true);

    }
    public IEnumerator ContinueTaxi_UIOn(Transform airplaneTransform, int waitTime, bool isOnClick)
    {
        yield return new WaitForSeconds(waitTime);
        if (airplaneTransform.GetComponent<RadarScript>().dep_isAirCraft_Continue && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            holdposn_continueposn.SetActive(true);
            holdposition.SetActive(false);
            continuetaxi.SetActive(true);
            continuetaxi_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    HoldPosnAndContinuePosUIButtonsDeactive();
                }
            }
            else
            {
                HoldPosnAndContinuePosUIButtonsDeactive();
            }
        }
    }
    public void ContinueTaxi_DeactiveButton()
    {
        holdposn_continueposn.SetActive(true);
        continuetaxi_activebutton.SetActive(true);
        holdposition_activebutton.SetActive(false);
    }
    public void ContinueTaxi_ActiveButton()
    {
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        holdposn_continueposn.SetActive(false);
        continuetaxi_activebutton.SetActive(false);
        holdposition_activebutton.SetActive(false);

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().SpeedupAfterPuchback());
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_isAirCraft_Continue = false;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().depIsContinue = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().depIsHold = false;

        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().depIsFinalHoldContinueStopTrigger)
        {
            ContinueCorotine = StartCoroutine(GreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, false));
        }
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();

        //.......By basant.......//

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureResumeHoldOn(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        StartCoroutine(DepResumeHoldOnAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureResumeHoldOnAudio(planeNoClipDep,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);

        //.....Stop Co-Routine... Penalty for stop Texxing when there is a Long delay........
        ScoreManager.instance.PenaltyForLongDelayStopCoroutine();
    }

    //.........By basant.........//
    IEnumerator DepHoldOnAgain(int _depHoldPlaneNo)
    {
        yield return new WaitForSeconds(15f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHoldOnAgain(planeNo);

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DepartureHoldOnAgainAudio(planeNoClipDep,_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depHoldPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depHoldPlaneNo);
    }
    IEnumerator DepResumeHoldOnAgain(int _depResumePlaneNo)
    {
        yield return new WaitForSeconds(15f);
        planeNo = GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureResumeHoldOnAgian(planeNo);

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneDep = CommandReceiver.instance.DepartureResumeHoldOnAgianAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depResumePlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depResumePlaneNo);
    }
    #endregion

    #region TowerControlHand_Off

    //........TowerControlHand_Off.............//

    public void TowerControlHand_Off_Call(Transform airplaneTransform)
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_TowerControlHand_Off && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            towercontrol_handoff.SetActive(true);
        }
        else
        {
            towercontrol_handoff.SetActive(false);
        }
    }
    public void TowerControlHand_Off_DeactiveButton()  //....Click On TowerControlHand_Off DeactiveButton.....//
    {
        towercontrol_handOff_activebutton.SetActive(true);
    }
    public void TowerControlHand_Off_ActiveButton()  //....Click On TowerControlHand_Off ActiveButton.....//
    {
        towercontrol_handOff_activebutton.SetActive(false);
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        towercontrol_handOff_activebutton.SetActive(false);
        towercontrol_handoff.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_TowerControlHand_Off = false;

        //........By basant.....//
        //...Bones Add...//
        ScoreManager.instance.ClickForBonus(300);
        References(GameManagerScript.instanceGMS.currentPlaneActive, gNDSound);       
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTowerCtrlHandOff(planeNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
     
        audioClipsPlaneDep = CommandReceiver.instance.DepartureTowerCtrlHandOffAudio(planeNoClipDep, gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);

        StartCoroutine(DepTowerCtrlHandOffAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    //........................................//

    //.......By basant.......//
    IEnumerator DepTowerCtrlHandOffAgain(int _depTCHPlaneNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depTCHPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_depTCHPlaneNo, _pilotSound);

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTowerCtrlHandOffAgain(planeNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureTowerCtrlHandOffAgainAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depTCHPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depTCHPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depTCHPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depTCHPlaneNo);

        StartCoroutine(TokyoTwrCtrlHandOff(_depTCHPlaneNo, 15));
    }
    public IEnumerator TokyoTwrCtrlHandOff(int _depGndToTwrPlaneNo, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //....2st shift Dep plane 1 strip....//
        //................................2nd shift ............................//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[_depGndToTwrPlaneNo].transform, 0.4f);
        GameManagerScript.instanceGMS.PlaneStrip[_depGndToTwrPlaneNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = TWR.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[_depGndToTwrPlaneNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = TWR.GetComponent<ATCBarUIScript>().controlBarColor;
        //......................................//

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depGndToTwrPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_depGndToTwrPlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.TokyoTowerCtrlHandOff(planeNo);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[_depGndToTwrPlaneNo].GetComponent<RadarScript>().currentATC = "TWR";
        if (_depGndToTwrPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "TWR";
        }
        audioClipsPlaneDep = CommandReceiver.instance.TokyoTowerCtrlHandOffAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depGndToTwrPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depGndToTwrPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depGndToTwrPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depGndToTwrPlaneNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_depGndToTwrPlaneNo));
        //..................................................//
    }
    //....................//
    #endregion

    #region Take-off Approval
    //........Take-off Approval.............//
    public void TakeoffApproval_AllThree(Transform airplaneTransform)
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_TakeoffApproval && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            takeoffapproval_Holdshort_lineupwait.SetActive(true);
        }
        else
        {
            takeoffapproval_Holdshort_lineupwait.SetActive(false);
        }
    }

    public void TakeoffApproval_DeactiveButton()
    {
        takeoffapproval_activebutton.SetActive(true);
        Holdshort_activebutton.SetActive(false);
        lineupwait_activebutton.SetActive(false);
    }
    public void HoldShortRWY_DeactiveButton()
    {
        Holdshort_activebutton.SetActive(true);
        takeoffapproval_activebutton.SetActive(false);
        lineupwait_activebutton.SetActive(false);
    }
    public void LineupWait_DeactiveButton()
    {
        lineupwait_activebutton.SetActive(true);
        takeoffapproval_activebutton.SetActive(false);
        Holdshort_activebutton.SetActive(false);

    }
    public void TakeoffApproval_ActiveButton()
    {
        takeoffapproval_activebutton.SetActive(false);
        Holdshort_activebutton.SetActive(false);
        lineupwait_activebutton.SetActive(false);

        takeoffapproval_Holdshort_lineupwait.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_TakeoffApproval = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().goandfly = true;

        //........Take off Approval....status...//

        Dep_AirplaneStatusIconHandling(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip, 3); //......Departure AirplaneStatus......//
        //Dep_TakeOff(GameManagerScript.instanceGMS.currentPlaneActive);
        //......................................//

        StartCoroutine(WaitForTextInTakeOffApproval(GameManagerScript.instanceGMS.currentPlaneActive));

        //...............Jugaad until new path point is not given...............//
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("34R"))
        {
            dep_runwayselected = 1;
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("16R"))
        {
            dep_runwayselected = 2;
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("16L"))
        {
            dep_runwayselected = 3;
        }

        if (dep_runwayselected == 1)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep34R_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg34R_Air();
            }
            //GameManagerScript.instanceGMS.Dep34R_Air();
        }
        else if (dep_runwayselected == 2)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep16R_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg16R_Air();
            }
            //GameManagerScript.instanceGMS.Dep16R_Air();
        }
        else if (dep_runwayselected == 3)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep16L_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg16L_Air();
            }
            //GameManagerScript.instanceGMS.Dep16L_Air();
        }

        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);

        //........by basant...//
        int _planeNo = GameManagerScript.instanceGMS.currentPlaneActive;

        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().lineUpAndWaitCount > 0)   //........plane no. has to be changed
        {
            ScoreManager.instance.ClickForBonus(200);
        }
        else
        {
            ScoreManager.instance.ClickForBonus(500);
        }
        References(_planeNo, tWRSound);

        //if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
        //{
            string str = RadarManagerScript.instance.airSpeed.text;
            string _windDir1 = str.Substring(0, 3);
            string _windForce1 = str.Substring(6, 2);
            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTakeOff(planeNo, runwayNo, _windDir1, _windForce1);
            TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

            audioClipsPlaneDep = CommandReceiver.instance.DepartureTakeOffAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _windDir1Clip, _windDir2Clip, _windDir3Clip, _windForce1Clip, _windForce2Clip, tWRSound);
            GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
            SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());

            GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, TWR);

            StartCoroutine(DepTakeOffAgain(_planeNo, _windDir1, _windForce1));

        //}
        //else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
        //{
        //    TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.TakeOffCancel(planeNo);
        //    TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        //    GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        //    audioClipsPlaneDep = CommandReceiver.instance.TakeOffCancelAudio(planeNoClipDep, _pilotSound);
        //    GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        //    SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());

        //    GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        //    StartCoroutine(AreYouAbleToTexi(_planeNo));
        //}
    }

    public void TakeOffCancelATC(int _planeNo)
    {
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().transform.GetChild(0).GetChild(5).gameObject.GetComponent<SpriteRenderer>().sprite = RedspriteEmg;

        StartCoroutine(TakeOffCancelATC_Coroutine(_planeNo));
    }
    public IEnumerator TakeOffCancelATC_Coroutine(int _planeNo)
    {
        yield return new WaitForSeconds(4);

        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
        {
            planeNo = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;

            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.TakeOffCancel(planeNo);
            TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

            GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

            audioClipsPlaneDep = CommandReceiver.instance.TakeOffCancelAudio(planeNoClipDep, _pilotSound);
            GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
            SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());

            GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

            StartCoroutine(AreYouAbleToTexi(_planeNo));
        }
    }

    IEnumerator AreYouAbleToTexi(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.CanTexiQues();

        audioClipsPlaneDep = CommandReceiver.instance.CanTexiQuesAudio(tWRSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());

        GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, TWR);
        StartCoroutine(WeAreAbleToTexi(_planeNo));
    }
    IEnumerator WeAreAbleToTexi(int _planeNo)
    {
        yield return new WaitForSeconds(12);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.CanTexiAns();

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        audioClipsPlaneDep = CommandReceiver.instance.CanTexiAnsAudio(_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());

        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        yield return new WaitForSeconds(10);

        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
    }
    IEnumerator WaitForTextInTakeOffApproval(int _planeNo)
    {
        yield return new WaitForSeconds(20);
        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0)
        {
            GameManagerScript.instanceGMS.PlaneList[_planeNo].transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
            GameManagerScript.instanceGMS.PlaneList[_planeNo].transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;
        }
    }
    IEnumerator WaitForTextInLineUpAndWait(int _linePlaneNo)
    {
        yield return new WaitForSeconds(20);
        if (GameManagerScript.instanceGMS.PlaneList[_linePlaneNo].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0)
        {
            GameManagerScript.instanceGMS.PlaneList[_linePlaneNo].transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
            GameManagerScript.instanceGMS.PlaneList[_linePlaneNo].transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;
        }
    }
    public void HoldShortRWY_ActiveButton()
    {
        takeoffapproval_activebutton.SetActive(false);
        Holdshort_activebutton.SetActive(false);
        lineupwait_activebutton.SetActive(false);
        takeoffapproval_Holdshort_lineupwait.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_TakeoffApproval = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().goandfly = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().holdshort = true;

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed = 0f;
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0f;            
            StartCoroutine(RecallAllthreefromHold(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform));
        }
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);

        //..........BY basant.........//
        References(GameManagerScript.instanceGMS.currentPlaneActive, tWRSound);
        
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.HoldShortOfRunway(planeNo, runwayNo);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneDep = CommandReceiver.instance.HoldShortOfRunwayAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);

        StartCoroutine(HoldShortOfRunAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    public IEnumerator RecallAllthreefromHold(Transform airplaneTransform)
    {
        yield return new WaitForSeconds(45f);
        airplaneTransform.gameObject.GetComponent<RadarScript>().dep_TakeoffApproval = true;
        TakeoffApproval_AllThree(airplaneTransform);
        Dep_Mask_Blue_On(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber));
        //..................................................//
    }
    public void LineupWait_ActiveButton()
    {
        takeoffapproval_activebutton.SetActive(false);
        Holdshort_activebutton.SetActive(false);
        lineupwait_activebutton.SetActive(false);
        takeoffapproval_Holdshort_lineupwait.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_TakeoffApproval = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().goandfly = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().linewait = true;
        
        StartCoroutine(WaitForTextInLineUpAndWait(GameManagerScript.instanceGMS.currentPlaneActive));

        //...............Jugaad until new path point is not given...............//
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("34R"))
        {
            dep_runwayselected = 1;
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("16R"))
        {
            dep_runwayselected = 2;
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().AirPoint[0].gameObject.name.Contains("16L"))
        {
            dep_runwayselected = 3;
        }
        //...................................................................//


        if (dep_runwayselected == 1)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep34R_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg34R_Air();
            }
           
        }
        else if (dep_runwayselected == 2)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep16R_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg16R_Air();
            }
           
        }
        else if (dep_runwayselected == 3)
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
            {
                GameManagerScript.instanceGMS.Dep16L_Air();
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.TakeOffCancel)
            {
                GameManagerScript.instanceGMS.DepEmg16L_Air();
            }
            
        }
        //if (dep_runwayselected == 1)
        //{
        //    GameManagerScript.instanceGMS.Dep34R_Air();
        //}
        //else if (dep_runwayselected == 2)
        //{
        //    GameManagerScript.instanceGMS.Dep16R_Air();
        //}
        //else if (dep_runwayselected == 3)
        //{
        //    GameManagerScript.instanceGMS.Dep16L_Air();
        //}
        //.....................................................................//
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);

        //..........BY basant.........
        References(GameManagerScript.instanceGMS.currentPlaneActive, tWRSound);
        
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.LineUpAndWait(planeNo, runwayNo);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneDep = CommandReceiver.instance.LineUpAndWaitAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);

        StartCoroutine(LineUpWaitAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    //........Takeoff Approva lOnly.........//

    public IEnumerator TakeoffApprovalOnlyOneButton(Transform airplaneTransform, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (airplaneTransform.GetComponent<RadarScript>().dep_TakeoffApprovalOnly && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            takeoffapprovalOnly.SetActive(true);
        }
        else
        {
            takeoffapprovalOnly.SetActive(false);
        }
    }

    public IEnumerator TakeoffApprovalOnlyIMask(int _planeNo)
    {
        yield return new WaitForSeconds(0f);
        Dep_Mask_Blue_On(_planeNo);
    }

    public void TakeoffApprovalOnly_DeactiveButton()
    {
        takeoffapprovalOnly_activebutton.SetActive(true);
    }
    public void TakeoffApprovalOnly_ActiveButton()
    {
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentDepPlaneNo);
        takeoffapprovalOnly_activebutton.SetActive(false);
        takeoffapprovalOnly.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_TakeoffApprovalOnly = false;
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().TakeoffApprovedSpeed(30f));

        //..........by Basant............//

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().lineUpAndWaitCount > 0)   //........plane no. has to be changed
        {
            ScoreManager.instance.ClickForBonus(200);
        }
        else
        {
            ScoreManager.instance.ClickForBonus(500);
        }
        References(GameManagerScript.instanceGMS.currentPlaneActive, tWRSound);
        
        string str = RadarManagerScript.instance.airSpeed.text;
        string _windDir1 = str.Substring(0, 3);
        string _windForce1 = str.Substring(6, 2);
        print("_windForce1 ..." + _windForce1);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTakeOff(planeNo, runwayNo, _windDir1, _windForce1);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        audioClipsPlaneDep = CommandReceiver.instance.DepartureTakeOffAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _windDir1Clip, _windDir2Clip, _windDir3Clip, _windForce1Clip, _windForce2Clip,tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        //..................//
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);

        StartCoroutine(DepTakeOffAgain(GameManagerScript.instanceGMS.currentPlaneActive, _windDir1, _windForce1));
        //.....................................//
    }
    //......................................//

    public void Takeoffspecialcase()
    {
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;
    }
    //............By basant.........
    IEnumerator HoldShortOfRunAgain(int _holdShortOfRunwayPlaneNo)
    {
        yield return new WaitForSeconds(14f);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_holdShortOfRunwayPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_holdShortOfRunwayPlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.HoldShortOfRunwayAgain(planeNo, runwayNo);        
        audioClipsPlaneDep = CommandReceiver.instance.HoldShortOfRunwayAgainAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_holdShortOfRunwayPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_holdShortOfRunwayPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_holdShortOfRunwayPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_holdShortOfRunwayPlaneNo);

        StartCoroutine(ReadyForDeparture(_holdShortOfRunwayPlaneNo));

    }
    IEnumerator LineUpWaitAgain(int _lineUpWaitPlaneNo)
    {
        yield return new WaitForSeconds(14f);

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_lineUpWaitPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_lineUpWaitPlaneNo, _pilotSound);        
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.LineUpAndWaitAgain(planeNo, runwayNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.LineUpAndWaitAgainAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_lineUpWaitPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_lineUpWaitPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_lineUpWaitPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_lineUpWaitPlaneNo);

        StartCoroutine(ReadyForDeparture(_lineUpWaitPlaneNo));
    }

    IEnumerator ReadyForDeparture(int _readyDepPlaneNo)
    {
        yield return new WaitForSeconds(13f);

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_readyDepPlaneNo].GetComponent<RadarScript>().pilotSound;        
        References(_readyDepPlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ReadyForDep(planeNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.ReadyForDepAudio(planeNoClipDep, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_readyDepPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_readyDepPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_readyDepPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_readyDepPlaneNo);
    }
    IEnumerator DepTakeOffAgain(int _depTakeOffPlaneNo, string _windDir1, string _windForce1)
    {
        yield return new WaitForSeconds(15f);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depTakeOffPlaneNo].GetComponent<RadarScript>().pilotSound;        
        References(_depTakeOffPlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTakeOffAgain(runwayNo, _windDir1, _windForce1, planeNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureTakeOffAgainAudio(planeNoClipDep, runwayNoDepClip1, runwayNoDepClip2, runwayNoDepClip3, _windDir1Clip, _windDir2Clip, _windDir3Clip, _windForce1Clip, _windForce2Clip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depTakeOffPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depTakeOffPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depTakeOffPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depTakeOffPlaneNo);
        yield return new WaitForSeconds(10f);
        StartCoroutine(LobbySounds.ins.ClearForTakeOffLobby(_depTakeOffPlaneNo));
    }
    //..................//
    #endregion

    #region DepartureHandOff
    //............DepartureHandOff.............//

    public void DepartureHandOff_Call(Transform airplaneTransform)
    {
        //....3rd shift Dep plane 1 strip....//
        if (airplaneTransform.GetComponent<RadarScript>().dep_DepartureHandOff && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            departure_handOff.SetActive(true);
        }
        else
        {
            departure_handOff.SetActive(false);
            departure_handOff_activebutton.SetActive(false);
        }
    }
    public void DepartureHandOff_DeactiveButton()
    {
        departure_handOff_activebutton.SetActive(true);
    }
    public void DepartureHandOff_ActiveButton()
    {       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        departure_handOff_activebutton.SetActive(false);
        departure_handOff.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_DepartureHandOff = false;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().dep_DepCtrlHandOffClick = true;
        //.........By Basant..........//

        //...Bones Add...//
        ScoreManager.instance.ClickForBonus(200);
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentDepPlaneNo, " >>[TWR]TAKE");  // plane no. has to be changed

        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHandOff(planeNo);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(tWRSound);

        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentDepPlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureHandOffAudio(planeNoClipDep, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentDepPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentDepPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentDepPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentDepPlaneNo, TWR);

        StartCoroutine(DepHandOffAgain(GameManagerScript.instanceGMS.currentDepPlaneNo));
    }
    public IEnumerator DepartureHandOff_AutoClosed(int _PlaneNo)
    {
        yield return new WaitForSeconds(0f);       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].transform, false);

        departure_handOff_activebutton.SetActive(false);
        departure_handOff.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_DepartureHandOff = false;
        //...Penalty Add...//
        //.....basant...//
        ScoreManager.instance.forgotDepHandoffCount++;
        StartCoroutine(DepInAir(_PlaneNo, 0));
    }
    //........................................//
    //...........By basant..........//
    IEnumerator DepHandOffAgain(int _depHandOffPlaneNo)
    {
        yield return new WaitForSeconds(15f);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHandOffAgainGoodDay();
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depHandOffPlaneNo].GetComponent<RadarScript>().pilotSound;
        
        StartCoroutine(TWRRadarCtrlAgainAgain(_depHandOffPlaneNo));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureHandOffAgainGoodDayAudio(_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depHandOffPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depHandOffPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depHandOffPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depHandOffPlaneNo);

    }
    IEnumerator TWRRadarCtrlAgainAgain(int _TwrRedarCtrlPlaneNo)
    {
        yield return new WaitForSeconds(15f);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureRadarCtrlAgainAgain();
        
        StartCoroutine(DepInAir(_TwrRedarCtrlPlaneNo, 18));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureRadarCtrlAgainAgainAudio(tWRSound);
        GameManagerScript.instanceGMS.PlaneList[_TwrRedarCtrlPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_TwrRedarCtrlPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_TwrRedarCtrlPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_TwrRedarCtrlPlaneNo, TWR);
    }
    IEnumerator DepInAir(int _depInAirPlaneNo, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //..............................4rd shift............//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[_depInAirPlaneNo].transform, 1.05f);
        GameManagerScript.instanceGMS.PlaneStrip[_depInAirPlaneNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = DEP.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[_depInAirPlaneNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = DEP.GetComponent<ATCBarUIScript>().controlBarColor;
        //..................................................// 
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_depInAirPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_depInAirPlaneNo, _pilotSound);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureInAir(planeNo, _altNew);
        DEP.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[_depInAirPlaneNo].GetComponent<RadarScript>().currentATC = "DEP";
        if (_depInAirPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "DEP";
        }
        audioClipsPlaneDep = CommandReceiver.instance.DepartureInAirAudio(planeNoClipDep, _altNew1Clip, _thousandClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_depInAirPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_depInAirPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_depInAirPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_depInAirPlaneNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_depInAirPlaneNo));
        //..................................................//
    }
    #endregion

    #region SID_flight_continued
    //............SID_flight_continued.............//

    public void ContinueOwnNav_Call(Transform airplaneTransform)
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_ContinueOwnNav && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            dep_continueownnav.SetActive(true);
        }
        else
        {
            dep_continueownnav.SetActive(false);
            dep_continueownnav_activebutton.SetActive(false);
        }
    }
    public void ContinueOwnNav_DeactiveButton()
    {
        dep_continueownnav_activebutton.SetActive(true);
    }
    public void ContinueOwnNav_ActiveButton()
    {        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        dep_continueownnav_activebutton.SetActive(false);
        dep_continueownnav.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_ContinueOwnNav = false;

        //...Bones Add...//

        ScoreManager.instance.ClickForBonus(300);
        int _soundIndex = ConvertAtcSoundsIntoNo(dEPSound);

        //...........By basant ............//
        planeNo = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureRadarCtrl(planeNo);
        DEP.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        AudioClip planeNoClipDep = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        StartCoroutine(DepRadarCtrl(GameManagerScript.instanceGMS.currentPlaneActive));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureRadarCtrlAudio(planeNoClipDep, dEPSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, DEP);
    }
    public IEnumerator ContinueOwnNav_AutoClosed(int _PlaneNo)
    {
        yield return new WaitForSeconds(60f);       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].transform, false);
        dep_continueownnav_activebutton.SetActive(false);
        dep_continueownnav.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().dep_ContinueOwnNav = false;
        NintendoController.instance.NpadButtonB2();  // divyansh
    }
    //........................................//
    //..........By basant ................
    IEnumerator DepRadarCtrl(int _redarCtrlPlaneNo)
    {
        yield return new WaitForSeconds(15f);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureRadarCtrlAgain();
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_redarCtrlPlaneNo].GetComponent<RadarScript>().pilotSound;
        
        StartCoroutine(DEPRadarCtrlAgainAgain(_redarCtrlPlaneNo));
        audioClipsPlaneDep = CommandReceiver.instance.DepartureRadarCtrlAgainAudio(_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_redarCtrlPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_redarCtrlPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_redarCtrlPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_redarCtrlPlaneNo);
    }
    IEnumerator DEPRadarCtrlAgainAgain(int _redarCtrlAgainPlaneNo)
    {
        yield return new WaitForSeconds(15f);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureRadarCtrlAgainAgain();
        
        audioClipsPlaneDep = CommandReceiver.instance.DepartureRadarCtrlAgainAgainAudio(dEPSound);
        GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_redarCtrlAgainPlaneNo, DEP);
    }
    #endregion

    #region Outside Control Zone

    //............Outside Control Zone.............//

    public void RadarControlOff_Call(Transform airplaneTransform)
    {
        if (airplaneTransform.GetComponent<RadarScript>().dep_RadarControlOff && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            dep_radarcontroloff.SetActive(true);
        }
        else
        {
            dep_radarcontroloff.SetActive(false);
            dep_radarcontroloff_activebutton.SetActive(false);
        }
    }
    public void RadarControlOff_DeactiveButton()
    {
        dep_radarcontroloff_activebutton.SetActive(true);
    }
    public void RadarControlOff_ActiveButton()
    {        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        dep_radarcontroloff_activebutton.SetActive(false);
        dep_radarcontroloff.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().dep_RadarControlOff = false;

        //...Bones Add...//
        ScoreManager.instance.ClickForBonus(200);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().dep_RadarCtrlClick = true;
        //.........By basant...........
        References(GameManagerScript.instanceGMS.currentPlaneActive,dEPSound);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ChooseRadarCtrl(planeNo, _flyDir, _wayPoint);
        DEP.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        StartCoroutine(ChooseRadarControAgain(GameManagerScript.instanceGMS.currentPlaneActive, _flyDir, _wayPoint, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _wayPointClip));
        audioClipsPlaneDep = CommandReceiver.instance.ChooseRadarCtrlAudio(planeNoClipDep, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _wayPointClip, dEPSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, DEP);
    }
    public IEnumerator RadarControlOff_AutoClosed(int _PlaneNo)
    {
        yield return new WaitForSeconds(0f);        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].transform, false);

        dep_radarcontroloff_activebutton.SetActive(false);
        dep_radarcontroloff.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().dep_RadarControlOff = false;
        //...Penalty Add...//
    }
    //........................................//
    //........By Basant..............
    IEnumerator ChooseRadarControAgain(int _redarCtrlAgainPlaneNo, string _flyDir, string _wayPoint, AudioClip _flyDir1Clip, AudioClip _flyDir2Clip, AudioClip _flyDir3Clip, AudioClip _wayPointClip)
    {
        yield return new WaitForSeconds(15f);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<RadarScript>().pilotSound;
        References(_redarCtrlAgainPlaneNo, _pilotSound);

        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ChooseRadarCtrlAgain(planeNo, _flyDir, _wayPoint);
       
        audioClipsPlaneDep = CommandReceiver.instance.ChooseRadarCtrlAgainAudio(planeNoClipDep, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _wayPointClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_redarCtrlAgainPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_redarCtrlAgainPlaneNo);
    }
    #endregion

    #region Departure Mask On Off
    //.........For Departure Mask ON OFF.............//

    public int ChangeDepPlaneNoForStripChange(int _depPlaneNo)
    {
        int actualPlaneStripNo = 0;
        if (_depPlaneNo == 1)
        {
            actualPlaneStripNo = 1;
        }
        if (_depPlaneNo == 4)
        {
            actualPlaneStripNo = 3;
        }
        if (_depPlaneNo == 5)
        {
            actualPlaneStripNo = 0;
        }
        if (_depPlaneNo == 6)
        {
            actualPlaneStripNo = 2;
        }
        if (_depPlaneNo == 7)
        {
            actualPlaneStripNo = 4;
        }
        if (_depPlaneNo == 8)
        {
            actualPlaneStripNo = 5;
        }
        if (_depPlaneNo == 9)
        {
            actualPlaneStripNo = 6;
        }
        return actualPlaneStripNo;
    }

    public void Dep_Mask_Blue_On(int DPNo)
    {
        //DPNo = ChangeDepPlaneNoForStripChange(DPNo);
        //print("DPNo : " + DPNo);
        //Dep_Maskdata = false;
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(0).gameObject.SetActive(true); //....For Departure plane-1 strips.
        
        yellowPlaneDep[DPNo] = StartCoroutine(Dep_Mask_Yellow_On(DPNo));
    }

    public IEnumerator Dep_Mask_Yellow_On(int DPNo)
    {
        yield return new WaitForSeconds(25);

        //Dep_Mask_Blue_Off(DPNo);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        
        RedPlaneDep[DPNo] = StartCoroutine(Dep_Mask_Red_On(DPNo));
        
    }
    public IEnumerator Dep_Mask_Red_On(int DPNo)
    {
        yield return new WaitForSeconds(25);

        //Dep_Mask_Yellow_Off(DPNo);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(2).gameObject.SetActive(true);

        BluePlaneDep[DPNo] = StartCoroutine(Dep_Mask_BlueOn_Again(DPNo));
    }

    public IEnumerator Dep_Mask_BlueOn_Again(int DPNo)
    {
        yield return new WaitForSeconds(25);
        //Dep_Mask_Red_Off(DPNo);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);

        float penaltyAmt = ScoreManager.instance.goalScoreVal * .05f;
        ScoreManager.instance.Penalty((int)penaltyAmt);
        TipsAndAlertController.instance.OnPenalty(Control_Text.instance.delayStr, GameManagerScript.instanceGMS.PlaneList[DPNo].GetComponent<AircraftScripts>().flightNumber);
        yellowPlaneDep[DPNo] = StartCoroutine(Dep_Mask_Yellow_On(DPNo));
    }

    public void Dep_Mask_Blue_Off(int DPNo)
    {
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(0).gameObject.SetActive(false);

        if (yellowPlaneDep[DPNo] != null)
        {
            StopCoroutine(yellowPlaneDep[DPNo]);
        }
    }
    public void Dep_Mask_Yellow_Off(int DPNo)
    {
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(1).gameObject.SetActive(false);

        if (RedPlaneDep[DPNo] != null)
        {
            StopCoroutine(RedPlaneDep[DPNo]);
        }
    }
    public void Dep_Mask_Red_Off(int DPNo)
    {
        GameManagerScript.instanceGMS.PlaneStrip[DPNo].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);

        if (BluePlaneDep[DPNo] != null)
        {
            StopCoroutine(BluePlaneDep[DPNo]);
        }
    }
    public void Dep_Mask_All_Off(int DPNo)
    {
        //DPNo = ChangeDepPlaneNoForStripChange(DPNo);
        
        Dep_Mask_Blue_Off(DPNo);
        Dep_Mask_Yellow_Off(DPNo);
        Dep_Mask_Red_Off(DPNo);        
    }

    public void Dep_Mask_green_On(Transform airPlaneTrans, bool isDepMaskOff) //...for Hold and Continue...//
    {
        if (!isDepMaskOff)
        {
            airPlaneTrans.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(2).GetChild(3).gameObject.SetActive(false);
        }
        else
        {
            airPlaneTrans.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(2).GetChild(3).gameObject.SetActive(true);
        }
    }
    //............................................................//
    #endregion

    #region Airplane Status

    //.........For Airplane Status.............//

    public void Dep_AirplaneStatusIconHandling(Transform flightStrip, int childNo)
    {
        for (int i = 0; i < flightStrip.GetChild(1).childCount; i++)
        {            
            flightStrip.GetChild(1).GetChild(i).gameObject.SetActive(false);            
        }
        flightStrip.GetChild(1).GetChild(childNo).gameObject.SetActive(true);
    }


    //public void Dep_Boarding(int AStatus)
    //{
    //    AStatus = ChangeDepPlaneNoForStripChange(AStatus);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(5).gameObject.SetActive(true);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(7).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(1).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(3).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(0).gameObject.SetActive(false);
    //}
    //public void Dep_PushBack(int AStatus)
    //{
    //    //print("pppppppppppppppppppppppppppp" + AStatus);
    //    AStatus = ChangeDepPlaneNoForStripChange(AStatus);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(7).gameObject.SetActive(true);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(5).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(1).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(3).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(0).gameObject.SetActive(false);
    //}
    //public void Dep_Taxi(int AStatus)
    //{
    //    AStatus = ChangeDepPlaneNoForStripChange(AStatus);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(1).gameObject.SetActive(true);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(5).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(7).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(3).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(0).gameObject.SetActive(false);
    //}
    //public void Dep_TakeOff(int AStatus)
    //{
    //    AStatus = ChangeDepPlaneNoForStripChange(AStatus);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(3).gameObject.SetActive(true);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(5).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(7).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(1).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(0).gameObject.SetActive(false);
    //}
    //public void Dep_InAir(int AStatus)
    //{
    //    AStatus = ChangeDepPlaneNoForStripChange(AStatus);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(0).gameObject.SetActive(true);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(5).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(7).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(1).gameObject.SetActive(false);
    //    _Canvas.transform.GetChild(4).GetChild(0).GetChild(AStatus).GetChild(1).GetChild(3).gameObject.SetActive(false);

    //}

    //............................................//

    #endregion

    #region Path Selection Lines

    //.........For Path Selection Lines.............//

    #region Path 54_34R Line UI

    //...54_34R Line...//

    public void AllSpots_54_34R()
    {

        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_54_34R_Path1()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_54_34R_Path2()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_54_34R_Path3()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject;
    }

    public void Spots_54_34R_Path123()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    }

    public void AllSpots_54_34R_False()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    #endregion

    #region Path 54_16R Line UI
    //.......54_16R Line.......//

    public void AllSpots_54_16R()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_54_16R_Path1()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_54_16R_Path2()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_54_16R_Path3()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject;

    }
    public void Spots_54_16R_Path123()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    }

    public void AllSpots_54_16R_False()
    {
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    #endregion

    #region Path 54_16L Line UI
    //.......54_16L Line.......//

    public void AllSpots_54_16L()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_54_16L_Path1()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_54_16L_Path2()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_54_16L_Path3()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

        selectedPathGameObj = PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject;
    }
    public void Spots_54_16L_Path123()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    }

    public void AllSpots_54_16L_False()
    {
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    #endregion

    #region Path 34R 16R 16L All Close Line UI
    //.......All OFF....//

    public void AllSpotsLine_Off()
    {
        PathselectionLine.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    #endregion

    //..............................................//
    #endregion

    #endregion

    //......................................................................................//
    //.............................Arrival Process........................................//

    #region Arrival Procerss

    #region Arrival RunwaySelection

    //.......Runway Selectin 34R,34L......// 

    public void Arv_RunwaySelection(Transform planeTransform, bool isOnClick)
    {
        //..............//
        arv_34R_runwayactivebutton.SetActive(false);
        arv_34L_runwayactivebutton.SetActive(false);


        if (planeTransform.GetComponent<RadarScript>().isAirCraftIRunway && planeTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_runwayselection_birdeyeview = true;
            
            for (int i = 0; i < totalRunwayUI.Count; i++)
            {
                totalRunwayUI[i].SetActive(false);
                totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
            }

            for (int i = 0; i < totalRunwayUILine.Count; i++)
            {
                totalRunwayUILine[i].SetActive(false);
            }

            totalRunwayUI[0].SetActive(true);
            totalRunwayUI[1].SetActive(true);

            arv_34R_runwayactivebutton.SetActive(false);
            arv_34L_runwayactivebutton.SetActive(false);

            arv_runwayselection.SetActive(true);  //........Active Runway Selectin 34R,34L......//            
        }
        else
        {
            if (!isOnClick)
            {
                if (!planeTransform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    arv_runwayselection_birdeyeview = false;

                    arv_34R_runwayactivebutton.SetActive(false);
                    arv_34L_runwayactivebutton.SetActive(false);

                    arv_runwayselection.SetActive(false);  //........Active Runway Selectin 34R,34L......//   

                }
            }
            else
            {
                arv_runwayselection_birdeyeview = false;

                arv_34R_runwayactivebutton.SetActive(false);
                arv_34L_runwayactivebutton.SetActive(false);

                arv_runwayselection.SetActive(false);  //........Active Runway Selectin 34R,34L......//  

            }


        }
    }
    public void Arv_34R_RunwaySelection_DeactiveButton()
    {
        arv_34R_runwayactivebutton.SetActive(true);
        arv_34L_runwayactivebutton.SetActive(false);
        //.....Runway 34R Ui...//

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }
        totalRunwayUILine[0].SetActive(true);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        totalRunwayUI[0].transform.GetChild(1).gameObject.SetActive(true);

        //......................//
    }
    public void Arv_34L_RunwaySelection_DeactiveButton()
    {
        arv_34L_runwayactivebutton.SetActive(true);
        arv_34R_runwayactivebutton.SetActive(false);

        //.....Runway 34R Ui...//
        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }
        totalRunwayUILine[1].SetActive(true);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        totalRunwayUI[1].transform.GetChild(1).gameObject.SetActive(true);
        //......................//
    }

    //.............By basant.............//
    public void CheckRunwaySignal(int _planeNo, int runwayNoIndex)
    {
        //.........plane safe unsafe and danger condition........//
        if (currentLevelSelected.tailWindAndEmgConditionForRunwaySignal[runwayNoIndex].runwayGameObject.transform.GetChild(3).gameObject.activeInHierarchy)
        {
            GameManagerScript.instanceGMS.PlaneStrip[_planeNo].transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color32(0, 207, 255, 255);
        }
        else if (currentLevelSelected.tailWindAndEmgConditionForRunwaySignal[runwayNoIndex].runwayGameObject.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            GameManagerScript.instanceGMS.PlaneStrip[_planeNo].transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color32(255, 154, 5, 255);
        }
        else if (currentLevelSelected.tailWindAndEmgConditionForRunwaySignal[runwayNoIndex].runwayGameObject.transform.GetChild(5).gameObject.activeInHierarchy)
        {
            GameManagerScript.instanceGMS.PlaneStrip[_planeNo].transform.GetChild(0).GetChild(3).GetComponent<Image>().color = new Color32(209, 8, 8, 255);
        }
    }
   
    //.................................//

    public void Arv_34R_RunwaySelection_ActiveButton()
    {
        CheckRunwaySignal(GameManagerScript.instanceGMS.currentPlaneActive, 0);
        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        //arv_runwayselection_all_ui.SetActive(false);  //.....Runway Ui...//
        arv_runwayselection.SetActive(false);
        GameManagerScript.instanceGMS.autoselectrunway = true;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Clear();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Add("34R");

        arv_runwayselection_birdeyeview = false;
       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftIRunway = false;

        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "34R";

        //......by basant.....//

        runwayNoArr = "34R";
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().runwayNo = runwayNoArr;
        Achievements.instance.OneRunway(runwayNoArr);              //by Ashish
        currentLevelSelected.CheckEmergencyAircraftAfterRunwaySelection(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, "34R");
        
        References(GameManagerScript.instanceGMS.currentPlaneActive,aPRSound);
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunWayToLand(planeNoArr, runwayNoArr, _flyDir, _altNew);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        RadarManagerScript.instance.SelectArrivalRWY(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "34R ILS");//Runway selection for radar system
        RadarManagerScript.instance.SelectSouth(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);//south selection for radar system
                    
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "SOUTH 34R LOW");
        ScoreManager.instance.ClickForBonus(200);

        audioClipsPlaneArr = CommandReceiver.instance.RunWayToLandAudio(currentFlightNoClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _altNew1Clip, _thousandClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
        StartCoroutine(RunWayToLandAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        
    }

    public void Arv_34L_RunwaySelection_ActiveButton()
    {
        CheckRunwaySignal(GameManagerScript.instanceGMS.currentPlaneActive, 1);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        //arv_runwayselection_all_ui.SetActive(false);  //.....Runway Ui...//
        arv_runwayselection.SetActive(false);

        GameManagerScript.instanceGMS.autoselectrunway = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Clear();
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Add("34L");
        
        arv_runwayselection_birdeyeview = false;        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftIRunway = false;

        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "34L";

        //......by basant....//
        runwayNoArr = "34L";
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().runwayNo = runwayNoArr;
        Achievements.instance.OneRunway(runwayNoArr);              //by Ashish
        References(GameManagerScript.instanceGMS.currentPlaneActive,aPRSound);
        currentLevelSelected.CheckEmergencyAircraftAfterRunwaySelection(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, "34L");
       
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunWayToLand(planeNoArr, runwayNoArr, _flyDir, _altNew);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        RadarManagerScript.instance.SelectArrivalRWY(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "34L ILS");//Runway selection for radar system
        RadarManagerScript.instance.SelectNorth(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);//north selection for radar system
        
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, "NORTH 34L LOW");
        ScoreManager.instance.ClickForBonus(200);
        
        audioClipsPlaneArr = CommandReceiver.instance.RunWayToLandAudio(currentFlightNoClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _altNew1Clip, _thousandClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);

        StartCoroutine(RunWayToLandAgain(GameManagerScript.instanceGMS.currentPlaneActive));

        
    }
    //....................................// 

    //.......AutoRunway Selectin 34R,34L......// 

    public void Auto_Arv_RunwaySelection(int _autoRSPlaneNo)
    {
        CheckRunwaySignal(_autoRSPlaneNo, 0);

        for (int i = 0; i < totalRunwayUI.Count; i++)
        {
            totalRunwayUI[i].SetActive(false);
            totalRunwayUI[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < totalRunwayUILine.Count; i++)
        {
            totalRunwayUILine[i].SetActive(false);
        }

        arv_runwayselection.SetActive(false);
        arv_runwayselection_birdeyeview = false;

        GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<AircraftScripts>().RunwaySelected.Clear();
        GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<AircraftScripts>().RunwaySelected.Add("34R");

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].transform, false);
        GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<RadarScript>().isAirCraftIRunway = false;

        GameManagerScript.instanceGMS.PlaneStrip[_autoRSPlaneNo].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "RWY";
        GameManagerScript.instanceGMS.PlaneStrip[_autoRSPlaneNo].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "34R";

        //...........by basant...........//
        runwayNoArr = "34R";
        GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<RadarScript>().runwayNo = runwayNoArr;

        References(_autoRSPlaneNo,aPRSound);
        currentLevelSelected.CheckEmergencyAircraftAfterRunwaySelection(GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].transform, "34R");
        
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunWayToLand(planeNoArr, runwayNoArr, _flyDir, _altNew);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        RadarManagerScript.instance.SelectArrivalRWY(GameManagerScript.instanceGMS.PlaneList, _autoRSPlaneNo, "34R ILS");//Runway selection for radar system
        RadarManagerScript.instance.SelectSouth(GameManagerScript.instanceGMS.PlaneList, _autoRSPlaneNo);//south selection for radar system
         
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, _autoRSPlaneNo, "SOUTH 34R LOW");

        audioClipsPlaneArr = CommandReceiver.instance.RunWayToLandAudio(currentFlightNoClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _altNew1Clip, _thousandClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_autoRSPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_autoRSPlaneNo, APR);
        StartCoroutine(RunWayToLandAgain(_autoRSPlaneNo));

        
    }

    //.......By basant.......//

    IEnumerator RunWayToLandAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        References(_planeNo, _pilotSound);
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunWayToLandAgain(runwayNoArr, _flyDir, _altNew, planeNoArr);
        
        audioClipsPlaneArr = CommandReceiver.instance.RunWayToLandAgainAudio(runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _altNew1Clip, _thousandClip, currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    //........................................// 
    #endregion

    #region Detour Selection

    //.....Detour Selected......//

    public void Arv_DetourSelection() //.....Detour Selected......//
    {
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftDetour)
        {
            arv_detour_selection.SetActive(true);
            arv_detour_selectionactivebutton.SetActive(false);
        }
        else
        {
            arv_detour_selection.SetActive(false);
            arv_detour_selectionactivebutton.SetActive(false);
        }
        //..............By basant..............//
        SetAlphaColorOfImage(RadarManagerScript.instance.highlightedRadarPoints[1], .3f);
    }
    public void Arv_DetourSelection_DeactiveButton()
    {
        arv_detour_selectionactivebutton.SetActive(true);
        //..............By basant..............//
        SetAlphaColorOfImage(RadarManagerScript.instance.highlightedRadarPoints[1], 1f);
    }
    public void Arv_DetourSelection_ActiveButton()
    {
        arv_detour_selectionactivebutton.SetActive(false);
        arv_detour_selection.SetActive(false);

        GameManagerScript.instanceGMS.DetourWay();        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftDetour = false;
        GameManagerScript.instanceGMS.DetourwaySelected = true;

        //........by basant....//
        References(GameManagerScript.instanceGMS.currentPlaneActive,aPRSound);
        
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectDetourRoute(planeNoArr, _flyDir, _cardinalDry, _altNew);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();        
        StartCoroutine(DetourAgain(GameManagerScript.instanceGMS.currentPlaneActive));
       
        audioClipsPlaneArr = CommandReceiver.instance.SelectDetourRouteAudio(currentFlightNoClip,_flyDir1Clip,_flyDir2Clip,_flyDir3Clip,_cardinalDryClip,_altNew1Clip,_thousandClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
    }
    public void Arv_DetourNotSelected(int _PlaneNo)  //.....Detour Not Selected......//
    {
        arv_detour_selection.SetActive(false);
        GameManagerScript.instanceGMS.CircleWay(_PlaneNo);
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].transform, false);
        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().isAirCraftDetour = false;

        //..............By basant..............//
        SetAlphaColorOfImage(RadarManagerScript.instance.highlightedRadarPoints[1], 0.3f);
    }
    public void SetAlphaColorOfImage(Image _image, float _alphaVal)
    {
        var color = _image.color;
        color.a = _alphaVal;
        _image.color = color;
    }
    //.........By basant........//
    IEnumerator DetourAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectDetourRouteAgain(_flyDir, _cardinalDry, _altNew, planeNoArr);
        
        audioClipsPlaneArr = CommandReceiver.instance.SelectDetourRouteAgainAudio(_flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _cardinalDryClip, _altNew1Clip, _thousandClip, currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive);
    }
    //........................//

    #endregion

    #region CleartoLanding and GoAround

    //.....Clear to Landing and GoAround......//

    public void Arv_CleartoLanding_GoAround() //.....Select Clear to landing and Goaround......//
    {
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftCleartolanding)
        {
            arv_cleartolanding_goaround_selection.SetActive(true);
            arv_cleartolanding_activebutton.SetActive(false);
            arv_goaround_activebutton.SetActive(false);
        }
        else
        {
            arv_cleartolanding_goaround_selection.SetActive(false);
            arv_cleartolanding_activebutton.SetActive(false);
            arv_goaround_activebutton.SetActive(false);
        }
    }
    public void Arv_CleartoLanding_DeactiveButton()
    {
        arv_cleartolanding_activebutton.SetActive(true);
        arv_goaround_activebutton.SetActive(false);
    }
    public void Arv_GoAround_DeactiveButton()
    {
        arv_goaround_activebutton.SetActive(true);
        arv_cleartolanding_activebutton.SetActive(false);
    }
    public void Arv_CleartoLanding_ActiveButton()
    {
        arv_goaround_activebutton.SetActive(false);
        arv_cleartolanding_activebutton.SetActive(false);
        arv_cleartolanding_goaround_selection.SetActive(false);

        GameManagerScript.instanceGMS.ClearToLanding();
        goaroundok = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftCleartolanding = false;        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        // ...........basant...........//
        References(GameManagerScript.instanceGMS.currentPlaneActive, tWRSound);

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().goAroundCount > 0)
        {
            ScoreManager.instance.ClickForBonus(200);
        }
        else
        {
            ScoreManager.instance.ClickForBonus(500);
        }
        //...................................//
        
        string str = RadarManagerScript.instance.airSpeed.text;
        string _windDir1 = str.Substring(0, 3);
        string _windForce1 = str.Substring(6, 2);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalClearToLanding(planeNoArr, runwayNoArr, _windDir1, _windForce1);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalClearToLandingAudio(currentFlightNoClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _windDir1Clip, _windDir2Clip, _windDir3Clip, _windForce1Clip,_windForce2Clip, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);
        StartCoroutine(ClearToLandAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }

    public void Arv_GoAround_ActiveButton()
    {
        goAroundCounter++;
        arv_goaround_activebutton.SetActive(false);
        arv_cleartolanding_activebutton.SetActive(false);
        arv_cleartolanding_goaround_selection.SetActive(false);

        GameManagerScript.instanceGMS.GoAround34R_34L(GameManagerScript.instanceGMS.currentPlaneActive);
        goaroundok = true;
        AirplaneStatusIconHandling(GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform, 4); //...Aeroplane status...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftCleartolanding = false;        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        //......... bonus point......
        ScoreManager.instance.ClickForBonus(100);
        //.........by basant............
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalGoAround(planeNoArr);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        StartCoroutine(GoAroundAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        int _soundIndex = ConvertAtcSoundsIntoNo(tWRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArrivalGoAroundAudio(currentFlightNoClip, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);
    }

    //..........By basant............//
    IEnumerator ClearToLandAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalClearToLandingAgain(runwayNoArr, planeNoArr);
        
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalClearToLandingAgainAudio(currentFlightNoClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
        yield return new WaitForSeconds(11);
        StartCoroutine(LobbySounds.ins.ClearForLandingLobbySound(_planeNo));

    }
    IEnumerator GoAroundAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalGoAroundAgain();
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArrivalGoAroundAgainAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    //........................................//

    #endregion

    #region Arrival Mask On Off

    //.........For Arrival Mask ON OFF.............//
    public int Arrival_ResetImask(int PNO)
    {
        if (PNO == 2)
        {
            PNO = 1;

        }
        if (PNO == 3)
        {
            PNO = 2;

        }
        return PNO;
    }
    public void Arv_Mask_Blue_On(int PNO)
    {
        //int originalPlane = PNO;

        //PNO = Arrival_ResetImask(PNO);
        //Arv_Maskdata = false;
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        yellowPlane[PNO] = StartCoroutine(Arv_Mask_Yellow_On(PNO));
    }
    public IEnumerator Arv_Mask_Yellow_On(int PNO)
    {
        
        yield return new WaitForSeconds(20);
       // print("Arv_Mask_Yellow_On---");
        Arv_Mask_Blue_Off(PNO);
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        RedPlane[PNO] = StartCoroutine(Arv_Mask_Red_On(PNO));
        
    }
    public IEnumerator Arv_Mask_Red_On(int PNO)
    {
        yield return new WaitForSeconds(20);
       // print("Arv_Mask_Red_On---......");
        Arv_Mask_Yellow_Off(PNO);
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(2).gameObject.SetActive(true);

        BluePlane[PNO] = StartCoroutine(Arv_Mask_BlueOn_Again(PNO));
    }

    public IEnumerator Arv_Mask_BlueOn_Again(int PNO)
    {
        yield return new WaitForSeconds(20);
        //print("Arv_Mask_BlueOn_Again---......");
        Arv_Mask_Red_Off(PNO);
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(0).gameObject.SetActive(true);

        float penaltyAmt = ScoreManager.instance.goalScoreVal * .05f;
        ScoreManager.instance.Penalty((int)penaltyAmt);
        TipsAndAlertController.instance.OnPenalty(Control_Text.instance.delayStr, GameManagerScript.instanceGMS.PlaneList[PNO].GetComponent<AircraftScripts>().flightNumber);
        yellowPlane[PNO] = StartCoroutine(Arv_Mask_Yellow_On(PNO));
    }

    public void Arv_Mask_Blue_Off(int PNO)
    {
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        if (yellowPlane[PNO] != null)
        {
            StopCoroutine(yellowPlane[PNO]);
            //print("Arv_Mask_yellow ---......off...");
        }
    }
    public void Arv_Mask_Yellow_Off(int PNO)
    {
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        if (RedPlane[PNO] != null)
        {
            StopCoroutine(RedPlane[PNO]);
            //print("Arv_Mask red --off......");
        }
    }
    public void Arv_Mask_Red_Off(int PNO)
    {
        GameManagerScript.instanceGMS.PlaneStrip[PNO].transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        if (BluePlane[PNO] != null)
        {
            StopCoroutine(BluePlane[PNO]);
            //print("Arv_Mask_Blue---......off...");
        }
    }
    public void Arv_Mask_All_Off(int PNO)
    {
        //PNO = Arrival_ResetImask(PNO);

        //Arv_Maskdata = true;
        Arv_Mask_Blue_Off(PNO);
        Arv_Mask_Yellow_Off(PNO);
        Arv_Mask_Red_Off(PNO);

        //....penalty......
    }
    public void Arv_Mask_Green_On(Transform airPlaneTrans, bool isDepMaskOff) //...for Hold and Continue...//
    {
        if (!isDepMaskOff)
        {
            airPlaneTrans.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(2).GetChild(3).gameObject.SetActive(false);
        }
        else
        {
            airPlaneTrans.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(2).GetChild(3).gameObject.SetActive(true);
        }
    }

    //............................................................//
    #endregion

    #region Speed Icon

    public IEnumerator Arv_SpeedStatus_Slow(int _speedIconPlaneNo, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(0).gameObject.SetActive(true);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(1).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(2).gameObject.SetActive(false);

    }
    public IEnumerator Arv_SpeedStatus_Medium(int _speedIconPlaneNo, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(1).gameObject.SetActive(true);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(0).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(2).gameObject.SetActive(false);

    }
    public IEnumerator Arv_SpeedStatus_Fast(int _speedIconPlaneNo, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(2).gameObject.SetActive(true);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(0).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[_speedIconPlaneNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(3).GetChild(1).gameObject.SetActive(false);

    }
    

    #endregion

    #region Speed Variation

    public void SpeedControl_All(int _stopPlaneNo)
    {
        all_speedui.SetActive(false);
        if (slowSpeedCorotine != null)
            StopCoroutine(slowSpeedCorotine);
        if (mediumSpeedCorotine != null)
            StopCoroutine(mediumSpeedCorotine);
        if (fastSpeedCorotine != null)
            StopCoroutine(fastSpeedCorotine);

        if (blueIMaskForSlowSpeedCorotine != null)
            StopCoroutine(blueIMaskForSlowSpeedCorotine);
        if (blueIMaskForMediumSpeedCorotine != null)
            StopCoroutine(blueIMaskForMediumSpeedCorotine);
        if (blueIMaskForFastSpeedCorotine != null)
            StopCoroutine(blueIMaskForFastSpeedCorotine);

        GameManagerScript.instanceGMS.PlaneList[_stopPlaneNo].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[_stopPlaneNo].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[_stopPlaneNo].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;
    }

    //.....Slow Speed Control..//

    public IEnumerator Slow_SpeedControl(int _ssplaneNo, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        arv_s_maintain.SetActive(false);
        arv_s_keepspeed_activeButton_ks_as.SetActive(false);
        arv_s_accelerate_activeButton_ks_as.SetActive(false);
       
        if (GameManagerScript.instanceGMS.PlaneList[_ssplaneNo].GetComponent<RadarScript>().isArvSlowSpeedCtrl && _ssplaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            all_speedui.SetActive(true);

            arv_s_maintain.SetActive(true);
            arv_s_keepspeed_activeButton_ks_as.SetActive(false);
            arv_s_accelerate_activeButton_ks_as.SetActive(false);
        }
        else
        {
            arv_s_maintain.SetActive(false);
            arv_s_keepspeed_activeButton_ks_as.SetActive(false);
            arv_s_accelerate_activeButton_ks_as.SetActive(false);
        }
    }
    public void Slow_KeepspeedDeactiveButton_KS_AS()
    {
        arv_s_keepspeed_activeButton_ks_as.SetActive(true);
        arv_s_accelerate_activeButton_ks_as.SetActive(false);
    }
    public void Slow_Accelerate_DeactiveButton_KS_AS()
    {
        arv_s_accelerate_activeButton_ks_as.SetActive(true);
        arv_s_keepspeed_activeButton_ks_as.SetActive(false);
    }
    public void Slow_KeepspeedActiveButton_KS_AS()
    {
        arv_s_accelerate_activeButton_ks_as.SetActive(false);
        arv_s_keepspeed_activeButton_ks_as.SetActive(false);
        arv_s_maintain.SetActive(false);
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        
        blueIMaskForSlowSpeedCorotine = StartCoroutine(StartBlueIMaskForSlowSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        slowSpeedCorotine = StartCoroutine(Slow_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //..........By basant..........//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.MaintainSpeed(planeNoArr);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.MaintainSpeedAudio(currentFlightNoClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);

        StartCoroutine(KeepSpeedAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }

    IEnumerator StartBlueIMaskForSlowSpeed(int _speediMaskPlaneNo)
    {
        yield return new WaitForSeconds(39.8f);
        GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].GetComponent<RadarScript>().isArvSlowSpeedCtrl = true;       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].transform, true);
    }
    IEnumerator StartBlueIMaskForMediumSpeed(int _speediMaskPlaneNo)
    {
        yield return new WaitForSeconds(39.8f);
        GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].GetComponent<RadarScript>().isArvMediumSpeedCtrl = true;       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].transform, true);
    }
    IEnumerator StartBlueIMaskForFastSpeed(int _speediMaskPlaneNo)
    {
        yield return new WaitForSeconds(39.8f);
        GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].GetComponent<RadarScript>().isArvFastSpeedCtrl = true;       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_speediMaskPlaneNo].transform, true);
    }
    public void Slow_Accelerate_ActiveButton_KS_AS()
    {
        accelerateCounter++;
        arv_s_accelerate_activeButton_ks_as.SetActive(false);
        arv_s_keepspeed_activeButton_ks_as.SetActive(false);
        arv_s_maintain.SetActive(false);

        StartCoroutine(Arv_SpeedStatus_Medium(GameManagerScript.instanceGMS.currentPlaneActive, 30)); //.....Change the speed icon...//       
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 2.4f;    //...(230)...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1.1f;

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        blueIMaskForMediumSpeedCorotine = StartCoroutine(StartBlueIMaskForMediumSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        mediumSpeedCorotine = StartCoroutine(Medium_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //......by basant...//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        planeSpeedArr = "230";
        ATC atcScript = aPRSound.GetComponent<ATC>();

        flySpeedClip1 = atcScript.two;
        flySpeedClip2 = atcScript.three;
        flySpeedClip3 = atcScript.zero;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.AccelerateSpeed(planeNoArr, "230");
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();       
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.AccelerateSpeedAudio(currentFlightNoClip, flySpeedClip1, flySpeedClip2, flySpeedClip3, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
        StartCoroutine(AccSpeedAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    //.........................//

    //...Medium Speed Control..//

    public IEnumerator Medium_SpeedControl(int _msplaneNo, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        arv_m_maintain.SetActive(false);
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);

        if (GameManagerScript.instanceGMS.PlaneList[_msplaneNo].GetComponent<RadarScript>().isArvMediumSpeedCtrl && _msplaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            all_speedui.SetActive(true);
            arv_m_maintain.SetActive(true);

            arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
            arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
            arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);           
        }
        else
        {
            arv_m_maintain.SetActive(false);

            arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
            arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
            arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
        }
    }
    public void Medium_DecelerateDeactiveButton_DS_KS_AS()
    {
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(true);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
    }
    public void Medium_KeepspeedDeactiveButton_DS_KS_AS()
    {
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(true);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
    }
    public void Medium_Accelerate_DeactiveButton_DS_KS_AS()
    {
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(true);
    }
    public void Medium_DecelerateActiveButton_DS_KS_AS()
    {
        accelerateCounter++;
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_maintain.SetActive(false);

        StartCoroutine(Arv_SpeedStatus_Slow(GameManagerScript.instanceGMS.currentPlaneActive, 30));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 2.2f;    //...(190)...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        blueIMaskForSlowSpeedCorotine = StartCoroutine(StartBlueIMaskForSlowSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        slowSpeedCorotine = StartCoroutine(Slow_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //......by basant
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        planeSpeedArr = "190";
        ATC atcScript = aPRSound.GetComponent<ATC>();
        flySpeedClip1 = atcScript.one;
        flySpeedClip2 = atcScript.nine;
        flySpeedClip3 = atcScript.zero;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DecelerateSpeed(planeNoArr, "190");
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.DecelerateSpeedAudio(currentFlightNoClip, flySpeedClip1, flySpeedClip2, flySpeedClip3, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
        StartCoroutine(DecelerateAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    public void Medium_KeepspeedActiveButton_DS_KS_AS()
    {
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_maintain.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        blueIMaskForMediumSpeedCorotine = StartCoroutine(StartBlueIMaskForMediumSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        mediumSpeedCorotine = StartCoroutine(Medium_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;
        //..........By basant..........//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;

        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.MaintainSpeed(planeNoArr);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();        
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        StartCoroutine(KeepSpeedAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.MaintainSpeedAudio(currentFlightNoClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
    }
    public void Medium_Accelerate_ActiveButton_DS_KS_AS()
    {
        accelerateCounter++;
        arv_m_decelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_keepspeed_activeButton_ds_ks_as.SetActive(false);
        arv_m_accelerate_activeButton_ds_ks_as.SetActive(false);
        arv_m_maintain.SetActive(false);
        StartCoroutine(Arv_SpeedStatus_Fast(GameManagerScript.instanceGMS.currentPlaneActive, 30));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 2.6f;    //...(250)...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1.2f;

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        blueIMaskForFastSpeedCorotine = StartCoroutine(StartBlueIMaskForFastSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        fastSpeedCorotine = StartCoroutine(Fast_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //......by basant....//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        planeSpeedArr = "250";
        ATC atcScript = aPRSound.GetComponent<ATC>();

        flySpeedClip1 = atcScript.two;
        flySpeedClip2 = atcScript.five;
        flySpeedClip3 = atcScript.zero;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.AccelerateSpeed(planeNoArr, "250");
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.AccelerateSpeedAudio(currentFlightNoClip, flySpeedClip1, flySpeedClip2, flySpeedClip3, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
        StartCoroutine(AccSpeedAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }

    //.........................//
    //...Fast Speed Control...//

    public IEnumerator Fast_SpeedControl(int _fsPlaneNo, int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        arv_f_maintain.SetActive(false);
        arv_f_decelerate_activeButton_ds_ks.SetActive(false);
        arv_f_keepspeed_activeButton_ds_ks.SetActive(false);

        if (GameManagerScript.instanceGMS.PlaneList[_fsPlaneNo].GetComponent<RadarScript>().isArvFastSpeedCtrl && _fsPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_f_maintain.SetActive(true);
            all_speedui.SetActive(true);
            arv_f_decelerate_activeButton_ds_ks.SetActive(false);
            arv_f_keepspeed_activeButton_ds_ks.SetActive(false);
        }
        else
        {
            arv_f_maintain.SetActive(false);

            arv_f_decelerate_activeButton_ds_ks.SetActive(false);
            arv_f_keepspeed_activeButton_ds_ks.SetActive(false);
        }
    }
    public void Fast_DecelerateDeactiveButton_DS_KS()
    {
        arv_f_decelerate_activeButton_ds_ks.SetActive(true);
        arv_f_keepspeed_activeButton_ds_ks.SetActive(false);
    }
    public void Fast_Keepspeed_DeactiveButton_DS_KS()
    {
        arv_f_keepspeed_activeButton_ds_ks.SetActive(true);
        arv_f_decelerate_activeButton_ds_ks.SetActive(false);
    }
    public void Fast_KeepspeedActiveButton_DS_KS()
    {
        arv_f_maintain.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        blueIMaskForFastSpeedCorotine = StartCoroutine(StartBlueIMaskForFastSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        fastSpeedCorotine = StartCoroutine(Fast_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //......by basant...........//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;

        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.MaintainSpeed(planeNoArr);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);
        StartCoroutine(KeepSpeedAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.MaintainSpeedAudio(currentFlightNoClip, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);
    }
    public void Fast_Decelerate_ActiveButton_DS_KS()
    {
        accelerateCounter++;
        arv_f_maintain.SetActive(false);

        StartCoroutine(Arv_SpeedStatus_Medium(GameManagerScript.instanceGMS.currentPlaneActive, 30)); //.....Change the speed icon. 

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 2.4f;    //...(230)...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1.1f;

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        blueIMaskForMediumSpeedCorotine = StartCoroutine(StartBlueIMaskForMediumSpeed(GameManagerScript.instanceGMS.currentPlaneActive));
        mediumSpeedCorotine = StartCoroutine(Medium_SpeedControl(GameManagerScript.instanceGMS.currentPlaneActive, 40));

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvSlowSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvMediumSpeedCtrl = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isArvFastSpeedCtrl = false;

        //......by basant....//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        planeSpeedArr = "230";
        ATC atcScript = aPRSound.GetComponent<ATC>();
        flySpeedClip1 = atcScript.two;
        flySpeedClip2 = atcScript.three;
        flySpeedClip3 = atcScript.zero;

        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DecelerateSpeed(planeNoArr, "230");
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.DecelerateSpeedAudio(currentFlightNoClip, flySpeedClip1, flySpeedClip2, flySpeedClip3, aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);

        StartCoroutine(DecelerateAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }

    //.........................//
    //.......By basant............
    IEnumerator AccSpeedAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.AccelerateAgain(planeSpeedArr, planeNoArr);
        
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        ATC atcScript = _pilotSound.GetComponent<ATC>();
        if (planeSpeedArr == "250")
        {
            flySpeedClip1 = atcScript.two;
            flySpeedClip2 = atcScript.five;
            flySpeedClip3 = atcScript.zero;
        }else if(planeSpeedArr == "230")
        {
            flySpeedClip1 = atcScript.two;
            flySpeedClip2 = atcScript.three;
            flySpeedClip3 = atcScript.zero;
        }
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.AccelerateAgainAudio(flySpeedClip1, flySpeedClip2, flySpeedClip3, currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    IEnumerator KeepSpeedAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.MaintainAgain(planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.MaintainAgainAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    IEnumerator DecelerateAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DecelerateAgain(planeSpeedArr, planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        ATC atcScript = _pilotSound.GetComponent<ATC>();
        
        if (planeSpeedArr == "230")
        {
            flySpeedClip1 = atcScript.two;
            flySpeedClip2 = atcScript.three;
            flySpeedClip3 = atcScript.zero;
        }
        else if (planeSpeedArr == "190")
        {
            flySpeedClip1 = atcScript.one;
            flySpeedClip2 = atcScript.nine;
            flySpeedClip3 = atcScript.zero;
        }
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.DecelerateAgainAudio(currentFlightNoClip, flySpeedClip1, flySpeedClip2, flySpeedClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    //..........................//

    #endregion

    #region Tower Control Hand-Off

    //........TowerControlHand_Off.............//

    public void Arv_TowerControlHand_Off_Call(int _towerPlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftArv_TowerControl && _towerPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_towercontrol_handoff.SetActive(true);
        }
        else
        {
            arv_towercontrol_handoff.SetActive(false);
            arv_towercontrol_handOff_activebutton.SetActive(false);
        }
    }
    public void Arv_TowerControlHand_Off_DeactiveButton()  //....Click On TowerControlHand_Off DeactiveButton.....//
    {
        arv_towercontrol_handOff_activebutton.SetActive(true);

    }
    public void Arv_TowerControlHand_Off_ActiveButton()  //....Click On TowerControlHand_Off ActiveButton.....//
    {       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        arv_towercontrol_handOff_activebutton.SetActive(false);
        arv_towercontrol_handoff.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_TowerCHandoff = true;

        //...Bones Add...//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftArv_TowerControl = false;
        ScoreManager.instance.ClickForBonus(300);

        //....by basant........//

        References(GameManagerScript.instanceGMS.currentPlaneActive,aPRSound);       
        //runwayNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().rWYArrival.Substring(0, 3);
       
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTowerCtrlHandOff(planeNoArr, _apprRoute, runwayNoArr);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTowerCtrlHandOffAudio(currentFlightNoClip, _apprRouteClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3,aPRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, APR);

        StartCoroutine(TowerCtrlHandOffAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    public void Arv_TowerControlHand_Off_AutoClosed(int _HOPlaneNo)  //....Auto close TowerControlHand_Off Buton.....//
    {       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_HOPlaneNo].transform, false);
        arv_towercontrol_handoff.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[_HOPlaneNo].GetComponent<RadarScript>().isAirCraftArv_TowerControl = false;
        //........by basant........//
        StartCoroutine(APRContactToTWR(_HOPlaneNo, 0));
        //........................//
    }
    //.......By basant....//
    IEnumerator TowerCtrlHandOffAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        References(_planeNo, _pilotSound);      
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTowerCtrlHandOffAgain(_apprRoute, runwayNoArr, planeNoArr);

        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTowerCtrlHandOffAgainAudio(currentFlightNoClip,_apprRouteClip, runwayNoArrClip1, runwayNoArrClip2, runwayNoArrClip3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
        StartCoroutine(APRContactToTWR(_planeNo, 15));
    }

    IEnumerator APRContactToTWR(int _planeno, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //....................1st shift.............//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[_planeno].transform, -1.36f);
        GameManagerScript.instanceGMS.PlaneStrip[_planeno].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = TWR.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[_planeno].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = TWR.GetComponent<ATCBarUIScript>().controlBarColor;
        //..........................................//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<AircraftScripts>().flightNumber;

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTower(planeNoArr);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<RadarScript>().currentATC = "TWR";
        if (_planeno == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "TWR";
        }
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTowerAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeno].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeno);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_planeno));
        //..................................................//
    }
    //....................//

    #endregion

    #region Departure Control Hand-Off(After Go Around)

    //........Departure Control Hand-Off.............//

    public void Arv_DepartureControlHand_Off_Call(int depCtrlHandOffPlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[depCtrlHandOffPlaneNo].GetComponent<RadarScript>().goAroundDCH && depCtrlHandOffPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_departurecontrolhand_off.SetActive(true);
        }
        else
        {
            arv_departurecontrolhand_off.SetActive(false);
            arv_departurecontrolhand_off_activebutton.SetActive(false);
        }
    }
    public void Arv_DepartureControlHand_Off_DeactiveButton()  //....Click On TowerControlHand_Off DeactiveButton.....//
    {
        arv_departurecontrolhand_off_activebutton.SetActive(true);
    }
    public void Arv_DepartureControlHand_Off_ActiveButton()  //....Click On TowerControlHand_Off ActiveButton.....//
    {        
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        arv_departurecontrolhand_off_activebutton.SetActive(false);
        arv_departurecontrolhand_off.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().goAroundDCH = false;
        //...Bones Add...//
        //...BY BASANT..//

        ScoreManager.instance.ClickForBonus(200);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHandOff(planeNoArr);
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        int _soundIndex = ConvertAtcSoundsIntoNo(tWRSound);

        StartCoroutine(DepartAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureHandOffAudio(currentFlightNoClip, tWRSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, TWR);
    }

    public IEnumerator Arv_DepartureControlHand_Off_AutoClosed(int planeNo)  //....Auto close TowerControlHand_Off Buton.....//
    {
        yield return new WaitForSeconds(50);

        if (GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().goAroundDCH)
        {
            Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[planeNo].transform, false);

            arv_departurecontrolhand_off.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().goAroundDCH = false;
            //.......BY BASANT........//
            StartCoroutine(TWR_TO_DEP_For_Arrival(planeNo, 0));
        }

        NintendoController.instance.NpadButtonB2();//divyansh
    }
    IEnumerator DepartAgain(int PlaneNo)
    {
        yield return new WaitForSeconds(15);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHandOffAgain(planeNoArr);        
        StartCoroutine(TWR_TO_DEP_For_Arrival(PlaneNo, 15));
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[PlaneNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[PlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureHandOffAgainAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(PlaneNo);
    }

    IEnumerator TWR_TO_DEP_For_Arrival(int twr_To_Dep_planeNo, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //........Shift TWR to DEP....................//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[twr_To_Dep_planeNo].transform, 2.5f);
        GameManagerScript.instanceGMS.PlaneStrip[twr_To_Dep_planeNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = DEP.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[twr_To_Dep_planeNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = DEP.GetComponent<ATCBarUIScript>().controlBarColor;

        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTokyoDep(planeNoArr);
        DEP.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<RadarScript>().currentATC = "DEP";
        if (twr_To_Dep_planeNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "DEP";
        }
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTokyoDepAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[twr_To_Dep_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(twr_To_Dep_planeNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(twr_To_Dep_planeNo));
        //..................................................//
    }
    #endregion

    #region Approach Control Hand-Off(After Go Around)

    //........Departure Control Hand-Off.............//

    public void Arv_ApproachControlHand_Off_Call(int _goAroundACPlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[_goAroundACPlaneNo].GetComponent<RadarScript>().goAroundACH && _goAroundACPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_approachcontrolhand_Off.SetActive(true);
        }
        else
        {
            arv_approachcontrolhand_Off.SetActive(false);
            arv_approachcontrolhand_Off_activebutton.SetActive(false);
        }
    }
    public void Arv_ApproachControlHand_Off_DeactiveButton()  //....Click On TowerControlHand_Off DeactiveButton.....//
    {
        arv_approachcontrolhand_Off_activebutton.SetActive(true);
    }
    public void Arv_ApproachControlHand_Off_ActiveButton()  //....Click On TowerControlHand_Off ActiveButton.....//
    {       
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);
        arv_approachcontrolhand_Off_activebutton.SetActive(false);
        arv_approachcontrolhand_Off.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().goAroundACH = false;
        //...Bones Add...//
        //...BY BASANT..//

        ScoreManager.instance.ClickForBonus(100);       
        References(GameManagerScript.instanceGMS.currentPlaneActive,dEPSound);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalApproachCtrlHandOff(planeNoArr, _LRDir, _flyDir, _wayPoint, _altNew);
        DEP.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalApproachCtrlHandOffAudio(currentFlightNoClip, _LRDirClip, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _wayPointClip, _altNew1Clip, _thousandClip, dEPSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, DEP);
        StartCoroutine(ApproachCtrlHandOffAgain(GameManagerScript.instanceGMS.currentPlaneActive));
    }
    public IEnumerator Arv_ApproachControlHand_Off_AutoClosed(int goAroundACHPlaneNo)  //....Auto close TowerControlHand_Off Buton.....//
    {
        yield return new WaitForSeconds(90);
        if (GameManagerScript.instanceGMS.PlaneList[goAroundACHPlaneNo].GetComponent<RadarScript>().goAroundACH)
        {           
            Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[goAroundACHPlaneNo].transform, false);
            arv_approachcontrolhand_Off.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[goAroundACHPlaneNo].GetComponent<RadarScript>().goAroundACH = false;
            //.......BY BASANT......//
            StartCoroutine(ArrApproachCtrlHandOffTokyo(goAroundACHPlaneNo, 0));
            NintendoController.instance.NpadButtonB2(); //divyansh
        }
    }
    //.......BY BASANT......//
    IEnumerator ApproachCtrlHandOffAgain(int planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().pilotSound;
        References(planeNo, _pilotSound);
        DEP.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalApproachCtrlHandOffTurn(_LRDir, _flyDir, _altNew, planeNoArr);
        
        StartCoroutine(ArrApproachCtrlHandOffTokyo(planeNo, 13f));
       
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalApproachCtrlHandOffTurnAudio(currentFlightNoClip, _LRDirClip, _flyDir1Clip, _flyDir2Clip, _flyDir3Clip, _altNew1Clip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(planeNo);
    }
    IEnumerator ArrApproachCtrlHandOffTokyo(int planeNo, float waitTime)
    {
        //............Dep to Apr strip shift.............//
        yield return new WaitForSeconds(waitTime);
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().airPlaneStrip, -3.3f);
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(2).GetComponent<Image>().color = APR.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(1).GetComponent<Image>().color = APR.GetComponent<ATCBarUIScript>().controlBarColor;
        AirplaneStatusIconHandling(GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().airPlaneStrip, 0); //...Aeroplane status...//

        //..............Reset plane strips and Redar ............................//
        GameManagerScript.instanceGMS.PlaneList[planeNo].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(5).GetChild(0).GetComponent<Text>().text = " ";
        GameManagerScript.instanceGMS.PlaneList[planeNo].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(5).GetChild(1).GetComponent<Text>().text = " ";

        if (GameManagerScript.instanceGMS.PlaneList[planeNo].gameObject.transform.transform.GetComponentInChildren<CameraMovement>()!= null)
        {
            RadarManagerScript.instance.ChangeImageAlphaColor(RadarManagerScript.instance.highlightedRadarPoints, .3f);
        }

        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentATC = "APR";
        if (planeNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "APR";
        }

        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().highlightedPath.Clear();         //..............clear list of highlighted path............//
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().rWYArrival = "---";
        RadarManagerScript.instance.SetRWYText(GameManagerScript.instanceGMS.PlaneList, planeNo);

        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().isDetourSelected = false;
        RadarManagerScript.instance.SetDetour(GameManagerScript.instanceGMS.PlaneList, planeNo);
        //..........................//

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(planeNo));
        //..................................................//
    }
    //......................
    #endregion

    #region Arv_Taxi Route C8_C9

    public void Arv_TaxiRouteC8_C9_Call(int _C8C9PlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[_C8C9PlaneNo].GetComponent<RadarScript>().isAirCraftC8_C9 && _C8C9PlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_taxirouteC8_C9.SetActive(true);
        }
        else
        {
            arv_taxirouteC8_C9.SetActive(false);
            arv_taxirouteC8_activebutton.SetActive(false);
            arv_taxirouteC9_activebutton.SetActive(false);

            AllClose_Towards34RTaxi_C8_C9();
        }
    }
    public void Arv_TaxiRouteC8_DeactiveButton()
    {
        arv_taxirouteC8_activebutton.SetActive(true);
        arv_taxirouteC9_activebutton.SetActive(false);
        //...Path Line...//

        Towards34RTaxi_C8_C9();
        Taxi_C8();
        //...............//
    }
    public void Arv_TaxiRouteC9_DeactiveButton()
    {
        arv_taxirouteC9_activebutton.SetActive(true);
        arv_taxirouteC8_activebutton.SetActive(false);
        //...Path Line...//

        Towards34RTaxi_C8_C9();
        Taxi_C9();
        //...............//
    }
    public void Arv_TaxiRouteC8_ActiveButton()
    {
        GameManagerScript.instanceGMS.C8_Path(GameManagerScript.instanceGMS.currentPlaneActive); //....C8 Path selected...//
        //....UiClosed...//
        arv_taxirouteC9_activebutton.SetActive(false);
        arv_taxirouteC8_activebutton.SetActive(false);
        arv_taxirouteC8_C9.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        AllClose_Towards34RTaxi_C8_C9(); //.....C8 and C9 Line Path Highlight Closed...//

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Add("C8");
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().taxipathway_C8C9L6L9 = 1;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftC8_C9 = false;

        StartCoroutine(Arv_SpotButtonClick(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, true, 46f));

        //....by basant........//
        taxiWaysArr = "C8";
        int _planeNo = GameManagerScript.instanceGMS.currentPlaneActive;
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().taxiWaysArr = taxiWaysArr;
        References(_planeNo, gNDSound);
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, _planeNo, " >> [TWR]LND >> C8");

        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
        {
            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRoute(planeNoArr, _LRDir, taxiWaysArr);
            audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

            StartCoroutine(ArrivalTexiRouteAgainC8(_planeNo));
        }
        else
        {
            if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.OutOfFuel)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SelectRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

                StartCoroutine(AfterC8Again(_planeNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SickPerson)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);
                StartCoroutine(AfterC8SickPassengerAgain(_planeNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EngineProblem(planeNoArr);
                audioClipsPlaneArr = CommandReceiver.instance.EngineProblemAudio(currentFlightNoClip, tWRSound);

            }
        }
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, TWR);
    }

    public IEnumerator AfterC8Again(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunwayExit(planeNoArr, _LRDir, taxiWaysArr);        
        audioClipsPlaneArr = CommandReceiver.instance.RunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        StartCoroutine(TWR_To_GND(_planeNo));
    }

    public IEnumerator AfterC8SickPassengerAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExitAgain(planeNoArr, _LRDir, taxiWaysArr);
        audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAgainAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        StartCoroutine(TWR_To_GND(_planeNo));
    }

    public void Arv_TaxiRouteC9_ActiveButton(int _C8C9Planeno) //.....For Autoclose..//
    {
        GameManagerScript.instanceGMS.C9_Path(_C8C9Planeno); //....C9 Path selected...//

        arv_taxirouteC9_activebutton.SetActive(false);
        arv_taxirouteC8_activebutton.SetActive(false);
        arv_taxirouteC8_C9.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].transform, false);

        AllClose_Towards34RTaxi_C8_C9(); //.....C8 and C9 Line Path Highlight Closed...//

        GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().RunwaySelected.Add("C9");
        GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().taxipathway_C8C9L6L9 = 2;
        GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<RadarScript>().isAirCraftC8_C9 = false;
       
        StartCoroutine(Arv_SpotButtonClick(GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].transform, false, 46f));

        //......by basant.....//

        taxiWaysArr = "C9";
        GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<RadarScript>().taxiWaysArr = taxiWaysArr;

        References(_C8C9Planeno, tWRSound);

        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, _C8C9Planeno, " >> [TWR]LND >> C9");

        if (GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
        {
            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRoute(planeNoArr, _LRDir, taxiWaysArr);
            audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

            StartCoroutine(ArrivalTexiRouteAgainC8(_C8C9Planeno));
        }
        else
        {
            if (GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.OutOfFuel)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SelectRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

                StartCoroutine(AfterC8Again(_C8C9Planeno));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SickPerson)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);
                StartCoroutine(AfterC8SickPassengerAgain(_C8C9Planeno));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EngineProblem(planeNoArr);
                audioClipsPlaneArr = CommandReceiver.instance.EngineProblemAudio(currentFlightNoClip, tWRSound);

            }
        }
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_C8C9Planeno].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_C8C9Planeno, TWR);
    }

    public void Arv_TaxiRouteC8_C9_ButtonClick() //.....For Button..//
    {
        Arv_TaxiRouteC9_ActiveButton(GameManagerScript.instanceGMS.currentPlaneActive);
    }

    //..........by basant.............//
    IEnumerator ArrivalTexiRouteAgainC8(int texiC8PlaneNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().pilotSound;
        References(texiC8PlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRouteAgain(_LRDir, taxiWaysArr, planeNoArr);
        
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAgainAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(texiC8PlaneNo);

        StartCoroutine(TWR_To_GND(texiC8PlaneNo));
    }
   
    IEnumerator TWR_To_GND(int planeNo)
    {
        yield return new WaitForSeconds(14);

        //....................2nd shift.............//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform, 0.6f);
        GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;
        //.........................................//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureOnGround(planeNoArr);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentATC = "GND";
        if (planeNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "GND";
        }
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureOnGroundAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(planeNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(planeNo));
        //..................................................//
    }
    #endregion

    #region Arv_Taxi Route L6_L9

    public void Arv_TaxiRouteL6_L9_Call(int _L6L9PlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<RadarScript>().isAirCraftL6_L9 && _L6L9PlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_taxirouteL6_L9.SetActive(true);
        }
        else
        {
            arv_taxirouteL6_L9.SetActive(false);
            arv_taxirouteL6_activebutton.SetActive(false);
            arv_taxirouteL9_activebutton.SetActive(false);

            AllClose_Towards34LTaxi_L6_L9();
        }
    }
    public void Arv_TaxiRouteL6_DeactiveButton()
    {
        arv_taxirouteL6_activebutton.SetActive(true);
        arv_taxirouteL9_activebutton.SetActive(false);
        //...Path Line...//

        Towards34LTaxi_L6_L9();
        Taxi_L6();
        //...............//
    }
    public void Arv_TaxiRouteL9_DeactiveButton()
    {
        arv_taxirouteL9_activebutton.SetActive(true);
        arv_taxirouteL6_activebutton.SetActive(false);
        //...Path Line...//

        Towards34LTaxi_L6_L9();
        Taxi_L9();
        //...............//
    } 

    public void Arv_TaxiRouteL6_ActiveButton()
    {
        GameManagerScript.instanceGMS.L6_Path(GameManagerScript.instanceGMS.currentPlaneActive); //....L6 Path selected...//
        //....UiClosed...//
        arv_taxirouteL9_activebutton.SetActive(false);
        arv_taxirouteL6_activebutton.SetActive(false);
        arv_taxirouteL6_L9.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        AllClose_Towards34LTaxi_L6_L9(); //.....C8 and C9 Line Path Highlight Closed...//
       
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected.Add("L6");
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().taxipathway_C8C9L6L9 = 3;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftL6_L9 = false;

        StartCoroutine(Arv_SpotButtonClick(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, true, 46f));

        //....by basant........//

        taxiWaysArr = "L6";
        int _planeNo = GameManagerScript.instanceGMS.currentPlaneActive;
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().taxiWaysArr = taxiWaysArr;
        References(_planeNo, gNDSound);

        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, _planeNo, " >> [TWR]LND >> L6");

        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
        {
            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRoute(planeNoArr, _LRDir, taxiWaysArr);
            audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

            StartCoroutine(ArrivalTexiRouteAgainL6(_planeNo));
        }
        else
        {
            if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.OutOfFuel)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SelectRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

                StartCoroutine(AfterL6Again(_planeNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SickPerson)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);
                StartCoroutine(AfterL6SickPassengerAgain(_planeNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EngineProblem(planeNoArr);
                audioClipsPlaneArr = CommandReceiver.instance.EngineProblemAudio(currentFlightNoClip, tWRSound);

            }
        }
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, TWR);
    }

    public IEnumerator AfterL6Again(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RunwayExit(planeNoArr, _LRDir, taxiWaysArr);

        audioClipsPlaneArr = CommandReceiver.instance.RunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        StartCoroutine(TWR_To_GND_L6L9(_planeNo));
    }

    public IEnumerator AfterL6SickPassengerAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExitAgain(planeNoArr, _LRDir, taxiWaysArr);

        audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAgainAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);

        StartCoroutine(TWR_To_GND_L6L9(_planeNo));
    }

    public void Arv_TaxiRouteL9_ActiveButton(int _L6L9PlaneNo) //.....For Autoclose..//
    {
        GameManagerScript.instanceGMS.L9_Path(_L6L9PlaneNo); //....L9 Path selected...//

        arv_taxirouteL9_activebutton.SetActive(false);
        arv_taxirouteL6_activebutton.SetActive(false);
        arv_taxirouteL6_L9.SetActive(false);

        //Arv_Mask_All_Off(_C8C9Planeno);
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].transform, false);

        AllClose_Towards34LTaxi_L6_L9(); //.....C8 and C9 Line Path Highlight Closed...//
        GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().RunwaySelected.Add("L9");
        GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().taxipathway_C8C9L6L9 = 4;
        GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<RadarScript>().isAirCraftL6_L9 = false;
        
        StartCoroutine(Arv_SpotButtonClick(GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].transform, false, 46));

        //......by basant.....//

        taxiWaysArr = "L9";
        GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<RadarScript>().taxiWaysArr = taxiWaysArr;
        References(_L6L9PlaneNo, tWRSound);

        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, _L6L9PlaneNo, " >> [TWR]LND >> L9");

        if (GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.Normal)
        {
            TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRoute(planeNoArr, _LRDir, taxiWaysArr);
            audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

            StartCoroutine(ArrivalTexiRouteAgainL6(_L6L9PlaneNo));
        }
        else
        {
            if (GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.OutOfFuel)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SelectRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SelectRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);

                StartCoroutine(AfterC8Again(_L6L9PlaneNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SickPerson)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.SickPassengerAtRunwayExit(planeNoArr, _LRDir, taxiWaysArr);
                audioClipsPlaneArr = CommandReceiver.instance.SickPassengerAtRunwayExitAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, tWRSound);
                StartCoroutine(AfterC8SickPassengerAgain(_L6L9PlaneNo));
            }
            else if (GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)
            {
                TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.EngineProblem(planeNoArr);
                audioClipsPlaneArr = CommandReceiver.instance.EngineProblemAudio(currentFlightNoClip, tWRSound);

            }
        }
        TWR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_L6L9PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_L6L9PlaneNo, TWR);
    }

    public void Arv_TaxiRouteL6_L9_ButtonClick() //.....For Button..//
    {
        Arv_TaxiRouteL9_ActiveButton(GameManagerScript.instanceGMS.currentPlaneActive);
    }
    //..........by basant............//

    IEnumerator ArrivalTexiRouteAgainL6(int texiC8PlaneNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().pilotSound;
        References(texiC8PlaneNo, _pilotSound);

        TWR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArrivalTexiRouteAgain(_LRDir, taxiWaysArr, planeNoArr);
        audioClipsPlaneArr = CommandReceiver.instance.ArrivalTexiRouteAgainAudio(currentFlightNoClip, _LRDirClip, taxiWaysArrClip1, taxiWaysArrClip2, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[texiC8PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(texiC8PlaneNo);

        StartCoroutine(TWR_To_GND_L6L9(texiC8PlaneNo));
    }

    IEnumerator TWR_To_GND_L6L9(int planeNo)
    {
        yield return new WaitForSeconds(14);

        //....................2nd shift.............//
        ShiftFlightStrip(GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform, 0.6f);
        GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform.GetChild(0).GetChild(2).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;
        GameManagerScript.instanceGMS.PlaneStrip[planeNo].transform.GetChild(0).GetChild(1).GetComponent<Image>().color = GND.GetComponent<ATCBarUIScript>().controlBarColor;
        //.........................................//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureOnGround(planeNoArr);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentATC = "GND";
        if (planeNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            GameManagerScript.instanceGMS.preAtcContainer = "GND";
        }

        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureOnGroundAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(planeNo);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(planeNo));
        //..................................................//
    }

    #endregion

    #region Arv_Spot 2_3_403

    public IEnumerator Arv_SpotButtonClick(Transform airplaneTrans, bool isOnClick, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        airplaneTrans.GetComponent<RadarScript>().isAirCraftSpot2_3_403 = true; //....spot bool true...//
        Arv_Mask_Blue_On(airplaneTrans.GetComponent<AircraftScripts>().PlaneNumber);

        Arv_Spot2_3_Call(airplaneTrans, isOnClick);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(airplaneTrans.GetComponent<AircraftScripts>().PlaneNumber));
        //..................................................//
    }

    public void Arv_Spot2_3_Call(Transform airplaneTrans, bool isOnClick)
    {
        airplaneTrans.GetComponent<RadarScript>().isAirCraftRouteA_B_C = false;
        arv_AllTexiSpot.SetActive(false);

        for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
        {
            arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);           
        }

        arv_parking_abc.SetActive(false);
        arv_parking_b_activebutton.SetActive(false);
        arv_parking_c_activebutton.SetActive(false);
        arv_parking_a_activebutton.SetActive(false);

        if (airplaneTrans.GetComponent<RadarScript>().isAirCraftSpot2_3_403 && airplaneTrans.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_AllTexiSpot.SetActive(true);
            arv_runwayselection_birdeyeview = true;
            for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
            {
                arv_AllTexiSpot.transform.GetChild(i).gameObject.SetActive(true);                
            }
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    arv_AllTexiSpot.SetActive(false);
                }
            }
            else
            {
                arv_AllTexiSpot.SetActive(false);
            }
        }
    }
    public void Arv_AllTexiSpot_DeactiveButton(int _texiSpot_DNo)
    {
        string spotText = arv_AllTexiSpot.transform.GetChild(_texiSpot_DNo).GetChild(0).GetChild(2).GetComponent<Text>().text;
        PictogramSpots.instance.CurrentSpotSelection(spotText);

        arv_runwayselection_birdeyeview = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.gameObject.SetActive(true);
        for (int i = 0; i < GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.childCount; i++)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34R")            
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C8")
            {
                //print("C88888- "+ _texiSpot_DNo);
                for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
                {
                    arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                }
                arv_AllTexiSpot.transform.GetChild(_texiSpot_DNo).GetChild(1).gameObject.SetActive(true);

                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo).gameObject.SetActive(true); //.....Path Line.....//
                EnableSpotHighlighter(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo).gameObject);
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C9")
            {
                //print("C9999999- ");
                for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
                {
                    arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                }
                arv_AllTexiSpot.transform.GetChild(_texiSpot_DNo).GetChild(1).gameObject.SetActive(true);

                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 3).gameObject.SetActive(true); //.....Path Line.....//
                EnableSpotHighlighter(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 3).gameObject);
            }
        }
        else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34L")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L6")
            {
                //print("L666666- ");
                for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
                {
                    arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                }
                arv_AllTexiSpot.transform.GetChild(_texiSpot_DNo).GetChild(1).gameObject.SetActive(true);

                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 6).gameObject.SetActive(true); //.....Path Line.....//
                EnableSpotHighlighter(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 6).gameObject);
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L9")
            {
                //print("L99999999- ");

                for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
                {
                    arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                }
                arv_AllTexiSpot.transform.GetChild(_texiSpot_DNo).GetChild(1).gameObject.SetActive(true);

                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 9).gameObject.SetActive(true); //.....Path Line.....//
                EnableSpotHighlighter(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot_DNo + 9).gameObject);
            }
        }
    }

    void EnableSpotHighlighter(GameObject obj)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            obj.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Arv_standby_DeactiveButton()
    {
        PictogramSpots.instance.CurrentSpotSelection(null);

        arv_runwayselection_birdeyeview = true;

        for (int i = 0; i < arv_AllTexiSpot.transform.childCount; i++)
        {
            arv_AllTexiSpot.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        arv_AllTexiSpot.transform.GetChild(arv_AllTexiSpot.transform.childCount-1).GetChild(1).gameObject.SetActive(true);

        //.....Path Line.....//        
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.gameObject.SetActive(false);
        //..................//
    }

    public void Arv_AllTexiSpot_ActiveButton(int _texiSpot)
    {


        for (int i = 0; i < GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.childCount; i++)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(i).gameObject.SetActive(false);
        }
        arv_AllTexiSpot.SetActive(false);
        //................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_selectroute = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 = _texiSpot;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftRouteA_B_C = true;

        Arv_ParkingLine_ABC_Call(GameManagerScript.instanceGMS.currentPlaneActive);  //....Call A B C path....//        

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34R")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C8")
            {
                print("C88888-1111 ");
                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot).gameObject;
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C9")
            {
                print("C9999999-2222 ");
                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot+3).gameObject;
            }
        }
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[0] == "34L")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L6")
            {
                print("L666666-3333 ");
                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot+6).gameObject;
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L9")
            {
                print("L99999999-44444 ");
                GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(_texiSpot + 9).gameObject;
            }
        }

        //...........by basant................//

        spotNoArv = arv_AllTexiSpot.transform.GetChild(_texiSpot).GetChild(0).GetChild(2).GetComponent<Text>().text;
        CurrentTexiSpotClips(spotNoArv, gNDSound);
    }

    public void CurrentTexiSpotClips(string str, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        if (str.Length == 1)
        {
            arv_spotNo1 = atcScript.zero;
            arv_spotNo2 = atcScript.zero;
            arv_spotNo3 = GetAudioClipUsingString(str, personSound);
        }else if(str.Length == 2)
        {
            arv_spotNo1 = atcScript.zero;
            arv_spotNo2 = GetAudioClipUsingString(str.Substring(0, 1), personSound);
            arv_spotNo3 = GetAudioClipUsingString(str.Substring(1, 1), personSound);
        }
        else if (str.Length == 3)
        {
            arv_spotNo1 = GetAudioClipUsingString(str.Substring(0, 1), personSound);
            arv_spotNo2 = GetAudioClipUsingString(str.Substring(1, 1), personSound);
            arv_spotNo3 = GetAudioClipUsingString(str.Substring(2, 1), personSound);
        }
    }

    AudioClip GetAudioClipUsingString(string s, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        if (s == "0")
        {
            return atcScript.zero;
        }
        else if (s == "1")
        {
            return atcScript.one;
        }
        else if (s == "2")
        {
            return atcScript.two;
        }
        else if (s == "3")
        {
            return atcScript.three;
        }
        else if (s == "4")
        {
            return atcScript.four;
        }
        else if (s == "5")
        {
            return atcScript.five;
        }
        else if (s == "6")
        {
            return atcScript.six;
        }
        else if (s == "7")
        {
            return atcScript.seven;
        }
        else if (s == "8")
        {
            return atcScript.eight;
        }
        else if (s == "9")
        {
            return atcScript.nine;
        }
        return atcScript.zero;
    }
    public void Arv_StandBy_ActiveButton()
    {
        arv_AllTexiSpot.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_selectroute = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftSpot2_3_403 = false;   
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().restart_standby = true;

        Arv_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        arv_runwayselection_birdeyeview = false;

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().restart_standbyAgain)
        {
            StartCoroutine(Arv_RecallSpotButtons(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform));           
        }
        //...........By basant..............//
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArvStandByText(planeNoArr);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        StartCoroutine(Arv_StandBy_Again(GameManagerScript.instanceGMS.currentPlaneActive));
        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArvStandByTextAudio(currentFlightNoClip, gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);
    }

    //............By basant......//

    public IEnumerator Arv_StandBy_Again(int _flightNo)
    {
        yield return new WaitForSeconds(14);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ArvStandByTextAgain(planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.ArvStandByTextAgainAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_flightNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_flightNo);
    }

    //.........................//

    public IEnumerator Arv_RecallSpotButtons(Transform airplaneTrans)
    {
        yield return new WaitForSeconds(30f);
        airplaneTrans.GetComponent<RadarScript>().isAirCraftSpot2_3_403 = true;
        Arv_Mask_Blue_On(airplaneTrans.GetComponent<AircraftScripts>().PlaneNumber);       
        Arv_Spot2_3_Call(airplaneTrans, false);
    }
    public void Arv_RecallplanetomoveC8C9()
    {
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_selectroute)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_selectroute = false;
        }
    }
    #endregion

    #region Arv_Parking Line A B C

    public void Arv_ParkingLine_ABC_Call(int _ABCPlaneNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[_ABCPlaneNo].GetComponent<RadarScript>().isAirCraftRouteA_B_C && _ABCPlaneNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_parking_abc.SetActive(true);
            arv_runwayselection_birdeyeview = true;           
        }
        else
        {
            arv_parking_abc.SetActive(false);
        }
    }
    public void Arv_ParkingLine_ABC_DeactiveButton(int _abcParking)
    {
        for (int i = 0; i < arv_parking_abc.transform.childCount; i++)
        {
            arv_parking_abc.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        arv_parking_abc.transform.GetChild(_abcParking).GetChild(1).gameObject.SetActive(true);

        //...........Path line....//

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj.SetActive(true);
        for (int i = 0; i < GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj.transform.childCount; i++)
        {           
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj.transform.GetChild(i).gameObject.SetActive(false);
        }
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj.transform.GetChild(_abcParking).gameObject.SetActive(true);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathHighlighterObj.transform.GetChild(_abcParking).gameObject;
        //............................//
    }

    public void Arv_ParkingLine_ABC_ActiveButton(int _abcParking)
    {
        //...... by divyansh..........//
        PictogramSpots.instance.CurrentSpotSelection(null);
        //.....................//
        for (int i = 0; i < arv_parking_abc.transform.childCount; i++)
        {
            arv_parking_abc.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        arv_parking_abc.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().arv_selectrouteABC = true;        

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C8" )
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 0) //...Spot 2...//
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(0).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT02");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 02";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);


                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("2", true);
                //..............................................//

                if (spotCounter2 == 0)  //....by Ashish...//
                {
                    spotCounter2++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 1) //...Spot 3...//
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(0).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT03");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 03";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);


                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("3", true);
                //..............................................//

                if (spotCounter3 == 0)             //by Ashish
                {
                    spotCounter3++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 2) //...Spot 403...//
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(0).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }

                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT403");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 403";


                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("403", true);
                //..............................................//

                RadarManagerScript.instance.TowardsTerminal_Cargo(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
                if (spotCounter403 == 0)   //....by Ashish...//
                {
                    spotCounter403++;
                }
            }
        }

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "C9")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 0)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(1).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT02");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 02";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("2", true);
                //..............................................//

                if (spotCounter2 == 0)  //....by Ashish...//
                {
                    spotCounter2++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 1)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(1).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT03");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 03";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("3", true);
                //..............................................//

                if (spotCounter3 == 0)             //by Ashish
                {
                    spotCounter3++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 2)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(1).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT403");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 403";

                RadarManagerScript.instance.TowardsTerminal_Cargo(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);
                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("403", true);
                //..............................................//

                if (spotCounter403 == 0)   //....by Ashish...//
                {
                    spotCounter403++;
                }
            }
        }

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L6")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 0)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(2).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT02");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 02";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("2", true);
                //..............................................//

                if (spotCounter2 == 0)  //....by Ashish...//
                {
                    spotCounter2++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 1)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(2).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT03");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 03";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("3", true);
                //..............................................//

                if (spotCounter3 == 0)             //by Ashish
                {
                    spotCounter3++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 2)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(2).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT403");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 403";

                RadarManagerScript.instance.TowardsTerminal_Cargo(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("403", true);
                //..............................................//

                if (spotCounter403 == 0)   //....by Ashish...//
                {
                    spotCounter403++;
                }
            }
        }

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RunwaySelected[1] == "L9")
        {
            if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 0)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint34R.transform.GetChild(3).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT02");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 02";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("2", true);
                //..............................................//

                if (spotCounter2 == 0)  //....by Ashish...//
                {
                    spotCounter2++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 1)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16R.transform.GetChild(3).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT03");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 03";
                RadarManagerScript.instance.TowardsTerminal_1(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("3", true);
                //..............................................//

                if (spotCounter3 == 0)             //by Ashish
                {
                    spotCounter3++;
                }
            }
            else if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathspot2_3_403 == 2)
            {
                foreach (Transform child in GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pathPoint16L.transform.GetChild(3).GetChild(_abcParking))
                {
                    if (child.tag == "CirclePoint")
                    {
                        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().AirPoint.Add(child.gameObject);
                    }
                }
                ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT403");
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "SPOT";
                GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = " 403";

                RadarManagerScript.instance.TowardsTerminal_Cargo(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive);

                //.................divyansh.....................//
                PictogramSpots.instance.ChangeSpotColor("403", true);
                //..............................................//

                if (spotCounter403 == 0)   //....by Ashish...//
                {
                    spotCounter403++;
                }
            }
        }
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0 && GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().restart_standby)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().restart_standby = false;
        }
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponentInChildren<PlaneAnimationController>().TyreNForwordStartRotate();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB1Start();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB2Start();
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponentInChildren<PlaneAnimationController>().RotateForwordTyreB3Start();
        }
        Arv_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftSpot2_3_403 = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraftRouteA_B_C = false;
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj != null)
        {
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().spotToSpotHighlightedObj.SetActive(true);
        }
        arv_runwayselection_birdeyeview = false;

        //.......Basant..........//
        if (_abcParking == 0)
        {
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-A");           
        }
        else if(_abcParking == 1)
        {
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-B");           
        }
        else if (_abcParking == 2)
        {
            ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> [GND]TAXI-C");           
        }
        StartCoroutine(Arv_AtcAfterABC_Route(GameManagerScript.instanceGMS.currentPlaneActive, 0));
        //...............//
    }

    public void RecalltomoveABC()
    {
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;
    }
    public IEnumerator Arv_AtcAfterABC_Route(int _abcRoutePlaneNo, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_abcRoutePlaneNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTexiRoute(planeNoArr, spotNoArv);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_abcRoutePlaneNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureTexiRouteAudio(currentFlightNoClip, arv_spotNo1, arv_spotNo2, arv_spotNo3, gNDSound);
        GameManagerScript.instanceGMS.PlaneList[_abcRoutePlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_abcRoutePlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_abcRoutePlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_abcRoutePlaneNo, GND);

        StartCoroutine(Arv_AtcAfterABC_Route_Again(_abcRoutePlaneNo, spotNoArv));
    }

    IEnumerator Arv_AtcAfterABC_Route_Again(int flightNo, string spotNo)
    {
        yield return new WaitForSeconds(14);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureTexiToSpot(spotNo, planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureTexiToSpotAudio(currentFlightNoClip, arv_spotNo1, arv_spotNo2, arv_spotNo3, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[flightNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(flightNo);
        yield return new WaitForSeconds(11);
        StartCoroutine(LobbySounds.ins.TaxingToSpotLobby(flightNo));
    }

    #endregion

    #region Hold Position

    //........Hold Position.............//

    public void Arv_HoldPosition_Call(Transform airplaneTransform, bool isOnClick)
    {
        if (airplaneTransform.GetComponent<RadarScript>().arv_IsAirCraft_Hold && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_holdposn_continueposn.SetActive(true);
            arv_holdposition.SetActive(true);
            arv_continuetaxi.SetActive(false);
            arv_holdposition_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!airplaneTransform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    Arv_HoldPosnAndContinuePosUIButtonsDeactive();
                    arv_holdposition_activebutton.SetActive(false);
                }
            }
            else
            {
                Arv_HoldPosnAndContinuePosUIButtonsDeactive();
                arv_holdposition_activebutton.SetActive(false);
            }
        }
    }

    public void Arv_HoldPosnAndContinuePosUIButtonsDeactive()
    {
        arv_holdposn_continueposn.SetActive(false);
        arv_holdposition.SetActive(false);
        arv_continuetaxi.SetActive(false);
    }
    public void Arv_HoldPosition_DeactiveButton()
    {
        arv_holdposition_activebutton.SetActive(true);
        arv_continuetaxi.SetActive(false);
    }
    public Coroutine holdArrivalCoroutine, ContinueArrivalCoroutine;

    public void HoldCorotineArrival()
    {
        if (holdArrivalCoroutine != null)
            StopCoroutine(holdArrivalCoroutine);
    }
    public void ContinueCorotineArrival()
    {
        if (ContinueArrivalCoroutine != null)
            StopCoroutine(ContinueArrivalCoroutine);
    }

    public void Arv_HoldPosition_ActiveButton()
    {
        arv_holdposn_continueposn.SetActive(false);
        arv_holdposition_activebutton.SetActive(false);

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().SpeedDownHoldButton());

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arv_IsAirCraft_Hold = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arvIsHold = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arvIsContinue = false;
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);        
        holdArrivalCoroutine = StartCoroutine(ArvGreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, true));

        //.....by basant.....//
        ScoreManager.instance.stopTexiingCount++;
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHoldOn(planeNoArr);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        StartCoroutine(DepartureHoldOnAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);
        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureHoldOnAudio(currentFlightNoClip,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);
    }

    IEnumerator ArvGreenOnForContinue(int _ContinueplaneNo, float waitTime, bool isAirCraft_Continue)  //..............for continue and hold
    {
        yield return new WaitForSeconds(waitTime);
        if (isAirCraft_Continue)
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().arv_IsAirCraft_Continue = true;
            StartCoroutine(ArvContinueTaxi_UIOn(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, 0, false));

            //.....Penalty for stop Texxing when there is a Long delay........//
            ScoreManager.instance.PenaltyForLongDelay(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<AircraftScripts>().flightNumber);        }
        else
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().arv_IsAirCraft_Hold = true;
            Arv_HoldPosition_Call(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, false);
        }
        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, true);
    }

    //.......basant.........//
    IEnumerator DepartureHoldOnAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureHoldOnAgain(planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureHoldOnAgainAudio(currentFlightNoClip, _pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }

    #endregion

    #region Continue Taxi

    //........Continue Taxi.............//

    public IEnumerator ArvContinueTaxi_UIOn(Transform airplaneTransform, int waitTime, bool isOnClick)
    {
        yield return new WaitForSeconds(waitTime);
        if (airplaneTransform.GetComponent<RadarScript>().arv_IsAirCraft_Continue && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_holdposn_continueposn.SetActive(true);
            arv_holdposition.SetActive(false);
            arv_continuetaxi.SetActive(true);
            arv_continuetaxi_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    Arv_HoldPosnAndContinuePosUIButtonsDeactive();
                    arv_continuetaxi_activebutton.SetActive(false);
                }
            }
            else
            {
                Arv_HoldPosnAndContinuePosUIButtonsDeactive();
                arv_continuetaxi_activebutton.SetActive(false);
            }
        }
    }
    public void Arv_ContinueTaxi_DeactiveButton()
    {
        arv_holdposn_continueposn.SetActive(true);
        arv_continuetaxi_activebutton.SetActive(true);
        arv_holdposition.SetActive(false);
    }
    public void Arv_ContinueTaxi_ActiveButton()
    {
        arv_holdposn_continueposn.SetActive(false);
        arv_continuetaxi_activebutton.SetActive(false);
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().SpeedupAfterPuchback());

        arv_holdposn_continueposn.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arv_IsAirCraft_Continue = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arvIsContinue = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arvIsHold = false;

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arvIsFinalHoldContinueStopTrigger)
        {
            ContinueArrivalCoroutine = StartCoroutine(ArvGreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, false));
        }

        //.......basant.......//
        //.....Stop Co-Routine... Penalty for stop Texxing when there is a Long delay........
        ScoreManager.instance.PenaltyForLongDelayStopCoroutine();

        planeNoArr = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureResumeHoldOn(planeNoArr);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
       
        StartCoroutine(DepartureResumeHoldOnAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        int _soundIndex = ConvertAtcSoundsIntoNo(gNDSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;
        audioClipsPlaneArr = CommandReceiver.instance.DepartureResumeHoldOnAudio(currentFlightNoClip,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);
    }

    //........basant.........//
    IEnumerator DepartureResumeHoldOnAgain(int _planeNo)
    {
        yield return new WaitForSeconds(15);
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;

        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.DepartureResumeHoldOnAgian(planeNoArr);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        int _soundIndex = ConvertAtcSoundsIntoNo(_pilotSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.DepartureResumeHoldOnAgianAudio(currentFlightNoClip,_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }
    #endregion

    #region Path Selection Line

    public void Towards34RTaxi_C8_C9()
    {
        PathselectionLine.transform.GetChild(7).GetChild(0).gameObject.SetActive(true);
        //PathselectionLine.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        //PathselectionLine.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
    }
    public void Taxi_C8()
    {
        PathselectionLine.transform.GetChild(7).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
    }
    public void Taxi_C9()
    {
        PathselectionLine.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(7).GetChild(1).gameObject.SetActive(false);

    }
    public void AllClose_Towards34RTaxi_C8_C9()
    {
        PathselectionLine.transform.GetChild(7).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(7).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
    }

    public void Towards34LTaxi_L6_L9()
    {
        PathselectionLine.transform.GetChild(8).GetChild(0).gameObject.SetActive(true);
        //PathselectionLine.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        //PathselectionLine.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
    }
    public void Taxi_L6()
    {
        PathselectionLine.transform.GetChild(19).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(19).GetChild(2).gameObject.SetActive(false);
    }
    public void Taxi_L9()
    {
        PathselectionLine.transform.GetChild(19).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(19).GetChild(1).gameObject.SetActive(false);

    }
    public void AllClose_Towards34LTaxi_L6_L9()
    {
        PathselectionLine.transform.GetChild(19).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(19).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(19).GetChild(2).gameObject.SetActive(false);
    }


    //..................//
    #region Path C8_2_3_403 All

    GameObject arv_SelectedPathHighlight;

    public void All_Taxi_C8_2()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);  //...C9
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);  //...C403

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_C8_2_Path1()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_C8_2_Path2()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_C8_2_Path3()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject;
    }

    public void Spots_C8_2_Path23403()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    //..................//

    public void All_Taxi_C8_3()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_C8_3_Path1()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject;
    }
    public void Spots_C8_3_Path2()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject;
    }
    public void Spots_C8_3_Path3()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject;
    }

    public void Spots_C8_3_Path23403()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
    }
    //..................//

    public void All_Taxi_C8_403()
    {
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_C8_403_Path1()
    {
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_C8_403_Path2()
    {
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_C8_403_Path3()
    {
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject;
    }

    public void Spots_C8_403_Path23403()
    {
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    public void AllClose_Taxi_C8_2_3_403()
    {
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
    }


    #endregion

    #region Path C9_2_3_403 All
    //.............//
    public void All_Taxi_C9_2()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_C9_2_Path1()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_C9_2_Path2()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_C9_2_Path3()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject;
    }

    public void Spots_C9_2_Path23403()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    //..................//

    public void All_Taxi_C9_3()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
    }
    public void Spots_C9_3_Path1()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject;
    }

    public void Spots_C9_3_Path2()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject;
    }
    public void Spots_C9_3_Path3()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject;
    }

    public void Spots_C9_3_Path23403()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
    }

    //..................//

    public void All_Taxi_C9_403()
    {
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);

        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(true);

    }
    public void Spots_C9_403_Path1()
    {
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
    }
    public void Spots_C9_403_Path2()
    {
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject;
    }
    public void Spots_C9_403_Path3()
    {
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);

        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(true);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);

        arv_SelectedPathHighlight = PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject;
    }

    public void Spots_C9_403_Path23403()
    {

        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
    public void AllClose_Taxi_C9_2_3_403()
    {
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        PathselectionLine.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
    }


    #endregion

    #endregion
    
    #region Emergency Plane Command

    public void Arv_EmergencySelection(int _planeNo)
    {
        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().arv_isAirCraftEmg && _planeNo == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            arv_Emergency_selection.SetActive(true);
            arv_Emergency_selectionactivebutton.SetActive(false);
        }
        else
        {
            arv_Emergency_selection.SetActive(false);
            arv_Emergency_selectionactivebutton.SetActive(false);
        }
    }

    public void Arv_Emergency_DeactiveButton()
    {
        arv_Emergency_selectionactivebutton.SetActive(true);
    }
    public void Arv_Emergency_ActiveButton()
    {
        arv_Emergency_selection.SetActive(false);
        arv_Emergency_selectionactivebutton.SetActive(false);

        UIManager.instance.Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);  //  i mask off
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().arv_isAirCraftEmg = false;

        //...........By basant............//
        int _planeNo = GameManagerScript.instanceGMS.currentPlaneActive;
        planeNoArr = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AircraftScripts>().flightNumber;

        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.AfterSelectingConfirmEmergency(planeNoArr);
        APR.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        int _soundIndex = ConvertAtcSoundsIntoNo(aPRSound);

        AudioClip currentFlightNoClip = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().differentPeopleSound[_soundIndex].flightNo;

        audioClipsPlaneArr = CommandReceiver.instance.AfterSelectingConfirmEmergencyAudio(currentFlightNoClip,aPRSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, APR);

        StartCoroutine(ConfirmEmergencyAgain(_planeNo));
    }
    public void Arv_EmergencyNotSelected(int _PlaneNo)
    {
        arv_Emergency_selection.SetActive(false);
        arv_Emergency_selectionactivebutton.SetActive(false);

        Arv_Mask_Green_On(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].transform, false);
        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().arv_isAirCraftEmg = false;
    }
    //...........By basant..............//
    IEnumerator ConfirmEmergencyAgain(int _planeNo)
    {
        yield return new WaitForSeconds(14);
        APR.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.AfterSelectingConfirmEmergencyAgain();
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        audioClipsPlaneArr = CommandReceiver.instance.AfterSelectingConfirmEmergencyAgainAudio(_pilotSound);
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneArr;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }

    #endregion

    public void PeneltyForArrivalLanding(int arrLandingplaneNo)
    {
        //.......BY BASANT...........//
        //.....check condition for penalty when there is delay..........//
        int currentGameTime = ScoreManager.instance.ConvertTextTimeIntoSeconds(ScoreManager.instance.timeTextGame.text);
        int planeDep_ArrTimeInSec = GameManagerScript.instanceGMS.PlaneList[arrLandingplaneNo].GetComponent<RadarScript>().aircraftDepArrTimeInSec;
        if (currentGameTime > planeDep_ArrTimeInSec)
        {
            // Give penalty = exceed time * 5..//
            int exceedTimeInSec = currentGameTime - planeDep_ArrTimeInSec;
            int exceedTimeInMin = (int)exceedTimeInSec / 60;

            int penaltyAmt = exceedTimeInMin * 5;
            ScoreManager.instance.Penalty(penaltyAmt);
            TipsAndAlertController.instance.OnPenalty(Control_Text.instance.delayStr, GameManagerScript.instanceGMS.PlaneList[arrLandingplaneNo].GetComponent<AircraftScripts>().flightNumber);
        }
        //.....................................................
    }

    #endregion

    //......................................................................................//

    //.............................Spot To Spot Process........................................//

    #region Spot to Spot


    #region Spot selection And standby for All

    public void Active_STS_and_SB(Transform airplaneTransform, bool isOnClick)
    {
        if (airplaneTransform.GetComponent<RadarScript>().sts_isAirCraft_STS_SB && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            sts_spotselection_birdeyeview = true;

            airplaneTransform.GetComponent<AircraftScripts>().spotCommand.SetActive(true);

            airplaneTransform.GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = airplaneTransform.GetComponent<AircraftScripts>().spotNameEnd;
            airplaneTransform.GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = airplaneTransform.GetComponent<AircraftScripts>().spotNumberEnd;

            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    if (airplaneTransform.GetComponent<AircraftScripts>().spotCommand != null)
                    {
                        sts_spotselection_birdeyeview = false;
                        airplaneTransform.GetComponent<AircraftScripts>().spotCommand.SetActive(false);                                              
                    }
                }
            }
            else
            {
                if (airplaneTransform.GetComponent<AircraftScripts>().spotCommand != null)
                {
                    sts_spotselection_birdeyeview = false;
                    airplaneTransform.GetComponent<AircraftScripts>().spotCommand.SetActive(false);
                }
            }
        }
    }

    public void Sts_Spot_DeactiveButton()
    {
        string spotText = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNumberEnd;
        PictogramSpots.instance.CurrentSpotSelection(spotText);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNameEnd;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNumberEnd;


        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);


        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.gameObject.SetActive(true);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void Sts_StandBy_DeactiveButton()
    {
        //...... by divyansh..........//
        PictogramSpots.instance.CurrentSpotSelection(null);
        //.....................//
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotHighlighter.gameObject.SetActive(false);
        
    }
    public void Sts_Spot_AactiveButton()
    {
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().pushBackTowingCar.SetActive(true); //..pushBack on..//

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.SetActive(false);
        sts_spotselection_birdeyeview = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().sts_isAirCraft_STS_SB = false; 

        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(0).GetComponent<Text>().text = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNameEnd;// "SPOT";
        GameManagerScript.instanceGMS.PlaneStrip[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetChild(5).GetChild(1).GetComponent<Text>().text = GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNumberEnd;// " 203";

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().GroundVehiclesFadeOut();
        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PushBackCalltoMove());

        Dep_AirplaneStatusIconHandling(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip, 7); //......Departure AirplaneStatus......//

        //Dep_PushBack(GameManagerScript.instanceGMS.currentPlaneActive);  //......Departure AirplaneStatus......//
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);

        ////.......by basant.............//
        int _currentPlaneNo = GameManagerScript.instanceGMS.currentPlaneActive;
        GameManagerScript.instanceGMS.PlaneList[_currentPlaneNo].GetComponent<RadarScript>().spotToSpotHighlightedObj = GameManagerScript.instanceGMS.PlaneList[_currentPlaneNo].GetComponent<AircraftScripts>().spotHighlighter.transform.GetChild(2).gameObject;
        GameManagerScript.instanceGMS.PlaneList[_currentPlaneNo].GetComponent<RadarScript>().towardsTerminal = GameManagerScript.instanceGMS.PlaneList[_currentPlaneNo].GetComponent<RadarScript>().endTerminal;
        RadarManagerScript.instance.SetTerminal(GameManagerScript.instanceGMS.PlaneList, _currentPlaneNo);
        GameManagerScript.instanceGMS.PlaneList[_currentPlaneNo].GetComponent<RadarScript>().endSpotClicked = true;
        References(_currentPlaneNo, gNDSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.StartTowingSpot(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        audioClipsPlaneDep = CommandReceiver.instance.StartTowingSpotAudio(_airserveClip, gNDSound);

        SpotClickAtcAudio(audioClipsPlaneDep, _currentPlaneNo);

        StartCoroutine(SpotClickAgain(_airserveNo, _currentPlaneNo));
        ScoreManager.instance.ChangeATCComandHistroy(GameManagerScript.instanceGMS.PlaneList, GameManagerScript.instanceGMS.currentPlaneActive, " >> SPOT " + GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotNumberEnd);
        ////........................//
    }

    //.......By basant..................//

    public void SpotClickAtcAudio(List<AudioClip> _airserveClip, int _planeNo)
    {
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = _airserveClip;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(_planeNo, GND);
    }

    public void SpotClickPilotAudio(List<AudioClip> _airserveClip, int _planeNo)
    {
        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips = _airserveClip;

        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_planeNo);
    }

    IEnumerator SpotClickAgain(string _airServeNo, int _planeNo)
    {
        yield return new WaitForSeconds(14);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.StartTowingSpotAgain(_airServeNo);

        audioClipsPlaneDep = CommandReceiver.instance.StartTowingSpotAgainAudio(_airserveClip, _pilotSound);
        SpotClickPilotAudio(audioClipsPlaneDep, _planeNo);
    }

    public void ClickOnStandByForSpotToSpot()
    {
        int _currentPlaneNo = GameManagerScript.instanceGMS.currentPlaneActive;
        References(_currentPlaneNo, gNDSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.HoldPositionSpot(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        audioClipsPlaneDep = CommandReceiver.instance.HoldPositionSpotAudio(_airserveClip, gNDSound);
        SpotClickAtcAudio(audioClipsPlaneDep, _currentPlaneNo);

        StartCoroutine(StandByClickAgain(_airserveNo, _currentPlaneNo));
    }


    IEnumerator StandByClickAgain(string _airServeNo, int _planeNo)
    {
        yield return new WaitForSeconds(14);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.HoldPositionSpotAgain(_airServeNo);

        audioClipsPlaneDep = CommandReceiver.instance.HoldPositionSpotAgainAudio(_airserveClip, _pilotSound);
        SpotClickPilotAudio(audioClipsPlaneDep, _planeNo);
    }

    //...................................//

    public void Sts_StandBy_ActiveButton() //.......Select Standby Active Button..
    {
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().spotCommand.SetActive(false);
        sts_spotselection_birdeyeview = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().sts_isAirCraft_STS_SB = false;

        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().Recall_STS_SB();

        //.........By basant......//
        ClickOnStandByForSpotToSpot();
        //......................//
    }




    #endregion

    #region Hold Position / Continue Taxi

    #region STS Hold Position 

    public void STS_HoldPosition_UIOn(Transform airplaneTransform, bool isOnClick)
    {
        if (airplaneTransform.GetComponent<RadarScript>().sts_isAirCraft_Hold && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {           
            sts_holdposition.SetActive(true);
            sts_continuetaxi.SetActive(false);
            sts_holdposition_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    STS_HoldPosnAndContinuePosUIButtonsDeactive();
                }
            }
            else
            {
                STS_HoldPosnAndContinuePosUIButtonsDeactive();
            }
        }
    }

    public void STS_HoldPosnAndContinuePosUIButtonsDeactive()
    {
        sts_holdposition.SetActive(false);
        sts_continuetaxi.SetActive(false);
    }
    public void STS_HoldPosition_DeactiveButton()
    {       
        sts_holdposition_activebutton.SetActive(true);
        sts_continuetaxi_activebutton.SetActive(false);
    }
    public Coroutine sts_holdCorotine, sts_ContinueCorotine;

    public void STS_StopCorotineHold()
    {
        if (sts_holdCorotine != null)
        {
            StopCoroutine(sts_holdCorotine);
        }
    }
    public void STS_StopCorotineContinue()
    {
        if (sts_ContinueCorotine != null)
        {
            StopCoroutine(sts_ContinueCorotine);
        }
    }
    public void STS_HoldPosition_ActiveButton()
    {
        sts_holdposition.SetActive(false);
        sts_continuetaxi.SetActive(false);
        sts_holdposition_activebutton.SetActive(false);
        sts_continuetaxi_activebutton.SetActive(false);

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().SpeedDownHoldButton());

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().sts_isAirCraft_Hold = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().stsIsHold = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().stsIsContinue = false;
        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        sts_holdCorotine = StartCoroutine(STS_GreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, true));

        //............by basant...............//

        int _currentPlaneNo = GameManagerScript.instanceGMS.currentPlaneActive;
        References(_currentPlaneNo, gNDSound);
      
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.TowingHoldPosition(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        audioClipsPlaneDep = CommandReceiver.instance.TowingHoldPositionAudio(_airserveClip,gNDSound);
        SpotClickAtcAudio(audioClipsPlaneDep, _currentPlaneNo);
        StartCoroutine(HoldClickAgain(_airserveNo, _currentPlaneNo));
    }

    public IEnumerator STS_GreenOnForContinue(int _ContinueplaneNo, float waitTime, bool sts_isAirCraft_Continue)  //..............for continue and hold
    {
        yield return new WaitForSeconds(waitTime);
        if (sts_isAirCraft_Continue)
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().sts_isAirCraft_Continue = true;
            StartCoroutine(STS_ContinueTaxi_UIOn(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, 0, false));

            //.....Penalty for stop Texxing when there is a Long delay........
            ScoreManager.instance.PenaltyForLongDelay(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<AircraftScripts>().flightNumber);
        }
        else
        {
            GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].GetComponent<RadarScript>().sts_isAirCraft_Hold = true;
            STS_HoldPosition_UIOn(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, false);
        }
        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[_ContinueplaneNo].transform, true);
    }


    //..............For Hold and Continue...........//
    IEnumerator HoldClickAgain(string _airServeNo, int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;

        References(_planeNo, _pilotSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.TowingHoldPositionAgain(_airServeNo);
        
        audioClipsPlaneDep = CommandReceiver.instance.TowingHoldPositionAgainAudio(_airserveClip, _pilotSound);
        SpotClickPilotAudio(audioClipsPlaneDep, _planeNo);
    }

    IEnumerator ContinueClickAgain(string _airServeNo, AudioClip _airServeClip, int _planeNo)
    {
        yield return new WaitForSeconds(15);
        GameObject _pilotSound = GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().pilotSound;
        References(_planeNo, _pilotSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ContinueTowingAgain(_airServeNo);        

        audioClipsPlaneDep = CommandReceiver.instance.ContinueTowingAgainAudio(_airServeClip, _pilotSound);

        SpotClickPilotAudio(audioClipsPlaneDep, _planeNo);
    }

    //.......................................



    #endregion

    #region  STS Continue Taxi

    public IEnumerator STS_ContinueTaxi_UIOn(Transform airplaneTransform, int waitTime, bool isOnClick)
    {
        yield return new WaitForSeconds(waitTime);
        if (airplaneTransform.GetComponent<RadarScript>().sts_isAirCraft_Continue && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {           
            sts_holdposition.SetActive(false);
            sts_continuetaxi.SetActive(true);
            sts_continuetaxi_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    STS_HoldPosnAndContinuePosUIButtonsDeactive();
                }
            }
            else
            {
                STS_HoldPosnAndContinuePosUIButtonsDeactive();
            }
        }
    }

    public void STS_ContinueTaxi_DeactiveButton()
    {       
        sts_continuetaxi_activebutton.SetActive(true);
        sts_holdposition_activebutton.SetActive(false);
    }
    public void STS_ContinueTaxi_ActiveButton()
    {
        sts_holdposition.SetActive(false);
        sts_continuetaxi.SetActive(false);
        sts_continuetaxi_activebutton.SetActive(false);
        sts_holdposition_activebutton.SetActive(false);

        StartCoroutine(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().SpeedupAfterPuchback());

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().sts_isAirCraft_Continue = false;

        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().stsIsContinue = true;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().stsIsHold = false;

        Dep_Mask_green_On(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform, false);

        if (!GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().stsIsFinalHoldContinueStopTrigger)
        {
            sts_ContinueCorotine = StartCoroutine(STS_GreenOnForContinue(GameManagerScript.instanceGMS.currentPlaneActive, 30f, false));
        }

        //............by basant...............//

        int _currentPlaneNo = GameManagerScript.instanceGMS.currentPlaneActive;
        References(_currentPlaneNo, gNDSound);
       
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.ContinueTowing(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        audioClipsPlaneDep = CommandReceiver.instance.ContinueTowingAudio(_airserveClip,gNDSound);

        SpotClickAtcAudio(audioClipsPlaneDep, _currentPlaneNo);

        StartCoroutine(SpotClickAgain(_airserveNo, _currentPlaneNo));

        //......................................//
    }

    #endregion

    #endregion

    #endregion

    #region Cross Runway

    public void Active_CR_and_SB(Transform airplaneTransform, bool isOnClick)
    {
        if (airplaneTransform.GetComponent<RadarScript>().isAirCraft_CR_SB && airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber == GameManagerScript.instanceGMS.currentPlaneActive)
        {
            crossrunway_standby.SetActive(true);
            crossrunway_activebutton.SetActive(false);
            cross_standby_activebutton.SetActive(false);
        }
        else
        {
            if (!isOnClick)
            {
                if (!airplaneTransform.GetComponent<AircraftScripts>().airPlaneStrip.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    crossrunway_standby.SetActive(false);
                    crossrunway_activebutton.SetActive(false);
                    cross_standby_activebutton.SetActive(false);                         
                }
            }
            else
            {
                crossrunway_standby.SetActive(false);
                crossrunway_activebutton.SetActive(false);
                cross_standby_activebutton.SetActive(false);                
            }
        }
    }
    public void CrossRunway_DeactiveButton()
    {
        crossrunway_activebutton.SetActive(true);
        cross_standby_activebutton.SetActive(false);
    }
    public void CrossStandBy_DeactiveButton()
    {
        crossrunway_activebutton.SetActive(false);
        cross_standby_activebutton.SetActive(true);
    }
    public void CrossRunway_AactiveButton()
    {
        crossrunway_standby.SetActive(false);
        crossrunway_activebutton.SetActive(false);
        cross_standby_activebutton.SetActive(false);

       
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraft_CR_SB = false;
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().crossrunway = true;
       
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);

        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform.GetComponent<AircraftScripts>().PlaneSpeed <= 0 )//&& GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().restart_standby)
        {
            StartCoroutine(CrossRunwayRecall(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].transform));
        }
        //.......by basant.............//
        References(GameManagerScript.instanceGMS.currentPlaneActive, gNDSound);
       
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RequestCrossRunwayClearToCrossRunway(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();

        audioClipsPlaneDep = CommandReceiver.instance.RequestCrossRunwayClearToCrossRunwayAudio(_airserveClip,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetATCStripAnimation(GameManagerScript.instanceGMS.currentPlaneActive, GND);

        StartCoroutine(CrossRunwayAgain(GameManagerScript.instanceGMS.currentPlaneActive, _airserveNo, _airserveClip));
        ////........................//
    }

    //.......By basant..................//

    public IEnumerator CrossRunwayRecall(Transform airplaneTransform)
    {
        yield return new WaitForSeconds(25f);

        airplaneTransform.GetComponent<AircraftScripts>().PlaneSpeed = 0.05f;
        airplaneTransform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 1f;        
    }

    public IEnumerator IMaskOnForCrossRunway(Transform airplaneTransform)
    {
        airplaneTransform.GetComponent<AircraftScripts>().PlaneSpeed = 0.03f;
        airplaneTransform.GetComponent<AircraftScripts>().RotationPlaneSpeed = 0.78f;

        yield return new WaitForSeconds(8f);
        airplaneTransform.GetComponent<RadarScript>().isAirCraft_CR_SB = true;
        Dep_Mask_Blue_On(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber);

        Active_CR_and_SB(airplaneTransform, false);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(airplaneTransform.GetComponent<AircraftScripts>().PlaneNumber));
        //..................................................//
    }

    public IEnumerator BeforeCrossRunway(int _PlaneNo)
    {
        yield return new WaitForSeconds(0f);
        
        References(_PlaneNo, gNDSound);
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RequestCrossRunway(_airserveNo);
        GND.GetComponent<ATCBarUIScript>().StartBarOutAnim();
        
        audioClipsPlaneDep = CommandReceiver.instance.RequestCrossRunwayAudio(_airserveClip,gNDSound);

        GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_PlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_PlaneNo);
    }

    IEnumerator CrossRunwayAgain(int _crossRunwayPlaneNo, string airserveNo, AudioClip airserveNoClip)
    {
        yield return new WaitForSeconds(15f);
     
        GND.GetComponent<ATCBarUIScript>().atcText = CommandReceiver.instance.RequestCrossRunwayClearToCrossRunwayAgain(airserveNo);
        audioClipsPlaneDep = CommandReceiver.instance.RequestCrossRunwayClearToCrossRunwayAgainAudio(airserveNoClip,gNDSound);
        GameManagerScript.instanceGMS.PlaneList[_crossRunwayPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips = audioClipsPlaneDep;
        SoundManager.instance.PlayATCSound(GameManagerScript.instanceGMS.PlaneList[_crossRunwayPlaneNo].GetComponent<RadarScript>().currentAirCraftAudioClips, GameManagerScript.instanceGMS.PlaneList[_crossRunwayPlaneNo].GetComponent<AudioSource>());
        GameManagerScript.instanceGMS.SetPilotStripAnimation(_crossRunwayPlaneNo);
    }
    //........................................................//

    IEnumerator CrossStandByClickAgain(int _planeNo)
    {
        yield return new WaitForSeconds(32);        

        ////crossrunway_standby.SetActive(true);
        ////crossrunway_activebutton.SetActive(false);
        ////cross_standby_activebutton.SetActive(false);

        GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().isAirCraft_CR_SB = true;
        if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().isDeparture || GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().isSpottoSpot)
        {
            Dep_Mask_Blue_On(_planeNo);
        }
        else if (GameManagerScript.instanceGMS.PlaneList[_planeNo].GetComponent<RadarScript>().isArrival)
        {
            Arv_Mask_Blue_On(_planeNo);
        }
        //Dep_Mask_Blue_On(_planeNo);
        Active_CR_and_SB(GameManagerScript.instanceGMS.PlaneList[_planeNo].transform, false);

        //..........Disable command when atc is open........//
        StartCoroutine(GameManagerScript.instanceGMS.DisableAtcCommandOnTriggerEnter(_planeNo));
        //..................................................//
    }
    //...................................//

    public void CrossStandBy_ActiveButton() //.......Select Standby Active Button..
    {
        crossrunway_standby.SetActive(false);
        crossrunway_activebutton.SetActive(false);
        cross_standby_activebutton.SetActive(false);


        GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().isAirCraft_CR_SB = false;
      
        Dep_Mask_All_Off(GameManagerScript.instanceGMS.currentPlaneActive);      
        if (GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<AircraftScripts>().recallCrossrunway)
        {      
            StartCoroutine(CrossStandByClickAgain(GameManagerScript.instanceGMS.currentPlaneActive));
        }
        //.........By basant......//

        ClickOnStandByForSpotToSpot();
        //......................//
    }

    #endregion

    //......................................................................................//
   public GameObject selectedPathGameObj;

    public void PathHighlighter(GameObject PathHighlighter, int mainParent, int PathNo, int childNo, int count)
    {
        for (int i = 0; i < PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).childCount; i++)
        {
            PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < count; i++)
        {
            PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).GetChild(childNo + i).gameObject.SetActive(true);
            selectedPathGameObj = PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).GetChild(childNo + i).gameObject;
        }
    }
    public void PathHighlighterFalse(GameObject PathHighlighter, int mainParent, int PathNo, int childNo, int count)
    {
        for (int i = 0; i < PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).childCount; i++)
        {
            PathHighlighter.transform.GetChild(mainParent).GetChild(1).GetChild(PathNo).GetChild(i).gameObject.SetActive(false);
        }
    }

    //.......................................HARSHIT...................................//

    #region ATCBarUI Process

    public void ATCColorDefelactor(string currentAirplaneATC)
    {
        for (int i = 0; i < atcBarScript.Length; i++)
        {
            atcBarScript[i].strapTextBg.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);
            atcBarScript[i].atcTextBg.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);           
        }

        ATCBarUIScript currentAirplaneATCScript = GameObject.Find(currentAirplaneATC).transform.GetComponent<ATCBarUIScript>();     
        if (currentAirplaneATCScript.aTCOpen == true)
        {
            currentAirplaneATCScript.strapTextBg.color = currentAirplaneATCScript.textStrapBGColor;
            currentAirplaneATCScript.atcTextBg.color = currentAirplaneATCScript.textStrapBGColor;
            currentAirplaneATCScript.controlBar.color = currentAirplaneATCScript.controlBarColor;
        }
    }

    #endregion

    public void ShiftFlightStrip(Transform strip, float sPosition)
    {
        strip.localPosition = new Vector3(sPosition, strip.localPosition.y, strip.localPosition.z);
    }
    public void AirplaneStatusIconHandling(Transform flightStrip, int childNo)
    {
        for (int i = 0; i < flightStrip.GetChild(1).childCount; i++)
        {
            flightStrip.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }

        flightStrip.GetChild(1).GetChild(childNo).gameObject.SetActive(true);
    }
    //.......................................HARSHIT...................................//   
}