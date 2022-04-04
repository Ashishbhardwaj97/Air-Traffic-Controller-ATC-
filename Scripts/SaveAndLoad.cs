using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    private nn.account.Uid userId;                                                      // Nintendo file saving variables
    private const string mountName = "MySave";                                          // Nintendo file saving variables
    private const string fileName = "MySaveData";                                       // Nintendo file saving variables
    private string filePath;                                                            // Nintendo file saving variables
    private nn.fs.FileHandle fileHandle = new nn.fs.FileHandle();                       // Nintendo file saving variables


    public static int level;                                                           // static varibles (do not loose their value on Scene Change )
    public static string str;                                                          // static varibles (do not loose their value on Scene Change )
    public static float backVol;                                                       // static varibles (do not loose their value on Scene Change )
    public static float ingameVol;                                                     // static varibles (do not loose their value on Scene Change )
    public static float atcVol;                                                        // static varibles (do not loose their value on Scene Change )
    public static int isAchmmtUnlock = 0;                                              // static varibles (do not loose their value on Scene Change )

    public static int inGameText;
    public static int language;
    public static int ATCLanguage;
    public static int autoBirdEyeView;
    public static int aircraftStatus;
    public static int controllsStatus;
    public static int firstOpen = 0;

    //..................................................//
    public static int terminal1Camera;
    public static int IntTerminalCamera;
    public static int runwayCamera;
    //  public static int runway23Camera;
    public static int passengerWindowCamera;
    public static int radioTowerCamera;
    public static int airportBirdCamera;
    //public static int runway34RCamera;
    //...................................................//

    public static int returnToLeveLSelect;
    public Text demo;

    public int nintendoCTRLNumber;

    public GameData gameData;                                                           // All Initializaton of Serilized class objects
    public Master master;                                                               // All Initializaton of Serilized class objects

    public int totalLevelNumbers;
    // All Initializaton of Serilized class objects
    public ListOfLevelData listOfLevelData;                                             // All Initializaton of Serilized class objects
    public LevelData[] levelData /*= new LevelData[22]*/;                                   // All Initializaton of Serilized class objects
                                                                                        // All Initializaton of Serilized class objects
    public ListOfOptionsData listOptionsData;                                                         // All Initializaton of Serilized class objects
    public AllOptionsData[] optionData = new AllOptionsData[1];

    public SaveAchievementsList saveAchievementList;                                    // All Initializaton of Serilized class objects
    public SaveAchievements[] saveAchievement/* = new SaveAchievements[22]*/;               // All Initializaton of Serilized class objects

    public static SaveAndLoad instance;

    public Transform levelButton;
    public Transform achievementButton;

    //.....................Ashish..................//
    public int[] easyLevels;
    public int[] normalLevels;
    public int[] hardLevels;
    public int[] extraLevels;
    public int c;
    //..............................................//
    private void Awake()
    {
        instance = this;
        master = new Master();
        gameData = new GameData();
        listOfLevelData = new ListOfLevelData();

        listOptionsData = new ListOfOptionsData();

        saveAchievementList = new SaveAchievementsList();

    }


    void Start()
    {
        // NintendoController.ninCtrlNumber = nintendoCTRLNumber;
#if UNITY_SWITCH && !UNITY_EDITOR
        nn.account.Account.Initialize();
        nn.account.UserHandle userHandle = new nn.account.UserHandle();

        nn.account.Account.TryOpenPreselectedUser(ref userHandle);
        nn.account.Account.GetUserId(ref userId, userHandle);

        nn.Result result = nn.fs.SaveData.Mount(mountName, userId);
        result.abortUnlessSuccess();

        filePath = string.Format("{0}:/{1}", mountName, fileName);

            Load();
#endif

        levelData = new LevelData[25];
        saveAchievement = new SaveAchievements[30];

        for (int i = 0; i < levelData.Length; i++)
        {
            levelData[i] = new LevelData();
           // levelData[i].levelScore = "0";
        }
        if (string.IsNullOrEmpty(str) && firstOpen == 0)
        {
            StartCoroutine(MenuController.instance.SetDefaultValues(2, 2, 2, 1, 2));
            MenuController.instance.SoundDefault();
        }
    }

    void OnDestroy()
    {

#if UNITY_SWITCH && !UNITY_EDITOR
        nn.fs.FileSystem.Unmount(mountName);
#endif
    }

    //.............................save the score val using Nintendo switch plugins.......................

    public void Save()
    {
        print("Save... ");
        byte[] data;
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
        {
            writer.WriteLine(str);

            writer.Flush();
            stream.Close();
            data = stream.GetBuffer();
            //Debug.Assert(data.Length == saveDataSize);
        }

#if UNITY_SWITCH
        // Nintendo Switch Guideline 0080
        UnityEngine.Switch.Notification.EnterExitRequestHandlingSection();
#endif

        nn.Result result = nn.fs.File.Delete(filePath);
        if (!nn.fs.FileSystem.ResultPathNotFound.Includes(result))
        {
            result.abortUnlessSuccess();
        }

        result = nn.fs.File.Create(filePath, data.Length);
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Write);
        result.abortUnlessSuccess();

        result = nn.fs.File.Write(fileHandle, 0, data, data.LongLength, nn.fs.WriteOption.Flush);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);
        result = nn.fs.FileSystem.Commit(mountName);
        result.abortUnlessSuccess();

#if UNITY_SWITCH
        // Nintendo Switch Guideline 0080
        UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection();
#endif
    }

    //.............................Load the score val using Nintendo switch plugins.......................

    public void Load()
    {
        print("Load...");
        nn.fs.EntryType entryType = 0;
        nn.Result result = nn.fs.FileSystem.GetEntryType(ref entryType, filePath);
        if (nn.fs.FileSystem.ResultPathNotFound.Includes(result)) { return; }
        result.abortUnlessSuccess();

        result = nn.fs.File.Open(ref fileHandle, filePath, nn.fs.OpenFileMode.Read);
        result.abortUnlessSuccess();

        long fileSize = 0;
        result = nn.fs.File.GetSize(ref fileSize, fileHandle);
        result.abortUnlessSuccess();

        byte[] data = new byte[fileSize];
        result = nn.fs.File.Read(fileHandle, 0, data, fileSize);
        result.abortUnlessSuccess();

        nn.fs.File.Close(fileHandle);

        using (MemoryStream stream = new MemoryStream(data))
        using (StreamReader reader = new StreamReader(stream))
        {
            str = reader.ReadLine();
        }
        //if (string.IsNullOrEmpty(str))
        //{
        //    StartCoroutine(MenuController.instance.SetDefaultValues(2, 2, 2, 1, 2));
        //}
        //
        StartCoroutine(RetriveDataTest());
        if (MenuController.isMainGame == 0 && returnToLeveLSelect == 0)
        {
            demo.text = str;
            OptionData();
        }
        RetriveOptionsData();
    }


    // ...............................................................................//

    //.................................This function assign volume of game in a static variable so it does not loose its value on scene change....................//
    public static void SaveSoundValues()
    {
        backVol = Menu_Controller.instance.backgrndMusicSlider.GetComponent<Slider>().value;
        ingameVol = Menu_Controller.instance.inGameSoundSlider.GetComponent<Slider>().value;
        atcVol = Menu_Controller.instance.ATCRadioSlider.GetComponent<Slider>().value;
       // SaveAndLoad.firstOpen = 1;
    }

    public void OptionData()
    {

        if (str != null && master.masterData[0].gameOptionsData.Count != 0)
        {
            // RetriveOptionsData();
            inGameText = master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameTextSettings;
            language = master.masterData[0].gameOptionsData[0].listOfoptions[0].languageSettings;
            ATCLanguage = master.masterData[0].gameOptionsData[0].listOfoptions[0].ATCLanguageSettings;
            autoBirdEyeView = master.masterData[0].gameOptionsData[0].listOfoptions[0].autoBirdEyeViewSettings;
            aircraftStatus = master.masterData[0].gameOptionsData[0].listOfoptions[0].aircraftStatusSettings;
            controllsStatus = master.masterData[0].gameOptionsData[0].listOfoptions[0].controllsStatusSettings;

            terminal1Camera = master.masterData[0].gameOptionsData[0].listOfoptions[0].terminal1CameraSettings;
            IntTerminalCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].IntTerminalCameraSettings;
            runwayCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].runwayCameraSettings;
            // runway23Camera = master.masterData[0].gameOptionsData[0].listOfoptions[0].runway23CameraSettings;
            passengerWindowCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].passengerWindowCameraSettings;
            radioTowerCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].radioTowerSettings;
            airportBirdCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].airportBirdCameraSettings;
            // runway34RCamera = master.masterData[0].gameOptionsData[0].listOfoptions[0].runway34RCameraSettings;
        }
    }

    //..................................Save all Data...............................................// 
    public void OptionDataSave()
    {
        optionData[0] = new AllOptionsData();

        listOptionsData.listOfoptions.Clear();

        optionData[0].backgrndMusicVol = backVol;
        optionData[0].inGameSoundVol = ingameVol;
        optionData[0].ATCRadioVol = atcVol;

        optionData[0].inGameTextSettings = inGameText;
        optionData[0].languageSettings = language;
        optionData[0].ATCLanguageSettings = ATCLanguage;
        optionData[0].autoBirdEyeViewSettings = autoBirdEyeView;
        optionData[0].aircraftStatusSettings = aircraftStatus;
        listOptionsData.listOfoptions.Add(optionData[0]);

        gameData.gameOptionsData.Clear();
        gameData.gameOptionsData.Add(listOptionsData);

        if (MenuController.isMainGame == 1)
        {
            ReInitializeValues();
        }

        master.masterData.Clear();
        master.masterData.Add(gameData);

        str = JsonUtility.ToJson(master);


    }
    //................................Saves Data of level, sound and achievements after level completion..............................//
    public IEnumerator LevelCompleteDataSave()
    {
        if (MenuController.isMainGame == 1 && MenuControlls.instance.NpadButton_B_Down == 0)
        {
            yield return new WaitForSeconds(1f);

            //..................................Save Level Info Starts................................//

            if (levelData[level].level != level)
            {
                levelData[level] = new LevelData();
                levelData[level].level = level;

                levelData[level].levelScore = ScoreManager.instance.scoreText.text;
                for (int j = 0; j < ScoreManager.instance.clearRankImg.Count; j++)
                {
                    if (ScoreManager.instance.clearRankImg[j].enabled == true)
                    {
                        levelData[level].rankNum = ScoreManager.clearRank;
                      //  levelData[level].rank = ScoreManager.instance.clearRankImg[j].sprite;
                        break;
                    }
                }

                listOfLevelData.listOfLevels.Add(levelData[level]);
            }

            else
            {
                if (listOfLevelData.listOfLevels.Count != 0)
                {
                    listOfLevelData.listOfLevels[level - 1].level = level;
                    listOfLevelData.listOfLevels[level - 1].levelScore = ScoreManager.instance.scoreText.text;
                    for (int j = 0; j < ScoreManager.instance.clearRankImg.Count; j++)
                    {
                        if (ScoreManager.instance.clearRankImg[j].enabled == true)
                        {
                            levelData[level].rankNum = ScoreManager.clearRank;

                           // listOfLevelData.listOfLevels[level - 1].rank = ScoreManager.instance.clearRankImg[j].sprite;
                            break;
                        }
                    }
                }
            }
            gameData.gameLevelData.Clear();
            gameData.gameLevelData.Add(listOfLevelData);

            //.............................Save Level Info Ends..........................//



            //.............................Save Achievements Starts..........................//
            if (Achievements.instance != null)
            {
                Achievements.instance.EasyAchievements();
                Achievements.instance.NormalAchievements();
                Achievements.instance.HardAchievements();
                Achievements.instance.SRankEasyAchievements();
                Achievements.instance.SRankNormalAchievements();
                Achievements.instance.SRankHardAchievements();
                Achievements.instance.SRankExtraAchievements();
                Achievements.instance.OneStageSRank();
                Achievements.instance.OneAndOnly();
            }

            yield return new WaitForSeconds(0.5f);

            gameData.gameAchmntList.Clear();
            gameData.gameAchmntList.Add(saveAchievementList);



            //.............................Save Achievements Ends............................//
        }



        //............................Save Sound Volume Start...........................//


        optionData[0] = new AllOptionsData();

        listOptionsData.listOfoptions.Clear();

        optionData[0].backgrndMusicVol = backVol;
        optionData[0].inGameSoundVol = ingameVol;
        optionData[0].ATCRadioVol = atcVol;

        optionData[0].inGameTextSettings = inGameText;
        optionData[0].languageSettings = language;
        optionData[0].ATCLanguageSettings = ATCLanguage;
        optionData[0].autoBirdEyeViewSettings = autoBirdEyeView;
        optionData[0].aircraftStatusSettings = aircraftStatus;
        optionData[0].controllsStatusSettings = controllsStatus;

        optionData[0].terminal1CameraSettings = terminal1Camera;
        optionData[0].IntTerminalCameraSettings = IntTerminalCamera;
        optionData[0].runwayCameraSettings = runwayCamera;
        //  optionData[0].runway23CameraSettings = runway23Camera;
        optionData[0].passengerWindowCameraSettings = passengerWindowCamera;
        optionData[0].radioTowerSettings = radioTowerCamera;
        optionData[0].airportBirdCameraSettings = airportBirdCamera;
        //  optionData[0].runway34RCameraSettings = runway34RCamera;

        listOptionsData.listOfoptions.Add(optionData[0]);

        gameData.gameOptionsData.Clear();
        gameData.gameOptionsData.Add(listOptionsData);

        //............................Save Sound Volume Ends............................//

        if (MenuController.isMainGame == 0 || MenuControlls.instance.NpadButton_B_Down == 1)
        {
            ReInitializeValues();
        }

        master.masterData.Clear();
        master.masterData.Add(gameData);

        str = JsonUtility.ToJson(master);

        Debug.Log(str);
        //if (MenuController.isMainGame == 0)
        //{
        //    demo.text = str;
        //}
        // print(demo);

        // yield return new WaitForSeconds(0f);

#if UNITY_SWITCH && !UNITY_EDITOR
          Save();   // to save
#endif
    }




    //.................................To Save Achievements..............................//
    public void SaveAch(int value, Sprite trophy, string date)
    {
        saveAchievement[value] = new SaveAchievements();
        saveAchievement[value].AchievementNum = value;
       // saveAchievement[value].trophy = trophy;
        saveAchievement[value].date = date;
        saveAchievement[value].isUnlocked = true;
        saveAchievementList.saveAchmntList.Add(saveAchievement[value]);
    }
    //......................................This Function reassign all saved data to respective list before Saving new data and Scene changing ........................//
    public void ReInitializeValues()
    {
        if (str != null)
        {
            master = new Master();
            master = JsonUtility.FromJson<Master>(str);

            if (master.masterData[0].gameLevelData.Count != 0)
            {
                listOfLevelData.listOfLevels.Clear();
                for (int i = 1; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                {
                    levelData[i] = new LevelData();

                    levelData[i].level = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].level;
                    levelData[i].levelScore = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].levelScore;
                   // levelData[i].rank = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].rank;
                    levelData[i].rankNum = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].rankNum;
                    listOfLevelData.listOfLevels.Add(levelData[i]);
                }

                gameData.gameLevelData.Clear();
                gameData.gameLevelData.Add(listOfLevelData);
            }

            if (master.masterData[0].gameAchmntList.Count != 0)
            {
                saveAchievementList.saveAchmntList.Clear();
                for (int i = 1; i <= master.masterData[0].gameAchmntList[0].saveAchmntList.Count; i++)
                {
                    saveAchievement[i] = new SaveAchievements();

                    saveAchievement[i].AchievementNum = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].AchievementNum;
                    saveAchievement[i].date = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].date;
                   // saveAchievement[i].trophy = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].trophy;
                    saveAchievement[i].isUnlocked = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].isUnlocked;
                    saveAchievementList.saveAchmntList.Add(saveAchievement[i]);
                }
                gameData.gameAchmntList.Clear();
                gameData.gameAchmntList.Add(saveAchievementList);

                if (str != null && master.masterData[0].gameAchmntList.Count != 0 && MenuController.isMainGame == 1)
                {
                    Achievements.instance.CheckUnlockAchievement();
                }
            }
        }
    }

    public void ReInitializeLevelValues()
    {

        if (str != null)
        {
            master = new Master();
            master = JsonUtility.FromJson<Master>(str);

            if (master.masterData[0].gameLevelData.Count != 0)
            {
                listOfLevelData.listOfLevels.Clear();
                for (int i = 1; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                {
                    levelData[i] = new LevelData();

                    levelData[i].level = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].level;
                    levelData[i].levelScore = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].levelScore;
                   // levelData[i].rank = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].rank;
                    levelData[i].rankNum = master.masterData[0].gameLevelData[0].listOfLevels[i - 1].rankNum;
                    listOfLevelData.listOfLevels.Add(levelData[i]);
                }
            }

            if (master.masterData[0].gameAchmntList.Count != 0)
            {
                saveAchievementList.saveAchmntList.Clear();
                for (int i = 1; i <= master.masterData[0].gameAchmntList[0].saveAchmntList.Count; i++)
                {
                    saveAchievement[i] = new SaveAchievements();

                    saveAchievement[i].AchievementNum = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].AchievementNum;
                    saveAchievement[i].date = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].date;
                  //  saveAchievement[i].trophy = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].trophy;
                    saveAchievement[i].isUnlocked = master.masterData[0].gameAchmntList[0].saveAchmntList[i - 1].isUnlocked;
                    saveAchievementList.saveAchmntList.Add(saveAchievement[i]);
                }

                if (str != null && master.masterData[0].gameAchmntList.Count != 0 && MenuController.isMainGame == 1)
                {
                    Achievements.instance.CheckUnlockAchievement();
                }
            }
        }
        else
        {
            levelData[level] = new LevelData();
        }


        if (MenuController.isMainGame == 1)
        {
           
            StartCoroutine(Achievements.instance.CheckAchievement());
        }

    }


    //..........This function runs after (Nintendo funtionality) Load and Retrive Saved data.......................// 

    public IEnumerator RetriveDataTest()
    {

        if (str != null)
        {
            master = JsonUtility.FromJson<Master>(str);

            if (master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameAchmntList[0].saveAchmntList != null)
                {
                    isAchmmtUnlock = 1;
                }
            }

        }
        yield return new WaitForSeconds(0f);
    }

    public void RetriveOptionsData()
    {
        if (str != null)
        {
            master = JsonUtility.FromJson<Master>(str);
        }

    }


    //............................(On Click Function) Assign Values When Click on Level Button......................//
    public void InputValues(int levelNumber)
    {
        if (str != null)
        {
            StartCoroutine(RetriveDataTest());
        }

        if (str != null && master.masterData[0].gameLevelData.Count != 0)
        {
            for (int i = 0; i < master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels[i].level == levelNumber)
                {
                    levelButton.GetComponent<RealTimeText>().highScore.text = master.masterData[0].gameLevelData[0].listOfLevels[i].levelScore;

                    if (master.masterData[0].gameLevelData[0].listOfLevels.Count >= levelNumber)
                    {
                        if (master.masterData[0].gameLevelData[0].listOfLevels[i].rankNum == 0)
                        {
                            Debug.Log("S");
                            levelButton.GetComponent<RealTimeText>().rank.sprite = Menu_Controller.instance.rankImage.transform.GetChild(0).GetComponent<Image>().sprite;
                        }

                        else if (master.masterData[0].gameLevelData[0].listOfLevels[i].rankNum == 1)
                        {
                            Debug.Log("A");
                            levelButton.GetComponent<RealTimeText>().rank.sprite = Menu_Controller.instance.rankImage.transform.GetChild(1).GetComponent<Image>().sprite;
                        }

                        else if (master.masterData[0].gameLevelData[0].listOfLevels[i].rankNum == 2)
                        {
                            Debug.Log("B");
                            levelButton.GetComponent<RealTimeText>().rank.sprite = Menu_Controller.instance.rankImage.transform.GetChild(2).GetComponent<Image>().sprite;
                        }

                        else if (master.masterData[0].gameLevelData[0].listOfLevels[i].rankNum == 3)
                        {
                            Debug.Log("C");
                            levelButton.GetComponent<RealTimeText>().rank.sprite = Menu_Controller.instance.rankImage.transform.GetChild(3).GetComponent<Image>().sprite;
                        }
                    }
                }
            }
        }
    }


    //..........................(On Click Function) It handles NEW and tick Functionality on level button.............//
    public void InputLevelInfo()
    {
        if (str != null)
        {
            StartCoroutine(RetriveDataTest());
        }

        if (str != null && master.masterData[0].gameLevelData.Count != 0)
        {
            for (int i = 0; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
            {
                if (MenuController.instance.operationPanel.activeInHierarchy)
                {
                    if (MenuControlls.instance.menu_List != null)
                    {
                        if (i == master.masterData[0].gameLevelData[0].listOfLevels.Count)
                        {
                            MenuController.instance.allLevelButtons[i].transform.GetChild(3).gameObject.SetActive(true);
                            MenuController.instance.allLevelButtons[i].transform.GetChild(4).gameObject.SetActive(false);
                            MenuController.instance.allLevelButtons[i].transform.GetChild(5).gameObject.SetActive(false);
                            SFXSound.ins.SFX.clip = SFXSound.ins.unlockLevel;
                            SFXSound.ins.SFX.Play();
                            break;
                        }
                        MenuController.instance.allLevelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                        MenuController.instance.allLevelButtons[i].transform.GetChild(4).gameObject.SetActive(false);
                        MenuController.instance.allLevelButtons[i].transform.GetChild(5).gameObject.SetActive(false);
                    }
                }

            }

        }

        int lastEasyButton = MenuController.instance.Operation_Easy_Buttons.transform.childCount;

        if (MenuController.instance.Operation_Easy_Buttons.transform.GetChild(lastEasyButton - 1).GetChild(2).gameObject.activeInHierarchy)
        {
            MenuController.instance.operationPanelUpperButtons.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        }


        int lastMediumButton = MenuController.instance.Operation_Medium_Buttons.transform.childCount;

        if (MenuController.instance.Operation_Medium_Buttons.transform.GetChild(lastMediumButton - 1).GetChild(2).gameObject.activeInHierarchy)
        {
            MenuController.instance.operationPanelUpperButtons.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        }



        //int lastHardButton = MenuController.instance.Operation_Easy_Buttons.transform.childCount;

        //if (MenuController.instance.Operation_Easy_Buttons.transform.GetChild(lastEasyButton).GetChild(2).gameObject.activeInHierarchy)
        //{
        //    MenuController.instance.operationPanelUpperButtons.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        //}


    }

    //..........................(On Click Function) Opens related panel when click on Achievement buttons(Vertical buttons e.g baby step, etc) ......................//
    public void InputAchmntPanel(int value)                         // OnClick
    {
        if (str != null)
        {
            StartCoroutine(RetriveDataTest());
        }

        if (str != null && master.masterData[0].gameAchmntList.Count != 0)
        {
            for (int i = 0; i < master.masterData[0].gameAchmntList[0].saveAchmntList.Count; i++)
            {
                if (master.masterData[0].gameAchmntList[0].saveAchmntList[i].AchievementNum == value)
                {
                    SFXSound.ins.Unlocked1();
                    achievementButton.GetComponent<AchivementPanels>().progress.text = "Unlocked";
                    achievementButton.GetComponent<AchivementPanels>().unlockDate.text = master.masterData[0].gameAchmntList[0].saveAchmntList[i].date;
                    achievementButton.GetComponent<AchivementPanels>().blackTrophy.sprite = Menu_Controller.instance.allPanelButton.transform.GetChild(master.masterData[0].gameAchmntList[0].saveAchmntList[i].AchievementNum - 1).GetChild(3).GetComponent<Image>().sprite;
                    break;
                }

                else
                {
                    SFXSound.ins.Unlocked();
                }

            }
        }

        if (achievementButton.gameObject.tag == "Slider")
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count * 1f) / (Achievements.easyLevelCount);
                int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
            }
        }

        else if (achievementButton.gameObject.tag == "ApprenticeSlider")
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > Achievements.easyLevelCount)
                {
                    achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - Achievements.easyLevelCount * 1f) / (Achievements.normalLevelCount);
                    int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                    achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                }
            }
        }

        else if (achievementButton.gameObject.tag == "ProfessionalSlider")
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > Achievements.easyLevelCount + Achievements.normalLevelCount)
                {
                    achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - Achievements.easyLevelCount - Achievements.normalLevelCount * 1f) / (Achievements.hardLevelCount);
                    int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                    achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                }
            }
        }

        else if (achievementButton.gameObject.tag == "QualifiedATC")        //Srank all easy
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > 0)
                {
                    if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length)
                    {
                        c = easyLevels.Length;

                        if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[c].levelScore) >= easyLevels[c] + 2000)
                        {
                            achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count * 1f) / (Achievements.easyLevelCount);
                            int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                            achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                        {
                            if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[i].levelScore) >= easyLevels[i] + 2000)
                            {
                                achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count * 1f) / (Achievements.easyLevelCount);
                                int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                                achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        else if (achievementButton.gameObject.tag == "Navigator")      //Srank all normal
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length)
                {
                    if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length + normalLevels.Length)
                    {
                        c = master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length;

                        if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[c].levelScore) >= normalLevels[c] + 2000)
                        {
                            achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length * 1f) / (Achievements.easyLevelCount);
                            int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                            achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                        }
                    }
                    else
                    {
                        for (int i = easyLevels.Length + 1; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                        {
                            if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[i].levelScore) >= normalLevels[i] + 2000)
                            {
                                achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length * 1f) / (Achievements.easyLevelCount);
                                int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                                achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        else if (achievementButton.gameObject.tag == "AirTraffic")        //Srank all hard
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length + normalLevels.Length)
                {
                    if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length + normalLevels.Length + hardLevels.Length)
                    {
                        c = master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length;

                        if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[c].levelScore) >= hardLevels[c] + 2000)
                        {
                            achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length * 1f) / (Achievements.easyLevelCount);
                            int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                            achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                        }
                    }
                    else
                    {
                        for (int i = easyLevels.Length + normalLevels.Length + 1; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                        {
                            if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[i].levelScore) >= hardLevels[i] + 2000)
                            {
                                achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length * 1f) / (Achievements.easyLevelCount);
                                int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                                achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        else if (achievementButton.gameObject.tag == "AirportHero")       //Srank all extra
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);

            achievementButton.GetComponent<AchivementPanels>().slider.value = 0f;
            achievementButton.GetComponent<AchivementPanels>().percentageText.text = 0.ToString();
            if (str != null && master.masterData[0].gameAchmntList.Count != 0)
            {
                if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length + normalLevels.Length + hardLevels.Length)
                {
                    if (master.masterData[0].gameLevelData[0].listOfLevels.Count > easyLevels.Length + normalLevels.Length + hardLevels.Length + extraLevels.Length)
                    {
                        c = master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length - hardLevels.Length;

                        if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[c].levelScore) >= extraLevels[c] + 2000)
                        {
                            achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length * 1f) / (Achievements.easyLevelCount);
                            int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                            achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                        }
                    }
                    else
                    {
                        for (int i = easyLevels.Length + normalLevels.Length + hardLevels.Length + 1; i <= master.masterData[0].gameLevelData[0].listOfLevels.Count; i++)
                        {
                            if (int.Parse(master.masterData[0].gameLevelData[0].listOfLevels[i].levelScore) >= extraLevels[i] + 2000)
                            {
                                achievementButton.GetComponent<AchivementPanels>().slider.value = (master.masterData[0].gameLevelData[0].listOfLevels.Count - easyLevels.Length - normalLevels.Length * 1f) / (Achievements.easyLevelCount);
                                int a = Convert.ToInt32(achievementButton.GetComponent<AchivementPanels>().slider.value * 100f);
                                achievementButton.GetComponent<AchivementPanels>().percentageText.text = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        else
        {
            achievementButton.GetComponent<AchivementPanels>().slider.gameObject.SetActive(false);
            achievementButton.GetComponent<AchivementPanels>().percentageText.gameObject.SetActive(false); achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(true);
            achievementButton.GetComponent<AchivementPanels>().fixPercentageText.gameObject.SetActive(false);
        }
    }



    //.......................... (On Click Function) Assign Values When Click on Achievement panel's Horizontal Button (i.e  All, Lock, Unlock)......................//
    public void InputAchmntButton(int value)                        // OnClick
    {
        if (str != null)
        {
            StartCoroutine(RetriveDataTest());
        }

        if (str != null && master.masterData[0].gameAchmntList.Count != 0)
        {
            if (value == 1)
            {
                Menu_Controller.instance.achmntDynamicPanel.SetActive(true);
                if (isAchmmtUnlock == 1)
                {
                    for (int j = 0; j < master.masterData[0].gameAchmntList[0].saveAchmntList.Count; j++)
                    {

                        Menu_Controller.instance.allPanelButton.transform.GetChild(master.masterData[0].gameAchmntList[0].saveAchmntList[j].AchievementNum - 1).GetChild(8).gameObject.SetActive(false);
                        Menu_Controller.instance.allPanelButton.transform.GetChild(master.masterData[0].gameAchmntList[0].saveAchmntList[j].AchievementNum - 1).GetChild(3).gameObject.SetActive(true);/* = master.masterData[0].gameAchmntList[0].saveAchmntList[i].trophy;*/
                        MenuController.instance.achievementSlider.GetComponent<Slider>().value = ((j + 1) / 21f); 
                        MenuController.instance.achievementPercentText.GetComponent<Text>().text = (((int)(((j  + 1)/ 21f) * 100f)) + "%").ToString(); 
                    }
                }
            }

            else if (value == 2)
            {
                Menu_Controller.instance.achmntDynamicPanel.SetActive(false);
                if (isAchmmtUnlock == 1)
                {
                    for (int i = 0; i < master.masterData[0].gameAchmntList[0].saveAchmntList.Count; i++)
                    {
                        Menu_Controller.instance.achmntPanelButton.transform.GetChild(master.masterData[0].gameAchmntList[0].saveAchmntList[i].AchievementNum - 1).gameObject.SetActive(false);
                    }
                }
            }

            else if (value == 3)
            {
                if (isAchmmtUnlock == 1)
                {
                    Menu_Controller.instance.achmntDynamicPanel.SetActive(true);
                    for (int j = 0; j < master.masterData[0].gameAchmntList[0].saveAchmntList.Count; j++)
                    {
                        Menu_Controller.instance.unlockAchmntPanelButton.transform.GetChild(master.masterData[0].gameAchmntList[0].saveAchmntList[j].AchievementNum - 1).gameObject.SetActive(true);
                    }
                }
            }
        }

        if (value == 1)
        {
            Menu_Controller.instance.achmntDynamicPanel.SetActive(true);
        }
        if (value == 2)
        {
            Menu_Controller.instance.achmntDynamicPanel.SetActive(false);
        }

        if (value == 3 && isAchmmtUnlock == 0)
        {
            Menu_Controller.instance.achmntDynamicPanel.SetActive(false);
        }

    }

    //.......................... (On Click Function) Assign Values When Click on Sound Sliders......................//

   


    public void InputSound()                       // OnClick
    {
        if (str != null)
        {
            StartCoroutine(RetriveDataTest());
        }

        if (str == null && firstOpen == 0)
        {
            StartCoroutine(MenuController.instance.SetDefaultValues(2, 2, 2, 1, 2));
            firstOpen = 1;
        }

        if (str != null && master.masterData[0].gameOptionsData.Count != 0)
        {
            Menu_Controller.instance.backgrndMusicSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].backgrndMusicVol;
            Menu_Controller.instance.inGameSoundSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameSoundVol;
            Menu_Controller.instance.ATCRadioSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].ATCRadioVol;
        }
        if (returnToLeveLSelect == 1 || firstOpen == 1)
        {
            Menu_Controller.instance.backgrndMusicSlider.GetComponent<Slider>().value = backVol;
            Menu_Controller.instance.inGameSoundSlider.GetComponent<Slider>().value = ingameVol;
            Menu_Controller.instance.ATCRadioSlider.GetComponent<Slider>().value = atcVol;
            //  returnToLeveLSelect = 0;
        }
    }

    public void Options_OperationData()
    {
        print(inGameText);
        if (inGameText == 0 && str == null)
        {
            StartCoroutine(MenuController.instance.SetDefaultValues(2, 2, 2, 1, 2));
        }

        else if (str != null)
        {
            RetriveOptionsData();

            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameTextSettings == 0)
            {
                StartCoroutine(MenuController.instance.SetDefaultValues(2, 2, 2, 1, 2));
                return;
            }
            if (master.masterData[0].gameOptionsData.Count != 0)
            {
                if (MenuController.instance.optionsPanel.activeInHierarchy /*&& MenuControlls.instance.upperMenu_Selected == MenuControlls.instance.upperMenu_List[0]*/)
                {

                    for (int i = 0; i < MenuController.instance.setDefault.Count; i++)
                    {
                        for (int j = 0; j < MenuController.instance.setDefault[i].transform.childCount; j++)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(j).GetChild(1).gameObject.SetActive(false);
                            MenuController.instance.setDefault[i].transform.GetChild(j).GetChild(2).GetComponent<Text>().color = Color.grey;
                        }

                        if (i == 0)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameTextSettings - 1).GetChild(1).gameObject.SetActive(true);
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameTextSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                        }

                        else if (i == 1)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].languageSettings - 1).GetChild(1).gameObject.SetActive(true);
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].languageSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                        }

                        else if (i == 2)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].ATCLanguageSettings - 1).GetChild(1).gameObject.SetActive(true);
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].ATCLanguageSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                        }

                        else if (i == 3)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].autoBirdEyeViewSettings - 1).GetChild(1).gameObject.SetActive(true);
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].autoBirdEyeViewSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                        }

                        else if (i == 4)
                        {
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].aircraftStatusSettings - 1).GetChild(1).gameObject.SetActive(true);
                            MenuController.instance.setDefault[i].transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].aircraftStatusSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                        }

                    }


                    for (int i = 0; i < MenuController.instance.controllsButtons.transform.childCount; i++)
                    {
                        MenuController.instance.controllsButtons.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                        MenuController.instance.controllsButtons.transform.GetChild(i).GetChild(2).GetComponent<Text>().color = Color.grey;
                    }

                    MenuController.instance.controllsButtons.transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].controllsStatusSettings - 1).GetChild(1).gameObject.SetActive(true);
                    MenuController.instance.controllsButtons.transform.GetChild(master.masterData[0].gameOptionsData[0].listOfoptions[0].controllsStatusSettings - 1).GetChild(2).GetComponent<Text>().color = Color.black;
                    //....................................................//

                    for (int i = 0; i < MenuController.instance.optionCameraButtons.transform.childCount; i++)
                    {
                        if (i == 0)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].terminal1CameraSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);

                                // MenuControlls.instance.menu_Selected.transform.GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        if (i == 1)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].IntTerminalCameraSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        if (i == 2)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].runwayCameraSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        //if (i == 3)
                        //{
                        //    if (master.masterData[0].gameOptionsData[0].listOfoptions[0].runway23CameraSettings == 1)
                        //    {
                        //        MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                        //    }
                        //    else
                        //    {
                        //        MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                        //    }
                        //}

                        if (i == 3)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].passengerWindowCameraSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        if (i == 4)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].radioTowerSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        if (i == 5)
                        {
                            if (master.masterData[0].gameOptionsData[0].listOfoptions[0].airportBirdCameraSettings == 1)
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                            }
                            else
                            {
                                MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                            }
                        }

                        //if (i == 7)
                        //{
                        //    if (master.masterData[0].gameOptionsData[0].listOfoptions[0].runway34RCameraSettings == 1)
                        //    {
                        //        MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                        //    }
                        //    else
                        //    {
                        //        MenuController.instance.optionCameraButtons.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                        //    }
                        //}
                    }
//.....................................................................................................................................................................//

                }
                if (str != null && master.masterData[0].gameOptionsData.Count != 0)
                {
                    Menu_Controller.instance.backgrndMusicSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].backgrndMusicVol;
                    Menu_Controller.instance.inGameSoundSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].inGameSoundVol;
                    Menu_Controller.instance.ATCRadioSlider.GetComponent<Slider>().value = master.masterData[0].gameOptionsData[0].listOfoptions[0].ATCRadioVol;
                }
                if (returnToLeveLSelect == 1)
                {
                    Menu_Controller.instance.backgrndMusicSlider.GetComponent<Slider>().value = backVol;
                    Menu_Controller.instance.inGameSoundSlider.GetComponent<Slider>().value = ingameVol;
                    Menu_Controller.instance.ATCRadioSlider.GetComponent<Slider>().value = atcVol;
                    PauseController.instance.ReInsertSaveValue();
                }
            }
        }

        else
        {
            PauseController.instance.ReInsertSaveValue();
        }
    }
}



//..........................Saves Data of all Levels.............................//
[Serializable]
public class LevelData
{
    public int level;
    public int rankNum;
    public string levelScore;
  //  public Sprite rank;
}

//..........................List of All Level in the game........................//
[Serializable]
public class ListOfLevelData
{
    public List<LevelData> listOfLevels = new List<LevelData>();
}

//..........................Saves Data of Volume of all sounds in the game.........//
[Serializable]
public class AllOptionsData
{
    public float backgrndMusicVol;
    public float inGameSoundVol;
    public float ATCRadioVol;

    public int inGameTextSettings;
    public int languageSettings;
    public int ATCLanguageSettings;
    public int autoBirdEyeViewSettings;
    public int aircraftStatusSettings;
    public int controllsStatusSettings;

    //........................................//
    public int terminal1CameraSettings;
    public int IntTerminalCameraSettings;
    public int runwayCameraSettings;
    // public int runway23CameraSettings;
    public int passengerWindowCameraSettings;
    public int radioTowerSettings;
    public int airportBirdCameraSettings;
    //  public int runway34RCameraSettings;
    //.......................................//
}
[Serializable]
public class ListOfOptionsData
{
    public List<AllOptionsData> listOfoptions = new List<AllOptionsData>();
}

//...........................Save Data of all achievements.........................//
[Serializable]
public class SaveAchievements
{
    public int AchievementNum;
    public string date;
  //  public Sprite trophy;
    public bool isUnlocked;
}

//...........................List of all achievements...............................//
[Serializable]
public class SaveAchievementsList
{
    public List<SaveAchievements> saveAchmntList = new List<SaveAchievements>();
}

//..........................Master class to save and retrive combined data of the game........................//    
[Serializable]
public class GameData
{
    public List<ListOfLevelData> gameLevelData = new List<ListOfLevelData>();
    public List<ListOfOptionsData> gameOptionsData = new List<ListOfOptionsData>();
    public List<SaveAchievementsList> gameAchmntList = new List<SaveAchievementsList>();
}

//..........................Master Class for Saving...........................................................//
[Serializable]
public class Master
{
    public List<GameData> masterData = new List<GameData>();
}




