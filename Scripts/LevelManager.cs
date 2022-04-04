using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<Transform> levels;// _1, level_2;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            //print("levels.Count- "+ levels.Count);
            levels[i].gameObject.SetActive(false);          
        }
        levels[SaveAndLoad.level - 1].gameObject.SetActive(true);

        //print("SaveAndLoad- " + SaveAndLoad.level);
        ScoreManager.instance.goalScoreVal = levels[SaveAndLoad.level - 1].GetComponent<Level>().targetScore;
        UIManager.instance.currentLevelSelected = levels[SaveAndLoad.level - 1].GetComponent<Level>();




        //if (SaveAndLoad.level == 1)
        //{           
        //    level_1.gameObject.SetActive(true);
        //    level_2.gameObject.SetActive(false);            
        //    ScoreManager.instance.goalScoreVal = level_1.GetComponent<Level>().targetScore;

        //    UIManager.instance.currentLevelSelected = level_1.GetComponent<Level>();
        //}
        //if (SaveAndLoad.level == 2) 
        //{           
        //    level_2.gameObject.SetActive(true);
        //    level_1.gameObject.SetActive(false);
        //    ScoreManager.instance.goalScoreVal = level_2.GetComponent<Level>().targetScore;

        //    UIManager.instance.currentLevelSelected = level_2.GetComponent<Level>();
        //}      

    }
  
    void Update()
    {
        
    }
}
