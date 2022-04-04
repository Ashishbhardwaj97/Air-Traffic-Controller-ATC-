using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainComponents : MonoBehaviour
{
    public List<Material> rainMaterialList;
    public List<MeshRenderer> rainMeshList;
    public ParticleSystem particle;
    [Range(0, 400)]
    public float emisionRate;

    public GameObject rainSky;

    public static RainComponents instance;

    void Awake()
    {
        instance = this;
    }


    public void RainOn()
    {
        //for (int i = 0; i < rainMaterialList.Count; i++)
        //{
        //    rainMaterialList[i].EnableKeyword("_EMISSION");
        //}

        //for (int i = 0; i < rainMeshList.Count; i++)
        //{
        //    rainMeshList[i].enabled = false;
        //}
        EmissionOnOFF.instance.EmissionOn();

        DayAndNight.instance.sun.SetActive(false);

        rainSky.SetActive(true);
        var emission = particle.emission;
        emission.enabled = true;
        emission.rateOverTime = emisionRate;
        EmissionOnOFF.instance.godRay.SetActive(false);

    }

    public void RainOFF()
    {
        for (int i = 0; i < rainMaterialList.Count; i++)
        {
            rainMaterialList[i].DisableKeyword("_EMISSION");
        }
        for (int i = 0; i < rainMeshList.Count; i++)
        {
            rainMeshList[i].enabled = true;
        }
        DayAndNight.instance.sun.SetActive(true);
        rainSky.SetActive(false);
        var emission = particle.emission;
        emission.enabled = false;
    }
}