using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Serializable]
    public class WindForceClip
    {
        public AudioClip windAngleClip1;
        public AudioClip windAngleClip2;
        public AudioClip windAngleClip3;

        public AudioClip windForceClip1;
        public AudioClip windForceClip2;


    }

    [Serializable]
    public class SetWindForceTiming
    {
        public string startTime;
        public string endTime;
        public string windAngle;
        public string windForce;
        
        [SerializeField]
        public WindForceClip[] windForceClipObject;
    }

    [SerializeField]
    public SetWindForceTiming[] setWindForceTimings;

    //[Serializable]
    //public class RunwayClosedStatusCondition
    //{
    //    public GameObject runwayObj;
    //    public string runwayNo;
    //    public int emgRunwayCounter;

    //}

    //[SerializeField]
    //public RunwayClosedStatusCondition[] LandingStatusForArrAricraft;

    [Serializable]
    public class AirDirectionMinMaxForClosedRunway
    {
        public GameObject runwayGameObject;
        public string runwayNo;
        public int airDirectionRedMin;
        public int airDirectionRedMax;
        internal int emgRunwayCounter;
    }

    [SerializeField]
    public AirDirectionMinMaxForClosedRunway[] tailWindAndEmgConditionForRunwaySignal;

    
    //For Score Management
    public int targetScore, highScore, levelNumber;

    //For Time Management
    public string startTime, endTime;

    //For Day Time Management
    public enum timeOfTheDaytype { Morning, Noon, Evening, Night };
    [SerializeField]
    public timeOfTheDaytype timeOfTheDay;


    [Space]
    //For Cloud Properties Management
    public bool cloud;
    [Range(0f, 1f)]
    public float cloudSpeed;                 // Speed Property of clouds
    [Range(0f, 1f)]
    public float cloudDensity;               // Density Property of clouds
    public Color cloudColor;                 // Color Property of Clouds
    [Range(0f, 360f)]
    public float cloudRotation;              // Rotation of Cloud

    [Space]
    //For Fog Properties Management
    public bool fog;
    public int fogAmount;
    public Color fogColor;

    [Space]
    //For Rain Properties Management
    public bool rain;
    [Range(0, 400)]
    public float rainAmount;
    public float rainDirection;


    [Space]
    //For thunder Management
    public int thunderAmount; //(times of flashes in time spawn)
    public float thunderIntensity; //(times of flashes in time spawn)
    public bool sunRays;

    //For Snow Management
    public float snowAmount;

    //for setting up of the level decoration
    public GameObject parkedVehicles, parkedAirplanes, monorail, japanCoastGuardShip, cargoShip;


    //for setting up of the Parking Category
    public enum parkingCategoryType { Terminal1, Terminal2, InternationalTerminal, InternationalCargoTerminal, EastCargoArea, JapanCoastGuardArea, VIPMachineOnlyArea };

    [SerializeField]
    public parkingCategoryType parkingCategory;

    //for Spawning of the airplanes
    public GameObject[] arrivalAirplanesToSpawn, departureAirplanesToSpawn;

    public int allAppearedPlaneCountforLevel; // to track the count of all airplane of level for Game Over and Level Complete
    public GameObject[] decorationPlanes;

    //..........Fast Wind for given time interval...(nedd to be changed in future).........//
    //public int airDirMinForClosedRunway, airDirMaxForClosedRunway;

    // Start is called before the first frame update

    public int minForceForDisableClearToLanding;

    void Start()
    {
        TimeOfTheDay();
        ScoreManager.instance.initialTimeInSeconds = ScoreManager.instance.ConvertTextTimeIntoSeconds(ScoreManager.instance.timeTextGame.text);
        ScoreManager.instance.timer = (((int)Time.deltaTime) * ScoreManager.instance.timeSpeed) + ScoreManager.instance.initialTimeInSeconds;

        ActiveAeroplaneDecoration();
    }

    //..........CheckWindForceTime
    public int CheckCurrentWindForce()
    {
        for (int i = 0; i < setWindForceTimings.Length; i++)
        {
            int startTime =ScoreManager.instance.ConvertTextTimeIntoSeconds(setWindForceTimings[i].startTime);
            int endTime = ScoreManager.instance.ConvertTextTimeIntoSeconds(setWindForceTimings[i].endTime);
            if (ScoreManager.instance.timer > startTime && ScoreManager.instance.timer < endTime)
            {
                //print("Time Found.....");
                return i;
            }
        }
        return 0;
    }
    public void TimeOfTheDay()
    {
        if (timeOfTheDay == timeOfTheDaytype.Morning)
        {
            DayAndNight.instance.time = 5;
            DayAndNight.instance.InitDayTime();

        }

        if (timeOfTheDay == timeOfTheDaytype.Noon)
        {
            DayAndNight.instance.time = 12;
            DayAndNight.instance.InitDayTime();

        }

        if (timeOfTheDay == timeOfTheDaytype.Evening)
        {
            DayAndNight.instance.time = 17;
            DayAndNight.instance.InitDayTime();

        }

        if (timeOfTheDay == timeOfTheDaytype.Night)
        {
            DayAndNight.instance.time = 21;
            DayAndNight.instance.InitDayTime();

        }

        if (rain)
        {
            DayAndNight.instance.isRain = true;
            RainComponents.instance.emisionRate = rainAmount;

            DayAndNight.instance.thunderAmount = thunderAmount;
            DayAndNight.instance.thunderIntensity = thunderIntensity;
        }

        if (fog)
        {
            DayAndNight.instance.fog = true;
            DayAndNight.instance.fogColor = fogColor;
            DayAndNight.instance.fogEndDist = fogAmount;


        }

        if (cloud)
        {
            DayAndNight.instance.clouds.SetActive(true);
            DayAndNight.instance.cloudRotation = cloudRotation;
            DayAndNight.instance.cloudDensity = cloudDensity;
            DayAndNight.instance.cloudColor = cloudColor;
            DayAndNight.instance.cloudSpeed = cloudSpeed;

            DayAndNight.instance.CloudChange();

        }

        ScoreManager.instance.timeTextGame.text = startTime;
        
    }

    public void ActiveAeroplaneDecoration()
    {
        if (decorationPlanes != null)
        {
            for (int i = 0; i < decorationPlanes.Length; i++)
            {
                decorationPlanes[i].SetActive(true);
            }
        }
    }

    

    #region Clear to landing closed
    //.............Runway will close when there is strong wind..............//

    public void CheckFastWindForce(Transform planeTransform)
    {
        bool tailWindCondition = CheckAirDirForClearToLandingClosed(planeTransform);

        if (ScoreManager.instance.setWindForceTimingsCounter < UIManager.instance.currentLevelSelected.setWindForceTimings.Length)
        {
            int _forceVal = int.Parse(UIManager.instance.currentLevelSelected.setWindForceTimings[ScoreManager.instance.setWindForceTimingsCounter].windForce);

            if (_forceVal >= minForceForDisableClearToLanding || isEmgergencyRunwayClosed || tailWindCondition)
            {

                UIManager.instance.clearToLandingCmd.GetComponent<Button>().enabled = false;
                UIManager.instance.clearToLandingCmd.GetComponent<Image>().color = new Color32(75, 75, 75, 255);
            }
            else
            {
                UIManager.instance.clearToLandingCmd.GetComponent<Button>().enabled = true;
                UIManager.instance.clearToLandingCmd.GetComponent<Image>().color = new Color32(75, 75, 75, 0);
            }
        }
        
    }

    public static bool isEmgergencyRunwayClosed;
    public void CheckEmergencyPlane(Transform planeTransform)
    {
        if (planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)// ||
           // planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.GearTrouble
            

        {
            isEmgergencyRunwayClosed = true;
        }
    }

    //...........Need to changed in future ..........When Emergency aircraft is removed from runway............//

    public void CheckEmgAircraftIsRemovedOrNot()
    {
        isEmgergencyRunwayClosed = false;
    }

    public bool CheckAirDirForClearToLandingClosed(Transform _planeNoTransform)
    {
        string currentRunway = _planeNoTransform.GetComponent<RadarScript>().rWYArrival.Substring(0, 3);
        if (tailWindAndEmgConditionForRunwaySignal.Length != 0)
        {
            for (int i = 0; i < tailWindAndEmgConditionForRunwaySignal.Length; i++)
            {
                if (tailWindAndEmgConditionForRunwaySignal[i].runwayNo == currentRunway)
                {
                    if (RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z > (tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMin - 20) &&
                             RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z < (tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMax + 20))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    #endregion

    #region Runway closed status for other aircrafts i.e. runway is safe, unsafe or danger
    //.........Runway closed status for other aircrafts i.e. runway is safe, unsafe or danger.........//

    public void OpenSingleColorOfRunwaySelection(GameObject Runway, string _openColor)
    {

        for (int i = 3; i < 6; i++)
        {
            Runway.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (_openColor == "safe")
        {
            Runway.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (_openColor == "unsafe")
        {
            Runway.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (_openColor == "danger")
        {
            Runway.transform.GetChild(5).gameObject.SetActive(true);
        }

    }


    public void CheckLandingStatusForArrivalAricraft()
    {
        if (tailWindAndEmgConditionForRunwaySignal.Length != 0)
        {
            for (int i = 0; i < tailWindAndEmgConditionForRunwaySignal.Length; i++)
            {
                if (tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter == 0)
                {
                    OpenSingleColorOfRunwaySelection(tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject, "safe");
                }
                else if (tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter == 1)
                {
                    OpenSingleColorOfRunwaySelection(tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject, "unsafe");
                }
                else if (tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter == 2)
                {
                    OpenSingleColorOfRunwaySelection(tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject, "danger");
                }
            }
        }
    }

    //.............Check wind condition For safe unsafe and danger ........//
    public void TailWindForRedColor()
    {
        int _forceVal = int.Parse(UIManager.instance.currentLevelSelected.setWindForceTimings[ScoreManager.instance.setWindForceTimingsCounter].windForce);

        for (int i = 0; i < tailWindAndEmgConditionForRunwaySignal.Length; i++)
        {
            for (int j = 3; j < 6; j++)
            {
                tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject.transform.GetChild(j).gameObject.SetActive(false);
            }

            if (_forceVal >= minForceForDisableClearToLanding)
            {
                if (RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z > tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMin &&
                    RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z < tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMax
                    )

                {
                    tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject.transform.GetChild(5).gameObject.SetActive(true);

                }

                else if ((RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z >= (tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMin - 20) &&
                     RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z <= tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMin) ||
                    (RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z >= tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMax &&
                     RadarManagerScript.instance.birdEyeView.transform.localEulerAngles.z <= (tailWindAndEmgConditionForRunwaySignal[i].airDirectionRedMax + 20))
                    )
                {
                    tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject.transform.GetChild(4).gameObject.SetActive(true);
                }
                else
                {
                    tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject.transform.GetChild(3).gameObject.SetActive(true);
                }
            }
            else
            {
                tailWindAndEmgConditionForRunwaySignal[i].runwayGameObject.transform.GetChild(3).gameObject.SetActive(true);
            }

        }
    }


    public void CheckEmergencyAircraftAfterRunwaySelection(Transform planeTransform, string runway)
    {
        if (planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)// ||
            //planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.GearTrouble
            //)

        {
            if (tailWindAndEmgConditionForRunwaySignal.Length != 0)
            {
                for (int i = 0; i < tailWindAndEmgConditionForRunwaySignal.Length; i++)
                {
                    if (runway == tailWindAndEmgConditionForRunwaySignal[i].runwayNo)
                    {
                        tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter++;
                    }
                }
            }


        }
    }

    public void CheckEmergencyAircraftAgainAtRunwayExit(Transform planeTransform)
    {
        if (planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.SmokeFromEngine)// ||
            //planeTransform.GetComponent<AircraftScripts>().airoplaneEMGEvent == AircraftScripts.airoplaneEMGEventType.GearTrouble
            //)

        {
            if (tailWindAndEmgConditionForRunwaySignal.Length != 0)
            {
                for (int i = 0; i < tailWindAndEmgConditionForRunwaySignal.Length; i++)
                {
                    if (tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter == 1)
                    {
                        tailWindAndEmgConditionForRunwaySignal[i].emgRunwayCounter++;
                    }
                }
            }

        }
    }

    #endregion

    
}
