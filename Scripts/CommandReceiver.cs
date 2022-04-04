using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CommandReceiver : MonoBehaviour
{
    public static CommandReceiver instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    //................Arrival section(Approach) ............................//
    #region Arrival Approach
    public string ArrivalApproach(string _flightNo, string _altA, string _altB, string _atisCode)
    {
        return "Tokyo Approach, " + _flightNo + ", leaving " + _altA + " to " + _altB + ", we have information " + _atisCode + ".";
    }

    public List<AudioClip> ArrivalApproachAudio(AudioClip _flightNo, AudioClip _altA1, AudioClip _altA2, AudioClip _altA3, AudioClip _altB1, AudioClip _altB2, AudioClip _altB3, AudioClip _atisCode, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoApproach);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.leaving);
        clipList.Add(_altA1);
        clipList.Add(_altA2);
        clipList.Add(_altA3);
        clipList.Add(atcScript.to);
        clipList.Add(_altB1);
        clipList.Add(_altB2);
        clipList.Add(_altB3);
        clipList.Add(atcScript.weHaveInformation);
        clipList.Add(_atisCode);
        return clipList;
    }

    //............ User selects Runway to land & route............
    #region Runway to land & route
    public string RunWayToLand(string _flightNo, string _runwayNo, string _flyDir, string _altNew)
    {
        return _flightNo + ", Tokyo Approach, runway " + _runwayNo + ", heading " + _flyDir + " vector to final approach course, descend and maintain " + _altNew + ".";
    }

    public List<AudioClip> RunWayToLandAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.tokoyoApproach);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.vectorToFinalApproachCourse);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string RunWayToLandAgain(string _runwayNo, string _flyDir, string _altNew, string _flightNo)
    {
        return "Roger, runway " + _runwayNo + ", heading " + _flyDir + ", descend and maintain " + _altNew + ", " + _flightNo + ".";
    }

    public List<AudioClip> RunWayToLandAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion

    //............. If user selects "Detour Route".............
    #region selects Detour Route

    public string SelectDetourRoute(string _flightNo, string _flyDir, string _cardinalDry, string _altNew)
    {
        return _flightNo + ", heading " + _flyDir + ", divert 2 miles " + _cardinalDry + " of approach course, descend and maintain " + _altNew + ".";
    }

    public List<AudioClip> SelectDetourRouteAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _cardinalDry, AudioClip _altNew1, AudioClip _thousand, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.divert2Miles);
        clipList.Add(_cardinalDry);
        clipList.Add(atcScript.ofApproachCourse);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_thousand);
        return clipList;
    }

    public string SelectDetourRouteAgain(string _flyDir, string _cardinalDry, string _altNew, string _flightNo)
    {
        return "Heading " + _flyDir + " divert 2 miles " + _cardinalDry + ", descend and maintain " + _altNew + ", " + _flightNo + ".";
    }

    public List<AudioClip> SelectDetourRouteAgainAudio(AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _cardinalDry, AudioClip _altNew1, AudioClip _thousandClip, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.divert2Miles);
        clipList.Add(_cardinalDry);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_thousandClip);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion

    //............... Maintain Aircraft Speed..................
    #region increase, decrease, maintain Aircraft speed

    public string AccelerateSpeed(string _flightNo, string _increasedFlySpeed)
    {
        return _flightNo + ", increase speed to " + _increasedFlySpeed + ".";
    }

    public List<AudioClip> AccelerateSpeedAudio(AudioClip _flightNo, AudioClip _increasedFlySpeed1, AudioClip _increasedFlySpeed2, AudioClip _increasedFlySpeed3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.increaseSpeedTo);
        clipList.Add(_increasedFlySpeed1);
        clipList.Add(_increasedFlySpeed2);
        clipList.Add(_increasedFlySpeed3);
        return clipList;
    }

    public string AccelerateAgain(string _increasedFlySpeed, string _flightNo)
    {
        return "Roger, increasing speed to " + _increasedFlySpeed + ", " + _flightNo + ".";
    }

    public List<AudioClip> AccelerateAgainAudio(AudioClip _increasedFlySpeed1, AudioClip _increasedFlySpeed2, AudioClip _increasedFlySpeed3, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.increasingSpeedTo);
        clipList.Add(_increasedFlySpeed1);
        clipList.Add(_increasedFlySpeed2);
        clipList.Add(_increasedFlySpeed3);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string DecelerateSpeed(string _flightNo, string _reducedFlySpeed)
    {
        return _flightNo + ", reduce speed to " + _reducedFlySpeed + ".";
    }

    public List<AudioClip> DecelerateSpeedAudio(AudioClip _flightNo, AudioClip _reducedFlySpeed1, AudioClip _reducedFlySpeed2, AudioClip _reducedFlySpeed3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.reduceSpeedTo);
        clipList.Add(_reducedFlySpeed1);
        clipList.Add(_reducedFlySpeed2);
        clipList.Add(_reducedFlySpeed3);
        return clipList;
    }

    public string DecelerateAgain(string _decreasedFlySpeed, string _flightNo)
    {
        return "Roger, reducing speed to " + _decreasedFlySpeed + ", " + _flightNo + ".";
    }

    public List<AudioClip> DecelerateAgainAudio(AudioClip _decreasedFlySpeed1, AudioClip _decreasedFlySpeed2, AudioClip _decreasedFlySpeed3, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.reducingSpeedTo);
        clipList.Add(_decreasedFlySpeed1);
        clipList.Add(_decreasedFlySpeed2);
        clipList.Add(_decreasedFlySpeed3);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string MaintainSpeed(string _flightNo)
    {
        return _flightNo + ", maintain present speed.";
    }

    public List<AudioClip> MaintainSpeedAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.maintainPresentSpeed);
        return clipList;
    }

    public string MaintainAgain(string _flightNo)
    {
        return "Roger, maintaining present speed, " + _flightNo + ".";
    }

    public List<AudioClip> MaintainAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.maintainingPresentSpeed);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion

    //................Tower Control Hand-Off....................
    #region Tower Control Hand-Off

    public string ArrivalTowerCtrlHandOff(string _flightNo, string _apprRoute, string _runwayNo)
    {
        return _flightNo + ", cleared for " + _apprRoute + ", runway " + _runwayNo + " approach, contact Tower 118.1.";
    }

    public List<AudioClip> ArrivalTowerCtrlHandOffAudio(AudioClip _flightNo, AudioClip _apprRoute, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.clearedfor);
        clipList.Add(_apprRoute);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.approach);
        clipList.Add(atcScript.contactTower118);
        return clipList;
    }

    public string ArrivalTowerCtrlHandOffAgain(string _apprRoute, string _runwayNo, string _flightNo)
    {
        return "Cleared for " + _apprRoute + ", runway " + _runwayNo + " approach, contacting Tower, " + _flightNo + ".";
    }

    public List<AudioClip> ArrivalTowerCtrlHandOffAgainAudio(AudioClip _flightNo, AudioClip _apprRoute, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.clearedfor);
        clipList.Add(_apprRoute);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.approach);
        clipList.Add(atcScript.contactingTower);
        clipList.Add(_flightNo);
        return clipList;
    }

    //....................... Arrival section(Tower) .................
    public string ArrivalTower(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", approaching final.";
    }

    public List<AudioClip> ArrivalTowerAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.approachingFinal);
        return clipList;
    }

    #endregion

    //...............Clear to Land.........................
    #region Clear to Land
    public string ArrivalClearToLanding(string _flightNo, string _runwayNo, string _windDir, string _windForce)
    {
        return _flightNo + ", runway " + _runwayNo + ", wind " + _windDir + " at " + _windForce + ", cleared to land.";
    }

    public List<AudioClip> ArrivalClearToLandingAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.wind);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(_windDir3);
        clipList.Add(atcScript.at);
        clipList.Add(_windForce1);
        clipList.Add(_windForce2);
        clipList.Add(atcScript.clearedToLand);
        return clipList;
    }

    public string ArrivalClearToLandingAgain(string _runwayNo, string _flightNo)
    {
        return "Runway " + _runwayNo + ", cleared to land, " + _flightNo + ".";

    }

    public List<AudioClip> ArrivalClearToLandingAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.clearedToLand);
        clipList.Add(_flightNo);
        return clipList;
    }

    //.......After aircraft lands on runway and ask for taxi route, after selecting A6 to ground.

    public string ArrivalTexiRoute(string _flightNo, string _LRDir, string _runwayExit)
    {
        return _flightNo + ", turn " + _LRDir + " " + _runwayExit + ", contact Ground 121.7.";
    }

    public List<AudioClip> ArrivalTexiRouteAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactGround127);
        return clipList;
    }

    public string ArrivalTexiRouteAgain(string _LRDir, string _runwayExit, string _flightNo)
    {
        return "Turn " + _LRDir + " " + _runwayExit + ", contact Ground, " + _flightNo + ".";
    }

    public List<AudioClip> ArrivalTexiRouteAgainAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactGround);
        clipList.Add(_flightNo);
        return clipList;
    }

    //............ If user chooses "Standby Taxi"

    public string ArvStandByText(string _flightNo)
    {
        return _flightNo + ", continue hold, due to traffic.";
    }

    public List<AudioClip> ArvStandByTextAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(_flightNo);
        clips.Add(atcScript.continueHold);

        clips.Add(atcScript.dueToTraffic);

        return clips;
    }

    public string ArvStandByTextAgain(string _flightNo)
    {
        return "Roger, continuing hold, " + _flightNo + ".";
    }

    public List<AudioClip> ArvStandByTextAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.roger);

        clips.Add(atcScript.continuingHold);
        clips.Add(_flightNo);


        return clips;
    }

    #endregion

    //.................Go Around................
    #region GoAround

    public string ArrivalGoAround(string _flightNo)
    {
        return _flightNo + ", go around.";
    }

    public List<AudioClip> ArrivalGoAroundAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.goAround);
        return clipList;
    }

    public string ArrivalGoAroundAgain()
    {
        return "We'll go around.";

    }

    public List<AudioClip> ArrivalGoAroundAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.wellGoAround);
        return clipList;
    }

    //..........when user can choose "Departure Control Hand-Off"....................
    public string DepartureHandOff(string _flightNo)
    {
        return _flightNo + ", contact Departure 126.0.";
    }

    public List<AudioClip> DepartureHandOffAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.contactDeparture126);
        return clipList;
    }

    public string DepartureHandOffAgain(string _flightNo)
    {
        return "Contacting Departure," + _flightNo + ".";//, good day.";
    }

    public List<AudioClip> DepartureHandOffAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.contactingDeparture);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string DepartureHandOffAgainGoodDay()
    {
        return "Contacting Departure, good day.";
    }

    public List<AudioClip> DepartureHandOffAgainGoodDayAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.contactingDeparture);
        clipList.Add(atcScript.goodDay);
        return clipList;
    }

    public string ArrivalTokyoDep(string _flightNo)
    {
        return "Tokyo Departure, " + _flightNo + ", we're going around.";
    }

    public List<AudioClip> ArrivalTokyoDepAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.wereGoingAround);
        return clipList;
    }

    public string ArrivalApproachCtrlHandOff(string _flightNo, string _LRDir, string _flyDir, string _waypoint, string _altNew)
    {
        return _flightNo + ", Tokyo Departure, radar contact, turn " + _LRDir + " heading " + _flyDir + " vector to " + _waypoint + ", climb and maintain " + _altNew + ", contact Approach.";
    }

    public List<AudioClip> ArrivalApproachCtrlHandOffAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _waypoint, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(atcScript.radarContact);
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.vectorTo);
        clipList.Add(_waypoint);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(atcScript.contactApproach);
        return clipList;
    }

    public string ArrivalApproachCtrlHandOffTurn(string _LRDir, string _flyDir, string _altNew, string _flightNo)
    {
        return "Turn " + _LRDir + " heading " + _flyDir + " climb and maintain " + _altNew + ", contact Approach, " + _flightNo + ".";
    }

    public List<AudioClip> ArrivalApproachCtrlHandOffTurnAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(atcScript.heading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);

        clipList.Add(atcScript.contactApproach);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string ArrivalApproachCtrlHandOffTokyo(string _flightNo, string _alt)
    {
        return "Tokyo Approach, " + _flightNo + ", we're going around, maintaining " + _alt + ".";
    }

    public List<AudioClip> ArrivalApproachCtrlHandOffTokyoAudio(AudioClip _flightNo, AudioClip _alt1, AudioClip _alt2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoApproach);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.wereGoingAround);
        clipList.Add(atcScript.maintaining);
        clipList.Add(_alt1);
        clipList.Add(_alt2);
        return clipList;
    }
    //.......choose the Runway and Route for the airplane to land


    public string TokyoApproachCtrlHandOff(string _flightNo, string _runwayNo, string _windDir, string _windForce, string _barometricAlt)
    {
        return _flightNo + ", Tokyo Approach, use runway " + _runwayNo + ", continue approach, wind " + _windDir + " at " + _windForce + ", QNH " + _barometricAlt + ".";
    }

    public List<AudioClip> TokyoApproachCtrlHandOffAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(_flightNo);
        clipList.Add(atcScript.tokyoApproach);
        clipList.Add(atcScript.use);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.continueApproach);
        clipList.Add(atcScript.wind);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(atcScript.at);
        clipList.Add(_windForce);
        clipList.Add(atcScript.QNH);
        clipList.Add(_barometricAlt1);
        clipList.Add(_barometricAlt2);
        clipList.Add(_barometricAlt3);
        clipList.Add(_barometricAlt4);
        return clipList;
    }

    //Roger, runway %RunwayNo%, continuing approach, %FlightNo%.
    public string TokyoApproachCtrlHandOffAgain(string _runwayNo, string _flightNo)
    {
        return "Roger, runway " + _runwayNo + ", continuing approach, " + _flightNo + ".";
    }

    public List<AudioClip> TokyoApproachCtrlHandOffAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.continueApproach);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion

    #endregion

    //..................Departure section(Ground):- ........................//
    #region Departure Section

    public string DepartureOnGround(string _flightNo)   //.........when strip Appears.....//
    {
        return "Tokyo Ground, " + _flightNo + ", on your frequency.";
    }

    public List<AudioClip> DepartureOnGroundAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(atcScript.tokyoGround);
        clips.Add(_flightNo);
        clips.Add(atcScript.onYourFrequency);

        return clips;
    }

    //............ If user chooses "Standby Taxi"

    public string StandByText(string _flightNo)
    {
        return _flightNo + ", stand-by taxi, due to traffic.";
    }

    public List<AudioClip> StandByTextAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(_flightNo);
        clips.Add(atcScript.standByTaxi);

        clips.Add(atcScript.dueToTraffic);

        return clips;
    }

    public string StandByTextAgain(string _flightNo)
    {
        return "Roger, standing-by, " + _flightNo + ".";
    }

    public List<AudioClip> StandByTextAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.roger);

        clips.Add(atcScript.standingBy);
        clips.Add(_flightNo);


        return clips;
    }
    //............ After selecting taxi route and spot.........

    public string DepartureTexiRoute(string _flightNo, string _spotNo)
    {
        return _flightNo + ", Tokyo Ground, taxi to Spot " + _spotNo + ".";
    }

    public List<AudioClip> DepartureTexiRouteAudio(AudioClip _flightNo, AudioClip _spotNo1, AudioClip _spotNo2, AudioClip _spotNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.tokyoGround);

        clips.Add(atcScript.taxiToSpot);
        clips.Add(_spotNo1);
        clips.Add(_spotNo2);
        clips.Add(_spotNo3);

        return clips;
    }

    public string DepartureTexiToSpot(string _spotNo, string _flightNo)
    {
        return "Taxi to Spot " + _spotNo + ", " + _flightNo + ".";
    }
    public List<AudioClip> DepartureTexiToSpotAudio(AudioClip _flightNo, AudioClip _spotNo1, AudioClip _spotNo2, AudioClip _spotNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(atcScript.taxiToSpot);
        clips.Add(_spotNo1);
        clips.Add(_spotNo2);
        clips.Add(_spotNo3);
        clips.Add(_flightNo);

        return clips;
    }
    //.....................Departure section(delivery).............

    public string DepartureTokyoDelivery(string _flightNo)
    {
        return "Tokyo Delivery, " + _flightNo + ", request clearance.";
    }

    public List<AudioClip> DepartureTokyoDeliveryAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(atcScript.tokyoDelivery);

        clips.Add(_flightNo);
        clips.Add(atcScript.requestClearance);
        return clips;
    }

    //................... If user chooses "Standby"............

    public string DepStandBy(string _flightNo)
    {
        return _flightNo + ", stand-by clearance.";
    }

    public List<AudioClip> DepStandByAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.standByClearance);
        return clips;
    }
    public string DepStandByAgain(string _flightNo)
    {
        return "Roger, standing-by, " + _flightNo + ".";
    }

    public List<AudioClip> DepStandByAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.roger);
        clips.Add(atcScript.standingBy);
        clips.Add(_flightNo);

        return clips;
    }
    //................If user chooses "Departure Approval

    public string DepartureApproval(string _flightNo, string _destination, string _depRoute, string _flightLvl, string _code)
    {
        return _flightNo + ", cleared to " + _destination + " via " + _depRoute + " Departure, flight planned route, maintain flight level " + _flightLvl + ", squawk " + _code + ". Read back.";
    }

    public List<AudioClip> DepartureApprovalAudio(AudioClip _flightNo, AudioClip _destination, AudioClip _depRoute, AudioClip _flightLvl1, AudioClip _flightLvl2, AudioClip _flightLvl3, AudioClip _code1, AudioClip _code2, AudioClip _code3, AudioClip _code4, GameObject personSound)

    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.clearedTo);
        clips.Add(_destination);
        clips.Add(atcScript.via);
        clips.Add(_depRoute);
        //clips.Add(ATC.instance.departure);
        clips.Add(atcScript.flightPlannedRouteMaintainFlightLevel);
        clips.Add(_flightLvl1);
        clips.Add(_flightLvl2);
        clips.Add(_flightLvl3);
        clips.Add(atcScript.squawk);
        clips.Add(_code1);
        clips.Add(_code2);
        clips.Add(_code3);
        clips.Add(_code4);
        clips.Add(atcScript.readBack);

        return clips;
    }

    public string DepartureApprovalAgain(string _destination, string _depRoute, string _flightLvl, string _code, string _flightNo)
    {
        return "Cleared to " + _destination + " via " + _depRoute + " Departure, flight planned route, maintain flight level " + _flightLvl + ", squawk " + _code + ", " + _flightNo + ".";
    }

    public List<AudioClip> DepartureApprovalAgainAudio(AudioClip _destination, AudioClip _depRoute, AudioClip _flightLvl1, AudioClip _flightLvl2, AudioClip _flightLvl3, AudioClip _code1, AudioClip _code2, AudioClip _code3, AudioClip _code4, AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(atcScript.clearedTo);
        clips.Add(_destination);
        clips.Add(atcScript.via);
        clips.Add(_depRoute);
        //clips.Add(ATC.instance.departure);
        clips.Add(atcScript.flightPlannedRouteMaintainFlightLevel);
        clips.Add(_flightLvl1);
        clips.Add(_flightLvl2);
        clips.Add(_flightLvl3);
        clips.Add(atcScript.squawk);
        clips.Add(_code1);
        clips.Add(_code2);
        clips.Add(_code3);
        clips.Add(_code4);

        clips.Add(_flightNo);
        return clips;
    }
    public string DeparturePushBack(string _flightNo)
    {
        return _flightNo + ", read back is correct, contact ground when ready for pushback.";
    }
    public List<AudioClip> DeparturePushBackAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(_flightNo);
        clips.Add(atcScript.readBackCorrectPushBack);

        return clips;
    }
    public string DeparturePushBackReady(string _flightNo)
    {
        return "Roger, contacting Ground when ready for pushback, " + _flightNo + ".";
    }
    public List<AudioClip> DeparturePushBackReadyAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.roger);

        clips.Add(atcScript.contactingWhenReadyPushback);
        clips.Add(_flightNo);

        return clips;
    }
    //After some time when the airplane is ready it will contact the ATC again

    public string DepPushBackRequest(string _flightNo)
    {
        return "Tokyo Ground, " + _flightNo + ", request push-back.";
    }
    public List<AudioClip> DepPushBackRequestAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.tokyoGround);

        clips.Add(_flightNo);
        clips.Add(atcScript.requestPushBack);
        return clips;
    }
    //....................After runway and route selection................

    public string DeparturePushBackApproved(string _flightNo, string _runwayNo)
    {
        return _flightNo + ", pushback approved, runway " + _runwayNo + ".";
    }
    public List<AudioClip> DeparturePushBackApprovedAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.pushBackApproved);
        clips.Add(atcScript.runway);
        clips.Add(_runwayNo1);
        clips.Add(_runwayNo2);
        clips.Add(_runwayNo3);
        return clips;
    }
    public string DeparturePushBackApprovedAgain(string _flightNo, string _runwayNo)
    {
        return _flightNo + ", pushback approved, runway " + _runwayNo + ", " + _flightNo + ".";
    }
    public List<AudioClip> DeparturePushBackApprovedAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.pushBackApproved);
        clips.Add(atcScript.runway);
        clips.Add(_runwayNo1);
        clips.Add(_runwayNo2);
        clips.Add(_runwayNo3);
        clips.Add(_flightNo);
        return clips;
    }
    public string DepartureReqTexi(string _flightNo)
    {
        return "Tokyo Ground, " + _flightNo + ", request taxi.";
    }
    public List<AudioClip> DepartureReqTexiAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();
        clips.Add(atcScript.tokyoGround);
        clips.Add(_flightNo);

        clips.Add(atcScript.requestTaxi);

        return clips;
    }
    public string DepartureClearToTexi(string _flightNo, string _runwayNo)
    {
        return _flightNo + ", taxi to runway " + _runwayNo + ".";
    }
    public List<AudioClip> DepartureClearToTexiAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clips = new List<AudioClip>();

        clips.Add(_flightNo);
        clips.Add(atcScript.texiToRunway);
        clips.Add(_runwayNo1);
        clips.Add(_runwayNo2);
        clips.Add(_runwayNo3);
        return clips;
    }
    public string DepartureClearToTexiAgain(string _flightNo, string _runwayNo)
    {
        return "Taxi to runway " + _runwayNo + ", " + _flightNo + ".";
    }
    public List<AudioClip> DepartureClearToTexiAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.texiToRunway);

        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(_flightNo);
        return clipList;
    }
    //.............if you hold aircraft in-between them.....
    public string DepartureHoldOn(string _flightNo)
    {
        return _flightNo + ", hold present position.";
    }

    public List<AudioClip> DepartureHoldOnAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.holdPresentPosition);
        return clipList;
    }

    public string DepartureHoldOnAgain(string _flightNo)
    {
        return "Roger, holding present position, " + _flightNo + ".";
    }

    public List<AudioClip> DepartureHoldOnAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.holdingPresentPosition);
        clipList.Add(_flightNo);
        return clipList;
    }

    //..................Aircraft after pressing resume taxiing...........

    public string DepartureResumeHoldOn(string _flightNo)
    {
        return _flightNo + ", continue taxi.";
    }

    public List<AudioClip> DepartureResumeHoldOnAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.continueTaxi);
        return clipList;
    }

    public string DepartureResumeHoldOnAgian(string _flightNo)
    {
        return "Roger, continuing taxi, " + _flightNo + ".";
    }

    public List<AudioClip> DepartureResumeHoldOnAgianAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.continuingTaxi);
        clipList.Add(_flightNo);
        return clipList;
    }

    //.......After selecting Tower control handoff...............

    public string DepartureTowerCtrlHandOff(string _flightNo)
    {
        return _flightNo + ", contact Tower 118.1.";
    }

    public List<AudioClip> DepartureTowerCtrlHandOffAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.contactTower118);
        return clipList;
    }

    public string DepartureTowerCtrlHandOffAgain(string _flightNo)
    {
        return "Contacting Tower, " + _flightNo + ".";
    }

    public List<AudioClip> DepartureTowerCtrlHandOffAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.contactingTower);
        clipList.Add(_flightNo);
        return clipList;
    }

    //...............Departure(Tower section):- ............

    public string TokyoTowerCtrlHandOff(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", on your frequency.";
    }

    public List<AudioClip> TokyoTowerCtrlHandOffAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.onYourFrequency);
        return clipList;
    }

    public string HoldShortOfRunway(string _flightNo, string _runwayNo)
    {
        return _flightNo + ", hold short of runway " + _runwayNo + ".";
    }

    public List<AudioClip> HoldShortOfRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.holdShortOfRunway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string HoldShortOfRunwayAgain(string _flightNo, string _runwayNo)
    {
        return "Roger, hold short of runway " + _runwayNo + ", " + _flightNo + ".";
    }

    public List<AudioClip> HoldShortOfRunwayAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.holdShortOfRunway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string LineUpAndWait(string _flightNo, string _runwayNo)
    {
        return _flightNo + ", runway " + _runwayNo + ", line up and wait.";
    }

    public List<AudioClip> LineUpAndWaitAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.lineUpAndWait);
        return clipList;
    }

    public string LineUpAndWaitAgain(string _flightNo, string _runwayNo)
    {
        return "Roger, runway " + _runwayNo + ", line up and wait, " + _flightNo + ".";
    }

    public List<AudioClip> LineUpAndWaitAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.lineUpAndWait);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string ReadyForDep(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", ready for departure.";
    }

    public List<AudioClip> ReadyForDepAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.readyForDeparture);
        return clipList;
    }

    public string DepartureTakeOff(string _flightNo, string _runwayNo, string _windDir, string _windForce)
    {
        return _flightNo + ", runway " + _runwayNo + ", wind " + _windDir + " at " + _windForce + ", cleared for takeoff.";
    }

    public List<AudioClip> DepartureTakeOffAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.wind);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(_windDir3);
        clipList.Add(atcScript.at);
        clipList.Add(_windForce1);
        clipList.Add(_windForce2);
        clipList.Add(atcScript.clearTakeOff);
        return clipList;
    }

    public string DepartureTakeOffAgain(string _runwayNo, string _windDir, string _windForce, string _flightNo)
    {
        return "Runway " + _runwayNo + ", " + _windDir + ", " + _windForce + ", cleared for takeoff, " + _flightNo + ".";
    }

    public List<AudioClip> DepartureTakeOffAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(_windForce1);
        clipList.Add(_windForce2);
        clipList.Add(_windDir3);
        clipList.Add(atcScript.clearTakeOff);
        clipList.Add(_flightNo);
        return clipList;
    }


    //public string DepartureHandOffAgainAgain()
    //{
    //    return "Good day.";
    //}
    //.............. After some time in air...............

    public string DepartureInAir(string _flightNo, string _altNew)
    {
        return "Tokyo Departure, " + _flightNo + ", climbing " + _altNew + ".";
    }

    public List<AudioClip> DepartureInAirAudio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _thousand, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.climbing);
        clipList.Add(_altNew1);
        clipList.Add(_thousand);
        return clipList;
    }

    //...............if you press radar control option then.........
    //%FlightNo%, Tokyo Departure, radar contact, fly heading %FlyDir% for vector to %Waypoint%, comply with restriction.
    //Flying heading %FlyDir% for vector to %Waypoint%, comply with restriction, %FlightNo%.

    public string ChooseRadarCtrl(string _flightNo, string _flyDir, string _wayPoint)
    {
        return _flightNo + ", Tokyo Departure, radar contact, fly heading " + _flyDir + " for vector to " + _wayPoint + ", comply with restriction.";
    }

    public List<AudioClip> ChooseRadarCtrlAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _wayPoint, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(atcScript.radarContact);
        clipList.Add(atcScript.flyHeading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.forVectorTo);
        clipList.Add(_wayPoint);
        clipList.Add(atcScript.complyToRestriction);
        return clipList;
    }

    public string ChooseRadarCtrlAgain(string _flightNo, string _flyDir, string _wayPoint)
    {
        return "Flying heading " + _flyDir + " for vector to " + _wayPoint + ", comply with restriction, " + _flightNo + ".";
    }

    public List<AudioClip> ChooseRadarCtrlAgainAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _wayPoint, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.flyHeading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        clipList.Add(atcScript.forVectorTo);
        clipList.Add(_wayPoint);
        clipList.Add(atcScript.complyToRestriction);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string DepartureRadarCtrl(string _flightNo)
    {
        return _flightNo + ", contact Tokyo Control 123.0.";
    }

    public List<AudioClip> DepartureRadarCtrlAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.contactCtrl123);
        return clipList;
    }

    public string DepartureRadarCtrlAgain()
    {
        return "Contacting Tokyo Control, good day.";
    }

    public List<AudioClip> DepartureRadarCtrlAgainAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.contactingTokyoCtrl);
        clipList.Add(atcScript.goodDay);
        return clipList;
    }

    public string DepartureRadarCtrlAgainAgain()
    {
        return "Good day.";
    }

    public List<AudioClip> DepartureRadarCtrlAgainAgainAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.goodDay);
        return clipList;
    }

    #endregion

    //....................New Commands......................................//
    #region Change spot event For Departure plane

    public string SpotChangeAircraft(string airserveNo, string currentSpot, string endSpot)
    {
        return "Ground, Haneda Airserve " + airserveNo + ", at spot " + currentSpot + ", request towing to spot " + endSpot + ".";
    }

    public List<AudioClip> SpotChangeAircraftAudio(AudioClip _airserveNo, AudioClip _currentSpot, AudioClip _endSpot, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(_airserveNo);
        clipList.Add(_currentSpot);
        clipList.Add(_endSpot);
        clipList.Add(atcScript.tw_rjtt_04);

        return clipList;
    }

    public string StartTowingSpot(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", Ground, " + "start towing.";
    }

    public List<AudioClip> StartTowingSpotAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.gndStartTowing);

        return clipList;
    }

    public string StartTowingSpotAgain(string airserveNo)
    {
        return "Roger, " + "start towing, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> StartTowingSpotAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerStartTowing);

        clipList.Add(_airserveNo);

        return clipList;
    }


    public string HoldPositionSpot(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", Ground, " + "hold position.";
    }

    public List<AudioClip> HoldPositionSpotAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.gndHoldPosition);

        return clipList;
    }

    public string HoldPositionSpotAgain(string airserveNo)
    {
        return "Roger, " + "hold position, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> HoldPositionSpotAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerHoldPosition);

        clipList.Add(_airserveNo);

        return clipList;
    }

    public string TowingHoldPosition(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", " + "hold present position.";
    }

    public List<AudioClip> TowingHoldPositionAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.holdPresentPositionInSpotChange);
        return clipList;
    }

    public string TowingHoldPositionAgain(string airserveNo)
    {
        return "Roger, " + "hold present position, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> TowingHoldPositionAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerHoldintPresentPosition);

        clipList.Add(_airserveNo);

        return clipList;
    }

    public string ContinueTowing(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", continue towing.";
    }

    public List<AudioClip> ContinueTowingAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.continueTowingInSpotChange);
        return clipList;
    }

    public string ContinueTowingAgain(string airserveNo)
    {
        return "Roger, " + "continue towing, Haneda Airserve " + airserveNo;
    }

    public List<AudioClip> ContinueTowingAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerContinueTowingInSpotChange);

        clipList.Add(_airserveNo);

        return clipList;
    }

    public string ChangeRoute(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", change your route";
    }

    public List<AudioClip> ChangeRouteAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.changeYourRouteInSpotChange);
        return clipList;
    }

    public string ChangeRouteAgain(string airserveNo)
    {
        return "Changing route, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> ChangeRouteAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.changingRouteInSpotChange);
        clipList.Add(_airserveNo);

        return clipList;
    }

    public string RequestCrossRunway(string airserveNo)
    {
        return "Ground, Haneda Airserve " + airserveNo + ", " + "request cross runway.";
    }

    public List<AudioClip> RequestCrossRunwayAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.requestCrossRunwayInSpotChange);
        clipList.Add(_airserveNo);

        //clipList.Add(ATC.instance.requestCrossRunway);
        return clipList;
    }

    public string RequestCrossRunwayHoldPosition(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", " + "Ground, " + "hold position.";
    }

    public List<AudioClip> RequestCrossRunwayHoldPositionAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.gndHoldPosition);

        return clipList;
    }

    public string RequestCrossRunwayHoldPositionAgain(string airserveNo)
    {
        return "Roger, " + "hold position, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> RequestCrossRunwayHoldPositionAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerHoldPosition);

        clipList.Add(_airserveNo);

        return clipList;
    }

    public string RequestCrossRunwayClearToCrossRunway(string airserveNo)
    {
        return "Haneda Airserve " + airserveNo + ", " + "Ground, " + "runway is clear, " + "please cross.";
    }

    public List<AudioClip> RequestCrossRunwayClearToCrossRunwayAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_airserveNo);

        clipList.Add(atcScript.runwayIsClearPleaseCross);

        return clipList;
    }

    public string RequestCrossRunwayClearToCrossRunwayAgain(string airserveNo)
    {
        return "Roger, " + "crossing runway, Haneda Airserve " + airserveNo + ".";
    }

    public List<AudioClip> RequestCrossRunwayClearToCrossRunwayAgainAudio(AudioClip _airserveNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.rogerCrossingRunway);

        clipList.Add(_airserveNo);

        return clipList;
    }

    #endregion


    #region EMG events: Rescue Events

    public string EmergencyCallForRescueEvents()
    {
        return "Emergency call for Japan coast guard. 118 from a large cargo ship, there has been an assumed crash with a small ship 5 kilos off the coast of Inubosaki. Head to the scene immediately. Report situation.";
    }

    public List<AudioClip> EmergencyCallForRescueEventsAudio(GameObject personSound)
    {
        List<AudioClip> clipList = new List<AudioClip>();

        ATC atcScript = personSound.GetComponent<ATC>();

        clipList.Add(atcScript.evdScrInfoE_1);
        return clipList;
    }

    public string EmergencyCallForRescueEventsPilot()
    {
        return "Roger that, heading to the scene immediately.";
    }

    public List<AudioClip> EmergencyCallForRescueEventsPilotAudio(GameObject personSound)
    {
        List<AudioClip> clipList = new List<AudioClip>();

        ATC atcScript = personSound.GetComponent<ATC>();

        clipList.Add(atcScript.evdScrInfoE_2);

        return clipList;
    }

    public string EmergencyCallForRescueEventAgain()
    {
        return "Tokyo ground control, JCG1, emergency off the Inubosaki coast, request takeoff from runway 04.";
    }

    public List<AudioClip> EmergencyCallForRescueEventAgainAudio(GameObject personSound)
    {
        List<AudioClip> clipList = new List<AudioClip>();

        ATC atcScript = personSound.GetComponent<ATC>();

        clipList.Add(atcScript.evdScrInfoE_3_1);

        return clipList;
    }

    public string AfterRescueEvents(string _flightNo, string _runwayNo, string _barometricAlt)
    {
        return _flightNo + ", " + "taxi to runway" + _runwayNo + ", " + "QNH" + _barometricAlt + ".";
    }

    public List<AudioClip> AfterRescueEventsAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(_flightNo);
        clipList.Add(atcScript.taxiToRunway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.QNH);
        clipList.Add(_barometricAlt1);
        clipList.Add(_barometricAlt2);
        clipList.Add(_barometricAlt3);
        clipList.Add(_barometricAlt4);
        return clipList;
    }

    public string AfterRescueEventsAgain(string _flightNo, string _runwayNo, string _barometricAlt)
    {
        return "taxi to runway" + _runwayNo + ", " + "QNH" + _barometricAlt + ", " + _flightNo + ".";
    }

    public List<AudioClip> AfterRescueEventsAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.taxiToRunway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.QNH);
        clipList.Add(_barometricAlt1);
        clipList.Add(_barometricAlt2);
        clipList.Add(_barometricAlt3);
        clipList.Add(_barometricAlt4);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string NoAircraftInRunway(string _runwayNo, string _windDir, string _windForce)
    {
        return "Runway" + _runwayNo + ", " + "wind" + _windDir + "at" + _windForce + ", " + "cleared for takeoff.";
    }

    public List<AudioClip> NoAircraftInRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.wind);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(atcScript.at);
        clipList.Add(_windForce1);
        clipList.Add(_windForce2);
        clipList.Add(atcScript.clearForTakeOff);
        return clipList;
    }


    public string WhenAirplaneIsInAir1(string _flightNo, string _altNew, string _flyDir)
    {
        return "Tokyo Departure, " + _flightNo + ", " + "climbing for" + _altNew + ", " + "fly heading" + _flyDir + ".";
    }

    public List<AudioClip> WhenAirplaneIsInAir1Audio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.climbingFor);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(atcScript.flyHeading);
        clipList.Add(_flyDir1);
        clipList.Add(_flyDir2);
        clipList.Add(_flyDir3);
        return clipList;
    }

    public string WhenAirplaneIsInAir2(string _flightNo, string _altNew)
    {
        return _flightNo + ", " + "Tokyo Departure" + ", " + "climb and maintain" + _altNew + ", " + "contact Mission Control" + ", " + "good luck.";
    }

    public List<AudioClip> WhenAirplaneIsInAir2Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(atcScript.contactMissionControl);
        clipList.Add(atcScript.goodLuck);
        return clipList;
    }

    public string WhenAirplaneIsInAir3(string _flightNo, string _altNew)
    {
        return "Climb and maintain" + _altNew + ", " + "Contact Mission Control" + ", " + _flightNo + ".";
    }

    public List<AudioClip> WhenAirplaneIsInAir3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(atcScript.contactMissionControl);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion

    #region EMG events: Take Off Cancel

    public string TakeOffCancel(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", Reject takeoff! Engine failure, Request return to spot.";
    }

    public List<AudioClip> TakeOffCancelAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.returnSpot);

        return clipList;
    }

    public string CanTexiQues()
    {
        return "Roger, Are you able to taxi?";
    }

    public List<AudioClip> CanTexiQuesAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.canTexiQ);

        return clipList;
    }

    public string CanTexiAns()
    {
        return "We are able to taxi, thanks for your help!";
    }

    public List<AudioClip> CanTexiAnsAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.canTexiA);
        clipList.Add(atcScript.thanks);

        return clipList;
    }

    #endregion Take Off Cancle

    #region  Emergency event(Arrival): No fuel

    public string FirstLineWhenAirplaneComesIn(string _flightNo)
    {
        return "Mayday, mayday, mayday fuel, " + "Tokyo Approach, " + _flightNo + "!";
    }

    public List<AudioClip> FirstLineWhenAirplaneComesInAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.mayDay);
        clipList.Add(atcScript.tokoyoApproach);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string RadioTroubleStart(string _flightNo)
    {
        return "Mayday, Mayday, Mayday, Tokyo Approach, " + _flightNo + ", Declare emergency, Squawk 7600.";
    }

    public List<AudioClip> RadioTroubleStartAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.mayDay);
        clipList.Add(atcScript.tokoyoApproach);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.declaringEmergencyQ);
        clipList.Add(atcScript.squawk);
        clipList.Add(atcScript.seven);
        clipList.Add(atcScript.six);
        clipList.Add(atcScript.zero);
        clipList.Add(atcScript.zero);
        return clipList;
    }

    public string AfterSelectingConfirmEmergency(string _flightNo)
    {
        return _flightNo + ", " + "declaring an emergency" + "?";
    }

    public List<AudioClip> AfterSelectingConfirmEmergencyAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.declaringEmergencyQ);
        return clipList;
    }

    public string AfterSelectingConfirmEmergencyAgain()
    {
        return "Affirm, " + "declaring emergency.";
    }

    public List<AudioClip> AfterSelectingConfirmEmergencyAgainAudio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        //clipList.Add(ATC.instance.affirm);
        clipList.Add(atcScript.declaringEmergencyA);
        return clipList;
    }

    public string ReducingSpeed(string _flightNo, string _reducedFlySpeed)
    {
        return "Roger, " + "reducing speed to" + _reducedFlySpeed + ", " + _flightNo + ".";
    }

    public List<AudioClip> ReducingSpeedAudio(AudioClip _flightNo, AudioClip _reducedFlySpeed1, AudioClip _reducedFlySpeed2, AudioClip _reducedFlySpeed3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.reduceSpeedTo);
        clipList.Add(_reducedFlySpeed1);
        clipList.Add(_reducedFlySpeed2);
        clipList.Add(_reducedFlySpeed3);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string SelectRunwayExit(string _flightNo, string _LRDir, string _runwayExit)
    {
        return _flightNo + ", " + "turn " + _LRDir + " " + _runwayExit + ", " + "contact Ground 121.7. Are you able to taxi?";
    }

    public List<AudioClip> SelectRunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactGroundNumber);
        clipList.Add(atcScript.canTexiQ);
        return clipList;
    }

    public string RunwayExit(string _flightNo, string _LRDir, string _runwayExit)
    {
        return "We are able to taxi, thanks for your help! Turning " + _LRDir + _runwayExit + ", " + "contacting Ground, " + _flightNo + ".";
    }

    public List<AudioClip> RunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.canTexiA);
        clipList.Add(atcScript.thanks);
        clipList.Add(atcScript.turning);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactingGround);
        //clipList.Add(ATC.instance.ground);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion


    #region Same as normal Aircraft: Landed

    public string CrossRunwayWhileTaxing(string _flightNo)
    {
        return "Ground, " + _flightNo + "," + "request cross runway.";
    }

    public List<AudioClip> CrossRunwayWhileTaxingAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.ground);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestCrossRunway);
        return clipList;
    }

    public string CrossRunwayWhileTaxingAgain(string _flightNo)
    {
        return "Tower, " + _flightNo + ", " + "request cross runway.";
    }

    public List<AudioClip> CrossRunwayWhileTaxingAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestCrossRunway);
        return clipList;
    }

    public string AfterCrossRunwayWhileTaxingChooseStandby(string _flightNo)
    {
        return _flightNo + ", " + "continue hold.";
    }

    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseStandbyAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.continueHold);
        return clipList;
    }

    public string AfterCrossRunwayWhileTaxingChooseCrossRunway(string _flightNo)
    {
        return _flightNo + ", " + "cleared cross runway.";
    }

    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseCrossRunwayAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.clearedCrossRunway);
        return clipList;
    }

    public string AfterCrossRunwayWhileTaxingChooseCrossRunwayAgain(string _flightNo)
    {
        return "Cleared cross runway, " + _flightNo;
    }

    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseCrossRunwayAgainAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.clearedCrossRunway);
        clipList.Add(_flightNo);
        return clipList;
    }

    #endregion


    #region Emergency event(Arrival): Sick passenger

    public string SickPassengerComesIn(string _flightNo)
    {
        return "Pan - pan, pan - pan, pan - pan, " + "Tokyo Approach, " + _flightNo + "," + "passenger aboard in medical distress!";
    }

    public List<AudioClip> SickPassengerComesInAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.panPan);
        clipList.Add(atcScript.tokoyoApproach);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.passangerSick);
        return clipList;
    }

    public string SickPassengerAtRunwayExit(string _flightNo, string _LRDir, string _runwayExit)
    {
        return "" + _flightNo + ", turn " + _LRDir + " " + _runwayExit + ", contact Ground 127.7. The ambulance is standing by at spot.";
    }

    public List<AudioClip> SickPassengerAtRunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactGroundNumber);
        clipList.Add(atcScript.ambulanceStandBy);

        return clipList;
    }

    public string SickPassengerAtRunwayExitAgain(string _flightNo, string LRDir, string runwayExit)
    {
        return "Thanks for your help! Turning " + LRDir + " " + runwayExit + ", contacting Ground, " + _flightNo + ".";
    }

    public List<AudioClip> SickPassengerAtRunwayExitAgainAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.thanks);
        clipList.Add(atcScript.turn);
        clipList.Add(_LRDir);
        clipList.Add(_runwayExit1);
        clipList.Add(_runwayExit2);
        clipList.Add(atcScript.contactingGround);

        clipList.Add(_flightNo);
        return clipList;
    }


    public string GearMalfunction(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", " + "unable to taxi due to landing gear malfunction.";
    }

    public List<AudioClip> GearMalfunctionAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.gearMalfunction);
        return clipList;
    }

    public string GearMalfunction1()
    {
        return "Roger, closing your runway, hold present position.";
    }

    public List<AudioClip> GearMalfunction1Audio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.closingRunway);
        clipList.Add(atcScript.holdPresentPosition);
        return clipList;
    }

    public string GearMalfunction2()
    {
        return "Roger, Hold present position.";
    }

    public List<AudioClip> GearMalfunction2Audio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.holdPresentPosition);
        return clipList;
    }

    public string GearMalfunction3(string _closedRunwayNo)
    {
        return "All stations!All stations!runway" + _closedRunwayNo + "is closed!";
    }

    public List<AudioClip> GearMalfunction3Audio(AudioClip _closedRunwayNo1, AudioClip _closedRunwayNo2, AudioClip _closedRunwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.allStations);
        clipList.Add(atcScript.runway);
        clipList.Add(_closedRunwayNo1);
        clipList.Add(_closedRunwayNo2);
        clipList.Add(_closedRunwayNo3);
        clipList.Add(atcScript.isClosed);
        return clipList;
    }

    public string EngineProblem(string _flightNo)
    {
        return "Tokyo Tower, " + _flightNo + ", " + "unable to taxi due to No.1 engine problem.";
    }

    public List<AudioClip> EngineProblemAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.engine1Problem);
        return clipList;
    }

    public string ArrivalTestFlight(string _flightNo, string _altA, string _altB, string _atisCode, string _runwayNo)
    {
        return "Tokyo Approach, " + _flightNo + ", " + "leaving" + _altA + "to" + _altB + ", " + "we have information" + _atisCode + "and request flyby over runway" + _runwayNo;
    }

    public List<AudioClip> ArrivalTestFlightAudio(AudioClip _flightNo, AudioClip _altA1, AudioClip _altA2, AudioClip _altA3, AudioClip _altB1, AudioClip _altB2, AudioClip _altB3, AudioClip _atisCode, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoApproach);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.leaving);
        clipList.Add(_altA1);
        clipList.Add(_altA2);
        clipList.Add(_altA3);
        clipList.Add(atcScript.to);
        clipList.Add(_altB1);
        clipList.Add(_altB2);
        clipList.Add(_altB3);
        clipList.Add(atcScript.weHaveInformation);
        clipList.Add(_atisCode);
        clipList.Add(atcScript.requestFlyByRunway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string FlybyOverRunway(string _flightNo, string _runwayNo)
    {
        return "Tokyo Tower, " + _flightNo + "flyby over runway" + _runwayNo + ".";
    }

    public List<AudioClip> FlybyOverRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.flyByOver);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string ClearedToFlyby(string _runwayNo)
    {
        return "Roger, cleared to flyby runway" + _runwayNo + ".";
    }

    public List<AudioClip> ClearedToFlybyAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.clearedToFlyby);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string ClearedToFlybyAgain(string _runwayNo)
    {
        return "Thank you, Cleared to flyby runway" + _runwayNo;
    }

    public List<AudioClip> ClearedToFlybyAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.thankYou);
        clipList.Add(atcScript.clearedToFlyby);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string NextFullStop(string _flightNo)
    {
        return "Contacting Departure, " + _flightNo + ", " + "Next full stop.";
    }

    public List<AudioClip> NextFullStopAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.contactingDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.nextFullStop);
        return clipList;
    }

    public string RequestLandingRunway(string _flightNo, string _runwayNo)
    {
        return "Tokyo Departure" + _flightNo + ", " + "Request landing runway" + _runwayNo + ".";
    }

    public List<AudioClip> RequestLandingRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestLanding);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }

    public string RequestLandingRunwayAgain(string _flightNo, string _runwayNo)
    {
        return "Request landing runway" + _runwayNo + ".";
    }

    public List<AudioClip> RequestLandingRunwayAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.requestLanding);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        return clipList;
    }


    public string TouchAndGo(string _flightNo)
    {
        return "Tokyo Tower" + _flightNo + ". " + "Request touch and go.";
    }

    public List<AudioClip> TouchAndGoAudio(AudioClip _flightNo, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.tokoyoTower);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestTouchAndGo);
        return clipList;
    }

    public string TouchAndGo1(string _flightNo, string _runwayNo, string _windDir, string _windForce)
    {
        return _flightNo + ", " + "runway" + _runwayNo + ", " + "cleared touch and go, wind" + _windDir + "at" + _windForce + ".";
    }

    public List<AudioClip> TouchAndGo1Audio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.clearedTouchAndGo);
        clipList.Add(_windDir1);
        clipList.Add(_windDir2);
        clipList.Add(atcScript.at);
        clipList.Add(_windForce1);
        clipList.Add(_windForce2);
        return clipList;
    }

    public string TouchAndGo2(string _flightNo, string _runwayNo)
    {
        return "Runway" + _runwayNo + "," + "cleared touch and go, " + _flightNo + ".";
    }

    public List<AudioClip> TouchAndGo2Audio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();

        clipList.Add(atcScript.runway);
        clipList.Add(_runwayNo1);
        clipList.Add(_runwayNo2);
        clipList.Add(_runwayNo3);
        clipList.Add(atcScript.clearedTouchAndGo);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string TouchAndGo3()
    {
        return "Request, full-stop landing.";
    }

    public List<AudioClip> TouchAndGo3Audio(GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.requestFullStopLanding);
        return clipList;
    }
    #endregion


    #region Change Altitude

    public string ChangeAltitude(string _flightNo, string _altNew)
    {
        return _flightNo + ", " + "descend and maintain" + _altNew + ".";
    }

    public List<AudioClip> TouchAndGo3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string ChangeAltitude1(string _flightNo, string _altNew)
    {
        return "Roger, descend and maintain" + _altNew + ", " + _flightNo + ".";
    }

    public List<AudioClip> ChangeAltitude1Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.descendAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string ChangeAltitude2(string _flightNo, string _altNew)
    {
        return _flightNo + ", " + "climb and maintain" + _altNew + ".";
    }

    public List<AudioClip> ChangeAltitude2Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string ChangeAltitude3(string _flightNo, string _altNew)
    {
        return "Roger, climb and maintain" + _altNew + ", " + _flightNo + ".";
    }

    public List<AudioClip> ChangeAltitude3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(_flightNo);
        return clipList;
    }

    public string ChangeAltitude4(string _flightNo, string _altNew)
    {
        return "Tokyo Departure, " + _flightNo + ", " + "request altitude change" + _altNew + ".";
    }

    public List<AudioClip> ChangeAltitude4Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.tokyoDeparture);
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestAltitudeChange);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string ChangeAltitude5(string _flightNo, string _altNew)
    {
        return _flightNo + ", " + "request approved" + "climb and maintain" + _altNew + ".";
    }

    public List<AudioClip> ChangeAltitude5Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestApproved);
        clipList.Add(atcScript.climbAndMaintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string ChangeAltitude6(string _flightNo, string _altNew)
    {
        return _flightNo + ", " + "request denied, " + "due to traffic, " + "maintain" + _altNew + ".";
    }

    public List<AudioClip> ChangeAltitude6Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(_flightNo);
        clipList.Add(atcScript.requestDenied);
        clipList.Add(atcScript.dueToTraffic);
        clipList.Add(atcScript.maintain);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        return clipList;
    }

    public string ChangeAltitude7(string _flightNo, string _altNew)
    {
        return "Roger, maintaining" + _altNew + ", " + _flightNo + ".";
    }

    public List<AudioClip> ChangeAltitude7Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
    {
        ATC atcScript = personSound.GetComponent<ATC>();
        List<AudioClip> clipList = new List<AudioClip>();
        clipList.Add(atcScript.roger);
        clipList.Add(atcScript.maintaining);
        clipList.Add(_altNew1);
        clipList.Add(_altNew2);
        clipList.Add(_flightNo);
        return clipList;
    }


    #endregion
}



//......................................................................NEW CODE...........................................................................................//


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class CommandReceiver : MonoBehaviour
//{
//    public static CommandReceiver instance;
//    private void Awake()
//    {
//        instance = this;
//    }

//    private void Start()
//    {

//    }

//    [System.Serializable]
//    public class ATCText
//    {
//        public string languageName;
//        public string tokyoApproach;
//        public string leaving;
//        public string to;
//        public string weHaveInformation;
//        public string tokyoGround;
//        public string onYourFrequency;
//        public string standByTaxi;
//        public string dueToTraffic;
//        public string roger;
//        public string standingBy;
//        public string taxiToSpot;
//        public string requestClearance;
//        public string standByClearance;
//        public string tokyoDelivery;
//        public string clearedTo;
//        public string via;
//        public string departure;
//        public string flightPlannedRoute;
//        public string maintainFlightLevel;
//        public string squawk;
//        public string readBack;
//        public string readBackIsCorrect;
//        public string contactGroundWhenReadyForPushback;
//        public string requestPushback;
//        public string pushbackApproved;
//        public string runway;
//        public string requestTaxi;
//        public string taxiToRunway;
//        public string holdPresentPosition;
//        public string holdingPresentPosition;
//        public string continueTaxi;
//        public string continuingTaxi;
//        public string contactTower118;
//        public string contactingTower;
//        public string tokyoTower;
//        public string holdShortOfRunway;
//        public string lineUpAndWait;
//        public string readForDeparture;
//        public string clearedForTakeoff;
//        public string at;
//        public string wind;
//        public string climbing;
//        public string tokyoDeparture;
//        public string radarContact;
//        public string flyHeading;
//        public string forVectorTo;
//        public string complyWithRestriction;
//        public string contactTokyoControl123;
//        public string contactingTokyoControl;
//        public string goodDay;
//        public string ground;
//        public string hanedaAirserve;
//        public string atSpot;
//        public string requestTowingToSpot;
//        public string startTowing;
//        public string holdPosition;
//        public string continueTowing;
//        public string changeYourRoute;
//        public string changingRoute;
//        public string requestCrossRunway;
//        public string runwayIsClear;
//        public string pleaseCross;
//        public string crossingRunway;
//        public string EmergencyCallForJapanCoastGuard;
//        public string FromALargeCargoShip;
//        public string thereHasBeenAnAssumedCrashWithASmallShip5KilosOffTheCoastOfInubosaki;
//        public string headToTheSceneImmediately;
//        public string reportSituation;
//        public string rogerThat;
//        public string headingToTheSceneImmediately;
//        public string tokyoGroundControl;
//        public string JCG1;
//        public string emergencyOffTheInubosakiCoast;
//        public string requestTakeOffFromRunway04;
//        public string qNH;
//        public string climbingFor;
//        public string climbAndMaintain;
//        public string contactMissionControl;
//        public string goodLuck;
//        public string rejectTakeOffEngineFailure;
//        public string requestReturnToSpot;
//        public string areYouAbleToTaxi;
//        public string weAreAbleToTaxi;
//        public string thanksForYourHelp;
//        public string maydayMaydayMaydayFuel;
//        public string maydayMaydayMayday;
//        public string declareEmergency;
//        public string declaringEmergency;
//        public string declaringAnEmergency;
//        public string squawk7600;
//        public string affirm;
//        public string reducingSpeedTo;
//        public string turn;
//        public string contactGround121;
//        public string turning;
//        public string contactingGround;
//        public string tower;
//        public string continueHold;
//        public string clearedCrossRunway;
//        public string panPanPanPanPanPan;
//        public string passengerAboardInMedicalDistress;
//        public string contactGround127;
//        public string theAmbulanceIsStandingByAtSpot;
//        public string unableToTaxiDueToLandingGearMalfunction;
//        public string closingYourRunway;
//        public string allStationsAllStationsRunway;
//        public string isClosed;
//        public string unableToTaxiDueToNo1EngineProblem;
//        public string andRequestFlyByOverRunway;
//        public string flyByOverRunway;
//        public string clearedToFlybyRunway;
//        public string thankYou;
//        public string contactingDeparture;
//        public string nextFullStop;
//        public string requestLandingRunway;
//        public string requestTouchAndGo;
//        public string clearedTouchAndGo;
//        public string request;
//        public string fullStopLanding;
//        public string descendAndMaintain;
//        public string requestDenied;
//        public string maintaining;
//        public string maintain;
//        public string requestAltitudeChange;
//        public string requestApproved;
//        public string goAround;
//        public string wellGoAround;
//        public string contactDeparture126;
//        public string wereGoingAround;
//        public string vectorTo;
//        public string contactApproach;
//        public string heading;
//        public string useRunway;
//        public string continueApproach;
//        public string continuingApproach;
//        public string clearedToLand;
//        public string contactGround;
//        public string cleardFor;
//        public string approach;
//        public string approachingFinal;
//        public string increaseSpeedTo;
//        public string increasingSpeedTo;
//        public string reduceSpeedTo;
//        public string maintainPresentSpeed;
//        public string maintainingPresentSpeed;
//        public string divert2Miles;
//        public string ofApproachCourse;
//        public string vectorToFinalApproachCourse;
//    }

//    [SerializeField]
//    public ATCText[] atcText;

//    public int AssignLanguage()
//    {
//        print("enter");
//        if (SaveAndLoad.language == 1)
//        {
//            return 1;
//        }
//        else if (SaveAndLoad.language == 2)
//        {
//            return 0;
//        }
//        else
//        {
//            return 2;
//        }
//    }

//    //................Arrival section(Approach) ............................//
//    #region Arrival Approach
//    public string ArrivalApproach(string _flightNo, string _altA, string _altB, string _atisCode)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoApproach + "," + _flightNo + "," + atcText[_lang].leaving + _altA + atcText[_lang].to + _altB + "," + atcText[_lang].weHaveInformation + _atisCode + ".";
//    }

//    public List<AudioClip> ArrivalApproachAudio(AudioClip _flightNo, AudioClip _altA1, AudioClip _altA2, AudioClip _altA3, AudioClip _altB1, AudioClip _altB2, AudioClip _altB3, AudioClip _atisCode, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoApproach);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.leaving);
//        clipList.Add(_altA1);
//        clipList.Add(_altA2);
//        clipList.Add(_altA3);
//        clipList.Add(atcScript.to);
//        clipList.Add(_altB1);
//        clipList.Add(_altB2);
//        clipList.Add(_altB3);
//        clipList.Add(atcScript.weHaveInformation);
//        clipList.Add(_atisCode);
//        return clipList;
//    }

//    //............ User selects Runway to land & route............
//    #region Runway to land & route
//    public string RunWayToLand(string _flightNo, string _runwayNo, string _flyDir, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoApproach + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].heading + _flyDir + atcText[_lang].vectorToFinalApproachCourse + ", " + atcText[_lang].descendAndMaintain + _altNew + ".";
//    }

//    public List<AudioClip> RunWayToLandAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.tokoyoApproach);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.vectorToFinalApproachCourse);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string RunWayToLandAgain(string _runwayNo, string _flyDir, string _altNew, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].heading + _flyDir + ", " + atcText[_lang].descendAndMaintain + _altNew + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> RunWayToLandAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion

//    //............. If user selects "Detour Route".............
//    #region selects Detour Route

//    public string SelectDetourRoute(string _flightNo, string _flyDir, string _cardinalDry, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].heading + _flyDir + ", " + atcText[_lang].divert2Miles + _cardinalDry + atcText[_lang].ofApproachCourse + ", " + atcText[_lang].descendAndMaintain + _altNew + ".";
//    }

//    public List<AudioClip> SelectDetourRouteAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _cardinalDry, AudioClip _altNew1, AudioClip _thousand, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.divert2Miles);
//        clipList.Add(_cardinalDry);
//        clipList.Add(atcScript.ofApproachCourse);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_thousand);
//        return clipList;
//    }

//    public string SelectDetourRouteAgain(string _flyDir, string _cardinalDry, string _altNew, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].heading + _flyDir + atcText[_lang].divert2Miles + _cardinalDry + ", " + atcText[_lang].descendAndMaintain + _altNew + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> SelectDetourRouteAgainAudio(AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _cardinalDry, AudioClip _altNew1, AudioClip _thousandClip, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.divert2Miles);
//        clipList.Add(_cardinalDry);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_thousandClip);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion

//    //............... Maintain Aircraft Speed..................
//    #region increase, decrease, maintain Aircraft speed

//    public string AccelerateSpeed(string _flightNo, string _increasedFlySpeed)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].increaseSpeedTo + _increasedFlySpeed + ".";
//    }

//    public List<AudioClip> AccelerateSpeedAudio(AudioClip _flightNo, AudioClip _increasedFlySpeed1, AudioClip _increasedFlySpeed2, AudioClip _increasedFlySpeed3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.increaseSpeedTo);
//        clipList.Add(_increasedFlySpeed1);
//        clipList.Add(_increasedFlySpeed2);
//        clipList.Add(_increasedFlySpeed3);
//        return clipList;
//    }

//    public string AccelerateAgain(string _increasedFlySpeed, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].increasingSpeedTo + _increasedFlySpeed + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> AccelerateAgainAudio(AudioClip _increasedFlySpeed1, AudioClip _increasedFlySpeed2, AudioClip _increasedFlySpeed3, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.increasingSpeedTo);
//        clipList.Add(_increasedFlySpeed1);
//        clipList.Add(_increasedFlySpeed2);
//        clipList.Add(_increasedFlySpeed3);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string DecelerateSpeed(string _flightNo, string _reducedFlySpeed)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].reduceSpeedTo + _reducedFlySpeed + ".";
//    }

//    public List<AudioClip> DecelerateSpeedAudio(AudioClip _flightNo, AudioClip _reducedFlySpeed1, AudioClip _reducedFlySpeed2, AudioClip _reducedFlySpeed3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.reduceSpeedTo);
//        clipList.Add(_reducedFlySpeed1);
//        clipList.Add(_reducedFlySpeed2);
//        clipList.Add(_reducedFlySpeed3);
//        return clipList;
//    }

//    public string DecelerateAgain(string _decreasedFlySpeed, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].reducingSpeedTo + _decreasedFlySpeed + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DecelerateAgainAudio(AudioClip _decreasedFlySpeed1, AudioClip _decreasedFlySpeed2, AudioClip _decreasedFlySpeed3, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.reducingSpeedTo);
//        clipList.Add(_decreasedFlySpeed1);
//        clipList.Add(_decreasedFlySpeed2);
//        clipList.Add(_decreasedFlySpeed3);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string MaintainSpeed(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].maintainPresentSpeed;
//    }

//    public List<AudioClip> MaintainSpeedAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.maintainPresentSpeed);
//        return clipList;
//    }

//    public string MaintainAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].maintainingPresentSpeed + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> MaintainAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.maintainingPresentSpeed);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion

//    //................Tower Control Hand-Off....................
//    #region Tower Control Hand-Off

//    public string ArrivalTowerCtrlHandOff(string _flightNo, string _apprRoute, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].cleardFor + _apprRoute + ", " + atcText[_lang].runway + _runwayNo + atcText[_lang].approach + ", " + atcText[_lang].contactTower118 + ".";
//    }

//    public List<AudioClip> ArrivalTowerCtrlHandOffAudio(AudioClip _flightNo, AudioClip _apprRoute, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.clearedfor);
//        clipList.Add(_apprRoute);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.approach);
//        clipList.Add(atcScript.contactTower118);
//        return clipList;
//    }

//    public string ArrivalTowerCtrlHandOffAgain(string _apprRoute, string _runwayNo, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].cleardFor + _apprRoute + ", " + atcText[_lang].runway + _runwayNo + atcText[_lang].approach + ", " + atcText[_lang].contactingTower + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ArrivalTowerCtrlHandOffAgainAudio(AudioClip _flightNo, AudioClip _apprRoute, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.clearedfor);
//        clipList.Add(_apprRoute);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.approach);
//        clipList.Add(atcScript.contactingTower);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //....................... Arrival section(Tower) .................
//    public string ArrivalTower(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].approachingFinal + ".";
//    }

//    public List<AudioClip> ArrivalTowerAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.approachingFinal);
//        return clipList;
//    }

//    #endregion

//    //...............Clear to Land.........................
//    #region Clear to Land
//    public string ArrivalClearToLanding(string _flightNo, string _runwayNo, string _windDir, string _windForce)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].wind + _windDir + atcText[_lang].at + _windForce + ", " + atcText[_lang].clearedToLand;
//    }

//    public List<AudioClip> ArrivalClearToLandingAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.wind);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(_windDir3);
//        clipList.Add(atcScript.at);
//        clipList.Add(_windForce1);
//        clipList.Add(_windForce2);
//        clipList.Add(atcScript.clearedToLand);
//        return clipList;
//    }

//    public string ArrivalClearToLandingAgain(string _runwayNo, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].clearedToLand + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ArrivalClearToLandingAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.clearedToLand);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //.......After aircraft lands on runway and ask for taxi route, after selecting A6 to ground.

//    public string ArrivalTexiRoute(string _flightNo, string _LRDir, string _runwayExit)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].turn + _LRDir + " " + _runwayExit + ", " + atcText[_lang].contactGround121;
//    }

//    public List<AudioClip> ArrivalTexiRouteAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactGround127);
//        return clipList;
//    }

//    public string ArrivalTexiRouteAgain(string _LRDir, string _runwayExit, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].turn + _LRDir + " " + _runwayExit + ", " + atcText[_lang].contactGround + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ArrivalTexiRouteAgainAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactGround);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //............ If user chooses "Standby Taxi"

//    public string ArvStandByText(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].continueHold + ", " + atcText[_lang].dueToTraffic + ".";
//    }

//    public List<AudioClip> ArvStandByTextAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(_flightNo);
//        clips.Add(atcScript.continueHold);

//        clips.Add(atcScript.dueToTraffic);

//        return clips;
//    }

//    public string ArvStandByTextAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].continueHold + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ArvStandByTextAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.roger);

//        clips.Add(atcScript.continuingHold);
//        clips.Add(_flightNo);


//        return clips;
//    }

//    #endregion

//    //.................Go Around................
//    #region GoAround

//    public string ArrivalGoAround(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].goAround + ".";
//    }

//    public List<AudioClip> ArrivalGoAroundAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.goAround);
//        return clipList;
//    }

//    public string ArrivalGoAroundAgain()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].wellGoAround + ".";

//    }

//    public List<AudioClip> ArrivalGoAroundAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.wellGoAround);
//        return clipList;
//    }

//    //..........when user can choose "Departure Control Hand-Off"....................
//    public string DepartureHandOff(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].contactDeparture126 + ".";
//    }

//    public List<AudioClip> DepartureHandOffAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.contactDeparture126);
//        return clipList;
//    }

//    public string DepartureHandOffAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].contactingDeparture + ", " + _flightNo + ".";//, good day.";
//    }

//    public List<AudioClip> DepartureHandOffAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.contactingDeparture);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string DepartureHandOffAgainGoodDay()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].contactingDeparture + ", " + atcText[_lang].goodDay + ".";
//    }

//    public List<AudioClip> DepartureHandOffAgainGoodDayAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.contactingDeparture);
//        clipList.Add(atcScript.goodDay);
//        return clipList;
//    }

//    public string ArrivalTokyoDep(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDeparture + ", " + _flightNo + ", " + atcText[_lang].wereGoingAround;
//    }

//    public List<AudioClip> ArrivalTokyoDepAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.wereGoingAround);
//        return clipList;
//    }

//    public string ArrivalApproachCtrlHandOff(string _flightNo, string _LRDir, string _flyDir, string _waypoint, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoDeparture + ", " + atcText[_lang].radarContact + ", " + atcText[_lang].turn + _LRDir + atcText[_lang].heading + _flyDir + atcText[_lang].vectorTo + _waypoint + ", " + atcText[_lang].climbAndMaintain + _altNew + ", " + atcText[_lang].contactApproach;
//    }

//    public List<AudioClip> ArrivalApproachCtrlHandOffAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _waypoint, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(atcScript.radarContact);
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.vectorTo);
//        clipList.Add(_waypoint);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(atcScript.contactApproach);
//        return clipList;
//    }

//    public string ArrivalApproachCtrlHandOffTurn(string _LRDir, string _flyDir, string _altNew, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].turn + _LRDir + atcText[_lang].heading + _flyDir + atcText[_lang].climbAndMaintain + _altNew + ", " + atcText[_lang].contactApproach + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ArrivalApproachCtrlHandOffTurnAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(atcScript.heading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);

//        clipList.Add(atcScript.contactApproach);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string ArrivalApproachCtrlHandOffTokyo(string _flightNo, string _alt)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoApproach + ", " + _flightNo + ", " + atcText[_lang].wereGoingAround + ", " + atcText[_lang].maintaining + _alt + ".";
//    }

//    public List<AudioClip> ArrivalApproachCtrlHandOffTokyoAudio(AudioClip _flightNo, AudioClip _alt1, AudioClip _alt2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoApproach);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.wereGoingAround);
//        clipList.Add(atcScript.maintaining);
//        clipList.Add(_alt1);
//        clipList.Add(_alt2);
//        return clipList;
//    }
//    //.......choose the Runway and Route for the airplane to land


//    public string TokyoApproachCtrlHandOff(string _flightNo, string _runwayNo, string _windDir, string _windForce, string _barometricAlt)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoApproach + ", " + atcText[_lang].useRunway + _runwayNo + ", " + atcText[_lang].continueApproach + ", " + atcText[_lang].wind + _windDir + atcText[_lang].at + _windForce + ", " + atcText[_lang].qNH + _barometricAlt + ".";
//    }

//    public List<AudioClip> TokyoApproachCtrlHandOffAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.tokyoApproach);
//        clipList.Add(atcScript.use);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.continueApproach);
//        clipList.Add(atcScript.wind);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(atcScript.at);
//        clipList.Add(_windForce);
//        clipList.Add(atcScript.QNH);
//        clipList.Add(_barometricAlt1);
//        clipList.Add(_barometricAlt2);
//        clipList.Add(_barometricAlt3);
//        clipList.Add(_barometricAlt4);
//        return clipList;
//    }

//    //Roger, runway %RunwayNo%, continuing approach, %FlightNo%.
//    public string TokyoApproachCtrlHandOffAgain(string _runwayNo, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].continuingApproach + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> TokyoApproachCtrlHandOffAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.continueApproach);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion

//    #endregion

//    //..................Departure section(Ground):- ........................//
//    #region Departure Section

//    public string DepartureOnGround(string _flightNo)   //.........when strip Appears.....//
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoGround + ", " + _flightNo + ", " + atcText[_lang].onYourFrequency;
//    }

//    public List<AudioClip> DepartureOnGroundAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(atcScript.tokyoGround);
//        clips.Add(_flightNo);
//        clips.Add(atcScript.onYourFrequency);

//        return clips;
//    }

//    //............ If user chooses "Standby Taxi"

//    public string StandByText(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].standByTaxi + ", " + atcText[_lang].dueToTraffic;
//    }

//    public List<AudioClip> StandByTextAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(_flightNo);
//        clips.Add(atcScript.standByTaxi);

//        clips.Add(atcScript.dueToTraffic);

//        return clips;
//    }

//    public string StandByTextAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].standingBy + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> StandByTextAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.roger);

//        clips.Add(atcScript.standingBy);
//        clips.Add(_flightNo);


//        return clips;
//    }
//    //............ After selecting taxi route and spot.........

//    public string DepartureTexiRoute(string _flightNo, string _spotNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoGround + ", " + atcText[_lang].taxiToSpot + _spotNo + ".";
//    }

//    public List<AudioClip> DepartureTexiRouteAudio(AudioClip _flightNo, AudioClip _spotNo1, AudioClip _spotNo2, AudioClip _spotNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.tokyoGround);

//        clips.Add(atcScript.taxiToSpot);
//        clips.Add(_spotNo1);
//        clips.Add(_spotNo2);
//        clips.Add(_spotNo3);

//        return clips;
//    }

//    public string DepartureTexiToSpot(string _spotNo, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].taxiToSpot + _spotNo + ", " + _flightNo + ".";
//    }
//    public List<AudioClip> DepartureTexiToSpotAudio(AudioClip _flightNo, AudioClip _spotNo1, AudioClip _spotNo2, AudioClip _spotNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(atcScript.taxiToSpot);
//        clips.Add(_spotNo1);
//        clips.Add(_spotNo2);
//        clips.Add(_spotNo3);
//        clips.Add(_flightNo);

//        return clips;
//    }
//    //.....................Departure section(delivery).............

//    public string DepartureTokyoDelivery(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDelivery + ", " + _flightNo + ", " + atcText[_lang].requestClearance + ".";
//    }

//    public List<AudioClip> DepartureTokyoDeliveryAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(atcScript.tokyoDelivery);

//        clips.Add(_flightNo);
//        clips.Add(atcScript.requestClearance);
//        return clips;
//    }

//    //................... If user chooses "Standby"............

//    public string DepStandBy(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].standByClearance + ".";
//    }

//    public List<AudioClip> DepStandByAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.standByClearance);
//        return clips;
//    }
//    public string DepStandByAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].standingBy + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepStandByAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.roger);
//        clips.Add(atcScript.standingBy);
//        clips.Add(_flightNo);

//        return clips;
//    }
//    //................If user chooses "Departure Approval

//    public string DepartureApproval(string _flightNo, string _destination, string _depRoute, string _flightLvl, string _code)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].clearedTo + _destination + atcText[_lang].via + _depRoute + atcText[_lang].departure + ", " + atcText[_lang].flightPlannedRoute + ", " + atcText[_lang].maintainFlightLevel + _flightLvl + ", " + atcText[_lang].squawk + _code + atcText[_lang].readBack + ".";
//    }

//    public List<AudioClip> DepartureApprovalAudio(AudioClip _flightNo, AudioClip _destination, AudioClip _depRoute, AudioClip _flightLvl1, AudioClip _flightLvl2, AudioClip _flightLvl3, AudioClip _code1, AudioClip _code2, AudioClip _code3, AudioClip _code4, GameObject personSound)

//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.clearedTo);
//        clips.Add(_destination);
//        clips.Add(atcScript.via);
//        clips.Add(_depRoute);
//        //clips.Add(ATC.instance.departure);
//        clips.Add(atcScript.flightPlannedRouteMaintainFlightLevel);
//        clips.Add(_flightLvl1);
//        clips.Add(_flightLvl2);
//        clips.Add(_flightLvl3);
//        clips.Add(atcScript.squawk);
//        clips.Add(_code1);
//        clips.Add(_code2);
//        clips.Add(_code3);
//        clips.Add(_code4);
//        clips.Add(atcScript.readBack);

//        return clips;
//    }

//    public string DepartureApprovalAgain(string _destination, string _depRoute, string _flightLvl, string _code, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].clearedTo + _destination + atcText[_lang].via + _depRoute + atcText[_lang].departure + ", " + atcText[_lang].flightPlannedRoute + ", " + atcText[_lang].maintainFlightLevel + _flightLvl + ", " + atcText[_lang].squawk + _code + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepartureApprovalAgainAudio(AudioClip _destination, AudioClip _depRoute, AudioClip _flightLvl1, AudioClip _flightLvl2, AudioClip _flightLvl3, AudioClip _code1, AudioClip _code2, AudioClip _code3, AudioClip _code4, AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(atcScript.clearedTo);
//        clips.Add(_destination);
//        clips.Add(atcScript.via);
//        clips.Add(_depRoute);
//        //clips.Add(ATC.instance.departure);
//        clips.Add(atcScript.flightPlannedRouteMaintainFlightLevel);
//        clips.Add(_flightLvl1);
//        clips.Add(_flightLvl2);
//        clips.Add(_flightLvl3);
//        clips.Add(atcScript.squawk);
//        clips.Add(_code1);
//        clips.Add(_code2);
//        clips.Add(_code3);
//        clips.Add(_code4);

//        clips.Add(_flightNo);
//        return clips;
//    }
//    public string DeparturePushBack(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].readBackIsCorrect + ", " + atcText[_lang].contactGroundWhenReadyForPushback + ".";
//    }
//    public List<AudioClip> DeparturePushBackAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(_flightNo);
//        clips.Add(atcScript.readBackCorrectPushBack);

//        return clips;
//    }
//    public string DeparturePushBackReady(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].contactGroundWhenReadyForPushback + ", " + _flightNo + ".";
//    }
//    public List<AudioClip> DeparturePushBackReadyAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.roger);

//        clips.Add(atcScript.contactingWhenReadyPushback);
//        clips.Add(_flightNo);

//        return clips;
//    }
//    //After some time when the airplane is ready it will contact the ATC again

//    public string DepPushBackRequest(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoGround + ", " + _flightNo + ", " + atcText[_lang].requestPushback + ".";
//    }
//    public List<AudioClip> DepPushBackRequestAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.tokyoGround);

//        clips.Add(_flightNo);
//        clips.Add(atcScript.requestPushBack);
//        return clips;
//    }
//    //....................After runway and route selection................

//    public string DeparturePushBackApproved(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].pushbackApproved + "," + atcText[_lang].runway + _runwayNo + ".";
//    }
//    public List<AudioClip> DeparturePushBackApprovedAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.pushBackApproved);
//        clips.Add(atcScript.runway);
//        clips.Add(_runwayNo1);
//        clips.Add(_runwayNo2);
//        clips.Add(_runwayNo3);
//        return clips;
//    }
//    public string DeparturePushBackApprovedAgain(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].pushbackApproved + ", " + atcText[_lang].runway + _runwayNo + ", " + _flightNo + ".";
//    }
//    public List<AudioClip> DeparturePushBackApprovedAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.pushBackApproved);
//        clips.Add(atcScript.runway);
//        clips.Add(_runwayNo1);
//        clips.Add(_runwayNo2);
//        clips.Add(_runwayNo3);
//        clips.Add(_flightNo);
//        return clips;
//    }
//    public string DepartureReqTexi(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoGround + ", " + _flightNo + ", " + atcText[_lang].requestTaxi + ".";
//    }
//    public List<AudioClip> DepartureReqTexiAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();
//        clips.Add(atcScript.tokyoGround);
//        clips.Add(_flightNo);

//        clips.Add(atcScript.requestTaxi);

//        return clips;
//    }
//    public string DepartureClearToTexi(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].taxiToRunway + _runwayNo + ".";
//    }
//    public List<AudioClip> DepartureClearToTexiAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clips = new List<AudioClip>();

//        clips.Add(_flightNo);
//        clips.Add(atcScript.texiToRunway);
//        clips.Add(_runwayNo1);
//        clips.Add(_runwayNo2);
//        clips.Add(_runwayNo3);
//        return clips;
//    }
//    public string DepartureClearToTexiAgain(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].taxiToRunway + _runwayNo + ", " + _flightNo + ".";
//    }
//    public List<AudioClip> DepartureClearToTexiAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.texiToRunway);

//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(_flightNo);
//        return clipList;
//    }
//    //.............if you hold aircraft in-between them.....
//    public string DepartureHoldOn(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].holdPresentPosition + ".";
//    }

//    public List<AudioClip> DepartureHoldOnAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.holdPresentPosition);
//        return clipList;
//    }

//    public string DepartureHoldOnAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdingPresentPosition + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepartureHoldOnAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.holdingPresentPosition);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //..................Aircraft after pressing resume taxiing...........

//    public string DepartureResumeHoldOn(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].continueTaxi + ".";
//    }

//    public List<AudioClip> DepartureResumeHoldOnAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.continueTaxi);
//        return clipList;
//    }

//    public string DepartureResumeHoldOnAgian(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].continuingTaxi + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepartureResumeHoldOnAgianAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.continuingTaxi);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //.......After selecting Tower control handoff...............

//    public string DepartureTowerCtrlHandOff(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].contactTower118 + ".";
//    }

//    public List<AudioClip> DepartureTowerCtrlHandOffAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.contactTower118);
//        return clipList;
//    }

//    public string DepartureTowerCtrlHandOffAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].contactingTower + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepartureTowerCtrlHandOffAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.contactingTower);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    //...............Departure(Tower section):- ............

//    public string TokyoTowerCtrlHandOff(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].onYourFrequency + ".";
//    }

//    public List<AudioClip> TokyoTowerCtrlHandOffAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.onYourFrequency);
//        return clipList;
//    }

//    public string HoldShortOfRunway(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].holdShortOfRunway + _runwayNo + ".";
//    }

//    public List<AudioClip> HoldShortOfRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.holdShortOfRunway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string HoldShortOfRunwayAgain(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdShortOfRunway + _runwayNo + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> HoldShortOfRunwayAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.holdShortOfRunway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string LineUpAndWait(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].lineUpAndWait + ".";
//    }

//    public List<AudioClip> LineUpAndWaitAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.lineUpAndWait);
//        return clipList;
//    }

//    public string LineUpAndWaitAgain(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + "," + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].lineUpAndWait + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> LineUpAndWaitAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.lineUpAndWait);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string ReadyForDep(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].readForDeparture + ".";
//    }

//    public List<AudioClip> ReadyForDepAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.readyForDeparture);
//        return clipList;
//    }

//    public string DepartureTakeOff(string _flightNo, string _runwayNo, string _windDir, string _windForce)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].wind + _windDir + atcText[_lang].at + _windForce + ", " + atcText[_lang].clearedForTakeoff + ".";
//    }

//    public List<AudioClip> DepartureTakeOffAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.wind);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(_windDir3);
//        clipList.Add(atcScript.at);
//        clipList.Add(_windForce1);
//        clipList.Add(_windForce2);
//        clipList.Add(atcScript.clearTakeOff);
//        return clipList;
//    }

//    public string DepartureTakeOffAgain(string _runwayNo, string _windDir, string _windForce, string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].runway + _runwayNo + ", " + _windDir + ", " + _windForce + ", " + atcText[_lang].clearedForTakeoff + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> DepartureTakeOffAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windDir3, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(_windForce1);
//        clipList.Add(_windForce2);
//        clipList.Add(_windDir3);
//        clipList.Add(atcScript.clearTakeOff);
//        clipList.Add(_flightNo);
//        return clipList;
//    }


//    //public string DepartureHandOffAgainAgain()
//    //{
//    //    return "Good day.";
//    //}
//    //.............. After some time in air...............

//    public string DepartureInAir(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDeparture + ", " + _flightNo + ", " + atcText[_lang].climbing + _altNew + ".";
//    }

//    public List<AudioClip> DepartureInAirAudio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _thousand, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.climbing);
//        clipList.Add(_altNew1);
//        clipList.Add(_thousand);
//        return clipList;
//    }

//    //...............if you press radar control option then.........
//    //%FlightNo%, Tokyo Departure, radar contact, fly heading %FlyDir% for vector to %Waypoint%, comply with restriction.
//    //Flying heading %FlyDir% for vector to %Waypoint%, comply with restriction, %FlightNo%.

//    public string ChooseRadarCtrl(string _flightNo, string _flyDir, string _wayPoint)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoDeparture + ", " + atcText[_lang].radarContact + ", " + atcText[_lang].flyHeading + _flyDir + atcText[_lang].forVectorTo + _wayPoint + ", " + atcText[_lang].complyWithRestriction + ".";
//    }

//    public List<AudioClip> ChooseRadarCtrlAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _wayPoint, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(atcScript.radarContact);
//        clipList.Add(atcScript.flyHeading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.forVectorTo);
//        clipList.Add(_wayPoint);
//        clipList.Add(atcScript.complyToRestriction);
//        return clipList;
//    }

//    public string ChooseRadarCtrlAgain(string _flightNo, string _flyDir, string _wayPoint)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].flyHeading + _flyDir + atcText[_lang].forVectorTo + _wayPoint + ", " + atcText[_lang].complyWithRestriction + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ChooseRadarCtrlAgainAudio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _wayPoint, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.flyHeading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        clipList.Add(atcScript.forVectorTo);
//        clipList.Add(_wayPoint);
//        clipList.Add(atcScript.complyToRestriction);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string DepartureRadarCtrl(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].contactTokyoControl123 + ".";
//    }

//    public List<AudioClip> DepartureRadarCtrlAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.contactCtrl123);
//        return clipList;
//    }

//    public string DepartureRadarCtrlAgain()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].contactingTokyoControl + ", " + atcText[_lang].goodDay + ".";
//    }

//    public List<AudioClip> DepartureRadarCtrlAgainAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.contactingTokyoCtrl);
//        clipList.Add(atcScript.goodDay);
//        return clipList;
//    }

//    public string DepartureRadarCtrlAgainAgain()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].goodDay + ".";
//    }

//    public List<AudioClip> DepartureRadarCtrlAgainAgainAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.goodDay);
//        return clipList;
//    }

//    #endregion

//    //....................New Commands......................................//
//    #region Change spot event For Departure plane

//    public string SpotChangeAircraft(string airserveNo, string currentSpot, string endSpot)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].ground + ", " + atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].atSpot + currentSpot + ", " + atcText[_lang].requestTowingToSpot + endSpot + ".";
//    }

//    public List<AudioClip> SpotChangeAircraftAudio(AudioClip _airserveNo, AudioClip _currentSpot, AudioClip _endSpot, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(_airserveNo);
//        clipList.Add(_currentSpot);
//        clipList.Add(_endSpot);
//        clipList.Add(atcScript.tw_rjtt_04);

//        return clipList;
//    }

//    public string StartTowingSpot(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].ground + "," + atcText[_lang].startTowing + ".";
//    }

//    public List<AudioClip> StartTowingSpotAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.gndStartTowing);

//        return clipList;
//    }

//    public string StartTowingSpotAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].startTowing + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> StartTowingSpotAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerStartTowing);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }


//    public string HoldPositionSpot(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].ground + ", " + atcText[_lang].holdPosition + ".";
//    }

//    public List<AudioClip> HoldPositionSpotAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.gndHoldPosition);

//        return clipList;
//    }

//    public string HoldPositionSpotAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdPosition + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> HoldPositionSpotAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerHoldPosition);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    public string TowingHoldPosition(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].holdPresentPosition + ".";
//    }

//    public List<AudioClip> TowingHoldPositionAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.holdPresentPositionInSpotChange);
//        return clipList;
//    }

//    public string TowingHoldPositionAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdPresentPosition + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> TowingHoldPositionAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerHoldintPresentPosition);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    public string ContinueTowing(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].continueTowing + ".";
//    }

//    public List<AudioClip> ContinueTowingAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.continueTowingInSpotChange);
//        return clipList;
//    }

//    public string ContinueTowingAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].continueTowing + ", " + atcText[_lang].hanedaAirserve + airserveNo;
//    }

//    public List<AudioClip> ContinueTowingAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerContinueTowingInSpotChange);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    public string ChangeRoute(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].changeYourRoute;
//    }

//    public List<AudioClip> ChangeRouteAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.changeYourRouteInSpotChange);
//        return clipList;
//    }

//    public string ChangeRouteAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].changingRoute + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> ChangeRouteAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.changingRouteInSpotChange);
//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    public string RequestCrossRunway(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].ground + ", " + atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].requestCrossRunway + ".";
//    }

//    public List<AudioClip> RequestCrossRunwayAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.requestCrossRunwayInSpotChange);
//        clipList.Add(_airserveNo);

//        //clipList.Add(ATC.instance.requestCrossRunway);
//        return clipList;
//    }

//    public string RequestCrossRunwayHoldPosition(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].ground + ", " + atcText[_lang].holdPosition + ".";
//    }

//    public List<AudioClip> RequestCrossRunwayHoldPositionAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.gndHoldPosition);

//        return clipList;
//    }

//    public string RequestCrossRunwayHoldPositionAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdPosition + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> RequestCrossRunwayHoldPositionAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerHoldPosition);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    public string RequestCrossRunwayClearToCrossRunway(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].hanedaAirserve + airserveNo + ", " + atcText[_lang].ground + ", " + atcText[_lang].runwayIsClear + ", " + atcText[_lang].pleaseCross + ".";
//    }

//    public List<AudioClip> RequestCrossRunwayClearToCrossRunwayAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_airserveNo);

//        clipList.Add(atcScript.runwayIsClearPleaseCross);

//        return clipList;
//    }

//    public string RequestCrossRunwayClearToCrossRunwayAgain(string airserveNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].crossingRunway + ", " + atcText[_lang].hanedaAirserve + airserveNo + ".";
//    }

//    public List<AudioClip> RequestCrossRunwayClearToCrossRunwayAgainAudio(AudioClip _airserveNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.rogerCrossingRunway);

//        clipList.Add(_airserveNo);

//        return clipList;
//    }

//    #endregion


//    #region EMG events: Rescue Events

//    public string EmergencyCallForRescueEvents()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].EmergencyCallForJapanCoastGuard + ". " + atcText[_lang].FromALargeCargoShip + ", " + atcText[_lang].thereHasBeenAnAssumedCrashWithASmallShip5KilosOffTheCoastOfInubosaki + ". " + atcText[_lang].headToTheSceneImmediately + ". " + atcText[_lang].reportSituation + ".";
//    }

//    public List<AudioClip> EmergencyCallForRescueEventsAudio(GameObject personSound)
//    {
//        List<AudioClip> clipList = new List<AudioClip>();

//        ATC atcScript = personSound.GetComponent<ATC>();

//        clipList.Add(atcScript.evdScrInfoE_1);
//        return clipList;
//    }

//    public string EmergencyCallForRescueEventsPilot()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].rogerThat + ", " + atcText[_lang].headingToTheSceneImmediately + ".";
//    }

//    public List<AudioClip> EmergencyCallForRescueEventsPilotAudio(GameObject personSound)
//    {
//        List<AudioClip> clipList = new List<AudioClip>();

//        ATC atcScript = personSound.GetComponent<ATC>();

//        clipList.Add(atcScript.evdScrInfoE_2);

//        return clipList;
//    }

//    public string EmergencyCallForRescueEventAgain()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoGroundControl + ", " + atcText[_lang].JCG1 + ", " + atcText[_lang].emergencyOffTheInubosakiCoast + ", " + atcText[_lang].requestTakeOffFromRunway04 + ".";
//    }

//    public List<AudioClip> EmergencyCallForRescueEventAgainAudio(GameObject personSound)
//    {
//        List<AudioClip> clipList = new List<AudioClip>();

//        ATC atcScript = personSound.GetComponent<ATC>();

//        clipList.Add(atcScript.evdScrInfoE_3_1);

//        return clipList;
//    }

//    public string AfterRescueEvents(string _flightNo, string _runwayNo, string _barometricAlt)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].taxiToRunway + _runwayNo + ", " + atcText[_lang].qNH + _barometricAlt + ".";
//    }

//    public List<AudioClip> AfterRescueEventsAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.taxiToRunway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.QNH);
//        clipList.Add(_barometricAlt1);
//        clipList.Add(_barometricAlt2);
//        clipList.Add(_barometricAlt3);
//        clipList.Add(_barometricAlt4);
//        return clipList;
//    }

//    public string AfterRescueEventsAgain(string _flightNo, string _runwayNo, string _barometricAlt)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].taxiToRunway + _runwayNo + ", " + atcText[_lang].qNH + _barometricAlt + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> AfterRescueEventsAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _barometricAlt1, AudioClip _barometricAlt2, AudioClip _barometricAlt3, AudioClip _barometricAlt4, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.taxiToRunway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.QNH);
//        clipList.Add(_barometricAlt1);
//        clipList.Add(_barometricAlt2);
//        clipList.Add(_barometricAlt3);
//        clipList.Add(_barometricAlt4);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string NoAircraftInRunway(string _runwayNo, string _windDir, string _windForce)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].wind + _windDir + atcText[_lang].at + _windForce + ", " + atcText[_lang].clearedForTakeoff + ".";
//    }

//    public List<AudioClip> NoAircraftInRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.wind);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(atcScript.at);
//        clipList.Add(_windForce1);
//        clipList.Add(_windForce2);
//        clipList.Add(atcScript.clearForTakeOff);
//        return clipList;
//    }


//    public string WhenAirplaneIsInAir1(string _flightNo, string _altNew, string _flyDir)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDeparture + _flightNo + ", " + atcText[_lang].climbingFor + _altNew + ", " + atcText[_lang].flyHeading + _flyDir + ".";
//    }

//    public List<AudioClip> WhenAirplaneIsInAir1Audio(AudioClip _flightNo, AudioClip _flyDir1, AudioClip _flyDir2, AudioClip _flyDir3, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.climbingFor);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(atcScript.flyHeading);
//        clipList.Add(_flyDir1);
//        clipList.Add(_flyDir2);
//        clipList.Add(_flyDir3);
//        return clipList;
//    }

//    public string WhenAirplaneIsInAir2(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].tokyoDeparture + ", " + atcText[_lang].climbAndMaintain + _altNew + ", " + atcText[_lang].contactMissionControl + ", " + atcText[_lang].goodLuck + ".";
//    }

//    public List<AudioClip> WhenAirplaneIsInAir2Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(atcScript.contactMissionControl);
//        clipList.Add(atcScript.goodLuck);
//        return clipList;
//    }

//    public string WhenAirplaneIsInAir3(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].climbAndMaintain + _altNew + ", " + atcText[_lang].contactMissionControl + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> WhenAirplaneIsInAir3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(atcScript.contactMissionControl);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion

//    #region EMG events: Take Off Cancel

//    public string TakeOffCancel(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].rejectTakeOffEngineFailure + ", " + atcText[_lang].requestReturnToSpot + ".";
//    }

//    public List<AudioClip> TakeOffCancelAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.returnSpot);

//        return clipList;
//    }

//    public string CanTexiQues()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].areYouAbleToTaxi + "?";
//    }

//    public List<AudioClip> CanTexiQuesAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.canTexiQ);

//        return clipList;
//    }

//    public string CanTexiAns()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].weAreAbleToTaxi + ", " + atcText[_lang].thanksForYourHelp + "!";
//    }

//    public List<AudioClip> CanTexiAnsAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.canTexiA);
//        clipList.Add(atcScript.thanks);

//        return clipList;
//    }

//    #endregion Take Off Cancle

//    #region  Emergency event(Arrival): No fuel

//    public string FirstLineWhenAirplaneComesIn(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].maydayMaydayMaydayFuel + ", " + atcText[_lang].tokyoApproach + ", " + _flightNo + "!";
//    }

//    public List<AudioClip> FirstLineWhenAirplaneComesInAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.mayDay);
//        clipList.Add(atcScript.tokoyoApproach);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string RadioTroubleStart(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].maydayMaydayMayday + ", " + atcText[_lang].tokyoApproach + ", " + _flightNo + ", " + atcText[_lang].declareEmergency + ", " + atcText[_lang].squawk7600 + ".";
//    }

//    public List<AudioClip> RadioTroubleStartAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.mayDay);
//        clipList.Add(atcScript.tokoyoApproach);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.declaringEmergencyQ);
//        clipList.Add(atcScript.squawk);
//        clipList.Add(atcScript.seven);
//        clipList.Add(atcScript.six);
//        clipList.Add(atcScript.zero);
//        clipList.Add(atcScript.zero);
//        return clipList;
//    }

//    public string AfterSelectingConfirmEmergency(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].declaringAnEmergency + "?";
//    }

//    public List<AudioClip> AfterSelectingConfirmEmergencyAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.declaringEmergencyQ);
//        return clipList;
//    }

//    public string AfterSelectingConfirmEmergencyAgain()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].affirm + ", " + atcText[_lang].declaringEmergency + ".";
//    }

//    public List<AudioClip> AfterSelectingConfirmEmergencyAgainAudio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        //clipList.Add(ATC.instance.affirm);
//        clipList.Add(atcScript.declaringEmergencyA);
//        return clipList;
//    }

//    public string ReducingSpeed(string _flightNo, string _reducedFlySpeed)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].reducingSpeedTo + _reducedFlySpeed + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ReducingSpeedAudio(AudioClip _flightNo, AudioClip _reducedFlySpeed1, AudioClip _reducedFlySpeed2, AudioClip _reducedFlySpeed3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.reduceSpeedTo);
//        clipList.Add(_reducedFlySpeed1);
//        clipList.Add(_reducedFlySpeed2);
//        clipList.Add(_reducedFlySpeed3);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string SelectRunwayExit(string _flightNo, string _LRDir, string _runwayExit)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].turn + _LRDir + _runwayExit + ", " + atcText[_lang].contactGround121 + ". " + atcText[_lang].areYouAbleToTaxi + "?";
//    }

//    public List<AudioClip> SelectRunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactGroundNumber);
//        clipList.Add(atcScript.canTexiQ);
//        return clipList;
//    }

//    public string RunwayExit(string _flightNo, string _LRDir, string _runwayExit)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].weAreAbleToTaxi + ", " + atcText[_lang].thanksForYourHelp + "!" + atcText[_lang].turning + _LRDir + _runwayExit + ", " + atcText[_lang].contactingGround + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> RunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.canTexiA);
//        clipList.Add(atcScript.thanks);
//        clipList.Add(atcScript.turning);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactingGround);
//        //clipList.Add(ATC.instance.ground);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion


//    #region Same as normal Aircraft: Landed

//    public string CrossRunwayWhileTaxing(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].ground + ", " + _flightNo + "," + atcText[_lang].requestCrossRunway + ".";
//    }

//    public List<AudioClip> CrossRunwayWhileTaxingAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.ground);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestCrossRunway);
//        return clipList;
//    }

//    public string CrossRunwayWhileTaxingAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tower + ", " + _flightNo + ", " + atcText[_lang].requestCrossRunway + ".";
//    }

//    public List<AudioClip> CrossRunwayWhileTaxingAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestCrossRunway);
//        return clipList;
//    }

//    public string AfterCrossRunwayWhileTaxingChooseStandby(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].continueHold + ".";
//    }

//    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseStandbyAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.continueHold);
//        return clipList;
//    }

//    public string AfterCrossRunwayWhileTaxingChooseCrossRunway(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].clearedCrossRunway + ".";
//    }

//    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseCrossRunwayAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.clearedCrossRunway);
//        return clipList;
//    }

//    public string AfterCrossRunwayWhileTaxingChooseCrossRunwayAgain(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].clearedCrossRunway + ", " + _flightNo;
//    }

//    public List<AudioClip> AfterCrossRunwayWhileTaxingChooseCrossRunwayAgainAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.clearedCrossRunway);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    #endregion


//    #region Emergency event(Arrival): Sick passenger

//    public string SickPassengerComesIn(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].panPanPanPanPanPan + ", " + atcText[_lang].tokyoApproach + ", " + _flightNo + "," + atcText[_lang].passengerAboardInMedicalDistress + "!";
//    }

//    public List<AudioClip> SickPassengerComesInAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.panPan);
//        clipList.Add(atcScript.tokoyoApproach);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.passangerSick);
//        return clipList;
//    }

//    public string SickPassengerAtRunwayExit(string _flightNo, string _LRDir, string _runwayExit)
//    {
//        int _lang = AssignLanguage();
//        return "" + _flightNo + ", " + atcText[_lang].turn + _LRDir + " " + _runwayExit + ", " + atcText[_lang].contactGround127 + ". " + atcText[_lang].theAmbulanceIsStandingByAtSpot + ".";
//    }

//    public List<AudioClip> SickPassengerAtRunwayExitAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactGroundNumber);
//        clipList.Add(atcScript.ambulanceStandBy);

//        return clipList;
//    }

//    public string SickPassengerAtRunwayExitAgain(string _flightNo, string LRDir, string runwayExit)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].thanksForYourHelp + "! " + atcText[_lang].turning + LRDir + " " + runwayExit + ", " + atcText[_lang].contactingGround + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> SickPassengerAtRunwayExitAgainAudio(AudioClip _flightNo, AudioClip _LRDir, AudioClip _runwayExit1, AudioClip _runwayExit2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.thanks);
//        clipList.Add(atcScript.turn);
//        clipList.Add(_LRDir);
//        clipList.Add(_runwayExit1);
//        clipList.Add(_runwayExit2);
//        clipList.Add(atcScript.contactingGround);

//        clipList.Add(_flightNo);
//        return clipList;
//    }


//    public string GearMalfunction(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].unableToTaxiDueToLandingGearMalfunction + ".";
//    }

//    public List<AudioClip> GearMalfunctionAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.gearMalfunction);
//        return clipList;
//    }

//    public string GearMalfunction1()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].closingYourRunway + ", " + atcText[_lang].holdingPresentPosition + ".";
//    }

//    public List<AudioClip> GearMalfunction1Audio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.closingRunway);
//        clipList.Add(atcScript.holdPresentPosition);
//        return clipList;
//    }

//    public string GearMalfunction2()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].holdPresentPosition + ".";
//    }

//    public List<AudioClip> GearMalfunction2Audio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.holdPresentPosition);
//        return clipList;
//    }

//    public string GearMalfunction3(string _closedRunwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].allStationsAllStationsRunway + _closedRunwayNo + atcText[_lang].isClosed + "!";
//    }

//    public List<AudioClip> GearMalfunction3Audio(AudioClip _closedRunwayNo1, AudioClip _closedRunwayNo2, AudioClip _closedRunwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.allStations);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_closedRunwayNo1);
//        clipList.Add(_closedRunwayNo2);
//        clipList.Add(_closedRunwayNo3);
//        clipList.Add(atcScript.isClosed);
//        return clipList;
//    }

//    public string EngineProblem(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + ", " + atcText[_lang].unableToTaxiDueToNo1EngineProblem + ".";
//    }

//    public List<AudioClip> EngineProblemAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.engine1Problem);
//        return clipList;
//    }

//    public string ArrivalTestFlight(string _flightNo, string _altA, string _altB, string _atisCode, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoApproach + ", " + _flightNo + ", " + atcText[_lang].leaving + _altA + atcText[_lang].leaving + _altB + ", " + atcText[_lang].weHaveInformation + _atisCode + atcText[_lang].andRequestFlyByOverRunway + _runwayNo;
//    }

//    public List<AudioClip> ArrivalTestFlightAudio(AudioClip _flightNo, AudioClip _altA1, AudioClip _altA2, AudioClip _altA3, AudioClip _altB1, AudioClip _altB2, AudioClip _altB3, AudioClip _atisCode, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoApproach);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.leaving);
//        clipList.Add(_altA1);
//        clipList.Add(_altA2);
//        clipList.Add(_altA3);
//        clipList.Add(atcScript.to);
//        clipList.Add(_altB1);
//        clipList.Add(_altB2);
//        clipList.Add(_altB3);
//        clipList.Add(atcScript.weHaveInformation);
//        clipList.Add(_atisCode);
//        clipList.Add(atcScript.requestFlyByRunway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string FlybyOverRunway(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + ", " + _flightNo + atcText[_lang].flyByOverRunway + _runwayNo + ".";
//    }

//    public List<AudioClip> FlybyOverRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.flyByOver);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string ClearedToFlyby(string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].clearedToFlybyRunway + _runwayNo + ".";
//    }

//    public List<AudioClip> ClearedToFlybyAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.clearedToFlyby);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string ClearedToFlybyAgain(string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].thankYou + ", " + atcText[_lang].clearedToFlybyRunway + _runwayNo;
//    }

//    public List<AudioClip> ClearedToFlybyAgainAudio(AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.thankYou);
//        clipList.Add(atcScript.clearedToFlyby);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string NextFullStop(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].contactingDeparture + ", " + _flightNo + ", " + atcText[_lang].nextFullStop + ".";
//    }

//    public List<AudioClip> NextFullStopAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.contactingDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.nextFullStop);
//        return clipList;
//    }

//    public string RequestLandingRunway(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDeparture + _flightNo + ", " + atcText[_lang].requestLandingRunway + _runwayNo + ".";
//    }

//    public List<AudioClip> RequestLandingRunwayAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestLanding);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }

//    public string RequestLandingRunwayAgain(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].requestLandingRunway + _runwayNo + ".";
//    }

//    public List<AudioClip> RequestLandingRunwayAgainAudio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.requestLanding);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        return clipList;
//    }


//    public string TouchAndGo(string _flightNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoTower + _flightNo + ". " + atcText[_lang].requestTouchAndGo + ".";
//    }

//    public List<AudioClip> TouchAndGoAudio(AudioClip _flightNo, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.tokoyoTower);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestTouchAndGo);
//        return clipList;
//    }

//    public string TouchAndGo1(string _flightNo, string _runwayNo, string _windDir, string _windForce)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].runway + _runwayNo + ", " + atcText[_lang].clearedTouchAndGo + ", " + atcText[_lang].wind + _windDir + atcText[_lang].at + _windForce + ".";
//    }

//    public List<AudioClip> TouchAndGo1Audio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, AudioClip _windDir1, AudioClip _windDir2, AudioClip _windForce1, AudioClip _windForce2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.clearedTouchAndGo);
//        clipList.Add(_windDir1);
//        clipList.Add(_windDir2);
//        clipList.Add(atcScript.at);
//        clipList.Add(_windForce1);
//        clipList.Add(_windForce2);
//        return clipList;
//    }

//    public string TouchAndGo2(string _flightNo, string _runwayNo)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].runway + _runwayNo + "," + atcText[_lang].clearedTouchAndGo + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> TouchAndGo2Audio(AudioClip _flightNo, AudioClip _runwayNo1, AudioClip _runwayNo2, AudioClip _runwayNo3, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();

//        clipList.Add(atcScript.runway);
//        clipList.Add(_runwayNo1);
//        clipList.Add(_runwayNo2);
//        clipList.Add(_runwayNo3);
//        clipList.Add(atcScript.clearedTouchAndGo);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string TouchAndGo3()
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].request + ", " + atcText[_lang].fullStopLanding + ".";
//    }

//    public List<AudioClip> TouchAndGo3Audio(GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.requestFullStopLanding);
//        return clipList;
//    }
//    #endregion


//    #region Change Altitude

//    public string ChangeAltitude(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].descendAndMaintain + _altNew + ".";
//    }

//    public List<AudioClip> TouchAndGo3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string ChangeAltitude1(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].descendAndMaintain + _altNew + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ChangeAltitude1Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.descendAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string ChangeAltitude2(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].climbAndMaintain + _altNew + ".";
//    }

//    public List<AudioClip> ChangeAltitude2Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string ChangeAltitude3(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].climbAndMaintain + _altNew + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ChangeAltitude3Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(_flightNo);
//        return clipList;
//    }

//    public string ChangeAltitude4(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].tokyoDeparture + ", " + _flightNo + ", " + atcText[_lang].requestAltitudeChange + _altNew + ".";
//    }

//    public List<AudioClip> ChangeAltitude4Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.tokyoDeparture);
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestAltitudeChange);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string ChangeAltitude5(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].requestApproved + atcText[_lang].climbAndMaintain + _altNew + ".";
//    }

//    public List<AudioClip> ChangeAltitude5Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestApproved);
//        clipList.Add(atcScript.climbAndMaintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string ChangeAltitude6(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return _flightNo + ", " + atcText[_lang].requestDenied + ", " + atcText[_lang].dueToTraffic + ", " + atcText[_lang].maintain + _altNew + ".";
//    }

//    public List<AudioClip> ChangeAltitude6Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(_flightNo);
//        clipList.Add(atcScript.requestDenied);
//        clipList.Add(atcScript.dueToTraffic);
//        clipList.Add(atcScript.maintain);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        return clipList;
//    }

//    public string ChangeAltitude7(string _flightNo, string _altNew)
//    {
//        int _lang = AssignLanguage();
//        return atcText[_lang].roger + ", " + atcText[_lang].maintaining + _altNew + ", " + _flightNo + ".";
//    }

//    public List<AudioClip> ChangeAltitude7Audio(AudioClip _flightNo, AudioClip _altNew1, AudioClip _altNew2, GameObject personSound)
//    {
//        ATC atcScript = personSound.GetComponent<ATC>();
//        List<AudioClip> clipList = new List<AudioClip>();
//        clipList.Add(atcScript.roger);
//        clipList.Add(atcScript.maintaining);
//        clipList.Add(_altNew1);
//        clipList.Add(_altNew2);
//        clipList.Add(_flightNo);
//        return clipList;
//    }


//    #endregion
//}

