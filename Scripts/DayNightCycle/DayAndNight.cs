using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class DayAndNight : MonoBehaviour
{
    [Range(1, 24)]
    public float time;                     // To set initial time (1-24)
    public float seconds;                  // To check total seconds in ChangeTime()
    public bool isRain;                    // To control Rain 
    public GameObject thunder;             // Directional Light used for thunder
    public GameObject sun;                 // Directional Light Sun
    public GameObject moon;                 // Moon
    public Transform transformObject;      // Rotatory object for day night cycle
    //[HideInInspector]
    public Light sunLight;
    [HideInInspector]
    public Light thunderLight;
    [HideInInspector]
    public float xAngle;
    [HideInInspector]
    public int randomCheck;                 // For random thunderstrom

    public int dayNightCycleSpeed;          // To control speed of cycle (Do not increase speed above 96)

    public bool fog;                        // To control fog
    public int fogStartDist;                // Fog start distance
    public int fogEndDist;                  // Fog end distance

    public Color fogColor;

    public GameObject clouds;                // Clouds Gameobject
    [Range(0f, 1f)]
    public float cloudSpeed;                 // Speed Property of clouds
    [Range(0f, 1f)]
    public float cloudDensity;               // Density Property of clouds
    public Color cloudColor;                 // Color Property of Clouds
    [Range(0f, 360f)]
    public float cloudRotation;              // Rotation of Cloud

    public int thunderAmount;
    public float thunderIntensity;
    public bool isSunRays;

    public static DayAndNight instance;
    public void Awake()
    {
        instance = this;
        thunderLight = thunder.GetComponent<Light>();
        sunLight = sun.GetComponent<Light>();
    }

    public void InitDayTime()
    {
        SetDirectionalLight();
        // seconds = time * 3600;

    }

    public void Start()
    {
        RainOff();
        StartCoroutine(DayNightCycle());
    }

    void Update()
    {

        if (fog)
            FogStart();
        if (!fog)
            FogStop();
        RainController();
    }

    // Starts Fog
    void FogStart()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = fogStartDist;
        RenderSettings.fogEndDistance = fogEndDist;
    }

    //Stops Fog
    void FogStop()
    {
        RenderSettings.fog = false;
    }


    //..........................................//
    // Main Functionality of Day and Night Cycle
    public IEnumerator DayNightCycle()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            if (ScoreManager.instance.timer > 86400)
            {
                ScoreManager.instance.timer = 0;
            }

            transformObject.rotation = Quaternion.Euler(new Vector3((ScoreManager.instance.timer - 21600) / 86400 * 360, 0, 0));

            if (ScoreManager.instance.timer > 19300 && ScoreManager.instance.timer < 19302)
            {
                StartCoroutine(IncreaseSunIntensity());
                break;
            }

            else if (ScoreManager.instance.timer > 64800 && ScoreManager.instance.timer < 64802)
            {
                StartCoroutine(DecreaseSunIntensity());
            }


            if (ScoreManager.instance.timer > 19200 && ScoreManager.instance.timer < 19202)
            {
                EmissionOnOFF.instance.EmissionOFF();
                break;
            }
            else if ((ScoreManager.instance.timer > 64800 && ScoreManager.instance.timer < 64802) /*|| (seconds > 0 && seconds < 4)*/)
            {
                EmissionOnOFF.instance.EmissionOn();
                break;
            }

            yield return new WaitForSeconds(0.1f);

        }
    }



    // Main Functionality of Day and Night Cycle
    //public void ChangeTime()
    //{
    //    if (ScoreManager.instance.timer > 86400)
    //    {
    //        ScoreManager.instance.timer = 0;
    //    }

    //    transformObject.rotation = Quaternion.Euler(new Vector3((ScoreManager.instance.timer - 21600) / 86400 * 360, 0, 0));

    //    if (ScoreManager.instance.timer > 19300 && ScoreManager.instance.timer < 19304)
    //    {
    //        StartCoroutine(IncreaseSunIntensity());
    //    }

    //    else if (ScoreManager.instance.timer > 64800 && ScoreManager.instance.timer < 64804)
    //    {
    //        StartCoroutine(DecreaseSunIntensity());
    //    }


    //    if (ScoreManager.instance.timer > 19200 && ScoreManager.instance.timer < 19202)
    //    {
    //        EmissionOnOFF.instance.EmissionOFF();
    //    }
    //    else if ((ScoreManager.instance.timer > 64800 && ScoreManager.instance.timer < 64802) /*|| (seconds > 0 && seconds < 4)*/)
    //    {
    //        EmissionOnOFF.instance.EmissionOn();
    //    }
    //}

    // To Initialize rotation angle(which sets Time) at the start of scene
    public void SetDirectionalLight()
    {
        if (time >= 18.0f || time < 6.0f)
        {
            sunLight.intensity = 0f;
            EmissionOnOFF.instance.EmissionOn();
            moon.SetActive(true);
        }

        if (time >= 6.0f && time <= 18.0f)
        {
            sunLight.intensity = 1f;
            EmissionOnOFF.instance.EmissionOFF();
            moon.SetActive(false);
        }

        if (time >= 1 && time <= 18)
        {
            xAngle = (time - 6) * 15;
        }

        else if (time >= 19 && time <= 24)
        {
            if (time == 19)
                xAngle = -180;
            else if (time == 20)
                xAngle = -165;
            else if (time == 21)
                xAngle = -150;
            else if (time == 22)
                xAngle = -135;
            else if (time == 23)
                xAngle = -120;
            else
                xAngle = -90;
        }
        transformObject.transform.eulerAngles = new Vector3(xAngle, 0);
    }

    // Increase Sun intensity in morning
    public IEnumerator IncreaseSunIntensity()
    {
        for (int i = 0; i < 300; i++)
        {
            if (sunLight.intensity > 1)
            {
                break;
            }
            sunLight.intensity += 0.005f;
            yield return new WaitForSeconds(0.1f);

        }

        if (DayAndNight.instance.isSunRays)
        {
            EmissionOnOFF.instance.godRay.SetActive(true);
        }

        StartCoroutine(DayNightCycle());

    }

    // Decrease Sun intensity in night
    public IEnumerator DecreaseSunIntensity()
    {
        for (int i = 0; i < 15; i++)
        {
            sunLight.intensity -= 0.1f;
            yield return new WaitForSeconds(0.1f);

        }

    }

    // To control rain
    public bool rainCheck = false;
    public bool rainCheck2 = true;

    void RainController()
    {
        if (isRain && rainCheck == false)
        {
            RainComponents.instance.RainOn();
            thunder.SetActive(true);

            rainCheck = true;
            rainCheck2 = true;
        }

        else if (isRain)
        {
            EmissionOnOFF.instance.godRay.SetActive(false);
            //RainComponents.instance.RainOn();
            randomCheck = UnityEngine.Random.Range(0, thunderAmount);
            if (randomCheck == 0)
                StartCoroutine(ThunderStrom());
        }

        else if (!isRain && rainCheck2 == true)
        {
            RainOff();
        }

    }

    public void RainOff()
    {
        RainComponents.instance.RainOFF();
        thunder.SetActive(false);
        StopCoroutine(ThunderStrom());

        rainCheck = false;
        rainCheck2 = false;
    }


    // For ThunderStrom
    public IEnumerator ThunderStrom()
    {
        if (NintendoController.instance.isPause == 0)
        {
            SFXSound.ins.SFXThunder.volume = SaveAndLoad.ingameVol;
            SFXSound.ins.SFXThunder.Play();
        }
        thunderLight.intensity = Random.Range(0.2f, thunderIntensity);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        thunderLight.intensity = 0f;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
    }

    //For Cloud Change
    public void CloudChange()
    {
        clouds.transform.eulerAngles = new Vector3(0f, cloudRotation, 0f);
        clouds.GetComponent<MeshRenderer>().material.SetFloat("Vector1_9C8525EF", cloudDensity);
        clouds.GetComponent<MeshRenderer>().material.SetFloat("Vector1_569A98A8", cloudSpeed);
        clouds.GetComponent<MeshRenderer>().material.SetColor("Color_8D969F07", cloudColor);
    }


}