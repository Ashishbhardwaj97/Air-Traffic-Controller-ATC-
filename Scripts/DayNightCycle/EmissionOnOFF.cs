using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionOnOFF : MonoBehaviour
{
    public List<Material> nightMaterialList;
    public List<MeshRenderer> nightMeshList;
    public List<GameObject> nightGameObjList;
    public List<GameObject> emmisionNightGameObjList;

    public GameObject nightSky;

    public static EmissionOnOFF instance;

    public Material planeShadeMatDay;
    public Material planeShadeMatNight;

    
    public GameObject daySky;
    public GameObject godRay;

    public bool isDay;
    
    void Awake()
    {
        instance = this;
    }

    public void EmissionOn()
    {
        //Debug.Log("Emision ON");
        for (int i = 0; i < nightMaterialList.Count; i++)
        {
            nightMaterialList[i].EnableKeyword("_EMISSION");
        }

        for (int i = 0; i < nightMeshList.Count; i++)
        {
            nightMeshList[i].enabled = true;
        }

        for (int i = 0; i < nightGameObjList.Count; i++)
        {
            nightGameObjList[i].SetActive(true);
        }
        EmissionStart();
        nightSky.SetActive(true);
        StartCoroutine(FadeInSky());
        isDay = false;
        ToGetAirplaneWindoMaterial();
        godRay.SetActive(false);
        
    }


    public void EmissionOFF()
    {
        //Debug.Log("Emision off");
        for (int i = 0; i < nightMaterialList.Count; i++)
        {
            nightMaterialList[i].DisableKeyword("_EMISSION");
        }

        for (int i = 0; i < nightMeshList.Count; i++)
        {
            nightMeshList[i].enabled = false;
        }

        for (int i = 0; i < nightGameObjList.Count; i++)
        {
            nightGameObjList[i].SetActive(false);
        }
        EmissionStop();
        StartCoroutine(FadeSky());
        
        isDay = true;
        ToGetAirplaneWindoMaterial();
        StartCoroutine(DaySkyIn());
        DayAndNight.instance.moon.SetActive(false);
    }


    public IEnumerator FadeSky()
    {
        Color alpha = nightSky.GetComponent<MeshRenderer>().material.color;
        for(int i = 0; i < 400; i++)
        {
            if (alpha.a < 0.1)
            {
                break;
            }
            alpha.a -= 0.01f;
           // print("alpha.a- " + alpha.a);
            nightSky.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", alpha);
            yield return new WaitForSeconds(0.1f);
        }
      //  EmissionOnOFF.instance.godRay.SetActive(true);

        StartCoroutine(DayAndNight.instance.DayNightCycle());
    }

    public IEnumerator FadeInSky()
    {
        Color alpha = nightSky.GetComponent<MeshRenderer>().material.color;
        //print(alpha);
        for (int i = 0; i < 300; i++)
        {
            if (alpha.a > 1)
            {
                break;
            }
            alpha.a += 0.01f;
            nightSky.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", alpha);
            yield return new WaitForSeconds(0.1f);
        }
        //print(alpha);
        DaySkyOFF();

        StartCoroutine(DayAndNight.instance.DayNightCycle());

    }

    void EmissionStart()                                                                                     
    {
        for (int i = 0; i < emmisionNightGameObjList.Count; i++)
        {
            emmisionNightGameObjList[i].GetComponent<MeshRenderer>().material.SetFloat("_Emission_Map", 1);
        }
    }

    void EmissionStop()                                                                                     
    {
        for (int i = 0; i < emmisionNightGameObjList.Count; i++)
        {
            emmisionNightGameObjList[i].GetComponent<MeshRenderer>().material.SetFloat("_Emission_Map", 0);
        }
    }


    void ToGetAirplaneWindoMaterial()
    {
        for (int i = 0; i < GameManagerScript.instanceGMS.PlaneList.Count; i++)
        {
            GameManagerScript.instanceGMS.PlaneList[i].GetComponent<AircraftScripts>().ChangeWindowShader();
        }

    }



    public IEnumerator DaySkyIn()
    {
        Color alpha = daySky.GetComponent<MeshRenderer>().material.color;
        //Debug.Log(alpha);
        alpha.a = 0;
        alpha.r = 1;
        alpha.b = 1;
        alpha.g = 1;
        //Debug.Log(alpha);
        daySky.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", alpha);
        while (true)
        {
            if (alpha.a > 0.5)
            {
                break;
            }

            alpha.a += 0.01f;
            //Debug.Log("increase   " + alpha);

            daySky.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", alpha);
            yield return new WaitForSeconds(0.1f);

        }
        //Debug.Log(alpha);

    }


    public void DaySkyOFF()
    {
        Color alphaDaySky = daySky.GetComponent<MeshRenderer>().material.color;

        //Debug.Log(daySky.GetComponent<MeshRenderer>().material.name);


        alphaDaySky.a = 0.0f;
        alphaDaySky.r = 1;
        alphaDaySky.b = 1;
        alphaDaySky.g = 1;

        daySky.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", alphaDaySky);
    }


}