using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FX : MonoBehaviour
{
  
    public GameObject Emergency_smoke_particle;
    public GameObject BrakesSmok;
    public GameObject Water_Splesh_particle;
    public GameObject Heat_Haze_particle;
    public bool Emergency_smoke;
    public bool TyreBurnoutSmoke;
    public bool Water_Splesh;
    public bool Heat_Haze;

    //public static FX instanceFx;

    void Awake()
    {
        //instanceFx = this;
    }
    void Start()
    {
        Emergency_smoke_particle.SetActive(false);
        BrakesSmok.SetActive(false);
        Water_Splesh_particle.SetActive(false);
        Heat_Haze_particle.SetActive(false);
    }

    void Update()
    {
        if (this.transform.position.y >= 2 && this.transform.position.y <= 2.5)
        {
           
        }

        Func_Emergency_smoke();
        Func_TyreBurnoutSmoke();
        Func_Water_Splesh();
        Func_Heat_Haze();
    }

    void Func_Emergency_smoke()
    {
        if (Emergency_smoke)
        {
            Emergency_smoke_particle.SetActive(true);
        }

        if (!Emergency_smoke)
        {
            Emergency_smoke_particle.SetActive(false);
        }
    }
    
    void Func_TyreBurnoutSmoke()
    {
        if (TyreBurnoutSmoke)
        {
            BrakesSmok.SetActive(true);
        }

        if (!TyreBurnoutSmoke)
        {
            BrakesSmok.SetActive(false);
        }
    }

    void Func_Water_Splesh()
    {
        if (Water_Splesh)
        {
            Water_Splesh_particle.SetActive(true);
        }

        if (!Water_Splesh)
        {
            Water_Splesh_particle.SetActive(false);
        }
    }

    void Func_Heat_Haze()
    {
        if (Heat_Haze)
        {
            Heat_Haze_particle.SetActive(true);
        }

        if (!Heat_Haze)
        {
            Heat_Haze_particle.SetActive(false);
        }
    }


}