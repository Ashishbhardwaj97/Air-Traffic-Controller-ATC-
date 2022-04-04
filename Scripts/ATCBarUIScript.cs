using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ATCBarUIScript : MonoBehaviour
{
    public String AtcBarName;
    public Transform atcBarUITrans, atcTextUITrans;
    public string atcText = "Tokyo_Approach, $ c, leaving flight_level 120 to 100, we_have_information $ i.";
    public bool aTCOpen;
    public Image strapTextBg, atcTextBg, controlBar;
    public Color textStrapBGColor, controlBarColor;
    public int airplaneValue;
    public Transform airplaneStripTrans;


    void Awake()
    {
    }
    void Start()
    {
        atcTextUITrans.GetComponent<Text>().text = atcText;

        strapTextBg = transform.GetChild(0).GetComponent<Image>();
        atcTextBg = transform.GetChild(3).GetComponent<Image>();
        controlBar = transform.GetChild(2).GetComponent<Image>();
        // controlBar.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);
    }
    void Update()
    {
    }
    public void StartBarOutAnim()
    {
        atcTextUITrans.GetComponent<Text>().text = atcText;
        Invoke("ATCbarUIAnimOut", 0f);
    }


    void ATCbarUIAnimOut()
    {
        if (!aTCOpen)
        {
            aTCOpen = true;

            for (int i = 0; i < GameManagerScript.instanceGMS.PlaneStrip.Count; i++)
            {
                if (GameManagerScript.instanceGMS.PlaneStrip[i].transform.GetChild(0).GetChild(4).gameObject.activeInHierarchy)
                {
                    if (GameManagerScript.instanceGMS.PlaneList[i].transform.GetComponentInChildren<CameraMovement>()!= null)
                    {

                        if (GameManagerScript.instanceGMS.currentPlaneActive == GameManagerScript.instanceGMS.PlaneList[i].transform.GetComponent<AircraftScripts>().PlaneNumber)
                        {
                            if (strapTextBg.gameObject.transform.parent.name == GameManagerScript.instanceGMS.PlaneList[i].transform.GetComponent<RadarScript>().currentATC)
                            {                               
                                strapTextBg.color = textStrapBGColor;
                                atcTextBg.color = textStrapBGColor;
                            }
                        }

                    }

                }
            }
            if (AtcBarName == GameManagerScript.instanceGMS.PlaneList[GameManagerScript.instanceGMS.currentPlaneActive].GetComponent<RadarScript>().currentATC)
            {
                UIManager.instance.ATCColorDefelactor(AtcBarName);
            }

        }

        controlBar.color = controlBarColor;
        AnimateTransformFunctions.ins.AnimateTransform(atcBarUITrans, atcBarUITrans.localPosition, new Vector3(-18.57f, atcBarUITrans.localPosition.y, atcBarUITrans.localPosition.z), 2f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseOut");
        StartCoroutine("ATCbarTextUIAnimOutAndIn");
    }

    IEnumerator ATCbarTextUIAnimOutAndIn()
    {
        AnimateTransformFunctions.ins.AnimateTransform(atcTextUITrans, atcTextUITrans.localPosition, new Vector3(-17f, atcTextUITrans.localPosition.y, atcTextUITrans.localPosition.z), 4f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "Linear");
        yield return new WaitForSeconds(8);
        AnimateTransformFunctions.ins.AnimateTransform(atcTextUITrans, atcTextUITrans.localPosition, new Vector3(-65f, atcTextUITrans.localPosition.y, atcTextUITrans.localPosition.z), 3f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "Linear");
        yield return new WaitForSeconds(3.2f);
        atcText = "";
        StartCounterForBarInAnim();
    }
    IEnumerator ATCbarUIAnimIn()
    {
        AnimateTransformFunctions.ins.AnimateTransform(atcBarUITrans, atcBarUITrans.localPosition, new Vector3(18.6f, atcBarUITrans.localPosition.y, atcBarUITrans.localPosition.z), 2f, AnimateTransformFunctions.TransformTypes.Position, AnimateTransformFunctions.AnimAxis.Local, "EaseIn");
        yield return new WaitForSeconds(2.1f);
        atcTextUITrans.localPosition = new Vector3(-17f, atcTextUITrans.localPosition.y, atcTextUITrans.localPosition.z);
        aTCOpen = false;
        strapTextBg.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);
        atcTextBg.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);
        //controlBar.color = new Color(0.125f, 0.125f, 0.125f, 0.784f);
    }

    public float timerValueOfTextWaiting, resetTimerValueofTextWaiting;
    IEnumerator StartCountdown()
    {
        while (timerValueOfTextWaiting > 0)
        {
            //Debug.Log("Countdown: " + timerValueOfTextWaiting);
            yield return new WaitForSeconds(1.0f);
            if (atcText != "")
            {
                StopCounterForBarInAnim();
                atcTextUITrans.GetComponent<Text>().text = atcText;
                atcTextUITrans.localPosition = new Vector3(22.5f, atcTextUITrans.localPosition.y, atcTextUITrans.localPosition.z);
                StartCoroutine(ATCbarTextUIAnimOutAndIn());
                timerValueOfTextWaiting = resetTimerValueofTextWaiting;
            }
            timerValueOfTextWaiting--;
        }
        StartCoroutine(ATCbarUIAnimIn());
        timerValueOfTextWaiting = resetTimerValueofTextWaiting;
    }
    void StartCounterForBarInAnim()
    {
        StartCoroutine("StartCountdown");
    }
    void StopCounterForBarInAnim()
    {
        StopCoroutine("StartCountdown");
    }



}