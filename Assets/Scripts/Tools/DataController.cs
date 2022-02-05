using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour
{
    static GameObject container;
    static GameObject _Container
    {
        get
        {
            return container;
        }
    }
    static DataController instance;
   
    //싱글톤 인스턴스
    public static DataController Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataController";
                instance = container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(container);

            }
            return instance;
        }
    }


    public string GameDataFileName = "DataFile";
    public string OptionDataFileName = "Option";

    public GameData gameData;
    public OptionData optionData;

    //데이터 파일 불러오기
    public void LoadGameData(string fileName)
    {

        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        filePath = filePath + ".json";
        if (File.Exists(filePath))
        {

            string fromJsonData = File.ReadAllText(filePath);

            if (fileName == GameDataFileName)
            {
                gameData = JsonUtility.FromJson<GameData>(fromJsonData);
            }
            else if (fileName == OptionDataFileName)
            {
                optionData = JsonUtility.FromJson<OptionData>(fromJsonData);
            }
        }
        else
        {

            TextAsset textAsset = Resources.Load("GameDatas/Json/" + fileName) as TextAsset;
            gameData = JsonUtility.FromJson<GameData>(textAsset.ToString());
            optionData = new OptionData();

        }

    }
    //데이터 리셋: 에셋 폴더에 있는 json파일로 교체
    public void ResetData()
    {
        TextAsset textAsset = Resources.Load("GameDatas/Json/" + GameDataFileName) as TextAsset;
        gameData = JsonUtility.FromJson<GameData>(textAsset.ToString());

    }

    //데이터 파일 정보 갱신
    public void SaveGameData(string fileName)
    {
        string toJsonData;
        if (fileName == "Option")
        {
            optionData.sound = GameManager.instance.soundPlay;
            optionData.backGround = GameManager.instance.backGroundPlay;
            toJsonData = JsonUtility.ToJson(optionData);
        }
        else if (fileName == "DataFile")
        {
            gameData.day = GameManager.instance.day;
            gameData.slotLimit = GameManager.instance.slotLimit;
            gameData.inventoryItems = GameManager.instance.inventoryItems;
            gameData.conBoxList = GameManager.instance.conBoxList;
           toJsonData = JsonUtility.ToJson(gameData);
        }
        else
        {
            toJsonData= JsonUtility.ToJson(gameData);
        }

        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        filePath = filePath + ".json";
        File.WriteAllText(filePath, toJsonData);
    }


    private void OnApplicationQuit()
    {
        SaveGameData("Option");
        SaveGameData("DataFile");
    }
}
