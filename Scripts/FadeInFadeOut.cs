using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    public static FadeInFadeOut instance;
    //public GameObject towingCar1;//, towingCar2;

    public Material[] towingCarMats;
    public Material[] groundVehicleMats;//, groundVehicleMats_2, groundVehicleMats_3, groundVehicleMats_403;

    //Material[] materials;
    void Awake()
    {
        instance = this;
       // materials = towingCar1.GetComponent<SkinnedMeshRenderer>().materials;
       // towingCarMats2 = towingCar2.GetComponentInChildren<SkinnedMeshRenderer>().materials;
        
        //groundVehicleMats_2 = groundVehicle_s2.GetComponentInChildren<MeshRenderer>().materials;
        //groundVehicleMats_3 = groundVehicle_s3.GetComponentInChildren<MeshRenderer>().materials;
        //groundVehicleMats_403 = groundVehicle_s403.GetComponentInChildren<MeshRenderer>().materials;

    }
    void Start()
    {

       // FadeOut(materials);
    }

    public void FadeOut(Material[] mats)
    {
       
        StartCoroutine(Fade(true, mats));
    }

    public void FadeIn(Material[] mats)
    {
        
        StartCoroutine(Fade(false, mats));
    }

    IEnumerator Fade(bool fadeAway, Material[] mats)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            var color = new Color(1, 1, 1, 1);
            for (int j = 0; j < mats.Length; j = j + 1)
            {
                if (mats[j].HasProperty("_Color"))
                    color = mats[j].color;

                for (float i = 1; i >= 0; i -= .1f)
                {
                    color.a = i;
                    yield return new WaitForSeconds(.01f);
                    if (mats[j].HasProperty("_BaseColor"))
                        mats[j].SetColor("_BaseColor", color);
                    if (mats[j].HasProperty("_TintColor"))
                        mats[j].SetColor("_TintColor", new Color(.5f, .5f, .5f, i));

                    if (mats[j].HasProperty("Vector1_79D32E89"))
                    {
                        mats[j].SetFloat("Vector1_79D32E89", 1 - i);
                    }

                }
                color.a = 0;
                if (mats[j].HasProperty("_TintColor"))
                    mats[j].SetColor("_TintColor", new Color32(150, 150, 150, 0));
                if (mats[j].HasProperty("_BaseColor"))
                    mats[j].SetColor("_BaseColor", color);

                if (mats[j].HasProperty("Vector1_79D32E89"))
                {
                    mats[j].SetFloat("Vector1_79D32E89", 1);
                }
            }
        }
        // fade from transparent to opaque
        else
        {
            var color = new Color(1, 1, 1, 1);
            for (int j = 0; j < mats.Length; j = j + 1)
            {
                //print("name =" + mats[j].name);
                if (mats[j].HasProperty("_Color"))
                    color = mats[j].color;
                for (float i = 0; i <= 1; i += .1f)
                {
                    color.a = i;
                    yield return new WaitForSeconds(.01f);
                    if (mats[j].HasProperty("_BaseColor"))
                        mats[j].SetColor("_BaseColor", color);
                    if (mats[j].HasProperty("_TintColor"))
                        mats[j].SetColor("_TintColor", new Color(.5f, .5f, .5f, i));

                    if (mats[j].HasProperty("Vector1_79D32E89"))
                    {
                        mats[j].SetFloat("Vector1_79D32E89", 1 - i);
                    }
                }
                color.a = 1;
                if (mats[j].HasProperty("_TintColor"))
                    mats[j].SetColor("_TintColor", new Color32(150, 150, 150, 255));
                if (mats[j].HasProperty("_BaseColor"))
                    mats[j].SetColor("_BaseColor", color);

                if (mats[j].HasProperty("Vector1_79D32E89"))
                {
                    mats[j].SetFloat("Vector1_79D32E89", 0);
                }

            }
        }

    }

}
